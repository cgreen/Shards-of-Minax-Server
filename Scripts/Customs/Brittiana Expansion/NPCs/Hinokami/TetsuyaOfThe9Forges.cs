/*
 * Scripts/Custom/DialogueSystem/TetsuyaOfThe9Forges.cs
 * Data-driven dialogue, custom smith outfit, poetic quest logic.
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
    [CorpseName("the corpse of Tetsuya of the 9 Forges")]
    public class TetsuyaOfThe9Forges : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static TetsuyaOfThe9Forges()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "TetsuyaOfThe9Forges.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public TetsuyaOfThe9Forges()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tetsuya";
            Title = "of the 9 Forges";
            Body = 0x190; // Human male
            Hue = 0x83F8; // Slightly tanned

            // Outfit: Master smith with Tokuno flavor
            AddItem(new Kamishimo() { Name = "Smith's Kamishimo", Hue = 0x85D });
            AddItem(new Hakama() { Name = "Iron-Dusted Hakama", Hue = 0x497 });
            AddItem(new SamuraiTabi() { Name = "Forge-Scarred Tabi", Hue = 0x900 });
            AddItem(new LeatherGloves() { Name = "Hammerhands", Hue = 0x83E });
            AddItem(new LeatherDo() { Name = "Smelted Leather Do", Hue = 0x96B });
            AddItem(new LeatherJingasa() { Name = "Crested Jingasa", Hue = 0x7AA });
            AddItem(new SmithSmasher() { Name = "The Ninth Hammer", Hue = 0x455 });
            // Optional: add a belt with a pouch for rare ores
            AddItem(new Obi() { Name = "Orekeeper's Obi", Hue = 0x51D });

            HairItemID = 0x203C; // topknot
            HairHue = 0x455;     // black
            FacialHairItemID = 0x2041; // thin beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public TetsuyaOfThe9Forges(Serial serial) : base(serial) { }

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
