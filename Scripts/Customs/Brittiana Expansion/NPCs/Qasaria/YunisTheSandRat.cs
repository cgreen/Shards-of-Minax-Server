/*
 * Scripts/Custom/DialogueSystem/YunisTheSandRat.cs
 * Data-driven dialogue, custom outfit, Qasaria lore.
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
    [CorpseName("the small form of Yunis the Sand Rat")]
    public class YunisTheSandRat : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static YunisTheSandRat()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "YunisTheSandRat.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public YunisTheSandRat()
            : base(AIType.AI_Thief, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Yunis";
            Title = "the Sand Rat";
            Body = 0x191; // Human (child-sized, you may wish to adjust for a child appearance mod)
            Hue = 0x83F;

            // Unique, lore-rich outfit pieces
            AddItem(new Bandana() { Name = "Tattered Crimson Scarf of the Sewer-Kin", Hue = 0x21 });
            AddItem(new Shirt() { Name = "Stained Desert-Silk Shirt", Hue = 0xC7 });
            AddItem(new ShortPants() { Name = "Patchwork Streetling Breeches", Hue = 0x94D });
            AddItem(new HalfApron() { Name = "Grimy Sash of Hidden Pockets", Hue = 0x455 });
            AddItem(new Sandals() { Name = "Scuffed Sandrat Footwraps", Hue = 0x96B });
            AddItem(new LeatherGloves() { Name = "Nimble Fingers of Forgotten Gold", Hue = 0x466 });
            AddItem(new BeggersStick() { Name = "Stick of Silent Footfalls", Hue = 0x844 });

            HairItemID = 0x203C; // short tousled hair
            HairHue = 0x25D; // dark brown
            FacialHairItemID = 0x0000; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public YunisTheSandRat(Serial serial) : base(serial) { }

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
