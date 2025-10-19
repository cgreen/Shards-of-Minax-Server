/*
 * Scripts/Custom/DialogueSystem/InariClayEater.cs
 * Mute orphan NPC. Hinokami lore. Interactive clay/quest branch.
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
    [CorpseName("the clay-smeared body of Inari")]
    public class InariClayEater : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static InariClayEater()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "InariClayEater.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public InariClayEater()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.1, 0.2)
        {
            Name = "Inari";
            Title = "the Clay-Eater";
            Body = 0x190; // Human male
            Hue = 0x83F;  // Earthy/tan

            // Unique, lore-rich outfit: ragged but spiritual
            AddItem(new MaleKimono() { Name = "Stained Kimono", Hue = 0x84A });
            AddItem(new Obi() { Name = "Clay-Patterned Obi", Hue = 0x964 });
            AddItem(new Waraji() { Name = "Worn Sandals", Hue = 0x96A });
            AddItem(new FlowerGarland() { Name = "Crown of Twined Grass", Hue = 0x481 });
            AddItem(new HalfApron() { Name = "Apron of Sacred Clay", Hue = 0xB97 });

            HairItemID = 0x203C; // Messy hair
            HairHue = 0x47E; // Pale/greyish, like clay
            FacialHairItemID = 0x0000;

            // Attach quirks
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public InariClayEater(Serial serial) : base(serial) { }

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
