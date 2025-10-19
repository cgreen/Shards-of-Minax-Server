using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Mobiles;
using Server.Commands;
using Server.Network;
using Server.Regions;
using Server.Spells.Ninjitsu;
using Bittiez.CustomSystems; // Ensure this matches your TensionManager namespace

namespace Server.Customs.Invasion_System
{
    #region Tier Helper

    /// <summary>
    /// Provides methods to determine the current tier based on tension and
    /// to retrieve the cumulative lists of allowed monster and champion types.
    /// Tier boundaries:
    ///   Level 1: 0 - 11,000
    ///   Level 2: 11,001 - 14,000
    ///   Level 3: 14,001 - 16,000
    ///   Level 4: 16,001 - 19,000
    ///   Level 5: 19,001+
    /// </summary>
    public static class InvasionTierHelper
    {
        // Define the lists of monster types for each tier
        private static readonly List<TownMonsterType> Tier1Monsters = new List<TownMonsterType>
        {
            TownMonsterType.OrcsandRatmen,
            TownMonsterType.Abyss,
			TownMonsterType.Arachnid,
			TownMonsterType.DragonKind,
			TownMonsterType.Humanoid,
			TownMonsterType.Undead
        };

        private static readonly List<TownMonsterType> Tier2Monsters = new List<TownMonsterType>
        {
			TownMonsterType.InvasionWolf,
			TownMonsterType.InvasionSlimes,
			TownMonsterType.InvasionSquirrel,
			TownMonsterType.InvasionToads,
			TownMonsterType.InvasionSheep,
			TownMonsterType.InvasionPanther,
			TownMonsterType.InvasionPigs,
			TownMonsterType.InvasionRabbit,
			TownMonsterType.InvasionRats,
			TownMonsterType.InvasionGorilla,
			TownMonsterType.InvasionGreatHart,
			TownMonsterType.InvasionGrizzlyBear,
			TownMonsterType.InvasionHarpy,
			TownMonsterType.InvasionHorses,
			TownMonsterType.InvasionGoats,
			TownMonsterType.InvasionFerrets,
			TownMonsterType.InvasionAlligators,
			TownMonsterType.InvasionBears,
			TownMonsterType.InvasionBulls,
			TownMonsterType.InvasionCats,
			TownMonsterType.InvasionChickens			
			
        };

        private static readonly List<TownMonsterType> Tier3Monsters = new List<TownMonsterType>
        {
			TownMonsterType.DemonicEntities,
			TownMonsterType.ExtendedArachnids,
			TownMonsterType.Mammals,
			TownMonsterType.Birds,
			TownMonsterType.ReptilesAmphibians,
			TownMonsterType.Goblins,
			TownMonsterType.HumanoidsExtended,
			TownMonsterType.MagicalBeasts,
			TownMonsterType.SpiritsWisps,
			TownMonsterType.AquaticCreatures,
			TownMonsterType.InsectsCrawlers,
			TownMonsterType.GiantsTrolls,
			TownMonsterType.MiscellaneousMonsters,		
			TownMonsterType.InvasionAirElementals,
			TownMonsterType.InvasionCorpser,
			TownMonsterType.InvasionCrabs,
			TownMonsterType.InvasionDaemons,
			TownMonsterType.InvasionDragons,
			TownMonsterType.InvasionEarthElementals
        };

        private static readonly List<TownMonsterType> Tier4Monsters = new List<TownMonsterType>
        {
			TownMonsterType.InvasionEttin,
			TownMonsterType.InvasionFey,
			TownMonsterType.InvasionFireElementals,
			TownMonsterType.InvasionGargoyles,
			TownMonsterType.InvasionGazers,
			TownMonsterType.InvasionGiantSerpant,
			TownMonsterType.InvasionGiantSpider,
			TownMonsterType.InvasionGolems,
			TownMonsterType.InvasionAncientLiches,
			TownMonsterType.InvasionLichs,
			TownMonsterType.InvasionLlama,
			TownMonsterType.InvasionMummy,
			TownMonsterType.InvasionOgres,
			TownMonsterType.InvasionRobot,
			TownMonsterType.InvasionRobotOverlord,
			TownMonsterType.InvasionSatyr,
			TownMonsterType.InvasionSkeletonKnight,
			TownMonsterType.InvasionWaterElementals
        };

        private static readonly List<TownMonsterType> Tier5Monsters = new List<TownMonsterType>
        {
			TownMonsterType.CombatOrientedNPCs,
			TownMonsterType.MartialArtsSpecialists,
			TownMonsterType.SpecializedCombatants,
			TownMonsterType.MagicalSupernaturalNPCs,
			TownMonsterType.ClericsHealersNPCs,
			TownMonsterType.ShamansMysticsNPCs,
			TownMonsterType.NatureThemedNPCs,
			TownMonsterType.StealthEspionageNPCs,
			TownMonsterType.MysticalMythologicalNPCs,
			TownMonsterType.CraftsmenArtisansNPCs,
			TownMonsterType.EntertainersCulturalNPCs,
			TownMonsterType.SciFiFuturisticNPCs,
			TownMonsterType.HistoricalThematicNPCs,
			TownMonsterType.MiscellaneousNPCs
        };

        // Define the lists of champion types for each tier
        private static readonly List<TownChampionType> Tier1Champions = new List<TownChampionType>
        {
            TownChampionType.Barracoon,
			TownChampionType.Neira,
            TownChampionType.Rikktor,
            TownChampionType.Semidar,
            TownChampionType.Serado,
            TownChampionType.LordOaks,
            TownChampionType.Mephitis			
        };

        private static readonly List<TownChampionType> Tier2Champions = new List<TownChampionType>
        {
            TownChampionType.UltimateMasterHealer,
            TownChampionType.UltimateMasterHerder,
            TownChampionType.UltimateMasterHider,
            TownChampionType.UltimateMasterImbuing,
            TownChampionType.UltimateMasterInscription,
            TownChampionType.UltimateMasterIntelligence,
            TownChampionType.UltimateMasterItemIdentification,
            TownChampionType.UltimateMasterLockpicker,
            TownChampionType.UltimateMasterLumberjack,
            TownChampionType.UltimateMasterMaceFighting,
            TownChampionType.UltimateMasterMage,
            TownChampionType.UltimateMasterMagicResistance,
            TownChampionType.UltimateMasterMeditation,
            TownChampionType.UltimateMasterMiner,
            TownChampionType.UltimateMasterMusician,
            TownChampionType.UltimateMasterMysticism,
            TownChampionType.UltimateMasterNecromancer,
            TownChampionType.UltimateMasterNinjitsu,
            TownChampionType.UltimateMasterParrying,
            TownChampionType.UltimateMasterPeacemaker,
            TownChampionType.UltimateMasterPoisoner,
            TownChampionType.UltimateMasterProvocation,
            TownChampionType.UltimateMasterRemoveTrap,
            TownChampionType.UltimateMasterSnooping,
            TownChampionType.UltimateMasterSpellweaver,
            TownChampionType.UltimateMasterSpiritSpeak,
            TownChampionType.UltimateMasterStealth,
            TownChampionType.UltimateMasterSwordsman,
            TownChampionType.UltimateMasterTactician,
            TownChampionType.UltimateMasterTailor,
            TownChampionType.UltimateMasterTasteIdentification,
            TownChampionType.UltimateMasterThief,
            TownChampionType.UltimateMasterThrowing,
            TownChampionType.UltimateMasterTinkering,
            TownChampionType.UltimateMasterTracker,
            TownChampionType.UltimateMasterVeterinary,
            TownChampionType.UltimateMasterWrestling
        };

