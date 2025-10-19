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
    [CorpseName("the shattered remains of Brenra Iceborn")]
    public class BrenraIceborn : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BrenraIceborn()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BrenraIceborn.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BrenraIceborn()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Brenra Iceborn";
            Title = "the Frostbound Dreamer";
            Body = 0x191; // Human female
            Hue = 0x47E;  // Pale blue

            // Unique, magical outfit:
            AddItem(new Robe() { Name = "Wispvein Shroud", Hue = 0x480 }); // shimmering icy cyan
            AddItem(new Skirt() { Name = "Gossamer Frost Skirt", Hue = 0x47F }); // mist-blue
            AddItem(new Cloak() { Name = "Chillwake Cloak", Hue = 0x495 }); // pale, almost transparent
            AddItem(new Sandals() { Name = "Snowpetal Sandals", Hue = 0x482 });
            AddItem(new BodySash() { Name = "Obelisk-Touched Sash", Hue = 0x48B }); // faintly glowing indigo
            AddItem(new WizardsHat() { Name = "Crown of Glacial Whispers", Hue = 0x481 });

            HairItemID = 0x203C;
            HairHue = 0x47B; // ice-white hair

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public BrenraIceborn(Serial serial) : base(serial) { }

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
