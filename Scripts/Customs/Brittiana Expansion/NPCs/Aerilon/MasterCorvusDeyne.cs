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
    [CorpseName("the corpse of Master Corvus Deyne")]
    public class MasterCorvusDeyne : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MasterCorvusDeyne()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MasterCorvusDeyne.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MasterCorvusDeyne()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Master Corvus Deyne";
            Title = "Archmage of War, Azure Conclave";
            Body = 0x190; // Human male
            Hue = 0x487; // Pale as moonlight

            // Distinctive Outfit
            AddItem(new Robe() { Name = "Mantle of the Azure Tempest", Hue = 0x489 });
            AddItem(new BodySash() { Name = "Conclave Sash of Supremacy", Hue = 0x512 });
            AddItem(new WizardsHat() { Name = "Crown of the Storm Sigil", Hue = 0x845 });
            AddItem(new PlateGloves() { Name = "Gauntlets of the Conqueror's Grasp", Hue = 0x510 });
            AddItem(new Boots() { Name = "War-Mage's Umbral Treads", Hue = 0x497 });
            AddItem(new LeatherGorget() { Name = "Arcane Gorget of Oaths", Hue = 0x455 });

            // Weapon: Mystic Staff
            AddItem(new GnarledStaff() { Name = "Voltaic Warstaff", Hue = 0x8A7 });

            HairItemID = 0x203B;
            HairHue = 0x497;
            FacialHairItemID = 0x204B;
            FacialHairHue = 0x497;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);	
        }

        public MasterCorvusDeyne(Serial serial) : base(serial) { }

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
