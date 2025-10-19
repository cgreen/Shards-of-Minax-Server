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
    [CorpseName("the corpse of Mira")]
    public class Mira : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static Mira()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "Mira.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public Mira()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Mira, the Innkeeper's Daughter";
            Title = "of Eldermoor";
            Body = 0x191; // Human female
            Hue = 0x83E;

            AddItem(new FancyShirt() { Name = "Sun-bleached Linen Blouse", Hue = 0x482 });
            AddItem(new PlainDress() { Name = "Cider-Stained Skirt", Hue = 0x26B });
            AddItem(new Cloak() { Name = "Soft Maplewood Cloak", Hue = 0x47B });
            AddItem(new BodySash() { Name = "Wanderer’s Belt of Hidden Pockets", Hue = 0x9C5 });
            AddItem(new Sandals() { Name = "Braided Leather Sandals", Hue = 0x966 });
            AddItem(new FlowerGarland() { Name = "Wildflower Garland", Hue = 0x44D });

            HairItemID = 0x203C;
            HairHue = 0x4B0;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public Mira(Serial serial) : base(serial) { }

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
