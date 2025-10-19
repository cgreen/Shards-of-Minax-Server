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
    [CorpseName("the remains of a Nujel'm reveler")]
    public class CitizenOfNujelm : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // Nujel'm Themed Equipment Pool
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
                () => new JesterShoes(),
                () => new Sandals()
            )},

            { "Torso", new SlotDef(1.0,
                () => new FancyShirt(),
                () => new Doublet(),
                () => new JesterSuit(),
                () => new BodySash(),
                () => new PlainDress(),
                () => new FancyDress()
            )},

            { "Legs", new SlotDef(0.90,
                () => new LongPants(),
                () => new ShortPants(),
                () => new Skirt(),
                () => new Kilt()
            )},

            { "Head", new SlotDef(0.65,
                () => new JesterHat(),
                () => new FloppyHat(),
                () => new FeatheredHat(),
                () => new Circlet(),
                () => new Cap(),
                () => new Bandana()
            )},

            { "Back", new SlotDef(0.30,
                () => new Cloak(),
                () => new BodySash()
            )},

            // Instruments or "props"
            { "Prop", new SlotDef(0.40,
                () => new Lute(),
                () => new Harp(),
                () => new Tambourine(),
                () => new Drums(),
                () => new PlayingCards()
            )},

            // Very rare simple jewelry
            { "Jewelry", new SlotDef(0.10,
                () => new GoldEarrings(),
                () => new GoldBracelet(),
                () => new GoldRing()
            )}
        };

        // Nujel'm Faction quest scrolls only
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Adjust these to use your faction system or pass "Nujel'm" as needed
            () => new FactionDeliveryQuestScroll("Nujel'm"),
            () => new FactionCollectionQuestScroll("Spices", 15, "Nujelm", 400),
            () => new FactionKillQuestScroll("Troublemaker", 5, "Nujelm", 900),
			
            () => new FactionCollectionQuestScroll("RodOfOrcControl", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("YellowRoseSeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("HaySeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("jigreapawFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("SmellyCarrotFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("BlackRoseSeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("PoppySeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("ocanateFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("Nebulifluxate", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("GardeningContract", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("CelerySeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("MiniCocoaSeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("Negite", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("GoldenRocketFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("SugarcaneSeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("FreshGinger", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("ippiocressFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("ElephantBreadnutFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("Energite", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("PineappleSeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("Gears", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("eawanFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("hiorolaFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("TanMushroomSeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("OceanMuscadineFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("TigerBeanFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("EmberLettuceFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("fucrucotFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("puchiniFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("Pitcher", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("BananaSeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("BlueberrySeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("HighdensityElectron", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("PositiveEvenium", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("MysteryGuavaFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("DateSeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("MoonPumpkinFruit", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("PotatoSeed", 25, "Nujelm", 750),
            () => new FactionCollectionQuestScroll("vrecequilaFruit", 25, "Nujelm", 750),			

            () => new FactionKillQuestScroll("InfernalBanshee", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("InfernalMinotaur", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("InfernalOrc", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("InfernalSavage", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("InfernoDevil", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("InfernoElemental", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("LavaDolphin", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("LivingLava", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ScaldingElemental", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ScaldingSnake", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ScaldingWraith", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ScorchedLich", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ScorchingLlama", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ScorchingOgre", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ScorchingWebspinner", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("SearingImp", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ArcaneAntlion", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ArcaneAssassin", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ArcaneSlug", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ArcaneSwine", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("MiningSkeleton", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("Orebinder", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("OreBird", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("OreboundElemental", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("OreBrigand", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("Oremire", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("OreMule", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("OreScaledDragon", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("RockyLlama", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("SilverMage", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("SulfuricSnake", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("TunnelMinotaur", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("TunnelRat", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("YomotsuMinelord", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("AncientDrakon", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("AncientHiryu", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("AncientYamandon", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("BoneSteed", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("CarvedBird", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("CragFiddler", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("CragSerpent", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("CragSlug", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("GraniteEye", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("GraniteGuardian", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("GraniteKemo", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("GraniteWarrior", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("IronboundElemental", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("MountainBrigand", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("MountainElite", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("MountainMinotaur", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("MountainRonin", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("MountainSteed", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("MountainWanderer", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("NexusWeaver", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ObsidianDragon", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ObsidianSerpent", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ObsidianWorm", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("PlutoniumElemental", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("RockboundSpectral", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("RockFiend", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("RockGuardian", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("RockOrc", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("RockridgeSavage", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("RuneguardPowerGolem", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("RunestoneGolem", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("ShardMaster", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("StoneboundRoots", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("StonefangCougar", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("StoneGorilla", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("StoneRipper", "5", "Nujelm", "500"),
            () => new FactionKillQuestScroll("StonewebWarlock", "5", "Nujelm", "500"),

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Nujelm, 350),				
			
            // Add more Nujel'm-specific themed quests as you like!
        };

        // Nujel'm themed names/titles
        private static readonly string[] FirstNames = new[]
        {
            "Azra", "Farid", "Layla", "Samir", "Yasmin", "Amir", "Zara", "Dalia", "Jalil", "Nadir",
            "Sahir", "Soraya", "Rafi", "Selim", "Tariq", "Iman", "Lina", "Zahir", "Ranya", "Kasim"
        };
        private static readonly string[] LastNames = new[]
        {
            "the Bard", "the Jester", "the Minstrel", "the Dancer", "the Storyteller", "the Poet",
            "of the Silks", "of the Lanterns", "of the Gardens", "of the Lotus", "of the Jewel Market",
            "of the Spices", "the Songbird", "the Laughmaker", "the Lyricist", "the Masked"
        };
        private static readonly string[] Titles = new[]
        {
            "of Nujel’m", "the Entertainer", "the Lyricist", "of the Taverns", "of the Carnival",
            "the Playwright", "the Jongleur", "the Troubadour", "of the Golden Streets", "the Celebrant"
        };

        [Constructable]
        public CitizenOfNujelm() : base(AIType.AI_Vendor, FightMode.None, 10, 1, 0.2, 0.4)
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
                Name = parts[0] + " " + parts[1]; // e.g., "Layla the Bard"
                Title = parts.Length > 2 ? parts[2] : "";
            }
            else
            {
                Name = fullName;
                Title = "";
            }
            SetStr(Utility.RandomMinMax(50, 70));
            SetDex(Utility.RandomMinMax(60, 90));
            SetInt(Utility.RandomMinMax(60, 100));
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

        private static string GenerateRandomName()
        {
            string first = FirstNames[Utility.Random(FirstNames.Length)];
            string last = LastNames[Utility.Random(LastNames.Length)];
            string title = Titles[Utility.Random(Titles.Length)];
            // Randomly do: First + Last, or First + Last + Title
            if (Utility.RandomBool())
                return $"{first} {last}";
            else
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
                    item.Hue = Utility.RandomMinMax(100, 1500); // Brighter hues for Nujel'm!
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
                player.SendMessage($"I need to compose another verse. Return in {wait.Minutes} minute(s).");
                return;
            }
            var factory = _questFactories[Utility.Random(_questFactories.Count)];
            Item scroll = null;
            try { scroll = factory(); }
            catch (Exception e)
            {
                Console.WriteLine("Quest factory failed: " + e);
                player.SendMessage("Alas, my muse fails me. Try again later.");
                return;
            }
            if (scroll != null)
            {
                player.AddToBackpack(scroll);
                player.SendMessage("Here, take this Nujel'm quest scroll!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfNujelm _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfNujelm npc)
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
        public CitizenOfNujelm(Serial serial) : base(serial) { }

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
