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
    [CorpseName("the remains of a New Haven citizen")]
    public class CitizenOfNewHaven : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ----------- New Haven Equipment Pool: simple, town-appropriate ------------
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
            // Shoes are almost always present
            { "Footwear",   new SlotDef(0.98,
                () => new Shoes(), 
                () => new Sandals(),
                () => new Boots()
            )},

            // Plain clothing: basic shirts, tunics, dresses
            { "Shirt",      new SlotDef(0.90,
                () => new Shirt(),
                () => new FancyShirt(),
                () => new Tunic(),
                () => new Doublet(),
                () => new Surcoat()
            )},

            // Pants/skirts
            { "Legs",       new SlotDef(0.90,
                () => new LongPants(),
                () => new ShortPants(),
                () => new Skirt(),
                () => new Kilt()
            )},

            // Robes and aprons are uncommon
            { "Robe",       new SlotDef(0.10,
                () => new Robe(),
                () => new PlainDress(),
                () => new FancyDress()
            )},
            { "Belt",       new SlotDef(0.10,
                () => new HalfApron(),
                () => new FullApron()
            )},

            // Hats and headgear (scholarly or simple)
            { "Head",       new SlotDef(0.40,
                () => new FloppyHat(),
                () => new Cap(),
                () => new Bonnet(),
                () => new StrawHat(),
                () => new WideBrimHat(),
                () => new WizardsHat(),
                () => new Bandana(),
                () => new SkullCap()
            )},

            // Cloak/cape is rare
            { "Back",       new SlotDef(0.05,
                () => new Cloak()
            )},

            // Jewelry is rare, but possible
            { "Neck",       new SlotDef(0.08, () => new Necklace()) },
            { "Earring",    new SlotDef(0.05, () => new GoldEarrings()) },
            { "Bracelet",   new SlotDef(0.05, () => new GoldBracelet()) },
            { "Ring",       new SlotDef(0.05, () => new GoldRing()) },

            // A *few* New Haven citizens have tools or musical instruments
            { "RightHand",  new SlotDef(0.20,
                () => new SkinningKnife(),
                () => new ScribesPen(),
                () => new RollingPin(),
                () => new Drums(),
                () => new Lute(),
                () => new Tambourine(),
                () => new ShepherdsCrook(),
                () => new Pitchfork()
            )},

            // Only the odd shield/torch for workers/guards
            { "LeftHand",   new SlotDef(0.05,
                () => new Torch(),
                () => new Lantern()
            )},
        };

        // ---- Only New Haven faction quests, all Faction*Scrolls, or force set to New Haven ----
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
			
            () => new FactionCollectionQuestScroll("MiniOrangeSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("LoveZucchiniFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("Nyxiolate", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("MiniPearSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("MutantLemonFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("LillypillyFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("SwampNectarineFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("ClockParts", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("Solvexium", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("ChargedAcoustesium", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("HairyTomatoFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("RefractivePotamite", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("Etherothal", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("strondaFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("kraccaleryFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("RiceSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("FieldCornSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("MandrakeSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("jeorraFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("ziongerFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("Gravitoxane", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("GarlicSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("TropicalCherryFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("RainLaurelFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("RedMushroomSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("CottonSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("Zephyrenium", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("MiniMangoSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("RedRoseSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("striachiniFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("DenaturedMorphonite", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("Xenocrylate", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("intineFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("Auroracene", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("MiniKiwiSeed", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("PeaceAmaranthFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("FluxxFruit", 25, "NewHaven", 750),
            () => new FactionCollectionQuestScroll("Turbesium", 25, "NewHaven", 750),			

            () => new FactionKillQuestScroll("DecayingBalron", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DecayingLizard", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DecayingWalrus", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("EerieDoppleganger", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("FungalBeast", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("IcyFrostTroll", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PestilentBoneMagi", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PestilentHind", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PlagueImp", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PlagueRider", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PutridBoneGargoyle", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PutridBoura", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PutridGorefiend", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PutridMinotaur", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PutridRidgeback", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PutridSolenQueen", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PutridTentacle", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PutridWyvern", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("ReaperOfRot", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("RottingKappa", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("RottingSwine", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("RuinedOverseer", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("TaintedChaosDragoon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("ToxicFireRabbit", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("ToxicGargoyle", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("VenomousOni", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("VileAcidPopper", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("BlackDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("BlondeDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("BlueDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("CopperDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DraconianCrab", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DraconianDreadspinner", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DraconianParrot", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DraconicMongbat", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DraconicTurkey", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DragonboundOverseer", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakeWarrior", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakkonHeir", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakkonHeirJr", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakonBeetle", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakonBoar", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakonGoat", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakonicDevourer", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakonsGargoyle", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakonsOstard", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DrakonsTiger", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("DreadBullFrog", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("EmeraldDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("GoldDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("GreenDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("InfernoAnt", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("LuckDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("OneEyedServant", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PlutoniumDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("PrismDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("RedDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("RubyDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("SapphireDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("SilverDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("WhiteDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("YellowDragon", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("AbyssalHorse", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("BlackWolf", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("BlightedBeastLord", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("BloodbaneFox", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("CorpseOfDoom", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("CultBrigand", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("CultChicken", "5", "NewHaven", "500"),
            () => new FactionKillQuestScroll("HellScorpion", "5", "NewHaven", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.NewHaven, 350),				
			

        };

        // ------------------- Appearance, stats, New Haven names/titles -------------
        [Constructable]
        public CitizenOfNewHaven()
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
                Name  = parts[0] + " " + parts[1];
                Title = parts.Length > 2 ? parts[2] : "";
            }
            else
            {
                Name = fullName;
                Title = "";
            }
            SetStr(Utility.RandomMinMax(40, 85));
            SetDex(Utility.RandomMinMax(40, 90));
            SetInt(Utility.RandomMinMax(40, 100));
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

        private static string GenerateRandomName()
        {
            string[] firstNames = new[]
            {
                "Alice", "Edgar", "Henry", "Judith", "Leo", "Mara", "Norman", "Rose", "Simon", "Thera",
                "Carla", "Felix", "Lilian", "Oscar", "Rufus", "Helen", "Jasper", "Paula", "Victor", "Wendy",
                "Bran", "Cora", "David", "Eva", "Gwen", "Hugo", "Ida", "Jon", "Karen", "Louis",
                "Marian", "Nell", "Oliver", "Penny", "Quentin", "Sally", "Toby", "Violet", "Walter", "Yvonne",
                "Zack", "Alma", "Ben", "Claire", "Derek", "Elsa", "Frank", "Grace", "Hazel", "Ivan",
                "Jill", "Keith", "Lara", "Molly", "Nina", "Owen", "Pam", "Quincy", "Rosa", "Sam"
            };
            string[] lastNames = new[]
            {
                "Fletcher", "Smith", "Turner", "Baker", "Carver", "Taylor", "Scribe", "Grove", "Wright", "Stone",
                "Rivers", "Mason", "Potter", "Walker", "Ward", "Dawson", "Goodwin", "Stewart", "Cook", "Miller",
                "Page", "Shepherd", "Sullivan", "Webb", "Hunter", "Harper", "Gardner", "Weaver", "Cooper", "Clark",
                "Fisher", "Dean", "Merchant", "Wilkins", "Chandler", "Piper", "Thatcher", "Bard", "Minstrel", "Poet"
            };
            string[] titles = new[]
            {
                "the Shopkeeper", "the Farmer", "the Weaver", "the Baker", "the Butcher", "the Scribe", "the Apprentice",
                "the Bard", "the Fisher", "the Guard", "the Cook", "the Student", "the Laborer", "the Gardener",
                "the Librarian", "the Mason", "the Blacksmith", "the Carpenter", "the Jeweler", "the Alchemist",
                "the Musician", "the Tailor", "the Merchant", "the Cobbler", "the Stablehand", "the Novice",
                "the Citizen", "the Vendor", "the Entertainer", "the Caretaker", "the Storyteller", "the Miller"
            };
            string first  = firstNames[Utility.Random(firstNames.Length)];
            string last   = lastNames[Utility.Random(lastNames.Length)];
            string title  = titles[Utility.Random(titles.Length)];
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
                    item.Hue = Utility.RandomMinMax(1900, 2290); // Muted, realistic New Haven hues
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1101, 1190);
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
                player.SendMessage($"Please give me a little more time. I’ll have more tasks in {wait.Minutes} minute(s).");
                return;
            }
            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;
            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("Sorry, I can’t offer a quest right now.");
                return;
            }

            player.AddToBackpack(scroll);
            player.SendMessage("Here, please help New Haven with this task!");
            _nextQuestUtc = DateTime.UtcNow + Cooldown;
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfNewHaven _npc;
            private readonly Mobile _from;
            public QuestEntry(Mobile from, CitizenOfNewHaven npc)
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
        public CitizenOfNewHaven(Serial serial) : base(serial) { }
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
