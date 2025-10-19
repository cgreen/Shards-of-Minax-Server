/*
 * Scripts/Custom/DialogueSystem/IlanisOfAerilon.cs
 * Data-driven dialogue, custom outfit, Aerilon envoy.
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
    [CorpseName("the corpse of Ilanis")]
    public class IlanisOfAerilon : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static IlanisOfAerilon()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "IlanisOfAerilon.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public IlanisOfAerilon()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Ilanis";
            Title = "Envoy of Aerilon";
            Body = 0x190; // Human male
            Hue = 0x83EA; // Pale/cool tone

            // Custom, minimalist "Aerilon" envoy look
            AddItem(new Robe() { Name = "Mantle of Detached Judgment", Hue = 0x482 });        // muted blue-gray
            AddItem(new Cloak() { Name = "Aetheric Shroud", Hue = 0x47E });                   // pale silver
            AddItem(new Sandals() { Name = "Steps of Stillness", Hue = 0x1F7 });              // soft azure
            AddItem(new BodySash() { Name = "Sash of Calculated Intent", Hue = 0x83F });      // cool cyan
            AddItem(new LeatherGloves() { Name = "Gloves of the Dispassionate Hand", Hue = 0x8A7 });

            HairItemID = 0x203C; // short hair, androgynous
            HairHue = 0x47E;     // silvery/white
            FacialHairItemID = 0x0000;
            FacialHairHue = 0x0000;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public IlanisOfAerilon(Serial serial) : base(serial) { }

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
