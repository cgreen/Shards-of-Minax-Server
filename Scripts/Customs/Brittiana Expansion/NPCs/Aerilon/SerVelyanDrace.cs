/*
 * Scripts/Custom/DialogueSystem/SerVelyanDrace.cs
 * Elite Skyguard commander with Aerilon-Wind heritage, quest delivery to Reptalon Scholar.
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
    [CorpseName("the corpse of Ser Velyan Drace")]
    public class SerVelyanDrace : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SerVelyanDrace()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SerVelyanDrace.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SerVelyanDrace()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ser Velyan Drace";
            Title = "Gilded Knight of the Skyguard";
            Body = 0x190; // Human male
            Hue = 0x48B;

            // Unique outfit
            AddItem(new WingedHelm { Name = "Drace's Azure Crest", Hue = 0x489 });
            AddItem(new PlateChest { Name = "Skyward Bastion", Hue = 0x4F6 });
            AddItem(new PlateArms { Name = "Stormforged Vambraces", Hue = 0x48A });
            AddItem(new PlateGloves { Name = "Grasp of the Windborne", Hue = 0x489 });
            AddItem(new PlateLegs { Name = "Boots of the Cloud Strider", Hue = 0x497 });
            AddItem(new Cloak { Name = "Mantle of Twin Allegiances", Hue = 0x1F2 });
            AddItem(new BodySash { Name = "Sash of Skyguard Oaths", Hue = 0xB2A });
            AddItem(new Broadsword { Name = "Aetherblade", Hue = 0x515 });
            AddItem(new BashingShield { Name = "Aerilon Crest Shield", Hue = 0x516 });

            HairItemID = 0x203C; // short hair
            HairHue = 0x47E; // silver-white
            FacialHairItemID = 0x2031; // full beard
            FacialHairHue = 0x47E;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public SerVelyanDrace(Serial serial) : base(serial) { }

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
