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
    [CorpseName("the corpse of Durn Hollowtooth")]
    public class DurnHollowtooth : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static DurnHollowtooth()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "DurnHollowtooth.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public DurnHollowtooth()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Durn Hollowtooth";
            Title = "the Mute Hunter";
            Body = 0x190; // Human male, can swap for a custom body for hybrid look if desired
            Hue = 0x47E; // A cold blue

            AddItem(new Cloak() { Name = "Mantle of Shaggy Silence", Hue = 0x47E });
            AddItem(new Kilt() { Name = "Tundra Hunter’s Kilt", Hue = 0x482 });
            AddItem(new FurBoots() { Name = "Frostbite Hide Boots", Hue = 0x4F9 });
            AddItem(new HornedTribalMask() { Name = "Tribal Spirit Mask", Hue = 0xB4A });
            AddItem(new LeatherArms() { Name = "Bear-Claw Bracers", Hue = 0x3B2 });
            AddItem(new BodySash() { Name = "Ice Seer’s Sash", Hue = 0x47D });
            AddItem(new Bag() { Name = "Stone-Skipping Pebble Pouch", Hue = 0xA5D });

            HairItemID = 0x203B; // Long, wild hair
            HairHue = 0x497;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public DurnHollowtooth(Serial serial) : base(serial) { }

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
