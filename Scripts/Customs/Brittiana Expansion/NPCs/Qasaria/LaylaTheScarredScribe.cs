/*
 * Scripts/Custom/DialogueSystem/LaylaTheScarredScribe.cs
 * Data-driven dialogue, custom outfit, Qasaria lore.
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
    [CorpseName("the corpse of Layla the Scarred Scribe")]
    public class LaylaTheScarredScribe : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static LaylaTheScarredScribe()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "LaylaTheScarredScribe.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public LaylaTheScarredScribe()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Layla the Scarred Scribe";
            Title = "Magical Tattooist of Qasaria";
            Body = 0x191; // Human female
            Hue = 0x455; // Dusty rose/tan

            // Unique, lore-rich outfit pieces
            AddItem(new HoodedShroudOfShadows() { Name = "Hood of the Unbroken Survivor", Hue = 0x497 }); // Deep purple
            AddItem(new FullApron() { Name = "Apron of Stained Testaments", Hue = 0xB93 }); // Ink-stained tan
            AddItem(new LeatherBustierArms() { Name = "Runecarver's Armwraps", Hue = 0x475 }); // Scarred skin-color leather
            AddItem(new FancyKilt() { Name = "Kilt of Desert Scars", Hue = 0x962 }); // Faded crimson
            AddItem(new Sandals() { Name = "Footfalls of Quiet Escape", Hue = 0x46E }); // Dust brown
            AddItem(new BodySash() { Name = "Sash of Inked Endurance", Hue = 0x89B }); // Blue-black

            HairItemID = 0x203C; // short, curly hair
            HairHue = 0x4A7; // Ash black

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public LaylaTheScarredScribe(Serial serial) : base(serial) { }

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
