/*
 * Scripts/Custom/DialogueSystem/DjalilTheGlassmaker.cs
 * Data-driven dialogue, unique glass artisan outfit, Qasaria/Desert Ancients lore.
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
    [CorpseName("the remains of Djalil the Glassmaker")]
    public class DjalilTheGlassmaker : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static DjalilTheGlassmaker()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "DjalilTheGlassmaker.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public DjalilTheGlassmaker()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Djalil";
            Title = "the Glassmaker";
            Body = 0x190; // Human male
            Hue = 0x83E;

            // Unique, lore-rich outfit
            AddItem(new Robe() { Name = "Robes of the Desert Ancients", Hue = 0xB97 }); // Golden-sand silk with mirrored trim
            AddItem(new BodySash() { Name = "Sash of Prismatic Hues", Hue = 0x482 }); // Shifts color in light
            AddItem(new HoodedShroudOfShadows() { Name = "Hood of Reflective Whispers", Hue = 0x47E }); // Opalescent, glass-like
            AddItem(new Sandals() { Name = "Sandals of Shifting Mirage", Hue = 0x46B }); // Iridescent blue-green
            AddItem(new LeatherGloves() { Name = "Gloves of the Furnace Spirit", Hue = 0xB42 }); // Sun-baked clay orange
            AddItem(new HalfApron() { Name = "Glassblower's Ember Apron", Hue = 0x501 }); // Smoke-grey, with shards sewn in
            AddItem(new GnarledStaff() { Name = "Scepter of Liquid Light", Hue = 0x47C }); // Clear crystal glass, glowing faintly

            HairItemID = 0x203C; // Short curly
            HairHue = 0x455; // Bronze-gold

            FacialHairItemID = 0x204B; // Short beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public DjalilTheGlassmaker(Serial serial) : base(serial) { }

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
