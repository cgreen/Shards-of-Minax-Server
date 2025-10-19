/*
 * Scripts/Custom/DialogueSystem/OmarAlOnyx.cs
 * Dialogue-enabled, unique outfit, Qasaria lore, arena questline.
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
    [CorpseName("the corpse of Omar al-Onyx")]
    public class OmarAlOnyx : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static OmarAlOnyx()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "OmarAlOnyx.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public OmarAlOnyx()
            : base(AIType.AI_Melee, FightMode.None, 12, 1, 0.3, 0.6)
        {
            Name = "Omar al-Onyx";
            Title = "the Black Onyx Warlord";
            Body = 0x190; // Human male
            Hue = 0x839; // Deep bronze

            // Custom arena warlord outfit, all named and hued
            AddItem(new PlateHelm() { Name = "Helm of the Night Jackal", Hue = 0x497 });
            AddItem(new PlateChest() { Name = "Arena Lord's Blackened Breastplate", Hue = 0x455 });
            AddItem(new PlateArms() { Name = "Bracers of Unyielding Valor", Hue = 0x665 });
            AddItem(new PlateGloves() { Name = "Mercenary's Iron Grip", Hue = 0x901 });
            AddItem(new PlateLegs() { Name = "Greaves of the Crimson Dunes", Hue = 0x4B1 });
            AddItem(new BodySash() { Name = "Sash of the Blood Games", Hue = 0x21D });
            AddItem(new Cloak() { Name = "Cloak of Onyx Authority", Hue = 0x0C4 });
            AddItem(new Boots() { Name = "Gladiator's Sandwalkers", Hue = 0x842 });

            // Iconic weapon: Heavy gladiatorial blade
            AddItem(new LargeBattleAxe() { Name = "Champion’s Bloodletter", Hue = 0x2A2 });

            HairItemID = 0x203C; // short hair
            HairHue = 0x455; // black
            FacialHairItemID = 0x2031; // full beard
            FacialHairHue = 0x47F;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public OmarAlOnyx(Serial serial) : base(serial) { }

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
