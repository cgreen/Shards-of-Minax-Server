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
    [CorpseName("the remains of a Vesper citizen")]
    public class CitizenOfVesper : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // -------- VESPER-THEMED Equipment Pool --------
        private class SlotDef
        {
            public double Chance;
            public Func<Item>[] Pool;
            public SlotDef(double chance, params Func<Item>[] pool) { Chance = chance; Pool = pool; }
        }

        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            { "Footwear", new SlotDef(0.98, () => new Boots(), () => new Shoes(), () => new ThighBoots()) },
            { "Shirt", new SlotDef(0.85, () => new Shirt(), () => new Tunic(), () => new Tunic(), () => new FancyShirt(), () => new Doublet()) },
            { "Pants", new SlotDef(0.90, () => new LongPants(), () => new ShortPants(), () => new ShortPants(), () => new ShortPants()) },
            { "Apron", new SlotDef(0.50, () => new HalfApron(), () => new FullApron()) },
            { "Head", new SlotDef(0.40, () => new Cap(), () => new StrawHat(), () => new WideBrimHat(), () => new Bandana()) },
            { "Chest", new SlotDef(0.15, () => new LeatherChest(), () => new StuddedChest(), () => new ChainChest()) }, // Light armor only, Vesper is practical
            { "Arms", new SlotDef(0.12, () => new LeatherArms(), () => new StuddedArms()) },
            { "Hands", new SlotDef(0.45, () => new LeatherGloves(), () => new LeatherGloves()) },
            { "Neck", new SlotDef(0.05, () => new LeatherGorget()) },
            { "Accessory", new SlotDef(0.07, () => new GoldRing()) },
            // Industrial props: mining lamp, pickaxe, etc. These are mainly cosmetic for this NPC.
            { "RightHand", new SlotDef(0.65, () => new Pickaxe(), () => new HammerPick(), () => new SmithHammer(), () => new Tongs(), () => new Pickaxe(), () => new Axe()) },
            { "LeftHand", new SlotDef(0.35, () => new Lantern(), () => new Bucket(), () => new WoodenShield()) },
        };

        // ----------- VESPER QUESTS -----------
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            () => new FactionDeliveryQuestScroll("IronIngot", "Vesper", 40),
            () => new FactionCollectionQuestScroll("Ore", 30, "Vesper", 1000),
            () => new FactionKillQuestScroll("Orc", 12, "Vesper", 900),
            () => new FactionDeliveryQuestScroll("SmithingTools", "Vesper", 5),
            () => new FactionKillQuestScroll("GiantRat", 20, "Vesper", 600),
            () => new FactionCollectionQuestScroll("Logs", 20, "Vesper", 600),
            () => new FactionDeliveryQuestScroll("TradeGoods", "Vesper", 1),
            () => new FactionKillQuestScroll("Bandit", 8, "Vesper", 700),
            () => new CollectionQuestScroll("Ore", 20, 9000), // fallback
            () => new KillQuestScroll("Elemental", 4, 5000),
			
            () => new FactionCollectionQuestScroll("Cloth", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("UncutCloth", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("Cotton", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("Wool", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("Flax", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("SpoolOfThread", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("OakLog", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("AshLog", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("YewLog", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("BloodwoodLog", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("ElixirOfRebirth", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("MedusaBlood", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("BarrabHemolymphConcentrate", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("PlantClippings", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("MyrmidexEggsac", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("InvisibilityPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("JukariBurnPoiltice", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("LavaBerry", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("Vanilla", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("BlueDiamond", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("TigerPelt", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("PerfectBanana", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("YellowScales", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("RiverMoss", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("UraliTranceTonic", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("PoisonPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("GreaterPoisonPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("DeadlyPoisonPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("ParasiticPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("ParasiticPlant", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("DarkglowPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("LuminescentFungi", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("ScouringToxin", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("ToxicVenomSac", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("ExplosionPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("GreaterExplosionPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("TacticalBomb", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("StrategicBomb", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("MegaBombPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("MinorPoisonBomb", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("PoisonBomb", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("UltraPoisonBomb", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("MegaHealthBomb", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("ConflagrationPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("GreaterConflagrationPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("ConfusionBlastPotion", 25, "Vesper", 750),
            () => new FactionCollectionQuestScroll("GreaterConfusionBlastPotion", 25, "Vesper", 750),			
            () => new FactionKillQuestScroll("FrostMite", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("FrostOoze", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("FrostSpider", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("FrostTroll", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Gaman", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GargishOutcast", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GargishRouser", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Gargoyle", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GargoyleDestroyer", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GargoyleEnforcer", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GargoyleGuardian", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GargoyleShade", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Gazer", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GazerLarva", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Ghoul", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GiantBlackWidow", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GiantIceWorm", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GiantRat", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GiantSerpent", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GiantSpider", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GiantToad", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GiantTurkey", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Gibberling", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Goat", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GoldenElemental", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Golem", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GolemController", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GoreFiend", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Gorilla", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GrayGoblin", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GrayGoblinKeeper", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GrayGoblinMage", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GreaterDragon", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GreaterMongbat", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GreaterPoisonElemental", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GreatHart", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GreenGoblin", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GreenGoblinAlchemist", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GreenGoblinScout", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Gregorio", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Gremlin", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GreyWolf", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("GrizzlyBear", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Grubber", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Guardian", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Harpy", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("HeadlessOne", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("HellCat", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("HellHound", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("HellSteed", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("HighPlainsBoura", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Hind", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Hiryu", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("HordeMinion", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Horse", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("HumanBrigand", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("HungryCoconutCrab", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Hydra", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("IceElemental", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("IceFiend", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Icehound", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("IceSerpent", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("IceSnake", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Imp", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Impaler", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("InjuredWolf", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("InsaneDryad", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("InterredGrizzle ", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("IronBeetle", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("JackRabbit", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("Juggernaut", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("JukaLord", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("JukaMage", "5", "Vesper", "500"),
            () => new FactionKillQuestScroll("JukaWarrior", "5", "Vesper", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Vesper, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Vesper, 350),				
			
        };

        // ----------- VESPER NAMES & TITLES -----------
        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Alec", "Bran", "Celia", "Dain", "Edda", "Finn", "Greta", "Hal", "Ira", "Joss", "Karl", "Lina", "Matthias", "Nina", "Olaf", "Petra", "Quinn", "Reed", "Selma", "Tobin", "Ulric", "Vera", "Walt", "Ysolde", "Zane"
            };
            string[] lastNames = new[]
            {
                "Ironhand", "Smith", "Coalburn", "Coppervein", "Furnace", "Barrelwright", "Cogwright", "Workman", "Mason", "Sawyer", "Stonecutter", "Brassard", "Gearson", "Chisel", "Steelbrew", "Ironfoot", "Kilnman", "Copperpot", "Rivet", "Forgewright", "Clinker", "Dockworker", "Sootcloak", "Lodelifter", "Orebound", "Bellowson", "Millwright", "Trundle", "Rafter", "Proudforge", "Tradeson", "Stack", "Pickman", "Riveter", "Vesperite"
            };
            string[] titles = new[]
            {
                "the Tinker", "the Barrelmaker", "the Riveter", "the Miner", "the Quarryman", "the Shipwright", "the Smelter", "the Mason", "the Teamster", "the Millwright",
                "the Laborer", "the Smith", "the Furnace Master", "the Cartwright", "the Stevedore", "the Logger", "the Gearsmith", "the Chandlery", "the Dockhand", "the Coalman", "the Candler", "the Apprentice", "the Journeyman", "the Foreman", "the Inspector", "of the Docks", "of the Ironworks", "of the Foundry", "of the Mill", "of Proudforge Hall"
            };
            string first  = firstNames[Utility.Random(firstNames.Length)];
            string last   = lastNames[Utility.Random(lastNames.Length)];
            string title  = titles[Utility.Random(titles.Length)];
            return $"{first} {last} {title}";
        }

        // ----------- NPC Logic (unchanged) -----------
        [Constructable]
        public CitizenOfVesper()
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
            SetStr(Utility.RandomMinMax(50, 100));
            SetDex(Utility.RandomMinMax(50, 100));
            SetInt(Utility.RandomMinMax(50, 100));
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
                    item.Hue = Utility.RandomMinMax(750, 2000); // Muted tones, no neon
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1, 2500);
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
                player.SendMessage($"I need to restock my ledgers. Come back in {wait.Minutes} minute(s).");
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
                player.SendMessage("For Vesper and industry! Take this task.");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfVesper _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfVesper npc)
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

        public CitizenOfVesper(Serial serial) : base(serial) { }

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
