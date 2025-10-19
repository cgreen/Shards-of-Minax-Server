/*
 * Scripts/Custom/DialogueSystem/CassiraSunveil.cs
 * Bardic dialogue, custom outfit, Sunreach & Qasaria lore.
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
    [CorpseName("the corpse of Cassira Sunveil")]
    public class CassiraSunveil : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static CassiraSunveil()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "CassiraSunveil.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public CassiraSunveil()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Cassira Sunveil";
            Title = "the Renowned Bard";
            Body = 0x191; // Human female
            Hue = 0x83EA; // Warm skin tone

            // Outfit: Bohemian bardic
            AddItem(new FancyShirt() { Name = "Sunveil’s Emberblouse", Hue = 0x486 });
            AddItem(new Skirt() { Name = "Velvet Bard's Skirt", Hue = 0x482 });
            AddItem(new Cloak() { Name = "Cloak of Whispered Rumors", Hue = 0x4B6 });
            AddItem(new BodySash() { Name = "Bardic Sash of Qasarian Silk", Hue = 0x47F });
            AddItem(new ThighBoots() { Name = "Minstrel’s Boots", Hue = 0x497 });
            AddItem(new FeatheredHat() { Name = "Sunfeathered Hat", Hue = 0x1F3 });
            AddItem(new ResonantHarp() { Name = "Cassira’s Gilded Harp", Hue = 0x485 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x47E; // platinum blonde
            FacialHairItemID = 0x0000; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public CassiraSunveil(Serial serial) : base(serial) { }

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
