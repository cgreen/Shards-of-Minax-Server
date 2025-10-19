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
    [CorpseName("the remains of a Minoc citizen")]
    public class CitizenOfMinoc : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // Equipment pool: Minoc-appropriate clothing/tools only!
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

        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>( StringComparer.OrdinalIgnoreCase )
        {
            // Shoes or boots are common
            { "Footwear",   new SlotDef(0.95,
                 () => new Boots(), 
                 () => new Sandals(), 
                 () => new Shoes(),
                 () => new ThighBoots()
            )},

            // Aprons and work shirts often
            { "Apron",      new SlotDef(0.80,
                () => new FullApron(),
                () => new HalfApron()
            )},

            { "Shirt",      new SlotDef(0.75,
                () => new Shirt(), 
                () => new Tunic(),
                () => new FancyShirt(),
                () => new FloppyHat(), // not a shirt, but gives character
                () => new JesterHat() // some Minoc citizens are colorful!
            )},

            // Leggings or simple pants
            { "Legs",       new SlotDef(0.90,
                 () => new LongPants(), 
                 () => new ShortPants(),
                 () => new LeatherShorts()
            )},

            // Overalls (not in default UO, but if you have them!)
            // { "Overalls", new SlotDef(0.25, () => new Overalls() )},

            // Simple headgear, bandana or straw hat
            { "Head",       new SlotDef(0.40,
                () => new StrawHat(),
                () => new Bandana(),
                () => new Cap()
            )},

            // Hands: rarely gloves for smiths/miners
            { "Hands",      new SlotDef(0.20,
                 () => new LeatherGloves(),
                 () => new PlateGloves()
            )},

            // Tool or weapon: most commonly a pickaxe, hatchet, or shovel
            { "RightHand",  new SlotDef(0.60,
                () => new Pickaxe(),
                () => new Shovel(),
                () => new Hatchet(),
                () => new SmithHammer()
            )},

            // Shield: very rare
            { "LeftHand",   new SlotDef(0.05,
                () => new Buckler()
            )},
        };

        // **Quests: Only Minoc faction quests. Edit/expand as needed!**
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            () => new FactionCollectionQuestScroll("IronIngot", 30, "Minoc", 500), // Collect ingots for Minoc
            () => new FactionDeliveryQuestScroll("Tools Delivery", "Minoc", 300), // Deliver tools
            () => new FactionKillQuestScroll("Orc", 12, "Minoc", 900),
			
            () => new FactionCollectionQuestScroll("MellowGourdFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("SilverFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("MysteryFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("VoidPulasanFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("TransparentAurarus", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("WheatSeed", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("SmallBananaSeed", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("PygmyOrangeFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("BroccoliSeed", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("MiniApricotSeed", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("FishingPole", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("satilFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("otilFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("wriggumondFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("krevaFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Chronodyne", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("GaseousAesthogen", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("BitterHopsSeed", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("rephoneFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Hinge", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("NegativePhocite", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Thoril", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("OpaqueHydragyon", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("FishBowl", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("unaFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Vibranide", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("AxleGears", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("CauliflowerSeed", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Axle", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("SextantParts", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("slomeloFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("FlaxSeed", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Impervanium", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("MetalContainerEngraver", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Flurocite", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("ittianaFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Candelabra", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("geweodineFruit", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("MiniPeachSeed", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Omniplasium", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("Springs", 25, "Minoc", 750),
            () => new FactionCollectionQuestScroll("ingeFruit", 25, "Minoc", 750),			

            () => new FactionKillQuestScroll("MinaxSorceress", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("MischievousWitch", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("MotownMermaid", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("MushroomWitch", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("Musketeer", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("NeoVictorianVampire", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("NinjaLibrarian", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("NoirDetective", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("OgreMaster", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PhoenixStyleMaster", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PigFarmer", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PinupPandemonium", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("pirate", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PirateOfTheStars", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PKMurderer", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PKMurdererLord", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PoisonAppleTree", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PsychedelicShaman", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PulpyPotionPurveyor", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("PunkRockPaladin", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RaKing", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RanchMaster", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RapRanger", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RaveRogue", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RedQueen", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("ReggaeRunesmith", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RenaissanceMechanic", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RetroAndroid", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RetroFuturist", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RetroRobotRomancer", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("Ringmaster", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RockabillyRevenant", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("scorpomancer", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SilentMovieMonk", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SilverSlime", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("Sith", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SkaSkald", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SkeletonLord", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SlimeMage", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SneakyNinja", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("StarCitizen", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("StarfleetCaptain", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("StarfleetOfficer", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SteampunkSamurai", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("Stormtrooper2", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SurferSummoner", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SwampThing", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SwinginSorceress", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("TexanRancher", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("TwistedCultist", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("VaudevilleValkyrie", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("WastelandBiker", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("WaterClanNinja", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("WaterClanSamurai", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("WildWestWizard", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("AncientHellhound", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("Boura", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("MagicalPig", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RidablePolarBear", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RidableSerpentineDragon", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("RidableTarantula", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("SkeletonHorse", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("BioluminescentFungus", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("BlightedEfreet", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("BlightedShadow", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("ColossalBlackWidow", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("CorrodedArmour", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("CorruptedMinotaurCaptain", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("DeathlyWatchBeetle", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("DecayboundOrcishMage", "5", "Minoc", "500"),
            () => new FactionKillQuestScroll("DecayedMage", "5", "Minoc", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Minoc, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Minoc, 350),				

			
            // Add more Minoc-relevant quest types if you want
        };

        // --- Random Minoc-appropriate names/titles ---
        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Wilfred", "Edwin", "Gertrude", "Marnie", "Albert", "Tilda", "Oswin", "Rowan", "Mira",
                "Hilda", "Beorn", "Erik", "Agnes", "Fergus", "Clara", "Rufus", "Ingrid", "Leofric",
                "Matilda", "Otto", "Bran", "Sibyl", "Ivor", "Lina", "Greta", "Magnus", "Blythe",
                "Dale", "Tamsin", "Lars", "Oskar", "Runa"
            };

            string[] lastNames = new[]
            {
                "Smith", "Ironhand", "Stonebreaker", "Copperfield", "Oreheart", "Coalbeard", "Timberfell", "Oakenshield",
                "Sawyer", "Carter", "Nailer", "Clothier", "Potter", "Wainwright", "Collier", "Mason", "Plank",
                "Gilder", "Turner", "Chiseler", "Brassard", "Cobbler", "Miner", "Thatcher", "Tanner", "Fletcher",
                "Gravel", "Cartwright", "Soot", "Hewer", "Barrowman", "Walker"
            };

            string[] titles = new[]
            {
                "the Miner",
                "the Smith",
                "the Woodworker",
                "the Blacksmith",
                "the Apprentice",
                "the Laborer",
                "the Pauper",
                "the Cooper",
                "the Carter",
                "the Mason",
                "the Carver",
                "the Woodcutter",
                "the Tanner",
                "the Beggar",
                "the Scrapper",
                "the Prospector",
                "the Ironmonger",
                "the Wheelwright",
                "the Peasant",
                "the Refugee",
                "the Scavenger",
                "the Tinkerer",
                "the Sawmill Hand",
                "the Chimney Sweep",
                "the Ragpicker",
                "the Brickmaker",
                "the Forgeman",
                "the Toolmaker",
                "the Ditcher",
                "the Forager",
                "the Tent-dweller",
                "the Drifter",
                "the Wanderer",
                "the Camp Warden",
                "the Cart Puller",
                "the Sootface",
                "of Minoc"
            };

            string first = firstNames[Utility.Random(firstNames.Length)];
            string last = lastNames[Utility.Random(lastNames.Length)];
            string title = titles[Utility.Random(titles.Length)];

            return $"{first} {last} {title}";
        }

        [Constructable]
        public CitizenOfMinoc()
            : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
        {
            InitBody();
            InitOutfit();
            XmlAttach.AttachTo(this, new XmlRandomTraits());
            XmlAttach.AttachTo(this, new XmlDynamicVendor());
            SpecialLootHelper.AddLoot(this);
        }

        private void InitBody()
        {
            Female = Utility.RandomBool();
            Body = Female ? 0x191 : 0x190;
            Hue = Utility.RandomSkinHue();
            string fullName = GenerateRandomName();
            string[] parts = fullName.Split(new[] { ' ' }, 3);

            if (parts.Length >= 2)
            {
                Name = parts[0] + " " + parts[1];
                Title = parts.Length > 2 ? parts[2] : "";
            }
            else
            {
                Name = fullName;
                Title = "";
            }
            SetStr(Utility.RandomMinMax(40, 90));
            SetDex(Utility.RandomMinMax(35, 80));
            SetInt(Utility.RandomMinMax(30, 70));
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
                    item.Hue = Utility.RandomMinMax(900, 1500);
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1, 3000);
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
                player.SendMessage("Here, take this Minoc quest scroll!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfMinoc _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfMinoc npc)
                : base(6156) // “Talk” icon id
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
        public CitizenOfMinoc(Serial serial) : base(serial) { }

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
    }
}