        private static readonly List<TownChampionType> Tier3Champions = new List<TownChampionType>
        {
            TownChampionType.UltimateAlchemyMaster,
            TownChampionType.UltimateMasterAnatomy,
            TownChampionType.UltimateMasterAnimalLore,
            TownChampionType.UltimateMasterAnimalTamer,
            TownChampionType.UltimateMasterArcher,
            TownChampionType.UltimateMasterArmsLore,
            TownChampionType.UltimateMasterBeggar,
            TownChampionType.UltimateMasterBlacksmith,
            TownChampionType.UltimateMasterBowcraft,
            TownChampionType.UltimateMasterBushido,
            TownChampionType.UltimateMasterCamper,
            TownChampionType.UltimateMasterCarpenter,
            TownChampionType.UltimateMasterCartographer,
            TownChampionType.UltimateMasterChef,
            TownChampionType.UltimateMasterChivalry,
            TownChampionType.UltimateMasterDetectingHidden,
            TownChampionType.UltimateMasterDiscordance,
            TownChampionType.UltimateMasterFencer,
            TownChampionType.UltimateMasterFishing,
            TownChampionType.UltimateMasterFocus,
            TownChampionType.UltimateMasterForensicEvaluator
        };

        private static readonly List<TownChampionType> Tier4Champions = new List<TownChampionType>
        {
            TownChampionType.ChaosLord,
            TownChampionType.ChaosWyrm,
            TownChampionType.ChronosTheTimeLord,
            TownChampionType.DraconicusTheDestroyer,
            TownChampionType.Dreadlord,
            TownChampionType.FrostWraith,
            TownChampionType.JesterOfChaos,
            TownChampionType.PrimevalDragon,
            TownChampionType.PrismaticDragon,
            TownChampionType.SaiyanWarrior,
            TownChampionType.SearingExarch,
            TownChampionType.SlimePrincessSuiblex,
            TownChampionType.SuperDragon
        };

        private static readonly List<TownChampionType> Tier5Champions = new List<TownChampionType>
        {
            TownChampionType.Harrower,
            TownChampionType.MinaxTheTimeSorceress			

        };

        public static int GetTier(int tension)
        {
            if (tension <= 11000)
                return 1;
            else if (tension <= 14000)
                return 2;
            else if (tension <= 16000)
                return 3;
            else if (tension <= 19000)
                return 4;
            else
                return 5;
        }

        public static List<TownMonsterType> GetMonsterTypesForTier(int tier)
        {
            List<TownMonsterType> types = new List<TownMonsterType>();
            if (tier >= 1)
                types.AddRange(Tier1Monsters);
            if (tier >= 2)
                types.AddRange(Tier2Monsters);
            if (tier >= 3)
                types.AddRange(Tier3Monsters);
            if (tier >= 4)
                types.AddRange(Tier4Monsters);
            if (tier >= 5)
                types.AddRange(Tier5Monsters);
            return types;
        }

        public static List<TownChampionType> GetChampionTypesForTier(int tier)
        {
            List<TownChampionType> types = new List<TownChampionType>();
            if (tier >= 1)
                types.AddRange(Tier1Champions);
            if (tier >= 2)
                types.AddRange(Tier2Champions);
            if (tier >= 3)
                types.AddRange(Tier3Champions);
            if (tier >= 4)
                types.AddRange(Tier4Champions);
            if (tier >= 5)
                types.AddRange(Tier5Champions);
            return types;
        }
    }

    #endregion

    #region Invasion Type Registry

