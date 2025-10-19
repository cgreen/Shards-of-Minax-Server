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
    [CorpseName("the remains of an Aerilonian citizen")]
    public class CitizenOfAerilon : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // --- Aerilon Equipment Pool ---
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
            { "Footwear",   new SlotDef(0.98,
                () => new ElvenBoots(),
                () => new Sandals(),
                () => new Shoes()
            )},
            { "Robe",       new SlotDef(0.65,
                () => new Robe(),
                () => new FancyDress(),
                () => new MaleElvenRobe(),
                () => new FemaleElvenRobe(),
                () => new FloweredDress(),
                () => new HoodedShroudOfShadows(),
                () => new Robe()
            )},
            { "Back",       new SlotDef(0.35,
                () => new Cloak()
            )},
            { "Head",       new SlotDef(0.40,
                () => new WizardsHat(),
                () => new Circlet(),
                () => new FlowerGarland(),
                () => new LeatherCap()
            )},
            { "Shirt",      new SlotDef(0.70,
                () => new FancyShirt(),
                () => new ElvenShirt(),
                () => new FormalShirt()
            )},
            { "Legs",       new SlotDef(0.45,
                () => new LongPants(),
                () => new ElvenPants(),
                () => new Skirt()
            )},
            { "Neck",       new SlotDef(0.25,
                () => new ElegantCollar(),
                () => new Necklace(),
                () => new LeatherGorget()
            )},
            { "Hands",      new SlotDef(0.10,
                () => new GoldBracelet(),
                () => new LeatherGloves()
            )},
            { "RightHand",  new SlotDef(0.40,
                () => new MagicWand(),
                () => new Scepter(),
                () => new GnarledStaff(),
                () => new SpellWeaversWand(),
                () => new Spellbook()
            )},
            { "LeftHand",   new SlotDef(0.15,
                () => new Spellbook(),
                () => new Lantern()
            )},
            { "Ring",       new SlotDef(0.10,
                () => new GoldRing()
            )},
            { "Talisman",   new SlotDef(0.04,
                () => new RandomTalisman()
            )},
        };

        // --- Aerilon Faction Quest Pool Only ---
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // All Aerilon faction only
            () => new FactionCollectionQuestScroll("CrystalShard", 10, "Aerilon", 800),
            () => new FactionDeliveryQuestScroll("ArcaneLetter", "Aerilon", 300),
            () => new FactionKillQuestScroll("CorruptedMage", 5, "Aerilon", 1200),
			
            () => new FactionCollectionQuestScroll("RevealScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("ChainLightningScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("EnergyFieldScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("FlameStrikeScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("GateTravelScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("ManaVampireScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("MassDispelScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("MeteorSwarmScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("PolymorphScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("EarthquakeScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("EnergyVortexScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("ResurrectionScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("SummonAirElementalScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("SummonDaemonScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("SummonEarthElementalScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("SummonFireElementalScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("SummonWaterElementalScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("AnimateDeadScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("BloodOathScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("CorpseSkinScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("CurseWeaponScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("EvilOmenScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("HorrificBeastScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("LichFormScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("MindRotScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("PainSpikeScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("PoisonStrikeScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("StrangleScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("SummonFamiliarScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("VampiricEmbraceScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("VengefulSpiritScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("WitherScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("WraithFormScroll", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("Spellbook", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("NecromancerSpellbook", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("Runebook", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("RunicAtlas", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("KeyRing", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("Key", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("Globe", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("Spyglass", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("BarrelTap", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("BarrelHoops", 25, "Aerilon", 750),
            () => new FactionCollectionQuestScroll("SmithyHammer", 25, "Aerilon", 750),

            () => new FactionKillQuestScroll("InfernoWarden ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("MoltenGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("PyroclasticGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("SolarElemental ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("VolcanicTitan ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("AbbadonTheAbyssal ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Chimereon ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Drolatic ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Grimorie ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("GrotesqueOfRouen ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("GrymalkinTheWatcher ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Mordrake ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Strix ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Vespa ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("VitrailTheMosaic ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("IshKarTheForgotten ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("NyxRith ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("QuorZael ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("RathZorTheShattered ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("ThulGorTheForsaken ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("UruKoth ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Vorgath ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("XalRath ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("ZelVrak ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("ZorThul ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("BloodSerpent ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("CelestialPython ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("EmperorCobra ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("FrostSerpent ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("GorgonViper ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("InfernoPython ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("ShadowAnaconda ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("ThunderSerpent ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("TitanBoa ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("VengefulPitViper ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("BlackWidowQueen ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("GiantTrapdoorSpider ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("GiantWolfSpider ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("GoldenOrbWeaver ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("GoliathBirdeater ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("HuntsmanSpider ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("PurseSpider ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("ScorpionSpider ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("SpiderlingBroodmother ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("TarantulaWarrior ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("BeardedGoat ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Chamois ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("CliffGoat ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("DallSheep ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("FaintingGoat ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Goral ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Ibex ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Markhor ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("SableAntelope ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("Tahr ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("BoneGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("CheeseGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("CrystalGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("IronGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("MeatGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("MuckGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("SandGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("ShadowGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("StoneGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("WoodGolem ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("BaboonsAlpha ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("CapuchinTrickster ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("ChimpanzeeBerserker ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("GibbonMystic ", "5", "Aerilon", "500"),
            () => new FactionKillQuestScroll("HowlerMonkey ", "5", "Aerilon", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Aerilon, 350),				
			
			
            // Add more Aerilon-specific quests if desired!
        };

        // --- Appearance/Stats/Name ---
        [Constructable]
        public CitizenOfAerilon()
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
                Name  = parts[0] + " " + parts[1];
                Title = parts.Length > 2 ? parts[2] : "";
            }
            else
            {
                Name = fullName;
                Title = "";
            }
            SetStr(Utility.RandomMinMax(40, 70));
            SetDex(Utility.RandomMinMax(40, 70));
            SetInt(Utility.RandomMinMax(80, 120));
            SpeechHue = Utility.RandomMinMax(1150, 1285); // blue-violet/azure speech
        }

        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Aelion", "Lirael", "Selune", "Kaelis", "Thalios", "Mirael", "Isarion", "Serene", "Veyra", "Orinon",
                "Zephyra", "Calyra", "Faelith", "Talrin", "Enaris", "Lynae", "Elyra", "Soril", "Valas", "Ylian",
                "Azura", "Nerion", "Elun", "Xira", "Oris", "Myriel", "Lureth", "Solan", "Vespera", "Aeris",
                "Ilyra", "Sareth", "Aven", "Lytha", "Therian", "Ysera", "Saelis", "Vion", "Xanir", "Qyrel",
                "Caelum", "Zyra", "Melian", "Tyrian", "Astra", "Elira", "Nyra", "Ryn", "Seraphi", "Zaelis"
            };
            string[] lastNames = new[]
            {
                "of Azure", "Skyborn", "Cloudweaver", "Crystalwind", "Moonspire", "Starshaper", "Dreamwarden", "Spellwright",
                "Blueveil", "Starseer", "Mistshaper", "Highmagus", "Stormchant", "Windstrider", "Aetherborn", "Twilight",
                "Luminar", "Brightspire", "Celestial", "Skylore", "Spellweaver", "Arcanshade", "Skygazer", "Moonshadow"
            };
            string[] titles = new[]
            {
                "the Azure Citizen", "the Arcanist", "the Crystal Scribe", "the Luminant", "of the Floating City",
                "the Lorekeeper", "the Twilight Savant", "the Celestial", "the Seer", "the Skybound",
                "of the Azure Isles", "the Student of Magic", "the Spellwright", "the Artificer", "the Skyreader"
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
                    // Aerilon citizens favor blues, violets, white, silver, and magical hues
                    item.Hue = Utility.RandomList(1150, 1153, 1154, 1157, 1260, 1272, 1278, 1281, 1282, 1285, 0, 2406, 1175, 1266);
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomList(1150, 1154, 1157, 1260, 1272, 1278, 1281, 1282, 1285, 0);
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
                player.SendMessage($"Return later; I must consult the Azure Conclave. Come back in {wait.Minutes} minute(s).");
                return;
            }
            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;
            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("The magical runes falter. Try again later.");
                return;
            }
            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("You receive a quest scroll bearing the mark of Aerilon.");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfAerilon _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfAerilon npc)
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
        public CitizenOfAerilon(Serial serial) : base(serial) { }
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
