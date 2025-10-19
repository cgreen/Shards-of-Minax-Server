/*
 * Scripts/Custom/DialogueSystem/CaptainBryndra.cs
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
    [CorpseName("the corpse of Captain Bryndra")]
    public class CaptainBryndra : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static CaptainBryndra()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "CaptainBryndra.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public CaptainBryndra()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Captain Bryndra";
            Title = "of the Frostguard";
            Body = 0x191; // Human female
            Hue = 0x468;

            // Unique, named, color-coded equipment
            AddItem(new PlateHelm() { Name = "Ironbrow’s Crest", Hue = 0x482 });
            AddItem(new LeatherGorget() { Name = "Chillward Collar", Hue = 0x497 });
            AddItem(new LeatherArms() { Name = "Bracers of Vigil", Hue = 0x59B });
            AddItem(new LeatherGloves() { Name = "Militia’s Grasp", Hue = 0x57A });
            AddItem(new LeatherChest() { Name = "Frostguard Hauberk", Hue = 0x480 });
            AddItem(new StuddedLegs() { Name = "Defiant Gaiters", Hue = 0x495 });
            AddItem(new Boots() { Name = "Snowbreaker Boots", Hue = 0x4B5 });
            AddItem(new Cloak() { Name = "Mantle of the Unbowed", Hue = 0x835 });
            AddItem(new HalfApron() { Name = "Warden’s Apron", Hue = 0x453 });

            AddItem(new Broadsword() { Name = "Icecleaver", Hue = 0x480 });
            AddItem(new BashingShield() { Name = "Wall of Resolve", Hue = 0x59B });

            HairItemID = 0x203C;
            HairHue = 0x497;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public CaptainBryndra(Serial serial) : base(serial) { }

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
