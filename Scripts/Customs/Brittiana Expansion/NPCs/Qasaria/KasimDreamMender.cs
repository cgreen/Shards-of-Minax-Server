/*
 * Scripts/Custom/DialogueSystem/KasimDreamMender.cs
 * Mystic dreamwalker of Qasaria, cursed and wise, offers dream-quest.
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
    [CorpseName("the corpse of Kasim the Dream-Mender")]
    public class KasimDreamMender : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static KasimDreamMender()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "KasimDreamMender.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public KasimDreamMender()
            : base(AIType.AI_Healer, FightMode.None, 10, 1, 0.1, 0.2)
        {
            Name = "Kasim the Dream-Mender";
            Title = "Dreamwalker of Qasaria";
            Body = 0x190; // Human male
            Hue = 0x430; // Pale gold, dream-touched

            // Unique, mystical outfit pieces
            AddItem(new HoodedShroudOfShadows() { Name = "Dreamshroud of the Broken Slumber", Hue = 0x8A5 });    // Faded violet
            AddItem(new Robe() { Name = "Mantle of Reverie", Hue = 0x481 });                                     // Smoky blue-grey
            AddItem(new BodySash() { Name = "Sash of Moonlit Promises", Hue = 0xB60 });                          // Silver-blue
            AddItem(new Sandals() { Name = "Steps of the Slumbering Sands", Hue = 0x44E });                      // Dusty gold
            AddItem(new LeatherGloves() { Name = "Gloves of Somnolent Healing", Hue = 0x96B });                  // Soft cream
            AddItem(new WoodlandBelt() { Name = "Cord of Restful Vigil", Hue = 0x4AC });                                 // Opal white

            AddItem(new GnarledStaff() { Name = "Nightmare-Binding Staff", Hue = 0x489 });

            HairItemID = 0x203B; // Long hair
            HairHue = 0x47E;     // Silvery-white
            FacialHairItemID = 0x203F; // Short beard
            FacialHairHue = 0x481;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public KasimDreamMender(Serial serial) : base(serial) { }

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
