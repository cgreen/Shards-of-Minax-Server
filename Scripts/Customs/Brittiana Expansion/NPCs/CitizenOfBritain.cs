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
    [CorpseName("the remains of a citizen of Britain")]
    public class CitizenOfBritain : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // EQUIPMENT: Britain cityfolk—simple, working-class, no exotic items
        private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>(StringComparer.OrdinalIgnoreCase)
        {
            { "Footwear",   new SlotDef(0.98,
                () => new Shoes(),
                () => new Boots(),
                () => new Sandals())
            },
            { "Shirt",      new SlotDef(0.90,
                () => new Shirt(),
                () => new FancyShirt(),
                () => new Doublet(),
                () => new Tunic())
            },
            { "Pants",      new SlotDef(0.90,
                () => new LongPants(),
                () => new ShortPants(),
                () => new Skirt(),
                () => new Kilt())
            },
            { "Apron",      new SlotDef(0.15,
                () => new HalfApron(),
                () => new FullApron())
            },
            { "Cloak",      new SlotDef(0.10,
                () => new Cloak())
            },
            { "Hat",        new SlotDef(0.30,
                () => new Cap(),
                () => new FeatheredHat(),
                () => new Bonnet())
            }
            // NO: armor, tribal, ninja, magic, rare/heroic, etc.
        };

        // ONLY Britain/Blue Quests (you can swap in any you want, all factioned for Britain)
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            // Only Britain faction quest scrolls!
            () => new FactionCollectionQuestScroll("IronIngot", 20, "Britain", 600),
            () => new FactionDeliveryQuestScroll("Rat Nemesis", "Britain", 300),
            () => new FactionKillQuestScroll("Orc", 10, "Britain", 900),
            () => new FactionRegionKillQuestScroll("Sewers", 12, XmlMobFactions.GroupTypes.Britain, 750, typeof(BlackPearl)),
            () => new FactionTamingQuestScroll(typeof(HellCat), 2, XmlMobFactions.GroupTypes.Britain, 400, typeof(Bone)),
			
            () => new FactionCollectionQuestScroll("RadishSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SnowPeasSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SoySeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SpinachSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("StrawberrySeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SweetPotatoSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("TurnipSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("ChiliPepperSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("CucumberSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("GreenPepperSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("OrangePepperSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("RedPepperSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("TomatoSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("YellowPepperSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("CantaloupeSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("GreenSquashSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("HoneydewMelonSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("PumpkinSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SquashSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("WatermelonSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("AppleSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("BananaTreeSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("CantaloupeVineSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("CoconutTreeSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("DateTreeSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("GrapeSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("LemonSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("LimeSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("PeachSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("PearSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SquashVineSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("WatermelonVineSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("BuildersHammer", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("CheeseAgingBarrel", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("PeaceableWoodenFence", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("MarijuanaSeeds", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("TaintedSeeds", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SilverSaplingSeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SeedOfLife", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SeedOfRenewal", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("RaisedGardenDeed", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("SeedBox", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("AbyssChivesFruit", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("aggearangFruit", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("agleatainFruit", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("ameoyoteFruit", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("AngelRootFruit", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("AngelTurnipFruit", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("ArcticParsnipFruit", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("AshLycheeFruit", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("AshRootFruit", 25, "Britain", 750),
            () => new FactionCollectionQuestScroll("AutumnCherryFruit", 25, "Britain", 750),
			
            () => new FactionKillQuestScroll("MandrillShaman ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("MountainGorilla ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("OrangutanSage ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("SifakaWarrior ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("SpiderMonkey ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("AzureMoose ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("CrimsonMule ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("CursedWhiteTail ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("EclipseReindeer ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("EmberAxis ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("FrostWapiti ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("MysticFallow ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("ShadowMuntjac ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("StormSika ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("VenomousRoe ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("AriesRamBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("CancerShellBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("CapricornMountainBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("GeminiTwinBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("LeoSunBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("LibraBalanceBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("SagittariusArcherBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("ScorpioVenomBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("TaurusEarthBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("VirgoPurityBear ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("AriesHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("CancerHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("CapricornHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("GeminiHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("LeoHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("LibraHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("SagittariusHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("ScorpioHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("TaurusHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("VirgoHarpy ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("InfernoStallion ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("IronSteed ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("MetallicWindsteed ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("StoneSteed ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("TidalMare ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("VolcanicCharger ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("WoodlandCharger ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("WoodlandSpiritHorse ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("YangStallion ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("YinSteed ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("Acererak ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("AzalinRex ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("CosmicBouncer ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("EldritchHarbinger ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("EldritchHare ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("EnigmaticSkipper ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("ForgottenWarden ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("InfinitePouncer ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("NightmareLeaper ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("WhisperingPooka ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("AnthraxRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("BlackDeathRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("CholeraRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("DeathRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("FeverRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("LeprosyRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("MalariaRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("RabidRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("SmallpoxRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("TyphusRat ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("AegisConstruct ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("ArbiterDrone ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("Mimicron ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("NemesisUnit ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("OmegaSentinel ", "5", "Britain", "500"),
            () => new FactionKillQuestScroll("OverlordMkII ", "5", "Britain", "500"),			

            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Britain, 600, typeof(MaxxiaScroll)),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),			
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),				
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Britain, 350),				
			
			
            // Add as many Britain-only versions as you like
        };

        // Names & titles appropriate to Britain: (baker, cooper, scribe, etc)
        private static readonly string[] FirstNames = new[] {
            "Alys", "Benn", "Cedric", "Daria", "Edwin", "Fiona", "Gareth", "Helena", "Ivor", "Jenna",
            "Kenrick", "Lysa", "Milo", "Nora", "Owen", "Petra", "Quentin", "Rosa", "Silas", "Tilda",
            "Ulf", "Viola", "Wyn", "Yorick", "Zara"
        };
        private static readonly string[] LastNames = new[] {
            "Smith", "Cooper", "Thatcher", "Carpenter", "Mason", "Baker", "Turner", "Carter", "Tanner", "Miller",
            "Brewster", "Potter", "Taylor", "Weaver", "Chandler", "Wright", "Chamberlain", "Gardener", "Barrow", "Mercer",
            "Page", "Butler", "Steward", "Fletcher", "Cartwright", "Fisher"
        };
        private static readonly string[] Titles = new[] {
            "the Baker", "the Cooper", "the Merchant", "the Scribe", "the Citizen", "the Tailor", "the Mason", "the Tanner",
            "the Gardener", "the Miller", "the Town Crier", "the Watchman", "the Steward", "the Porter", "the Cook",
            "of Britain", "the Innkeeper", "the Alewife", "the Piper", "the Barber", "the Chandler", "the Butcher",
            "the Fishmonger", "the Wainwright"
        };

        [Constructable]
        public CitizenOfBritain()
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

            // Name, last name, title format (e.g., "Alys Mason the Scribe")
            string first = FirstNames[Utility.Random(FirstNames.Length)];
            string last = LastNames[Utility.Random(LastNames.Length)];
            string title = Titles[Utility.Random(Titles.Length)];
            Name = first + " " + last;
            Title = title;

            SetStr(Utility.RandomMinMax(50, 90));
            SetDex(Utility.RandomMinMax(50, 90));
            SetInt(Utility.RandomMinMax(50, 90));
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
                    item.Hue = Utility.RandomMinMax(1, 1200); // subdued, urban tones
                    AddItem(item);
                }
            }
            Utility.AssignRandomHair(this);
            HairHue = Utility.RandomMinMax(1101, 1177);
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
                player.SendMessage("Here, take this quest scroll! For Britain!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly CitizenOfBritain _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, CitizenOfBritain npc)
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
        public CitizenOfBritain(Serial serial) : base(serial) { }

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

        // Internal helper for slot defs
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
    }
}
