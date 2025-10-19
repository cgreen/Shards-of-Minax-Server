/*
 * Scripts/Custom/DialogueSystem/KelnuBrightribs.cs
 * Data-driven dialogue, custom tribal outfit, prophecy quest hook.
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
    [CorpseName("the body of Kelnu Brightribs")]
    public class KelnuBrightribs : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static KelnuBrightribs()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "KelnuBrightribs.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public KelnuBrightribs()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kelnu Brightribs";
            Title = "the Young Vision-Seeker";
            Body = 0x190; // Human male
            Hue = 0x845;  // Tanned skin

            // Outfit: tribal and youthful
            AddItem(new TribalMask() { Name = "Painted Bark Mask", Hue = 0x7B2 });
            AddItem(new FurSarong() { Name = "Fur Sarong", Hue = 0x961 });
            AddItem(new WoodlandChest() { Name = "Woven Chestguard", Hue = 0x90E });
            AddItem(new WoodlandLegs() { Name = "Leaf-Laced Leggings", Hue = 0x8A4 });
            AddItem(new Sandals() { Name = "Spirit-Walker's Sandals", Hue = 0x8AA });

            HairItemID = 0x203C; // messy, youthful
            HairHue = 0x825;     // dark brown
            FacialHairItemID = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public KelnuBrightribs(Serial serial) : base(serial) { }

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
