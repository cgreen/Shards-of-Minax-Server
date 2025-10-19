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
    [CorpseName("the sleeping form of Veela")]
    public class VeelaOfTheSevenNames : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static VeelaOfTheSevenNames()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "VeelaOfTheSevenNames.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public VeelaOfTheSevenNames()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Veela of the Seven Names";
            Title = "Oracle of the Obelisk";
            Body = 0x191; // Human female
            Hue = 0x47F;

            AddItem(new Robe() { Name = "Moonpetal Robe", Hue = 0x482 });
            AddItem(new WizardsHat() { Name = "Slumberveil Hood", Hue = 0x47E });
            AddItem(new BodySash() { Name = "Dreamweaver Sash", Hue = 0x900 });
            AddItem(new Sandals() { Name = "Icesong Sandals", Hue = 0x47F });
            AddItem(new LeatherGloves() { Name = "Bracelets of Forgetting", Hue = 0x2B2 });

            HairItemID = 0x203C; // Long hair
            HairHue = 0x47E;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);	
        }

        public VeelaOfTheSevenNames(Serial serial) : base(serial) { }

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
