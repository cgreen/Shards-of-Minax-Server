/*
 * Scripts/Custom/DialogueSystem/OldManRenjiro.cs
 * Blind seer of Hinokami, riddle dialogue, dream-quest hooks.
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
    [CorpseName("the remains of Old Man Renjiro")]
    public class OldManRenjiro : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static OldManRenjiro()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "OldManRenjiro.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public OldManRenjiro()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Old Man Renjiro";
            Title = "the Blind Seer";
            Body = 0x190; // Human male
            Hue = 0x840;  // Subtle pale hue

            // Unique mystic outfit (the demon mask stands out)
            AddItem(new TribalMask() { Name = "Oni Mask of Spirit Sight", Hue = 0x66D }); // deep red
            AddItem(new MonkRobe() { Name = "Threadbare Monk’s Robe", Hue = 0x47E }); // faded blue-gray
            AddItem(new Obi() { Name = "Sash of Fortune Telling", Hue = 0xB45 });
            AddItem(new Sandals() { Name = "Worn Straw Sandals", Hue = 0x901 });
            AddItem(new QuarterStaff() { Name = "Staff of the Blind Dreamer", Hue = 0x972 });

            HairItemID = 0x203C; // Long beard
            HairHue = 0x455; // Gray
            FacialHairItemID = 0x203F;
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public OldManRenjiro(Serial serial) : base(serial) { }

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
