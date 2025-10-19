/*
 * Scripts/Custom/DialogueSystem/SennaGildedDust.cs
 * Data-driven dialogue, custom outfit, Qasaria intrigue.
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
    [CorpseName("the corpse of Senna")]
    public class SennaGildedDust : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SennaGildedDust()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SennaGildedDust.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SennaGildedDust()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Senna";
            Title = "of the Gilded Dust";
            Body = 0x191; // Human female
            Hue = 0x845;  // Warm, golden-brown skin

            // Unique, lore-rich outfit pieces
            AddItem(new FancyDress() { Name = "Sandswept Gossamer Dress", Hue = 0x1B72 }); // Gold-rose silk
            AddItem(new BodySash() { Name = "Veil of Whispered Secrets", Hue = 0x4CE }); // Soft pearl
            AddItem(new Sandals() { Name = "Footfalls of the Dancer's Path", Hue = 0x497 }); // Azure blue
            AddItem(new Cloak() { Name = "Cloak of Golden Dusk", Hue = 0x8B7 }); // Faded gold
            AddItem(new FlowerGarland() { Name = "Circlet of Desert Blooms", Hue = 0x489 }); // Pink/coral
            AddItem(new LeatherGloves() { Name = "Grasp of Silent Intent", Hue = 0x452 }); // Sandy beige
            AddItem(new Dagger() { Name = "Stinger of the Undermarket", Hue = 0x501 }); // Glints like quartz

            HairItemID = 0x203C; // Long, flowing hair
            HairHue = 0x455; // Lustrous black
            FacialHairItemID = 0x0000; // none
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public SennaGildedDust(Serial serial) : base(serial) { }

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
