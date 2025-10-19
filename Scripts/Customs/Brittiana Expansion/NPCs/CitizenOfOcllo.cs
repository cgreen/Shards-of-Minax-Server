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
    [CorpseName("the remains of a humble villager")]
    public class CitizenOfOcllo : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // -------------- Ocllo Equipment Pool --------------
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

        // Only simple clothing/equipment
        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            { "Footwear",   new SlotDef(0.95,
                () => new Sandals(),
                () => new Shoes(),
                () => new Boots()
            )},

            { "Shirt",      new SlotDef(1.0, // always has shirt/tunic
                () => new Shirt(),
                () => new Tunic(),
                () => new FancyShirt(),
                () => new Doublet()
            )},

            { "Pants",      new SlotDef(1.0, // always has pants/skirt
                () => new LongPants(),
                () => new ShortPants(),
                () => new Skirt(),
                () => new Kilt()
            )},

            { "Apron",      new SlotDef(0.40,
                () => new HalfApron(),
                () => new FullApron()
            )},

            { "Outerwear",  new SlotDef(0.30,
                () => new Cloak(),
                () => new BodySash()
            )},

            // Headwear only straw hats or nothing
            { "Head",       new SlotDef(0.25,
                () => new StrawHat(),
                () => new Bonnet()
            )},

            // Ocllo is known for shepherds/herders/tamers, give crook or staff sometimes
            { "Hands",      new SlotDef(0.20,
                () => new ShepherdsCrook(),
                () => new Pitchfork(),
                () => new QuarterStaff()
            )}
        };

        // ------------- Ocllo Quest Scroll Pool (all Ocllo faction) -------------
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // All quests forced to Ocllo faction:
            () => new FactionCollectionQuestScroll("Wool", 15, "Ocllo", 500),
            () => new FactionCollectionQuestScroll("Bandage", 12, "Ocllo", 300),
			
            () => new FactionCollectionQuestScroll("ClockFrame", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("GroundPearFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("MiniAvocadoSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("TeaSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("SweetBoquilaFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("NightCabbageFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("OatsSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Voidanate", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("AquariumFood", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Pyrolythene", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("xekraFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Arcvaloxate", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("kleopeFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("WonderRambutanFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("VoidSproutFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("PansySeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("kledamiaFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("GraveNylon", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("iddiochokeFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("VacationWafer", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("NightmareSaguaroFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("phecceayoteFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("GreenBeanSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("CarrotSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Schizonite", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("EasternBacuriFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Darkspirite", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("earolaFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("grutatoFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("EmberLaurelFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("MiniCherrySeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("xemeloFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("SnowHopsSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("AquariumFishNet", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Duskenium", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("SpiritRoseSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("piokinFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("SunFlowerSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("siheonachFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("glissidillaFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("echocadoFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("VoidBrambleFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("SnapdragonSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("AquariumEastDeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Synthionide", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Thermodrithium", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("XeenBerryFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("hialoupeFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("LoveKumquatFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("MorphicHeteril", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("CoconutSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Spectrovanate", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("AsparagusSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("StormBrambleFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("PeaceNectarineFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("PeasSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Hatchet", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("Starshardine", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("BlackRaspberrySeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("ExoticEun", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("vuveFruit", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("MiniCoffeeSeed", 25, "Ocllo", 750),
            () => new FactionCollectionQuestScroll("TanGingerSeed", 25, "Ocllo", 750),			

            () => new FactionKillQuestScroll("StonyGolath", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Anachronaut", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("AtomicRaptor", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("ChoirWraith", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("ChronoColossus", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("ContainmentSpill", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Continuant", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Cosplayer", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("CryoToad", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("CuPatternVatbeast", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("DigitalPhantom", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("EchoWielder", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("EtheralCitizen", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("FurnaceDrakeMK1", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("HemoglintStryga", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Hemovulpine", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("HexaSeraph", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("ImperiumSteed", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("ImperiumWatcher", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Meatformer", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("MemoryRot", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("MiasmaResiduum", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Phasebeak", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("ProtocolDragonX", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("RoosterUnitC7Warcluck", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("SigilCrawler", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("SolenDroneBeta", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("StingerClassSentinel", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("SupplyBeastV44", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("SyntheticOphidian", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("TauEngine", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("TheArchivist", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Unit12", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("VaultCeratops3", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("VaultDrone", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("VaultKitty", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("VaultSentinelX8", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("AnointedBonePriest", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("BloodOfThePharaoh", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("CamelSpider", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("CursedAir", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("CursedCorpse", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("CursedMolar", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("CursedTree", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("CursedVine", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("DesertBear", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("DesertGrizzly", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("DesertHopper", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("DryadOfTheDunes", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("DuneWolf", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("EliteMummy", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("FlameOfTheNile", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("HieroglyphMage", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("MummifiedBeast", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("MummifiedOstard", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("MummifiedYomotsu", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("MummyRam", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("MummyRender", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("MysticEffervescence", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("NileRiverSerpent", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("NileSerpent", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("PharaohsSteed", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("PharaohsUnicorn", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("PyramidCrane", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("PyramidRouser", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("QueenOfTheScarabs", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("RoyalGuard", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("SacredHart", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("SandSquirrel", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Sandwurm", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("ScarabSpider", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("SphinxLizard", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("TombAmbusher", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("TombRobber", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Aurefrost", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Blightrun", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Cryvyn", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Duskwyr", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Echofern", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Faelgrim", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Fencreep", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Glazeborn", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Glimmerjack", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Gnarrox", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Graventh", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Grothuuk", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Marnstag", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Marrowth", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Nachtbram", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Nimogwai", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Nullshade", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Nyxra", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Onyxith", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Pyrrfelis", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Sangsleet", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Shaktarro", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Shavarak", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Skarnvex", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Skretchkin", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Somnira", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("SongOfTheWild", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Thessil", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Thornlash", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Toxinex", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Umbrakyn", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Velmara", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Veradrix", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Volgarith", "5", "Ocllo", "500"),
            () => new FactionKillQuestScroll("Whispent", "5", "Ocllo", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Ocllo, 350),				


			
            // ...add more simple Ocllo-flavored quests as you like
        };

        // ------------ Random Appearance/Name/Title for Ocllo -------------
        [Constructable]
        public CitizenOfOcllo()
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
                Name = parts[0] + " " + parts[1]; // first + last
                Title = parts.Length > 2 ? parts[2] : "";
            }
            else
            {
                Name = fullName;
                Title = "";
            }

            SetStr(Utility.RandomMinMax(40, 70));
            SetDex(Utility.RandomMinMax(40, 70));
            SetInt(Utility.RandomMinMax(30, 60));
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Aelfric", "Beorht", "Cuthbert", "Edith", "Godric", "Hilda", "Leofric", "Mildred", "Oswald", "Wulfric",
                "Bert", "Martha", "Eda", "Tom", "Elsie", "Will", "Peg", "Nan", "Rob", "Daisy", "Alice", "Betty", "Nell", "Owen", "Ada", "Bess"
            };

            string[] lastNames = new[]
            {
                "Goodman", "Hillman", "Atwood", "Shepherd", "Cowherd", "Carter", "Cooper", "Miller", "Potter", "Smith", "Turner", "Wooler", "Farmer", "Gardner", "Thatcher"
            };

            string[] titles = new[]
            {
                "the Shepherd", "the Cowherd", "the Dairymaid", "the Farmer", "the Tamer", "the Milker", "the Lambswooler", "the Spinner", "the Hired Hand", "the Pigkeeper", "the Goose Girl", "the Herdsman", "the Swineherd", "the Ploughman", "the Villager", "the Stable Boy", "the Dairyman", "the Shepherdess", "the Milkmaid", "the Flock Watcher", "the Haymaker", "the Churner", "the Calf Minder", "the Wool Carder"
            };

            string first = firstNames[Utility.Random(firstNames.Length)];
            string last = lastNames[Utility.Random(lastNames.Length)];
            string title = titles[Utility.Random(titles.Length)];

            return $"{first} {last} {title}";
        }

        private void InitOutfit()
        {
            foreach (var kv in _slotDefs)
            {
                if (Utility.RandomDouble() <= kv.Value.Chance)
                {
                    var factories = kv.Value.Pool;
                    var item = factories[Utility.Random(factories.Length)]();
                    // Ocllo is plain: mostly undyed or light earth tones
                    item.Hue = Utility.RandomList(0, 2425, 2419, 2105, 2117, 2130, 2406, 2407);
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomList(0, 1109, 2105, 2124, 2220, 2411, 2414); // browns, black, gray
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
                player.SendMessage($"I'm busy with chores! Come back in {wait.Minutes} minute(s).");
                return;
            }

            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;

            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("Sorry, I lost your task. Come back later!");
                return;
            }

            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("Here, take this Ocllo task scroll!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfOcllo _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfOcllo npc)
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
        public CitizenOfOcllo(Serial serial) : base(serial) { }

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
