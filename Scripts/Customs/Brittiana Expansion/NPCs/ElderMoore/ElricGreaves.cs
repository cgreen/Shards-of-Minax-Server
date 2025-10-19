/*
 * Scripts/Custom/DialogueSystem/ElricGreaves.cs
 * Data-driven dialogue for Elric, the Fence-Builder of Eldermoor.
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
    [CorpseName("the corpse of Elric Greaves")]
    public class ElricGreaves : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ElricGreaves()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ElricGreaves.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ElricGreaves()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Elric Greaves";
            Title = "the Fence-Builder";
            Body = 0x190; // Human male
            Hue = 0x83F;

            // Unique, named outfit
            AddItem(new FancyShirt() { Name = "Fence-Builder's Indigo Shirt", Hue = 0x1F7 });
            AddItem(new LeatherArms() { Name = "Splinterproof Armguards", Hue = 0x845 });
            AddItem(new Kilt() { Name = "Mudstained Work Kilt", Hue = 0x968 });
            AddItem(new HalfApron() { Name = "Carpenter's Tool Apron", Hue = 0xB63 });
            AddItem(new LeatherGloves() { Name = "Oakbark Gauntlets", Hue = 0xA06 });
            AddItem(new Boots() { Name = "Earthfast Boots", Hue = 0x972 });
            AddItem(new StrawHat() { Name = "Rainworn Straw Hat", Hue = 0x839 });
            AddItem(new CarpentersHammer() { Name = "Elric's Heavy Mallet", Hue = 0x1C1 });

            HairItemID = 0x203C; // Messy brown hair
            HairHue = 0x7B2;
            FacialHairItemID = 0x2041; // Unkempt beard
            FacialHairHue = 0x7B2;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public ElricGreaves(Serial serial) : base(serial) { }

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
