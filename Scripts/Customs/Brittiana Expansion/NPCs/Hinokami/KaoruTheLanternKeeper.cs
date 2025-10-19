/*
 * Scripts/Custom/DialogueSystem/KaoruTheLanternKeeper.cs
 * Data-driven dialogue, custom Tokuno-inspired outfit, spiritual lore.
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
    [CorpseName("the corpse of Kaoru the Lantern Keeper")]
    public class KaoruTheLanternKeeper : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static KaoruTheLanternKeeper()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "KaoruTheLanternKeeper.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public KaoruTheLanternKeeper()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kaoru the Lantern Keeper";
            Title = "Priestess of Amateru";
            Body = 0x191; // Human female
            Hue = 0x481;

            // Outfit: elegant, spiritual, Tokuno-inspired
            AddItem(new FemaleKimono() { Name = "Robes of Sunrise Devotion", Hue = 0x47E });
            AddItem(new FlowerGarland() { Name = "Crown of Blossoms", Hue = 0x482 });
            AddItem(new Obi() { Name = "Sash of Lantern Light", Hue = 0x2B0 });
            AddItem(new Sandals() { Name = "Pilgrim’s Step", Hue = 0x1B4 });
            AddItem(new Lantern() { Name = "Sacred Lantern of Amateru", Hue = 0x481 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x482; // dark chestnut
            FacialHairItemID = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public KaoruTheLanternKeeper(Serial serial) : base(serial) { }

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
