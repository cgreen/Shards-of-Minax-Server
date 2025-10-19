using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;           // SkillName
using Server.Engines.XmlSpawner2;    // XmlAttach, XmlAttachment

namespace Server.Items
{
    public class UnidentifiedShield : BaseUnidentifiedItem
    {
        // ---------- STATIC LOOT TABLES (high-tier shields) ----------
        private static readonly Type[] Tier8Items = {
            typeof(BladedancersOrderShield),
            typeof(RiotDefendersShield),
            typeof(WitchfireShield),
            typeof(MoltenShapersShield),			
			typeof(DarkKnightsDoomShield)
        };
        private static readonly Type[] Tier9Items = {
            typeof(KnightsValorShield),
            typeof(HyruleKnightsShield),
            typeof(KnightsValorShield),
            typeof(RoguesStealthShield),
            typeof(Stormshield),			
            typeof(FrostwardensWoodenShield)
        };
        private static readonly Type[] Tier10Items = {
            typeof(RiotDefendersShield),
            typeof(MirrorShield),			
            typeof(HammerlordsShield)		
        };

        // ---------- CTORS ----------
        [Constructable]
        public UnidentifiedShield() : base(0x1B77)
        {
            Name = "Unidentified Shield";
			Hue = 2274;
        }

        [Constructable]
        public UnidentifiedShield(int quality) : base(0x1B77, quality)
        {
            Name = "Unidentified Shield";
			Hue = 2274;
        }

        public UnidentifiedShield(Serial serial) : base(serial) { }

        // =========================================================
        //                      I D E N T I F Y
        // =========================================================
        public override void Identify(Mobile from)
        {
            // 1) Roll tier (same as weapons) :contentReference[oaicite:0]{index=0}
            int skillBonus = (int)(from.Skills[SkillName.ItemID].Base / 10);
            int roll       = Utility.RandomMinMax(1, 100) + Quality + skillBonus;
            int tier;

            if      (roll >= 100) tier = 10;
            else if (roll >= 98)  tier = 9;
            else if (roll >= 95)  tier = 8;
            else if (roll >= 90)  tier = 7;
            else if (roll >= 82)  tier = 6;
            else if (roll >= 71)  tier = 5;
            else if (roll >= 58)  tier = 4;
            else if (roll >= 42)  tier = 3;
            else if (roll >= 22)  tier = 2;
            else                  tier = 1;

            // 2) Create base shield
            Item newItem;
            if (tier <= 7)
            {
                newItem = new RandomMagicShield(tier);
            }
            else if (tier == 8)
            {
                newItem = CreateFromList(Tier8Items);
            }
            else if (tier == 9)
            {
                var combo = new List<Type>(Tier8Items);
                combo.AddRange(Tier9Items);
                newItem = CreateFromList(combo.ToArray());
            }
            else // tier 10
            {
                var combo = new List<Type>(Tier8Items);
                combo.AddRange(Tier9Items);
                combo.AddRange(Tier10Items);
                newItem = CreateFromList(combo.ToArray());
            }

            // 3) Decide attachment count :contentReference[oaicite:1]{index=1}
            int toAdd = GetAttachmentCount(tier);

            // 4) Build pool & attach
            if (toAdd > 0)
            {
                var pool = BuildAttachmentPool(tier);
                for (int i = 0; i < toAdd && pool.Count > 0; i++)
                {
                    int idx = Utility.Random(pool.Count);
                    XmlAttach.AttachTo(newItem, pool[idx]);
                    pool.RemoveAt(idx);
                }
            }

            // 5) Place and notify
            if (Parent is Container c) c.AddItem(newItem);
            else                        newItem.MoveToWorld(Location, Map);

            from.SendMessage(String.Format(
                "You identify the shield (Quality {0}) – it becomes {1} (Tier {2}){3}.",
                Quality, newItem.Name, tier,
                toAdd > 0 ? " and gains " + toAdd + " attachment" + (toAdd > 1 ? "s" : "") : ""
            ));
            Delete();
        }

        // =========================================================
        //                 A T T A C H M E N T   L O G I C
        // =========================================================

        private static int GetAttachmentCount(int tier)
        {
            double roll = Utility.RandomDouble();

            if (tier <= 5)                        // 80% none, 20% one
                return roll < 0.20 ? 1 : 0;

            if (tier <= 7)                        // 60% one, 30% two, 10% none
                return roll < 0.60 ? 1 : (roll < 0.90 ? 2 : 0);

            // tier 8–10: 50% one, 35% two, 15% three
            return roll < 0.50 ? 1 : (roll < 0.85 ? 2 : 3);
        }

        private static List<XmlAttachment> BuildAttachmentPool(int tier)
        {
            var list = new List<XmlAttachment>();

            // Tier 1
            if (tier >= 1)
            {
                list.Add(new XmlMinionBonus(1));               // :contentReference[oaicite:2]{index=2}
                list.Add(new XmlFireBreathAttack(10, 4, 1.0)); // :contentReference[oaicite:3]{index=3}
            }
            // Tier 2
            if (tier >= 2)
            {
                list.Add(new XmlAstralStrike(2, 4));           // :contentReference[oaicite:4]{index=4}
                list.Add(new XmlFireBreathAttack(15, 5, 0.9));
            }
            // Tier 3
            if (tier >= 3)
            {
                list.Add(new XmlMinionBonus(2));
                list.Add(new XmlFireBreathAttack(20, 6, 0.8));
                list.Add(new XmlAstralStrike(3, 5));
            }
            // Tier 4
            if (tier >= 4)
            {
                list.Add(new XmlMinionBonus(2));
                list.Add(new XmlFireBreathAttack(25, 7, 0.7));
                list.Add(new XmlAstralStrike(4, 6));
            }
            // Tier 5
            if (tier >= 5)
            {
                list.Add(new XmlMinionBonus(3));
                list.Add(new XmlFireBreathAttack(30, 8, 0.6));
                list.Add(new XmlAstralStrike(5, 7));
            }
            // Tier 6
            if (tier >= 6)
            {
                list.Add(new XmlMinionBonus(3));
                list.Add(new XmlFireBreathAttack(40, 9, 0.5));
                list.Add(new XmlAstralStrike(6, 8));
            }
            // Tier 7
            if (tier >= 7)
            {
                list.Add(new XmlMinionBonus(4));
                list.Add(new XmlFireBreathAttack(50, 10, 0.4));
                list.Add(new XmlAstralStrike(7, 10));
            }
            // Tier 8
            if (tier >= 8)
            {
                list.Add(new XmlMinionBonus(4));
                list.Add(new XmlFireBreathAttack(60, 11, 0.35));
                list.Add(new XmlAstralStrike(8, 12));
            }
            // Tier 9
            if (tier >= 9)
            {
                list.Add(new XmlMinionBonus(5));
                list.Add(new XmlFireBreathAttack(75, 12, 0.30));
                list.Add(new XmlAstralStrike(9, 14));
            }
            // Tier 10
            if (tier >= 10)
            {
                list.Add(new XmlMinionBonus(5));
                list.Add(new XmlFireBreathAttack(90, 14, 0.25));
                list.Add(new XmlAstralStrike(10, 15));
            }

            return list;
        }

        // =========================================================
        //                      H E L P E R S
        // =========================================================
        private static Item CreateFromList(Type[] list)
        {
            Type t = list[Utility.Random(list.Length)];
            return (Item)Activator.CreateInstance(t);
        }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
}
