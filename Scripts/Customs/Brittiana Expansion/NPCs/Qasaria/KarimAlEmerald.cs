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
    [CorpseName("the corpse of Karim al-Emerald")]
    public class KarimAlEmerald : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static KarimAlEmerald()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "KarimAlEmerald.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public KarimAlEmerald()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.1, 0.2)
        {
            Name = "Karim al-Emerald";
            Title = "the Emerald Vizier";
            Body = 0x190; // Human male
            Hue = 0x839;

            // Unique, lore-rich outfit
            AddItem(new WizardsHat() { Name = "Cowl of Whispering Sands", Hue = 0x22F });
            AddItem(new Robe() { Name = "Verdant Mantle of the Emerald Court", Hue = 0x59B });
            AddItem(new BodySash() { Name = "Sash of Concealed Daggers", Hue = 0x900 });
            AddItem(new Cloak() { Name = "Cloak of Shadowed Oaths", Hue = 0x497 });
            AddItem(new Sandals() { Name = "Steps of the Silent Serpent", Hue = 0x8B5 });
            AddItem(new LeatherGloves() { Name = "Gloves of Delicate Treachery", Hue = 0x56E });
            AddItem(new StuddedArms() { Name = "Bracers of the Undermarket", Hue = 0x7D2 });
            AddItem(new WoodlandBelt() { Name = "Emerald Sigil Belt", Hue = 0x8C9 });
            AddItem(new Dagger() { Name = "Emerald-Stained Stiletto", Hue = 0x58A });

            HairItemID = 0x203C; // short hair
            HairHue = 0x455;     // dark green
            FacialHairItemID = 0x203F; // goatee
            FacialHairHue = 0x1B1;     // dark

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public KarimAlEmerald(Serial serial) : base(serial) { }

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
