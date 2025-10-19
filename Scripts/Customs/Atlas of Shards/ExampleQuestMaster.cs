using System;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;

/// <summary>
/// A compact quest giver that demonstrates how to hand out every kind of custom
/// QuestScroll (Delivery, Region‑Kill, Collection, Taming, Kill) through your
/// DialogueModule branching system.
/// </summary>
namespace Server.Mobiles
{
    public class ExampleQuestMaster : BaseCreature
    {
        [Constructable]
        public ExampleQuestMaster()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Master Arlen the Taskkeeper";
            Body = 0x190;                         // human male
            Hue  = 0x83EA;                       // light brown robe & sandals
            AddItem(new Robe       { Hue = 0x47E, Name = "Archivist's Robe" });
            AddItem(new Sandals    { Hue = 0x47E });
            AddItem(new WizardsHat { Hue = 0x47E, Name = "Feathered Cap" });
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile player)
            {
                player.SendGump(new DialogueGump(player, BuildRootDialogue(player)));
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Dialogue
        // ─────────────────────────────────────────────────────────────────────
        private DialogueModule BuildRootDialogue(PlayerMobile player)
        {
            var root = new DialogueModule(
                "Greetings, adventurer!  I chronicle deeds great and small.\n" +
                "Prove yourself by completing one of my tasks, and I shall reward you handsomely.");

            // 1) Delivery quest → Cheese Maker
            root.AddOption("I can deliver a message to the Cheese Maker in Britain.",
                _ => !HasScroll<DeliveryQuestScroll>(player, "Cheese Maker"),
                _ =>
                {
                    GiveScroll(player, new DeliveryQuestScroll("Cheese Maker", 0));
                    Continue(player,
                        "Splendid!  Seek out any villager whose trade is cheese‑craft. " +
                        "Hand them the parchment, then return to claim your prize.");
                });

            // 2) Region kill quest → Ratman Cave
            root.AddOption("Point me toward vermin; I shall purge Ratman Cave.",
                _ => !HasScroll<RegionKillQuestScroll>(player, "Ratman Cave"),
                _ =>
                {
                    GiveScroll(player, new RegionKillQuestScroll("Ratman Cave", 15, 0));
                    Continue(player,
                        "Steel your nerves—the stench is worse than the claws. " +
                        "Slay fifteen fiends inside the cavern and the bounty is yours.");
                });

            // 3) Collection quest → 20 Apples
            root.AddOption("I can forage—what supplies are needed?",
                _ => !HasScroll<CollectionQuestScroll>(player, "Apple"),
                _ =>
                {
                    GiveScroll(player, new CollectionQuestScroll("Apple", 20, 0));
                    Continue(player,
                        "Bring me twenty fresh apples.  The castle cook is running short " +
                        "and the Queen must have her pies.");
                });

            // 4) Taming quest → BullFrog
            root.AddOption("My way with beasts is unmatched—set me a challenge.",
                _ => !HasScroll<TamingQuestScroll>(player, "BullFrog"),
                _ =>
                {
                    GiveScroll(player, new TamingQuestScroll("BullFrog", 3, 0));
                    Continue(player,
                        "Tame three sturdy bullfrogs from the marshes and return them alive. " +
                        "Their chorus keeps the mosquitoes at bay.");
                });

            // 5) Kill quest → Ogre
            root.AddOption("Give me a true fight; ogres will do nicely.",
                _ => !HasScroll<KillQuestScroll>(player, "Ogre"),
                _ =>
                {
                    GiveScroll(player, new KillQuestScroll("Ogre", 10, 0));
                    Continue(player,
                        "Ten ogres shall fall to your blade.  Track their camps in the foothills, " +
                        "then bring me proof of their defeat.");
                });

            root.AddOption("Perhaps another time.", _ => true, _ => { /* closes gump */ });

            return root;
        }

        // ─────────────────────────────────────────────────────────────────────
        // Helpers
        // ─────────────────────────────────────────────────────────────────────
        private static bool HasScroll<T>(PlayerMobile pm, string keyword) where T : Item
        {
            return pm.Backpack?.FindItemsByType(typeof(T), true)
                       .OfType<Item>()
                       .Any(i => i.Name != null && i.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) == true;
        }

        private static void GiveScroll(PlayerMobile pm, Item scroll)
        {
            pm.AddToBackpack(scroll);
            pm.SendSound(0x3D); // parchment rustle
        }

        private static void Continue(PlayerMobile pm, string npcText)
        {
            var followUp = new DialogueModule(npcText);
            followUp.AddOption("Thank you; I’ll get started.", _ => true, _ => { });
            pm.SendGump(new DialogueGump(pm, followUp));
        }

        public ExampleQuestMaster(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }
}
