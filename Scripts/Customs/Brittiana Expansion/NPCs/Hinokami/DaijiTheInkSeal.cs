/*
 * Scripts/Custom/DialogueSystem/DaijiTheInkSeal.cs
 * Data-driven dialogue, custom outfit, Hinokami lore.
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
    [CorpseName("the corpse of Daiji the Ink-Seal")]
    public class DaijiTheInkSeal : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static DaijiTheInkSeal()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "DaijiTheInkSeal.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public DaijiTheInkSeal()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Daiji the Ink-Seal";
            Title = "Registrar of Hinokami";
            Body = 0x190; // Human male
            Hue = 0x8A5;  // Light tan

            // Outfit: meticulous, ceremonial scribe/bureaucrat with strong Tokuno flavor
            AddItem(new MaleKimono() { Name = "Ceremonial Kimono of the Scribe", Hue = 0x47E });
            AddItem(new Obi() { Name = "Obi of Officialdom", Hue = 0x453 });
            AddItem(new Kasa() { Name = "Wide Scribe’s Kasa", Hue = 0x12B });
            AddItem(new Sandals() { Name = "Calligrapher's Sandals", Hue = 0x451 });
            AddItem(new HalfApron() { Name = "Ink-Stained Apron", Hue = 0x497 });
            AddItem(new BodySash() { Name = "Sealkeeper's Sash", Hue = 0x4A6 });

            HairItemID = 0x203C; // topknot
            HairHue = 0x455; // jet black

            // Scribe's tools
            AddItem(new CartographersPen() { Name = "Scribe's Calligraphy Brush" });
            AddItem(new MaxxiaScroll() { Name = "Scroll of Regulations" });
            AddItem(new MaxxiaScroll() { Name = "Permit Application" });

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public DaijiTheInkSeal(Serial serial) : base(serial) { }

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
