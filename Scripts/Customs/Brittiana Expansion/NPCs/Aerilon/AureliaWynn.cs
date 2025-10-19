/*
 * Scripts/Custom/DialogueSystem/AureliaWynn.cs
 * Data-driven dialogue, custom outfit, Aerilon lore.
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
    [CorpseName("the corpse of Aurelia Wynn")]
    public class AureliaWynn : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static AureliaWynn()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "AureliaWynn.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public AureliaWynn()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Aurelia Wynn";
            Title = "Keeper of the Glimmer Garden";
            Body = 0x191; // Human female
            Hue = 0x59B; // Subtle green-tinted skin

            // Unique, lore-rich outfit pieces
            AddItem(new FlowerGarland() { Name = "Halo of Verdant Serenity", Hue = 0x59B });
            AddItem(new FancyDress() { Name = "Glimmerpetal Gown", Hue = 0x495 });
            AddItem(new ElvenBoots() { Name = "Mossstep Boots", Hue = 0x59A });
            AddItem(new BodySash() { Name = "Sash of Blossoming Dusk", Hue = 0x4FD });
            AddItem(new Cloak() { Name = "Mantle of Sylvan Mists", Hue = 0x482 });
            AddItem(new LeatherGloves() { Name = "Gardener’s Embrace", Hue = 0x4A7 });

            HairItemID = 0x203C; // long flowing hair
            HairHue = 0x481; // pastel lavender
            FacialHairItemID = 0x0000; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public AureliaWynn(Serial serial) : base(serial) { }

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
