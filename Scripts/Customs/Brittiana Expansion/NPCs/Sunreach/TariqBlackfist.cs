/*
 * Scripts/Custom/DialogueSystem/TariqBlackfist.cs
 * Gladiator pitmaster, Sunreach black market brawler, dialogue-driven quest.
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
    [CorpseName("the corpse of Tariq Blackfist")]
    public class TariqBlackfist : BaseCreature
    {
        private static readonly DialogueManager _dialogue;

        static TariqBlackfist()
        {
            var path = Path.Combine(Core.BaseDirectory, "Data", "Dialogues", "TariqBlackfist.xml");
            _dialogue = DialogueManager.LoadFromXml(path);
        }

        [Constructable]
        public TariqBlackfist()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Tariq Blackfist";
            Title = "Gladiator Pitmaster";
            Body = 0x190; // Human male
            Hue = 0x83F; // Tanned/brawler look

            // Distinct pitmaster/brawler look
            AddItem(new LeatherArms() { Name = "Pitmaster's Wraps", Hue = 0x455 });
            AddItem(new LeatherGloves() { Name = "Brawler's Gauntlets", Hue = 0x59B });
            AddItem(new Kilt() { Name = "Bloodstained Kilt", Hue = 0x21 });
            AddItem(new HalfApron() { Name = "Fighter's Apron", Hue = 0x487 });
            AddItem(new Sandals() { Name = "Arena Sandals", Hue = 0x514 });
            AddItem(new Bandana() { Name = "Sunreach Bandana", Hue = 0x455 });

            HairItemID = 0x203B; // long hair
            HairHue = 0x47C;     // black
            FacialHairItemID = 0x2041; // full beard
            FacialHairHue = 0x47C;

            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        public TariqBlackfist(Serial serial) : base(serial) { }

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
