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
    [CorpseName("the corpse of Brother Falin")]
    public class BrotherFalin : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BrotherFalin()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BrotherFalin.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BrotherFalin()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Brother Falin";
            Title = "the Fallen Monk";
            Body = 0x190; // Human male
            Hue = 0x8A5;  // Pale, haunted tone

            // Custom ragged monk attire, each piece named and hued:
            AddItem(new MonkRobe() { Name = "Falin’s Ashen Robe", Hue = 0x835 }); // Charred-grey
            AddItem(new BodySash() { Name = "Frayed Sash of Yew", Hue = 0x59B }); // Moss green
            AddItem(new Sandals() { Name = "Pilgrim’s Threadbare Sandals", Hue = 0x487 }); // Muddy brown
            AddItem(new Cloak() { Name = "Veil of Repentance", Hue = 0x96D }); // Deep violet
            AddItem(new HoodedShroudOfShadows() { Name = "Hood of Quiet Regret", Hue = 0x497 }); // Faded navy

            // Staff as a monkly symbol (not a weapon)
            AddItem(new GnarledStaff() { Name = "Worn Pilgrim’s Staff", Hue = 0x59B });

            // Unshaven, haunted look
            HairItemID = 0x203C; // Shaggy hair
            HairHue = 0x451;
            FacialHairItemID = 0x204C; // Patchy beard
            FacialHairHue = 0x451;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
			XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);	
        }

        public BrotherFalin(Serial serial) : base(serial) { }

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
