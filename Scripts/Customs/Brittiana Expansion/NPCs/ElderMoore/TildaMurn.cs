/*
 * Scripts/Custom/DialogueSystem/TildaMurn.cs
 * Custom, data-driven dialogue for Tilda Murn the Goat-Matron.
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
    [CorpseName("the corpse of Tilda Murn")]
    public class TildaMurn : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static TildaMurn()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "TildaMurn.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public TildaMurn()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tilda Murn";
            Title = "the Goat-Matron";
            Body = 0x191; // Human female
            Hue = 0x847;

            // Unique, story-rich attire:
            AddItem(new FancyShirt() { Name = "The Old Bleater's Smock", Hue = 0x47E });    // deep dusty purple
            AddItem(new Skirt() { Name = "Goat’s Blessing Wrap", Hue = 0x842 });            // earthy brown
            AddItem(new HalfApron() { Name = "Milking-Apron of Many Stains", Hue = 0x96B }); // weathered grey-blue
            AddItem(new Bonnet() { Name = "Murn’s Crooked Bonnet", Hue = 0x46E });          // lopsided, faded green
            AddItem(new Boots() { Name = "Muddy Marsh Boots", Hue = 0x57D });               // mossy brown
            AddItem(new Cloak() { Name = "Elder’s Goat-Cloth Shawl", Hue = 0xB8B });        // patchwork cream

            HairItemID = 0x203C;
            HairHue = 0x453;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public TildaMurn(Serial serial) : base(serial) { }

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
