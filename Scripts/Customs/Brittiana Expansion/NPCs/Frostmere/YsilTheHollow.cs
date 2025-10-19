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
    [CorpseName("the hollow corpse of Ysil")]
    public class YsilTheHollow : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static YsilTheHollow()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "YsilTheHollow.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public YsilTheHollow()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.1, 0.2)
        {
            Name = "Ysil the Hollow";
            Title = "the Rune-Scarred Outcast";
            Body = 0x191;
            Hue = 0x47E;

            AddItem(new HoodedShroudOfShadows() { Hue = 0x4F5 });
            AddItem(new Cloak() { Hue = 0x497 }); // Cloak of Sundered Allegiance
            AddItem(new BodySash() { Hue = 0x488 }); // Sash of Hollow Memory
            AddItem(new LeatherSkirt() { Hue = 0x48B }); // Glacial Wrath Skirt
            AddItem(new Sandals() { Hue = 0x482 }); // Wraithstep Sandals
            AddItem(new LeatherMempo() { Hue = 0x47F }); // Runebound Mempo
            AddItem(new ShadowSai() { Hue = 0x47B }); // Shadow Sai

            HairItemID = 0x203C;
            HairHue = 0x481;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public YsilTheHollow(Serial serial) : base(serial) { }

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
