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
    [CorpseName("the corpse of Garrik the Blacksmith")]
    public class GarrikBlacksmith : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static GarrikBlacksmith()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "GarrikBlacksmith.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public GarrikBlacksmith()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Garrik";
            Title = "the Blacksmith of Frostmere";
            Body = 0x190; // Human male
            Hue = 0x845;

            // Unique, lore-rich outfit
            AddItem(new Doublet() { Hue = 0x8A5, Name = "Garrik's Frost-Hardened Doublet" });      // Icy blue-grey
            AddItem(new LeatherArms() { Hue = 0x497, Name = "Minoc-Bound Bracers" });             // Dark steel
            AddItem(new FullApron() { Hue = 0x551, Name = "Volcanic Forgemaster's Apron" });      // Charred crimson
            AddItem(new LeatherLegs() { Hue = 0x430, Name = "Tundra-Walker's Greaves" });         // Frostbitten brown
            AddItem(new Boots() { Hue = 0x46E, Name = "Bearhide Forge Boots" });                  // Soot-black
            AddItem(new PlateGloves() { Hue = 0x7B1, Name = "Ice-Tong Gauntlets" });              // Silvered blue
            AddItem(new Bandana() { Hue = 0x482, Name = "Coal-Dust Bandana" });                   // Dusty grey

            // Weapon/tool
            AddItem(new SmithSmasher() { Hue = 0x835, Name = "Frosthammer, the Smith’s Pride" });

            HairItemID = 0x203B;
            HairHue = 0x453;
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x453;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public GarrikBlacksmith(Serial serial) : base(serial) { }

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
