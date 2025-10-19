/*
 * Scripts/Custom/DialogueSystem/MiraKess_CloakOfTheSpire.cs
 * Espionage master, intricate dialogue, Aerilon intrigue.
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
    [CorpseName("the corpse of Mira Kess")]
    public class MiraKess_CloakOfTheSpire : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MiraKess_CloakOfTheSpire()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MiraKess_CloakOfTheSpire.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MiraKess_CloakOfTheSpire()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Mira Kess";
            Title = "Cloak of the Spire";
            Body = 0x191; // Human female
            Hue = 0x482;  // Pale, almost blue-tinged skin

            // Unique, lore-rich outfit pieces
            AddItem(new WizardsHat() { Name = "Nightveil Hood of Sussurus", Hue = 0x455 });
            AddItem(new FancyShirt() { Name = "Shirt of Stolen Whispers", Hue = 0x46E });
            AddItem(new LeatherNinjaJacket() { Name = "Gloamsilk Jerkin of the Cloak", Hue = 0x497 });
            AddItem(new BodySash() { Name = "Sash of Trust’s Undoing", Hue = 0xB2A });
            AddItem(new Cloak() { Name = "Shadowweave Drape of Paranoia", Hue = 0x1F8 });
            AddItem(new Skirt() { Name = "Conspirator’s Skirt of Midnight Petals", Hue = 0x4F3 });
            AddItem(new NinjaTabi() { Name = "Steps of the Sly", Hue = 0x9C2 });
            AddItem(new LeatherGloves() { Name = "Hands of Silent Schemes", Hue = 0x51D });
            AddItem(new MagicWand() { Name = "Listening Rod", Hue = 0x51C });

            HairItemID = 0x2044; // ponytail
            HairHue = 0x497;     // Black-blue hair
            FacialHairItemID = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public MiraKess_CloakOfTheSpire(Serial serial) : base(serial) { }

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
