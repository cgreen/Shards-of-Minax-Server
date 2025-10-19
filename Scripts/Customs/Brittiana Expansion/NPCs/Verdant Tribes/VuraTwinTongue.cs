/*
 * Scripts/Custom/DialogueSystem/VuraTwinTongue.cs
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
    [CorpseName("the corpse of Vura Twin-Tongue")]
    public class VuraTwinTongue : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static VuraTwinTongue()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "VuraTwinTongue.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public VuraTwinTongue()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Vura Twin-Tongue";
            Title = "the Trickster Trader";
            Body = 0x191; // Human female
            Hue = 0x835; // Slightly olive

            // Outfit: Trickster with wild tribal flair, hints of both Verdant and Buccaneer’s Den
            AddItem(new TribalMask() { Name = "Painted Mask of Shifting Lies", Hue = 0x46E });
            AddItem(new FlowerGarland() { Name = "Wreath of Whispered Bargains", Hue = 0x59F });
            AddItem(new FancyShirt() { Name = "Jungle-Twist Tunic", Hue = 0x582 });
            AddItem(new Skirt() { Name = "Trade-Woven Skirt", Hue = 0x592 });
            AddItem(new BodySash() { Name = "Sash of Hidden Pockets", Hue = 0x4E7 });
            AddItem(new Sandals() { Name = "Quiet-Step Sandals", Hue = 0x456 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x422; // dark mahogany

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public VuraTwinTongue(Serial serial) : base(serial) { }

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