    /// <summary>
    /// Central registry mapping invasion type enums to their spawn logic.
    /// Update these dictionaries when adding new monster or champion types.
    /// </summary>
    public static class InvasionTypeRegistry
    {
        // Map from TownMonsterType to the corresponding spawn entry arrays.
        // It is assumed that MonsterTownSpawnEntry.Abyss, MonsterTownSpawnEntry.Arachnid, etc.
        // are defined elsewhere in your project.
        public static readonly Dictionary<TownMonsterType, MonsterTownSpawnEntry[]> MonsterSpawns = new Dictionary<TownMonsterType, MonsterTownSpawnEntry[]>
        {
            { TownMonsterType.OrcsandRatmen, MonsterTownSpawnEntry.OrcsandRatmen },
            { TownMonsterType.Abyss, MonsterTownSpawnEntry.Abyss },
            { TownMonsterType.Arachnid, MonsterTownSpawnEntry.Arachnid },
            { TownMonsterType.DragonKind, MonsterTownSpawnEntry.DragonKind },
            { TownMonsterType.Humanoid, MonsterTownSpawnEntry.Humanoid },
            { TownMonsterType.Undead, MonsterTownSpawnEntry.Undead },
			{ TownMonsterType.CombatOrientedNPCs, MonsterTownSpawnEntry.CombatOrientedNPCs },
			{ TownMonsterType.MartialArtsSpecialists, MonsterTownSpawnEntry.MartialArtsSpecialists },
			{ TownMonsterType.SpecializedCombatants, MonsterTownSpawnEntry.SpecializedCombatants },
			{ TownMonsterType.MagicalSupernaturalNPCs, MonsterTownSpawnEntry.MagicalSupernaturalNPCs },
			{ TownMonsterType.ClericsHealersNPCs, MonsterTownSpawnEntry.ClericsHealersNPCs },
			{ TownMonsterType.ShamansMysticsNPCs, MonsterTownSpawnEntry.ShamansMysticsNPCs },
			{ TownMonsterType.NatureThemedNPCs, MonsterTownSpawnEntry.NatureThemedNPCs },
			{ TownMonsterType.StealthEspionageNPCs, MonsterTownSpawnEntry.StealthEspionageNPCs },
			{ TownMonsterType.MysticalMythologicalNPCs, MonsterTownSpawnEntry.MysticalMythologicalNPCs },
			{ TownMonsterType.CraftsmenArtisansNPCs, MonsterTownSpawnEntry.CraftsmenArtisansNPCs },
			{ TownMonsterType.EntertainersCulturalNPCs, MonsterTownSpawnEntry.EntertainersCulturalNPCs },
			{ TownMonsterType.SciFiFuturisticNPCs, MonsterTownSpawnEntry.SciFiFuturisticNPCs },
			{ TownMonsterType.HistoricalThematicNPCs, MonsterTownSpawnEntry.HistoricalThematicNPCs },
			{ TownMonsterType.MiscellaneousNPCs, MonsterTownSpawnEntry.MiscellaneousNPCs },
			{ TownMonsterType.DemonicEntities, MonsterTownSpawnEntry.DemonicEntities },
			{ TownMonsterType.ExtendedArachnids, MonsterTownSpawnEntry.ExtendedArachnids },
			{ TownMonsterType.Mammals, MonsterTownSpawnEntry.Mammals },
			{ TownMonsterType.Birds, MonsterTownSpawnEntry.Birds },
			{ TownMonsterType.ReptilesAmphibians, MonsterTownSpawnEntry.ReptilesAmphibians },
			{ TownMonsterType.Goblins, MonsterTownSpawnEntry.Goblins },
			{ TownMonsterType.HumanoidsExtended, MonsterTownSpawnEntry.HumanoidsExtended },
			{ TownMonsterType.MagicalBeasts, MonsterTownSpawnEntry.MagicalBeasts },
			{ TownMonsterType.SpiritsWisps, MonsterTownSpawnEntry.SpiritsWisps },
			{ TownMonsterType.AquaticCreatures, MonsterTownSpawnEntry.AquaticCreatures },
			{ TownMonsterType.InsectsCrawlers, MonsterTownSpawnEntry.InsectsCrawlers },
			{ TownMonsterType.GiantsTrolls, MonsterTownSpawnEntry.GiantsTrolls },
			{ TownMonsterType.MiscellaneousMonsters, MonsterTownSpawnEntry.MiscellaneousMonsters },
			{ TownMonsterType.InvasionAirElementals, MonsterTownSpawnEntry.InvasionAirElementals },
			{ TownMonsterType.InvasionAlligators, MonsterTownSpawnEntry.InvasionAlligators },
			{ TownMonsterType.InvasionBears, MonsterTownSpawnEntry.InvasionBears },
			{ TownMonsterType.InvasionBulls, MonsterTownSpawnEntry.InvasionBulls },
			{ TownMonsterType.InvasionCats, MonsterTownSpawnEntry.InvasionCats },
			{ TownMonsterType.InvasionChickens, MonsterTownSpawnEntry.InvasionChickens },
			{ TownMonsterType.InvasionCorpser, MonsterTownSpawnEntry.InvasionCorpser },
			{ TownMonsterType.InvasionCrabs, MonsterTownSpawnEntry.InvasionCrabs },
			{ TownMonsterType.InvasionDaemons, MonsterTownSpawnEntry.InvasionDaemons },
			{ TownMonsterType.InvasionDragons, MonsterTownSpawnEntry.InvasionDragons },
			{ TownMonsterType.InvasionEarthElementals, MonsterTownSpawnEntry.InvasionEarthElementals },
			{ TownMonsterType.InvasionEttin, MonsterTownSpawnEntry.InvasionEttin },
			{ TownMonsterType.InvasionFerrets, MonsterTownSpawnEntry.InvasionFerrets },
			{ TownMonsterType.InvasionFey, MonsterTownSpawnEntry.InvasionFey },
			{ TownMonsterType.InvasionFireElementals, MonsterTownSpawnEntry.InvasionFireElementals },
			{ TownMonsterType.InvasionGargoyles, MonsterTownSpawnEntry.InvasionGargoyles },
			{ TownMonsterType.InvasionGazers, MonsterTownSpawnEntry.InvasionGazers },
			{ TownMonsterType.InvasionGiantSerpant, MonsterTownSpawnEntry.InvasionGiantSerpant },
			{ TownMonsterType.InvasionGiantSpider, MonsterTownSpawnEntry.InvasionGiantSpider },
			{ TownMonsterType.InvasionGoats, MonsterTownSpawnEntry.InvasionGoats },
			{ TownMonsterType.InvasionGolems, MonsterTownSpawnEntry.InvasionGolems },
			{ TownMonsterType.InvasionGorilla, MonsterTownSpawnEntry.InvasionGorilla },
			{ TownMonsterType.InvasionGreatHart, MonsterTownSpawnEntry.InvasionGreatHart },
			{ TownMonsterType.InvasionGrizzlyBear, MonsterTownSpawnEntry.InvasionGrizzlyBear },
			{ TownMonsterType.InvasionHarpy, MonsterTownSpawnEntry.InvasionHarpy },
			{ TownMonsterType.InvasionHorses, MonsterTownSpawnEntry.InvasionHorses },
			{ TownMonsterType.InvasionAncientLiches, MonsterTownSpawnEntry.InvasionAncientLiches },
			{ TownMonsterType.InvasionLichs, MonsterTownSpawnEntry.InvasionLichs },
			{ TownMonsterType.InvasionLlama, MonsterTownSpawnEntry.InvasionLlama },
			{ TownMonsterType.InvasionMummy, MonsterTownSpawnEntry.InvasionMummy },
			{ TownMonsterType.InvasionOgres, MonsterTownSpawnEntry.InvasionOgres },
			{ TownMonsterType.InvasionPanther, MonsterTownSpawnEntry.InvasionPanther },
			{ TownMonsterType.InvasionPigs, MonsterTownSpawnEntry.InvasionPigs },
			{ TownMonsterType.InvasionRabbit, MonsterTownSpawnEntry.InvasionRabbit },
			{ TownMonsterType.InvasionRats, MonsterTownSpawnEntry.InvasionRats },
			{ TownMonsterType.InvasionRobot, MonsterTownSpawnEntry.InvasionRobot },
			{ TownMonsterType.InvasionRobotOverlord, MonsterTownSpawnEntry.InvasionRobotOverlord },
			{ TownMonsterType.InvasionSatyr, MonsterTownSpawnEntry.InvasionSatyr },
			{ TownMonsterType.InvasionSheep, MonsterTownSpawnEntry.InvasionSheep },
			{ TownMonsterType.InvasionSkeletonKnight, MonsterTownSpawnEntry.InvasionSkeletonKnight },
			{ TownMonsterType.InvasionSlimes, MonsterTownSpawnEntry.InvasionSlimes },
			{ TownMonsterType.InvasionSquirrel, MonsterTownSpawnEntry.InvasionSquirrel },
			{ TownMonsterType.InvasionToads, MonsterTownSpawnEntry.InvasionToads },
			{ TownMonsterType.InvasionWaterElementals, MonsterTownSpawnEntry.InvasionWaterElementals },
			{ TownMonsterType.InvasionWolf, MonsterTownSpawnEntry.InvasionWolf },
			
            // Add additional mappings here as you expand.
        };

