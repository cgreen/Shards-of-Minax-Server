/*
 * Scripts/Custom/DialogueSystem/ThendrilQuillforge.cs
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
    [CorpseName("the corpse of Thendril Quillforge")]
    public class ThendrilQuillforge : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ThendrilQuillforge()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ThendrilQuillforge.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ThendrilQuillforge()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Thendril Quillforge";
            Title = "the Alchemic Visionary";
            Body = 0x190; // Human male
            Hue = 0x474;

            // Unique, lore-rich outfit pieces
            AddItem(new WizardsHat() { Name = "Transmuter’s Philtered Hat", Hue = 0x47C });
            AddItem(new Robe() { Name = "Robe of Sublime Distillation", Hue = 0x515 });
            AddItem(new BodySash() { Name = "Sash of Elemental Regret", Hue = 0xB70 });
            AddItem(new LeatherGloves() { Name = "Gloves of Mercurial Peril", Hue = 0x481 });
            AddItem(new HalfApron() { Name = "Apron of Stubborn Stains", Hue = 0x484 });
            AddItem(new Boots() { Name = "Boots of Crystalline Resonance", Hue = 0x497 });
            AddItem(new GnarledStaff() { Name = "Catalytic Infusion Rod", Hue = 0xAFA });

            HairItemID = 0x2048; // wild short hair
            HairHue = 0x481; // blue-tinged gray
            FacialHairItemID = 0x203F; // bushy beard
            FacialHairHue = 0x481;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public ThendrilQuillforge(Serial serial) : base(serial) { }

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
