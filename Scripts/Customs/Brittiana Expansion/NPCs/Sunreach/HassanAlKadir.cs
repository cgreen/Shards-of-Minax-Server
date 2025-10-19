/*
 * Scripts/Custom/DialogueSystem/HassanAlKadir.cs
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
    [CorpseName("the corpse of Hassan Al-Kadir")]
    public class HassanAlKadir : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static HassanAlKadir()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "HassanAlKadir.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public HassanAlKadir()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Hassan Al-Kadir";
            Title = "the Desert Scholar";
            Body = 0x190; // Human male
            Hue = 0x841;  // Slightly tanned

            // Lore-rich outfit pieces
            AddItem(new Robe() { Name = "Sandweave Scholar’s Robe", Hue = 0x1BB });
            AddItem(new BodySash() { Name = "Sash of Forgotten Lore", Hue = 0x973 });
            AddItem(new FeatheredHat() { Name = "Turban of the Ancient Sun", Hue = 0x847 });
            AddItem(new Sandals() { Name = "Desert Wanderer’s Sandals", Hue = 0x964 });
            AddItem(new LeatherGloves() { Name = "Archivist’s Gloves", Hue = 0x97B });
            AddItem(new QuarterStaff() { Name = "Staff of Sifting Sands", Hue = 0x845 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x455; // dark
            FacialHairItemID = 0x203F; // full beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public HassanAlKadir(Serial serial) : base(serial) { }

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
