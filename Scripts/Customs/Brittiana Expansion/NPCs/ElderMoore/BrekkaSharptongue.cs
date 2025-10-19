/*
 * Scripts/Custom/DialogueSystem/BrekkaSharptongue.cs
 * NPC: The Unwelcome Watch
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
    [CorpseName("the corpse of Brekka Sharptongue")]
    public class BrekkaSharptongue : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BrekkaSharptongue()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BrekkaSharptongue.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BrekkaSharptongue()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Brekka Sharptongue";
            Title = "the Unwelcome Watch";
            Body = 0x191; // Human female
            Hue = 0x838;

            // Outfit - each piece has a story
            AddItem(new StuddedChest() { Name = "Ironbound Jerkin", Hue = 0x969 }); // battered, iron-grey
            AddItem(new StuddedArms() { Name = "Moorwalker Guards", Hue = 0x845 }); // muddy brown
            AddItem(new LeatherGloves() { Name = "Halric's Old Gauntlets", Hue = 0x497 }); // given by Halric
            AddItem(new HalfApron() { Name = "Soot-Stained Half-Apron", Hue = 0x53E }); // from working the forges
            AddItem(new LongPants() { Name = "Scrapper's Breeches", Hue = 0x45E }); // faded green
            AddItem(new Boots() { Name = "Swamp-Tread Boots", Hue = 0x96D }); // waterproofed, dark
            AddItem(new Bandana() { Name = "Bloodstripe Headband", Hue = 0x21 }); // deep red stripe, her old bandit mark
            AddItem(new Cloak() { Name = "Eldermoor Sentry Cloak", Hue = 0x455 }); // dark blue-grey, local militia

            HairItemID = 0x203C; // short, practical hair
            HairHue = 0x497;

            // Custom loot/traits
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public BrekkaSharptongue(Serial serial) : base(serial) { }

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
