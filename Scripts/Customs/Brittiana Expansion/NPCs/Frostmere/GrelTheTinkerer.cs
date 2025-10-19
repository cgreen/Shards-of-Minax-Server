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
    [CorpseName("the remains of Grel the Tinkerer")]
    public class GrelTheTinkerer : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static GrelTheTinkerer()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "GrelTheTinkerer.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public GrelTheTinkerer()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Grel the Tinkerer";
            Title = "The Clockwork Innovator";
            Body = 0x190; // Human male
            Hue = 0x83F;

            // Unique Outfit: Each with unique name/hue
            var vest = new Doublet() { Hue = 0x5B6, Name = "Grel's Sprocket-Spattered Vest" };
            var pants = new ElvenPants() { Hue = 0x47E, Name = "Frost-Cog Slacks" };
            var boots = new FurBoots() { Hue = 0x482, Name = "Oil-Stained Tinker Boots" };
            var apron = new HalfApron() { Hue = 0x48F, Name = "Toolloop Apron" };
            var cloak = new Cloak() { Hue = 0x4F7, Name = "Patchwork Patent Cloak" };
            var hat = new WizardsHat() { Hue = 0x4E7, Name = "Teapot-Handle Wizard Hat" };
            var gloves = new LeatherGloves() { Hue = 0x495, Name = "Gear-Greased Gloves" };

            AddItem(vest);
            AddItem(pants);
            AddItem(boots);
            AddItem(apron);
            AddItem(cloak);
            AddItem(hat);
            AddItem(gloves);

            // Prosthetic left arm: replace with teapot
            AddItem(new BoneArms() { Hue = 0x47E, Name = "Copper Teapot Prosthesis" });

            HairItemID = 0x203B;
            HairHue = 0x482;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public GrelTheTinkerer(Serial serial) : base(serial) { }

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
