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
    [CorpseName("the frozen form of Kaelen")]
    public class KaelenTheIcebinder : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static KaelenTheIcebinder()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "KaelenTheIcebinder.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public KaelenTheIcebinder()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kaelen the Icebinder";
            Title = "the Apprentice Mage";
            Body = 0x190; // Human male
            Hue = 0x47E; // Pale blueish skin

            // Unique outfit, all with custom hues and names
            AddItem(new FancyShirt() { Name = "Glacier-Woven Shirt", Hue = 0x482 });
            AddItem(new ElvenPants() { Name = "Cerulean Frostpants", Hue = 0x51F });
            AddItem(new HoodedShroudOfShadows() { Name = "Obelisk-Blue Shroud", Hue = 0x4F7 });
            AddItem(new Sandals() { Name = "Miststep Sandals", Hue = 0x480 });
            AddItem(new LeatherGloves() { Name = "Wyvernhide Gloves", Hue = 0x49C });
            AddItem(new MageWand() { Name = "Crystalized Chillwand", Hue = 0x9C4 });

            HairItemID = 0x203B;
            HairHue = 0x47E;
            FacialHairItemID = 0x204C;
            FacialHairHue = 0x482;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public KaelenTheIcebinder(Serial serial) : base(serial) { }

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
