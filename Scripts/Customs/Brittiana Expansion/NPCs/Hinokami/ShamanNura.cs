/*
 * Scripts/Custom/DialogueSystem/ShamanNura.cs
 * Verdant Tribes: Vision Quest Dialogue, Herbalism Quests, Tribal Lore.
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
    [CorpseName("the remains of Shaman Nura")]
    public class ShamanNura : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static ShamanNura()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "ShamanNura.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public ShamanNura()
            : base(AIType.AI_Healer, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Shaman Nura";
            Title = "the Spirit Walker";
            Body = 0x191; // Human female
            Hue = 0x83E8; // Tanned, earth tone

            // Verdant, tribal outfit (nature/druidic)
            AddItem(new MonkRobe() { Name = "Robes of the Verdant Spirit", Hue = 0x59B });
            AddItem(new FlowerGarland() { Name = "Garland of Sacred Blooms", Hue = 0x482 });
            AddItem(new WoodlandBelt() { Name = "Shaman’s Bark Belt", Hue = 0x839 });
            AddItem(new WoodlandArms() { Name = "Druidic Bark Sleeves", Hue = 0x839 });
            AddItem(new FurBoots() { Name = "Boots of Moss and Hide", Hue = 0x97F });

            HairItemID = 0x203C; // long wavy
            HairHue = 0x453; // green-tinged brown

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            // Add custom loot as needed
        }

        public ShamanNura(Serial serial) : base(serial) { }

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
