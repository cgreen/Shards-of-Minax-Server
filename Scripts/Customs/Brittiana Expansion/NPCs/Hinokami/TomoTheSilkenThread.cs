using Server;
using Server.Items;
using Server.Mobiles;
using Server.Custom.Dialogue;
using Server.Engines.XmlSpawner2;
using System.IO;

namespace Server.Mobiles
{
    [CorpseName("the corpse of Tomo the Silken Thread")]
    public class TomoTheSilkenThread : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static TomoTheSilkenThread()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "TomoTheSilkenThread.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public TomoTheSilkenThread()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tomo the Silken Thread";
            Title = "kimono weaver";
            Body = 0x191; // Human female
            Hue = 0x47F; // Subtle violet

            // Unique, beetle-inspired outfit
            AddItem(new FemaleKimono() { Name = "Kimono of Iridescent Beetle Silk", Hue = 0x845 });
            AddItem(new Obi() { Name = "Sash of Moonlit Bamboo", Hue = 0x48E });
            AddItem(new Sandals() { Name = "Petal-Soft Sandals", Hue = 0x47F });
            AddItem(new FlowerGarland() { Name = "Beetle-Charm Garland", Hue = 0x482 });

            HairItemID = 0x203C; // topknot/bun
            HairHue = 0x7D2; // glossy black
            FacialHairItemID = 0x0000; // none
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public TomoTheSilkenThread(Serial serial) : base(serial) { }

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
