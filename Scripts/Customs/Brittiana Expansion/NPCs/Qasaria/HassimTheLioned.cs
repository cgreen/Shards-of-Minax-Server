/*
 * Scripts/Custom/DialogueSystem/HassimTheLioned.cs
 * Data-driven dialogue, custom outfit, Qasaria arena lore.
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
    [CorpseName("the corpse of Hassim the Lioned")]
    public class HassimTheLioned : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static HassimTheLioned()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "HassimTheLioned.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public HassimTheLioned()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.3, 0.4)
        {
            Name = "Hassim the Lioned";
            Title = "Champion of the Sands";
            Body = 0x190; // Human male
            Hue = 0x845;

            // Distinctive, lore-rich arena champion attire
            AddItem(new TigerPeltHelm() { Name = "Lion's Mane of Hassim", Hue = 0xB98 });
            AddItem(new LeatherDo() { Name = "Arena-Bound Chest of Honor", Hue = 0xB65 });
            AddItem(new StuddedArms() { Name = "Brawler's Embrace", Hue = 0x972 });
            AddItem(new TigerPeltLegs() { Name = "Sandwalker Greaves", Hue = 0xB8B });
            AddItem(new LeatherGloves() { Name = "Gauntlets of the Fallen", Hue = 0x8A2 });
            AddItem(new BodySash() { Name = "Sash of Sibling Memory", Hue = 0xB25 });
            AddItem(new Sandals() { Name = "Blood-Stained Arena Sandals", Hue = 0x66D });

            // Weapon: Iconic
            AddItem(new Bardiche() { Name = "Lion's Crescent", Hue = 0x485 });

            HairItemID = 0x203C; // wild mane
            HairHue = 0x8A5;

            FacialHairItemID = 0x204B; // beard
            FacialHairHue = 0x8A5;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public HassimTheLioned(Serial serial) : base(serial) { }

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
