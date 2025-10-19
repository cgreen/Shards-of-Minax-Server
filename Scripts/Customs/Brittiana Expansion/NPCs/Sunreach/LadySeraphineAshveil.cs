/*
 * Scripts/Custom/DialogueSystem/LadySeraphineAshveil.cs
 * Data-driven dialogue, custom pirate outfit, Sunreach/Minax lore.
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
    [CorpseName("the corpse of Lady Seraphine Ashveil")]
    public class LadySeraphineAshveil : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static LadySeraphineAshveil()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "LadySeraphineAshveil.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public LadySeraphineAshveil()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Lady Seraphine Ashveil";
            Title = "the Pirate Duchess";
            Body = 0x191; // Human female
            Hue = 0x466;

            // Unique, notorious pirate outfit
            AddItem(new FancyDress() { Name = "Crimson Corsair Gown", Hue = 0x21 });
            AddItem(new Cloak() { Name = "Ashveil's Midnight Cloak", Hue = 0x455 });
            AddItem(new TricorneHat() { Name = "Jeweled Pirate Tricorne", Hue = 0x497 });
            AddItem(new BodySash() { Name = "Sash of Silver Coins", Hue = 0x481 });
            AddItem(new Boots() { Name = "Black Buccaneer's Boots", Hue = 0x497 });
            AddItem(new LeatherGloves() { Name = "Smuggler's Gloves", Hue = 0x1C0 });
            AddItem(new Cutlass() { Name = "Ashveil's Silvered Cutlass", Hue = 0x47E });

            HairItemID = 0x2047; // wavy long
            HairHue = 0x47E; // silver hair
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public LadySeraphineAshveil(Serial serial) : base(serial) { }

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
