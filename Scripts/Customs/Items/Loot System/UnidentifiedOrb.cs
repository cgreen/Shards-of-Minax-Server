using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;   // for SkillName
using Server.CustomJewels;

namespace Server.Items
{
    public class UnidentifiedOrb : BaseUnidentifiedItem
    {
        // ———— ORB TABLES ————
        private static readonly Type[] Tier1Potions = {
            typeof(SkillOrb),
            typeof(StatCapOrb),
            typeof(CompassionStone),
            typeof(HonestyStone),
            typeof(HonorStone),
            typeof(JusticeStone),
            typeof(SacrificeStone),
            typeof(SpiritualityStone),
            typeof(ValorStone),
            typeof(HumilityStone),
            typeof(MythicAmethyst),
            typeof(LegendaryAmethyst),
            typeof(AncientAmethyst),
            typeof(FenCrystal),
            typeof(RhoCrystal),
            typeof(RysCrystal),
            typeof(WyrCrystal),
            typeof(FreCrystal),
            typeof(TorCrystal),
            typeof(VelCrystal),
            typeof(XenCrystal),
            typeof(PolCrystal),
            typeof(WolCrystal),
            typeof(BalCrystal),
            typeof(TalCrystal),
            typeof(JalCrystal),
            typeof(RalCrystal),
            typeof(KalCrystal),
            typeof(MythicDiamond),
            typeof(LegendaryDiamond),
            typeof(AncientDiamond),
            typeof(MythicEmerald),
            typeof(LegendaryEmerald),
            typeof(AncientEmerald),
            typeof(KeyAugment),
            typeof(RadiantRhoCrystal),
            typeof(RadiantRysCrystal),
            typeof(RadiantWyrCrystal),
            typeof(RadiantFreCrystal),
            typeof(RadiantTorCrystal),
            typeof(RadiantVelCrystal),
            typeof(RadiantXenCrystal),
            typeof(RadiantPolCrystal),
            typeof(RadiantWolCrystal),
            typeof(RadiantBalCrystal),
            typeof(RadiantTalCrystal),
            typeof(RadiantJalCrystal),
            typeof(RadiantRalCrystal),
            typeof(RadiantKalCrystal),
            typeof(MythicRuby),
            typeof(LegendaryRuby),
            typeof(AncientRuby),
            typeof(TyrRune),
            typeof(AhmRune),
            typeof(MorRune),
            typeof(MefRune),
            typeof(YlmRune),
            typeof(KotRune),
            typeof(JorRune),
            typeof(MythicSapphire),
            typeof(LegendarySapphire),
            typeof(AncientSapphire),
            typeof(MythicSkull),
            typeof(AncientSkull),
            typeof(LegendarySkull),
            typeof(GlimmeringGranite),
            typeof(GlimmeringClay),
            typeof(GlimmeringHeartstone),
            typeof(GlimmeringGypsum),
            typeof(GlimmeringIronOre),
            typeof(GlimmeringOnyx),
            typeof(GlimmeringMarble),
            typeof(GlimmeringPetrifiedWood),
            typeof(GlimmeringLimestone),
            typeof(GlimmeringBloodrock),
            typeof(MythicTourmaline),
            typeof(LegendaryTourmaline),
            typeof(AncientTourmaline),
            typeof(MythicWood),
            typeof(LegendaryWood),
            typeof(AlchemistsWax),
            typeof(ArcaneHourglass),
            typeof(BlacksmithingCatalyst),
            typeof(CartographersPen),
            typeof(CartographersPin),
            typeof(ChaosGlyph),
            typeof(CompassRose),
            typeof(DiamondLootScroll),
            typeof(EasternBrand),
            typeof(ErasureScroll),
            typeof(ExaltedOrb),
            typeof(FarEasternBrand),
            typeof(FeluccanBrand),
            typeof(FeluccaPortalPrism),
            typeof(FirestormGlyph),
            typeof(FletchingCatalyst),
            typeof(GoldenSeal),
            typeof(GlyphOfBounty),
            typeof(IlshenarBrand),
            typeof(InkOfRegression),
            typeof(MalasBrand),
            typeof(MonsterMixMedallion),
            typeof(NorthernBrand),
            typeof(OrbOfAnnulment),
            typeof(PlanarCompass),
            typeof(RadiusRune),
            typeof(ScrollOfIntensification),
            typeof(SingularityRune),
            typeof(SosariaBrand),
            typeof(SouthernBrand),
            typeof(StabilizerRune),
            typeof(SurveyorsCompass),
            typeof(TailoringCatalyst),
            typeof(TemporalSundial),
            typeof(TerMurBrand),
            typeof(TimeTurnToken),
            typeof(TinkeringCatalyst),
            typeof(TokunoBrand),
            typeof(TrammelBrand),
            typeof(WesternBrand),
            typeof(CustomJewel)	
        };
        private static readonly Type[] Tier2Potions = {

            typeof(CustomJewel)			
        };
        private static readonly Type[] Tier3Potions = {

            typeof(CustomJewel)	
        };
        private static readonly Type[] Tier4Potions = {

            typeof(CustomJewel)
        };
        private static readonly Type[] Tier5Potions = {

            typeof(CustomJewel)
        };
        private static readonly Type[] Tier6Potions = {

            typeof(CustomJewel)
        };
        private static readonly Type[] Tier7Potions = {

            typeof(CustomJewel)
        };
        private static readonly Type[] Tier8Potions = {

            typeof(CustomJewel)
        };
        private static readonly Type[] Tier9Potions = {

            typeof(CustomJewel)
        };
        private static readonly Type[] Tier10Potions = {

            typeof(CustomJewel)
        };

