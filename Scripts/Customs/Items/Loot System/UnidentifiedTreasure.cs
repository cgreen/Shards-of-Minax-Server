using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;   // for SkillName

namespace Server.Items
{
    public class UnidentifiedTreasure : BaseUnidentifiedItem
    {
        // ———— TREASURE TABLES ————
        private static readonly Type[] Tier1Potions = {
            typeof(AbbasidsTreasureChest),
            typeof(AbyssalPlaneChest),
            typeof(AlehouseChest),
            typeof(AlienArtifactChest),
            typeof(AlienArtifaxChest),
            typeof(AlliedForcesTreasureChest),
            typeof(AnarchistsCache),
            typeof(AncientRelicChest),
            typeof(AngelBlessingChest),
            typeof(AnglersBounty),
            typeof(ArcadeKingsTreasure),
            typeof(ArcadeMastersVault),
            typeof(ArcaneTreasureChest),
            typeof(ArcanumChest),
            typeof(ArcheryBonusChest),
            typeof(AshokasTreasureChest),
            typeof(AshokaTreasureChest),
            typeof(AssassinsCoffer),
            typeof(AthenianTreasureChest),
            typeof(BabylonianChest),
            typeof(BakersDelightChest),
            typeof(BakersDolightChest),
            typeof(BavarianFestChest),
            typeof(BismarcksTreasureChest),
            typeof(BolsheviksLoot),
            typeof(BountyHuntersCache),
            typeof(BoyBandBox),
            typeof(BrewmastersChest),
            typeof(BritainsRoyalTreasuryChest),
            typeof(BuccaneersChest),
            typeof(CaesarChest),
            typeof(CandyCarnivalCoffer),
            typeof(CaptainCooksTreasure),
            typeof(CelticLegendsChest),
            typeof(ChamplainTreasureChest),
            typeof(CheeseConnoisseursCache),
            typeof(ChocolatierTreasureChest),
            typeof(CivilRightsStrongbox),
            typeof(CivilWarCache),
            typeof(CivilWarChest),
            typeof(CivilWorChest),
            typeof(ClownsWhimsicalChest),
            typeof(ColonialPioneersCache),
            typeof(ComradesCache),
            typeof(ConfederationCache),
            typeof(ConquistadorsHoard),
            typeof(CovenTreasuresChest),
            typeof(CyberneticCache)	
        };
        private static readonly Type[] Tier2Potions = {
            typeof(CyrusTreasure),
            typeof(DesertPharaohChest),
            typeof(DinerDelightChest),
            typeof(DoctorsBag),
            typeof(DojoLegacyChest),
            typeof(DragonGuardiansHoardChest),
            typeof(DragonHoardChest),
            typeof(DragonHoChest),
            typeof(DragonHodChest),
            typeof(DragonHorChest),
            typeof(DriveInTreasureTrove),
            typeof(DroidWorkshopChest),
            typeof(DynastyRelicsChest),
            typeof(EdisonsTreasureChest),
            typeof(EgyptianChest),
            typeof(EliteFoursVault),
            typeof(ElvenEnchantressChest),
            typeof(ElvenTreasuryChest),
            typeof(EmeraldIsleChest),
            typeof(EmperorJustinianCache),
            typeof(EmperorLegacyChest),
            typeof(EnchantedForestChest),
            typeof(EtherealPlaneChest),
            typeof(EuropeanRelicsChest),
            typeof(FairyDustChest),
            typeof(FirstNationsHeritageChest),
            typeof(FlowerPowerChest),
            typeof(FocusBonusChest),
            typeof(ForbiddenAlchemistsCache),
            typeof(FrontierExplorersStash),
            typeof(FunkyFashionChest),
            typeof(FurTradersChest),
            typeof(GalacticExplorersTrove),
            typeof(GalacticRelicsChest),
            typeof(GamersLootbox),
            typeof(GardenersParadiseChest),
            typeof(GeishasGift),
            typeof(GermanUnificationChest),
            typeof(GoldRushBountyChest),
            typeof(GoldRushRelicChest),
            typeof(GreasersGoldmineChest),
            typeof(GroovyVabesChest),
            typeof(GroovyVibesChest),
            typeof(GrungeRockersCache),
            typeof(HipHopRapVault),
            typeof(HolyRomanEmpireChest)			
        };
        private static readonly Type[] Tier3Potions = {
            typeof(HomewardBoundChest),
            typeof(HussarsChest),
            typeof(InfernalPlaneChest),
            typeof(InnovatorVault),
            typeof(JedisReliquary),
            typeof(JestersGigglingChest),
            typeof(JestersJamboreeChest),
            typeof(JestersJest),
            typeof(JudahsTreasureChest),
            typeof(JukeboxJewels),
            typeof(JustinianTreasureChest),
            typeof(KagesTreasureChest),
            typeof(KingdomsVaultChest),
            typeof(KingKamehamehaTreasure),
            typeof(KingsBest),
            typeof(KoscheisUndyingChest),
            typeof(LawyerBriefcase),
            typeof(LeprechaunsLootChest),
            typeof(LeprechaunsTrove),
            typeof(LouisTreasuryChest),
            typeof(MacingBonusChest),
            typeof(MagesArcaneChest),
            typeof(MagesRelicChest),
            typeof(MaharajaTreasureChest),
            typeof(MarioTreasureBox),
            typeof(MedievalEnglandChest),
            typeof(MerchantChest),
            typeof(MerchantFortuneChest),
            typeof(MermaidTreasureChest),
            typeof(MillenniumTimeCapsule)
        };
        private static readonly Type[] Tier4Potions = {
            typeof(MimeSilentChest),
            typeof(MirageChest),
            typeof(ModMadnessTrunk),
            typeof(MondainsDarkSecretsChest),
            typeof(MysticalDaoChest),
            typeof(MysticalEnchantersChest),
            typeof(MysticEnigmaChest),
            typeof(MysticGardenCache),
            typeof(MysticMoonChest),
            typeof(NaturesBountyChest),
            typeof(NavyCaptainsChest),
            typeof(NecroAlchemicalChest),
            typeof(NeonNightsChest),
            typeof(NeroChest),
            typeof(NinjaChest),
            typeof(NordicExplorersChest),
            typeof(PatriotCache),
            typeof(PeachRoyalCache),
            typeof(PharaohsReliquary),
            typeof(PharaohsTreasure),
            typeof(PixieDustChest),
            typeof(PokeballTreasureChest),
            typeof(PolishRoyalChest),
            typeof(PopStarsTrove),
            typeof(RadBoomboxTrove),
            typeof(Radical90sRelicsChest),
            typeof(RadRidersStash),
            typeof(RailwayWorkersChest),
            typeof(RebelChest),
            typeof(RenaissanceCollectorsChest),
            typeof(RetroArcadeChest),
            typeof(RevolutionaryChess),
            typeof(RevolutionaryChest),
            typeof(RevolutionaryRelicChest),
            typeof(RevolutionChest),
            typeof(RhineValleyChest),
            typeof(RiverPiratesChest),
            typeof(RiverRaftersChest),
            typeof(RockersVault),
            typeof(RockNBallVault),
            typeof(RockNRallVault),
            typeof(RockNRollVault),
            typeof(RoguesHiddenChest)
        };
        private static readonly Type[] Tier5Potions = {
            typeof(RomanBritanniaChest),
            typeof(RomanEmperorsVault),
            typeof(SamuraiHonorChest),
            typeof(SamuraiStash),
            typeof(SandstormChest),
            typeof(ScholarEnlightenmentChest),
            typeof(SeaDogsChest),
            typeof(ShinobiSecretsChest),
            typeof(SilkRoadTreasuresChest),
            typeof(SilverScreenChest),
            typeof(SithsVault),
            typeof(SlavicBrosChest),
            typeof(SlavicLegendsChest),
            typeof(SmugglersCache),
            typeof(SocialMediaMavensChest),
            typeof(SorceressSecretsChest),
            typeof(SpaceRaceCache),
            typeof(SpartanTreasureChest),
            typeof(SpecialChivalryChest),
            typeof(SpecialWoodenChestConstantine),
            typeof(SpecialWoodenChestExplorerLegacy),
            typeof(SpecialWoodenChestFrench),
            typeof(SpecialWoodenChestHelios),
            typeof(SpecialWoodenChestIvan),
            typeof(SpecialWoodenChestOisin),
            typeof(SpecialWoodenChestTomoe),
            typeof(SpecialWoodenChestWashington),
            typeof(StarfleetsVault),
            typeof(SugarplumFairyChest),
            typeof(SwingTimeChest),
            typeof(SwordsmanshipBonusChest),
            typeof(TacticsBonusChest),
            typeof(TangDynastyChest),
            typeof(TechnicolorTalesChest),
            typeof(TechnophilesCache),
            typeof(TeutonicRelicChest),
            typeof(TeutonicTreasuresChest),
            typeof(ThiefsHideawayStash),
            typeof(ToxicologistsTrove)
        };
        private static readonly Type[] Tier6Potions = {
            typeof(TrailblazersTrove),
            typeof(TravelerChest),
            typeof(TreasureChestOfTheQinDynasty),
            typeof(TreasureChestOfTheThreeKingdoms),
            typeof(TsarsLegacyChest),
            typeof(TsarsRoyalChest),
            typeof(TsarsTreasureChest),
            typeof(TudorDynastyChest),
            typeof(UndergroundAnarchistsCache),
            typeof(USSRRelicsChest),
            typeof(VenetianMerchantsStash),
            typeof(VHSAdventureCache),
            typeof(VictorianEraChest),
            typeof(VikingChest),
            typeof(VintnersVault),
            typeof(VinylVault),
            typeof(VirtuesGuardianChest),
            typeof(WarOf1812Vault),
            typeof(WarringStatesChest),
            typeof(WingedHusChest),
            typeof(WingedHussarsChest),
            typeof(WitchsBrewChest),
            typeof(WorkersRevolutionChest),
            typeof(WorldWarIIChest),
            typeof(WWIIValorChest),
            typeof(GrandChestOfLithuanianLegacy),
            typeof(HelvetianTreasureChest),
            typeof(LostChestOfEquatorialGuinea),
            typeof(TreasureChestOfAfghanKings),
            typeof(TreasureChestOfAnatolia),
            typeof(TreasureChestOfAncientEgypt),
            typeof(TreasureChestOfAncientEthiopia),
            typeof(TreasureChestOfAncientGeorgia),
            typeof(TreasureChestOfAncientGhana),
            typeof(TreasureChestOfAncientKyrgyzstan),
            typeof(TreasureChestOfAncientLibya),
            typeof(TreasureChestOfAncientPersia),
            typeof(TreasureChestOfAncientSriLanka),
            typeof(TreasureChestOfAncientSyria),
            typeof(TreasureChestOfAndorra),
            typeof(TreasureChestOfAngola),
            typeof(TreasureChestOfAntiguaBarbuda),
            typeof(TreasureChestOfArabiasSands)
        };
        private static readonly Type[] Tier7Potions = {
            typeof(TreasureChestOfArgentina),
            typeof(TreasureChestOfArmenia),
            typeof(TreasureChestOfAustralia),
            typeof(TreasureChestOfAzerbaijan),
            typeof(TreasureChestOfBahamianLegends),
            typeof(TreasureChestOfBarbados),
            typeof(TreasureChestOfBelarus),
            typeof(TreasureChestOfBelizeanLegends),
            typeof(TreasureChestOfBeninKingdom),
            typeof(TreasureChestOfBoliviasLostEmpires),
            typeof(TreasureChestOfBosnia),
            typeof(TreasureChestOfBotswanaLegacy),
            typeof(TreasureChestOfBrazilsHistory),
            typeof(TreasureChestOfBruneisGoldenAge),
            typeof(TreasureChestOfBurundi),
            typeof(TreasureChestOfCaboVerde),
            typeof(TreasureChestOfCameroonLegacy),
            typeof(TreasureChestOfCanadianHeritage),
            typeof(TreasureChestOfChad),
            typeof(TreasureChestOfChineseHistory),
            typeof(TreasureChestOfColombia),
            typeof(TreasureChestOfComoros),
            typeof(TreasureChestOfCostaRicanHistory),
            typeof(TreasureChestOfCoteDIvoire),
            typeof(TreasureChestOfCuba),
            typeof(TreasureChestOfCyprus),
            typeof(TreasureChestOfCzechHistory),
            typeof(TreasureChestOfDalmatianKings),
            typeof(TreasureChestOfDihya),
            typeof(TreasureChestOfDilmun),
            typeof(TreasureChestOfDjibouti),
            typeof(TreasureChestOfDominica),
            typeof(TreasureChestOfEcuadorianLegends),
            typeof(TreasureChestOfElSalvadorHistory),
            typeof(TreasureChestOfEritreanLegacy),
            typeof(TreasureChestOfEstonianLegends),
            typeof(TreasureChestOfEswatini),
            typeof(TreasureChestOfFinland),
            typeof(TreasureChestOfFrenchHistory),
            typeof(TreasureChestOfGaboneseHistory),
            typeof(TreasureChestOfGermanHistory),
            typeof(TreasureChestOfGreatZimbabwe),
            typeof(TreasureChestOfGreekHistory)
        };
        private static readonly Type[] Tier8Potions = {
            typeof(TreasureChestOfGrenada),
            typeof(TreasureChestOfGuatemala),
            typeof(TreasureChestOfGuinea),
            typeof(TreasureChestOfGuineaBissau),
            typeof(TreasureChestOfGuyana),
            typeof(TreasureChestOfHaitisLegacy),
            typeof(TreasureChestOfHonduranLegends),
            typeof(TreasureChestOfHungarianLegends),
            typeof(TreasureChestOfIndiasLegacy),
            typeof(TreasureChestOfIrishHistory),
            typeof(TreasureChestOfItalianHistory),
            typeof(TreasureChestOfJamaica),
            typeof(TreasureChestOfJordan),
            typeof(TreasureChestOfKazakhstan),
            typeof(TreasureChestOfKenyanLegends),
            typeof(TreasureChestOfKiribati),
            typeof(TreasureChestOfKoreanHeritage),
            typeof(TreasureChestOfKuwait),
            typeof(TreasureChestOfLanXang),
            typeof(TreasureChestOfLatvianLegacy),
            typeof(TreasureChestOfLebanon),
            typeof(TreasureChestOfLesotho),
            typeof(TreasureChestOfLiberianHistory),
            typeof(TreasureChestOfLiechtenstein),
            typeof(TreasureChestOfLusitanianLegends),
            typeof(TreasureChestOfLuxembourg),
            typeof(TreasureChestOfMadagascar),
            typeof(TreasureChestOfMalaysianHistory),
            typeof(TreasureChestOfMaliEmpire),
            typeof(TreasureChestOfMalta),
            typeof(TreasureChestOfMauritania),
            typeof(TreasureChestOfMauritius),
            typeof(TreasureChestOfMesopotamianLegends),
            typeof(TreasureChestOfMexicosLegacy),
            typeof(TreasureChestOfMicronesianLegends),
            typeof(TreasureChestOfMoldovanHistory),
            typeof(TreasureChestOfMonaco),
            typeof(TreasureChestOfMongolia),
            typeof(TreasureChestOfMontenegro),
            typeof(TreasureChestOfMozambiqueHistory),
            typeof(TreasureChestOfNamibia),
            typeof(TreasureChestOfNaurusForgottenKings),
            typeof(TreasureChestOfNepal),
            typeof(TreasureChestOfNewZealandHistory)
        };
        private static readonly Type[] Tier9Potions = {
            typeof(TreasureChestOfNicaraguasLegacy),
            typeof(TreasureChestOfNigerEmpires),
            typeof(TreasureChestOfNigerianHistory),
            typeof(TreasureChestOfNorthKorea),
            typeof(TreasureChestOfNorthMacedonia),
            typeof(TreasureChestOfNorway),
            typeof(TreasureChestOfNusantaraKings),
            typeof(TreasureChestOfOman),
            typeof(TreasureChestOfPakistan),
            typeof(TreasureChestOfPalauanHistory),
            typeof(TreasureChestOfPalestine),
            typeof(TreasureChestOfPanama),
            typeof(TreasureChestOfPapuaNewGuinea),
            typeof(TreasureChestOfParaguay),
            typeof(TreasureChestOfPolishHistory),
            typeof(TreasureChestOfQatar),
            typeof(TreasureChestOfQuisqueya),
            typeof(TreasureChestOfRomania),
            typeof(TreasureChestOfRussianHistory),
            typeof(TreasureChestOfRwanda),
            typeof(TreasureChestOfRwandasKings),
            typeof(TreasureChestOfSaintKittsAndNevis),
            typeof(TreasureChestOfSaintLucia),
            typeof(TreasureChestOfSaintVincent),
            typeof(TreasureChestOfSamoa),
            typeof(TreasureChestOfSanMarino),
            typeof(TreasureChestOfSaoTomeAndPrincipe),
            typeof(TreasureChestOfSenegal),
            typeof(TreasureChestOfSiam),
            typeof(TreasureChestOfSierraLeone),
            typeof(TreasureChestOfSingapore),
            typeof(TreasureChestOfSlovakia),
            typeof(TreasureChestOfSomalia),
            typeof(TreasureChestOfSouthAfricanLegends),
            typeof(TreasureChestOfSouthSudan),
            typeof(TreasureChestOfSudaneseHistory),
            typeof(TreasureChestOfSuriname),
            typeof(TreasureChestOfSweden),
            typeof(TreasureChestOfTajikistan),
            typeof(TreasureChestOfTanzania),
            typeof(TreasureChestOfTheAlbanianHighlands),
            typeof(TreasureChestOfTheAustrianLegacy),
            typeof(TreasureChestOfTheBelgianRealms),
            typeof(TreasureChestOfTheBengalDelta),
            typeof(TreasureChestOfTheBulgarianTsars),
            typeof(TreasureChestOfTheCentralAfricanRealms),
            typeof(TreasureChestOfTheChileanAndes),
            typeof(TreasureChestOfTheCongo),
            typeof(TreasureChestOfTheCongoRiver),
            typeof(TreasureChestOfTheDanes),
            typeof(TreasureChestOfTheDragonKingdom),
            typeof(TreasureChestOfTheDutchGoldenAge)
        };
        private static readonly Type[] Tier10Potions = {
            typeof(TreasureChestOfTheEmirates),
            typeof(TreasureChestOfTheFijianIsles),
            typeof(TreasureChestOfTheGambia),
            typeof(TreasureChestOfTheHolySee),
            typeof(TreasureChestOfTheIcelandicSagas),
            typeof(TreasureChestOfTheIrrawaddyKings),
            typeof(TreasureChestOfTheKhmerEmpire),
            typeof(TreasureChestOfTheLakeOfStars),
            typeof(TreasureChestOfTheLostEmpire),
            typeof(TreasureChestOfTheMaldives),
            typeof(TreasureChestOfTheMarshallIslands),
            typeof(TreasureChestOfTheMoroccanDynasties),
            typeof(TreasureChestOfTheMossiKingdoms),
            typeof(TreasureChestOfThePearlOfTheOrient),
            typeof(TreasureChestOfTheSandsOfGaza),
            typeof(TreasureChestOfTheSeychellesIsles),
            typeof(TreasureChestOfTheShiningSun),
            typeof(TreasureChestOfTheSlovenes),
            typeof(TreasureChestOfTheSolomonIsles),
            typeof(TreasureChestOfTheSovietUnion),
            typeof(TreasureChestOfTheSpanishLegacy),
            typeof(TreasureChestOfTheUnitedKingdom),
            typeof(TreasureChestOfTheUnitedStates),
            typeof(TreasureChestOfTheWhiteEagle),
            typeof(TreasureChestOfTheZambezi),
            typeof(TreasureChestOfTimorLeste),
            typeof(TreasureChestOfTimuridSamarkand),
            typeof(TreasureChestOfTogo),
            typeof(TreasureChestOfTonga),
            typeof(TreasureChestOfTrinidadAndTobago),
            typeof(TreasureChestOfTunisia),
            typeof(TreasureChestOfTurkmenistan),
            typeof(TreasureChestOfTuvalu),
            typeof(TreasureChestOfUganda),
            typeof(TreasureChestOfUkrainianLegends),
            typeof(TreasureChestOfUruguay),
            typeof(TreasureChestOfVanuatu),
            typeof(TreasureChestOfVenezuela),
            typeof(TreasureChestOfVietLegends),
            typeof(TreasureChestOfYemen)
        };

        // ———— CTORS ————
        [Constructable]
        public UnidentifiedTreasure() : base(0x0E43) // bottle ID
        {
            Name = "Unidentified Treasure";
        }

        [Constructable]
        public UnidentifiedTreasure(int quality) : base(0x0E43, quality)
        {
            Name = "Unidentified Treasure";
        }

        public UnidentifiedTreasure(Serial serial) : base(serial) { }

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
