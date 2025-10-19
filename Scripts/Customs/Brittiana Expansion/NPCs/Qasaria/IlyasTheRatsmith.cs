/*
 * Scripts/Custom/DialogueSystem/IlyasTheRatsmith.cs
 * Torturer, info-broker, and Undermarket fixture of Qasaria.
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
    [CorpseName("the corpse of Ilyas the Ratsmith")]
    public class IlyasTheRatsmith : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static IlyasTheRatsmith()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "IlyasTheRatsmith.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public IlyasTheRatsmith()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ilyas the Ratsmith";
            Title = "of the Undermarket";
            Body = 0x190; // Human male
            Hue = 0x455;

            // Unique, sinister outfit (with lore-rich names and hues)
            AddItem(new HoodedShroudOfShadows() { Name = "Shroud of Muffled Screams", Hue = 0x497 });
            AddItem(new LeatherNinjaJacket() { Name = "Flayed Inquisitor’s Vest", Hue = 0x455 });
            AddItem(new LeatherNinjaPants() { Name = "Ratskin Legwraps", Hue = 0x3E2 });
            AddItem(new NinjaTabi() { Name = "Softstep Tabi of the Torturer", Hue = 0x3E1 });
            AddItem(new LeatherGloves() { Name = "Gloves of the Truth-Extractor", Hue = 0x49F });
            AddItem(new BodySash() { Name = "Sash of the Rat King", Hue = 0x48C });
            AddItem(new AssassinSpike() { Name = "The Whispering Pick", Hue = 0x497 });
            AddItem(new Bandana() { Name = "Facecloth of Old Trinsic", Hue = 0x46F });

            HairItemID = 0x2047; // short hair
            HairHue = 0x4E9; // sallow, greasy black
            FacialHairItemID = 0x203F; // short beard
            FacialHairHue = 0x4E9;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public IlyasTheRatsmith(Serial serial) : base(serial) { }

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
