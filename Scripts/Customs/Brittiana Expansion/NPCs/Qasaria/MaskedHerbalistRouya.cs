/*
 * Scripts/Custom/DialogueSystem/MaskedHerbalistRouya.cs
 * Data-driven dialogue, custom outfit, Qasaria and Hinokami lore.
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
    [CorpseName("the corpse of the Masked Herbalist")]
    public class MaskedHerbalistRouya : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MaskedHerbalistRouya()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MaskedHerbalistRouya.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MaskedHerbalistRouya()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "the Masked Herbalist";
            Title = "of the Qasarian Night Markets";
            Body = 0x191; // Female
            Hue = 0x83F; // Subtle olive

            AddItem(new ClothNinjaHood() { Name = "Flowerweave Mask", Hue = 0x489 });
            AddItem(new BodySash() { Name = "Saffron Sash of Concealment", Hue = 0x8A5 });
            AddItem(new Robe() { Name = "Verdant Desert Robe", Hue = 0x59C });
            AddItem(new Sandals() { Name = "Duststep Sandals", Hue = 0xA15 });
            AddItem(new Obi() { Name = "Belt of Hidden Pouches", Hue = 0xB82 });
            AddItem(new ElvenShirt() { Name = "Sleeves of Lavender Sigils", Hue = 0x47D });
            AddItem(new Bag() { Name = "Witch’s Remedy Kit", Hue = 0x21E });

            HairItemID = 0x203C; // Braided hair (hidden by hood)
            HairHue = 0x466;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
			SpecialLootHelper.AddLoot(this);
        }

        public MaskedHerbalistRouya(Serial serial) : base(serial) { }

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
