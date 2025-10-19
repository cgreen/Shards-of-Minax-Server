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
    [CorpseName("the corpse of Old Marruk")]
    public class OldMarruk : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static OldMarruk()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "OldMarruk.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public OldMarruk()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Old Marruk";
            Title = "Goat-Herder of Frostmere";
            Body = 0x190; // Human male
            Hue = 0x846;

            // Custom unique outfit
            AddItem(new FurSarong() { Name = "Marruk’s Patchwork Goat-hide Sarong", Hue = 0x480 });
            AddItem(new Robe() { Name = "Weatherbeaten Frostcloak", Hue = 0x482 });
            AddItem(new HoodedShroudOfShadows() { Name = "Blindman’s Hood", Hue = 0x497 });
            AddItem(new Sandals() { Name = "Frostbitten Sandals", Hue = 0x465 });
            AddItem(new ShepherdsCrook() { Name = "The Soul-Seer’s Crook", Hue = 0x48E });

            HairItemID = 0x203B; // Long hair
            HairHue = 0x481; // Frosty gray
            FacialHairItemID = 0x204B; // Long beard
            FacialHairHue = 0x481;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public OldMarruk(Serial serial) : base(serial) { }

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
