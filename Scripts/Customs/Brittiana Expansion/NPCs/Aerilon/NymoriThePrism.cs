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
    [CorpseName("the corpse of Nymori the Prism")]
    public class NymoriThePrism : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static NymoriThePrism()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "NymoriThePrism.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public NymoriThePrism()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nymori the Prism";
            Title = "Painter of Emotions";
            Body = 0x191; // Human female
            Hue = 0x480; // Ethereal blue

            // Unique, poetic outfit:
            AddItem(new FlowerGarland() { Name = "Crown of Wistful Petals", Hue = 0x9C5 }); // soft lavender
            AddItem(new Robe() { Name = "Opaline Brushstroke Gown", Hue = 0xB7E }); // shifting opal
            AddItem(new BodySash() { Name = "Sash of Chromatic Longing", Hue = 0x48E }); // prism blue
            AddItem(new Sandals() { Name = "Steps of Silent Rain", Hue = 0x59D }); // muted silver-blue
            AddItem(new Cloak() { Name = "Veil of Remembered Dusk", Hue = 0xA47 }); // deep twilight purple
            AddItem(new LeatherGloves() { Name = "Palette-Weaver’s Touch", Hue = 0x487 }); // pale pastel

            HairItemID = 0x203B; // Long, flowing
            HairHue = 0x47E; // Iridescent silver
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public NymoriThePrism(Serial serial) : base(serial) { }

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
