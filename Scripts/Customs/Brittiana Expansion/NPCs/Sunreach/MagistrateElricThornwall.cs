/*
 * Scripts/Custom/DialogueSystem/MagistrateElricThornwall.cs
 * Data-driven dialogue, corrupt legalist, Sunreach lore.
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
    [CorpseName("the corpse of Magistrate Elric Thornwall")]
    public class MagistrateElricThornwall : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MagistrateElricThornwall()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MagistrateElricThornwall.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MagistrateElricThornwall()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Magistrate Elric Thornwall";
            Title = "the Shadow Judge";
            Body = 0x190; // Human male
            Hue = 0x83F;  // Slightly pale/ashen

            // Distinctive corrupt magistrate look: black robes, judge's sash, subtle hints of power and corruption
            AddItem(new Robe() { Name = "Judicial Robe of Sunreach", Hue = 0x455 });
            AddItem(new BodySash() { Name = "Sash of the Five Houses", Hue = 0x4F5 });
            AddItem(new Sandals() { Name = "Polished Magistrate Sandals", Hue = 0x497 });
            AddItem(new LeatherGloves() { Name = "Inscribed Lawkeeper’s Gloves", Hue = 0x495 });
            AddItem(new Cap() { Name = "Magistrate's Cap", Hue = 0x497 });

            HairItemID = 0x2048; // Short hair
            HairHue = 0x455;     // Black
            FacialHairItemID = 0x203F; // Goatee
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public MagistrateElricThornwall(Serial serial) : base(serial) { }

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
