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
    [CorpseName("the remains of Kaelis the Outcast")]
    public class KaelisTheOutcast : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static KaelisTheOutcast()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "KaelisTheOutcast.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public KaelisTheOutcast()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kaelis the Outcast";
            Title = "Exile of the Fractured Isle";
            Body = 0x190; // Human male
            Hue = 0x47E; // Pale blue, hints of arcane exposure

            // Unique outfit
            AddItem(new Robe() { Name = "Tattered Azure Channeler’s Robe", Hue = 0x482 });
            AddItem(new HoodedShroudOfShadows() { Name = "Sundered Shroud of the Fractured Mind", Hue = 0x497 });
            AddItem(new LeatherGloves() { Name = "Conductive Fingerwrappings", Hue = 0x4F1 });
            AddItem(new Sandals() { Name = "Dusty Shardwalker Sandals", Hue = 0x47E });
            AddItem(new BodySash() { Name = "Cincture of Forbidden Wisdom", Hue = 0x516 });
            AddItem(new MageWand() { Name = "Crackling Resonant Wand", Hue = 0x4F2 });

            HairItemID = 0x203B; // Messy hair
            HairHue = 0x47D;
            FacialHairItemID = 0x204B; // Wild beard
            FacialHairHue = 0x47D;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public KaelisTheOutcast(Serial serial) : base(serial) { }

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
