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
    [CorpseName("the corpse of Aldric the Hunter")]
    public class AldricTheHunter : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static AldricTheHunter()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "AldricTheHunter.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public AldricTheHunter()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Aldric the Hunter";
            Title = "Warden of Eldermoor’s Wilds";
            Body = 0x190; // Human male
            Hue = 0x83C;

            AddItem(new WoodlandChest() { Name = "Aldric's Bramble-Stitched Jerkin", Hue = 0x7A5 });
            AddItem(new LeatherLegs() { Name = "Weathered Huntsman's Trousers", Hue = 0x455 });
            AddItem(new Boots() { Name = "Bog-Stained Trail Boots", Hue = 0x966 });
            AddItem(new Cloak() { Name = "Cloak of the Marsh Dawn", Hue = 0x47E });
            AddItem(new LeatherArms() { Name = "Wolfsinew Armguards", Hue = 0x96D });
            AddItem(new FeatheredHat() { Name = "Crowfeather Ranger's Cap", Hue = 0x455 });
            AddItem(new RangersCrossbow() { Name = "Aldric's Crossbow 'Silent Sting'", Hue = 0x59B });

            HairItemID = 0x203C;
            HairHue = 0x453;
            FacialHairItemID = 0x2040;
            FacialHairHue = 0x453;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public AldricTheHunter(Serial serial) : base(serial) { }

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