        // Map from TownChampionType to the corresponding champion Mobile Type.
        public static readonly Dictionary<TownChampionType, Type> ChampionSpawns = new Dictionary<TownChampionType, Type>
        {
            { TownChampionType.Barracoon, typeof(Barracoon) },
            { TownChampionType.Harrower, typeof(Harrower) },
            { TownChampionType.LordOaks, typeof(LordOaks) },
            { TownChampionType.Mephitis, typeof(Mephitis) },
            { TownChampionType.Neira, typeof(Neira) },
            { TownChampionType.Rikktor, typeof(Rikktor) },
            { TownChampionType.Semidar, typeof(Semidar) },
            { TownChampionType.Serado, typeof(Serado) },
			{ TownChampionType.ChaosLord, typeof(ChaosLord) },
			{ TownChampionType.ChaosWyrm, typeof(ChaosWyrm) },
			{ TownChampionType.ChronosTheTimeLord, typeof(ChronosTheTimeLord) },
			{ TownChampionType.DraconicusTheDestroyer, typeof(DraconicusTheDestroyer) },
			{ TownChampionType.Dreadlord, typeof(Dreadlord) },
			{ TownChampionType.FrostWraith, typeof(FrostWraith) },
			{ TownChampionType.JesterOfChaos, typeof(JesterOfChaos) },
			{ TownChampionType.MinaxTheTimeSorceress, typeof(MinaxTheTimeSorceress) },
			{ TownChampionType.PrimevalDragon, typeof(PrimevalDragon) },
			{ TownChampionType.PrismaticDragon, typeof(PrismaticDragon) },
			{ TownChampionType.SaiyanWarrior, typeof(SaiyanWarrior) },
			{ TownChampionType.SearingExarch, typeof(SearingExarch) },
			{ TownChampionType.SlimePrincessSuiblex, typeof(SlimePrincessSuiblex) },
			{ TownChampionType.SuperDragon, typeof(SuperDragon) },
			{ TownChampionType.UltimateAlchemyMaster, typeof(UltimateAlchemyMaster) },
			{ TownChampionType.UltimateMasterAnatomy, typeof(UltimateMasterAnatomy) },
			{ TownChampionType.UltimateMasterAnimalLore, typeof(UltimateMasterAnimalLore) },
			{ TownChampionType.UltimateMasterAnimalTamer, typeof(UltimateMasterAnimalTamer) },
			{ TownChampionType.UltimateMasterArcher, typeof(UltimateMasterArcher) },
			{ TownChampionType.UltimateMasterArmsLore, typeof(UltimateMasterArmsLore) },
			{ TownChampionType.UltimateMasterBeggar, typeof(UltimateMasterBeggar) },
			{ TownChampionType.UltimateMasterBlacksmith, typeof(UltimateMasterBlacksmith) },
			{ TownChampionType.UltimateMasterBowcraft, typeof(UltimateMasterBowcraft) },
			{ TownChampionType.UltimateMasterBushido, typeof(UltimateMasterBushido) },
			{ TownChampionType.UltimateMasterCamper, typeof(UltimateMasterCamper) },
			{ TownChampionType.UltimateMasterCarpenter, typeof(UltimateMasterCarpenter) },
			{ TownChampionType.UltimateMasterCartographer, typeof(UltimateMasterCartographer) },
			{ TownChampionType.UltimateMasterChef, typeof(UltimateMasterChef) },
			{ TownChampionType.UltimateMasterChivalry, typeof(UltimateMasterChivalry) },
			{ TownChampionType.UltimateMasterDetectingHidden, typeof(UltimateMasterDetectingHidden) },
			{ TownChampionType.UltimateMasterDiscordance, typeof(UltimateMasterDiscordance) },
			{ TownChampionType.UltimateMasterFencer, typeof(UltimateMasterFencer) },
			{ TownChampionType.UltimateMasterFishing, typeof(UltimateMasterFishing) },
			{ TownChampionType.UltimateMasterFocus, typeof(UltimateMasterFocus) },
			{ TownChampionType.UltimateMasterForensicEvaluator, typeof(UltimateMasterForensicEvaluator) },
			{ TownChampionType.UltimateMasterHealer, typeof(UltimateMasterHealer) },
			{ TownChampionType.UltimateMasterHerder, typeof(UltimateMasterHerder) },
			{ TownChampionType.UltimateMasterHider, typeof(UltimateMasterHider) },
			{ TownChampionType.UltimateMasterImbuing, typeof(UltimateMasterImbuing) },
			{ TownChampionType.UltimateMasterInscription, typeof(UltimateMasterInscription) },
			{ TownChampionType.UltimateMasterIntelligence, typeof(UltimateMasterIntelligence) },
			{ TownChampionType.UltimateMasterItemIdentification, typeof(UltimateMasterItemIdentification) },
			{ TownChampionType.UltimateMasterLockpicker, typeof(UltimateMasterLockpicker) },
			{ TownChampionType.UltimateMasterLumberjack, typeof(UltimateMasterLumberjack) },
			{ TownChampionType.UltimateMasterMaceFighting, typeof(UltimateMasterMaceFighting) },
			{ TownChampionType.UltimateMasterMage, typeof(UltimateMasterMage) },
			{ TownChampionType.UltimateMasterMagicResistance, typeof(UltimateMasterMagicResistance) },
			{ TownChampionType.UltimateMasterMeditation, typeof(UltimateMasterMeditation) },
			{ TownChampionType.UltimateMasterMiner, typeof(UltimateMasterMiner) },
			{ TownChampionType.UltimateMasterMusician, typeof(UltimateMasterMusician) },
			{ TownChampionType.UltimateMasterMysticism, typeof(UltimateMasterMysticism) },
			{ TownChampionType.UltimateMasterNecromancer, typeof(UltimateMasterNecromancer) },
			{ TownChampionType.UltimateMasterNinjitsu, typeof(UltimateMasterNinjitsu) },
			{ TownChampionType.UltimateMasterParrying, typeof(UltimateMasterParrying) },
			{ TownChampionType.UltimateMasterPeacemaker, typeof(UltimateMasterPeacemaker) },
			{ TownChampionType.UltimateMasterPoisoner, typeof(UltimateMasterPoisoner) },
			{ TownChampionType.UltimateMasterProvocation, typeof(UltimateMasterProvocation) },
			{ TownChampionType.UltimateMasterRemoveTrap, typeof(UltimateMasterRemoveTrap) },
			{ TownChampionType.UltimateMasterSnooping, typeof(UltimateMasterSnooping) },
			{ TownChampionType.UltimateMasterSpellweaver, typeof(UltimateMasterSpellweaver) },
			{ TownChampionType.UltimateMasterSpiritSpeak, typeof(UltimateMasterSpiritSpeak) },
			{ TownChampionType.UltimateMasterStealth, typeof(UltimateMasterStealth) },
			{ TownChampionType.UltimateMasterSwordsman, typeof(UltimateMasterSwordsman) },
			{ TownChampionType.UltimateMasterTactician, typeof(UltimateMasterTactician) },
			{ TownChampionType.UltimateMasterTailor, typeof(UltimateMasterTailor) },
			{ TownChampionType.UltimateMasterTasteIdentification, typeof(UltimateMasterTasteIdentification) },
			{ TownChampionType.UltimateMasterThief, typeof(UltimateMasterThief) },
			{ TownChampionType.UltimateMasterThrowing, typeof(UltimateMasterThrowing) },
			{ TownChampionType.UltimateMasterTinkering, typeof(UltimateMasterTinkering) },
			{ TownChampionType.UltimateMasterTracker, typeof(UltimateMasterTracker) },
			{ TownChampionType.UltimateMasterVeterinary, typeof(UltimateMasterVeterinary) },
			{ TownChampionType.UltimateMasterWrestling, typeof(UltimateMasterWrestling) },
			
            // Add additional mappings here as you expand.
        };
    }

    #endregion

    #region Tension Invasion Scheduler

    public static class TensionInvasionScheduler
    {
        private static Timer _schedulerTimer;

        public static void Initialize()
        {
            // Check every hour (initial delay and repeat interval set to 1 hour)
           // _schedulerTimer = Timer.DelayCall(TimeSpan.FromHours(1), TimeSpan.FromHours(1), CheckAndScheduleInvasions);
			
            // Register admin command for manual checking
            CommandSystem.Register("CheckTensionInvasions", AccessLevel.Administrator, CheckTensionInvasions_OnCommand);			
        }

        [Usage("CheckTensionInvasions")]
        [Description("Manually checks the current tension and calculates how many towns would be invaded.")]
        public static void CheckTensionInvasions_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            int tension = TensionManager.Tension;
            from.SendMessage($"[Tension Debug] Current Tension: {tension}");

            if (tension < 10000)
            {
                from.SendMessage("[Tension Debug] Not enough tension to trigger an invasion. Minimum required: 10,000.");
                return;
            }

            // Calculate proportion based on tension (range: 10,000 to 100,000)
            double proportion = (tension - 10000) / 200000.0;
            if (proportion > 1.0)
                proportion = 1.0;

            int totalTowns = Enum.GetNames(typeof(InvasionTowns)).Length;
            int townsToInvade = (int)Math.Round(proportion * totalTowns);
            if (townsToInvade < 1)
                townsToInvade = 1;

            from.SendMessage($"[Tension Debug] Invasion Calculation: {townsToInvade} town(s) would be invaded.");

            // Optionally, allow the admin to trigger the invasion manually
            if (e.Arguments.Length > 0 && e.Arguments[0].ToLower() == "start")
            {
                from.SendMessage("[Tension Debug] Manually triggering invasions!");
                TriggerInvasions(townsToInvade);
            }
        }

