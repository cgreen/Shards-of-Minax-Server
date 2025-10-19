/*
 * Scripts/Custom/DialogueSystem/VarnikCleft.cs
 * Data-driven dialogue, custom crystal-forged golem, Aerilon lore.
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
    [CorpseName("the crystal shards of Varnik Cleft")]
    public class VarnikCleft : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static VarnikCleft()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "VarnikCleft.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public VarnikCleft()
            : base(AIType.AI_Mage, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Varnik Cleft";
            Title = "the Crystal-Forged (Awakened)";
            Body = 0x190; // humanoid base for golems
            Hue = 0x515; // deep shimmering azure

            // Custom, loreful crystal golem outfit/gear
            AddItem(new WizardsHat() { Name = "Facet-Crown of Salia", Hue = 0x4FF });
            AddItem(new Robe() { Name = "Gleamshard Mantle", Hue = 0x4F2 });
            AddItem(new BodySash() { Name = "Girdle of Resonance", Hue = 0xB70 });
            AddItem(new Cloak() { Name = "Etherveil of Echoes", Hue = 0x1F6 });
            AddItem(new Sandals() { Name = "Soleplates of the First Awakening", Hue = 0x497 });
            AddItem(new LeatherGloves() { Name = "Articulators of Careful Making", Hue = 0x483 });
            AddItem(new GnarledStaff() { Name = "Shard-Bound Scepter", Hue = 0x519 });

            HairItemID = 0x0000; // none, head is crystal facets
            FacialHairItemID = 0x0000; // none

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this); // Crystal fragments etc
        }

        public VarnikCleft(Serial serial) : base(serial) { }

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
