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
    [CorpseName("the charred remains of Elda Matchstick Varn")]
    public class EldaMatchstickVarn : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static EldaMatchstickVarn()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "EldaMatchstickVarn.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public EldaMatchstickVarn()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Elda \"Matchstick\" Varn";
            Title = "the Little Spark";
            Body = 0x191; // Human female
            Hue = 0x47E;

            AddItem(new FancyShirt() { Name = "Licks-of-Flame Blouse", Hue = 0x66D });
            AddItem(new Skirt() { Name = "Ash-Singed Skirt", Hue = 0x7F2 });
            AddItem(new HalfApron() { Name = "Firekeeper's Patchwork Apron", Hue = 0x9C4 });
            AddItem(new Shoes() { Name = "Charred Buckle Shoes", Hue = 0x455 });
            AddItem(new Bandana() { Name = "Scorched Red Kerchief", Hue = 0x26C });

            HairItemID = 0x203B;
            HairHue = 0x501; // Flame-red hair
            // No facial hair

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            SpecialLootHelper.AddLoot(this);	
        }

        public EldaMatchstickVarn(Serial serial) : base(serial) { }

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
