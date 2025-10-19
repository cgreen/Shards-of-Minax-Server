/*
 * Scripts/Custom/DialogueSystem/OriOfTheHollowTree.cs
 * Data-driven dialogue, unique outfit, Verdant Tribes lore, haunted woods quest.
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
    [CorpseName("the corpse of Ori of the Hollow Tree")]
    public class OriOfTheHollowTree : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static OriOfTheHollowTree()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "OriOfTheHollowTree.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public OriOfTheHollowTree()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ori of the Hollow Tree";
            Title = "Bone-Flute Carver";
            Body = 0x190; // Human male or choose 0x191 for female
            Hue = 0x845; // Earthen

            // Unique tribal/druidic outfit: bark-like, bone, and natural
            AddItem(new TribalMask() { Name = "Stag-Bone Mask", Hue = 0x47D });
            AddItem(new Robe() { Name = "Hollow-Bark Robe", Hue = 0x7C4 });
            AddItem(new Sandals() { Name = "Rootwoven Sandals", Hue = 0x1B2 });
            AddItem(new BodySash() { Name = "Sash of Bone Charms", Hue = 0x482 });
            AddItem(new BoneHarvester() { Name = "Bone-Handled Carving Knife", Hue = 0x482 });

            HairItemID = 0x203C; // Messy
            HairHue = 0x453;
            FacialHairItemID = 0x203E;
            FacialHairHue = 0x453;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public OriOfTheHollowTree(Serial serial) : base(serial) { }

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
