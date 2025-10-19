/*
 * Scripts/Custom/DialogueSystem/BrukTheSilent.cs
 * Data-driven dialogue, unique silent monk outfit, Verdant lore.
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
    [CorpseName("the corpse of Bruk the Silent")]
    public class BrukTheSilent : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BrukTheSilent()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BrukTheSilent.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BrukTheSilent()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Bruk the Silent";
            Title = "Warrior Monk of the Verdant Tribes";
            Body = 0x190; // Human male
            Hue = 0x83A;

            // Distinctive silent monk/tribal look
            AddItem(new MonkRobe() { Name = "Verdant Monk Robe", Hue = 0x59C });
            AddItem(new HoodedShroudOfShadows() { Name = "Cowl of Atonement", Hue = 0x59C });
            AddItem(new Sandals() { Name = "Grovesand Sandals", Hue = 0x455 });
            AddItem(new LeatherGloves() { Name = "Gloves of Quiet Resolve", Hue = 0x8A5 });
            AddItem(new QuarterStaff() { Name = "Silent Guardian's Staff", Hue = 0x59C });

            // Tattoos (if supported)
            // XmlAttach.AttachTo(this, new XmlTattoo("glyphs", 0x54F));

            HairItemID = 0x2047; // short hair
            HairHue = 0x453;
            FacialHairItemID = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public BrukTheSilent(Serial serial) : base(serial) { }

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
