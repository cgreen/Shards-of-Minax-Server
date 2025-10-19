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
    [CorpseName("the corpse of Brenvar")]
    public class BrenvarInnkeeper : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BrenvarInnkeeper()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BrenvarInnkeeper.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BrenvarInnkeeper()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Brenvar";
            Title = "Innkeeper of the Stubborn Boar";
            Body = 0x190; // Human male
            Hue = 0x83F;

            AddItem(new Shirt() { Name = "Ale-Stained Linen Shirt", Hue = 0x65D });
            AddItem(new HalfApron() { Name = "Stubborn Boar’s Apron", Hue = 0x6AB });
            AddItem(new LongPants() { Name = "Dockside Stout Trousers", Hue = 0x59C });
            AddItem(new Boots() { Name = "Old River Boots", Hue = 0x45B });
            AddItem(new BodySash() { Name = "Spiced Rum Sash", Hue = 0x483 });
            AddItem(new Cloak() { Name = "Bronze Tankard Brooch", Hue = 0x972 });
            AddItem(new Bandana() { Name = "Disheveled Bar Mop", Hue = 0x497 });

            FacialHairItemID = 0x204B; // Beard
            FacialHairHue = 0x47D; // Salt-and-pepper

            HairItemID = 0x203B; // Medium
            HairHue = 0x47D;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public BrenvarInnkeeper(Serial serial) : base(serial) { }

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
