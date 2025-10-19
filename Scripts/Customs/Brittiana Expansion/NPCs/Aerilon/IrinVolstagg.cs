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
    [CorpseName("the corpse of Irin Volstagg")]
    public class IrinVolstagg : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static IrinVolstagg()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "IrinVolstagg.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public IrinVolstagg()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Irin Volstagg";
            Title = "the Crystal Diver";
            Body = 0x190; // Human male
            Hue = 0xB2A; // Slightly tanned

            // Unique, lore-rich outfit pieces
            AddItem(new Bandana()        { Name = "Skydrifter’s Headwrap", Hue = 0x482 });
            AddItem(new Shirt()          { Name = "Shardlight Diving Shirt", Hue = 0x5B6 });
            AddItem(new LeatherArms()    { Name = "Sleeves of Clinging Mists", Hue = 0x46E });
            AddItem(new HalfApron()      { Name = "Volt-Catch Utility Harness", Hue = 0xAB0 });
            AddItem(new StuddedGloves()  { Name = "Grappler’s Gauntlets", Hue = 0x47E });
            AddItem(new LeatherLegs()    { Name = "Breeches of the Brink", Hue = 0xB3E });
            AddItem(new ThighBoots()     { Name = "Windstep Diver’s Boots", Hue = 0x495 });
            AddItem(new BodySash()       { Name = "Kaelis’ Favor Sash", Hue = 0x4F7 }); // Reluctant memento

            // Accessory: Tethered rope & rune-inscribed hook on his belt
            AddItem(new Cloak()          { Name = "Skyfall Recovery Cloak", Hue = 0x47F });

            HairItemID = 0x203C; // short hair
            HairHue = 0x455; // copper
            FacialHairItemID = 0x2031; // short beard
            FacialHairHue = 0x455; // copper

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public IrinVolstagg(Serial serial) : base(serial) { }

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
