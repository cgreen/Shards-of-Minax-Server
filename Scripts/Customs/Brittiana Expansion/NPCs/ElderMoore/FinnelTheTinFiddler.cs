/*
 * Scripts/Custom/DialogueSystem/FinnelTheTinFiddler.cs
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
    [CorpseName("the corpse of Finnel the Tin-Fiddler")]
    public class FinnelTheTinFiddler : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static FinnelTheTinFiddler()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "FinnelTheTinFiddler.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public FinnelTheTinFiddler()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Finnel the Tin-Fiddler";
            Title = "Balladeer of Eldermoor";
            Body = 0x190; // Human male
            Hue = 0x8A5;

            // Unique, colorful outfit:
            AddItem(new FancyShirt() { Name = "Jester’s Songcoat", Hue = 0x48E }); // Vibrant blue
            AddItem(new ShortPants() { Name = "Traveler’s Sash-breeches", Hue = 0x59E }); // Lively green
            AddItem(new JesterHat() { Name = "The Clinking Cap", Hue = 0x486 }); // Playful purple
            AddItem(new Cloak() { Name = "Twilight Minstrel’s Cloak", Hue = 0x4AA }); // Deep silver-gray
            AddItem(new JesterShoes() { Name = "Tin-Toed Slippers", Hue = 0x8FD }); // Pale gold
            AddItem(new HalfApron() { Name = "Bard’s Sash of Keepsakes", Hue = 0x496 }); // Rusty red

            // Musical weapon!
            AddItem(new ResonantHarp() { Name = "Finnel’s Fiddle of Whispers", Hue = 0x481 });

            HairItemID = 0x203B; // Messy hair
            HairHue = 0x47F; // Chestnut brown
            FacialHairItemID = 0x204B; // Patchy goatee
            FacialHairHue = 0x47F;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public FinnelTheTinFiddler(Serial serial) : base(serial) { }

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
