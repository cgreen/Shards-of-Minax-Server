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
    [CorpseName("the remains of a Buccaneer's Den citizen")]
    public class BuccaneerCitizenQuestGiver : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // Pirate-appropriate equipment pool
        private class SlotDef
        {
            public double Chance;
            public Func<Item>[] Pool;
            public SlotDef(double chance, params Func<Item>[] pool) { Chance = chance; Pool = pool; }
        }

        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            // Almost always boots or sandals
            { "Footwear", new SlotDef(0.95,
                () => new Boots(),
                () => new Sandals(),
                () => new Shoes(),
                () => new ThighBoots()
            )},

            // Shirt/vest
            { "Shirt", new SlotDef(0.85,
                () => new FancyShirt(),
                () => new Shirt(),
                () => new Doublet(),
                () => new Tunic()
            )},

            // Trousers or ragged pants
            { "Legs", new SlotDef(0.80,
                () => new LongPants(),
                () => new ShortPants(),
                () => new LeatherShorts()
            )},

            // Pirate vests/coats sometimes
            { "Robe", new SlotDef(0.15,
                () => new Robe(),
                () => new FancyDress(),
                () => new Cloak()
            )},

            // Bandana/hat
            { "Head", new SlotDef(0.65,
                () => new Bandana(),
                () => new TricorneHat(),
                () => new SkullCap(),
                () => new FloppyHat(),
                () => new StrawHat()
            )},

            // Apron/belt for working folk
            { "Belt", new SlotDef(0.40,
                () => new HalfApron(),
                () => new FullApron()
            )},

            // Piratey weapon or dagger
            { "RightHand", new SlotDef(0.75,
                () => new Cutlass(),
                () => new Broadsword(),
                () => new Club(),
                () => new Dagger(),
                () => new SkinningKnife()
            )},

            // Offhand items
            { "LeftHand", new SlotDef(0.10,
                () => new Buckler(),
                () => new WoodenShield(),
                () => new Lantern()
            )},
        };

        // Pirate/Buccaneer's Den names and titles
        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Red", "Sandy", "Morgan", "Jack", "Bonny", "Jolly", "One-Eyed", "Dirty", "Pegleg", "Mad", "Salty", "Smiling",
                "Crimson", "Slim", "Black", "Rusty", "Ivy", "Rook", "Pale", "Drake", "Sable", "Scurvy", "Bess", "Ragnar",
                "Rum", "Billy", "Tarn", "Maggie", "Ned", "Grace", "Hawk", "Swarthy", "Iron", "Tessa", "Penny", "Finn"
            };
            string[] lastNames = new[]
            {
                "Bart", "Jones", "Hawk", "Marrow", "Kidd", "Raven", "Wren", "Graves", "Morgan", "Black", "Silver", "Hawk",
                "Hooks", "Barnacle", "Crow", "Cutter", "Quinn", "Salt", "McGee", "O'Malley", "Beard", "Scarr", "Bones", "Carver",
                "Dreg", "Merrow", "Reed", "Blake", "Kelpie", "Shark", "Storm", "Kraken", "Fletcher", "Finn", "Locke", "Sable"
            };
            string[] titles = new[]
            {
                "the Sailor",
                "the Smuggler",
                "the Cutpurse",
                "the Barkeep",
                "the Deckhand",
                "the Buccaneer",
                "the Fishmonger",
                "the Dockhand",
                "the Fence",
                "the Swabbie",
                "the Lookout",
                "the Mapmaker",
                "the Shipwright",
                "the Drunkard",
                "the Cardsharp",
                "the Dice Master",
                "the Salt Dog",
                "the Freebooter",
                "the Scrapper",
                "the Beggar",
                "the Storyteller",
                "the Rumrunner",
                "the Black Market Dealer",
                "the Corsair",
                "the First Mate",
                "the Quartermaster",
                "the Brawler",
                "the Sharkbait",
                "the Shell Collector",
                "the Lucky",
                "the Old Salt",
                "the Skulker",
                "the Rogue",
                "the Troublemaker",
                "the Drifter"
            };
            string first = firstNames[Utility.Random(firstNames.Length)];
            string last = lastNames[Utility.Random(lastNames.Length)];
            string title = titles[Utility.Random(titles.Length)];
            return $"{first} {last} {title}";
        }

        // Only Buccaneer's Den faction quests (if your scrolls support faction param, set it)
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // These should all be configured for Buccaneer's Den faction
            () => new FactionKillQuestScroll("PirateCaptain", 1, "BuccaneersDen", 2000), // Sample, add/adjust your scrolls!
            () => new FactionCollectionQuestScroll("GoldCoin", 50, "BuccaneersDen", 1500),
            () => new FactionKillQuestScroll("SeaSerpent", 2, "BuccaneersDen", 1000),
			
            () => new FactionCollectionQuestScroll("WoodenBowlOfCorn", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("WoodenBowlOfLettuce", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("WoodenBowlOfPeas", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("EmptyPewterBowl", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("PewterBowlOfCorn", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("PewterBowlOfLettuce", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("PewterBowlOfPeas", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("PewterBowlOfPotatos", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("WoodenBowlOfStew", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("WoodenBowlOfTomatoSoup", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Chessboard", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("CheckerBoard", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Backgammon", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Dices", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("ContractOfEmployment", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("BarkeepContract", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("VendorRentalContract", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Wasabi", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("BentoBox", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("GreenTeaBasket", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("MaxxiaScroll", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("HeritageSovereign", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("GenderChangeDeed", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("MurderRemovalDeed", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("ClothingBlessDeed", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("AdventurersContract", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("TradeRouteContract", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("HeritageToken", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("FrenchBread", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("BowlFlour", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("DestroyingAngel", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("SpringWater", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("PetrafiedWood", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("HeatingStand", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("SkinTingeingTincture", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("TransmutationCauldron", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("GlassblowingBook", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("SandMiningBook", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Blowpipe", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Zychroline", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Aetheralate", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Neontrium", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Oblivionate", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Phantomide", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Quarkothene", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Stygiocarbon", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Cryovitrin", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Fluxidate", 25, "BuccaneersDen", 750),
            () => new FactionCollectionQuestScroll("Novaesine", 25, "BuccaneersDen", 750),			

            () => new FactionKillQuestScroll("LibrarianCustodian", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("LightningBearer", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Locksmith", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Logician", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("LongbowSniper", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Luchador", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Magician", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("MapMaker", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("MartialMonk", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("MasterPickpocket", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("MuscleBrute", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("NecroSummoner", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("NerveAgent", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("NetCaster", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("NymphSinger", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Oracle", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("PastryChef", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("PatchworkMonster", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Pathologist", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("PhantomAssassin", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Pickpocket", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("PocketPicker", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Protester", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("QiGongHealer", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("QuantumPhysicist", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("RamRider", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("RapierDuelist", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Relativist", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("RelicHunter", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("RuneCaster", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("RuneKeeper", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Saboteur", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("SabreFighter", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("SafeCracker", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("Samurai", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("SatyrPiper", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("SawmillWorker", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("ScoutArcher", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("ScoutLeader", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("ScoutNinja", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("ScrollMage", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("SerpentHandler", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("ShadowLurker", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("ShadowPriest", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("SheepdogHandler", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("ShieldBearer", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("ShieldMaiden", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("SlyStoryteller", "5", "BuccaneersDen", "500"),
            () => new FactionKillQuestScroll("SousChef", "5", "BuccaneersDen", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.BuccaneersDen, 350),				
			
            // Add more with Buccaneer's Den flavor!
        };

        [Constructable]
        public BuccaneerCitizenQuestGiver()
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
                    item.Hue = Utility.RandomMinMax(1, 500);
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
                player.SendMessage("Yarr, seems somethin’ went wrong. Try again later.");
                return;
            }

            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("Here, take this Buccaneer's Den quest scroll!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly BuccaneerCitizenQuestGiver _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, BuccaneerCitizenQuestGiver npc)
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

        public BuccaneerCitizenQuestGiver(Serial serial) : base(serial) { }

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
