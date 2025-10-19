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
    [CorpseName("the remains of a Yew townsfolk")]
    public class CitizenOfYewQuestGiver : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ------------- YEW‐THEMED EQUIPMENT -------------
        private class SlotDef
        {
            public double Chance;
            public Func<Item>[] Pool;
            public SlotDef(double chance, params Func<Item>[] pool)
            {
                Chance = chance; Pool = pool;
            }
        }

        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            // Footwear
            { "Footwear", new SlotDef(0.98,
                () => new Boots(),
                () => new Shoes(),
                () => new FurBoots(),
                () => new Sandals()
            )},
            // Robe/tunic (Abbey theme)
            { "Robe", new SlotDef(0.45,
                () => new MonkRobe(),
                () => new Robe(),
                () => new Tunic(),
                () => new PlainDress(),
                () => new Surcoat()
            )},
            // Cloak/back
            { "Back", new SlotDef(0.18,
                () => new Cloak(),
                () => new BodySash(),
                () => new Quiver()
            )},
            // Headgear (woodland, simple, or legal)
            { "Head", new SlotDef(0.44,
                () => new FeatheredHat(),
                () => new WideBrimHat(),
                () => new StrawHat(),
                () => new Bandana(),
                () => new Bonnet(),
                () => new BearMask(),
                () => new StrawHat()
            )},
            // Shirts/tops
            { "Shirt", new SlotDef(0.75,
                () => new FancyShirt(),
                () => new Shirt(),
                () => new Tunic(),
                () => new Doublet(),
                () => new BodySash()
            )},
            // Chest armor (rare, only leather/studded)
            { "Chest", new SlotDef(0.12,
                () => new LeatherChest(),
                () => new StuddedChest()
            )},
            // Legs
            { "Legs", new SlotDef(0.72,
                () => new LongPants(),
                () => new ShortPants(),
                () => new LeatherLegs(),
                () => new Skirt()
            )},
            // Arms (leather only, rare)
            { "Arms", new SlotDef(0.10,
                () => new LeatherArms()
            )},
            // Hands (leather gloves)
            { "Hands", new SlotDef(0.24,
                () => new LeatherGloves()
            )},
            // Belt/apron (woodworking/crafts)
            { "Belt", new SlotDef(0.32,
                () => new HalfApron(),
                () => new FullApron()
            )},
            // Neck/gorget (almost never)
            { "Neck", new SlotDef(0.05,
                () => new LeatherGorget()
            )},
            // Weapons — focus on archery/woodland
            { "RightHand", new SlotDef(0.65,
                () => new Bow(),
                () => new CompositeBow(),
                () => new Crossbow(),
                () => new SkinningKnife(),
                () => new Dagger(),
                () => new Club(),
                () => new ShepherdsCrook()
            )},
            // Off‐hand
            { "LeftHand", new SlotDef(0.15,
                () => new Lantern(),
                () => new Buckler()
            )},
        };

        // ------------------- QUESTS: Yew Faction Only -------------------
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Faction quests only for Yew/Justice!
            () => new FactionCollectionQuestScroll("Wood", 20, "Yew", 500),  // Collect wood
            () => new FactionCollectionQuestScroll("Leather", 15, "Yew", 450),
            () => new FactionKillQuestScroll("Brigand", 10, "Yew", 700),
            () => new FactionDeliveryQuestScroll("Justice Proclamation", "Yew", 300),
            // Add more as you see fit!
			
            () => new FactionCollectionQuestScroll("Epaulette", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("Cloak", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("Quiver", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("FeatheredHat", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("JesterHat", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("FloppyHat", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("Cap", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("WideBrimHat", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("StrawHat", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("TallStrawHat", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("WizardsHat", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("Bonnet", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("TricorneHat", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("Bandana", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("SkullCap", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("Kasa", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("ClothNinjaHood", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("FlowerGarland", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("BearMask", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("DeerMask", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("HornedTribalMask", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("TribalMask", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("OrcishKinMask", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("OrcMask", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("SavageMask", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("ChefsToque", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("Bascinet", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("CloseHelm", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("NorseHelm", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("OrcHelm", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("Helmet", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("AssassinsCowl", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("ChainHatsuburi", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("ChainCoif", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("Circlet", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("DecorativePlateKabuto", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("DragonTurtleHideHelm", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("EvilOrcHelm", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("LeatherCap", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("LeatherJingasa", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("LeatherMempo", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("LeatherNinjaHood", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("LightPlateJingasa", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("PlateBattleKabuto", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("PlateHelm", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("PlateMempo", 25, "Yew", 750),
            () => new FactionCollectionQuestScroll("RavenHelm", 25, "Yew", 750),
			
            () => new FactionKillQuestScroll("Sheep", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SilverSerpent", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SilverSteed", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SkeletalCat", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SkeletalDragon", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SkeletalDrake", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SkeletalKnight", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SkeletalLich", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SkeletalMage", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SkeletalMount", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Skeleton", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SkitteringHopper", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Skree", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Slime", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Slith", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Snake", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SnowElemental", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SnowLeopard", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SolenHelper", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SpeckledScorpion", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SpectralArmour", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Spectre", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Spellbinder", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Squirrel", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("StoneGargoyle", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("StoneHarpy", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("StoneMonster", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("StoneSlith", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("StrongMongbat", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("StygianDrake", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Succubus", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SwampDragon", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("SwampTentacle", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TanglingRoots", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TerathanAvenger", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TerathanDrone", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TerathanMatriarch", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TerathanWarrior", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TheButcher", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("ThirdDawnParrot", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TigersClawMaster", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TigersClawThief", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TimberWolf", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Titan", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Tormented Minotaur", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("ToxicElemental", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("ToxicSlith", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TrapdoorSpider", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Treefellow", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TreefellowGuardian", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Triceratops", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Triton", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Troglodyte", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Troll", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("TsukiWolf", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Turkey", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("UndeadGargoyle", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("UndeadGuardian", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("UnfrozenMummy", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Unicorn", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("ValoriteElemental", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("VampireBat", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("VeriteElemental", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Virulent", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Viscera", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("VoidManesfistation", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("VorpalBunny", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("WailingBanshee", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("Walrus", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("WandererOfTheVoid", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("WaterElemental", "5", "Yew", "500"),
            () => new FactionKillQuestScroll("WhippingVine", "5", "Yew", "500"),			

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Yew, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Yew, 350),				
			
			
        };

        // ------------------- RANDOM NAME/STAT LOGIC: YEW STYLE ----------------
        [Constructable]
        public CitizenOfYewQuestGiver()
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
            string fullName = GenerateRandomYewName();
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

        private static string GenerateRandomYewName()
        {
            string[] firstNames = new[]
            {
                // Anglo‐Saxon, rural, simple
                "Beorn", "Wulfric", "Edith", "Godwin", "Hilda", "Leofric", "Oswald", "Eadwine", "Cynric",
                "Eadmund", "Mildred", "Aethelred", "Ceolwynn", "Eadgifu", "Dunstan", "Alfred", "Cuthbert", "Eadburh", "Oswynn", "Theodric", "Saeward",
                "Aelfric", "Wynnflaed", "Aethelstan", "Leofwine", "Ceawlin", "Aelfhild", "Aethelwynn", "Eadgyth", "Waerburh", "Osgar", "Godith", "Ethelred"
            };
            string[] lastNames = new[]
            {
                // Woodland, local, Yew area
                "Greenwood", "Forester", "Longbow", "Woodman", "Oakenshield", "Rivers", "Hillman", "of the Glen", "of Empath Abbey",
                "Woodwalker", "Heathfield", "Ashgrove", "Hawthorne", "Yewman", "Oakwood", "Thicket", "Woodsward", "Heathertop", "Abbeyson",
                "of Yew", "of the Wilds", "Wildwood", "Archer", "Oakleaf", "Briar", "Woodbine", "of the Downs", "of the Wood"
            };
            string[] titles = new[]
            {
                // Civic, legal, woodland/abbey
                "the Forester", "the Archer", "the Bowyer", "the Fletcher", "the Huntsman", "the Yeoman", "the Bailiff", "the Reeve", "the Scribe",
                "the Judge", "the Magistrate", "the Lawkeeper", "the Sheriff", "of Empath Abbey", "the Abbott", "the Prior", "the Nun", "the Parson",
                "the Hermit", "the Woodcutter", "the Woodsman", "the Herbalist", "the Gamekeeper", "the Watchman", "the Constable", "the Chronicler"
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
                    item.Hue = Utility.RandomMinMax(500, 2500); // keep earthy
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1, 2001);
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
                player.SendMessage($"The Abbey is still writing new scrolls. Return in {wait.Minutes} minute(s).");
                return;
            }
            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;
            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("The scrolls are lost in the woods... Try again soon.");
                return;
            }
            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("Justice walks with you. Here is your task.");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfYewQuestGiver _npc;
            private readonly Mobile _from;
            public QuestEntry(Mobile from, CitizenOfYewQuestGiver npc)
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

        public CitizenOfYewQuestGiver(Serial serial) : base(serial) { }

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
