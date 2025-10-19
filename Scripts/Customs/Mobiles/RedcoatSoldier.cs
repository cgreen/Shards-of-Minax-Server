using System;
using Server.Items;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
    public class RedcoatSoldier : BaseCreature
    {
        private TimeSpan m_SpeechDelay = TimeSpan.FromSeconds(30.0);
        public DateTime m_NextSpeechTime;

        [Constructable]
        public RedcoatSoldier() : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = Utility.RandomList("Thomas", "George", "Edward", "Charles", "William", "Henry", "James") + " the Redcoat";
            Body = 0x190; // Male body
            Hue = Utility.RandomSkinHue();
            SpeechHue = 0x23; // Red speech
            Title = "a British Redcoat";

            SetStr(150, 200);
            SetDex(100, 150);
            SetInt(50, 70);

            SetHits(150, 200);
            SetDamage(8, 14);

            SetDamageType(ResistanceType.Physical, 100);
            SetResistance(ResistanceType.Physical, 30, 40);
            SetResistance(ResistanceType.Fire, 10, 20);
            SetResistance(ResistanceType.Cold, 10, 20);
            SetResistance(ResistanceType.Poison, 10, 20);
            SetResistance(ResistanceType.Energy, 10, 20);

            SetSkill(SkillName.Archery, 75.0, 90.0);
            SetSkill(SkillName.Tactics, 60.0, 80.0);
            SetSkill(SkillName.MagicResist, 40.0, 60.0);
            SetSkill(SkillName.Parry, 50.0, 70.0);

            Fame = 3000;
            Karma = -3000;

            VirtualArmor = 25;

            EquipRedcoatUniform();
        }

        private void EquipRedcoatUniform()
        {
            AddItem(new FancyShirt() { Hue = 38 }); // red
            AddItem(new ShortPants() { Hue = 0 }); // black
            AddItem(new ThighBoots() { Hue = 0 });

            TricorneHat hat = new TricorneHat() { Hue = 0 };
            AddItem(hat);

            Crossbow crossbow = new Crossbow();
            AddItem(crossbow);
            PackItem(new Bolt(20)); // Ammunition
        }

        public override bool AlwaysMurderer => true;

        public override void OnThink()
        {
            base.OnThink();

            if (DateTime.Now >= m_NextSpeechTime)
            {
                if (Combatant != null && InRange(Combatant, 10))
                {
                    SayRandomTaunt();
                    m_NextSpeechTime = DateTime.Now + m_SpeechDelay;
                }
            }
        }

        private void SayRandomTaunt()
        {
            string[] taunts = new string[]
            {
                "For King and Country!",
                "You rebels shall kneel before the Crown!",
                "Long live the King!",
                "This land belongs to Britain!",
                "You call that a musket shot?"
            };

            Say(true, taunts[Utility.Random(taunts.Length)]);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
        }

        public RedcoatSoldier(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