        private static void TriggerInvasions(int townsToInvade)
        {
            // Reduce tension by 500 each time invasions are triggered (ensuring it never goes below 0)
            TensionManager.Tension = Math.Max(0, TensionManager.Tension - 1000);

            List<InvasionTowns> availableTowns = new List<InvasionTowns>();
            foreach (InvasionTowns town in Enum.GetValues(typeof(InvasionTowns)))
            {
                bool isInvaded = InvasionControl.Invasions.Exists(inv => inv.InvasionTown == town);
                if (!isInvaded)
                    availableTowns.Add(town);
            }

            if (availableTowns.Count == 0)
                return;

            if (townsToInvade > availableTowns.Count)
                townsToInvade = availableTowns.Count;

            // Determine the current tier based on the current tension
            int currentTier = InvasionTierHelper.GetTier(TensionManager.Tension);

            // Get cumulative lists of monster and champion types for this tier
            List<TownMonsterType> monsterOptions = InvasionTierHelper.GetMonsterTypesForTier(currentTier);
            List<TownChampionType> championOptions = InvasionTierHelper.GetChampionTypesForTier(currentTier);

            for (int i = 0; i < townsToInvade; i++)
            {
                int index = Utility.Random(availableTowns.Count);
                InvasionTowns selectedTown = availableTowns[index];
                availableTowns.RemoveAt(index);

                // Pick a random type from the available lists
                TownMonsterType monster = monsterOptions[Utility.Random(monsterOptions.Count)];
                TownChampionType champion = championOptions[Utility.Random(championOptions.Count)];
                DateTime startTime = DateTime.UtcNow;

                new TownInvasion(selectedTown, monster, champion, startTime);
				var invasion = new TownInvasion(selectedTown, monster, champion, DateTime.UtcNow);
				invasion.OnStart(); // call it directly
            }
        }

