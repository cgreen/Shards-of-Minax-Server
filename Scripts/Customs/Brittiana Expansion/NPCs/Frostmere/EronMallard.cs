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
    [CorpseName("the corpse of Eron Mallard")]
    public class EronMallard : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static EronMallard()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "EronMallard.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public EronMallard()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Eron Mallard";
            Title = "the Snowglass Artisan";
            Body = 0x190; // Human male
            Hue = 0x4F1;

            // Outfit: Each piece is unique, named and hued
            AddItem(new FancyShirt() { Hue = 0x480, Name = "Mallard's Frosted Silk Shirt" });
            AddItem(new ElvenPants() { Hue = 0x47E, Name = "Snowbound Artificer's Leggings" });
            AddItem(new Cloak() { Hue = 0xB0F, Name = "Cloak of Reflected Truths" });
            AddItem(new Shoes() { Hue = 0x47E, Name = "Levitating Snow-Skates" });
            AddItem(new WizardsHat() { Hue = 0x4F2, Name = "Suncatcher's Pointed Cap" });
            AddItem(new BodySash() { Hue = 0x488, Name = "Starlit Glassworker's Sash" });

            HairItemID = 0x203C;
            HairHue = 0x47D;
            FacialHairItemID = 0x204C;
            FacialHairHue = 0x453;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public EronMallard(Serial serial) : base(serial) { }

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
