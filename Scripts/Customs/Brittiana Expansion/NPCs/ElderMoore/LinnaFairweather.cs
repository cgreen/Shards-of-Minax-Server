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
    [CorpseName("the corpse of Linna Fairweather")]
    public class LinnaFairweather : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static LinnaFairweather()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "LinnaFairweather.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public LinnaFairweather()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Linna Fairweather";
            Title = "the Weather-Witch of Eldermoor";
            Body = 0x191; // Human female
            Hue = 0x83F;

            AddItem(new HoodedShroudOfShadows { Hue = 0x482 }); // "Cloudcaller’s Veil"
            AddItem(new MonkRobe { Hue = 0x5E3 }); // "Mistweaver Robe"
            AddItem(new Sandals { Hue = 0x1BB }); // "Barefoot Echoes"
            AddItem(new BodySash { Hue = 0x3C3 }); // "Belt of Rushing Rain"

            HairItemID = 0x2049;
            HairHue = 0x47E;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public LinnaFairweather(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile pm)
            {
                var root = _dialogue.GetModule("greeting");
                pm.SendGump(new XMLDialogueGump(pm, root, _dialogue));
            }
        }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write(0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); reader.ReadInt(); }
    }
}
