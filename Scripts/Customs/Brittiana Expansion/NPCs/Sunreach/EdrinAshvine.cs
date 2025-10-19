/*
 * Scripts/Custom/DialogueSystem/EdrinAshvine.cs
 * Data-driven dialogue, custom outfit, Sunreach lore.
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
    [CorpseName("the corpse of Edrin Ashvine")]
    public class EdrinAshvine : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static EdrinAshvine()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "EdrinAshvine.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public EdrinAshvine()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Edrin Ashvine";
            Title = "the Shipwright-Inventor";
            Body = 0x190; // Human male
            Hue = 0x83F8; // Slightly tanned

            // Distinctive inventor/shipwright outfit
            AddItem(new Shirt() { Name = "Oiled Canvas Tunic", Hue = 0x59C });
            AddItem(new FullApron() { Name = "Tool-studded Apron", Hue = 0x847 });
            AddItem(new ShortPants() { Name = "Grease-Splattered Trousers", Hue = 0x899 });
            AddItem(new Sandals() { Name = "Salt-Stained Sandals", Hue = 0x973 });
            AddItem(new FeatheredHat() { Name = "Windswept Feathers of Aerilon", Hue = 0x5B5 });
            AddItem(new LeatherGloves() { Name = "Gloves of the Crystalwright", Hue = 0x514 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x47F; // wild silver hair

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public EdrinAshvine(Serial serial) : base(serial) { }

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
