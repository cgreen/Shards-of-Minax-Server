/*
 * Scripts/Custom/DialogueSystem/TomaDewhands.cs
 * Data-driven dialogue, custom outfit, Verdant Tribes lore.
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
    [CorpseName("the corpse of Toma Dewhands")]
    public class TomaDewhands : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static TomaDewhands()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "TomaDewhands.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public TomaDewhands()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Toma Dewhands";
            Title = "the Caretaker of the Children";
            Body = 0x191; // Human female
            Hue = 0x840;

            // Verdant Tribes, gentle forest attire
            AddItem(new FancyDress() { Name = "Leaf-Spun Caretaker's Gown", Hue = 0x59B });
            AddItem(new BodySash() { Name = "Verdant Spirit Sash", Hue = 0x597 });
            AddItem(new Sandals() { Name = "Forest-Soft Sandals", Hue = 0x712 });
            AddItem(new Cloak() { Name = "Shawl of Gentle Spring", Hue = 0x845 });
            AddItem(new FlowerGarland() { Name = "Garland of Comforting Blossoms", Hue = 0x482 });

            HairItemID = 0x203C; // medium hair
            HairHue = 0x46A;     // light brown
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public TomaDewhands(Serial serial) : base(serial) { }

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
