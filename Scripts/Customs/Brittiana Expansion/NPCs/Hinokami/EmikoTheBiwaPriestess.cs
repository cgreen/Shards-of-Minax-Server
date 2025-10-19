/*
 * Scripts/Custom/DialogueSystem/EmikoTheBiwaPriestess.cs
 * Data-driven dialogue, custom biwa lore, spirit exorcism, Hinokami flavor.
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
    [CorpseName("the remains of Emiko the Biwa Priestess")]
    public class EmikoTheBiwaPriestess : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static EmikoTheBiwaPriestess()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "EmikoTheBiwaPriestess.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public EmikoTheBiwaPriestess()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Emiko";
            Title = "the Biwa Priestess";
            Body = 0x191; // Human female
            Hue = 0x8A5;  // Subtle gold skin tone

            // Hinokami shrine maiden & bardic attire
            AddItem(new FemaleKimono() { Name = "Silk Kimono of Lingering Spirits", Hue = 0x48F });
            AddItem(new Obi() { Name = "Obi of Bound Melodies", Hue = 0x485 });
            AddItem(new Sandals() { Name = "Woven Shrine Sandals", Hue = 0x430 });
            AddItem(new FlowerGarland() { Name = "Cherry Blossom Garland", Hue = 0x487 });
            AddItem(new Cloak() { Name = "Mist-Shroud Cloak", Hue = 0x4F2 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x47E;     // white/silver

            // Unique item: Spirit-Bound Biwa
            AddItem(new MagicWand() { Name = "Biwa Strung With Priestess Emiko's Hair", Hue = 0x481 });

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public EmikoTheBiwaPriestess(Serial serial) : base(serial) { }

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
