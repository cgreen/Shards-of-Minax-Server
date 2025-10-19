/*
 * Scripts/Custom/DialogueSystem/VornGallows.cs
 * Gravedigger NPC for Eldermoor with unique outfit and dialogue tree.
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
    [CorpseName("the corpse of Vorn Gallows")]
    public class VornGallows : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static VornGallows()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "VornGallows.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public VornGallows()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Vorn Gallows";
            Title = "the Gravedigger";
            Body = 0x190; // Human male
            Hue = 0x847;  // Pale, sallow undertone

            AddItem(new MonkRobe() { Name = "Soil-Stained Burial Robe", Hue = 0x455 }); // Dark brown, almost black
            AddItem(new HoodedShroudOfShadows() { Name = "The Mourner’s Cowl", Hue = 0x497 }); // Faded blue-grey
            AddItem(new Boots() { Name = "Graverobber's Boots", Hue = 0x5E4 }); // Muddy olive
            AddItem(new LeatherGloves() { Name = "Gloves of Silent Vigil", Hue = 0x966 }); // Bone-white
            AddItem(new BodySash() { Name = "Sash of Ancestral Keys", Hue = 0x59B }); // Old iron-grey
            AddItem(new GnarledStaff() { Name = "Waker’s Crook", Hue = 0x900 }); // Mossy greenish-black

            HairItemID = 0x203B;
            HairHue = 0x47E; // Ash grey
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x47E;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public VornGallows(Serial serial) : base(serial) { }

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
