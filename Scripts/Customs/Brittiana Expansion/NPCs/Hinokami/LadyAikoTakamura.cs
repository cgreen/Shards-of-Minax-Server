/*
 * Scripts/Custom/DialogueSystem/LadyAikoTakamura.cs
 * Data-driven dialogue, custom Tokuno-inspired outfit, Hinokami lore.
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
    [CorpseName("the corpse of Lady Aiko Takamura")]
    public class LadyAikoTakamura : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static LadyAikoTakamura()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "LadyAikoTakamura.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public LadyAikoTakamura()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Lady Aiko Takamura";
            Title = "Cultural Guardian of Hinokami";
            Body = 0x191; // Human female
            Hue = 0x47E; // pale / Tokuno-inspired

            // Custom Tokuno ceremonial outfit
            AddItem(new FemaleKimono() { Name = "Embroidered Festival Kimono", Hue = 0x482 });
            AddItem(new Obi() { Name = "Obi of Tranquility", Hue = 0x2B3 });
            AddItem(new FlowerGarland() { Name = "Cherry Blossom Garland", Hue = 0x485 });
            AddItem(new Sandals() { Name = "Traditional Waraji", Hue = 0x497 });
            AddItem(new BodySash() { Name = "Sash of Spring Harmony", Hue = 0x488 });

            HairItemID = 0x203C; // swept hair
            HairHue = 0x455; // black
            FacialHairItemID = 0x0000; // none
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public LadyAikoTakamura(Serial serial) : base(serial) { }

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