        // ———— CTORS ————
        [Constructable]
        public UnidentifiedOrb() : base(0x186F) // bottle ID
        {
            Name = "Unidentified Orb";
        }

        [Constructable]
        public UnidentifiedOrb(int quality) : base(0x186F, quality)
        {
            Name = "Unidentified Orb";
        }

        public UnidentifiedOrb(Serial serial) : base(serial) { }

        // ———— IDENTIFY METHOD ————
        public override void Identify(Mobile from)
        {
            // 1) Roll tier
            int skillBonus = (int)(from.Skills[SkillName.ItemID].Base / 10);
            int roll       = Utility.RandomMinMax(1, 100) + Quality + skillBonus;
            int tier;

            if      (roll >= 100) tier = 10;
            else if (roll >= 98)  tier =  9;
            else if (roll >= 95)  tier =  8;
            else if (roll >= 90)  tier =  7;
            else if (roll >= 82)  tier =  6;
            else if (roll >= 71)  tier =  5;
            else if (roll >= 58)  tier =  4;
            else if (roll >= 42)  tier =  3;
            else if (roll >= 22)  tier =  2;
            else                  tier =  1;

            // 2) Pick a potion for that tier
            Item newPotion = CreateFromTier(tier);

            // 3) Place it in the world or container
            if (Parent is Container c)
                c.AddItem(newPotion);
            else
                newPotion.MoveToWorld(Location, Map);

            // 4) Notify & delete
            from.SendMessage(
                $"You identify the potion (Quality {Quality}) – it becomes “{newPotion.Name}” (Tier {tier})."
            );
            Delete();
        }

        // ———— HELPER TO SELECT POTION BY TIER ————
        private static Item CreateFromTier(int tier)
        {
            Type[] list;

            switch (tier)
            {
                case  1: list = Tier1Potions;  break;
                case  2: list = Tier2Potions;  break;
                case  3: list = Tier3Potions;  break;
                case  4: list = Tier4Potions;  break;
                case  5: list = Tier5Potions;  break;
                case  6: list = Tier6Potions;  break;
                case  7: list = Tier7Potions;  break;
                case  8: list = Tier8Potions;  break;
                case  9: list = Tier9Potions;  break;
                case 10: list = Tier10Potions; break;
                default: list = Tier1Potions;  break;
            }

            if (list == null || list.Length == 0)
                return new LesserHealPotion(); // fallback

            var t = list[Utility.Random(list.Length)];
            return (Item)Activator.CreateInstance(t);
        }

        // ———— SERIALIZE / DESERIALIZE ————
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
