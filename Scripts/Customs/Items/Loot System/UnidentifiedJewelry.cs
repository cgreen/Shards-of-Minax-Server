using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;           // SkillName
using Server.Engines.XmlSpawner2;    // XmlAttach, XmlAttachment

namespace Server.Items
{
    public class UnidentifiedJewelry : BaseUnidentifiedItem
    {
        // ---------- STATIC JEWELRY LOOT TABLES (custom jewelry types) ----------
        private static readonly Type[] Tier8Jewelry = {
            typeof(AmuletOfCorruption),
            typeof(AcidSlugRing),
            typeof(AmuletOfCorrosion),
            typeof(AmuletOfCorruption),
            typeof(AmuletOfTheCrystalDepths),
            typeof(AmuletOfTheMeerCaptain),
            typeof(BlackBearSummoningAmulet),
            typeof(BoneAmulet),
            typeof(BrigandsBand),
            typeof(CoconutCrabCharm),
            typeof(CrystalDaemonAmulet),
            typeof(DarkGuardianAmulet),
            typeof(DolphinsGuardianAmulet),			
			typeof(AmuletOfCorrosion)
        };
        private static readonly Type[] Tier9Jewelry = {
            typeof(BoneAmulet),
            typeof(DragonmasterAmulet),
            typeof(DragonWolfAmulet),
            typeof(ElderGazerAmulet),
            typeof(FireAntAmulet),
            typeof(FrostbindAmulet),
            typeof(GazerLordAmulet),
            typeof(GoblinWardAmulet),
            typeof(GrizzledRingOfDread),
            typeof(InfernalPactBracelet),
            typeof(InfernalSummonersBand),
            typeof(JackRabbitCharm)			
        };
        private static readonly Type[] Tier10Jewelry = {
            typeof(DolphinsGuardianAmulet),
            typeof(LatticeAmulet),
            typeof(NatureGuardiansTalisman),
            typeof(NecklaceOfTheEquineLord),
            typeof(PigWhisperersTalisman),
            typeof(PlaguebringersTalisman),
            typeof(PredatorsAmulet),
            typeof(RingOfTheJukanCommander),
            typeof(SerpentmastersRing),
            typeof(SolenQueenHiveBand),
            typeof(TidecallersPendant),
            typeof(WildSpiritsAmulet),
            typeof(WraithlordsAmulet)			
        };

        // ---------- CTORS ----------
        [Constructable]
        public UnidentifiedJewelry() : base(0x108A) 
        {
            Name = "Unidentified Jewelry";
			Hue = 2274;
        }

        [Constructable]
        public UnidentifiedJewelry(int quality) : base(0x108A, quality)
        {
            Name = "Unidentified Jewelry";
			Hue = 2274;
        }

        public UnidentifiedJewelry(Serial serial) : base(serial) { }

        public override void Identify(Mobile from)
        {
            // 1) roll tier exactly as weapons do
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

            // 2) create the base jewelry
            Item newItem;
            if (tier <= 7)
            {
                newItem = new RandomMagicJewelry(tier);
            }
            else if (tier == 8)
            {
                newItem = CreateFromList(Tier8Jewelry);
            }
            else if (tier == 9)
            {
                var combo = new List<Type>(Tier8Jewelry);
                combo.AddRange(Tier9Jewelry);
                newItem = CreateFromList(combo.ToArray());
            }
            else // tier == 10
            {
                var combo = new List<Type>(Tier8Jewelry);
                combo.AddRange(Tier9Jewelry);
                combo.AddRange(Tier10Jewelry);
                newItem = CreateFromList(combo.ToArray());
            }

            // 3) decide how many attachments (0–3)
            int attachCount = GetAttachmentCount(tier);

            // 4) pick & apply XML attachments
            if (attachCount > 0)
            {
                List<XmlAttachment> pool = BuildAttachmentPool(tier);
                for (int i = 0; i < attachCount && pool.Count > 0; i++)
                {
                    int idx = Utility.Random(pool.Count);
                    XmlAttach.AttachTo(newItem, pool[idx]);
                    pool.RemoveAt(idx);
                }
            }

            // 5) move the item into the world
            if (Parent is Container c)
                c.AddItem(newItem);
            else
                newItem.MoveToWorld(Location, Map);

            from.SendMessage(
                $"You identify the jewelry (Quality {Quality}) – it becomes {newItem.Name} (Tier {tier})" +
                (attachCount > 0
                    ? $" and gains {attachCount} special attachment{(attachCount > 1 ? "s" : "")}."
                    : ".")
            );

            Delete();
        }

