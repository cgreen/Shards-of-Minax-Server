/*
 * Scripts/Custom/DialogueSystem/SilentHunter.cs
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
    [CorpseName("the corpse of the Silent Hunter")]
    public class SilentHunter : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SilentHunter()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SilentHunter.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SilentHunter()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "The Silent Hunter";
            Title = "of Frostmere";
            Body = 0x190; // Human male
            Hue = 0x47F;

            // Unique, loreful gear
            AddItem(new ElvenShirt() { Name = "Snowshade Tunic", Hue = 0x47E });
            AddItem(new LeatherNinjaPants() { Name = "Tundra-Walkers", Hue = 0x482 });
            AddItem(new FurBoots() { Name = "Frostbound Boots", Hue = 0x47A });
            AddItem(new HoodedShroudOfShadows() { Name = "Glacier Shroud", Hue = 0x480 });
            AddItem(new LeatherGloves() { Name = "Whisperhide Gloves", Hue = 0x482 });
            AddItem(new RangersCrossbow() { Name = "Icebark Crossbow", Hue = 0x47D });
            AddItem(new BodySash() { Name = "Obelisk-Ember Sash", Hue = 0x49B });

            HairItemID = 0x2049; // Short, windswept hair
            HairHue = 0x47F;

            // Custom Traits
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public SilentHunter(Serial serial) : base(serial) { }

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
