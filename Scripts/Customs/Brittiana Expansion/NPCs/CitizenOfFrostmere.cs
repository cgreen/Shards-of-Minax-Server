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
    [CorpseName("the remains of a Frostmere villager")]
    public class CitizenOfFrostmere : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ------------------- Frostmere Equipment Pool ------------------------
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

        // Frostmere has a smaller, icier, simpler set. No bright colors, much fur, wool, leather, some battered armor for ex-warriors.
        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            // Footwear: Always boots or fur boots
            { "Footwear",   new SlotDef(0.98,
                () => new FurBoots(),
                () => new Boots(),
                () => new ThighBoots()
            )},

            // Cloaks/Outerwear: Fur cloaks, sometimes heavy cloaks
            { "Back",       new SlotDef(0.30,
                () => new FurCape(),
                () => new Cloak()
            )},

            // Headgear: Fur hats, hoods, rare battered helms for warriors, scholar's cap
            { "Head",       new SlotDef(0.60,
                () => new BearMask(),
                () => new BearMask(),
                () => new Bascinet(),
                () => new Cap(),
                () => new Circlet(),
                () => new Bascinet() // battered old helm
            )},

            // Shirt/Chest non-armor: Wool tunics, heavy shirts, scholar's robe (rare)
            { "Shirt",      new SlotDef(0.85,
                () => new Tunic(),
                () => new FancyShirt(),
                () => new Shirt(),
                () => new Robe(), // scholar/ritual
                () => new BodySash()
            )},

            // Chest armor: Fur or leather only, battered chain for ex-warrior
            { "Chest",      new SlotDef(0.20,
                () => new LeatherChest(),
                () => new FurSarong(),
                () => new ChainChest() // rare, exile-warrior
            )},

            // Legs: Woolen/fur pants, skirt for women
            { "Legs",       new SlotDef(0.70,
                () => new LongPants(),
                () => new LongPants(),
                () => new Skirt()
            )},

            // Arms: Fur or leather bracers, rare battered chain arms
            { "Arms",       new SlotDef(0.25,
                () => new LeatherArms(),
                () => new LeatherArms(),
                () => new LeatherArms()
            )},

            // Hands: Fur or leather gloves/mitts
            { "Hands",      new SlotDef(0.45,
                () => new LeatherGloves(),
                () => new LeatherGloves()
            )},

            // Belt: Fur sash/apron
            { "Belt",       new SlotDef(0.30,
                () => new FullApron(),
                () => new BodySash()
            )},

            // Neck: Simple gorget or scarf
            { "Neck",       new SlotDef(0.15,
                () => new LeatherGorget(),
                () => new TigerPeltCollar()
            )},

            // Right Hand: Tools, walking sticks, or simple weapon; scholars get book/wand
            { "RightHand",  new SlotDef(0.70,
                () => new QuarterStaff(),
                () => new Dagger(),
                () => new SkinningKnife(),
                () => new ShepherdsCrook(),
                () => new Pickaxe(),
                () => new Spellbook(),
                () => new MagicWand()
            )},

            // Left Hand: Torch, lantern, or rare wooden shield
            { "LeftHand",   new SlotDef(0.20,
                () => new Lantern(),
                () => new Torch(),
                () => new WoodenShield()
            )},
        };

        // ------------- Faction Quests Only for Frostmere --------------
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // These should be all Frostmere-related/faction quest scrolls.
            // Replace/add your own custom quest scrolls as needed:
            () => new FactionCollectionQuestScroll("Ice Shard", 10, "Frostmere", 900),
            () => new FactionDeliveryQuestScroll("Frozen Relic", "Frostmere", 500),
            () => new FactionKillQuestScroll("Snow Elemental", 5, "Frostmere", 1200),
			
            () => new FactionCollectionQuestScroll("AutumnPomegranateFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("BitterDurianFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("BittersweetChivesFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("BlackChoyFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("blattiovesFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("blearelFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("BlumbFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("bosheaShootFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("brafulalFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("brongerFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("BushCerimanFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("BushSpinachFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("CandyMorindaFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("CaveAsparagusFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("CavePersimmonFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("CavernMangosteenFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("chigionutFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("chummionachFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("ciarryFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("CinderGingerFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("CliffNectarineFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("crennealeryFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("criarianFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("darantFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DaydreamPommeracFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DesertPlumFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DesertRowanFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DessertBroccoliFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DessertTomatoFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DewKiwiFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DewPawpawFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("dimquatFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("diowanFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DragoLimeFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DrakeLentilFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("DrakeMangoFruit", 25, "Frostmere", 750),
            () => new FactionCollectionQuestScroll("eacketFruit", 25, "Frostmere", 750),			

            () => new FactionKillQuestScroll("ChillfireElemental", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("ChillSatyr", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("ColdscaleLizardman", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("CrystalChangeling", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostAxeOrc", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostbiteHound", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostbittenSteed", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostboundBandage", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostboundKnight", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostboundSovereign", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostbrandWarrior", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostedSeductress", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostedWidowSpider", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrostwovenMage", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("FrozenBonefiend", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("GlacialAbomination", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("GlacialConstruct", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("GlacialEagle", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("GlacialExecutioner", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("GlacialOgre", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("GlacialOoze", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("GlacialTimberwolf", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("GlacialWraith", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IceboundLarva", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IceclawPredator", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IcelightWisp", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IceWraithMatriarch", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IcyAlchemistGoblin", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IcyBunny", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IcyDominionQueen", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IcyExecutioner", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IcyLion", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IcyMinion", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("IcySolenServant", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("MoonfrostWolf", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("SerpentOfTheGlaciers", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("ShatteredCorpse", "5", "Frostmere", "500"),
            () => new FactionKillQuestScroll("Shiverlash", "5", "Frostmere", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Frostmere, 350),				

			
            // Add more as your custom scrolls allow!
        };

        // --------------- Random Frostmere Name Generation --------------
        [Constructable]
        public CitizenOfFrostmere()
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
            string fullName = GenerateFrostmereName();
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
            SetInt(Utility.RandomMinMax(60, 110)); // smarter than avg
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

        private static string GenerateFrostmereName()
        {
            // Frostmere first names: Nordic/Celtic plus exile/scholar themes
            string[] firstNames = new[]
            {
                "Sigrid", "Rurik", "Leif", "Yrsa", "Eira", "Bjorn", "Astrid", "Dagny", "Viggo", "Solveig",
                "Torin", "Liv", "Jorund", "Freya", "Soren", "Anja", "Egil", "Halvard", "Ingrid", "Alaric",
                "Sigurd", "Magnus", "Kelda", "Lars", "Elin", "Stig", "Hilda", "Erik", "Svala", "Thora",
                "Finn", "Bran", "Galen", "Cerys", "Cian", "Ewan", "Ailis", "Isolde", "Nessa", "Toril",
                "Mira", "Elric", "Njal", "Ragna", "Tove", "Morten", "Vilda", "Greta", "Ivar", "Oskar",
                "Anwen", "Siobhan", "Sorcha", "Rhys", "Dara", "Nerys"
            };

            // Frostmere last names: Frost/ice/cold/nature, or scholarly/arcane
            string[] lastNames = new[]
            {
                "Iceborn", "Frostvein", "Snowcloak", "Glacier", "Winterson", "Northwind", "Rimeshaper", "Coldstone", "Icebreaker", "Whiteshroud",
                "Stormrune", "Runeweaver", "Ironmark", "Stonegrace", "Ashenhand", "Lorebinder", "Spellward", "Dawnwatch", "Wolfkin", "Shieldsson",
                "Mistwalker", "Wintergrave", "Shadowvale", "Emberfell", "Drakeblood", "Wolfbane", "Stormhand", "Stormwatch", "Ironfrost"
            };

            // Titles: Scholar, exile, survivor, stoic crafts
            string[] titles = new[]
            {
                "the Survivor", "the Exile", "the Scholar", "the Lorekeeper", "the Outcast", "the Stoic", "Ice Fisher", "Keeper of the Obelisk",
                "the Wolf Tamer", "of the Icebound", "the Forager", "the Scout", "the Silent", "Keeper of Secrets", "Seeker of Lore", "Ice Sage",
                "the Stalwart", "the Cold", "of Frostmere", "Frostborn", "the Scribe", "Shield of Frostmere", "of the Glaciers", "the Wanderer"
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
                    item.Hue = 1150 + Utility.Random(7); // Icy/cold hues (use your frost color range)
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = 1150 + Utility.Random(7);
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
                player.SendMessage("Here, take this quest scroll! [Frostmere Faction]");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfFrostmere _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfFrostmere npc)
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

        // Persistence
        public CitizenOfFrostmere(Serial serial) : base(serial) { }

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
