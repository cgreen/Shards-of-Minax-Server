/*
 * Scripts/Custom/DialogueSystem/CommanderShiraAlGarnet.cs
 * Data-driven dialogue, custom outfit, Qasaria guard commander, spy quest.
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
    [CorpseName("the corpse of Commander Shira al-Garnet")]
    public class CommanderShiraAlGarnet : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static CommanderShiraAlGarnet()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "CommanderShiraAlGarnet.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public CommanderShiraAlGarnet()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Commander Shira al-Garnet";
            Title = "of the Ruby Guard";
            Body = 0x191; // Human female
            Hue = 0x455;

            // Unique, lore-rich outfit pieces (with custom hues)
            AddItem(new PlateHelm() { Name = "Garnet-Crested Commander’s Helm", Hue = 0x972 });
            AddItem(new StuddedChest() { Name = "Qasarian Ruby Guard Hauberk", Hue = 0x486 });
            AddItem(new LeatherArms() { Name = "Sand-Scoured Bracers of Redemption", Hue = 0x967 });
            AddItem(new PlateGloves() { Name = "Ironclasp Gauntlets of Valor", Hue = 0xA45 });
            AddItem(new PlateLegs() { Name = "Marching Greaves of the Exile", Hue = 0x830 });
            AddItem(new Cloak() { Name = "Mantle of the Desert Vigil", Hue = 0x21F });
            AddItem(new BodySash() { Name = "Sash of Garnet Loyalty", Hue = 0xA10 });
            AddItem(new Sandals() { Name = "Scorpionhide Patrol Sandals", Hue = 0x754 });

            AddItem(new Broadsword() { Name = "Redemption’s Edge", Hue = 0xA10 });
            AddItem(new BashingShield() { Name = "Qasarian Officer’s Shield", Hue = 0x486 });

            HairItemID = 0x203B; // Long hair
            HairHue = 0x6C4; // Black with crimson highlight

            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public CommanderShiraAlGarnet(Serial serial) : base(serial) { }

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
