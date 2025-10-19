/*
 * Scripts/Custom/DialogueSystem/MaiyaTheSpiritSinger.cs
 * Data-driven dialogue, custom outfit, musical and shamanic quirks.
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
    [CorpseName("the body of Maiya the Spirit-Singer")]
    public class MaiyaTheSpiritSinger : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MaiyaTheSpiritSinger()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MaiyaTheSpiritSinger.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MaiyaTheSpiritSinger()
            : base(AIType.AI_Healer, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Maiya";
            Title = "the Spirit-Singer";
            Body = 0x191; // Human female
            Hue = 0x83F; // Soft green/brown, tribal

            // Outfit: flowing, tribal, musical
            AddItem(new FlowerGarland() { Name = "Wreath of Whispering Blooms", Hue = 0x59B });
            AddItem(new WoodlandChest() { Name = "Shaman’s Leaf-Tunic", Hue = 0x582 });
            AddItem(new WoodlandArms() { Name = "Spiritwoven Armwraps", Hue = 0x592 });
            AddItem(new WoodlandLegs() { Name = "Earthsong Leggings", Hue = 0x5AB });
            AddItem(new Sandals() { Name = "Barefoot Sandals", Hue = 0x8A5 });
            AddItem(new BodySash() { Name = "Belt of Sacred Seeds", Hue = 0x489 });

            HairItemID = 0x203C; // Long wavy hair
            HairHue = 0x47F; // Dark brown

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public MaiyaTheSpiritSinger(Serial serial) : base(serial) { }

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
