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
    [CorpseName("the corpse of Elder Aelric")]
    public class ElderAelric : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ElderAelric()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ElderAelric.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ElderAelric()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Elder Aelric";
            Title = "the Frostseer of Frostmere";
            Body = 0x190; // Human male
            Hue = 0x83F;

            AddItem(new Robe() { Name = "Frostseer’s Robe", Hue = 0x482 });
            AddItem(new Cloak() { Name = "Galeweave Cloak", Hue = 0x5E4 });
            AddItem(new BodySash() { Name = "Arcanist’s Sash", Hue = 0x47E });
            AddItem(new ElvenPants() { Name = "Starflare Pants", Hue = 0x559 });
            AddItem(new Sandals() { Name = "Windswept Slippers", Hue = 0x47F });
            AddItem(new Circlet() { Name = "Icicle Circlet", Hue = 0x480 });
            AddItem(new LeatherGloves() { Name = "Gloves of Veiled Wisdom", Hue = 0x455 });
            AddItem(new GnarledStaff() { Name = "Gnarled Staff of Veyra" });

            HairItemID = 0x203B;
            HairHue = 0x46C; // Frosty silver
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x46C;
			
			XmlAttach.AttachTo(this, new XmlRandomTraits());
			XmlAttach.AttachTo(this, new XmlDynamicVendor());
			SpecialLootHelper.AddLoot(this);
        }

        public ElderAelric(Serial serial) : base(serial) { }

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
