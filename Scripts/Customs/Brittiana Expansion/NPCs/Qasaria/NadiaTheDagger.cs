/*
 * Scripts/Custom/DialogueSystem/NadiaTheDagger.cs
 * Dynamic assassin NPC with interactive dialogue and custom outfit.
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
    [CorpseName("the corpse of Nadia the Dagger")]
    public class NadiaTheDagger : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static NadiaTheDagger()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "NadiaTheDagger.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public NadiaTheDagger()
            : base(AIType.AI_Thief, FightMode.None, 10, 1, 0.1, 0.2)
        {
            Name = "Nadia the Dagger";
            Title = "Shadowmaster Zahid’s Blade";
            Body = 0x191; // Human female
            Hue = 0x46F;

            // Unique, deadly outfit (Assassin’s motif)
            AddItem(new ClothNinjaHood() { Name = "Hood of the Crimson Pact", Hue = 0x21 });
            AddItem(new LeatherNinjaJacket() { Name = "Jackal's Embrace", Hue = 0x455 });
            AddItem(new LeatherNinjaPants() { Name = "Nightshade Leggings", Hue = 0x966 });
            AddItem(new NinjaTabi() { Name = "Footpads of the Desert Serpent", Hue = 0x7AF });
            AddItem(new LeatherNinjaMitts() { Name = "Whisperclaw Gloves", Hue = 0x455 });
            AddItem(new BodySash() { Name = "Sash of Silent Vendetta", Hue = 0x21 });
            AddItem(new AssassinSpike() { Name = "Dagger of Unspoken Debts", Hue = 0x485 });

            HairItemID = 0x203C; // Long hair, tied back
            HairHue = 0x497; // Black

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public NadiaTheDagger(Serial serial) : base(serial) { }

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
