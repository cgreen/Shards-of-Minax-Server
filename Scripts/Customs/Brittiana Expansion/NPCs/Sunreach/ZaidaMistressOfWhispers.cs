/*
 * Scripts/Custom/DialogueSystem/ZaidaMistressOfWhispers.cs
 * Data-driven dialogue, custom outfit, Sunreach intrigue quest.
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
    [CorpseName("the corpse of Zaida, Mistress of Whispers")]
    public class ZaidaMistressOfWhispers : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ZaidaMistressOfWhispers()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ZaidaMistressOfWhispers.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ZaidaMistressOfWhispers()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Zaida";
            Title = "Mistress of Whispers";
            Body = 0x191; // Human female
            Hue = 0x455;  // Dusky, shadowy skin tone

            // Outfit - enigmatic, veiled, hinting at forbidden knowledge
            AddItem(new HoodedShroudOfShadows() { Name = "Veil of the Nameless", Hue = 0x497 });
            AddItem(new PlainDress() { Name = "Whisperweave Gown", Hue = 0x481 });
            AddItem(new BodySash() { Name = "Sash of the Night Court", Hue = 0x56D });
            AddItem(new Sandals() { Name = "Silent Steps", Hue = 0x455 });
            AddItem(new LeatherGloves() { Name = "Gloves of Subtlety", Hue = 0x47E });
            AddItem(new Cloak() { Name = "Cloak of Lingering Secrets", Hue = 0x4A7 });

            HairItemID = 0x203C; // long hair pulled back
            HairHue = 0x497; // Black/dark
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            // Accessories: Dagger (hidden)
            AddItem(new Dagger() { Name = "Veiled Threat", Hue = 0x1B1, Movable = false });

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public ZaidaMistressOfWhispers(Serial serial) : base(serial) { }

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
