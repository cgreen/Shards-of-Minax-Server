/*
 * Scripts/Custom/DialogueSystem/HalimTheStoryteller.cs
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
    [CorpseName("the corpse of Halim the Storyteller")]
    public class HalimTheStoryteller : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static HalimTheStoryteller()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "HalimTheStoryteller.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public HalimTheStoryteller()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Halim the Storyteller";
            Title = "Bard of the Golden Sands";
            Body = 0x190; // Human male
            Hue = 0x8403; // warm tan

            // Unique, lore-rich outfit pieces
            AddItem(new FeatheredHat() { Name = "Desert Gale Plume", Hue = 0x8A5 });
            AddItem(new FancyShirt() { Name = "Talespinner's Silken Blouse", Hue = 0x47F });
            AddItem(new BodySash() { Name = "Sash of the Whispered Word", Hue = 0x21E });
            AddItem(new FancyKilt() { Name = "Jewelmarket Storyweaver's Skirt", Hue = 0x4B8 });
            AddItem(new Cloak() { Name = "Dune-Shadow Cloak", Hue = 0x497 });
            AddItem(new Sandals() { Name = "Wanderer's Silent Step", Hue = 0x42B });

            AddItem(new ResonantHarp() { Name = "Minstrel’s Heartstring Harp", Hue = 0xB92 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x4E2; // gold/bronze
            FacialHairItemID = 0x2041; // trimmed beard
            FacialHairHue = 0x4E2;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public HalimTheStoryteller(Serial serial) : base(serial) { }

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
