/*
 * Scripts/Custom/DialogueSystem/MidoriHerbWitch.cs
 * Data-driven dialogue, custom outfit, Hinokami lore, tanuki familiar.
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
    [CorpseName("the corpse of Midori the Herb-Witch")]
    public class MidoriHerbWitch : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MidoriHerbWitch()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MidoriHerbWitch.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MidoriHerbWitch()
            : base(AIType.AI_Healer, FightMode.None, 8, 1, 0.1, 0.2)
        {
            Name = "Midori";
            Title = "the Herb-Witch";
            Body = 0x191; // Human female
            Hue = 0x83E;

            // Unique, wild herbalist outfit—Hinokami style, mystical touch
            AddItem(new FemaleKimono() { Name = "Kimono of Verdant Wisdom", Hue = 0x7C5 });
            AddItem(new Obi() { Name = "Obi of Moonlit Dew", Hue = 0x481 });
            AddItem(new ClothNinjaHood() { Name = "Mossy Hood", Hue = 0x847 });
            AddItem(new Sandals() { Name = "Forest-Strider Sandals", Hue = 0x59B });
            AddItem(new FlowerGarland() { Name = "Garland of Wild Herbs", Hue = 0x57E });
            AddItem(new HalfApron() { Name = "Stained Herbalist's Apron", Hue = 0x529 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x589; // deep green
            FacialHairItemID = 0x0000; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public MidoriHerbWitch(Serial serial) : base(serial) { }

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
