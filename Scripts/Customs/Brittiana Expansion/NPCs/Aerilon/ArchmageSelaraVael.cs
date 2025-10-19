/*
 * Scripts/Custom/DialogueSystem/ArchmageSelaraVael.cs
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
    [CorpseName("the corpse of Archmage Selara Vael")]
    public class ArchmageSelaraVael : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ArchmageSelaraVael()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ArchmageSelaraVael.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ArchmageSelaraVael()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Archmage Selara Vael";
            Title = "the Azure Conclave";
            Body = 0x191; // Human female
            Hue = 0x48D;

            // Unique, lore-rich outfit pieces
            AddItem(new WizardsHat() { Name = "Conclave Diadem of Azure Storms", Hue = 0x4F2 });
            AddItem(new Robe() { Name = "Aetheric Mantle of the Conclave", Hue = 0x516 });
            AddItem(new BodySash() { Name = "Sash of Candescent Insight", Hue = 0xB21 });
            AddItem(new Cloak() { Name = "Veil of Wind’s Betrayal", Hue = 0x1F2 });
            AddItem(new Sandals() { Name = "Steps of the Skyborne", Hue = 0x497 });
            AddItem(new LeatherGloves() { Name = "Grips of Spellbinding", Hue = 0x495 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x47E; // white/silver
            FacialHairItemID = 0x0000; // none
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public ArchmageSelaraVael(Serial serial) : base(serial) { }

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
