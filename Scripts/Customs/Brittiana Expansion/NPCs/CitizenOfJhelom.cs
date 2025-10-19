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
    [CorpseName("the remains of a Jhelom citizen")]
    public class CitizenOfJhelom : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ---- Jhelom Equipment Pool: boots, leathers, simple plate, shirts, simple hats ----
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
            // Boots/Sandals
            { "Footwear", new SlotDef(0.95, () => new Boots(), () => new Sandals(), () => new Shoes()) },

            // No robes! Maybe a 10% chance for a surcoat.
            { "Robe", new SlotDef(0.10, () => new Surcoat()) },

            // Cloaks are rare.
            { "Back", new SlotDef(0.10, () => new Cloak()) },

            // Headgear: bandana, cap, helmet, rarely bareheaded.
            { "Head", new SlotDef(0.40, () => new Bandana(), () => new Cap(), () => new Helmet(), () => new PlateHelm()) },

            // Shirt/tunic/sash
            { "Shirt", new SlotDef(0.85, () => new Tunic(), () => new Shirt(), () => new BodySash(), () => new FancyShirt()) },

            // Chest armor: leather or plate, nothing fancy
            { "Chest", new SlotDef(0.50, () => new LeatherChest(), () => new PlateChest(), () => new StuddedChest()) },

            // Legs: pants or armor
            { "Legs", new SlotDef(0.80, () => new LongPants(), () => new LeatherLegs(), () => new PlateLegs()) },

            // Skirt (kilt) - some fighters!
            { "Skirt", new SlotDef(0.15, () => new Kilt()) },

            // Arms: simple armor
            { "Arms", new SlotDef(0.40, () => new LeatherArms(), () => new PlateArms(), () => new StuddedArms()) },

            // Hands: gloves
            { "Hands", new SlotDef(0.40, () => new LeatherGloves(), () => new PlateGloves()) },

            // Belt/apron (smiths, fighters)
            { "Belt", new SlotDef(0.30, () => new FullApron(), () => new HalfApron()) },

            // Gorget/neck
            { "Neck", new SlotDef(0.20, () => new LeatherGorget(), () => new PlateGorget()) },

            // Right hand: Jhelom is all about weapons!
            { "RightHand", new SlotDef(0.90,
                () => new Broadsword(),
                () => new Longsword(),
                () => new Katana(),
                () => new Axe(),
                () => new Club(),
                () => new Spear(),
                () => new Mace(),
                () => new WarHammer(),
                () => new Halberd(),
                () => new Pitchfork(),
                () => new Cutlass()
            )},

            // Off hand: mostly shield, rarely torch
            { "LeftHand", new SlotDef(0.35,
                () => new Shield(),
                () => new Buckler(),
                () => new MetalShield(),
                () => new WoodenShield(),
                () => new Torch()
            )},
        };

        // ---- Jhelom Quest Factories: same as your base, but force Faction to Jhelom if possible ----
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Examples using "Jhelom" as the faction if possible!
            () => new FactionCollectionQuestScroll("Leather", 20, "Jhelom", 5000),
            () => new FactionDeliveryQuestScroll("Rat Nemesis", "Jhelom", 2500),
            () => new FactionKillQuestScroll("Dragon", 5, "Jhelom", 12000),
			
            () => new FactionCollectionQuestScroll("Infinityclay", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("MageCherryFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("HazelLimeFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("slirindFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("gropioveFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Photoplasmene", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Kryotoxite", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Scales", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("MiniPistacioSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("CabbageSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("NewAquariumBook", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("SourAmaranthFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("PeanutSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("GinsengSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("FlammablePlasmine", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("PinkCarnationSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("DandelionSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Fibrogen", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("imberFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("LettuceSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("IrishRoseSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("NativeRambutanFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("BlackberrySeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("MysteryOrangeFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("fudishFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("qekliatilloFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("PotionKeg", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("moyiarlanFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("MiniAppleSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Bloodglass", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Beeswax", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Lumicryne", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("WoodenBowlOfCarrots", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("BeetSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Astrocyne", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("AquariumNorthDeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("NightshadeSeed", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Uranimite", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Hoe", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("vropperrotFruit", 25, "Jhelom", 750),
            () => new FactionCollectionQuestScroll("Aeroglass", 25, "Jhelom", 750),			

            () => new FactionKillQuestScroll("EarthAlchemist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Electrician", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("ElementalWizard", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Enchanter", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("EpeeSpecialist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("EscapeArtist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("EvidenceAnalyst", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Explorer", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("ExplosiveDemolitionist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("FeastMaster", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("FencingMaster", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("FieldCommander", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("FieldMedic", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("FireAlchemist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("FireMage", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Firestarter", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("FlameWelder", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Flutist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Forager", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("ForensicAnalyst", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("ForestMinstrel", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("ForestScout", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("ForestTracker", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("GemCutter", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("GhostScout", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("GhostWarrior", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("GourmetChef", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("GraveDigger", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("GrecoRomanWrestler", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("GrillMaster", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("HammerGuard", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Harpist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Herbalist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("HerbalistPoisoner", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("IceSorcerer", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Illusionist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Infiltrator", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("InvisibleSaboteur", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("IronSmith", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("JavelinAthlete", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Joiner", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("JungleNaturalist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("KarateExpert", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("KatanaDuelist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("KnifeThrower", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("KnightOfJustice", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("KnightOfMercy", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("KnightOfValor", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Kunoichi", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("SpearFisher", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("SpearSentry", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Spellbreaker", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("SpiritMedium", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Spy", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("StarReader", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("StormCaller", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("StormConjurer", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Strategist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("SumoWrestler", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("SwordDefender", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("TaekwondoMaster", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("TerrainScout", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("ToxicologistChef", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("TrapEngineer", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("TrapMaker", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("TrapSetter", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("TreeFeller", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("TrickShotArtist", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("UrbanTracker", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("VenomousAssassin", "5", "Jhelom", "500"),
            () => new FactionKillQuestScroll("Violinist", "5", "Jhelom", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Jhelom, 350),				
			
            // ...add more as your quest scrolls allow!
        };

        // ---- Jhelom Names and Titles ----
        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                // Jhelom: Strong, martial, Old English/Norse, plus gender-neutral
                "Bjorn", "Cedric", "Eadric", "Gunnar", "Hilda", "Ingrid", "Leif", "Magnus", "Ragnhild", "Sigurd", "Thora", "Ulf", "Viggo", "Yrsa",
                "Aldric", "Bran", "Doran", "Edith", "Frey", "Greta", "Hroth", "Ivar", "Jorunn", "Kjell", "Lars", "Marek", "Odin", "Rurik", "Sigrid",
                "Torin", "Ulric", "Vera", "Wulf", "Ylva", "Astrid", "Erik", "Sven", "Eirik", "Sten", "Runar", "Soren", "Kara", "Lotta", "Elin"
            };

            string[] lastNames = new[]
            {
                // Jhelom: Fighters, pitfolk, trainers, guards, smiths, sailors
                "Ironfist", "Pitfighter", "Stonearm", "Hammerhand", "Swordson", "Shieldbearer", "Steelgrip", "Axebringer", "Bladeward", "Clubfoot",
                "Maulson", "Wolfkin", "Hawkguard", "Stormrider", "Strongarm", "Oakenshield", "Goldbeard", "Swiftblade", "Redmane", "Halberdson",
                "Longspear", "Macesworn", "Steelbrow", "Fleetfoot", "Brawlmaster", "Trainer", "Pitboss", "Battler", "Duelist", "Gladiator"
            };

            string[] titles = new[]
            {
                // Jhelom: Valor, strength, training, fighting pits, defense
                "the Brave", "the Stalwart", "the Fighter", "the Pit Champion", "the Swordhand",
                "the Shieldmaiden", "the Axe Thrower", "the Duelist", "the Pit Guard", "the Instructor",
                "the Sellsword", "the Gladiator", "the Defender", "the Brawler", "the Sentinel",
                "the Captain", "the Sergeant", "the Veteran", "the Armorer", "the Recruiter",
                "the Challenger", "the Swordsmith", "the Mercenary", "the Watchman", "the Pit Referee",
                "the Quartermaster", "of the Fighting Pits", "of Jhelom", "of the Arena"
            };

            string first = firstNames[Utility.Random(firstNames.Length)];
            string last = lastNames[Utility.Random(lastNames.Length)];
            string title = titles[Utility.Random(titles.Length)];
            return $"{first} {last} {title}";
        }

        // --------- Construction and outfit -----------
        [Constructable]
        public CitizenOfJhelom()
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
            SetStr(Utility.RandomMinMax(60, 110));
            SetDex(Utility.RandomMinMax(60, 110));
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
                    item.Hue = Utility.RandomMinMax(300, 2400); // more subdued Jhelom colors
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1, 2000);
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
                player.SendMessage("Here, take this quest scroll! Fight with valor for Jhelom!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfJhelom _npc;
            private readonly Mobile _from;
            public QuestEntry(Mobile from, CitizenOfJhelom npc)
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
        public CitizenOfJhelom(Serial serial) : base(serial) { }
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
