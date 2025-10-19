/*
 * Scripts/Custom/DialogueSystem/SultanRafiqAlRuby.cs
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
    [CorpseName("the body of Sultan Rafiq al-Ruby")]
    public class SultanRafiqAlRuby : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static SultanRafiqAlRuby()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "SultanRafiqAlRuby.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public SultanRafiqAlRuby()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Sultan Rafiq al-Ruby";
            Title = "The Ruby Prince";
            Body = 0x190; // Human male
            Hue = 0x83F; // Slightly sun-burnished

            // Unique, lore-rich outfit
            AddItem(new Circlet() { Name = "Imperial Ruby Circlet of Command", Hue = 0x66D });
            AddItem(new FancyShirt() { Name = "Embroidered Shirt of the Crimson Dunes", Hue = 0x21 });
            AddItem(new FullApron() { Name = "Sash of the Desert Cavalier", Hue = 0x489 });
            AddItem(new Robe() { Name = "Regal Robe of Qasarian Sunset", Hue = 0x485 });
            AddItem(new Cloak() { Name = "Mantle of Desert Resolve", Hue = 0x21E });
            AddItem(new PlateGloves() { Name = "Gauntlets of Oathbound Steel", Hue = 0x96A });
            AddItem(new PlateLegs() { Name = "Greaves of the Ruby Horsemen", Hue = 0x66D });
            AddItem(new Boots() { Name = "Sandwalkers of the South Wind", Hue = 0x6F8 });
            AddItem(new Scepter() { Name = "Sultan’s Scepter of Rubicund Authority", Hue = 0x21 });

            HairItemID = 0x203B; // shoulder-length hair
            HairHue = 0x455; // dark with hints of red
            FacialHairItemID = 0x204C; // neatly groomed beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public SultanRafiqAlRuby(Serial serial) : base(serial) { }

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
