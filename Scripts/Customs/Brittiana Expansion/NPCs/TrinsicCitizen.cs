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
    [CorpseName("the remains of a Trinsic citizen")]
    public class TrinsicCitizen : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ------------------- Trinsic Equipment Pool ------------------------
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
            { "Footwear", new SlotDef(0.95, () => new Boots(), () => new Shoes(), () => new Sandals(), () => new ThighBoots()) },
            { "Robe", new SlotDef(0.20, () => new Robe(), () => new FancyDress(), () => new MonkRobe()) },
            { "Back", new SlotDef(0.05, () => new Cloak()) },
            { "Head", new SlotDef(0.15, () => new Cap(), () => new Bonnet(), () => new WideBrimHat(), () => new StrawHat()) },
            { "Shirt", new SlotDef(0.85, () => new Shirt(), () => new FancyShirt(), () => new Tunic(), () => new BodySash()) },
            { "Chest", new SlotDef(0.10, () => new LeatherChest(), () => new StuddedChest()) }, // Light armor, occasional
            { "Legs", new SlotDef(0.90, () => new LongPants(), () => new ShortPants(), () => new Skirt(), () => new Kilt()) },
            { "Belt", new SlotDef(0.30, () => new HalfApron(), () => new FullApron()) },
            { "Neck", new SlotDef(0.10, () => new Necklace()) },
            { "Hands", new SlotDef(0.05, () => new LeatherGloves()) },
            { "LeftHand", new SlotDef(0.10, () => new Buckler(), () => new WoodenShield()) }, // Rarely civic guards may have a shield
            { "RightHand", new SlotDef(0.10, () => new Club(), () => new Pitchfork(), () => new ShepherdsCrook(), () => new Cutlass()) }, // Occasional tool or light weapon
        };

        // --------------- Trinsic Themed Quest Scrolls (ALL FACTION: TRINSIC) ---------------
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            () => new FactionCollectionQuestScroll("Leather", 10, "Trinsic", 500), // Adapt these for your system
            () => new FactionCollectionQuestScroll("IronIngot", 20, "Trinsic", 1200),
            () => new FactionDeliveryQuestScroll("Supplies", "Trinsic", 150),
            () => new FactionKillQuestScroll("Brigand", 8, "Trinsic", 800),
            () => new FactionCollectionQuestScroll("IronIngot", 20, "Trinsic", 600),
            () => new FactionDeliveryQuestScroll("Rat Nemesis", "Trinsic", 300),
            () => new FactionKillQuestScroll("Orc", 10, "Trinsic", 900),
            () => new FactionRegionKillQuestScroll("Sewers", 12, XmlMobFactions.GroupTypes.Trinsic, 750, typeof(BlackPearl)),
            () => new FactionTamingQuestScroll(typeof(HellCat), 2, XmlMobFactions.GroupTypes.Trinsic, 400, typeof(Bone)),

            () => new FactionCollectionQuestScroll("DoubleBladedStaff", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("ElvenCompositeLongbow", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("ElvenMachete", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("ElvenSpellblade", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("JukaBow", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Kama", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Lajatang", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Leafblade", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("MagicalShortbow", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("NoDachi", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Nunchaku", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Pickaxe", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Tekagi", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Tessen", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Tetsubo", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Wakizashi", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("WildStaff", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Yumi", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Shield", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Lantern", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("BronzeShield", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Buckler", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("HeaterShield", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("MetalKiteShield", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("MetalShield", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("OrderShield", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("ChaosShield", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("WoodenKiteShield", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("WoodenShield", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Torch", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("FootStool", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("BarrelStaves", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("BarrelLid", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Stool", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("WoodenBox", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("SmallCrate", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("MediumCrate", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("LargeCrate", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("WoodenChest", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("EmptyBookcase", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("WoodenBench", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("WoodenThrone", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("TallCabinet", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("FriedEggs", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Ribs", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Arrow", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Bolt", 25, "Trinsic", 750),
            () => new FactionCollectionQuestScroll("Kindling", 25, "Trinsic", 750),

            () => new FactionKillQuestScroll("RiptideCrab ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("ShadowCrab ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("StormCrab ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("VortexCrab ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("AbyssalWarden ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("BlightDemon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("CursedHarbinger ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Deadlord ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("FrostboundBehemoth ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("HellfireJuggernaut ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("InfernalIncinerator ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("StormDeamon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("ToxicReaver ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("VoidStalker ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("AncientDragon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("BloodDragon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("CelestialDragon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("CrystalDragon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("EtherealDragon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("FrostDrakon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("InfernoDrakon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("NatureDragon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("ShadowDragon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("StormDragon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("VenomousDragon ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("CrystalWarden ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("FossilElemental ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("GraniteColossus ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("LavaFiend ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("MagmaGolem ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("MudGolem ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("QuakeBringer ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("SandstormElemental ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("StoneGuardian ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("TerraWisp ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("CerebralEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("EarthquakeEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("FlameWardenEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("FrostWardenEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("IllusionistEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("NecroEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("StormcallerEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("TidalEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("TwinTerrorEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("VenomousEttin ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("BubbleFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("DreamyFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("FrostyFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("GlimmeringFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("HarmonyFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("MysticFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("PuffyFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("SparkFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("StarryFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("SunbeamFerret ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Banshee ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Chaneque ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Dryad ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Fairy ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Leprechaun ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Nymph ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Puck ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Selkie ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("Sidhe ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("WillOTheWisp ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("CinderWraith ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("EmberSerpent ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("EmberSpirit ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("FlareImp ", "5", "Trinsic", "500"),
            () => new FactionKillQuestScroll("InfernalDuke ", "5", "Trinsic", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Trinsic, 350),				
			
            // Add/modify as fits your quest system!
        };

        // ------------- Names & Titles (Trinsic/Civic flavor) --------------
        private static readonly string[] FirstNames = new[]
        {
            "Aldric", "Bran", "Cedric", "Darian", "Edric", "Gareth", "Harold", "Ivor", "Jonas", "Kara",
            "Leona", "Mira", "Ned", "Oswin", "Perrin", "Quinn", "Rhea", "Soren", "Tamsin", "Ulric",
            "Vera", "Wilfred", "Ysolde", "Zara"
        };

        private static readonly string[] LastNames = new[]
        {
            "Smith", "Cooper", "Fletcher", "Mason", "Thatcher", "Tanner", "Wainwright", "Carter",
            "Scribe", "Baker", "Weaver", "Miller", "Turner", "Falkner", "Porter", "Shepherd", "Steward"
        };

        private static readonly string[] Titles = new[]
        {
            "of Trinsic", "the Baker", "the Cobbler", "the Mason", "the Farmer", "the Merchant",
            "the Fisher", "the Sailor", "the Townsfolk", "the Watchman", "the Scribe", "the Steward",
            "the Innkeeper", "the Apprentice", "the Craftsman", "the Child", "the Housewife", "the Elder",
            "the Widow", "the Apprentice", "the Blacksmith", "the Stablehand", "the Cooper", "the Chandler"
        };

        [Constructable]
        public TrinsicCitizen()
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
            string first = FirstNames[Utility.Random(FirstNames.Length)];
            string last = LastNames[Utility.Random(LastNames.Length)];
            string title = Titles[Utility.Random(Titles.Length)];
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
                    item.Hue = Utility.RandomMinMax(2000, 3000);
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
            private readonly TrinsicCitizen _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, TrinsicCitizen npc)
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
        public TrinsicCitizen(Serial serial) : base(serial) { }

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
