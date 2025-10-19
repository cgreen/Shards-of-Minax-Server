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
    [CorpseName("the corpse of Captain Urven Slate")]
    public class CaptainUrvenSlate : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static CaptainUrvenSlate()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "CaptainUrvenSlate.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public CaptainUrvenSlate()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Captain Urven Slate";
            Title = "Ice-Runner and Exile of Sunreach";
            Body = 0x190; // Human male
            Hue = 0x83C; // Pale frostbitten skin

            // Unique pirate-y, frosty outfit with custom hues and names
            AddItem(new FancyShirt() { Name = "Frostbite Silk Undershirt", Hue = 0x480 });
            AddItem(new LeatherArms() { Name = "Gale-Hardened Bracers", Hue = 0x497 });
            AddItem(new LeatherGloves() { Name = "Glacial Grasp Gloves", Hue = 0x4B7 });
            AddItem(new LongPants() { Name = "Aurora-Striped Slops", Hue = 0x59E });
            AddItem(new HalfApron() { Name = "Salt-Scarred Pirate's Apron", Hue = 0x1BB });
            AddItem(new Boots() { Name = "Snowrunner's Boots", Hue = 0x5B2 });
            AddItem(new TricorneHat() { Name = "Frosted Tricorne of the Frozen Tern", Hue = 0x47E });
            AddItem(new Cloak() { Name = "Icicle-Edged Cloak", Hue = 0x482 });
            AddItem(new Cutlass() { Name = "Shiversteel Cutlass", Hue = 0x480 });

            // Pirate beard/hair
            HairItemID = 0x203C;
            HairHue = 0x2AC; // Black with streaks of frost
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x47E; // Frosty gray

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public CaptainUrvenSlate(Serial serial) : base(serial) { }

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
