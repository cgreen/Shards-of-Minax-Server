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
    [CorpseName("the remains of a Qasarian citizen")]
    public class QasarianCitizenQuestGiver : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // Qasarian equipment slots (robes, sashes, turbans, sandals, merchant props, curved daggers)
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

        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            // Sandals or shoes (almost always)
            { "Footwear", new SlotDef(0.95,
                () => new Sandals(),
                () => new Shoes()
            )},

            // Desert robes, sashes, and tunics (often)
            { "Robe", new SlotDef(0.60,
                () => new Robe(),
                () => new Robe(),
                () => new BodySash(),
                () => new Tunic(),
                () => new Robe(),             // UO's Arabic robe
                () => new FlowerGarland()       // For color, not literal flowers
            )},

            // Headwear: Turban, Keffiyeh, Circlet, Simple Cap
            { "Head", new SlotDef(0.75,
                () => new Bandana(),         // custom turban if available
                () => new TribalMask(),
                () => new Bandana(),
                () => new Circlet(),
                () => new SkullCap(),
                () => new Kasa()            // "kasa" can look similar to sun hats
            )},

            // Shirt (always)
            { "Shirt", new SlotDef(0.90,
                () => new Shirt(),
                () => new FancyShirt(),
                () => new Tunic(),
                () => new Doublet(),
                () => new BodySash()
            )},

            // Sash or belt (sometimes)
            { "Belt", new SlotDef(0.75,
                () => new BodySash(),
                () => new HalfApron()
            )},

            // Legs (loose pants, rarely armor)
            { "Legs", new SlotDef(0.70,
                () => new LongPants(),
                () => new ShortPants(),
                () => new ElvenPants()
            )},

            // Jewelry (sometimes)
            { "Neck", new SlotDef(0.30,
                () => new Necklace()
            )},
            { "Earring", new SlotDef(0.10,
                () => new GoldEarrings()
            )},
            { "Bracelet", new SlotDef(0.10,
                () => new GoldBracelet()
            )},
            { "Ring", new SlotDef(0.10,
                () => new GoldRing()
            )},

            // Right hand: merchant or simple weapons
            { "RightHand", new SlotDef(0.60,
                () => new Scimitar(),
                () => new Dagger(),
                () => new Cleaver()

            )},

            // Left hand: trade item, bottle, lantern
            { "LeftHand", new SlotDef(0.40,
                () => new Bottle(),
                () => new Lantern(),
                () => new Bag()
            )}
        };

        // All Qasaria quests use the Qasaria faction
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            () => new FactionCollectionQuestScroll("Spice", 15, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("RareGem", 1, "Qasaria", 2000),
            () => new FactionDeliveryQuestScroll("MerchantGoods", "Qasaria", 350),
            () => new FactionKillQuestScroll("Bandit", 10, "Qasaria", 1200),
			
            () => new FactionCollectionQuestScroll("ShortCabinet", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("RedArmoire", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("ElegantArmoire", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("MapleArmoire", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("CherryArmoire", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("LapHarp", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("Lute", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("Drums", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("Harp", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("PlainWoodenChest", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("OrnateWoodenChest", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("GildedWoodenChest", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("WoodenFootLocker", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("FinishedWoodenChest", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("SweetCocoaButter", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("Dough", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("UnbakedFruitPie", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("UnbakedPeachCobbler", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("UnbakedApplePie", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("UnbakedPumpkinPie", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("Cookies", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("ThreeTieredCake", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("MisoSoup", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("WhiteMisoSoup", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("RedMisoSoup", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("AwaseMisoSoup", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("WasabiClumps", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("SushiRolls", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("SushiPlatter", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("GreenTea", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("SweetDough", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("CakeMix", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("CookieMix", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("UnbakedQuiche", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("UnbakedMeatPie", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("UncookedSausagePizza", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("UncookedCheesePizza", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("Quiche", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("MeatPie", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("SausagePizza", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("CheesePizza", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("FruitPie", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("PeachCobbler", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("PumpkinPie", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("EnchantedApple", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("TribalPaint", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("GrapesOfWrath", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("EggBomb", 25, "Qasaria", 750),
            () => new FactionCollectionQuestScroll("FishSteak", 25, "Qasaria", 750),

            () => new FactionKillQuestScroll("BoundKirin", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("CursedMalidorWarrior", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("CursedRat", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("DeanOfMalidor", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("DisplacementBeast", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("Dracolich", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("EnchantedMinion", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("EnchantmentDragon", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("EnchantmentSlooth", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("Hexling", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("Hexlord", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("LabRat", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MacroVirus", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MagicFiend", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MalidorWarhorse", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("Morlock", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MysticDragon", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("OrcishAlchemist", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("PixieSonglord", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("RomeroZombie", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("SpellClaw", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("SpellDrake", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("SpellElemental", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("ToxinElemental", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("TwinHead", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("WanderingSoul", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("Werewolf", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("WitchboundGargoyle", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("WitchboundMummy", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("WitchesFamiliar", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("WitchsEnforcer", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("WitchsMongbat", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("YamishDemon", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("BronzeOfTheDeep", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("BuriedCow", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("BurrowerKeppto", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("CaveAvenger", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("CavernGoblin", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("CoalWisp", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("CorrodedRedSolen", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("CorrodedSlith", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("CorrodedSolenWorker", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("DeepOrtanord", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("ElfMiner", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("EntombedMummy", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("GhoulMiner", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("GloomKnight", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("GrittyPixie", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("InsaneOphidianKnight", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("LostMiner", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MinecraftGargolye", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MineDancer", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MineHorror", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MineralWaterElemental", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MinersFleshGolem", "5", "Qasaria", "500"),
            () => new FactionKillQuestScroll("MineWolf", "5", "Qasaria", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Qasaria, 350),				
			
			
            // ...add more if desired, but always for "Qasaria" faction!
        };

        [Constructable]
        public QasarianCitizenQuestGiver()
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

        private static string GenerateRandomName()
        {
            // Qasarian-style names (Arabic, Persian, etc.)
            string[] firstNames = new[]
            {
                "Yasir", "Layla", "Samir", "Amina", "Nasir", "Jaleel", "Zara", "Hakim", "Iman", "Salim",
                "Ranya", "Omar", "Nadia", "Rashid", "Farid", "Dalia", "Jamal", "Aziz", "Fatima", "Hassan",
                "Sabir", "Leila", "Rami", "Amira", "Nassim", "Jibril", "Khalid", "Soraya", "Sadiq", "Tahira",
                "Parviz", "Mina", "Tariq", "Zainab", "Aliyah", "Adil", "Ayaan", "Basim", "Hadiya", "Samira",
                "Mahmoud", "Munir", "Nawal", "Rahma", "Sahar", "Tarik", "Ziyad", "Yasmine", "Ruqayya", "Nizar"
            };
            string[] lastNames = new[]
            {
                "al-Qasari", "ibn Qamar", "bint Riyad", "al-Merchant", "al-Zahari", "al-Amin", "al-Hakim", "al-Farid",
                "al-Dinari", "bint Layali", "al-Jamal", "al-Aziz", "al-Salim", "al-Sabah", "al-Bazaar", "al-Harith",
                "ibn Jaleel", "al-Sandwalker", "al-Gemcutter", "al-Khadem", "al-Sidra", "al-Qamar", "al-Sahara", "al-Souk",
                "al-Mina", "al-Hasan", "al-Nasir", "al-Tariq", "al-Suhail", "al-Khalid", "al-Safiya", "al-Nafis"
            };
            string[] titles = new[]
            {
                "the Merchant", "the Spice Trader", "the Jewel Appraiser", "the Weaver", "the Alchemist",
                "the Perfumer", "the Dune Guide", "the Scribe", "the Storyteller", "the Scholar", "the Desert Wanderer",
                "the Vizier", "the Caravan Master", "the Date Seller", "the Lamp Maker", "the Moneylender", "the Silkseller",
                "the Sandkeeper", "the Sarabist", "the Astrologer", "the Falconer", "the Carpetmonger", "the Herbalist",
                "the Goldsmith", "the Pearl Diver", "the Magistrate", "the Artisan", "the Calligrapher", "the Rug Weaver",
                "the Envoy", "the Storyteller", "the Musician", "the Sage", "the Cupbearer"
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
                    item.Hue = Utility.RandomMinMax(1001, 1800); // warm sands & jewel tones
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(800, 1350); // dark hair tones
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
                player.SendMessage($"I must prepare more scrolls. Please return in {wait.Minutes} minute(s).");
                return;
            }
            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;
            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("Apologies, my scrolls are missing. Please try again soon.");
                return;
            }
            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("A quest for Qasaria awaits you—read this scroll.");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly QasarianCitizenQuestGiver _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, QasarianCitizenQuestGiver npc)
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

        public QasarianCitizenQuestGiver(Serial serial) : base(serial) { }

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
