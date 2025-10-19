/*
 * Scripts/Custom/DialogueSystem/SafiyaAlSapphire.cs
 * Merchant-Queen NPC, rich Qasaria lore, custom dialogue.
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
    [CorpseName("the corpse of Safiya al-Sapphire")]
    public class SafiyaAlSapphire : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SafiyaAlSapphire()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SafiyaAlSapphire.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SafiyaAlSapphire()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Safiya al-Sapphire";
            Title = "the Merchant-Queen of Qasaria";
            Body = 0x191; // Human female
            Hue = 0x8A5; // Desert tan

            // Unique, lore-rich outfit
            AddItem(new FancyDress() { Name = "Azure Whisper-Gown of the Dunes", Hue = 0x5BC });
            AddItem(new BodySash() { Name = "Sapphire Chain of Coin and Fate", Hue = 0x5DF });
            AddItem(new Cloak() { Name = "Veil of Shifting Markets", Hue = 0x482 });
            AddItem(new Sandals() { Name = "Treader’s Slippers of Silent Gold", Hue = 0x8A7 });
            AddItem(new Circlet() { Name = "Diadem of Sapphire Accord", Hue = 0x512 });
            AddItem(new RingmailGloves() { Name = "Tradebinder’s Gloves", Hue = 0x978 });
            AddItem(new WoodlandBelt() { Name = "Merchant’s Ledger Sash", Hue = 0xBB8 });

            HairItemID = 0x203B;
            HairHue = 0x455; // Raven black
            FacialHairItemID = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public SafiyaAlSapphire(Serial serial) : base(serial) { }

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
