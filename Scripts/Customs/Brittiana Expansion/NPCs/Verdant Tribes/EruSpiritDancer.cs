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
    [CorpseName("the corpse of Eru Spirit Dancer")]
    public class EruSpiritDancer : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static EruSpiritDancer()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "EruSpiritDancer.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public EruSpiritDancer()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.1, 0.2)
        {
            Name = "Eru";
            Title = "the Spirit Dancer";
            Body = 0x191; // Human female
            Hue = 0x847; // earthy tan

            // Outfit: Nature and spirit-dancer themed
            AddItem(new FlowerGarland() { Name = "Wreath of Wild Blossoms", Hue = 0x48D });
            AddItem(new PlainDress() { Name = "Spiritweave Dress", Hue = 0x1C2 });
            AddItem(new BodySash() { Name = "Sash of Storytelling", Hue = 0x4E2 });
            AddItem(new Sandals() { Name = "Mossy Sandals", Hue = 0x59B });
            AddItem(new TribalMask() { Name = "Ceremonial Tribal Mask", Hue = 0x455 });

            HairItemID = 0x203B; // Long hair
            HairHue = 0x59B; // Leaf green
            FacialHairItemID = 0x0000; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public EruSpiritDancer(Serial serial) : base(serial) { }

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
