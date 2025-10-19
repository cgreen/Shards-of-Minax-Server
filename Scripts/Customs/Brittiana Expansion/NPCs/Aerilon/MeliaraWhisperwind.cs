/*
 * Scripts/Custom/DialogueSystem/MeliaraWhisperwind.cs
 * Dream-magic themed, cryptic dialogue, custom attire, Aerilon rep quest.
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
    [CorpseName("the corpse of Meliara Whisperwind")]
    public class MeliaraWhisperwind : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MeliaraWhisperwind()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MeliaraWhisperwind.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MeliaraWhisperwind()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Meliara Whisperwind";
            Title = "Dreamsinger of the Veil";
            Body = 0x191; // Human female
            Hue = 0x47E; // Pale silver-blue

            // Unique, enchanted dreamweaver attire
            AddItem(new WizardsHat() { Name = "Veilweaver’s Diadem", Hue = 0x9C3 }); // Iridescent pale amethyst
            AddItem(new Robe() { Name = "Gown of the Liminal Tides", Hue = 0x4F2 }); // Deep shimmering azure
            AddItem(new Cloak() { Name = "Mistshroud of Waking Twilight", Hue = 0x482 }); // Smoky silver-violet
            AddItem(new Sandals() { Name = "Slippers of Quiet Passage", Hue = 0xA68 }); // Moonlit lilac
            AddItem(new BodySash() { Name = "Sash of Somnolent Threads", Hue = 0xB18 }); // Gentle pearl-pink
            AddItem(new LeatherGloves() { Name = "Gloves of Oneiric Touch", Hue = 0x47F }); // Opalescent blue

            HairItemID = 0x203C; // Long hair, wild
            HairHue = 0x8A5; // Faint lavender
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            // Dream-themed effects or attachments
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public MeliaraWhisperwind(Serial serial) : base(serial) { }

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
