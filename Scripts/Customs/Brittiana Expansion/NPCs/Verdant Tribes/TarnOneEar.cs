/*
 * Scripts/Custom/DialogueSystem/TarnOneEar.cs
 * Animal Whisperer, Verdant Tribes, interactive beast quest.
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
    [CorpseName("the corpse of Tarn One-Ear")]
    public class TarnOneEar : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static TarnOneEar()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "TarnOneEar.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public TarnOneEar()
            : base(AIType.AI_Archer, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tarn One-Ear";
            Title = "the Animal Whisperer";
            Body = 0x190; // Human male
            Hue = 0x83F; // earthy

            // Distinct outfit - tribal, practical, animalistic
            AddItem(new TribalMask() { Name = "Wolf-Bone Mask", Hue = 0x455 });
            AddItem(new LeatherDo() { Name = "Hunter's Jerkin", Hue = 0x966 });
            AddItem(new LeatherNinjaPants() { Name = "Briar-Lined Leggings", Hue = 0x966 });
            AddItem(new FurBoots() { Name = "Mossy Fur Boots", Hue = 0x839 });
            AddItem(new BodySash() { Name = "Totem Sash", Hue = 0x968 });
            AddItem(new WildStaff() { Name = "Crook of the Pack", Hue = 0x966 });

            HairItemID = 0x203C; // short, messy hair
            HairHue = 0x46F; // brown
            FacialHairItemID = 0x203E; // short beard
            FacialHairHue = 0x46F;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public TarnOneEar(Serial serial) : base(serial) { }

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
