/*
 * Scripts/Custom/DialogueSystem/HighPriestessSamira.cs
 * Data-driven dialogue, custom outfit, Qasaria/Sun Temple lore.
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
    [CorpseName("the corpse of High Priestess Samira")]
    public class HighPriestessSamira : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static HighPriestessSamira()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "HighPriestessSamira.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public HighPriestessSamira()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "High Priestess Samira";
            Title = "Keeper of the Obelisk of Eternity";
            Body = 0x191; // Human female
            Hue = 0x46A;  // Bronze, sun-warmed skin tone

            // Custom, lore-rich outfit
            AddItem(new WizardsHat() { Name = "Solar Diadem of the First Dawn", Hue = 0x489 });              // Brilliant sun-gold, etched with runic sigils
            AddItem(new Robe() { Name = "Vestments of the Desert Sun", Hue = 0x44E });                       // Deep gold and pale linen layers
            AddItem(new Cloak() { Name = "Shroud of the Longest Day", Hue = 0x54C });                        // Shimmering white, with gold thread
            AddItem(new BodySash() { Name = "Sash of Sacred Vigil", Hue = 0x488 });                          // Saffron
            AddItem(new Sandals() { Name = "Sandwalkers of Eternal Light", Hue = 0x4C1 });                   // Silken, with obsidian beads
            AddItem(new PlateGloves() { Name = "Grips of Divine Purity", Hue = 0x482 });                     // Polished brass, sun-engraved
            AddItem(new ElegantCollar() { Name = "Sunfire Gorget", Hue = 0x48F });                           // Radiant gemstone center
            AddItem(new Scepter() { Name = "Censer of the Obelisk", Hue = 0x545 });                          // Jeweled scepter/censer, faintly glowing

            HairItemID = 0x203B; // Long hair
            HairHue = 0x495;     // Dark, sun-streaked

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public HighPriestessSamira(Serial serial) : base(serial) { }

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
