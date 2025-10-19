/*
 * Scripts/Custom/DialogueSystem/LeilaTheSandDancer.cs
 * Data-driven dialogue, custom outfit, Qasaria lore and intrigue.
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
    [CorpseName("the delicate form of Leila the Sand Dancer")]
    public class LeilaTheSandDancer : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static LeilaTheSandDancer()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "LeilaTheSandDancer.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public LeilaTheSandDancer()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Leila";
            Title = "the Sand Dancer";
            Body = 0x191; // Human female
            Hue = 0xB6E; // Golden-tanned skin

            // Unique, lore-rich outfit pieces
            AddItem(new FancyDress() { Name = "Gown of Sunlit Silks", Hue = 0x2D1 }); // gold silk
            AddItem(new BodySash() { Name = "Sash of Shimmering Mirage", Hue = 0x489 }); // opal
            AddItem(new Sandals() { Name = "Dancer's Step of the Crimson Dunes", Hue = 0x4E2 }); // crimson
            AddItem(new FlowerGarland() { Name = "Wreath of Desert Blossoms", Hue = 0x495 }); // pastel pink/peach
            AddItem(new Cloak() { Name = "Veil of the Amber Oasis", Hue = 0xB7F }); // amber gold
            AddItem(new GoldBracelet() { Name = "Bracelet of the Caravan’s Blessing", Hue = 0x430 }); // teal
            AddItem(new GoldEarrings() { Name = "Earrings of Whispered Secrets", Hue = 0x845 }); // deep blue

            HairItemID = 0x203B; // long hair
            HairHue = 0x455; // dark auburn
            FacialHairItemID = 0x0000; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public LeilaTheSandDancer(Serial serial) : base(serial) { }

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
