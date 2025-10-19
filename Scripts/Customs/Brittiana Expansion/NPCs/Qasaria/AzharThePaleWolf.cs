/*
 * Scripts/Custom/DialogueSystem/AzharThePaleWolf.cs
 * Ash Serpent defector, Qasaria Outcast, deep lore, bone altar quest.
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
    [CorpseName("the corpse of Azhar the Pale Wolf")]
    public class AzharThePaleWolf : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static AzharThePaleWolf()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "AzharThePaleWolf.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public AzharThePaleWolf()
            : base(AIType.AI_Archer, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Azhar the Pale Wolf";
            Title = "Ash Serpent Defector";
            Body = 0x190; // Human male
            Hue = 0x47E; // Ashen skin

            // Unique, lore-rich outfit pieces
            AddItem(new TribalMask() { Name = "Wolfbone Mask of Ashen Memory", Hue = 0x9C2 }); // Pale bone white
            AddItem(new LeatherDo() { Name = "Jacket of the Burned Oasis", Hue = 0x835 }); // Charred brown
            AddItem(new LeatherNinjaPants() { Name = "Sandrunner's Wraps", Hue = 0xB95 }); // Desert gold
            AddItem(new Cloak() { Name = "Desert Cloak of Remorse", Hue = 0xA3A }); // Bleached grey
            AddItem(new BodySash() { Name = "Sash of Broken Brotherhood", Hue = 0x7B5 }); // Ashen blue
            AddItem(new FurBoots() { Name = "Tracks of the Exiled Wolf", Hue = 0x79E }); // Pale grey
            AddItem(new BoneHarvester() { Name = "The Severed Crescent", Hue = 0x8AC }); // Tainted ivory, his signature weapon

            HairItemID = 0x203C; // Short tousled
            HairHue = 0x455; // Stark white
            FacialHairItemID = 0x2041; // Short beard
            FacialHairHue = 0x47E; // Pale ashen

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public AzharThePaleWolf(Serial serial) : base(serial) { }

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
