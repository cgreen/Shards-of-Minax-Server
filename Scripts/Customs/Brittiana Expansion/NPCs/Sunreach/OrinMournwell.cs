/*
 * Scripts/Custom/DialogueSystem/OrinMournwell.cs
 * Data-driven dialogue, custom outfit, graveyard necromancer lore for Sunreach.
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
    [CorpseName("the corpse of Orin Mournwell")]
    public class OrinMournwell : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static OrinMournwell()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "OrinMournwell.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public OrinMournwell()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Orin Mournwell";
            Title = "the Graveyard Keeper";
            Body = 0x190; // Human male
            Hue = 0x83F8; // Pale

            // Outfit: somber, occult, "necromantic gravekeeper"
            AddItem(new DeathRobe() { Name = "Threadbare Mourning Robe", Hue = 0x497 }); // Dark grey/black
            AddItem(new HoodedShroudOfShadows() { Name = "Graverobber’s Hood", Hue = 0x455 });
            AddItem(new Sandals() { Name = "Funeral Sandals", Hue = 0x1BB });
            AddItem(new BodySash() { Name = "Sash of Ashen Secrets", Hue = 0x83F8 });
            AddItem(new LeatherGloves() { Name = "Pallbearer’s Gloves", Hue = 0x497 });

            // Weapon: Necromancer’s Staff
            AddItem(new NecromancersStaff() { Name = "Wormwood Staff", Hue = 0x483 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x455; // ashen/dull brown
            FacialHairItemID = 0x203E; // medium beard
            FacialHairHue = 0x455;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public OrinMournwell(Serial serial) : base(serial) { }

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
