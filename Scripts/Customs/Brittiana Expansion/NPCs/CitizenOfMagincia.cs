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
    [CorpseName("the remains of a Magincian citizen")]
    public class CitizenOfMagincia : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // --- Magincia-style Equipment Pool ---
        private class SlotDef
        {
            public double Chance;
            public Func<Item>[] Pool;
            public SlotDef(double chance, params Func<Item>[] pool) { Chance = chance; Pool = pool; }
        }
        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            { "Footwear", new SlotDef(0.95, () => new Sandals(), () => new Shoes(), () => new Boots() ) },
            { "Shirt", new SlotDef(0.85, () => new Shirt(), () => new FancyShirt(), () => new Tunic()) },
            { "Legs", new SlotDef(0.90, () => new LongPants(), () => new ShortPants(), () => new Skirt() ) },
            { "Back", new SlotDef(0.10, () => new Cloak() ) },
            { "Head", new SlotDef(0.20, () => new StrawHat(), () => new Cap() ) },
            { "Apron", new SlotDef(0.30, () => new HalfApron(), () => new FullApron() ) },
            { "Belt", new SlotDef(0.10, () => new BodySash() ) },
            // No armor/weapons for humble citizens
        };

        // --- Magincia-only quest scrolls (examples, adapt as needed) ---
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // All Faction quests: "Magincia" as the faction name
            () => new FactionCollectionQuestScroll("FishSteak", 20, "Magincia", 750), // Collect fish for the docks
            () => new FactionDeliveryQuestScroll("DriedHerbs", "Magincia", 250),      // Deliver herbs to a healer
            () => new FactionKillQuestScroll("SeaSerpent", 3, "Magincia", 900),      // Slay sea monsters for Magincia
            () => new FactionCollectionQuestScroll("Wool", 10, "Magincia", 500),     // Collect wool for trade
			
            () => new FactionCollectionQuestScroll("MiniAlmondSeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("MiniGrapefruitSeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("Cinderathane", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("zanioperFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("Clock", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("HateCalamansiFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("fliavesFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("CornSeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("CranberrySeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("RedRaspberrySeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("jochiniFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("RainPommeracFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("gigliachokeFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("ElvenHopsSeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("OnionSeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("fushewFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("eacotFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("uyerdFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("IceRocketFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("VoidOkraFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("WinterCoconutFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("Helionine", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("iaconaFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("veapeFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("MiniPomegranateSeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("MageDateFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("SweetHopsSeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("FalseAlmondFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("EggplantSeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("girinFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("Prismalium", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("grandaFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("Radiacrylate", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("PeaceDateFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("probbacheeFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("WhiteRoseSeed", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("Morphaloxane", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("omondFruit", 25, "Magincia", 750),
            () => new FactionCollectionQuestScroll("Eclipsium", 25, "Magincia", 750),			

            () => new FactionKillQuestScroll("WardCaster", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("WaterAlchemist", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("WeaponEnchanter", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("WoolWeaver", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("ZenMonk", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("AirClanNinja", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("AirClanSamurai", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("AlienWarrior", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("AppleElemental", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("Assassin", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("AstralTraveler", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("AvatarOfElements", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("BaroqueBarbarian", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("BeetleJuiceSummoner", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("Biomancer", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("BluesSingingGorgon", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("BmovieBeastmaster", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("BountyHunter", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("CabaretKrakenGirl", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("Cannibal", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("CavemanScientist", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("CelestialSamurai", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("ChrisRoberts", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("CorporateExecutive", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("CountryCowgirlCyclops", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("Cowboy", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("CyberpunkSorcerer", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("DancingFarmerB", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("DancingFarmerC", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("DarkElf", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("DarkLord", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("DinoRider", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("DiscoDruid", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("DogtheBountyHunter", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("DuelistPoet", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("EarthClanNinja", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("EarthClanSamurai", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("EvilAlchemist", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("EvilClown", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("FairyQueen", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("FastExplorer", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("FireClanNinja", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("FireClanSamurai", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("FlapperElementalist", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("FloridaMan", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("ForestRanger", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("FunkFungiFamiliar", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("GangLeader", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("GlamRockMage", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("GothicNovelist", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("GraffitiGargoyle", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("GreaserGryphonRider", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("GreenHag", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("GreenNinja", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("HippieHoplite", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("HolyKnight", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("HostileDruid", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("HostilePrincess", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("IceKing", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("InfernoDragon", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("InsaneRoboticist", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("JazzAgeJuggernaut", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("Jester", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("Lawyer", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("LineDragon", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("LordBlackthorn", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("LordBritishSummoner", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("MagmaElemental", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("MedievalMeteorologist", "5", "Magincia", "500"),
            () => new FactionKillQuestScroll("MegaDragon", "5", "Magincia", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Magincia, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Magincia, 350),				

			
            // You can add more as your quest scroll system allows!
        };

        // --- Random Magincian names & titles ---
        private static string GenerateRandomName()
        {
            string[] firstNames = { "Galen", "Maris", "Tilda", "Darian", "Lysa", "Nestor", "Orla", "Selwyn", "Rafi", "Bennet", "Ena", "Hale", "Emil", "Vella", "Soren", "Myra", "Lorne", "Marin", "Flint", "Dina" };
            string[] lastNames = { "Fisher", "Caravel", "Coastman", "Dockhand", "Porter", "Merchant", "Netweaver", "Steward", "Barrow", "Shepherd", "Waters", "Rowe", "Saltspray", "Greenfield", "Pond", "Reed", "Bywater", "Hale", "White", "Lowman" };
            string[] titles = {
                "the Humble", "the Fishmonger", "the Docksman", "the Sheep Herder", "of Magincia", "the Netmender",
                "the Bargeman", "the Beekeeper", "the Port Laborer", "the Simple", "the Modest", "the Fisher",
                "the Baker", "the Stablehand", "the Sailor", "the Trader", "the Weaver", "the Planter",
                "the Candler", "the Brewer", "the Soapmaker", "the Sand Gatherer", "the Oystercatcher", "the Florist",
                "the Gulls' Friend", "the Shoemaker", "the Teamster", "the Ferryman", "the Swabber", "the Clerk",
                "the Miller", "the Townsfolk", "the Apprentice", "the Netcaster"
            };
            string first = firstNames[Utility.Random(firstNames.Length)];
            string last = lastNames[Utility.Random(lastNames.Length)];
            string title = titles[Utility.Random(titles.Length)];
            return $"{first} {last} {title}";
        }

        // --- Creature/Outfit/Name setup ---
        [Constructable]
        public CitizenOfMagincia()
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
            SetStr(Utility.RandomMinMax(40, 80));
            SetDex(Utility.RandomMinMax(40, 80));
            SetInt(Utility.RandomMinMax(40, 80));
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
                    item.Hue = Utility.RandomMinMax(2101, 2220); // Light, earthy, blue, or white hues (Magincia-style)
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1001, 1100); // Light-brown to sandy hues
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
                player.SendMessage("Here, take this quest scroll for the good of Magincia!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }
        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfMagincia _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfMagincia npc)
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
        public CitizenOfMagincia(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
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
