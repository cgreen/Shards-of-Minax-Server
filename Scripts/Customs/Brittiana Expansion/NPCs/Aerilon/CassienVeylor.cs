/*
 * Scripts/Custom/DialogueSystem/CassienVeylor.cs
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
    [CorpseName("the corpse of Inquisitor Cassien Veylor")]
    public class CassienVeylor : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static CassienVeylor()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "CassienVeylor.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public CassienVeylor()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Cassien Veylor";
            Title = "Inquisitor of the Arcane Tribunal";
            Body = 0x190; // Human male
            Hue = 0x466;

            // Unique, lore-rich outfit pieces
            AddItem(new WizardsHat() { Name = "Judicator’s Cerulean Cowl", Hue = 0x8C7 });
            AddItem(new Robe() { Name = "Mantle of Relentless Inquiry", Hue = 0x9C4 });
            AddItem(new LeatherGloves() { Name = "Magistrate’s Grasp", Hue = 0x4A8 });
            AddItem(new BodySash() { Name = "Sash of Severed Oaths", Hue = 0xB28 });
            AddItem(new Cloak() { Name = "Tribunal’s Unseen Veil", Hue = 0x497 });
            AddItem(new Sandals() { Name = "Boots of Iron Judgment", Hue = 0x515 });
            AddItem(new PlateGorget() { Name = "Gorget of Arcane Probity", Hue = 0x835 });
            AddItem(new MageWand() { Name = "Wand of Testimony", Hue = 0x80E });

            HairItemID = 0x2048; // long, swept hair
            HairHue = 0x44E; // dark steel blue
            FacialHairItemID = 0x203E; // goatee
            FacialHairHue = 0x47D; // frosted grey

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public CassienVeylor(Serial serial) : base(serial) { }

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
