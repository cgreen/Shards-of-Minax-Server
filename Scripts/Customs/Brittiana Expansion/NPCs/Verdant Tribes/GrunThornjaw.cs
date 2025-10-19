/*
 * Scripts/Custom/DialogueSystem/GrunThornjaw.cs
 * Verdant Blacksmith; interactive dialogue, rage control quest, tribal lore.
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
    [CorpseName("the corpse of Grun Thornjaw")]
    public class GrunThornjaw : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static GrunThornjaw()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "GrunThornjaw.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public GrunThornjaw()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Grun Thornjaw";
            Title = "the Reformed Berserker";
            Body = 0x190; // Human male
            Hue = 0x840;

            // Outfit: rugged, tribal, with bone and leather
            AddItem(new BoneHelm() { Name = "Mask of the Ashen Forge", Hue = 0x83F });
            AddItem(new StuddedChest() { Name = "Studded Leather Chest", Hue = 0x839 });
            AddItem(new LeatherArms() { Name = "Bone-Grafted Bracers", Hue = 0x847 });
            AddItem(new LeatherGloves() { Name = "Crafter's Gauntlets", Hue = 0x835 });
            AddItem(new LeatherLegs() { Name = "Verdant Smith's Greaves", Hue = 0x842 });
            AddItem(new HalfApron() { Name = "Smithing Apron", Hue = 0x97A });
            AddItem(new Sandals() { Name = "Soot-Stained Sandals", Hue = 0x422 });

            HairItemID = 0x203C; // short hair
            HairHue = 0x453;
            FacialHairItemID = 0x203F; // beard
            FacialHairHue = 0x453;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public GrunThornjaw(Serial serial) : base(serial) { }

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
