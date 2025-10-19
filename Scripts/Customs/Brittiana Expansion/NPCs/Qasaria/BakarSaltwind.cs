/*
 * Scripts/Custom/DialogueSystem/BakarSaltwind.cs
 * Data-driven dialogue, custom outfit, Sunreach-Qasaria lore.
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
    [CorpseName("the corpse of Bakar Saltwind")]
    public class BakarSaltwind : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BakarSaltwind()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BakarSaltwind.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BakarSaltwind()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Bakar";
            Title = "the Saltwind Merchant";
            Body = 0x190; // Human male
            Hue = 0x840;  // Tanned seafarer skin

            // Unique, lore-rich outfit pieces
            AddItem(new WideBrimHat() { Name = "Sunreach Saltcrown", Hue = 0x38F });
            AddItem(new Shirt() { Name = "Spice-Stained Caravan Shirt", Hue = 0x1A3 });
            AddItem(new HalfApron() { Name = "Seafarer's Spicebelt", Hue = 0xB92 });
            AddItem(new LongPants() { Name = "Qasarian Silk Trousers", Hue = 0x2B6 });
            AddItem(new Sandals() { Name = "Sandrunner’s Driftsteps", Hue = 0x968 });
            AddItem(new Cloak() { Name = "Saltwind Duster Cloak", Hue = 0x47D });
            AddItem(new LeatherGloves() { Name = "Trader’s Grip", Hue = 0x59B });
            AddItem(new Cutlass() { Name = "Pearl-Hilted Saltblade", Hue = 0x480 });

            HairItemID = 0x203C; // Medium short hair
            HairHue = 0x47F; // Sun-bleached blonde
            FacialHairItemID = 0x203F; // Mustache and goatee
            FacialHairHue = 0x47F;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public BakarSaltwind(Serial serial) : base(serial) { }

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
