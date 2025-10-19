/*
 * Scripts/Custom/DialogueSystem/AlessaDawnspire.cs
 * Paladin resistance leader, sabotage quest, Sunreach lore.
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
    [CorpseName("the fallen paladin")]
    public class AlessaDawnspire : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static AlessaDawnspire()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "AlessaDawnspire.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public AlessaDawnspire()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Alessa Dawnspire";
            Title = "aspiring paladin";
            Body = 0x191; // Human female
            Hue = 0x468;

            // Outfit: Unconventional, but evokes a bold, heroic, and slightly secretive paladin
            AddItem(new PlateChest() { Name = "Paladin's Breastplate of Dawn", Hue = 0x482 });
            AddItem(new LeatherArms() { Name = "Bracers of the Hidden Light", Hue = 0x455 });
            AddItem(new LeatherLegs() { Name = "Boots of Quiet Resolve", Hue = 0x466 });
            AddItem(new Cloak() { Name = "Cloak of Defiance", Hue = 0x497 });
            AddItem(new BodySash() { Name = "Sash of Resistance", Hue = 0xB1A });
            AddItem(new Longsword() { Name = "Saboteur’s Blade", Hue = 0x47F });

            HairItemID = 0x203B; // long hair
            HairHue = 0x47F; // golden brown
            FacialHairItemID = 0x0000; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public AlessaDawnspire(Serial serial) : base(serial) { }

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
