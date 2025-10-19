using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.ContextMenus;
using Server.Engines.XmlSpawner2;
using Server.Custom;

namespace Server.Mobiles
{
    [CorpseName("the remains of a citizen of Eldermoor")]
    public class CitizenOfEldermoor : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // Rustic, simple village clothes/tools
        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            { "Footwear", new SlotDef(0.95,
                () => new Boots(),
                () => new Sandals(),
                () => new Shoes(),
                () => new ThighBoots()
            )},
            { "Head", new SlotDef(0.30,
                () => new StrawHat(),
                () => new Bandana(),
                () => new FloppyHat()
            )},
            { "Shirt", new SlotDef(0.90,
                () => new Shirt(),
                () => new Tunic(),
                () => new FancyShirt(),
                () => new Doublet()
            )},
            { "Chest", new SlotDef(0.15,
                () => new LeatherChest(),
                () => new StuddedChest()
            )},
            { "Legs", new SlotDef(0.85,
                () => new LongPants(),
                () => new ShortPants(),
                () => new Skirt()
            )},
            { "Belt", new SlotDef(0.40,
                () => new HalfApron(),
                () => new FullApron()
            )},
            { "RightHand", new SlotDef(0.35,
                () => new Pitchfork(),
                () => new ShepherdsCrook(),
                () => new ButcherKnife(),
                () => new SkinningKnife(),
                () => new Club()
            )},
            { "LeftHand", new SlotDef(0.15,
                () => new WoodenShield(),
                () => new Lantern()
            )}
        };

        // Only Faction/Eldermoor quests (not regular ones)
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            () => new FactionCollectionQuestScroll("Vegetables", 25, "Eldermoor", 500),
            () => new FactionDeliveryQuestScroll("Bandages", "Eldermoor", 200),
			
            () => new FactionCollectionQuestScroll("RangersCrossbow", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("ResonantHarp", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("RevealingAxe", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Scalpel", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("ScribeSword", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SewingNeedle", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("ShadowSai", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SilentBlade", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SleepAid", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SmithSmasher", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SnoopersPaddle", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SpellWeaversWand", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SpiritScepter", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("TacticalMultitool", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("TenFootPole", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("VeterinaryLance", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("VivisectionKnife", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("WitchBurningTorch", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("AssassinSpike", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Bokuto", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("BoneHarvester", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("BoneMachete", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Boomerang", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("ButcherKnife", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Cleaver", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("CrescentBlade", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Cyclone", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Daisho", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("DiamondMace", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("DiscMace", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Shaft", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Skillet", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SewingKit", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("FletcherTools", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SpoonLeft", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("ForkLeft", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Plate", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("KnifeLeft", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Goblet", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("PewterMug", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Clippers", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Tongs", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SledgeHammer", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Saw", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("Froe", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("FlourSifter", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("JointingPlane", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("MouldingPlane", 25, "Eldermoor", 750),
            () => new FactionCollectionQuestScroll("SmoothingPlane", 25, "Eldermoor", 750),			

            () => new FactionKillQuestScroll("ShadowToad ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("SpectralToad ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("VenomousToad ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("VileToad ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("AbyssalTide ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("AzureMirage ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("CoralSentinel ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("FrostWarden ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("HydrokineticWarden ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("MireSpawner ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("SteamLeviathan ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Stormcaller ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("TsunamiTitan ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("VortexWraith ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("AncientWolf ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("CelestialWolf ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("CursedWolf ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("EarthquakeWolf ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("EmberWolf ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("FrostbiteWolf ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("GloomWolf ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("ShadowProwler ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("StormWolf ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("VenomousWolf ", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("AnvilHurler", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("AquaticTamer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("ArcaneScribe", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("ArcticNaturalist", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("ArmorCurer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("ArrowFletcher", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("AsceticHermit", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Astrologer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Banneret", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("BattleDressmaker", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("BattlefieldHealer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("BattleWeaver", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Beastmaster", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("BigCatTamer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Biologist", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("BirdTrainer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("BoneShielder", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("BoomerangThrower", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("CabinetMaker", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Carver", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Chemist", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("ChoirSinger", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("ClockworkEngineer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("ClueSeeker", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("CombatMedic", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("CombatNurse", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("ConArtist", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Contortionist", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("CrimeSceneTech", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("CrossbowMarksman", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("CryingOrphan", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Cryptologist", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DarkSorcerer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DeathCultist", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DecoyDeployer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DeepMiner", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DemolitionExpert", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DesertNaturalist", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DesertTracker", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Diplomat", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DisguiseMaster", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Diviner", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DroneMaster", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DrumBoy", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("Drummer", "5", "Eldermoor", "500"),
            () => new FactionKillQuestScroll("DualWielder", "5", "Eldermoor", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Eldermoor, 350),				

			
        };

        // Eldermoor-style names/titles
        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Aelfric", "Beorn", "Cuthbert", "Eadric", "Edith", "Godwin", "Hilda", "Leofric", "Mildred", "Osric", "Oswald", "Wulfric", "Wynn", "Alfred", "Eadgyth"
            };
            string[] lastNames = new[]
            {
                "of Eldermoor", "the Villager", "the Farmer", "the Miller", "the Shepherd", "the Woodcutter", "the Tanner", "the Spinner", "the Miller's Son", "the Goodwife"
            };
            // No "title" field, use last name as simple title/descriptor
            return $"{firstNames[Utility.Random(firstNames.Length)]} {lastNames[Utility.Random(lastNames.Length)]}";
        }

        [Constructable]
        public CitizenOfEldermoor()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            InitBody();
            InitOutfit();
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
        }

        private void InitBody()
        {
            Female = Utility.RandomBool();
            Body = Female ? 0x191 : 0x190;
            Hue = Utility.RandomSkinHue();

            string fullName = GenerateRandomName();
            Name = fullName;
            Title = "";

            SetStr(Utility.RandomMinMax(50, 80));
            SetDex(Utility.RandomMinMax(40, 80));
            SetInt(Utility.RandomMinMax(35, 60));
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

        private void InitOutfit()
        {
            foreach (var kv in _slotDefs)
            {
                if (Utility.RandomDouble() <= kv.Value.Chance)
                {
                    var factories = kv.Value.Pool;
                    var item = factories[Utility.Random(factories.Length)]();
                    item.Hue = Utility.RandomMinMax(1501, 2016); // Earthy tones
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1001, 1150); // Browns/blonds only
            if (!Female && Utility.RandomBool())
                FacialHairItemID = Utility.RandomList(0x204B, 0x204C, 0x204D, 0x204E);
            FacialHairHue = HairHue;
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new QuestEntry(from, this));
        }

        private void TryGiveQuest(Mobile player)
        {
            if (DateTime.UtcNow < _nextQuestUtc)
            {
                TimeSpan wait = _nextQuestUtc - DateTime.UtcNow;
                player.SendMessage($"I need to restock my scrolls. Come back in {wait.Minutes} minute(s).");
                return;
            }

            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;

            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("Hmm, something went wrong. Try again later.");
                return;
            }

            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("Here, take this Eldermoor quest scroll!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfEldermoor _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfEldermoor npc)
                : base(6156)
            {
                _npc = npc;
                _from = from;
                Enabled = true;
            }

            public override void OnClick()
            {
                if (_from == null || _npc == null) return;
                _npc.TryGiveQuest(_from);
            }
        }

        // Persistence
        public CitizenOfEldermoor(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
            writer.Write(_nextQuestUtc);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            _nextQuestUtc = reader.ReadDateTime();
        }

        // Helper class for slot defs
        private class SlotDef
        {
            public double Chance;
            public Func<Item>[] Pool;
            public SlotDef(double chance, params Func<Item>[] pool)
            {
                Chance = chance;
                Pool = pool;
            }
        }
    }
}
