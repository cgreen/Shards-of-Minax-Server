/*
 * Scripts/Custom/DialogueSystem/ZarrahTheBarkbound.cs
 * Data-driven dialogue, custom outfit, Verdant lore.
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
    [CorpseName("the corpse of Zarrah the Barkbound")]
    public class ZarrahTheBarkbound : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ZarrahTheBarkbound()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ZarrahTheBarkbound.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ZarrahTheBarkbound()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Zarrah the Barkbound";
            Title = "the Tree-Hermit";
            Body = 0x191; // Human female
            Hue = 0x835; // earthy brown-green

            // Bark-like, druidic, tribal outfit
            AddItem(new WoodlandChest() { Name = "Barkbound Chestwraps", Hue = 0x599 });
            AddItem(new WoodlandLegs() { Name = "Rootbound Leggings", Hue = 0x58B });
            AddItem(new WoodlandArms() { Name = "Branchwoven Armlets", Hue = 0x594 });
            AddItem(new WoodlandGloves() { Name = "Mossy Gloves", Hue = 0x7D2 });
            AddItem(new FlowerGarland() { Name = "Wreath of Verdant Blossoms", Hue = 0xB88 });
            AddItem(new Sandals() { Name = "Earthen Sandals", Hue = 0x59A });

            HairItemID = 0x203C; // long hair
            HairHue = 0x59A; // pale greenish-brown (mossy)
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public ZarrahTheBarkbound(Serial serial) : base(serial) { }

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
