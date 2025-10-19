/*
 * Scripts/Custom/DialogueSystem/NyssaCoil.cs
 * Data-driven dialogue, custom dream-infused outfit, Aerilon psychic lore.
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
    [CorpseName("the frail form of Nyssa Coil")]
    public class NyssaCoil : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static NyssaCoil()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "NyssaCoil.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public NyssaCoil()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nyssa Coil";
            Title = "the Mindweaver";
            Body = 0x191; // Human female
            Hue = 0x47E; // Ethereal white

            // Unique dreamlike outfit
            AddItem(new WizardsHat() { Name = "Hat of Waking Echoes", Hue = 0x488 });
            AddItem(new Robe() { Name = "Vestments of the Somnambulist", Hue = 0x482 });
            AddItem(new BodySash() { Name = "Ribbon of Forgotten Names", Hue = 0xB4B });
            AddItem(new Cloak() { Name = "Veil of Lucid Shadows", Hue = 0x3FE });
            AddItem(new Sandals() { Name = "Footfalls of the Dreambound", Hue = 0x490 });
            AddItem(new LeatherGloves() { Name = "Grasps of Reverie", Hue = 0x497 });

            // Psychedelic hair
            HairItemID = 0x203C; // wavy hair
            HairHue = 0x1B7; // opaline blue
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public NyssaCoil(Serial serial) : base(serial) { }

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
