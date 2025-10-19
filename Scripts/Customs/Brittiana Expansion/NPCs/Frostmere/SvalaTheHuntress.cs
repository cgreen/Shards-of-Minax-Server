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
    [CorpseName("the corpse of Svala the Huntress")]
    public class SvalaTheHuntress : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SvalaTheHuntress()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SvalaTheHuntress.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SvalaTheHuntress()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Svala";
            Title = "the Huntress";
            Body = 0x191; // Human female
            Hue = 0x839;

            // Outfit: Each piece unique, with hues fitting Frostmere's icebound theme
            AddItem(new LeatherCap() { Name = "Snowbound Lynx Hood", Hue = 0x47E });
            AddItem(new LeatherChest() { Name = "Stormhide Jerkin", Hue = 0x59D });
            AddItem(new LeatherLegs() { Name = "Frostwolf Breeches", Hue = 0x4C2 });
            AddItem(new LeatherGloves() { Name = "Icegrip Gloves", Hue = 0x482 });
            AddItem(new FurBoots() { Name = "Tundra Stalker Boots", Hue = 0x481 });
            AddItem(new Cloak() { Name = "Wyrmskin Mantle", Hue = 0x96D });
            AddItem(new BodySash() { Name = "Emerald Scout's Sash", Hue = 0x48E });

            // Weapon: Unique skinned bow
            AddItem(new CompositeBow() { Name = "Shiverbranch Bow", Hue = 0x5B5 });

            HairItemID = 0x203B;
            HairHue = 0x47D;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public SvalaTheHuntress(Serial serial) : base(serial) { }

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
