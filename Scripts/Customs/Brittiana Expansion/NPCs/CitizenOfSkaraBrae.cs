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
    [CorpseName("the remains of a citizen of Skara Brae")]
    public class CitizenOfSkaraBrae : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ---- Minimal, peaceful civilian Skara Brae outfit pool ----
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
            { "Footwear",   new SlotDef(0.95,
                () => new Sandals(),
                () => new Shoes(),
                () => new Boots())
            },

            { "Robe",       new SlotDef(0.70,  // Robes are common!
                () => new Robe(),
                () => new FloweredDress(),
                () => new MonkRobe(),
                () => new PlainDress())
            },

            { "Cloak",      new SlotDef(0.15,
                () => new Cloak())
            },

            { "Head",       new SlotDef(0.30,
                () => new FlowerGarland(),
                () => new Bonnet(),
                () => new Bandana(),
                () => new Bandana())
            },

            { "Shirt",      new SlotDef(0.50,
                () => new FancyShirt(),
                () => new Shirt(),
                () => new Tunic(),
                () => new BodySash())
            },

            { "Legs",       new SlotDef(0.60,
                () => new LongPants(),
                () => new ShortPants(),
                () => new Skirt(),
                () => new Kilt())
            },

            { "Sash",       new SlotDef(0.25,
                () => new BodySash())
            },

            // Staff as a prop, rarely (symbolic, not a weapon)
            { "Staff",      new SlotDef(0.10,
                () => new ShepherdsCrook(),
                () => new GnarledStaff())
            },

            // Musical instruments for bardic citizens (rare flavor)
            { "Instrument", new SlotDef(0.05,
                () => new Harp(),
                () => new Lute())
            },
        };

        // ---- Skara Brae–specific Quest Factories ----
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // All quest scrolls must be for Skara Brae faction or local lore (update with your actual quest types as needed!)
            () => new FactionCollectionQuestScroll("Wool", 12, "SkaraBrae", 350),
            () => new FactionDeliveryQuestScroll("Herbs", "SkaraBrae", 150),
            () => new FactionKillQuestScroll("Rat", 8, "SkaraBrae", 220),
            () => new CollectionQuestScroll("Rare Herbs", 8, 950),
            () => new KillQuestScroll("Dire Wolf", 2, 550),
            () => new RegionKillQuestScroll("Spirit Lake", 4, 350),
			
            () => new FactionCollectionQuestScroll("Cabbage", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Cantaloupe", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Carrot", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("HoneydewMelon", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Squash", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Lettuce", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Onion", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Pumpkin", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("GreenGourd", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("YellowGourd", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Turnip", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Watermelon", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("EarOfCorn", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Eggs", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Peach", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Pear", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Lemon", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Lime", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Grapes", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Apple", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("SheafOfHay", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("RawFishSteak", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("SmallFish", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Fish", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Hides", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("GoldRing", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Necklace", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("GoldNecklace", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("GoldBeadNecklace", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Beads", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("GoldBracelet", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("GoldEarrings", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("StarSapphire", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Emerald", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Sapphire", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Ruby", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Citrine", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Amethyst", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Tourmaline", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Amber", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("Diamond", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("BatWing", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("DaemonBlood", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("PigIron", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("NoxCrystal", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("GraveDust", 25, "SkaraBrae", 750),
            () => new FactionCollectionQuestScroll("BoltOfCloth", 25, "SkaraBrae", 750),

            () => new FactionKillQuestScroll("CursedSoul", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("CuSidhe", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Cyclops", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Daemon", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DarkGuardian", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DarknightCreeper", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DarkWisp", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DeadlyImp", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DeepSeaSerpent", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DemonKnight", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DesertOstard", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Devourer", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DireWolf", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DiseasedCat", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Dog", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Dolphin", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Doppleganger", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Dragon", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DragonsFlameGrandMage", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DragonsFlameMage", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DragonWolf", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Drake", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DreadSpider", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DreadWarhorse", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DreamWraith ", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("DullCopperElemental", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Eagle", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EarthElemental", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EffetePutridGargoyle", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EffeteUndeadGargoyle", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Efreet", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("ElderGazer", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("ElfBrigand", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EliteNinja", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnragedCollosus", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnragedCreatures", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnragedEarthElemental", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnslavedGargoyle", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnslavedGoblinKeeper", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnslavedGoblinMage", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnslavedGoblinScout", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnslavedGrayGoblin", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnslavedGreenGoblin", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnslavedGreenGoblinAlchemist", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EnslavedSatyr", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Eowmu", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Ethereals", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EtherealWarrior", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Ettin", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EvilMage", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("EvilMageLord", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Executioner", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("ExodusMinion", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("ExodusOverseer", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FairyDragon", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FanDancer", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FeralTreefellow", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("Ferret", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FetidEssence", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FierceDragon", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FireAnt", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FireBeetle", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FireDaemon", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FireElemental", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FireGargoyle", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FireRabbit", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FireSteed", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FleshGolem", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FleshRenderer", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("ForestOstard", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("ForgottenServant", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FrenziedOstard", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FrostDragon", "5", "SkaraBrae", "500"),
            () => new FactionKillQuestScroll("FrostDrake", "5", "SkaraBrae", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SkaraBrae, 350),				
			
            // ...add more as you like!
        };

        [Constructable]
        public CitizenOfSkaraBrae()
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
                Name  = parts[0] + " " + parts[1]; // first + last
                Title = parts.Length > 2 ? parts[2] : "";
            }
            else
            {
                Name = fullName;
                Title = "";
            }

            SetStr(Utility.RandomMinMax(40, 70));
            SetDex(Utility.RandomMinMax(40, 70));
            SetInt(Utility.RandomMinMax(50, 90));
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

        // --- Only simple, spiritual, nature‐inspired names/titles ---
        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Ailith", "Bran", "Celyn", "Dara", "Eirian", "Fionn", "Gwynn", "Isolde", "Lira", "Mira",
                "Nerys", "Orin", "Rowan", "Sage", "Tamsin", "Willow", "Yara", "Ash", "Dara", "Elias",
                "Jorah", "Kael", "Lira", "Rhea", "Selene", "Wren", "Iris", "Finn", "Tess", "Vesper"
            };
            string[] lastNames = new[]
            {
                "of Skara Brae", "the Harper", "the Shepherd", "the Herbalist", "the Scribe", "the Minstrel", "the Wayfarer",
                "the Fisher", "the Gatherer", "the Weaver", "the Gardener", "the Keeper", "the Chronicler",
                "the Seer", "the Bard", "the Druid", "the Pilgrim", "the Healer", "the Poet"
            };
            string first  = firstNames[Utility.Random(firstNames.Length)];
            string last   = lastNames[Utility.Random(lastNames.Length)];
            return $"{first} {last}";
        }

        private void InitOutfit()
        {
            foreach (var kv in _slotDefs)
            {
                if (Utility.RandomDouble() <= kv.Value.Chance)
                {
                    var factories = kv.Value.Pool;
                    var item = factories[Utility.Random(factories.Length)]();
                    item.Hue = Utility.RandomMinMax(2500, 3000);
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
                player.SendMessage("Here, take this quest scroll!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfSkaraBrae _npc;
            private readonly Mobile _from;
            public QuestEntry(Mobile from, CitizenOfSkaraBrae npc) : base(6156)
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

        public CitizenOfSkaraBrae(Serial serial) : base(serial) { }
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
