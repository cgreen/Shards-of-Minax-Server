/*
 * Scripts/Custom/DialogueSystem/SergioDumar.cs
 * Dialogue-driven vintner with quest hooks for poison and intrigue.
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
    [CorpseName("the corpse of Sergio Dumar")]
    public class SergioDumar : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SergioDumar()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SergioDumar.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SergioDumar()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Sergio Dumar";
            Title = "the Vintner";
            Body = 0x190; // Human male
            Hue = 0x83EA; // Mediterranean olive tone

            // Outfit: rakish, faintly sinister vintner/poisoner
            AddItem(new Shirt() { Name = "Embroidered Wine Merchant's Shirt", Hue = 0x485 });
            AddItem(new FancyShirt() { Name = "Crimson Sash", Hue = 0x21 });
            AddItem(new HalfApron() { Name = "Stained Tasting Apron", Hue = 0x455 });
            AddItem(new LongPants() { Name = "Velvet Breeches", Hue = 0x497 });
            AddItem(new Boots() { Name = "Polished Boots", Hue = 0x455 });
            AddItem(new FeatheredHat() { Name = "Plumed Sommelier's Hat", Hue = 0x59B });
            AddItem(new LeatherGloves() { Name = "Wine-stained Gloves", Hue = 0x76 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x10; // dark brown
            FacialHairItemID = 0x203F; // Vandyke
            FacialHairHue = 0x10;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public SergioDumar(Serial serial) : base(serial) { }

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
