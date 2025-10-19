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
    [CorpseName("the corpse of Nolgrim the Scribe")]
    public class NolgrimTheScribe : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static NolgrimTheScribe()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "NolgrimTheScribe.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public NolgrimTheScribe()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Nolgrim the Scribe";
            Title = "Archivist of Forbidden Texts";
            Body = 0x190; // Human male
            Hue = 0x840;

            // Unique, named outfit with odd hues for arcane/paranoid look
            AddItem(new FancyShirt() { Name = "Inkward's Blue Stainshirt", Hue = 0x5B6 });
            AddItem(new LongPants() { Name = "Midnight Scholar's Breeches", Hue = 0x497 });
            AddItem(new HalfApron() { Name = "Script-Keeper's Apron", Hue = 0x46F });
            AddItem(new HoodedShroudOfShadows() { Name = "Paranoia's Cowl", Hue = 0x455 });
            AddItem(new Sandals() { Name = "Slinking Scribe's Slippers", Hue = 0x59B });
            AddItem(new LeatherGloves() { Name = "Inkproof Gauntlets", Hue = 0x45A });

            // Props
            AddItem(new ScribeSword() { Name = "Living Ink Quillblade", Hue = 0x51B });

            HairItemID = 0x203C; // Short hair
            HairHue = 0x48B;

            // Attach paranoia/quirk flavor (if you have custom traits)
            XmlAttach.AttachTo(this, new XmlRandomTraits());
        }

        public NolgrimTheScribe(Serial serial) : base(serial) { }

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
