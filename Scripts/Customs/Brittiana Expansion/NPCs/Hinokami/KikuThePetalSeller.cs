/*
 * Scripts/Custom/DialogueSystem/KikuThePetalSeller.cs
 * Data-driven dialogue, emotional-florist quirks, Hinokami lore.
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
    [CorpseName("the body of Kiku the Petal-Seller")]
    public class KikuThePetalSeller : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static KikuThePetalSeller()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "KikuThePetalSeller.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public KikuThePetalSeller()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kiku";
            Title = "the Petal-Seller";
            Body = 0x191; // Human female
            Hue = 0x47F;  // Light-skinned

            // Unique, Hinokami-appropriate outfit
            AddItem(new FlowerGarland() { Name = "Wreath of Blushing Sakura", Hue = 0x485 });
            AddItem(new FemaleKimono() { Name = "Blossom Kimono", Hue = 0x48C });
            AddItem(new Obi() { Name = "Embroidered Obi", Hue = 0x488 });
            AddItem(new Sandals() { Name = "Petal Sandals", Hue = 0x489 });
            AddItem(new FloweredDress() { Name = "Layered Petal Skirt", Hue = 0x4E7 });
            AddItem(new BodySash() { Name = "Sash of Fragrant Spring", Hue = 0x481 });

            HairItemID = 0x203B; // Long hair
            HairHue = 0x4B5;     // Dark, with a hint of purple
            FacialHairItemID = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            // Kiku sells flowers (custom shop can be added here)
        }

        public KikuThePetalSeller(Serial serial) : base(serial) { }

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
