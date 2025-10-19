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
    [CorpseName("the corpse of Chieftain Kaelor the Ash-Walker")]
    public class ChieftainKaelorAshWalker : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ChieftainKaelorAshWalker()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ChieftainKaelorAshWalker.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ChieftainKaelorAshWalker()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Kaelor the Ash-Walker";
            Title = "Chieftain of the Verdant Tribes";
            Body = 0x190; // Human male
            Hue = 0x839;

            // Tribal, nature-themed outfit
            AddItem(new TribalMask() { Name = "Ash-Walker’s War Mask", Hue = 0x455 });
            AddItem(new LeatherArms() { Name = "Ember-Stained Bracers", Hue = 0x842 });
            AddItem(new LeatherChest() { Name = "Cloak of Wild Bark", Hue = 0x7B5 });
            AddItem(new LeatherLegs() { Name = "Greaves of the Green Flame", Hue = 0x83E });
            AddItem(new FurBoots() { Name = "Hunter’s Footwraps", Hue = 0x966 });
            AddItem(new Cloak() { Name = "Cloak of Ancestral Smoke", Hue = 0x497 });

            AddItem(new Club() { Name = "The Ashen Club", Hue = 0x455 });

            HairItemID = 0x203B; // Long hair
            HairHue = 0x83A; // dark brown/ash

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        public ChieftainKaelorAshWalker(Serial serial) : base(serial) { }

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
