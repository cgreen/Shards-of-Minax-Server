/*
 * Scripts/Custom/DialogueSystem/SisterRanaMoonVow.cs
 * Data-driven dialogue, custom outfit, Qasaria lore.
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
    [CorpseName("the body of Sister Rana")]
    public class SisterRanaMoonVow : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SisterRanaMoonVow()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SisterRanaMoonVow.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SisterRanaMoonVow()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Sister Rana";
            Title = "of the Moon Vow";
            Body = 0x191; // Human female
            Hue = 0x4F8; // Soft moonlit blue

            // Unique, lore-rich outfit
            AddItem(new WizardsHat() { Name = "Veil of Lunar Serenity", Hue = 0x482 });
            AddItem(new MonkRobe() { Name = "Robes of the Waxing Night", Hue = 0x47E });
            AddItem(new Cloak() { Name = "Mantle of Silver Eclipse", Hue = 0xB7B });
            AddItem(new BodySash() { Name = "Sash of Celestial Balance", Hue = 0x514 });
            AddItem(new Sandals() { Name = "Moonshadow Steps", Hue = 0xB2B });
            AddItem(new LeatherGloves() { Name = "Grips of Divinatory Grace", Hue = 0x48D });
            AddItem(new SilverNecklace() { Name = "Crescent Amulet of Moonglow", Hue = 0x47E });

            HairItemID = 0x203C; // long hair, parted
            HairHue = 0x47E; // pale silver

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public SisterRanaMoonVow(Serial serial) : base(serial) { }

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
