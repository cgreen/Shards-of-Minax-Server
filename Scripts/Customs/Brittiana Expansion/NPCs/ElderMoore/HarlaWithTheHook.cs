/*
 * Scripts/Custom/DialogueSystem/HarlaWithTheHook.cs
 * Custom NPC: Harla with the Hook – Quest-Giver and Tall-Tale Pirate
 */
using System.IO;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Custom.Dialogue;
using Server.Engines.XmlSpawner2;
using Server.Custom;

namespace Server.Mobiles
{
    [CorpseName("the corpse of Harla with the Hook")]
    public class HarlaWithTheHook : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static HarlaWithTheHook()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "HarlaWithTheHook.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public HarlaWithTheHook()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Harla with the Hook";
            Title = "the Shipwrecked Storyteller";
            Body = 0x191; // Human female
            Hue = 0x834;

            // Unique outfit pieces (each with name & hue)
            var saltCloak = new Cloak() { Name = "Salt-Tangled Cloak", Hue = 0x482 };
            var brigandine = new LeatherChest() { Name = "Weathered Brigandine", Hue = 0x97F };
            var tatteredSash = new BodySash() { Name = "Tide-Stained Sash", Hue = 0x47E };
            var oneBoot = new Boots() { Name = "Lonely Corsair’s Boot", Hue = 0x465 };
            var pirateHat = new TricorneHat() { Name = "Windworn Tricorne", Hue = 0x845 };
            var patchPants = new ShortPants() { Name = "Patchwork Deckpants", Hue = 0x51C };
            var fishnetGlove = new StuddedGloves() { Name = "Fishnet Glove (Left)", Hue = 0x59B };
            var ironHook = new BoneGloves() { Name = "Iron Hook (Right)", Hue = 0x497 }; // Right hand only

            // Dress her up
            AddItem(saltCloak);
            AddItem(brigandine);
            AddItem(tatteredSash);
            AddItem(oneBoot);
            AddItem(pirateHat);
            AddItem(patchPants);
            AddItem(fishnetGlove);
            AddItem(ironHook);

            HairItemID = 0x203C;
            HairHue = 0x8B0;
            FacialHairItemID = 0; // None

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this); // adds loot/vendor system
        }

        public HarlaWithTheHook(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile pm)
            {
                var root = _dialogue.GetModule("greeting");
                pm.SendGump(new XMLDialogueGump(pm, root, _dialogue));
            }
        }

        public override void Serialize(GenericWriter w) { base.Serialize(w); w.Write(0); }
        public override void Deserialize(GenericReader r) { base.Deserialize(r); r.ReadInt(); }
    }
}
