/*
 * Scripts/Custom/DialogueSystem/BrotherLoric.cs
 * Data-driven dialogue, custom outfit, Yew refugee shrine lore.
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
    [CorpseName("the corpse of Brother Loric")]
    public class BrotherLoric : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static BrotherLoric()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "BrotherLoric.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public BrotherLoric()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.1, 0.2)
        {
            Name = "Brother Loric";
            Title = "missionary of Yew";
            Body = 0x190; // Human male
            Hue = 0x83F; // Pale

            // Humble, monastic outfit
            AddItem(new MonkRobe() { Name = "Robe of Humble Service", Hue = 0x7E4 });
            AddItem(new Sandals() { Name = "Simple Sandals", Hue = 0x47F });
            AddItem(new BodySash() { Name = "Sash of the Compassionate", Hue = 0x47D });
            AddItem(new WoodenShield() { Name = "Icon of Justice", Hue = 0x844 });
            AddItem(new ShepherdsCrook() { Name = "Staff of Sanctuary", Hue = 0x59B });

            HairItemID = 0x203C; // short hair
            HairHue = 0x47F; // brown
            FacialHairItemID = 0x2041; // trimmed beard
            FacialHairHue = 0x47F;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            // No combat loot; Brother Loric is a non-combatant questgiver.
        }

        public BrotherLoric(Serial serial) : base(serial) { }

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
