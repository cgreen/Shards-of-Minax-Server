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
    [CorpseName("the corpse of Tosk the Bellringer")]
    public class ToskTheBellringer : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ToskTheBellringer()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ToskBellringer.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ToskTheBellringer()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tosk the Bellringer";
            Title = "Night Watchman of Frostmere";
            Body = 0x190; // Human male
            Hue = 0x482;

            // Outfit: all unique items/hues, themed for an insomniac night watchman in Frostmere
            AddItem(new FancyShirt() { Name = "Sleepless Tunic", Hue = 0x47F });
            AddItem(new LeatherDo() { Name = "Frostguard Hauberk", Hue = 0x47E });
            AddItem(new StuddedGloves() { Name = "Midnight Vigil Gloves", Hue = 0x497 });
            AddItem(new Kilt() { Name = "Tundra Walker's Kilt", Hue = 0x482 });
            AddItem(new FurBoots() { Name = "Icebound Boots", Hue = 0x480 });
            AddItem(new Cloak() { Name = "Moonless Watch Cloak", Hue = 0x4B5 });
            AddItem(new HoodedShroudOfShadows() { Name = "Cowl of Endless Night", Hue = 0x455 });

            // Bell weapon as a staff prop
            AddItem(new GnarledStaff() { Name = "The Iron Bellstaff", Hue = 0x481 });

            HairItemID = 0x2047;
            HairHue = 0x453;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this); 
        }

        public ToskTheBellringer(Serial serial) : base(serial) { }

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
