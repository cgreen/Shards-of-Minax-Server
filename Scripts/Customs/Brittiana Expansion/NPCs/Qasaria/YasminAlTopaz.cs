/*
 * Scripts/Custom/DialogueSystem/YasminAlTopaz.cs
 * Data-driven dialogue, custom outfit, Qasaria lore and quest.
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
    [CorpseName("the corpse of Yasmin al-Topaz")]
    public class YasminAlTopaz : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static YasminAlTopaz()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "YasminAlTopaz.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public YasminAlTopaz()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Yasmin al-Topaz";
            Title = "Mistress of the Sands";
            Body = 0x191; // Human female
            Hue = 0x3B2; // Bronze/golden

            // Unique, lore-rich outfit pieces
            AddItem(new WizardsHat() { Name = "Veil of the Dune Ancients", Hue = 0x489 });           // Opalescent, pale gold
            AddItem(new Robe() { Name = "Robes of the Shifting Mirage", Hue = 0x1BB });              // Rich, iridescent sand
            AddItem(new BodySash() { Name = "Sash of Endless Horizons", Hue = 0xB91 });              // Deep sunset orange
            AddItem(new Cloak() { Name = "Cloak of Whispering Grains", Hue = 0x482 });               // Dusty desert tan
            AddItem(new Sandals() { Name = "Steps of the Ancients", Hue = 0x96D });                  // Topaz yellow
            AddItem(new LeatherGloves() { Name = "Grips of the Forgotten Pharaohs", Hue = 0x66C });  // Smoky agate

            HairItemID = 0x203B; // long hair
            HairHue = 0x4E9;     // jet black with gold streaks

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public YasminAlTopaz(Serial serial) : base(serial) { }

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
