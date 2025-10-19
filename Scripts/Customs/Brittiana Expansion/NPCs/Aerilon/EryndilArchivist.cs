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
    [CorpseName("the remains of Eryndil the Archivist")]
    public class EryndilArchivist : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static EryndilArchivist()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "EryndilArchivist.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public EryndilArchivist()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Eryndil the Archivist";
            Title = "Keeper of Aerilon's Memory";
            Body = 0x190; // Human male
            Hue = 0x47E;  // Soft arcane blue

            // Unique, named, hued items
            AddItem(new Robe() { Name = "Archivist's Azure Mantle", Hue = 0x482 });       // Deep blue
            AddItem(new WizardsHat() { Name = "Savant’s Sable Point", Hue = 0x455 });     // Black
            AddItem(new Boots() { Name = "Footfalls of Whispered Lore", Hue = 0x47E });   // Pale blue
            AddItem(new BodySash() { Name = "Sash of Forgotten Truths", Hue = 0x4E9 });   // Pale silver
            AddItem(new GnarledStaff() { Name = "Staff of the Shelved Storm", Hue = 0x487 }); // Pale azure

            HairItemID = 0x203B;
            HairHue = 0x466; // Faint silver
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x466;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this); // Attach traits, vendor system, random loot
        }

        public EryndilArchivist(Serial serial) : base(serial) { }

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
