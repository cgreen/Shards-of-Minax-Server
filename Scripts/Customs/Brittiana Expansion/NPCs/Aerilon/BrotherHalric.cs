/*
 * Scripts/Custom/DialogueSystem/BrotherHalric.cs
 * Data-driven dialogue, custom outfit, Aerilon & Wind lore, SeaHorse Specialist quest.
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
    [CorpseName("the body of Brother Halric")]
    public class BrotherHalric : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BrotherHalric()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BrotherHalric.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BrotherHalric()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Brother Halric";
            Title = "Acolyte of Balance";
            Body = 0x190; // Human male
            Hue = 0x4B6;

            // Unique, lore-rich outfit pieces
            AddItem(new ClothNinjaHood() { Name = "Cowl of Twilight Equanimity", Hue = 0x489 });
            AddItem(new MonkRobe() { Name = "Robe of the Circling Winds", Hue = 0x486 });
            AddItem(new BodySash() { Name = "Balancekeeper’s Sash", Hue = 0x847 });
            AddItem(new Sandals() { Name = "Shores of Serenity", Hue = 0x982 });
            AddItem(new LeatherGloves() { Name = "Hands of Silent Service", Hue = 0x480 });
            AddItem(new ShepherdsCrook() { Name = "Meditation Crook of Yew", Hue = 0x899 });

            HairItemID = 0x2044; // monkish topknot
            HairHue = 0x47D; // grey
            FacialHairItemID = 0x003F; // short beard
            FacialHairHue = 0x47D;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public BrotherHalric(Serial serial) : base(serial) { }

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
