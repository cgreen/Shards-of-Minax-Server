/*
 * Scripts/Custom/DialogueSystem/FarahWindBorn.cs
 * Data-driven dialogue, custom outfit, Aerilon/Qasaria lore.
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
    [CorpseName("the corpse of Farah the Wind-Born")]
    public class FarahWindBorn : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static FarahWindBorn()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "FarahWindBorn.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public FarahWindBorn()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Farah";
            Title = "of the Wind-Born";
            Body = 0x191; // Human female
            Hue = 0x470;  // Wind blue-grey

            // Unique, named outfit: wind and sand motif
            AddItem(new WizardsHat() { Name = "Galecrest Circlet", Hue = 0x482 });       // Cerulean with opal shimmer
            AddItem(new Robe() { Name = "Mantle of Exiled Zephyrs", Hue = 0x8B4 });      // Pale sand-gold
            AddItem(new BodySash() { Name = "Sash of Roaring Horizons", Hue = 0x4B9 });  // Cloud blue
            AddItem(new Cloak() { Name = "Cloak of Unfettered Sky", Hue = 0x497 });      // Deep storm-grey
            AddItem(new Sandals() { Name = "Sirocco Treads", Hue = 0x991 });             // Faded gold
            AddItem(new LeatherGloves() { Name = "Gloves of Boundless Breath", Hue = 0x512 }); // Silver-white
            AddItem(new LeatherLegs() { Name = "Leggings of the Wandering Gale", Hue = 0x514 }); // Pale blue
            AddItem(new MagicWand() { Name = "Tempest Scepter", Hue = 0x48E });          // Crystaline blue staff

            HairItemID = 0x203B; // Long hair
            HairHue = 0x47E;     // Silver-white

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public FarahWindBorn(Serial serial) : base(serial) { }

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
