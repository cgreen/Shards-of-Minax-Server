using System.IO;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Custom.Dialogue;
using Server.Engines.XmlSpawner2;

namespace Server.Mobiles
{
    [CorpseName("the curdled remains of Brendyl Wheyfoot")]
    public class BrendylWheyfoot : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BrendylWheyfoot()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BrendylWheyfoot.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BrendylWheyfoot()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Brendyl Wheyfoot";
            Title = "of the Curdled Path";
            Body = 0x190;
            Hue = 0x83F;

            AddItem(new FancyShirt { Hue = 0x480, Name = "Whey-Stained Tunic of Mild Despair" });
            AddItem(new Kilt { Hue = 0x8B3, Name = "Curdled Tartan of the Eastfold Dairy" });
            AddItem(new Cloak { Hue = 0x47E, Name = "Rennet-Wrapped Cloak of Warmth" });
            AddItem(new Sandals { Hue = 0x4B5, Name = "Buttermilk-Soaked Soles" });
            AddItem(new WideBrimHat { Hue = 0x453, Name = "Hat of the Wheyward Wanderer" });

            HairItemID = 0x2049;
            HairHue = 0x481;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is PlayerMobile pm)
            {
                var root = _dialogue.GetModule("greeting");
                pm.SendGump(new XMLDialogueGump(pm, root, _dialogue));
            }
        }

        public BrendylWheyfoot(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
