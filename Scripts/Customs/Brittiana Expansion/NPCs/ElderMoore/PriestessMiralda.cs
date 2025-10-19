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
    [CorpseName("the corpse of Priestess Miralda")]
    public class PriestessMiralda : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static PriestessMiralda()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "PriestessMiralda.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public PriestessMiralda()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Priestess Miralda of Compassion";
            Title = "Shrinekeeper of Eldermoor";
            Body = 0x191; // Human female
            Hue = 0x46F;

            // Custom, named outfit:
            AddItem(new MonkRobe() { Name = "Miralda’s Rose-Gold Vestment", Hue = 0x4F2 });
            AddItem(new Cloak() { Name = "Stole of Kindred Hues", Hue = 0x47E });
            AddItem(new FlowerGarland() { Name = "Garland of Spring Memory", Hue = 0x481 });
            AddItem(new Sandals() { Name = "Pilgrim’s Pink Sandals", Hue = 0x5B1 });
            AddItem(new BodySash() { Name = "Sash of Hidden Grace", Hue = 0x43E });
            AddItem(new GnarledStaff() { Name = "Staff of Gentle Guidance", Hue = 0x47E });

            HairItemID = 0x203C;
            HairHue = 0x482;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public PriestessMiralda(Serial serial) : base(serial) { }

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
