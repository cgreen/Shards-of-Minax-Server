/*
 * Scripts/Custom/DialogueSystem/ShadowmasterZahid.cs
 * Black market boss with dynamic dialogue, Qasaria intrigue, custom outfit.
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
    [CorpseName("the corpse of Shadowmaster Zahid")]
    public class ShadowmasterZahid : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ShadowmasterZahid()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ShadowmasterZahid.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ShadowmasterZahid()
            : base(AIType.AI_Thief, FightMode.None, 10, 1, 0.1, 0.2)
        {
            Name = "Shadowmaster Zahid";
            Title = "the Undermarket Kingpin";
            Body = 0x190; // Human male
            Hue = 0x46F; // Olive skin

            // Unique, criminal-luxe outfit pieces
            AddItem(new SkullCap() { Name = "Veil of the Endless Bazaar", Hue = 0x497 });
            AddItem(new FancyShirt() { Name = "Silks of the Hidden Crescent", Hue = 0x8B8 });
            AddItem(new BodySash() { Name = "Shadowmaster's Whisper Sash", Hue = 0x455 });
            AddItem(new LeatherDo() { Name = "Smuggler's Midnight Vest", Hue = 0x66D });
            AddItem(new LeatherNinjaPants() { Name = "Nightstride Trousers", Hue = 0x961 });
            AddItem(new NinjaTabi() { Name = "Silent Step Sandals", Hue = 0x455 });
            AddItem(new LeatherGloves() { Name = "Claws of the Undermarket", Hue = 0x497 });
            AddItem(new ShadowSai() { Name = "Sai of Vanishing", Hue = 0x8B8 }); // Weapon

            HairItemID = 0x203B; // Long hair
            HairHue = 0x455; // Dark brown
            FacialHairItemID = 0x203F; // Full beard
            FacialHairHue = 0x497; // Black

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public ShadowmasterZahid(Serial serial) : base(serial) { }

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
