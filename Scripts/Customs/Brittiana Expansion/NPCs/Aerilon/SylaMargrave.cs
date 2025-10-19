/*
 * Scripts/Custom/DialogueSystem/SylaMargrave.cs
 * Verbose, fiery, lore-rich dialogue and custom outfit.
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
    [CorpseName("the ashes of Syla Margrave")]
    public class SylaMargrave : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SylaMargrave()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SylaMargrave.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SylaMargrave()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Syla Margrave";
            Title = "Pyromancer of the Outer Ring";
            Body = 0x191; // Human female
            Hue = 0x4FD;

            // Unique, loreful outfit—fiery theme, distinctive pieces
            AddItem(new WizardsHat()      { Name = "Crown of Searing Insight",        Hue = 0x489 }); // bright flame orange
            AddItem(new FancyShirt()      { Name = "Emberwoven Chemise",               Hue = 0x2A4 }); // deep ember red
            AddItem(new BodySash()        { Name = "Cincture of Flickering Sparks",    Hue = 0x550 }); // golden yellow
            AddItem(new FemaleElvenRobe() { Name = "Mantle of the Ashen Ring",         Hue = 0x455 }); // ashen gray
            AddItem(new Cloak()           { Name = "Shroud of Phoenix Smoke",          Hue = 0x47F }); // smoky crimson
            AddItem(new LeatherGloves()   { Name = "Gauntlets of Blistering Control",  Hue = 0xB53 }); // magma orange
            AddItem(new FurBoots()        { Name = "Boots of the Firewalker's Path",   Hue = 0x6A4 }); // soot-black

            HairItemID = 0x203B; // Long hair
            HairHue = 0xA25;     // bright coppery red

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public SylaMargrave(Serial serial) : base(serial) { }

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