        private static void CheckAndScheduleInvasions()
        {
            // Reduce tension by 500 every hour (to a minimum of zero)
            TensionManager.Tension = Math.Max(0, TensionManager.Tension - 1000);
            int tension = TensionManager.Tension;

            // Only trigger invasions if tension is at least 10,000
            if (tension < 10000)
                return;

            // Calculate proportion based on tension (range: 10,000 to 100,000)
            double proportion = (tension - 10000) / 90000.0;
            if (proportion > 1.0)
                proportion = 1.0;

            int totalTowns = Enum.GetNames(typeof(InvasionTowns)).Length;
            int townsToInvade = (int)Math.Round(proportion * totalTowns);
            if (townsToInvade < 1)
                townsToInvade = 1;

            List<InvasionTowns> availableTowns = new List<InvasionTowns>();
            foreach (InvasionTowns town in Enum.GetValues(typeof(InvasionTowns)))
            {
                bool isInvaded = InvasionControl.Invasions.Exists(inv => inv.InvasionTown == town);
                if (!isInvaded)
                    availableTowns.Add(town);
            }

            if (availableTowns.Count == 0)
                return;

            if (townsToInvade > availableTowns.Count)
                townsToInvade = availableTowns.Count;

            // For each invasion to schedule...
            for (int i = 0; i < townsToInvade; i++)
            {
                int index = Utility.Random(availableTowns.Count);
                InvasionTowns selectedTown = availableTowns[index];
                availableTowns.RemoveAt(index);

                // Determine current tier and get options
                int currentTier = InvasionTierHelper.GetTier(tension);
                List<TownMonsterType> monsterOptions = InvasionTierHelper.GetMonsterTypesForTier(currentTier);
                List<TownChampionType> championOptions = InvasionTierHelper.GetChampionTypesForTier(currentTier);

                TownMonsterType monster = monsterOptions[Utility.Random(monsterOptions.Count)];
                TownChampionType champion = championOptions[Utility.Random(championOptions.Count)];
                DateTime startTime = DateTime.UtcNow;

                new TownInvasion(selectedTown, monster, champion, startTime);
				var invasion = new TownInvasion(selectedTown, monster, champion, DateTime.UtcNow);
				invasion.OnStart(); // call it directly
            }
        }
    }

    #endregion

    #region Town Invasion

	public class InvasionTownInfo
	{
		public Point3D Top { get; set; }
		public Point3D Bottom { get; set; }
		public int MinSpawnZ { get; set; }
		public int MaxSpawnZ { get; set; }
		public Map SpawnMap { get; set; }
		public string TownName { get; set; }
	}

	public static class InvasionTownInfoDefs
	{
		public static readonly Dictionary<InvasionTowns,InvasionTownInfo> Regions = 
			new Dictionary<InvasionTowns,InvasionTownInfo>
		{
			// >>> EXISTING ONES YOU ALREADY HAVE <<<
			[InvasionTowns.BuccaneersDen] = new InvasionTownInfo { Top = new Point3D(2608, 2060, 0), Bottom = new Point3D(2824, 2296, 0), MinSpawnZ = 50, MaxSpawnZ = 61, SpawnMap = Map.Felucca, TownName = "Buccaneer's Den" },
			[InvasionTowns.Cove] = new InvasionTownInfo { Top = new Point3D(2213, 1148, 0), Bottom = new Point3D(2284, 1233, 0), MinSpawnZ = 50, MaxSpawnZ = 61, SpawnMap = Map.Felucca, TownName = "Cove" },
			[InvasionTowns.Delucia] = new InvasionTownInfo { Top = new Point3D(5171, 3980, 41), Bottom = new Point3D(5300, 4040, 39), MinSpawnZ = 29, MaxSpawnZ = 32, SpawnMap = Map.Felucca, TownName = "Delucia" },
			[InvasionTowns.Jhelom] = new InvasionTownInfo { Top = new Point3D(1304, 3682, 0), Bottom = new Point3D(1465, 3877, 0), MinSpawnZ = 50, MaxSpawnZ = 61, SpawnMap = Map.Felucca, TownName = "Jhelom" },
			[InvasionTowns.Minoc] = new InvasionTownInfo { Top = new Point3D(2443, 420, 15), Bottom = new Point3D(2520, 539, 0), MinSpawnZ = 10, MaxSpawnZ = 16, SpawnMap = Map.Felucca, TownName = "Minoc" },
			[InvasionTowns.Moonglow] = new InvasionTownInfo { Top = new Point3D(4394, 1058, 30), Bottom = new Point3D(4481, 1173, 0), MinSpawnZ = 50, MaxSpawnZ = 61, SpawnMap = Map.Felucca, TownName = "Moonglow" },
			[InvasionTowns.Nujel] = new InvasionTownInfo { Top = new Point3D(3665, 1189, 0), Bottom = new Point3D(3774, 1357, 0), MinSpawnZ = 50, MaxSpawnZ = 61, SpawnMap = Map.Felucca, TownName = "Nujel'm" },
			[InvasionTowns.Ocllo] = new InvasionTownInfo { Top = new Point3D(3617, 2482, 0), Bottom = new Point3D(3712, 2630, 20), MinSpawnZ = 5, MaxSpawnZ = 21, SpawnMap = Map.Felucca, TownName = "Ocllo" },
			[InvasionTowns.Papua] = new InvasionTownInfo { Top = new Point3D(5644, 3112, -15), Bottom = new Point3D(5826, 3315, 0), MinSpawnZ = 50, MaxSpawnZ = 61, SpawnMap = Map.Felucca, TownName = "Papua" },
			[InvasionTowns.SkaraBrae] = new InvasionTownInfo { Top = new Point3D(577, 2131, -90), Bottom = new Point3D(634, 2234, -90), MinSpawnZ = 25, MaxSpawnZ = 65, SpawnMap = Map.Felucca, TownName = "Skara Brae" },
			[InvasionTowns.Yew] = new InvasionTownInfo { Top = new Point3D(452, 928, 0), Bottom = new Point3D(669, 1104, 0), MinSpawnZ = 50, MaxSpawnZ = 61, SpawnMap = Map.Felucca, TownName = "Yew" },
			[InvasionTowns.Vesper] = new InvasionTownInfo { Top = new Point3D(2835, 656, 0), Bottom = new Point3D(2940, 988, 0), MinSpawnZ = 50, MaxSpawnZ = 61, SpawnMap = Map.Felucca, TownName = "Vesper" },
			[InvasionTowns.HedgeMaze] = new InvasionTownInfo { Top = new Point3D(1032, 2159, 0), Bottom = new Point3D(1256, 2304, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Hedge Maze" },
			[InvasionTowns.DungeonDestard] = new InvasionTownInfo { Top = new Point3D(5121, 769, 0), Bottom = new Point3D(5372, 1020, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Destard" },
			[InvasionTowns.BritainCemetery] = new InvasionTownInfo { Top = new Point3D(1336, 1443, 0), Bottom = new Point3D(1390, 1493, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Britain Cemetery" },
			[InvasionTowns.DungeonShame_Level1] = new InvasionTownInfo { Top = new Point3D(5376, 0, 0), Bottom = new Point3D(5503, 127, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Shame (Level 1)" },
			[InvasionTowns.DungeonShame_Level2] = new InvasionTownInfo { Top = new Point3D(5505, 0, 0), Bottom = new Point3D(5363, 127, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Shame (Level 2)" },
			[InvasionTowns.DungeonShame_Level3] = new InvasionTownInfo { Top = new Point3D(5376, 131, 0), Bottom = new Point3D(5630, 256, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Shame (Level 3)" },
			[InvasionTowns.IceDungeon] = new InvasionTownInfo { Top = new Point3D(5663, 128, 0), Bottom = new Point3D(5892, 263, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Ice Dungeon" },
			[InvasionTowns.IceDemonLair] = new InvasionTownInfo { Top = new Point3D(5650, 319, 0), Bottom = new Point3D(5774, 370, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Ice Demon Lair" },
			[InvasionTowns.DungeonHythloth_Level1] = new InvasionTownInfo { Top = new Point3D(5889, 0, 0), Bottom = new Point3D(6005, 117, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Hythloth (Level 1)" },
			[InvasionTowns.DungeonDeceit_Level1] = new InvasionTownInfo { Top = new Point3D(5128, 521, 0), Bottom = new Point3D(5239, 642, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Deceit (Level 1)" },
			[InvasionTowns.DungeonDespise_Level1] = new InvasionTownInfo { Top = new Point3D(5377, 511, 0), Bottom = new Point3D(5517, 639, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Despise (Level 1)" },
			[InvasionTowns.DungeonWrong_Level1] = new InvasionTownInfo { Top = new Point3D(5775, 512, 0), Bottom = new Point3D(5892, 634, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Wrong (Level 1)" },
			[InvasionTowns.DungeonKhaldun] = new InvasionTownInfo { Top = new Point3D(5377, 1281, 0), Bottom = new Point3D(5627, 1512, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Khaldun" },
			[InvasionTowns.FireDungeon_Level1] = new InvasionTownInfo { Top = new Point3D(5765, 1281, 0), Bottom = new Point3D(5884, 1417, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Fire Dungeon (Level 1)" },
			[InvasionTowns.DungeonDoom] = new InvasionTownInfo { Top = new Point3D(249, 0, 0), Bottom = new Point3D(515, 257, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Malas, TownName = "Dungeon Doom" },
			[InvasionTowns.Bedlam] = new InvasionTownInfo { Top = new Point3D(71, 1564, 0), Bottom = new Point3D(211, 1690, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Malas, TownName = "Bedlam" },
			[InvasionTowns.SorcerersDungeon_Level1] = new InvasionTownInfo { Top = new Point3D(365, 0, 0), Bottom = new Point3D(483, 116, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Sorcerer’s Dungeon (Level 1)" },
			[InvasionTowns.SerpentinePassage] = new InvasionTownInfo { Top = new Point3D(382, 1497, 0), Bottom = new Point3D(542, 1596, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Serpentine Passage" },
			[InvasionTowns.DungeonAnkh] = new InvasionTownInfo { Top = new Point3D(0, 1247, 0), Bottom = new Point3D(183, 1584, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "Dungeon Ankh" },
			// ——— MISSING FROM QuestScroll.PlacesX ———

			// Shame levels/areas
			[InvasionTowns.DungeonShame_Level5] = new InvasionTownInfo { Top = new Point3D(5636, 0, 0), Bottom = new Point3D(5893, 126, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Shame (Level 5)" },
			[InvasionTowns.DungeonShame_MageTowers1] = new InvasionTownInfo { Top = new Point3D(5431, 175, 0), Bottom = new Point3D(5455, 199, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Shame Mage Towers" },
			[InvasionTowns.DungeonShame_MageTowers2] = new InvasionTownInfo { Top = new Point3D(5567, 183, 0), Bottom = new Point3D(5591, 207, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Shame Mage Towers" },

			// Ice Ratman Fort
			[InvasionTowns.IceRatmanFort] = new InvasionTownInfo { Top = new Point3D(5795, 313, 0), Bottom = new Point3D(5866, 384, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Ratman Fort" },

			// Hythloth levels
			[InvasionTowns.DungeonHythloth_Level2] = new InvasionTownInfo { Top = new Point3D(5905, 136, 0), Bottom = new Point3D(6002, 244, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Hythloth (Level 2)" },
			[InvasionTowns.DungeonHythloth_Level3] = new InvasionTownInfo { Top = new Point3D(6025, 134, 0), Bottom = new Point3D(6133, 237, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Hythloth (Level 3)" },
			[InvasionTowns.DungeonHythloth_Level4] = new InvasionTownInfo { Top = new Point3D(6037, 22, 0), Bottom = new Point3D(6125, 110, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Hythloth (Level 4)" },

			// Deceit levels
			[InvasionTowns.DungeonDeceit_Level2] = new InvasionTownInfo { Top = new Point3D(5270, 523, 0), Bottom = new Point3D(5356, 636, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Deceit (Level 2)" },
			[InvasionTowns.DungeonDeceit_Level3] = new InvasionTownInfo { Top = new Point3D(5124, 644, 0), Bottom = new Point3D(5233, 768, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Deceit (Level 3)" },
			[InvasionTowns.DungeonDeceit_Level4] = new InvasionTownInfo { Top = new Point3D(5249, 640, 0), Bottom = new Point3D(5339, 764, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Deceit (Level 4)" },

			// Despise levels
			[InvasionTowns.DungeonDespise_Level2] = new InvasionTownInfo { Top = new Point3D(5377, 640, 0), Bottom = new Point3D(5529, 767, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Despise (Level 2)" },
			[InvasionTowns.DungeonDespise_Level3] = new InvasionTownInfo { Top = new Point3D(5375, 768, 0), Bottom = new Point3D(5633, 1022, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Despise (Level 3)" },

			// Wrong levels
			[InvasionTowns.DungeonWrong_Level2] = new InvasionTownInfo { Top = new Point3D(5635, 506, 0), Bottom = new Point3D(5745, 588, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Wrong (Level 2)" },
			[InvasionTowns.DungeonWrong_Level3] = new InvasionTownInfo { Top = new Point3D(5682, 612, 0), Bottom = new Point3D(5724, 673, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Wrong (Level 3)" },

			// Trinsic Passage
			[InvasionTowns.TrinsicPassage] = new InvasionTownInfo { Top = new Point3D(5886, 1274, 0), Bottom = new Point3D(6047, 1414, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Trinsic Passage" },

			// Fire Dungeon
			[InvasionTowns.FireDungeon_Level2] = new InvasionTownInfo { Top = new Point3D(5633, 1274, 0), Bottom = new Point3D(5763, 1398, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Fire Dungeon (Level 2)" },
			[InvasionTowns.FireDungeon_Level2b] = new InvasionTownInfo { Top = new Point3D(5630, 1383, 0), Bottom = new Point3D(5664, 1456, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Fire Dungeon (Level 2)" },
			[InvasionTowns.FireDungeon_Level1b] = new InvasionTownInfo { Top = new Point3D(5666, 1402, 0), Bottom = new Point3D(5887, 1520, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Fire Dungeon (Level 1)" },

			// Sewers
			[InvasionTowns.Sewers] = new InvasionTownInfo { Top = new Point3D(6019, 1418, 0), Bottom = new Point3D(6132, 1520, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Sewers" },

			// Terathan Keep
			[InvasionTowns.TerathanKeep] = new InvasionTownInfo { Top = new Point3D(5124, 1532, 0), Bottom = new Point3D(5376, 1784, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Terathan Keep" },

			// Solen Hive
			[InvasionTowns.SolenHive] = new InvasionTownInfo { Top = new Point3D(5639, 1780, 0), Bottom = new Point3D(5934, 2037, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "the Solen Hive" },

			// Covetous levels
			[InvasionTowns.Covetous_Level1] = new InvasionTownInfo { Top = new Point3D(5373, 1843, 0), Bottom = new Point3D(5508, 1942, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Covetous (Level 1)" },
			[InvasionTowns.Covetous_Level2] = new InvasionTownInfo { Top = new Point3D(5374, 1951, 0), Bottom = new Point3D(5622, 2045, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Covetous (Level 2)" },
			[InvasionTowns.Covetous_Level3] = new InvasionTownInfo { Top = new Point3D(5533, 1821, 0), Bottom = new Point3D(5630, 1937, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Covetous (Level 3)" },
			[InvasionTowns.Covetous_JailCells] = new InvasionTownInfo { Top = new Point3D(5491, 1791, 0), Bottom = new Point3D(5556, 1821, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Covetous (Jail Cells)" },
			[InvasionTowns.Covetous_LakeCave] = new InvasionTownInfo { Top = new Point3D(5390, 1780, 0), Bottom = new Point3D(5486, 1838, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Trammel, TownName = "Dungeon Covetous (Lake Cave)" },

			// Sorcerer's Dungeon
			[InvasionTowns.SorcerersDungeon_Level2] = new InvasionTownInfo { Top = new Point3D(196, 0, 0), Bottom = new Point3D(363, 101, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Sorcerer’s Dungeon (Level 2)" },
			[InvasionTowns.SorcerersDungeon_Level3] = new InvasionTownInfo { Top = new Point3D(52, 0, 0), Bottom = new Point3D(185, 134, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Sorcerer’s Dungeon (Level 3)" },
			[InvasionTowns.SorcerersDungeon_JailCells] = new InvasionTownInfo { Top = new Point3D(218, 104, 0), Bottom = new Point3D(251, 147, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Sorcerer’s Dungeon (Jail Cells)" },

			// Ancient Cave
			[InvasionTowns.AncientCave] = new InvasionTownInfo { Top = new Point3D(13, 658, 0), Bottom = new Point3D(134, 760, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Ancient Cave" },

			// Kirin Passage
			[InvasionTowns.KirinPassage] = new InvasionTownInfo { Top = new Point3D(0, 805, 0), Bottom = new Point3D(187, 1198, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Kirin Passage" },

			// Wisp Dungeon
			[InvasionTowns.WispDungeon_Level3] = new InvasionTownInfo { Top = new Point3D(815, 1446, 0), Bottom = new Point3D(913, 1584, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Wisp Dungeon (Level 3)" },
			[InvasionTowns.WispDungeon_Level5] = new InvasionTownInfo { Top = new Point3D(917, 1456, 0), Bottom = new Point3D(1017, 1578, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Wisp Dungeon (Level 5)" },
			[InvasionTowns.WispDungeon_Level7] = new InvasionTownInfo { Top = new Point3D(740, 1509, 0), Bottom = new Point3D(815, 1585, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Wisp Dungeon (Level 7)" },
			[InvasionTowns.WispDungeon_Level8] = new InvasionTownInfo { Top = new Point3D(746, 1460, 0), Bottom = new Point3D(792, 1495, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Wisp Dungeon (Level 8)" },

			// Ratman Mines
			[InvasionTowns.RatmanMines_Level1] = new InvasionTownInfo { Top = new Point3D(1263, 1460, 0), Bottom = new Point3D(1355, 1574, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Ratman Mines (Level 1)" },
			[InvasionTowns.RatmanMines_Level2] = new InvasionTownInfo { Top = new Point3D(1151, 1460, 0), Bottom = new Point3D(1259, 1558, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Ratman Mines (Level 2)" },

			// Spider Cave
			[InvasionTowns.SpiderCave] = new InvasionTownInfo { Top = new Point3D(1749, 941, 0), Bottom = new Point3D(1870, 1003, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Spider Cave" },

			// Spectre Dungeon
			[InvasionTowns.SpectreDungeon] = new InvasionTownInfo { Top = new Point3D(1940, 1006, 0), Bottom = new Point3D(2022, 1113, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Spectre Dungeon" },

			// Dungeon Blood
			[InvasionTowns.DungeonBlood] = new InvasionTownInfo { Top = new Point3D(2048, 825, 0), Bottom = new Point3D(2195, 1060, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "Dungeon Blood" },

			// Rock Dungeon
			[InvasionTowns.RockDungeon] = new InvasionTownInfo { Top = new Point3D(2084, 0, 0), Bottom = new Point3D(2244, 183, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "the Rock Dungeon" },

			// Dungeon Exodus
			[InvasionTowns.DungeonExodus] = new InvasionTownInfo { Top = new Point3D(1836, 9, 0), Bottom = new Point3D(2082, 210, 0), MinSpawnZ = 0, MaxSpawnZ = 0, SpawnMap = Map.Ilshenar, TownName = "Dungeon Exodus" },

			// … keep going for all the other “Places” entries …
			// DungeonHythloth_Level2, Level3, Level4
			// DungeonShame_Level5, DungeonShame_MageTowers1 & _2
			// TrinsicPassage, RatmanMines_Level1/_Level2, WispDungeon_Level3/5/7/8
			// DungeonAnkh, FireDungeon_Level2, IceDungeon, RatmanFort, RockDungeon, SolenHive, TerathanKeep
			// DungeonDoom (Map.Malas), Bedlam (Map.Malas), AncientCave, KirinPassage, SerpentinePassage, DungeonBlood, DungeonExodus
		};
	}


    public class TownInvasion
    {
        #region Private Variables

        private int _MinSpawnZ;
        private int _MaxSpawnZ;

        private bool _FinalStage;

        private Point3D _Top = new Point3D(4394, 1058, 30);
        private Point3D _Bottom = new Point3D(4481, 1173, 0);
        private Map _SpawnMap = Map.Felucca;

        private List<Mobile> _Spawned;

        private TownMonsterType _TownMonsterType = TownMonsterType.OrcsandRatmen;
        private TownChampionType _TownChampionType = TownChampionType.Barracoon;
        private InvasionTowns _InvasionTown = InvasionTowns.BuccaneersDen;
        private DateTime _StartTime;
        private bool _AlwaysMurderer = false;

        private string _TownInvaded = "Moonglow";

        private Timer _SpawnTimer;

        private DateTime _lastAnnounce = DateTime.UtcNow;

        private bool WasDisabledRegion;
        private bool Active;
        #endregion

        #region Public Variables

        public int MinSpawnZ { get { return _MinSpawnZ; } set { _MinSpawnZ = value; } }
        public int MaxSpawnZ { get { return _MaxSpawnZ; } set { _MaxSpawnZ = value; } }
        public Point3D Top { get { return _Top; } set { _Top = value; } }
        public Point3D Bottom { get { return _Bottom; } set { _Bottom = value; } }
        public Map SpawnMap { get { return _SpawnMap; } set { _SpawnMap = value; } }
        public List<Mobile> Spawned { get { return _Spawned; } set { _Spawned = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public TownMonsterType TownMonsterType { get { return _TownMonsterType; } set { _TownMonsterType = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public TownChampionType TownChampionType { get { return _TownChampionType; } set { _TownChampionType = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public InvasionTowns InvasionTown { get { return _InvasionTown; } set { _InvasionTown = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime StartTime { get { return _StartTime; } set { _StartTime = value; } }

        public bool IsRunning { get { return _SpawnTimer != null && _SpawnTimer.Running; } }
        public string TownInvaded { get { return _TownInvaded; } set { _TownInvaded = value; } }

        public Timer SpawnTimer { get { return _SpawnTimer; } set { _SpawnTimer = value; } }

        #endregion

        #region Constructors

        public TownInvasion(InvasionTowns town, TownMonsterType monster, TownChampionType champion, DateTime time)
        {
            _Spawned = new List<Mobile>();

            _InvasionTown = town;
            _TownMonsterType = monster;
            _TownChampionType = champion;
            _StartTime = time;

            InvasionControl.Invasions.Add(this);
        }

        public TownInvasion(GenericReader reader)
        {
            Deserialize(reader);
        }

        #endregion

		public void OnStart()
		{
			if (!IsRunning)
			{
				if (InvasionTownInfoDefs.Regions.TryGetValue(InvasionTown, out var info))
				{
					Top = info.Top;
					Bottom = info.Bottom;
					MinSpawnZ = info.MinSpawnZ;
					MaxSpawnZ = info.MaxSpawnZ;
					SpawnMap = info.SpawnMap;
					TownInvaded = info.TownName;
				}
				else
				{
					// Fallback/default values or throw
				}

				World.Broadcast(38, false, $"[Invasion Alert] {TownInvaded} is under attack by Minax army of {TownMonsterType}!");

				foreach (Region r in Region.Regions)
				{
					if (r is GuardedRegion && r.Name == TownInvaded)
					{
						WasDisabledRegion = ((GuardedRegion)r).Disabled;
						((GuardedRegion)r).Disabled = true;
					}
				}

				Spawn();
			}
		}



        public void OnStop()
        {
            Despawn();

            if (!WasDisabledRegion)
            {
                foreach (Region r in Region.Regions)
                {
                    if (r is GuardedRegion && r.Name == TownInvaded)
                    {
                        ((GuardedRegion)r).Disabled = false;
                    }
                }
            }

            if (_SpawnTimer != null)
                _SpawnTimer.Stop();

            InvasionControl.Invasions.Remove(this);
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0);
            writer.Write((int)InvasionTown);
            writer.Write((int)TownMonsterType);
            writer.Write((int)TownChampionType);
            writer.Write(StartTime);
            writer.Write(Spawned);

            Active = IsRunning;
            writer.Write(Active);
        }

        public void Deserialize(GenericReader reader)
        {
            int version = reader.ReadInt();
            InvasionTown = (InvasionTowns)reader.ReadInt();
            TownMonsterType = (TownMonsterType)reader.ReadInt();
            TownChampionType = (TownChampionType)reader.ReadInt();
            StartTime = reader.ReadDateTime();
            Spawned = reader.ReadStrongMobileList();
            Active = reader.ReadBool();

            if (Spawned == null)
                Spawned = new List<Mobile>();

            if (Active)
                InitTimer();
        }

        #region Private Methods

        private static void GlobalSync()
        {
            int index = InvasionControl.Invasions.Count;
            while (--index >= 0)
            {
                if (index >= InvasionControl.Invasions.Count)
                    continue;

                TownInvasion obj = InvasionControl.Invasions[index];
                if (obj._StartTime <= DateTime.UtcNow)
                    obj.OnStart();
            }
        }

        private void InitTimer()
        {
            if (!IsRunning)
                _SpawnTimer = Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromSeconds(15.0), CheckSpawn);
        }

        /// <summary>
        /// Spawns monsters using the registry to retrieve the proper entries.
        /// </summary>
        private void Spawn()
        {
            Despawn();

            MonsterTownSpawnEntry[] entries;
            if (!InvasionTypeRegistry.MonsterSpawns.TryGetValue(_TownMonsterType, out entries))
            {
                Console.WriteLine($"[Invasion] No spawn entries defined for {_TownMonsterType}.");
                return;
            }

            foreach (var entry in entries)
                for (int i = 0; i < entry.Amount; i++)
                    AddMonster(entry.Monster);

            if (_Spawned.Count == 0)
            {
                OnStop();
                return;
            }

            InitTimer();
        }

        /// <summary>
        /// Uses the registry to spawn the champion.
        /// </summary>
        public void SpawnChamp()
        {
            Despawn();
            _FinalStage = true;

            Type champType;
            if (InvasionTypeRegistry.ChampionSpawns.TryGetValue(_TownChampionType, out champType))
            {
                AddMonster(champType);
            }
            else
            {
                Console.WriteLine($"[Invasion] No champion spawn defined for {_TownChampionType}.");
            }
        }

        public void CheckSpawn()
        {
            int count = 0;
            for (int i = 0; i < _Spawned.Count; i++)
                if (_Spawned[i] != null && !_Spawned[i].Deleted && _Spawned[i].Alive)
                    count++;

            if (!_FinalStage)
            {
                // If all monsters are slain, advance to champion spawn.
                if (count == 0)
                    SpawnChamp();
            }
            else
            {
                // If the champion is slain, stop the invasion after a delay.
                if (count == 0)
                    Timer.DelayCall(TimeSpan.FromMinutes(5), OnStop);
            }

            if (DateTime.UtcNow >= _lastAnnounce + TimeSpan.FromMinutes(1))
            {
                string message = string.Format("{0} is being invaded by {1}. Please come help!", TownInvaded, TownMonsterType);
                foreach (TownCrier tc in TownCrier.Instances)
                {
                    tc.PublicOverheadMessage(MessageType.Yell, 0, false, message);
                }
                _lastAnnounce = DateTime.UtcNow;
            }
        }

        private void Despawn()
        {
            foreach (Mobile m in _Spawned)
            {
                if (m != null && !m.Deleted)
                    m.Delete();
            }

            _Spawned.Clear();
            _FinalStage = false;
        }

        private Point3D FindSpawnLocation()
        {
            int x, y, z;
            int count = 100;
            do
            {
                x = Utility.Random(_Top.X, (_Bottom.X - _Top.X));
                y = Utility.Random(_Top.Y, (_Bottom.Y - _Top.Y));
                z = SpawnMap.GetAverageZ(x, y);
            }
            while (!SpawnMap.CanSpawnMobile(x, y, z) && --count >= 0);
            if (count < 0)
            {
                x = y = z = 0;
            }
            return new Point3D(x, y, z);
        }

        private void AddMonster(Type type)
        {
            object monster = Activator.CreateInstance(type);
            if (monster != null && monster is Mobile)
            {
                Point3D location = FindSpawnLocation();
                if (location == Point3D.Zero)
                    return;

                Mobile mob = (Mobile)monster;
                mob.OnBeforeSpawn(location, SpawnMap);
                mob.MoveToWorld(location, SpawnMap);
                mob.OnAfterSpawn();
                if (mob is BaseCreature)
                    ((BaseCreature)mob).Tamable = false;

                _Spawned.Add(mob);
            }
        }

        #endregion
    }

    #endregion
}
