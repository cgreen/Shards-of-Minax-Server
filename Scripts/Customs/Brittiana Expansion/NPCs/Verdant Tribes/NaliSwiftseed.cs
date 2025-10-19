/*
 * Scripts/Custom/DialogueSystem/NaliSwiftseed.cs
 * Data-driven dialogue, custom outfit, Verdant Tribes lore.
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
    [CorpseName("the corpse of Nali Swiftseed")]
    public class NaliSwiftseed : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static NaliSwiftseed()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "NaliSwiftseed.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public NaliSwiftseed()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nali Swiftseed";
            Title = "the Seed Runner";
            Body = 0x191; // Human female
            Hue = 0x83F3;

            // Unique, lore-rich outfit for a Verdant Tribes herbal courier
            AddItem(new FlowerGarland() { Name = "Blooming Laurel", Hue = 0x481 });
            AddItem(new WoodlandChest() { Name = "Mossbound Tunic", Hue = 0x59B });
            AddItem(new WoodlandLegs() { Name = "Leafwoven Leggings", Hue = 0x59B });
            AddItem(new Sandals() { Name = "Earth-Touched Sandals", Hue = 0x455 });
            AddItem(new HalfApron() { Name = "Herbalist's Apron", Hue = 0x47F });
            AddItem(new BodySash() { Name = "Sash of Verdant Paths", Hue = 0x59B });
            AddItem(new Bag() { Name = "Bag of Seeds", Hue = 0x59B }); // Custom bag for flavor

            HairItemID = 0x203C; // Short tied hair
            HairHue = 0x47B;     // Greenish-brown

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public NaliSwiftseed(Serial serial) : base(serial) { }

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
