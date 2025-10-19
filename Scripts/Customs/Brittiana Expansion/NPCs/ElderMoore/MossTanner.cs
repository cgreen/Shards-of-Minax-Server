/*
 * Scripts/Custom/DialogueSystem/MossTanner.cs
 * The Trapwright NPC, master of gadgets and temporal anomalies.
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
    [CorpseName("the corpse of Moss Tanner")]
    public class MossTanner : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static MossTanner()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "MossTanner.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public MossTanner()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Moss Tanner the Trapwright";
            Title = "Trapwright of Eldermoor";
            Body = 0x190;
            Hue = 0x839;

            AddItem(new LeatherCap() { Name = "Patchwork Leather Cap", Hue = 0x8AB });
            AddItem(new HalfApron() { Name = "Rune-Inscribed Tinker’s Apron", Hue = 0x482 });
            AddItem(new FormalShirt() { Name = "Ash-Stained Tinkerer’s Shirt", Hue = 0x47E });
            AddItem(new ElvenPants() { Name = "Baggy Gadgeteer’s Pants", Hue = 0x899 });
            AddItem(new FurBoots() { Name = "Charred Work Boots", Hue = 0x455 });
            AddItem(new BodySash() { Name = "Bandolier of Mismatched Tools", Hue = 0x8A5 });
            AddItem(new ArtificerWand() { Name = "Rune-Carved Artificer Wand", Hue = 0x4B7 });

            HairItemID = 0x203C; // Wild, curly hair
            HairHue = 0x49B;
            FacialHairItemID = 0x204B; // Scruffy beard
            FacialHairHue = 0x47E;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public MossTanner(Serial serial) : base(serial) { }

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
