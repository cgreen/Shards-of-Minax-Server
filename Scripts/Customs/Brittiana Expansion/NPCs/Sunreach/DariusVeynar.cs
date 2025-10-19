/*
 * Scripts/Custom/DialogueSystem/DariusVeynar.cs
 * Data-driven dialogue, custom outfit, Sunreach trade & intrigue.
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
    [CorpseName("the corpse of Darius Veynar")]
    public class DariusVeynar : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static DariusVeynar()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "DariusVeynar.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public DariusVeynar()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Darius Veynar";
            Title = "the Merchant Prince";
            Body = 0x190; // Human male
            Hue = 0x83F8; // Tanned

            // Unique, opulent merchant outfit
            AddItem(new FancyShirt() { Name = "Crimson Silk Shirt", Hue = 0x21 });
            AddItem(new Surcoat() { Name = "Sable Brocade Surcoat", Hue = 0x497 });
            AddItem(new LongPants() { Name = "Gold-Trimmed Silk Trousers", Hue = 0x8A5 });
            AddItem(new BodySash() { Name = "Sash of the Five Houses", Hue = 0x482 });
            AddItem(new Cloak() { Name = "Councilman's Velvet Cloak", Hue = 0x59A });
            AddItem(new Boots() { Name = "Merchant-Prince’s Boots", Hue = 0x455 });
            AddItem(new FeatheredHat() { Name = "Plumed Sunreach Hat", Hue = 0x5BE });

            // Jewelry
            AddItem(new GoldRing());
            AddItem(new GoldBracelet());

            HairItemID = 0x203B; // Long hair
            HairHue = 0x47E; // Black
            FacialHairItemID = 0x203F; // Trimmed beard
            FacialHairHue = 0x47E;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public DariusVeynar(Serial serial) : base(serial) { }

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
