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
    [CorpseName("the remains of Salia Moontide")]
    public class SaliaMoontide : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SaliaMoontide()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SaliaMoontide.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SaliaMoontide()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Salia Moontide";
            Title = "Azure Engineer";
            Body = 0x191; // Human female
            Hue = 0x485;  // Soft blue

            // Unique Lore Outfit
            AddItem(new ElvenShirt() { Name = "Moontide's Aetherweave Tunic", Hue = 0x515 }); // Luminous silver-blue
            AddItem(new ElvenPants() { Name = "Crystalfall Leggings", Hue = 0x489 }); // Deep azure
            AddItem(new BodySash() { Name = "Girdle of Conductive Filaments", Hue = 0x48C }); // Vibrant electric blue
            AddItem(new HoodedShroudOfShadows() { Name = "Arcanist's Cowl of Vigilance", Hue = 0x47E }); // Pale lavender
            AddItem(new ElvenBoots() { Name = "Skyforged Boots", Hue = 0x493 }); // Shimmering steel-grey
            AddItem(new ArtificerWand() { Name = "Resonance Calibrator", Hue = 0x515 }); // Matching staff/wand

            HairItemID = 0x203C;
            HairHue = 0x466;
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public SaliaMoontide(Serial serial) : base(serial) { }

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
