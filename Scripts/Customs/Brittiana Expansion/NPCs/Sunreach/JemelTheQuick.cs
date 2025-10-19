/*
 * Scripts/Custom/DialogueSystem/JemelTheQuick.cs
 * Data-driven dialogue, street urchin leader, Sunreach flavor.
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
    [CorpseName("the body of Jemel the Quick")]
    public class JemelTheQuick : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static JemelTheQuick()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "JemelTheQuick.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public JemelTheQuick()
            : base(AIType.AI_Thief, FightMode.None, 6, 1, 0.2, 0.4)
        {
            Name = "Jemel the Quick";
            Title = "Street Urchin King";
            Body = 0x190; // Human male
            Hue = 0x83F8; // Tan skin

            // Ragged but distinctive outfit, agile child-thief theme
            AddItem(new Bandana() { Name = "Tattered Red Bandana", Hue = 0x21 });
            AddItem(new Shirt() { Name = "Grimy Street Shirt", Hue = 0x839 });
            AddItem(new ShortPants() { Name = "Patched Short Pants", Hue = 0x853 });
            AddItem(new Sandals() { Name = "Worn Sandals", Hue = 0x901 });
            AddItem(new HalfApron() { Name = "Stolen Half-Apron", Hue = 0x455 });
            AddItem(new Dagger() { Name = "Small Shiv", Hue = 0x900 });

            HairItemID = 0x203B; // short hair
            HairHue = 0x1BB; // brown

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);
        }

        public JemelTheQuick(Serial serial) : base(serial) { }

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