        // === ATTACHMENT LOGIC ===

        /// <summary>How many attachments based on tier:</summary>
        private static int GetAttachmentCount(int tier)
        {
            double d = Utility.RandomDouble();

            if (tier <= 5)        // 20% chance 1, 80% none
                return d < 0.20 ? 1 : 0;

            if (tier <= 7)        // 60% one, 30% two, 10% none
                return d < 0.60 ? 1 : (d < 0.90 ? 2 : 0);

            // tier 8-10: 50% one, 35% two, 15% three
            return d < 0.50 ? 1 : (d < 0.85 ? 2 : 3);
        }

        /// <summary>Builds pool of XML attachments up through the given tier.</summary>
        private static List<XmlAttachment> BuildAttachmentPool(int tier)
        {
            var list = new List<XmlAttachment>();

            // Tier 1
            if (tier >= 1)
            {
                list.Add(new XmlMinionBonus(1));
            }

            // Tier 2
            if (tier >= 2)
            {
                list.Add(new XmlAstralStrike(2, 4));
            }

            // Tier 3
            if (tier >= 3)
            {
                list.Add(new XmlMinionBonus(2));
            }

            // Tier 4
            if (tier >= 4)
            {
                list.Add(new XmlMinionBonus(2));
            }

            // Tier 5
            if (tier >= 5)
            {
                list.Add(new XmlMinionBonus(3));
            }

            // Tier 6
            if (tier >= 6)
            {
                list.Add(new XmlMinionBonus(3));
            }

            // Tier 7
            if (tier >= 7)
            {
                list.Add(new XmlMinionBonus(4));
            }

            // Tier 8
            if (tier >= 8)
            {
                list.Add(new XmlMinionBonus(4));
            }

            // Tier 9
            if (tier >= 9)
            {
                list.Add(new XmlMinionBonus(5));
            }

            // Tier 10
            if (tier >= 10)
            {
                list.Add(new XmlMinionBonus(5));
            }

            // -------- AOS BASE ATTRIBUTES --------
            // We'll scale most attributes as +tier
            if (tier >= 1)
            {
                list.Add(new XmlAosAttributes { BonusStr        = tier });
                list.Add(new XmlAosAttributes { BonusDex        = tier });
                list.Add(new XmlAosAttributes { BonusInt        = tier });
                list.Add(new XmlAosAttributes { RegenHits       = tier });
                list.Add(new XmlAosAttributes { RegenStam       = tier });
                list.Add(new XmlAosAttributes { RegenMana       = tier });
                list.Add(new XmlAosAttributes { BonusHits       = tier * 2 });
                list.Add(new XmlAosAttributes { BonusStam       = tier * 2 });
                list.Add(new XmlAosAttributes { BonusMana       = tier * 2 });
            }
            if (tier >= 3)
            {
                list.Add(new XmlAosAttributes { DefendChance    = tier });
                list.Add(new XmlAosAttributes { AttackChance    = tier });
                list.Add(new XmlAosAttributes { SpellDamage     = tier });
                list.Add(new XmlAosAttributes { CastSpeed       = tier });
                list.Add(new XmlAosAttributes { CastRecovery    = tier });
            }
            if (tier >= 5)
            {
                list.Add(new XmlAosAttributes { LowerManaCost   = tier });
                list.Add(new XmlAosAttributes { LowerRegCost    = tier });
                list.Add(new XmlAosAttributes { ReflectPhysical = tier });
                list.Add(new XmlAosAttributes { EnhancePotions  = tier });
                list.Add(new XmlAosAttributes { Luck            = tier * 5 });
            }
            if (tier >= 7)
            {
                list.Add(new XmlAosAttributes { WeaponDamage    = tier });
                list.Add(new XmlAosAttributes { WeaponSpeed     = tier });
                list.Add(new XmlAosAttributes { NightSight      = 1 });
                list.Add(new XmlAosAttributes { SpellChanneling = 1 });
            }

            // -------- AOS WEAPON ATTRIBUTES --------
            if (tier >= 2)
            {
                list.Add(new XmlAosWeaponAttributes { LowerStatReq     = tier });
                list.Add(new XmlAosWeaponAttributes { SelfRepair       = tier });
                list.Add(new XmlAosWeaponAttributes { DurabilityBonus  = tier });
            }
            if (tier >= 4)
            {
                list.Add(new XmlAosWeaponAttributes { HitLeechHits     = tier });
                list.Add(new XmlAosWeaponAttributes { HitLeechStam     = tier });
                list.Add(new XmlAosWeaponAttributes { HitLeechMana     = tier });
                list.Add(new XmlAosWeaponAttributes { HitLowerAttack   = tier });
                list.Add(new XmlAosWeaponAttributes { HitLowerDefend   = tier });
                list.Add(new XmlAosWeaponAttributes { UseBestSkill     = 1 });
                list.Add(new XmlAosWeaponAttributes { MageWeapon       = 1 });
            }
            if (tier >= 6)
            {
                list.Add(new XmlAosWeaponAttributes { HitMagicArrow    = tier });
                list.Add(new XmlAosWeaponAttributes { HitHarm          = tier });
                list.Add(new XmlAosWeaponAttributes { HitFireball      = tier });
                list.Add(new XmlAosWeaponAttributes { HitColdArea      = tier });
                list.Add(new XmlAosWeaponAttributes { HitFireArea      = tier });
                list.Add(new XmlAosWeaponAttributes { HitEnergyArea    = tier });
                list.Add(new XmlAosWeaponAttributes { HitPoisonArea    = tier });
            }
            if (tier >= 8)
            {
                list.Add(new XmlAosWeaponAttributes { HitDispel        = tier });
                list.Add(new XmlAosWeaponAttributes { ResistPhysicalBonus = tier });
                list.Add(new XmlAosWeaponAttributes { ResistFireBonus     = tier });
                list.Add(new XmlAosWeaponAttributes { ResistColdBonus     = tier });
                list.Add(new XmlAosWeaponAttributes { ResistPoisonBonus   = tier });
                list.Add(new XmlAosWeaponAttributes { ResistEnergyBonus   = tier });
            }

            // -------- AOS ARMOR ATTRIBUTES --------
            if (tier >= 2)
            {
                list.Add(new XmlAosArmorAttributes { LowerStatReq    = tier });
                list.Add(new XmlAosArmorAttributes { SelfRepair      = tier });
                list.Add(new XmlAosArmorAttributes { DurabilityBonus = tier });
            }
            if (tier >= 5)
            {
                list.Add(new XmlAosArmorAttributes { MageArmor       = tier });
            }

            // -------- AOS ELEMENT ATTRIBUTES --------
            if (tier >= 3)
            {
                list.Add(new XmlAosElementAttributes { Physical = tier });
                list.Add(new XmlAosElementAttributes { Fire     = tier });
                list.Add(new XmlAosElementAttributes { Cold     = tier });
            }
            if (tier >= 6)
            {
                list.Add(new XmlAosElementAttributes { Poison   = tier });
                list.Add(new XmlAosElementAttributes { Energy   = tier });
            }

            return list;
        }

        // === HELPERS ===

        private static Item CreateFromList(Type[] list)
        {
            if (list == null || list.Length == 0)
                return new RandomMagicJewelry(7);

            Type t = list[Utility.Random(list.Length)];
            return (Item)Activator.CreateInstance(t);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
