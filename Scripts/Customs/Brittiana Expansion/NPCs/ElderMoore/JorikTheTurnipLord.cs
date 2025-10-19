/*
 * Scripts/Custom/DialogueSystem/JorikTheTurnipLord.cs
 * Fully data-driven dialogue.
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
    [CorpseName("the corpse of Jorik the Turnip Lord")]
    public class JorikTheTurnipLord : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static JorikTheTurnipLord()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "JorikTheTurnipLord.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public JorikTheTurnipLord()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Jorik the Turnip Lord";
            Title = "the Drunken Squire of Eldermoor";
            Body = 0x190; // Human male
            Hue = 0x841;  // Weathered farmer’s skin

            // Unique outfit: All turnip-themed!
            AddItem(new FancyShirt() { Name = "Turniplord's Spattered Jerkin", Hue = 0x18D }); // deep root purple
            AddItem(new Kilt() { Name = "Muddy Field Kilt", Hue = 0x571 }); // earthy brown
            AddItem(new HalfApron() { Name = "Squire's Turnip-Sack Apron", Hue = 0x47E }); // faded burlap gold
            AddItem(new TallStrawHat() { Name = "Turnip-Top Hat", Hue = 0x8A5 }); // pale green, like turnip leaves
            AddItem(new Sandals() { Name = "Soggy Sodbuster Sandals", Hue = 0x1BB }); // marsh green

            HairItemID = 0x2047;
            HairHue = 0x422; // straw-colored
            FacialHairItemID = 0x203C;
            FacialHairHue = 0x453; // reddish


            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public JorikTheTurnipLord(Serial serial) : base(serial) { }

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
