/*
 * Scripts/Custom/DialogueSystem/KethHollowgaze.cs
 * Data-driven dialogue, custom outfit, Verdant lore, loyalty/betrayal quests.
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
    [CorpseName("the corpse of Keth Hollowgaze")]
    public class KethHollowgaze : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static KethHollowgaze()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "KethHollowgaze.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public KethHollowgaze()
            : base(AIType.AI_Archer, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Keth Hollowgaze";
            Title = "the Exile Shadow-Walker";
            Body = 0x190; // Human male
            Hue = 0x83F;

            // Outfit: Shadowy, tribal, mask
            AddItem(new TribalMask() { Name = "Carved Hollow Mask", Hue = 0x455 });
            AddItem(new WoodlandArms() { Hue = 0x7C2 });
            AddItem(new WoodlandChest() { Hue = 0x7C2 });
            AddItem(new WoodlandLegs() { Hue = 0x7C2 });
            AddItem(new LeatherGloves() { Hue = 0x594 });
            AddItem(new Cloak() { Name = "Cloak of Fallen Leaves", Hue = 0x59B });
            AddItem(new Sandals() { Hue = 0x1BB });
            AddItem(new GnarledStaff() { Name = "Shadow-Walker's Cane", Hue = 0x8A5 });

            HairItemID = 0x203C; // Long hair
            HairHue = 0x455;
            FacialHairItemID = 0x203F; // Long beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public KethHollowgaze(Serial serial) : base(serial) { }

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
