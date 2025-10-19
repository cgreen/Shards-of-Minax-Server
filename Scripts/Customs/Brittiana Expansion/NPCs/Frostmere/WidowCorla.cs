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
    [CorpseName("the corpse of Widow Corla")]
    public class WidowCorla : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static WidowCorla()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "WidowCorla.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public WidowCorla()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Widow Corla";
            Title = "the Gravekeeper of Frostmere";
            Body = 0x191; // Human female
            Hue = 0x486;

            AddItem(new HoodedShroudOfShadows() { Name = "Moonfrost Shroud", Hue = 0x482 });
            AddItem(new PlainDress() { Name = "Lakewind Mourning Dress", Hue = 0x47F });
            AddItem(new Cloak() { Name = "Pale Mist Veil", Hue = 0x47E });
            AddItem(new Sandals() { Name = "Fishscale Sandals", Hue = 0x480 });
            AddItem(new HalfApron() { Name = "Ceremonial Fishgut Apron", Hue = 0x47D });
            AddItem(new BodySash() { Name = "Spirit-Binding Sash", Hue = 0x495 });

            HairItemID = 0x203C;
            HairHue = 0x3E2;
            // Optionally: Add a lantern or custom staff
            AddItem(new CampingLanturn() { Name = "Grave Lantern", Hue = 0x490 });

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public WidowCorla(Serial serial) : base(serial) { }

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
