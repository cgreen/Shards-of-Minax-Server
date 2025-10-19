/*
 * Scripts/Custom/DialogueSystem/FarimTheSuncaller.cs
 * Blind prophet of Sunreach; gives a relic recovery quest.
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
    [CorpseName("the corpse of Farim the Suncaller")]
    public class FarimTheSuncaller : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static FarimTheSuncaller()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "FarimTheSuncaller.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public FarimTheSuncaller()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Farim the Suncaller";
            Title = "the Blind Prophet";
            Body = 0x190; // Human male
            Hue = 0x840; // Tanned, weathered

            // Outfit: Blind prophet, desert-worn, hint of mystic
            AddItem(new HoodedShroudOfShadows() { Name = "Sunwoven Hood", Hue = 0xB91 });
            AddItem(new Robe() { Name = "Prophet’s Robe of Sunreach", Hue = 0xA1C });
            AddItem(new BodySash() { Name = "Braided Sash of Dawn", Hue = 0xB81 });
            AddItem(new Sandals() { Name = "Wanderer’s Footwraps", Hue = 0x1B2 });
            AddItem(new BeggersStick() { Name = "Suncaller’s Cane", Hue = 0x482 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x47E; // white/silver
            FacialHairItemID = 0x204B; // long beard
            FacialHairHue = 0x47E; // white/silver

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public FarimTheSuncaller(Serial serial) : base(serial) { }

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
