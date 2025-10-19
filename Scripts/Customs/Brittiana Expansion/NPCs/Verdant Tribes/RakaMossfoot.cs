/*
 * Scripts/Custom/DialogueSystem/RakaMossfoot.cs
 * Verdant Tribes mushroom-brewer and questgiver.
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
    [CorpseName("the remains of Raka Mossfoot")]
    public class RakaMossfoot : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static RakaMossfoot()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "RakaMossfoot.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public RakaMossfoot()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Raka Mossfoot";
            Title = "the Mushroom Brewer";
            Body = 0x191; // Human female
            Hue = 0x840; // earthy green

            // Outfit: Fungi-themed, herbalist look
            AddItem(new FlowerGarland() { Name = "Crown of Moss and Spores", Hue = 0x5E4 });
            AddItem(new Robe() { Name = "Mushroom Weaver's Robe", Hue = 0x594 });
            AddItem(new Sandals() { Name = "Mud-Spattered Sandals", Hue = 0x598 });
            AddItem(new BodySash() { Name = "Pouch of Dried Spores", Hue = 0x8A5 });
            AddItem(new LeatherGloves() { Name = "Gloves of Soft Rot", Hue = 0x8B3 });
            AddItem(new GnarledStaff() { Name = "Sporewood Staff", Hue = 0x590 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x497; // mossy brown
            FacialHairItemID = 0x0000; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public RakaMossfoot(Serial serial) : base(serial) { }

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
