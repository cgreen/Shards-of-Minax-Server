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
    [CorpseName("the remains of a Serpent's Hold citizen")]
    public class CitizenOfSerpentsHold : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // --- Serpent’s Hold Equipment: Monastic and Martial (simpler pool) ---
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

        // NOTE: Minimal, monk/knight/serpent theme only.
        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            { "Footwear", new SlotDef(0.95,
                () => new Sandals(), () => new Boots(), () => new Shoes()
            )},
            { "Robe", new SlotDef(0.40,
                () => new MonkRobe(), () => new Robe(), () => new DeathRobe()
            )},
            { "Shirt", new SlotDef(0.70,
                () => new Tunic(), () => new Shirt(), () => new FancyShirt(), () => new BodySash()
            )},
            { "Chest", new SlotDef(0.30,
                () => new PlateChest(), () => new ChainChest(), () => new LeatherChest(), () => new StuddedChest()
            )},
            { "Legs", new SlotDef(0.70,
                () => new LongPants(), () => new ShortPants(), () => new PlateLegs(), () => new LeatherLegs(), () => new ChainLegs()
            )},
            { "Arms", new SlotDef(0.30,
                () => new PlateArms(), () => new LeatherArms()
            )},
            { "Hands", new SlotDef(0.30,
                () => new LeatherGloves(), () => new PlateGloves()
            )},
            { "Belt", new SlotDef(0.60,
                () => new FullApron(), () => new HalfApron()
            )},
            { "Head", new SlotDef(0.30,
                () => new Circlet(), () => new Bascinet(), () => new CloseHelm(), () => new SkullCap()
            )},
            { "Back", new SlotDef(0.10,
                () => new Cloak()
            )},
            { "Neck", new SlotDef(0.10,
                () => new PlateGorget(), () => new LeatherGorget()
            )},
            // Right hand: light martial, staff, shield
            { "RightHand", new SlotDef(0.60,
                () => new Longsword(), () => new Broadsword(), () => new Mace(), () => new QuarterStaff(), () => new BlackStaff(), () => new Shield()
            )},
            // Offhand: shield (sometimes), lantern
            { "LeftHand", new SlotDef(0.20,
                () => new Shield(), () => new Lantern()
            )},
        };

        // --- All quests are for Serpent’s Hold faction! ---
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Always set Faction to "Serpent's Hold" (customize your scroll constructors if needed)
            () => new FactionCollectionQuestScroll("Leather", 20, "Serpent's Hold", 2000),
            () => new FactionCollectionQuestScroll("IronIngot", 20, "Serpent's Hold", 2000),
            () => new FactionDeliveryQuestScroll("Potion", "Serpent's Hold", 500),
            () => new FactionKillQuestScroll("Orc", 10, "Serpent's Hold", 1000),
			
            () => new FactionCollectionQuestScroll("IronIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("ColdIronIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("SilverIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("DullCopperIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("ShadowIronIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("CopperIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("BronzeIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("GoldIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("AgapiteIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("VeriteIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("ValoriteIngot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("RefreshPotion", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("AgilityPotion", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("NightSightPotion", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("LesserHealPotion", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("StrengthPotion", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("LesserPoisonPotion", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("LesserCurePotion", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("LesserExplosionPotion", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("MortarPestle", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("BlackPearl", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Bloodmoss", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Garlic", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Ginseng", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("MandrakeRoot", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Nightshade", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("SpidersSilk", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("SulfurousAsh", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Bottle", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Bacon", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Ham", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Sausage", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("RawChickenLeg", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("RawBird", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("RawLambLeg", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("RawRibs", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Board", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("BreadLoaf", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("ApplePie", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Cake", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("Muffins", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("CheeseWheel", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("CookedBird", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("LambLeg", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("ChickenLeg", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("SackFlour", 25, "SerpentsHold", 750),
            () => new FactionCollectionQuestScroll("JarHoney", 25, "SerpentsHold", 750),

            () => new FactionKillQuestScroll("AbysmalHorror", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("AbyssalAbomination", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("AcidElemental", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("AcidPopper", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("AcidSlug", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("AgapiteElemental", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("AirElemental", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Alligator", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("AncientLich", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("AncientWyrm", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("AntLion", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("ArcaneDaemon", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("ArchDaemon", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("ArcticOgreLord", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BakeKitsune", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Balron", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BattleChickenLizard", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Beetle", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Betrayer", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Bird", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BlackBear", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BlackSolenInfiltratorQueen", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BlackSolenInfiltratorWarrior", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BlackSolenQueen", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BlackSolenWarrior", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BlackSolenWorker", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BloodElemental", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BloodFox", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BloodWorm", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Boar", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Bogle", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Bogling", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BogThing", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BoneDemon", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BoneKnight", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BoneMagi", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BronzeElemental", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BrownBear", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BulbousPutrification", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Bull", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("BullFrog", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CapturedHordeMinion", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Cat", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Centaur", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Changeling", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("ChaosDaemon", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("ChaosDragoon", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("ChaosDragoonElite", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Chicken", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("ChickenLizard", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("ClockworkScorpion", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CoconutCrab", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("ColdDrake", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CopperElemental", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CoralSnake", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CorporealBrume", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Corpser", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CorrosiveSlime", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CorruptedSoul", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Cougar", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Cow", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Crane", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CrimsonDrake", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CrystalDaemon", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CrystalElemental", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CrystalHydra", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CrystalLatticeSeeker", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CrystalSeaSerpent", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CrystalVortex", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("CrystalWisp", "5", "SerpentsHold", "500"),
            () => new FactionKillQuestScroll("Cursed", "5", "SerpentsHold", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.SerpentsHold, 350),							
			
        };

        // --- Serpent's Hold–style names and titles ---
        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Aldric", "Cedric", "Godric", "Osric", "Eadric", "Leofric", "Alaric", "Edwin", "Wilfred", "Cuthbert",
                "Beorn", "Edmund", "Wulfric", "Hilda", "Edith", "Brunhild", "Matilda", "Mildred", "Elena", "Sibyl",
                "Gawain", "Percival", "Tristan", "Rowena", "Elaine", "Seraphine", "Isolde", "Merrick", "Galen", "Lucan"
            };

            string[] lastNames = new[]
            {
                "Serpenthelm", "Silverblade", "Serpentguard", "Serpentwarden", "Palewatch", "Stoneshield", "Brightblade", "Faithward", "Nightward",
                "Lightbringer", "Oathkeeper", "Shieldbearer", "Steelfaith", "Dragonsbane", "Dawnward", "Serpentheart", "Shieldhand", "Templeton", "Sanctuary", "Wayfarer"
            };

            string[] titles = new[]
            {
                "the Devout", "the Monk", "the Paladin", "the Squire", "the Watchman", "the Serpent's Acolyte", "the Faithful", "the Sentinel",
                "the Guardian", "the Serpent Disciple", "of the Silver Serpent", "the Penitent", "the Serpentkeeper", "the Warden", "Knight of Serpent's Hold",
                "the Castellan", "the Defender", "the Virtuous", "Keeper of the Shrine", "the Novice", "the Initiate", "of Empath Abbey", "of the Order"
            };

            string first = firstNames[Utility.Random(firstNames.Length)];
            string last = lastNames[Utility.Random(lastNames.Length)];
            string title = titles[Utility.Random(titles.Length)];

            return $"{first} {last} {title}";
        }

        [Constructable]
        public CitizenOfSerpentsHold()
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
                    item.Hue = Utility.RandomMinMax(2301, 2390); // Serpent's Hold: silver/blue/greyish (customize as needed)
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
                player.SendMessage("Here, take this Serpent's Hold quest scroll!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfSerpentsHold _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfSerpentsHold npc)
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

        public CitizenOfSerpentsHold(Serial serial) : base(serial) { }
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
