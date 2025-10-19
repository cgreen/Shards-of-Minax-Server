/*
 * Scripts/Custom/DialogueSystem/YumiSilentWind.cs
 * Data-driven dialogue, ninja attire, Hinokami lore.
 */

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
    [CorpseName("the body of Yumi 'Silent Wind'")]
    public class YumiSilentWind : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static YumiSilentWind()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "YumiSilentWind.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public YumiSilentWind()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Yumi 'Silent Wind'";
            Title = "the Hinokami Ninja";
            Body = 0x191; // Human female
            Hue = 0x455;

            // Unique, shadowy ninja attire
            AddItem(new ClothNinjaHood() { Name = "Hood of the Silent Wind", Hue = 0x497 });
            AddItem(new ClothNinjaJacket() { Name = "Ninja's Shroud", Hue = 0x497 });
            AddItem(new LeatherNinjaPants() { Name = "Midnight Shinobi Leggings", Hue = 0x497 });
            AddItem(new NinjaTabi() { Name = "Tabi of Swiftness", Hue = 0x455 });
            AddItem(new ShadowSai() { Name = "Silent Sai", Hue = 0x455 });
            AddItem(new Obi() { Name = "Obi of Whispers", Hue = 0xB25 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x455; // raven black

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public YumiSilentWind(Serial serial) : base(serial) { }

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
