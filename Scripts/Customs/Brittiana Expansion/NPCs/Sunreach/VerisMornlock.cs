/*
 * Scripts/Custom/DialogueSystem/VerisMornlock.cs
 * Fence/arms dealer, Sunreach intrigue, dialogue-driven.
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
    [CorpseName("the corpse of Veris Mornlock")]
    public class VerisMornlock : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static VerisMornlock()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "VerisMornlock.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public VerisMornlock()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Veris Mornlock";
            Title = "the Arms Fence";
            Body = 0x190; // Human male
            Hue = 0x83E;

            // Rugged, criminal-but-practical outfit
            AddItem(new Shirt() { Name = "Worn Canvas Shirt", Hue = 0x967 });
            AddItem(new LongPants() { Name = "Oiled Leather Trousers", Hue = 0x455 });
            AddItem(new HalfApron() { Name = "Tool-Stained Apron", Hue = 0x1BB });
            AddItem(new LeatherGloves() { Name = "Scuffed Gauntlets", Hue = 0x497 });
            AddItem(new Bandana() { Name = "Grease-Smudged Bandana", Hue = 0x46F });
            AddItem(new Boots() { Name = "Heavy Work Boots", Hue = 0x90C });

            // Weapons—visible as part of his trade
            AddItem(new Cutlass() { Name = "Illicit Blade", Movable = false, Hue = 0x839 });
            AddItem(new Crossbow() { Name = "Crate-Fresh Crossbow", Movable = false, Hue = 0x59A });

            HairItemID = 0x203C; // short hair
            HairHue = 0x2B; // dark
            FacialHairItemID = 0x2041; // goatee
            FacialHairHue = 0x2B;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public VerisMornlock(Serial serial) : base(serial) { }

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
