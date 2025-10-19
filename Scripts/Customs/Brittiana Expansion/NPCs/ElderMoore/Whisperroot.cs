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
    [CorpseName("the fallen boughs of Whisperroot")]
    public class Whisperroot : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static Whisperroot()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "Whisperroot.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public Whisperroot()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.0, 0.0)
        {
            Name = "Whisperroot";
            Title = "the Ancient of the Elderwood";
            Body = 0x2F; // humanoid, but you may wish to use custom body for treefolk
            Hue = 0x7D3; // earthy brown-green

            AddItem(new Cloak() { Name = "Barkbound Cloak", Hue = 0x59A });
            AddItem(new BodySash() { Name = "Shimmering Root-Sash", Hue = 0xB61 });
            AddItem(new Circlet() { Name = "Amber-Gleam Circlet", Hue = 0x488 });
            AddItem(new WoodlandArms() { Name = "Ancient Leaf Mantle", Hue = 0x5E5 });
            AddItem(new LeafLegs() { Name = "Earthwoven Leggings", Hue = 0x539 });
            AddItem(new Sandals() { Name = "Spirit-Root Sandals", Hue = 0x567 });

            AddItem(new GnarledStaff() { Name = "Whisperroot's Branch", Hue = 0x490 });

            // Custom appearance tweaks here if desired!

            XmlAttach.AttachTo(this, new XmlRandomTraits());
			XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public Whisperroot(Serial serial) : base(serial) { }

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
