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
    [CorpseName("the corpse of Brinna Saltwhistle")]
    public class BrinnaSaltwhistle : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BrinnaSaltwhistle()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BrinnaSaltwhistle.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BrinnaSaltwhistle()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Brinna Saltwhistle";
            Title = "the Tavern Storyteller";
            Body = 0x191; // Human female
            Hue = 0x847;

            // Her unique, colorful and spy-concealing outfit:
            AddItem(new FancyShirt() { Name = "Drunkard's Indigo Blouse", Hue = 0x5B5 });
            AddItem(new Skirt() { Name = "Saltwhistle's Patchwork Skirt", Hue = 0x482 });
            AddItem(new HalfApron() { Name = "Qasarian Silk Apron", Hue = 0x2C1 });
            AddItem(new Cloak() { Name = "Mistcloak of Whispered Words", Hue = 0x497 });
            AddItem(new Shoes() { Name = "Spilled-Mead Slippers", Hue = 0x96C });
            AddItem(new FeatheredHat() { Name = "The Jolly Gullcap", Hue = 0x59D });
            AddItem(new BodySash() { Name = "Token of Old Aelric", Hue = 0x38F });

            HairItemID = 0x203C;
            HairHue = 0x42C;
            FacialHairItemID = 0; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public BrinnaSaltwhistle(Serial serial) : base(serial) { }

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
