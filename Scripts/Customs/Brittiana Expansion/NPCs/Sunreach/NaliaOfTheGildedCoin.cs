/*
 * Scripts/Custom/DialogueSystem/NaliaOfTheGildedCoin.cs
 * Sunreach banker, Merchant Guildmaster, and quest-giver.
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
    [CorpseName("the remains of Nalia")]
    public class NaliaOfTheGildedCoin : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static NaliaOfTheGildedCoin()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "NaliaOfTheGildedCoin.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public NaliaOfTheGildedCoin()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nalia";
            Title = "of the Gilded Coin";
            Body = 0x191; // Human female
            Hue = 0x8FD; // Subtle gold/bronze skin

            // Unique, opulent merchant outfit
            AddItem(new FancyDress() { Name = "Gilded Merchant Dress", Hue = 0x8A5 });
            AddItem(new Cloak() { Name = "Sunreach Gold Cloak", Hue = 0x501 });
            AddItem(new BodySash() { Name = "Sash of Coin’s Favor", Hue = 0xB8D });
            AddItem(new FeatheredHat() { Name = "Gilded Coin Hat", Hue = 0x853 });
            AddItem(new Sandals() { Name = "Silken Sandals", Hue = 0x96B });
            AddItem(new GoldBracelet() { Name = "Merchant’s Cuff" });
            AddItem(new GoldRing() { Name = "Guild Signet Ring" });
            AddItem(new Spellbook() { Name = "Ledger of Laundered Gold" });

            HairItemID = 0x203C; // long wavy
            HairHue = 0x453; // rich brown
            FacialHairItemID = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public NaliaOfTheGildedCoin(Serial serial) : base(serial) { }

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
