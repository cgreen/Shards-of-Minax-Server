/*
 * Scripts/Custom/DialogueSystem/NaokoMaskmaker.cs
 * Data-driven dialogue, custom ceremonial outfit, mask lore.
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
    [CorpseName("the corpse of Naoko the Maskmaker")]
    public class NaokoMaskmaker : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static NaokoMaskmaker()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "NaokoMaskmaker.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public NaokoMaskmaker()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Naoko the Maskmaker";
            Title = "Ceremonial Artisan";
            Body = 0x191; // Human female
            Hue = 0x83EA; // Subtle pale hue

            // Unique, lore-rich Japanese/ceremonial outfit
            AddItem(new FemaleKimono() { Name = "Kimono of Spirit Weaving", Hue = 0x482 });
            AddItem(new Obi() { Name = "Obi of Hidden Faces", Hue = 0x44F });
            AddItem(new Sandals() { Name = "Sandals of Silent Steps", Hue = 0x497 });
            AddItem(new BearMask() { Name = "Naoko's Carved Mask", Hue = 0x47E });
            AddItem(new ClothNinjaHood() { Name = "Veil of Whispered Spirits", Hue = 0x455 });

            HairItemID = 0x2046; // Topknot
            HairHue = 0x455; // Jet black

            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public NaokoMaskmaker(Serial serial) : base(serial) { }

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
