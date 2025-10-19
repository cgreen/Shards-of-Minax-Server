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
    [CorpseName("the corpse of Nyra")]
    public class NyraOfTheHollowMarsh : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static NyraOfTheHollowMarsh()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "NyraOfTheHollowMarsh.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public NyraOfTheHollowMarsh()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nyra of the Hollow Marsh";
            Title = "the Druid Exile";
            Body = 0x191; // Human female
            Hue = 0x840;

            // Outfit: all uniquely named, thematic, and colored
            AddItem(new HoodedShroudOfShadows() { Name = "Marshlight Hood", Hue = 0x482 });
            AddItem(new Robe() { Name = "Gloaming Veil", Hue = 0x497 });
            AddItem(new WoodlandBelt() { Name = "Ivywrap Sash", Hue = 0x7E8 });
            AddItem(new FurBoots() { Name = "Fenwalker Boots", Hue = 0x598 });
            AddItem(new FlowerGarland() { Name = "Moonbloom Circlet", Hue = 0x481 });
            AddItem(new ElvenShirt() { Name = "Mistweave Undergown", Hue = 0x966 });

            HairItemID = 0x203C;
            HairHue = 0x8A5; // Moss-green
            // No facial hair

            AddItem(new MysticStaff() { Name = "Wand of Hollowroot", Hue = 0x8AD });

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public NyraOfTheHollowMarsh(Serial serial) : base(serial) { }

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
