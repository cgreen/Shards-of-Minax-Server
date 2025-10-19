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
    [CorpseName("the corpse of Lira Veyra")]
    public class LiraVeyra : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static LiraVeyra()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "LiraVeyra.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public LiraVeyra()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Lira Veyra";
            Title = "the Battle Mage of the Azure Conclave";
            Body = 0x191; // Human female
            Hue = 0x47E; // Subtle blue skin hue, magical cast

            // Outfit: Each piece has a custom name and unique color
            AddItem(new FancyShirt() { Name = "Azure Conclave Shirt", Hue = 0x5B7 });         // shimmering azure silk
            AddItem(new LeatherArms() { Name = "Mage-Bound Bracers", Hue = 0x497 });          // runed midnight bracers
            AddItem(new Skirt() { Name = "Veyra's Spellwoven Skirt", Hue = 0x482 });          // deep navy blue
            AddItem(new Cloak() { Name = "Mantle of Skyfire", Hue = 0x900 });                 // sparkling silver-blue
            AddItem(new ThighBoots() { Name = "Stormwalker's Boots", Hue = 0x455 });          // obsidian with faint azure lacing
            AddItem(new WizardsHat() { Name = "Circlet of Aetheric Thought", Hue = 0x9C4 });  // crystalline, almost white-blue
            AddItem(new BodySash() { Name = "Conclave Sash of Office", Hue = 0x491 });        // deep sapphire

            // Weapon: 
            AddItem(new GnarledStaff() { Name = "Wand of Bifurcating Fates", Hue = 0x9C5 });  // pale glowing blue, with intricate runes

            // Hair (long and wild, blue-black)
            HairItemID = 0x203C;
            HairHue = 0x1B2;
            // No facial hair

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public LiraVeyra(Serial serial) : base(serial) { }

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
