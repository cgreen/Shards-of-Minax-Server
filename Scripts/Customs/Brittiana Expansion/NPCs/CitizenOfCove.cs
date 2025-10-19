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
    [CorpseName("the remains of a Cove villager")]
    public class CitizenOfCove : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ------------ Equipment Pool: Only humble Cove-appropriate items -------------
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
            // Shoes or bare feet
            { "Footwear",   new SlotDef(0.85,
                () => new Boots(),
                () => new Sandals(),
                () => new Shoes(),
                () => new ThighBoots()
            )},
            // Simple shirts/dresses
            { "Shirt",      new SlotDef(1.0,
                () => new Shirt(),
                () => new PlainDress(),
                () => new Tunic(),
                () => new Doublet()
            )},
            // Simple pants or skirt
            { "Legs",       new SlotDef(0.95,
                () => new LongPants(),
                () => new ShortPants(),
                () => new Skirt(),
                () => new Kilt()
            )},
            // Fisherfolk apron or none
            { "Belt",       new SlotDef(0.50,
                () => new HalfApron()
            )},
            // Humble headgear, orcish options sometimes
            { "Head",       new SlotDef(0.20,
                () => new StrawHat(),
                () => new Cap(),
                () => new Bandana(),
                () => new OrcMask() // For half-orc villagers
            )},
            // Cloaks/robes rare, mostly cold weather or for elders
            { "Robe",       new SlotDef(0.10,
                () => new Robe(),
                () => new Cloak()
            )},
            // Fisherfolk might have these
            { "Hands",      new SlotDef(0.10,
                () => new LeatherGloves()
            )},
            // Faction-appropriate weapons/tools (rare)
            { "RightHand",  new SlotDef(0.15,
                () => new FishingPole(),
                () => new Dagger(),
                () => new Club(),
                () => new SkinningKnife()
            )},
            // Off-hand lantern, rare
            { "LeftHand",   new SlotDef(0.05,
                () => new Lantern()
            )},
        };

        // ------------- Quest Pool: Only Cove Faction Quests --------------
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Only Faction quests; you can add more if you have other Cove-specific scrolls!
            () => new FactionCollectionQuestScroll("FishSteak", 25, "Cove", 800), // sample fish gathering quest
            () => new FactionCollectionQuestScroll("Wool", 20, "Cove", 500),
            () => new FactionDeliveryQuestScroll("Supplies", "Cove", 200), // delivery to compassion shrine
			
            () => new FactionCollectionQuestScroll("CompositeBow", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("Crossbow", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("HeavyCrossbow", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("RepeatingCrossbow", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("Bow", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("Dagger", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("Kryss", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("SkinningKnife", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("Pitchfork", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("BlackStaff", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("GnarledStaff", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("QuarterStaff", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("ShepherdsCrook", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("BladedStaff", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("Scythe", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("Scepter", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("MagicWand", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("AnimalClaws", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("WrestlingBelt", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("ArtificerWand", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("BashingShield", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("BeggersStick", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("BoltRod", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("CampingLanturn", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("CarpentersHammer", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("CooksCleaver", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("DetectivesBoneHarvester", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("DistractingHammer", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("ExplorersMachete", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("FireAlchemyBlaster", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("FishermansTrident", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("FletchersBow", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("FocusKryss", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("GearLauncher", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("GourmandsFork", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("HolyKnightSword", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("IllegalCrossbow", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("IntelligenceEvaluator", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("LoreSword", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("MageWand", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("MallKatana", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("MeatPicks", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("MeditationFans", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("MerchantsShotgun", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("MysticStaff", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("NecromancersStaff", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("NinjaBow", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("Nunchucks", 25, "Cove", 750),
            () => new FactionCollectionQuestScroll("PoisonBlade", 25, "Cove", 750),			

            () => new FactionKillQuestScroll("PhantomAutomaton ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("QuantumGuardian ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("SynthroidPrime ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("TalonMachine ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("Dreadnaught ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("ElectroWraith ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("FrostDroid ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("GrapplerDrone ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("InfernoSentinel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("NanoSwarm ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("PlasmaJuggernaut ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("SpectralAutomaton ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("TacticalEnforcer ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("VortexConstruct ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("ArcaneSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("CelestialSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("EnigmaticSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("FrenziedSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("GentleSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("MelodicSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("MysticSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("RhythmicSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("TempestSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("WickedSatyr ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("BubblegumBlaster ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("CandyCornCreep ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("CaramelConjurer ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("ChocolateTruffle ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("GummySheep ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("JellybeanJester ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("LicoriceSheep ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("LollipopLord ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("PeppermintPuff ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("TaffyTitan ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("ArcaneSentinel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("FlameborneKnight ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("FrostboundChampion ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("GraveKnight ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("IroncladDefender ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("NecroticGeneral ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("ShadowbladeAssassin ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("SpectralWarden ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("StormBone ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("VampiricBlade ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("AcidicSlime ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("CrystalOoze ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("ElectricSlime ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("FrozenOoze ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("GlisteningOoze ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("MoltenSlime ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("RadiantSlime ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("ShadowSludge ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("ToxicSludge ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("VoidSlime ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("AlbertsSquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("BeldingsGroundSquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("DouglasSquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("EasternGraySquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("FlyingSquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("FoxSquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("IndianPalmSquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("RedSquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("RedTailedSquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("RockSquirrel ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("BlightedToad ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("CorrosiveToad ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("CursedToad ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("EldritchToad ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("FungalToad ", "5", "Cove", "500"),
            () => new FactionKillQuestScroll("InfernalToad ", "5", "Cove", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Cove, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Cove, 350),				
			
            // add more as you wish
        };

        // ------------ Random Cove Name/Title (with half-orc options) -----------
        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Davin", "Mira", "Cerin", "Lina", "Willem", "Thora", "Edric", "Jessa", "Bran", "Lira",
                "Finn", "Rhea", "Elyn", "Tomas", "Bara", "Hal", "Tilda", "Anwen", "Tor", "Meryl",
                // Half-orc variants
                "Grush", "Gor", "Ugna", "Drog", "Ruk", "Brug", "Krug", "Mugra"
            };
            string[] lastNames = new[]
            {
                "Netcatcher", "Fishhook", "Stonecutter", "Barleycorn", "Millson", "Hayward", "Willowbend", "Brookside",
                "Goodfellow", "Kindly", "Oatfield", "Rivers", "Croft", "Truesilver", "Carver", "Thatch", "Pond", "Oarsman",
                // Half-orc variants
                "the Half-Orc", "Grottsplitter", "Bogtusk", "Mudjaw", "Orcfriend"
            };
            string[] titles = new[]
            {
                "of Cove", "the Fisherman", "the Fisherwoman", "the Compassionate", "the Dockhand", "the Weaver",
                "the Candle-maker", "the Cook", "the Ferryman", "the Seamstress", "the Netmender", "the Millwright",
                "the Shepherd", "the Goodwife", "the Young", "the Elder", "the Kindly", "the Hermit", "the Cowherd",
                "the Midwife", "the Fishwife", "the Tanner", "the Cooper", "the Mason",
                // Half-orc
                "the Unusual", "of the Orc Fort", "the Outsider"
            };
            return $"{firstNames[Utility.Random(firstNames.Length)]} {lastNames[Utility.Random(lastNames.Length)]} {titles[Utility.Random(titles.Length)]}";
        }

        // ------------ Random Appearance/Outfit -----------------
        [Constructable]
        public CitizenOfCove()
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
            // For half-orc: body/hue could be randomly different
            bool halfOrc = Utility.RandomDouble() < 0.15; // 15% chance
            Body = halfOrc ? 17 : (Female ? 0x191 : 0x190); // 17 is Orc body
            Hue = halfOrc ? 33770 : Utility.RandomSkinHue(); // 33770 is orc green, or use your shard's hue
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
            SetStr(Utility.RandomMinMax(30, 60));
            SetDex(Utility.RandomMinMax(30, 60));
            SetInt(Utility.RandomMinMax(20, 50));
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
                    item.Hue = Utility.RandomMinMax(1000, 2700);
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
                player.SendMessage("Here, take this Cove quest scroll!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfCove _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfCove npc)
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

        public CitizenOfCove(Serial serial) : base(serial) { }

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
