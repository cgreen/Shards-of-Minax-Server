/*
 * Scripts/Custom/DialogueSystem/DornMakel.cs
 * Gruff ex-warden, custom blacksmith outfit, Aerilon lore & unique quest.
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
    [CorpseName("the corpse of Dorn Makel")]
    public class DornMakel : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static DornMakel()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "DornMakel.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public DornMakel()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Dorn Makel";
            Title = "ex-Warden of the Outer Rim";
            Body = 0x190; // Human male
            Hue = 0x847; // Ashen, tanned skin

            // Custom war-scarred blacksmith outfit:
            AddItem(new LeatherCap() { Name = "Battered Wardhelm of the Fallen", Hue = 0x497 });
            AddItem(new SmithSmasher() { Name = "Forgemaster's Scarhammer", Hue = 0x484 });
            AddItem(new LeatherChest() { Name = "Scorched Vest of the Rim", Hue = 0x2B2 });
            AddItem(new LeatherGloves() { Name = "Charred Smith's Gauntlets", Hue = 0x966 });
            AddItem(new LeatherLegs() { Name = "Warden's Fused Greaves", Hue = 0x1BB });
            AddItem(new HalfApron() { Name = "Apron of Forges Past", Hue = 0x835 });
            AddItem(new Boots() { Name = "Sundered Ironclad Boots", Hue = 0x497 });
            AddItem(new Cloak() { Name = "Cloak of Ashen Vigil", Hue = 0x455 });

            HairItemID = 0x203C; // short hair
            HairHue = 0x966; // iron-grey
            FacialHairItemID = 0x203F; // beard
            FacialHairHue = 0x966;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public DornMakel(Serial serial) : base(serial) { }

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
