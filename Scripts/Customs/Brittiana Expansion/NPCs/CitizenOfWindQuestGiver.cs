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
    [CorpseName("the remains of a Wind citizen")]
    public class CitizenOfWindQuestGiver : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // -- Equipment: mage-only, scholarly, magical
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
            { "Footwear", new SlotDef(0.95,
                () => new Sandals(),
                () => new Shoes(),
                () => new ElvenBoots()
            )},

            { "Robe", new SlotDef(1.0,
                () => new Robe(),
                () => new GildedDress(),
                () => new MonkRobe(),
                () => new HoodedShroudOfShadows(),
                () => new MaleElvenRobe(),
                () => new FemaleElvenRobe()
            )},

            { "Back", new SlotDef(0.3,
                () => new Cloak(),
                () => new HoodedShroudOfShadows()
            )},

            { "Head", new SlotDef(0.7,
                () => new WizardsHat(),
                () => new Circlet(),
                () => new SkullCap()
            )},

            { "Shirt", new SlotDef(0.4,
                () => new FancyShirt(),
                () => new Tunic()
            )},

            // Only magical implements and books in hands
            { "RightHand", new SlotDef(0.8,
                () => new GnarledStaff(),
                () => new BlackStaff(),
                () => new QuarterStaff(),
                () => new Spellbook(),
                () => new MagicWand(),
                () => new MageWand(),
                () => new NecromancersStaff()
            )},
            { "LeftHand", new SlotDef(0.5,
                () => new Spellbook()
            )},

            { "Neck", new SlotDef(0.2,
                () => new ElegantCollar(),
                () => new Necklace()
            )},

            // Very rare magic rings or talismans
            { "Ring", new SlotDef(0.05,
                () => new GoldRing()
            )},
            { "Talisman", new SlotDef(0.05,
                () => new RandomTalisman()
            )},
        };

        // -- Quests: ALL Wind faction only (for each quest type, ensure faction is set to Wind)
        // For demonstration: here's how to ensure all are for "Wind" (adjust your custom quest scroll constructors if needed)
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Examples (replace with your own constructors if needed, but always for Wind)
            () => new FactionCollectionQuestScroll("MandrakeRoot", 10, "Wind", 800),
            () => new FactionDeliveryQuestScroll("Ancient Tome", "Wind", 1),
            () => new FactionKillQuestScroll("Daemon", 3, "Wind", 2000),
			
            () => new FactionCollectionQuestScroll("BlackPowder", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Saltpeter", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Charcoal", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Matchcord", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Potash", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("SmokeBomb", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("HoveringWisp", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("NaturalDye", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("ColorFixative", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("NexusCore", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("DarkSapphire", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("CrushedGlass", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("CrystalGranules", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("CrystalDust", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("SoftenedReeds", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("VialOfVitriol", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("DryReeds", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("CrystallineFragments", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("ShimmeringCrystals", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("SilverSerpentVenom", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("BottleIchor", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("GoldDust", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Boots", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Sandals", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Shoes", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("NinjaTabi", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("FurBoots", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("ThighBoots", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("ElvenBoots", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("SamuraiTabi", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Waraji", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("JesterShoes", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Robe", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("FancyDress", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("GildedDress", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("DeathRobe", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("MonkRobe", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("Kamishimo", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("HakamaShita", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("MaleKimono", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("FemaleKimono", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("MaleElvenRobe", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("FemaleElvenRobe", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("FloweredDress", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("EveningGown", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("PlainDress", 25, "Wind", 750),
            () => new FactionCollectionQuestScroll("HoodedShroudOfShadows", 25, "Wind", 750),			

            () => new FactionKillQuestScroll("KasTheBloodyHanded ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("KelThuzad ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("LarlochTheShadowKing ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("Nagash ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("RaistlinMajere ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("SothTheDeathKnight ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("SzassTam ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("Vecna ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("BloodLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("FrostLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("InfernalLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("NecroticLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("PlagueLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("ShadowLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("SoulEaterLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("StormLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("ToxicLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("WraithLich ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("CactusLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("CharroLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("DiaDeLosMuertosLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("ElMariachiLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("FiestaLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("LuchadorLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("SombreroDeSolLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("SombreroLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("TacoLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("TequilaLlama ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("AkhenatenTheHeretic ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("CleopatraTheEnigmatic ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("HatshepsutTheQueen ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("KhufuTheGreatBuilder ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("MentuhotepTheWise ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("Nefertiti ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("RamsesTheImmortal ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("SetiTheAvenger ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("ThutmoseTheConqueror ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("TutankhamunTheCursed ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("BonecrusherOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("ChromaticOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("FlamebringerOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("FleshEaterOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("FrostOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("GloomOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("IroncladOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("NecroticOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("ShadowOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("StormOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("ToxicOgre ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("AbyssalPanther ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("CelestialHorror ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("CosmicStalker ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("EtherealPanthra ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("NebulaCat ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("NightmarePanther ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("PhantomPanther ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("StarbornPredator ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("VoidCat ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("BabirusaBeast ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("BorneoPig ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("BushPig ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("DomesticSwine ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("GiantForestHog ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("HogWild ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("JavelinaJinx ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("PeccaryProtector ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("VietnamesePig ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("WarthogWarrior ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("AbyssalBouncer ", "5", "Wind", "500"),
            () => new FactionKillQuestScroll("ChaosHare ", "5", "Wind", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Wind, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Wind, 350),				
			
            // ... add as many as you want, but always "Wind" as the faction
        };

        // -- Names: magical, arcane, mysterious
        private static readonly string[] FirstNames = new[]
        {
            "Azrael", "Sorion", "Maelis", "Seraphi", "Zyra", "Thalor", "Elowen", "Orith", "Veyra", "Celian",
            "Quelor", "Lirael", "Zephir", "Morwyn", "Eldrin", "Soreth", "Yllari", "Nalin", "Kaelis", "Ilithra",
            "Aeris", "Valen", "Nyra", "Syrae", "Orin", "Valthor", "Selene", "Dorian", "Mirael", "Kaelis"
        };
        private static readonly string[] LastNames = new[]
        {
            "the Arcane", "the Wise", "of Wind", "the Hidden", "Spellbinder", "Runeseeker", "Whispercloak",
            "Sage of Wind", "Magister", "Lorekeeper", "Warden of the Gate", "the Unseen", "of the Aether",
            "Enchanter", "the Ethereal", "the Occult", "Archmage", "Conjuror", "the Shrouded", "Windspeaker"
        };
        private static readonly string[] Titles = new[]
        {
            "Scholar of Wind", "Mage of the Hidden City", "Keeper of Lore", "Runecaster", "Mistress of Runes",
            "Seeker of Wisdom", "Initiate of the Arcane", "Adept of Wind", "Loremaster", "Magus of the Aether",
            "Watcher of the Veil", "Custodian of Spells"
        };

        [Constructable]
        public CitizenOfWindQuestGiver()
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

            // Name and title
            string first = FirstNames[Utility.Random(FirstNames.Length)];
            string last = LastNames[Utility.Random(LastNames.Length)];
            string title = Titles[Utility.Random(Titles.Length)];
            Name = $"{first} {last}";
            Title = title;

            SetStr(Utility.RandomMinMax(50, 80));
            SetDex(Utility.RandomMinMax(50, 80));
            SetInt(Utility.RandomMinMax(80, 120));
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
                    item.Hue = Utility.RandomMinMax(900, 1150); // Ethereal, blue, or silver hues
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1, 2999);
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
                player.SendMessage($"The mystical energies are spent. Return in {wait.Minutes} minute(s).");
                return;
            }

            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;

            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("The magic falters. Try again later.");
                return;
            }

            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("You receive a magical quest scroll from the Citizen of Wind!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfWindQuestGiver _npc;
            private readonly Mobile _from;
            public QuestEntry(Mobile from, CitizenOfWindQuestGiver npc)
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
        public CitizenOfWindQuestGiver(Serial serial) : base(serial) { }
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
