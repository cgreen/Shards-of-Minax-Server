/*
 * Scripts/Custom/DialogueSystem/AqilTheSeer.cs
 * Data-driven dialogue, custom outfit, Qasaria lore, prophecy quest.
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
    [CorpseName("the corpse of Aqil the Seer")]
    public class AqilTheSeer : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static AqilTheSeer()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "AqilTheSeer.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public AqilTheSeer()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Aqil";
            Title = "the Blind Seer";
            Body = 0x190; // Human male
            Hue = 0xB64; // Olive-brown desert complexion

            // Unique, lore-rich outfit pieces
            AddItem(new HoodedShroudOfShadows() { Name = "Desert Prophet’s Shroud", Hue = 0x47E }); // silver-white
            AddItem(new Robe() { Name = "Vestments of Forgotten Light", Hue = 0xB7E }); // pale gold
            AddItem(new BodySash() { Name = "Sash of the Ancients' Voice", Hue = 0x4F2 }); // deep blue
            AddItem(new Sandals() { Name = "Sands-of-Time Footwraps", Hue = 0x966 }); // dusty tan
            AddItem(new ShepherdsCrook() { Name = "Oracle’s Crook of Insight", Hue = 0x9C4 }); // bone white

            HairItemID = 0x203B; // Long hair
            HairHue = 0x47E; // White/silver
            FacialHairItemID = 0x203E; // Long beard
            FacialHairHue = 0x47E;

            // Attach XML traits for random speech, events, etc.
            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public AqilTheSeer(Serial serial) : base(serial) { }

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
