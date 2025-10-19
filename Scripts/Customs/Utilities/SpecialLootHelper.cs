using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Plants;
using Server.Items.Crops;

namespace Server.Custom
{
    public class SpecialLootHelper
    {
        private static readonly List<Func<Item>> LootTable = new List<Func<Item>>
        {
            () => new UnidentifiedArmor(),
            () => new UnidentifiedShield(),
            () => new UnidentifiedJewelry(),
            () => new UnidentifiedClothing(),
            () => new UnidentifiedWeapon(),
            () => new UnidentifiedPotion(),
            () => new UnidentifiedCrystal(),
            () => new UnidentifiedCuriosity(),
            () => new UnidentifiedMagicMap(),
            () => new UnidentifiedOrb(),
            () => new UnidentifiedDocument(),
            () => new UnidentifiedTreasure(),		
            () => new UnidentifiedArmor(),
            () => new UnidentifiedShield(),
            () => new UnidentifiedJewelry(),
            () => new UnidentifiedClothing(),
            () => new UnidentifiedWeapon(),
            () => new UnidentifiedPotion(),
            () => new UnidentifiedCrystal(),
            () => new UnidentifiedCuriosity(),
            () => new UnidentifiedMagicMap(),
            () => new UnidentifiedOrb(),
            () => new UnidentifiedDocument(),
            () => new UnidentifiedTreasure(),
            () => new Clock(),
            () => new Nails(),
            () => new ClockParts(),
            () => new AxleGears(),
            () => new Gears(),
            () => new Hinge(),
            () => new Sextant(),
            () => new SextantParts(),
            () => new Axle(),
            () => new Springs(),
            () => new KeyRing(),
            () => new Lockpick(),
            () => new TinkersTools(),
            () => new Board(),
            () => new SewingKit(),
            () => new DrawKnife(),
            () => new Froe(),
            () => new Scorp(),
            () => new Inshave(),
            () => new ButcherKnife(),
            () => new Scissors(),
            () => new Tongs(),
            () => new DovetailSaw(),
            () => new Saw(),
            () => new Hammer(),
            () => new SmithHammer(),
            () => new Shovel(),
            () => new MouldingPlane(),
            () => new JointingPlane(),
            () => new SmoothingPlane(),
            () => new Pickaxe(),
            () => new Drums(),
            () => new Tambourine(),
            () => new LapHarp(),
            () => new Lute(),
            () => new CartographersScope(),
            () => new SnoopersMasterScope(),
            () => new BlankScroll(),
            () => new Bandage(),
            () => new RecallRune(),
            () => new Arrow(),
            () => new Bolt(),
            () => new Candle(),
            () => new Torch(),
            () => new Lantern(),
            () => new OilFlask(),
            () => new FloppyHat(),
            () => new Bedroll(),
            () => new CampersBackpack(),
            () => new GraveAxe(),
            () => new TileExcavatorShovel(),
            () => new Kindling(),
            () => new Chessboard(),
            () => new CheckerBoard(),
            () => new Backgammon(),			
            () => new UnidentifiedArmor(),
            () => new UnidentifiedShield(),
            () => new UnidentifiedJewelry(),
            () => new UnidentifiedClothing(),
            () => new UnidentifiedWeapon(),
            () => new UnidentifiedPotion(),
            () => new UnidentifiedCrystal(),
            () => new UnidentifiedCuriosity(),
            () => new UnidentifiedMagicMap(),
            () => new UnidentifiedOrb(),
            () => new UnidentifiedDocument(),
            () => new UnidentifiedTreasure(),		
            () => new UnidentifiedArmor(),
            () => new UnidentifiedShield(),
            () => new UnidentifiedJewelry(),
            () => new UnidentifiedClothing(),
            () => new UnidentifiedWeapon(),
            () => new UnidentifiedPotion(),
            () => new UnidentifiedCrystal(),
            () => new UnidentifiedCuriosity(),
            () => new UnidentifiedMagicMap(),
            () => new UnidentifiedOrb(),
            () => new UnidentifiedDocument(),
            () => new UnidentifiedTreasure(),			
            () => new IronIngot(),
            () => new DullCopperIngot(),
            () => new ShadowIronIngot(),
            () => new CopperIngot(),
            () => new BronzeIngot(),
            () => new GoldIngot(),
            () => new AgapiteIngot(),
            () => new VeriteIngot(),
            () => new ValoriteIngot(),
            () => new RefreshPotion(),
            () => new AgilityPotion(),
            () => new NightSightPotion(),
            () => new LesserHealPotion(),
            () => new StrengthPotion(),
            () => new LesserPoisonPotion(),
            () => new LesserCurePotion(),
            () => new LesserExplosionPotion(),
            () => new MortarPestle(),
            () => new BlackPearl(),
            () => new Bloodmoss(),
            () => new Garlic(),
            () => new Ginseng(),
            () => new MandrakeRoot(),
            () => new Nightshade(),
            () => new SpidersSilk(),
            () => new SulfurousAsh(),
            () => new Bottle(),
            () => new Bacon(),
            () => new Ham(),
            () => new Sausage(),
            () => new RawChickenLeg(),
            () => new RawBird(),
            () => new RawLambLeg(),
            () => new RawRibs(),
            () => new Board(),
            () => new BreadLoaf(),
            () => new ApplePie(),
            () => new Cake(),
            () => new Muffins(),
            () => new CheeseWheel(),
            () => new CookedBird(),
            () => new LambLeg(),
            () => new ChickenLeg(),
            () => new SackFlour(),
            () => new JarHoney(),
            () => new Cabbage(),
            () => new Cantaloupe(),
            () => new Carrot(),
            () => new HoneydewMelon(),
            () => new Squash(),
            () => new Lettuce(),
            () => new Onion(),
            () => new Pumpkin(),
            () => new GreenGourd(),
            () => new YellowGourd(),
            () => new Turnip(),
            () => new Watermelon(),
            () => new EarOfCorn(),
            () => new Eggs(),
            () => new Peach(),
            () => new Pear(),
            () => new Lemon(),
            () => new Lime(),
            () => new Grapes(),
            () => new Apple(),
            () => new SheafOfHay(),
            () => new RawFishSteak(),
            () => new SmallFish(),
            () => new Fish(),
            () => new Hides(),
            () => new GoldRing(),
            () => new Necklace(),
            () => new GoldNecklace(),
            () => new GoldBeadNecklace(),
            () => new Beads(),
            () => new GoldBracelet(),
            () => new GoldEarrings(),
            () => new StarSapphire(),
            () => new Emerald(),
            () => new Sapphire(),
            () => new Ruby(),
            () => new Citrine(),
            () => new Amethyst(),
            () => new Tourmaline(),
            () => new Amber(),
            () => new Diamond(),
            () => new BatWing(),
            () => new DaemonBlood(),
            () => new PigIron(),
            () => new NoxCrystal(),
            () => new GraveDust(),
            () => new BoltOfCloth(),
            () => new Cloth(),
            () => new UncutCloth(),
            () => new Cotton(),
            () => new Wool(),
            () => new Flax(),
            () => new SpoolOfThread(),
            () => new OakLog(),
            () => new AshLog(),
            () => new YewLog(),
            () => new BloodwoodLog(),
            () => new ElixirOfRebirth(),
            () => new MedusaBlood(),
            () => new BarrabHemolymphConcentrate(),
            () => new PlantClippings(),
            () => new MyrmidexEggsac(),
            () => new InvisibilityPotion(),
            () => new JukariBurnPoiltice(),
            () => new LavaBerry(),
            () => new Vanilla(),
            () => new BlueDiamond(),
            () => new TigerPelt(),
            () => new PerfectBanana(),
            () => new YellowScales(),
            () => new RiverMoss(),
            () => new UraliTranceTonic(),
            () => new PoisonPotion(),
            () => new GreaterPoisonPotion(),
            () => new DeadlyPoisonPotion(),
            () => new ParasiticPotion(),
            () => new ParasiticPlant(),
            () => new DarkglowPotion(),
            () => new LuminescentFungi(),
            () => new ScouringToxin(),
            () => new ToxicVenomSac(),
            () => new ExplosionPotion(),
            () => new GreaterExplosionPotion(),
            () => new TacticalBomb(),
            () => new StrategicBomb(),
            () => new MegaBombPotion(),
            () => new MinorPoisonBomb(),
            () => new PoisonBomb(),
            () => new UltraPoisonBomb(),
            () => new MegaHealthBomb(),
            () => new ConflagrationPotion(),
            () => new GreaterConflagrationPotion(),
            () => new ConfusionBlastPotion(),
            () => new GreaterConfusionBlastPotion(),
            () => new BlackPowder(),
            () => new Saltpeter(),
            () => new Charcoal(),
            () => new Matchcord(),
            () => new Potash(),
            () => new SmokeBomb(),
            () => new HoveringWisp(),
            () => new NaturalDye(),
            () => new ColorFixative(),
            () => new NexusCore(),
            () => new DarkSapphire(),
            () => new CrushedGlass(),
            () => new CrystalGranules(),
            () => new CrystalDust(),
            () => new SoftenedReeds(),
            () => new VialOfVitriol(),
            () => new DryReeds(),
            () => new CrystallineFragments(),
            () => new ShimmeringCrystals(),
            () => new SilverSerpentVenom(),
            () => new BottleIchor(),
            () => new GoldDust(),
            () => new Boots(),
            () => new Sandals(),
            () => new Shoes(),
            () => new NinjaTabi(),
            () => new FurBoots(),
            () => new ThighBoots(),
            () => new ElvenBoots(),
            () => new SamuraiTabi(),
            () => new Waraji(),
            () => new JesterShoes(),
            () => new Robe(),
            () => new FancyDress(),
            () => new GildedDress(),
            () => new DeathRobe(),
            () => new MonkRobe(),
            () => new Kamishimo(),
            () => new HakamaShita(),
            () => new MaleKimono(),
            () => new FemaleKimono(),
            () => new MaleElvenRobe(),
            () => new FemaleElvenRobe(),
            () => new FloweredDress(),
            () => new EveningGown(),
            () => new PlainDress(),
            () => new HoodedShroudOfShadows(),
            () => new Epaulette(),
            () => new Cloak(),
            () => new Quiver(),
            () => new FeatheredHat(),
            () => new JesterHat(),
            () => new FloppyHat(),
            () => new Cap(),
            () => new WideBrimHat(),
            () => new StrawHat(),
            () => new TallStrawHat(),
            () => new WizardsHat(),
            () => new Bonnet(),
            () => new TricorneHat(),
            () => new Bandana(),
            () => new SkullCap(),
            () => new Kasa(),
            () => new ClothNinjaHood(),
            () => new FlowerGarland(),
            () => new BearMask(),
            () => new DeerMask(),
            () => new HornedTribalMask(),
            () => new TribalMask(),
            () => new OrcishKinMask(),
            () => new OrcMask(),
            () => new SavageMask(),
            () => new ChefsToque(),
            () => new Bascinet(),
            () => new CloseHelm(),
            () => new NorseHelm(),
            () => new OrcHelm(),
            () => new Helmet(),
            () => new AssassinsCowl(),
            () => new ChainHatsuburi(),
            () => new ChainCoif(),
            () => new Circlet(),
            () => new DecorativePlateKabuto(),
            () => new DragonTurtleHideHelm(),
            () => new EvilOrcHelm(),
            () => new LeatherCap(),
            () => new LeatherJingasa(),
            () => new LeatherMempo(),
            () => new LeatherNinjaHood(),
            () => new LightPlateJingasa(),
            () => new PlateBattleKabuto(),
            () => new PlateHelm(),
            () => new PlateMempo(),
            () => new RavenHelm(),
            () => new SmallPlateJingasa(),
            () => new StandardPlateKabuto(),
            () => new StuddedMempo(),
            () => new TigerPeltHelm(),
            () => new VultureHelm(),
            () => new PlateHatsuburi(),
            () => new BoneHelm(),
            () => new DragonHelm(),
            () => new HeavyPlateJingasa(),
            () => new WingedHelm(),
            () => new FancyShirt(),
            () => new Tunic(),
            () => new BodySash(),
            () => new Shirt(),
            () => new ElvenShirt(),
            () => new FormalShirt(),
            () => new ClothNinjaJacket(),
            () => new Doublet(),
            () => new Surcoat(),
            () => new JinBaori(),
            () => new JesterSuit(),
            () => new PlateChest(),
            () => new RingmailChest(),
            () => new ChainChest(),
            () => new LeatherChest(),
            () => new FemaleLeatherChest(),
            () => new FemalePlateChest(),
            () => new StuddedChest(),
            () => new BoneChest(),
            () => new DragonChest(),
            () => new DragonTurtleHideChest(),
            () => new FemaleLeafChest(),
            () => new FemaleStuddedChest(),
            () => new HideFemaleChest(),
            () => new LeafChest(),
            () => new LeatherNinjaJacket(),
            () => new TigerPeltChest(),
            () => new WoodlandChest(),
            () => new HideChest(),
            () => new LeatherDo(),
            () => new PlateDo(),
            () => new StuddedDo(),
            () => new DragonTurtleHideBustier(),
            () => new TigerPeltBustier(),
            () => new LongPants(),
            () => new ShortPants(),
            () => new LeatherShorts(),
            () => new ElvenPants(),
            () => new HidePants(),
            () => new LeatherNinjaPants(),
            () => new TattsukeHakama(),
            () => new PlateLegs(),
            () => new LeatherLegs(),
            () => new ChainLegs(),
            () => new StuddedLegs(),
            () => new DragonLegs(),
            () => new DragonTurtleHideLegs(),
            () => new LeafLegs(),
            () => new RingmailLegs(),
            () => new LeafTonlet(),
            () => new TigerPeltLegs(),
            () => new TigerPeltShorts(),
            () => new LeatherHaidate(),
            () => new PlateHaidate(),
            () => new LeatherSkirt(),
            () => new LeatherSuneate(),
            () => new StuddedHaidate(),
            () => new PlateSuneate(),
            () => new StuddedSuneate(),
            () => new WoodlandLegs(),
            () => new Skirt(),
            () => new Kilt(),
            () => new Hakama(),
            () => new FurSarong(),
            () => new TigerPeltLongSkirt(),
            () => new GuildedKilt(),
            () => new CheckeredKilt(),
            () => new FancyKilt(),
            () => new TigerPeltSkirt(),
            () => new PlateArms(),
            () => new StuddedBustierArms(),
            () => new RingmailArms(),
            () => new DragonArms(),
            () => new LeafArms(),
            () => new LeatherArms(),
            () => new StuddedArms(),
            () => new WoodlandArms(),
            () => new BoneArms(),
            () => new DragonTurtleHideArms(),
            () => new HidePauldrons(),
            () => new LeatherBustierArms(),
            () => new LeatherHiroSode(),
            () => new PlateHiroSode(),
            () => new StuddedHiroSode(),
            () => new LeatherGloves(),
            () => new PlateGloves(),
            () => new StuddedGloves(),
            () => new BoneGloves(),
            () => new WoodlandGloves(),
            () => new DragonGloves(),
            () => new RingmailGloves(),
            () => new HideGloves(),
            () => new LeafGloves(),
            () => new LeatherNinjaMitts(),
            () => new FullApron(),
            () => new Obi(),
            () => new WoodlandBelt(),
            () => new HalfApron(),
            () => new LeatherGorget(),
            () => new PlateGorget(),
            () => new StuddedGorget(),
            () => new ElegantCollar(),
            () => new HideGorget(),
            () => new TigerPeltCollar(),
            () => new WoodlandGorget(),
            () => new LeafGorget(),
            () => new RandomTalisman(),
            () => new Longsword(),
            () => new Broadsword(),
            () => new Cutlass(),
            () => new Katana(),
            () => new Scimitar(),
            () => new VikingSword(),
            () => new Axe(),
            () => new BattleAxe(),
            () => new DoubleAxe(),
            () => new ExecutionersAxe(),
            () => new LargeBattleAxe(),
            () => new TwoHandedAxe(),
            () => new WarAxe(),
            () => new Club(),
            () => new HammerPick(),
            () => new Mace(),
            () => new Maul(),
            () => new WarHammer(),
            () => new WarMace(),
            () => new Bardiche(),
            () => new Halberd(),
            () => new Lance(),
            () => new Pike(),
            () => new ShortSpear(),
            () => new Spear(),
            () => new WarFork(),
            () => new CompositeBow(),
            () => new Crossbow(),
            () => new HeavyCrossbow(),
            () => new RepeatingCrossbow(),
            () => new Bow(),
            () => new Dagger(),
            () => new Kryss(),
            () => new SkinningKnife(),
            () => new Pitchfork(),
            () => new BlackStaff(),
            () => new GnarledStaff(),
            () => new QuarterStaff(),
            () => new ShepherdsCrook(),
            () => new BladedStaff(),
            () => new Scythe(),
            () => new Scepter(),
            () => new MagicWand(),
            () => new AnimalClaws(),
            () => new WrestlingBelt(),
            () => new ArtificerWand(),
            () => new BashingShield(),
            () => new BeggersStick(),
            () => new BoltRod(),
            () => new CampingLanturn(),
            () => new CarpentersHammer(),
            () => new CooksCleaver(),
            () => new DetectivesBoneHarvester(),
            () => new DistractingHammer(),
            () => new ExplorersMachete(),
            () => new FireAlchemyBlaster(),
            () => new FishermansTrident(),
            () => new FletchersBow(),
            () => new FocusKryss(),
            () => new GearLauncher(),
            () => new GourmandsFork(),
            () => new HolyKnightSword(),
            () => new IllegalCrossbow(),
            () => new IntelligenceEvaluator(),
            () => new LoreSword(),
            () => new MageWand(),
            () => new MallKatana(),
            () => new MeatPicks(),
            () => new MeditationFans(),
            () => new MerchantsShotgun(),
            () => new MysticStaff(),
            () => new NecromancersStaff(),
            () => new NinjaBow(),
            () => new Nunchucks(),
            () => new PoisonBlade(),
            () => new RangersCrossbow(),
            () => new ResonantHarp(),
            () => new RevealingAxe(),
            () => new Scalpel(),
            () => new ScribeSword(),
            () => new SewingNeedle(),
            () => new ShadowSai(),
            () => new SilentBlade(),
            () => new SleepAid(),
            () => new SmithSmasher(),
            () => new SnoopersPaddle(),
            () => new SpellWeaversWand(),
            () => new SpiritScepter(),
            () => new TacticalMultitool(),
            () => new TenFootPole(),
            () => new VeterinaryLance(),
            () => new VivisectionKnife(),
            () => new WitchBurningTorch(),
            () => new AssassinSpike(),
            () => new Bokuto(),
            () => new BoneHarvester(),
            () => new BoneMachete(),
            () => new Boomerang(),
            () => new ButcherKnife(),
            () => new Cleaver(),
            () => new CrescentBlade(),
            () => new Cyclone(),
            () => new Daisho(),
            () => new DiamondMace(),
            () => new DiscMace(),
            () => new DoubleBladedStaff(),
            () => new ElvenCompositeLongbow(),
            () => new ElvenMachete(),
            () => new ElvenSpellblade(),
            () => new JukaBow(),
            () => new Kama(),
            () => new Lajatang(),
            () => new Leafblade(),
            () => new MagicalShortbow(),
            () => new NoDachi(),
            () => new Nunchaku(),
            () => new Pickaxe(),
            () => new Tekagi(),
            () => new Tessen(),
            () => new Tetsubo(),
            () => new Wakizashi(),
            () => new WildStaff(),
            () => new Yumi(),
            () => new Shield(),
            () => new Lantern(),
            () => new BronzeShield(),
            () => new Buckler(),
            () => new HeaterShield(),
            () => new MetalKiteShield(),
            () => new MetalShield(),
            () => new OrderShield(),
            () => new ChaosShield(),
            () => new WoodenKiteShield(),
            () => new WoodenShield(),
            () => new Torch(),
            () => new FootStool(),
            () => new BarrelStaves(),
            () => new BarrelLid(),
            () => new Stool(),
            () => new WoodenBox(),
            () => new SmallCrate(),
            () => new MediumCrate(),
            () => new LargeCrate(),
            () => new WoodenChest(),
            () => new EmptyBookcase(),
            () => new WoodenBench(),
            () => new WoodenThrone(),
            () => new TallCabinet(),
            () => new ShortCabinet(),
            () => new RedArmoire(),
            () => new ElegantArmoire(),
            () => new MapleArmoire(),
            () => new CherryArmoire(),
            () => new LapHarp(),
            () => new Lute(),
            () => new Drums(),
            () => new Harp(),
            () => new PlainWoodenChest(),
            () => new OrnateWoodenChest(),
            () => new GildedWoodenChest(),
            () => new WoodenFootLocker(),
            () => new FinishedWoodenChest(),
            () => new SweetCocoaButter(),
            () => new Dough(),
            () => new UnbakedFruitPie(),
            () => new UnbakedPeachCobbler(),
            () => new UnbakedApplePie(),
            () => new UnbakedPumpkinPie(),
            () => new Cookies(),
            () => new ThreeTieredCake(),
            () => new MisoSoup(),
            () => new WhiteMisoSoup(),
            () => new RedMisoSoup(),
            () => new AwaseMisoSoup(),
            () => new WasabiClumps(),
            () => new SushiRolls(),
            () => new SushiPlatter(),
            () => new GreenTea(),
            () => new SweetDough(),
            () => new CakeMix(),
            () => new CookieMix(),
            () => new UnbakedQuiche(),
            () => new UnbakedMeatPie(),
            () => new UncookedSausagePizza(),
            () => new UncookedCheesePizza(),
            () => new Quiche(),
            () => new MeatPie(),
            () => new SausagePizza(),
            () => new CheesePizza(),
            () => new FruitPie(),
            () => new PeachCobbler(),
            () => new PumpkinPie(),
            () => new EnchantedApple(),
            () => new TribalPaint(),
            () => new GrapesOfWrath(),
            () => new EggBomb(),
            () => new FishSteak(),
            () => new FriedEggs(),
            () => new Ribs(),
            () => new Arrow(),
            () => new Bolt(),
            () => new Kindling(),
            () => new Shaft(),
            () => new ReactiveArmorScroll(),
            () => new ClumsyScroll(),
            () => new CreateFoodScroll(),
            () => new FeeblemindScroll(),
            () => new HealScroll(),
            () => new MagicArrowScroll(),
            () => new NightSightScroll(),
            () => new WeakenScroll(),
            () => new AgilityScroll(),
            () => new CunningScroll(),
            () => new CureScroll(),
            () => new HarmScroll(),
            () => new MagicTrapScroll(),
            () => new ProtectionScroll(),
            () => new StrengthScroll(),
            () => new BlessScroll(),
            () => new FireballScroll(),
            () => new MagicLockScroll(),
            () => new PoisonScroll(),
            () => new TelekinisisScroll(),
            () => new TeleportScroll(),
            () => new UnlockScroll(),
            () => new WallOfStoneScroll(),
            () => new ArchCureScroll(),
            () => new ArchProtectionScroll(),
            () => new CurseScroll(),
            () => new FireFieldScroll(),
            () => new GreaterHealScroll(),
            () => new LightningScroll(),
            () => new ManaDrainScroll(),
            () => new RecallScroll(),
            () => new BladeSpiritsScroll(),
            () => new DispelFieldScroll(),
            () => new IncognitoScroll(),
            () => new MagicReflectScroll(),
            () => new MindBlastScroll(),
            () => new ParalyzeScroll(),
            () => new PoisonFieldScroll(),
            () => new SummonCreatureScroll(),
            () => new DispelScroll(),
            () => new EnergyBoltScroll(),
            () => new ExplosionScroll(),
            () => new InvisibilityScroll(),
            () => new MarkScroll(),
            () => new MassCurseScroll(),
            () => new ParalyzeFieldScroll(),
            () => new RevealScroll(),
            () => new ChainLightningScroll(),
            () => new EnergyFieldScroll(),
            () => new GateTravelScroll(),
            () => new ManaVampireScroll(),
            () => new MassDispelScroll(),
            () => new MeteorSwarmScroll(),
            () => new PolymorphScroll(),
            () => new EarthquakeScroll(),
            () => new EnergyVortexScroll(),
            () => new ResurrectionScroll(),
            () => new SummonAirElementalScroll(),
            () => new SummonDaemonScroll(),
            () => new SummonEarthElementalScroll(),
            () => new SummonFireElementalScroll(),
            () => new SummonWaterElementalScroll(),
            () => new AnimateDeadScroll(),
            () => new BloodOathScroll(),
            () => new CorpseSkinScroll(),
            () => new CurseWeaponScroll(),
            () => new EvilOmenScroll(),
            () => new HorrificBeastScroll(),
            () => new LichFormScroll(),
            () => new MindRotScroll(),
            () => new PainSpikeScroll(),
            () => new PoisonStrikeScroll(),
            () => new StrangleScroll(),
            () => new SummonFamiliarScroll(),
            () => new VampiricEmbraceScroll(),
            () => new VengefulSpiritScroll(),
            () => new WitherScroll(),
            () => new WraithFormScroll(),
            () => new Spellbook(),
            () => new NecromancerSpellbook(),
            () => new Runebook(),
            () => new RunicAtlas(),
            () => new KeyRing(),
            () => new Key(),
            () => new Globe(),
            () => new Spyglass(),
            () => new BarrelTap(),
            () => new BarrelHoops(),
            () => new SmithyHammer(),
            () => new Skillet(),
            () => new SewingKit(),
            () => new FletcherTools(),
            () => new SpoonLeft(),
            () => new ForkLeft(),
            () => new Plate(),
            () => new KnifeLeft(),
            () => new Goblet(),
            () => new PewterMug(),
            () => new Clippers(),
            () => new Tongs(),
            () => new SledgeHammer(),
            () => new Saw(),
            () => new Froe(),
            () => new FlourSifter(),
            () => new JointingPlane(),
            () => new MouldingPlane(),
            () => new SmoothingPlane(),
            () => new Hatchet(),
            () => new Candelabra(),
            () => new Scales(),
            () => new Gears(),
            () => new Axle(),
            () => new Springs(),
            () => new AxleGears(),
            () => new ClockParts(),
            () => new Clock(),
            () => new PotionKeg(),
            () => new ClockFrame(),
            () => new MetalContainerEngraver(),
            () => new Hinge(),
            () => new SextantParts(),
            () => new RodOfOrcControl(),
            () => new Beeswax(),
            () => new WoodenBowlOfCarrots(),
            () => new WoodenBowlOfCorn(),
            () => new WoodenBowlOfLettuce(),
            () => new WoodenBowlOfPeas(),
            () => new EmptyPewterBowl(),
            () => new PewterBowlOfCorn(),
            () => new PewterBowlOfLettuce(),
            () => new PewterBowlOfPeas(),
            () => new PewterBowlOfPotatos(),
            () => new WoodenBowlOfStew(),
            () => new WoodenBowlOfTomatoSoup(),
            () => new Chessboard(),
            () => new CheckerBoard(),
            () => new Backgammon(),
            () => new Dices(),
            () => new ContractOfEmployment(),
            () => new BarkeepContract(),
            () => new VendorRentalContract(),
            () => new Wasabi(),
            () => new BentoBox(),
            () => new GreenTeaBasket(),
            () => new MaxxiaScroll(),
            () => new HeritageSovereign(),
            () => new GenderChangeDeed(),
            () => new MurderRemovalDeed(),
            () => new ClothingBlessDeed(),
            () => new AdventurersContract(),
            () => new TradeRouteContract(),
            () => new HeritageToken(),
            () => new FrenchBread(),
            () => new BowlFlour(),
            () => new DestroyingAngel(),
            () => new SpringWater(),
            () => new PetrafiedWood(),
            () => new HeatingStand(),
            () => new SkinTingeingTincture(),
            () => new TransmutationCauldron(),
            () => new GlassblowingBook(),
            () => new SandMiningBook(),
            () => new Blowpipe(),
            () => new Zychroline(),
            () => new Aetheralate(),
            () => new Neontrium(),
            () => new Oblivionate(),
            () => new Phantomide(),
            () => new Quarkothene(),
            () => new Stygiocarbon(),
            () => new Cryovitrin(),
            () => new Fluxidate(),
            () => new Novaesine(),
            () => new Xenocrylate(),
            () => new Gravitoxane(),
            () => new Eclipsium(),
            () => new Darkspirite(),
            () => new Photoplasmene(),
            () => new Vibranide(),
            () => new Duskenium(),
            () => new Chronodyne(),
            () => new Auroracene(),
            () => new Voidanate(),
            () => new Lumicryne(),
            () => new Prismalium(),
            () => new Etherothal(),
            () => new Pyrolythene(),
            () => new Radiacrylate(),
            () => new Synthionide(),
            () => new Morphaloxane(),
            () => new Astrocyne(),
            () => new Nyxiolate(),
            () => new Spectrovanate(),
            () => new Solvexium(),
            () => new Helionine(),
            () => new Thermodrithium(),
            () => new Arcvaloxate(),
            () => new Cinderathane(),
            () => new Zephyrenium(),
            () => new Kryotoxite(),
            () => new Starshardine(),
            () => new Omniplasium(),
            () => new Nebulifluxate(),
            () => new GraveNylon(),
            () => new Aeroglass(),
            () => new Infinityclay(),
            () => new Bloodglass(),
            () => new DenaturedMorphonite(),
            () => new Energite(),
            () => new FlammablePlasmine(),
            () => new Impervanium(),
            () => new NegativePhocite(),
            () => new OpaqueHydragyon(),
            () => new PositiveEvenium(),
            () => new RefractivePotamite(),
            () => new Schizonite(),
            () => new Thoril(),
            () => new TransparentAurarus(),
            () => new Turbesium(),
            () => new Uranimite(),
            () => new ChargedAcoustesium(),
            () => new ExoticEun(),
            () => new Fibrogen(),
            () => new Flurocite(),
            () => new GaseousAesthogen(),
            () => new HighdensityElectron(),
            () => new MorphicHeteril(),
            () => new Negite(),
            () => new GardeningContract(),
            () => new FishingPole(),
            () => new AquariumFishNet(),
            () => new AquariumFood(),
            () => new FishBowl(),
            () => new VacationWafer(),
            () => new AquariumNorthDeed(),
            () => new AquariumEastDeed(),
            () => new NewAquariumBook(),
            () => new FreshGinger(),
            () => new Pitcher(),
            () => new Hoe(),
            () => new BlackberrySeed(),
            () => new BlackRaspberrySeed(),
            () => new BlueberrySeed(),
            () => new CranberrySeed(),
            () => new PineappleSeed(),
            () => new RedRaspberrySeed(),
            () => new BlackRoseSeed(),
            () => new DandelionSeed(),
            () => new IrishRoseSeed(),
            () => new PansySeed(),
            () => new PinkCarnationSeed(),
            () => new PoppySeed(),
            () => new RedRoseSeed(),
            () => new SnapdragonSeed(),
            () => new SpiritRoseSeed(),
            () => new WhiteRoseSeed(),
            () => new YellowRoseSeed(),
            () => new CottonSeed(),
            () => new FlaxSeed(),
            () => new HaySeed(),
            () => new OatsSeed(),
            () => new RiceSeed(),
            () => new SugarcaneSeed(),
            () => new WheatSeed(),
            () => new GarlicSeed(),
            () => new TanGingerSeed(),
            () => new GinsengSeed(),
            () => new MandrakeSeed(),
            () => new NightshadeSeed(),
            () => new RedMushroomSeed(),
            () => new TanMushroomSeed(),
            () => new BitterHopsSeed(),
            () => new ElvenHopsSeed(),
            () => new SnowHopsSeed(),
            () => new SweetHopsSeed(),
            () => new CornSeed(),
            () => new FieldCornSeed(),
            () => new SunFlowerSeed(),
            () => new TeaSeed(),
            () => new BananaSeed(),
            () => new CoconutSeed(),
            () => new DateSeed(),
            () => new MiniAlmondSeed(),
            () => new MiniAppleSeed(),
            () => new MiniApricotSeed(),
            () => new MiniAvocadoSeed(),
            () => new MiniCherrySeed(),
            () => new MiniCocoaSeed(),
            () => new MiniCoffeeSeed(),
            () => new MiniGrapefruitSeed(),
            () => new MiniKiwiSeed(),
            () => new MiniMangoSeed(),
            () => new MiniOrangeSeed(),
            () => new MiniPeachSeed(),
            () => new MiniPearSeed(),
            () => new MiniPistacioSeed(),
            () => new MiniPomegranateSeed(),
            () => new SmallBananaSeed(),
            () => new AsparagusSeed(),
            () => new BeetSeed(),
            () => new BroccoliSeed(),
            () => new CabbageSeed(),
            () => new CarrotSeed(),
            () => new CauliflowerSeed(),
            () => new CelerySeed(),
            () => new EggplantSeed(),
            () => new GreenBeanSeed(),
            () => new LettuceSeed(),
            () => new OnionSeed(),
            () => new PeanutSeed(),
            () => new PeasSeed(),
            () => new PotatoSeed(),
            () => new RadishSeed(),
            () => new SnowPeasSeed(),
            () => new SoySeed(),
            () => new SpinachSeed(),
            () => new StrawberrySeed(),
            () => new SweetPotatoSeed(),
            () => new TurnipSeed(),
            () => new ChiliPepperSeed(),
            () => new CucumberSeed(),
            () => new GreenPepperSeed(),
            () => new OrangePepperSeed(),
            () => new RedPepperSeed(),
            () => new TomatoSeed(),
            () => new YellowPepperSeed(),
            () => new CantaloupeSeed(),
            () => new GreenSquashSeed(),
            () => new HoneydewMelonSeed(),
            () => new PumpkinSeed(),
            () => new SquashSeed(),
            () => new WatermelonSeed(),
            () => new AppleSeed(),
            () => new BananaTreeSeed(),
            () => new CantaloupeVineSeed(),
            () => new CoconutTreeSeed(),
            () => new DateTreeSeed(),
            () => new GrapeSeed(),
            () => new LemonSeed(),
            () => new LimeSeed(),
            () => new PeachSeed(),
            () => new PearSeed(),
            () => new SquashVineSeed(),
            () => new WatermelonVineSeed(),
            () => new BuildersHammer(),
            () => new CheeseAgingBarrel(),
            () => new PeaceableWoodenFence(),
            () => new MarijuanaSeeds(),
            () => new TaintedSeeds(),
            () => new SilverSaplingSeed(),
            () => new SeedOfLife(),
            () => new SeedOfRenewal(),
            () => new BeetleFeeder(),
            () => new BirdFeeder(),
            () => new BoarFeeder(),
            () => new BullFeeder(),
            () => new BullFrogFeeder(),
            () => new CatFeeder(),
            () => new CowFeeder(),
            () => new DesertOstardFeeder(),
            () => new DogFeeder(),
            () => new DolphinFeeder(),
            () => new ForestOstardFeeder(),
            () => new GamanFeeder(),
            () => new GiantToadFeeder(),
            () => new GoatFeeder(),
            () => new GorillaFeeder(),
            () => new GreatHartFeeder(),
            () => new HindFeeder(),
            () => new HiryuFeeder(),
            () => new HorseFeeder(),
            () => new KirinFeeder(),
            () => new LlamaFeeder(),
            () => new OstardFeeder(),
            () => new PigFeeder(),
            () => new RabbitFeeder(),
            () => new RatFeeder(),
            () => new RidgebackFeeder(),
            () => new SheepFeeder(),
            () => new SwampDragonFeeder(),
            () => new UnicornFeeder(),
            () => new WalrusFeeder(),
            () => new RaisedGardenDeed(),
            () => new SeedBox(),
            () => new AbyssChivesFruit(),
            () => new aggearangFruit(),
            () => new agleatainFruit(),
            () => new ameoyoteFruit(),
            () => new AngelRootFruit(),
            () => new AngelTurnipFruit(),
            () => new ArcticParsnipFruit(),
            () => new AshLycheeFruit(),
            () => new AshRootFruit(),
            () => new AutumnCherryFruit(),
            () => new AutumnPomegranateFruit(),
            () => new BitterDurianFruit(),
            () => new BittersweetChivesFruit(),
            () => new BlackChoyFruit(),
            () => new blattiovesFruit(),
            () => new blearelFruit(),
            () => new BlumbFruit(),
            () => new bosheaShootFruit(),
            () => new brafulalFruit(),
            () => new brongerFruit(),
            () => new BushCerimanFruit(),
            () => new BushSpinachFruit(),
            () => new CandyMorindaFruit(),
            () => new CaveAsparagusFruit(),
            () => new CavePersimmonFruit(),
            () => new CavernMangosteenFruit(),
            () => new chigionutFruit(),
            () => new chummionachFruit(),
            () => new ciarryFruit(),
            () => new CinderGingerFruit(),
            () => new CliffNectarineFruit(),
            () => new crennealeryFruit(),
            () => new criarianFruit(),
            () => new darantFruit(),
            () => new DaydreamPommeracFruit(),
            () => new DesertPlumFruit(),
            () => new DesertRowanFruit(),
            () => new DessertBroccoliFruit(),
            () => new DessertTomatoFruit(),
            () => new DewKiwiFruit(),
            () => new DewPawpawFruit(),
            () => new dimquatFruit(),
            () => new diowanFruit(),
            () => new DragoLimeFruit(),
            () => new DrakeLentilFruit(),
            () => new DrakeMangoFruit(),
            () => new eacketFruit(),
            () => new eacotFruit(),
            () => new earolaFruit(),
            () => new EasternBacuriFruit(),
            () => new eawanFruit(),
            () => new echocadoFruit(),
            () => new ElephantBreadnutFruit(),
            () => new EmberLaurelFruit(),
            () => new EmberLettuceFruit(),
            () => new FalseAlmondFruit(),
            () => new fliavesFruit(),
            () => new FluxxFruit(),
            () => new fucrucotFruit(),
            () => new fudishFruit(),
            () => new fushewFruit(),
            () => new geweodineFruit(),
            () => new gigliachokeFruit(),
            () => new girinFruit(),
            () => new glissidillaFruit(),
            () => new GoldenRocketFruit(),
            () => new grandaFruit(),
            () => new gropioveFruit(),
            () => new GroundPearFruit(),
            () => new grutatoFruit(),
            () => new HairyTomatoFruit(),
            () => new HateCalamansiFruit(),
            () => new HazelLimeFruit(),
            () => new hialoupeFruit(),
            () => new hiorolaFruit(),
            () => new iaconaFruit(),
            () => new IceRocketFruit(),
            () => new iddiochokeFruit(),
            () => new imberFruit(),
            () => new ingeFruit(),
            () => new intineFruit(),
            () => new ippiocressFruit(),
            () => new ittianaFruit(),
            () => new jeorraFruit(),
            () => new jigreapawFruit(),
            () => new jochiniFruit(),
            () => new kledamiaFruit(),
            () => new kleopeFruit(),
            () => new kraccaleryFruit(),
            () => new krevaFruit(),
            () => new LillypillyFruit(),
            () => new LoveKumquatFruit(),
            () => new LoveZucchiniFruit(),
            () => new MageCherryFruit(),
            () => new MageDateFruit(),
            () => new MellowGourdFruit(),
            () => new MoonPumpkinFruit(),
            () => new moyiarlanFruit(),
            () => new MutantLemonFruit(),
            () => new MysteryFruit(),
            () => new MysteryGuavaFruit(),
            () => new MysteryOrangeFruit(),
            () => new NativeRambutanFruit(),
            () => new NightCabbageFruit(),
            () => new NightmareSaguaroFruit(),
            () => new ocanateFruit(),
            () => new OceanMuscadineFruit(),
            () => new omondFruit(),
            () => new otilFruit(),
            () => new PeaceAmaranthFruit(),
            () => new PeaceDateFruit(),
            () => new PeaceNectarineFruit(),
            () => new phecceayoteFruit(),
            () => new piokinFruit(),
            () => new probbacheeFruit(),
            () => new puchiniFruit(),
            () => new PygmyOrangeFruit(),
            () => new qekliatilloFruit(),
            () => new RainLaurelFruit(),
            () => new RainPommeracFruit(),
            () => new rephoneFruit(),
            () => new satilFruit(),
            () => new siheonachFruit(),
            () => new SilverFruit(),
            () => new slirindFruit(),
            () => new slomeloFruit(),
            () => new SmellyCarrotFruit(),
            () => new SourAmaranthFruit(),
            () => new StormBrambleFruit(),
            () => new striachiniFruit(),
            () => new strondaFruit(),
            () => new SwampNectarineFruit(),
            () => new SweetBoquilaFruit(),
            () => new TigerBeanFruit(),
            () => new TropicalCherryFruit(),
            () => new unaFruit(),
            () => new uyerdFruit(),
            () => new veapeFruit(),
            () => new VoidBrambleFruit(),
            () => new VoidOkraFruit(),
            () => new VoidPulasanFruit(),
            () => new VoidSproutFruit(),
            () => new vrecequilaFruit(),
            () => new vropperrotFruit(),
            () => new vuveFruit(),
            () => new WinterCoconutFruit(),
            () => new WonderRambutanFruit(),
            () => new wriggumondFruit(),
            () => new XeenBerryFruit(),
            () => new xekraFruit(),
            () => new xemeloFruit(),
            () => new zanioperFruit(),
            () => new ziongerFruit(),
            () => new PowerScroll( SkillName.Alchemy, 75),
            () => new PowerScroll( SkillName.Anatomy, 75),
            () => new PowerScroll( SkillName.AnimalLore, 75),
            () => new PowerScroll( SkillName.AnimalTaming, 75),
            () => new PowerScroll( SkillName.Archery, 75),
            () => new PowerScroll( SkillName.ArmsLore, 75),
            () => new PowerScroll( SkillName.Begging, 75),
            () => new PowerScroll( SkillName.Blacksmith, 75),
            () => new PowerScroll( SkillName.Bushido, 75),
            () => new PowerScroll( SkillName.Camping, 75),
            () => new PowerScroll( SkillName.Carpentry, 75),
            () => new PowerScroll( SkillName.Cartography, 75),
            () => new PowerScroll( SkillName.Chivalry, 75),
            () => new PowerScroll( SkillName.Cooking, 75),
            () => new PowerScroll( SkillName.DetectHidden, 75),
            () => new PowerScroll( SkillName.Discordance, 75),
            () => new PowerScroll( SkillName.EvalInt, 75),
            () => new PowerScroll( SkillName.Fencing, 75),
            () => new PowerScroll( SkillName.Fishing, 75),
            () => new PowerScroll( SkillName.Fletching, 75),
            () => new PowerScroll( SkillName.Focus, 75),
            () => new PowerScroll( SkillName.Forensics, 75),
            () => new PowerScroll( SkillName.Healing, 75),
            () => new PowerScroll( SkillName.Herding, 75),
            () => new PowerScroll( SkillName.Hiding, 75),
            () => new PowerScroll( SkillName.Imbuing, 75),
            () => new PowerScroll( SkillName.Inscribe, 75),
            () => new PowerScroll( SkillName.ItemID, 75),
            () => new PowerScroll( SkillName.Lockpicking, 75),
            () => new PowerScroll( SkillName.Lumberjacking, 75),
            () => new PowerScroll( SkillName.Macing, 75),
            () => new PowerScroll( SkillName.MagicResist, 75),
            () => new PowerScroll( SkillName.Meditation, 75),
            () => new PowerScroll( SkillName.Mining, 75),
            () => new PowerScroll( SkillName.Musicianship, 75),
            () => new PowerScroll( SkillName.Mysticism, 75),
            () => new PowerScroll( SkillName.Necromancy, 75),
            () => new PowerScroll( SkillName.Ninjitsu, 75),
            () => new PowerScroll( SkillName.Parry, 75),
            () => new PowerScroll( SkillName.Peacemaking, 75),
            () => new PowerScroll( SkillName.Poisoning, 75),
            () => new PowerScroll( SkillName.Provocation, 75),
            () => new PowerScroll( SkillName.RemoveTrap, 75),
            () => new PowerScroll( SkillName.Snooping, 75),
            () => new PowerScroll( SkillName.Spellweaving, 75),
            () => new PowerScroll( SkillName.SpiritSpeak, 75),
            () => new PowerScroll( SkillName.Stealing, 75),
            () => new PowerScroll( SkillName.Stealth, 75),
            () => new PowerScroll( SkillName.Swords, 75),
            () => new PowerScroll( SkillName.Tactics, 75),
            () => new PowerScroll( SkillName.Tailoring, 75),
            () => new PowerScroll( SkillName.TasteID, 75),
            () => new PowerScroll( SkillName.Throwing, 75),
            () => new PowerScroll( SkillName.Tinkering, 75),
            () => new PowerScroll( SkillName.Tracking, 75),
            () => new PowerScroll( SkillName.Veterinary, 75),
            () => new PowerScroll( SkillName.Wrestling, 75),
            () => new PowerScroll( SkillName.Alchemy, 90),
            () => new PowerScroll( SkillName.Anatomy, 90),
            () => new PowerScroll( SkillName.AnimalLore, 90),
            () => new PowerScroll( SkillName.AnimalTaming, 90),
            () => new PowerScroll( SkillName.Archery, 90),
            () => new PowerScroll( SkillName.ArmsLore, 90),
            () => new PowerScroll( SkillName.Begging, 90),
            () => new PowerScroll( SkillName.Blacksmith, 90),
            () => new PowerScroll( SkillName.Bushido, 90),
            () => new PowerScroll( SkillName.Camping, 90),
            () => new PowerScroll( SkillName.Carpentry, 90),
            () => new PowerScroll( SkillName.Cartography, 90),
            () => new PowerScroll( SkillName.Chivalry, 90),
            () => new PowerScroll( SkillName.Cooking, 90),
            () => new PowerScroll( SkillName.DetectHidden, 90),
            () => new PowerScroll( SkillName.Discordance, 90),
            () => new PowerScroll( SkillName.EvalInt, 90),
            () => new PowerScroll( SkillName.Fencing, 90),
            () => new PowerScroll( SkillName.Fishing, 90),
            () => new PowerScroll( SkillName.Fletching, 90),
            () => new PowerScroll( SkillName.Focus, 90),
            () => new PowerScroll( SkillName.Forensics, 90),
            () => new PowerScroll( SkillName.Healing, 90),
            () => new PowerScroll( SkillName.Herding, 90),
            () => new PowerScroll( SkillName.Hiding, 90),
            () => new PowerScroll( SkillName.Imbuing, 90),
            () => new PowerScroll( SkillName.Inscribe, 90),
            () => new PowerScroll( SkillName.ItemID, 90),
            () => new PowerScroll( SkillName.Lockpicking, 90),
            () => new PowerScroll( SkillName.Lumberjacking, 90),
            () => new PowerScroll( SkillName.Macing, 90),
            () => new PowerScroll( SkillName.MagicResist, 90),
            () => new PowerScroll( SkillName.Meditation, 90),
            () => new PowerScroll( SkillName.Mining, 90),
            () => new PowerScroll( SkillName.Musicianship, 90),
            () => new PowerScroll( SkillName.Mysticism, 90),
            () => new PowerScroll( SkillName.Necromancy, 90),
            () => new PowerScroll( SkillName.Ninjitsu, 90),
            () => new PowerScroll( SkillName.Parry, 90),
            () => new PowerScroll( SkillName.Peacemaking, 90),
            () => new PowerScroll( SkillName.Poisoning, 90),
            () => new PowerScroll( SkillName.Provocation, 90),
            () => new PowerScroll( SkillName.RemoveTrap, 90),
            () => new PowerScroll( SkillName.Snooping, 90),
            () => new PowerScroll( SkillName.Spellweaving, 90),
            () => new PowerScroll( SkillName.SpiritSpeak, 90),
            () => new PowerScroll( SkillName.Stealing, 90),
            () => new PowerScroll( SkillName.Stealth, 90),
            () => new PowerScroll( SkillName.Swords, 90),
            () => new PowerScroll( SkillName.Tactics, 90),
            () => new PowerScroll( SkillName.Tailoring, 90),
            () => new PowerScroll( SkillName.TasteID, 90),
            () => new PowerScroll( SkillName.Throwing, 90),
            () => new PowerScroll( SkillName.Tinkering, 90),
            () => new PowerScroll( SkillName.Tracking, 90),
            () => new PowerScroll( SkillName.Veterinary, 90),
            () => new PowerScroll( SkillName.Wrestling, 90),
            () => new PowerScroll( SkillName.Alchemy, 100),
            () => new PowerScroll( SkillName.Anatomy, 100),
            () => new PowerScroll( SkillName.AnimalLore, 100),
            () => new PowerScroll( SkillName.AnimalTaming, 100),
            () => new PowerScroll( SkillName.Archery, 100),
            () => new PowerScroll( SkillName.ArmsLore, 100),
            () => new PowerScroll( SkillName.Begging, 100),
            () => new PowerScroll( SkillName.Blacksmith, 100),
            () => new PowerScroll( SkillName.Bushido, 100),
            () => new PowerScroll( SkillName.Camping, 100),
            () => new PowerScroll( SkillName.Carpentry, 100),
            () => new PowerScroll( SkillName.Cartography, 100),
            () => new PowerScroll( SkillName.Chivalry, 100),
            () => new PowerScroll( SkillName.Cooking, 100),
            () => new PowerScroll( SkillName.DetectHidden, 100),
            () => new PowerScroll( SkillName.Discordance, 100),
            () => new PowerScroll( SkillName.EvalInt, 100),
            () => new PowerScroll( SkillName.Fencing, 100),
            () => new PowerScroll( SkillName.Fishing, 100),
            () => new PowerScroll( SkillName.Fletching, 100),
            () => new PowerScroll( SkillName.Focus, 100),
            () => new PowerScroll( SkillName.Forensics, 100),
            () => new PowerScroll( SkillName.Healing, 100),
            () => new PowerScroll( SkillName.Herding, 100),
            () => new PowerScroll( SkillName.Hiding, 100),
            () => new PowerScroll( SkillName.Imbuing, 100),
            () => new PowerScroll( SkillName.Inscribe, 100),
            () => new PowerScroll( SkillName.ItemID, 100),
            () => new PowerScroll( SkillName.Lockpicking, 100),
            () => new PowerScroll( SkillName.Lumberjacking, 100),
            () => new PowerScroll( SkillName.Macing, 100),
            () => new PowerScroll( SkillName.MagicResist, 100),
            () => new PowerScroll( SkillName.Meditation, 100),
            () => new PowerScroll( SkillName.Mining, 100),
            () => new PowerScroll( SkillName.Musicianship, 100),
            () => new PowerScroll( SkillName.Mysticism, 100),
            () => new PowerScroll( SkillName.Necromancy, 100),
            () => new PowerScroll( SkillName.Ninjitsu, 100),
            () => new PowerScroll( SkillName.Parry, 100),
            () => new PowerScroll( SkillName.Peacemaking, 100),
            () => new PowerScroll( SkillName.Poisoning, 100),
            () => new PowerScroll( SkillName.Provocation, 100),
            () => new PowerScroll( SkillName.RemoveTrap, 100),
            () => new PowerScroll( SkillName.Snooping, 100),
            () => new PowerScroll( SkillName.Spellweaving, 100),
            () => new PowerScroll( SkillName.SpiritSpeak, 100),
            () => new PowerScroll( SkillName.Stealing, 100),
            () => new PowerScroll( SkillName.Stealth, 100),
            () => new PowerScroll( SkillName.Swords, 100),
            () => new PowerScroll( SkillName.Tactics, 100),
            () => new PowerScroll( SkillName.Tailoring, 100),
            () => new PowerScroll( SkillName.TasteID, 100),
            () => new PowerScroll( SkillName.Throwing, 100),
            () => new PowerScroll( SkillName.Tinkering, 100),
            () => new PowerScroll( SkillName.Tracking, 100),
            () => new PowerScroll( SkillName.Veterinary, 100),
            () => new PowerScroll( SkillName.Wrestling, 100),			
            () => new MirrorOfKalandra()
        };

		public static int LootTableCount => LootTable.Count;

		public static Item GetLootByIndex(int index)
		{
			if (index >= 0 && index < LootTable.Count)
				return LootTable[index]();
			return null;
		}

        private static readonly double[] DropChances = { 0.40, 0.20, 0.10, 0.05 };

		public static void AddLoot(Mobile mob)
		{
			// Ensure the mobile has a backpack.
			Container pack = mob.Backpack;
			if (pack == null)
			{
				pack = new Backpack { Movable = false, Visible = false };
				mob.AddItem(pack);
			}

			// Add base gold and notes
			if (Utility.RandomDouble() < 0.5)
				pack.DropItem(new Gold(Utility.RandomMinMax(100, 500)));
			if (Utility.RandomDouble() < 0.3)
				pack.DropItem(new Gold(Utility.RandomMinMax(500, 1000)));
			if (Utility.RandomDouble() < 0.5)
				pack.DropItem(CreatePersonalNote());
			if (Utility.RandomDouble() < 0.5)
				pack.DropItem(CreatePersonalNote());

			// Check for the 1-in-20 vendor case
			if (Utility.Random(10) == 0)
			{
				// Create a container to simulate the vendor's inventory
				Bag vendorPack = new Bag
				{
					Name = "Wandering Vendor's Goods"
				};

				int vendorItemCount = Utility.RandomMinMax(5, 20);
				HashSet<int> chosenIndexes = new HashSet<int>();

				for (int i = 0; i < vendorItemCount && chosenIndexes.Count < LootTable.Count; i++)
				{
					int index;
					do
					{
						index = Utility.Random(LootTable.Count);
					}
					while (!chosenIndexes.Add(index)); // unique items

					int amount = Utility.RandomMinMax(1, 20);
					Item item = LootTable[index]();

					if (item.Stackable)
					{
						item.Amount = amount;
						vendorPack.DropItem(item);
					}
					else
					{
						for (int j = 0; j < amount; j++)
						{
							vendorPack.DropItem(LootTable[index]());
						}
					}
				}

				pack.DropItem(vendorPack);
				return; // Skip the standard drop
			}

			// Regular drop logic
			int dropCount = 0;
			foreach (double chance in DropChances)
			{
				if (Utility.RandomDouble() < chance)
					dropCount++;
			}

			HashSet<int> regularIndexes = new HashSet<int>();
			for (int i = 0; i < dropCount && regularIndexes.Count < LootTable.Count; i++)
			{
				int index;
				do
				{
					index = Utility.Random(LootTable.Count);
				}
				while (!regularIndexes.Add(index));

				pack.DropItem(LootTable[index]());
			}
		}


        private static SimpleNote CreatePersonalNote()
        {
            SimpleNote note = new SimpleNote();
            switch (Utility.Random(70))
            {
                case 0:
                    note.TitleString = "A Secret to Keep";
                    note.NoteString = "Look for the hidden treasure behind the old oak tree.";
                    break;
                case 1:
                    note.TitleString = "Craftsmanship Admired";
                    note.NoteString = "The blacksmith's work is exceptional.";
                    break;
				case 2:
					note.TitleString = "A Special Occasion";
					note.NoteString = "Our anniversary is coming up; must plan something special.";
					break;
				case 3:
					note.TitleString = "Family Matters";
					note.NoteString = "The children love the new nanny.";
					break;
				case 4:
					note.TitleString = "Household Duties";
					note.NoteString = "Paid the gardener his due; the lawn looks magnificent.";
					break;
				case 5:
					note.TitleString = "Feast Preparations";
					note.NoteString = "Preparing for the big feast next week.";
					break;
				case 6:
					note.TitleString = "Antique Collector's Reminder";
					note.NoteString = "Must not forget to polish my collection of antique spoons every Friday.";
					break;
				case 7:
					note.TitleString = "A Merchant’s Worries";
					note.NoteString = "That last shipment of spices never arrived…";
					break;
				case 8:
					note.TitleString = "Suspicious Activity";
					note.NoteString = "Someone has been following me. Need to change my route home.";
					break;
				case 9:
					note.TitleString = "A Secret Rendezvous";
					note.NoteString = "Meet me at the docks at midnight. Bring no one.";
					break;
				case 10:
					note.TitleString = "Unpaid Debts";
					note.NoteString = "I must collect the coin from old Jared before week's end.";
					break;
				case 11:
					note.TitleString = "A Lover’s Note";
					note.NoteString = "I cannot wait to see you under the willow tree again.";
					break;
				case 12:
					note.TitleString = "The Alchemist’s Curiosity";
					note.NoteString = "The strange plant by the river glows at night… must investigate.";
					break;
				case 13:
					note.TitleString = "A Noble’s Request";
					note.NoteString = "Send word to the tailor—my new robes must be ready by the royal banquet.";
					break;
				case 14:
					note.TitleString = "A Tavern Secret";
					note.NoteString = "The barkeep waters down his ale. No wonder the price is so low.";
					break;
				case 15:
					note.TitleString = "The Fisherman’s Luck";
					note.NoteString = "Caught the biggest trout of my life today! The village will talk about this for weeks!";
					break;
				case 16:
					note.TitleString = "A Scholar’s Dilemma";
					note.NoteString = "If my calculations are correct, the planets will align tomorrow night.";
					break;
				case 17:
					note.TitleString = "A Forgotten Debt";
					note.NoteString = "I owe Thomas 10 gold from our last card game. Must repay soon.";
					break;
				case 18:
					note.TitleString = "A Farmer’s Concern";
					note.NoteString = "The crows have returned. I must reinforce the scarecrows.";
					break;
				case 19:
					note.TitleString = "A Blacksmith’s Worry";
					note.NoteString = "My best hammer has gone missing. I suspect young Henry took it.";
					break;
				case 20:
					note.TitleString = "A Rogue’s Mark";
					note.NoteString = "The mark is in the marketplace at dawn. Easy pickings.";
					break;
				case 21:
					note.TitleString = "The Guard Captain’s Suspicion";
					note.NoteString = "Smugglers have been using the east gate. Must alert the men.";
					break;
				case 22:
					note.TitleString = "A Miner’s Grievance";
					note.NoteString = "The new tunnel is unstable. We need better supports before digging further.";
					break;
				case 23:
					note.TitleString = "An Old Legend";
					note.NoteString = "They say the ghost of the weeping widow still roams the forest at night.";
					break;
				case 24:
					note.TitleString = "A Personal Regret";
					note.NoteString = "I should have never sold grandmother’s locket.";
					break;
				case 25:
					note.TitleString = "A Collector’s Dream";
					note.NoteString = "One more rare coin and my collection will be complete.";
					break;
				case 26:
					note.TitleString = "A Hunter’s Tale";
					note.NoteString = "The white stag eludes me once more… but I will not give up the chase.";
					break;
				case 27:
					note.TitleString = "A Mage’s Experiment";
					note.NoteString = "The last spell nearly burned my house down. I must refine the incantation.";
					break;
				case 28:
					note.TitleString = "A Hidden Cache";
					note.NoteString = "Buried the gold by the old well. Hope no one finds it.";
					break;
				case 29:
					note.TitleString = "A Sailor’s Warning";
					note.NoteString = "The sea is restless tonight… best delay the voyage.";
					break;
				case 30:
					note.TitleString = "A Guard’s Report";
					note.NoteString = "The perimeter is secure, but I swear I saw someone lurking in the shadows.";
					break;
				case 31:
					note.TitleString = "A Merchant’s Woes";
					note.NoteString = "My shipment was delayed again. I’ll have to find a new supplier.";
					break;
				case 32:
					note.TitleString = "An Adventurer’s Journal";
					note.NoteString = "Found a hidden cavern behind the waterfall. Who knows what treasures lie within?";
					break;
				case 33:
					note.TitleString = "A Tailor’s Reflections";
					note.NoteString = "The fabric for the new gown is exquisite. Can’t wait to see it finished.";
					break;
				case 34:
					note.TitleString = "A Miner’s Discovery";
					note.NoteString = "I stumbled upon something strange in the tunnels today… something not of this world.";
					break;
				case 35:
					note.TitleString = "A Blacksmith’s Dream";
					note.NoteString = "I’ve been working on a new sword design. It’s going to be the sharpest blade I’ve ever made.";
					break;
				case 36:
					note.TitleString = "A Thief’s Memoir";
					note.NoteString = "The vault was full of treasures, but the real prize was the ancient ring hidden beneath.";
					break;
				case 37:
					note.TitleString = "A Baker’s Morning";
					note.NoteString = "The bread came out perfect today! I can already smell it from the oven.";
					break;
				case 38:
					note.TitleString = "A Farmer’s Reflection";
					note.NoteString = "The harvest is good this year. I should think about expanding the field.";
					break;
				case 39:
					note.TitleString = "A Hunter’s Record";
					note.NoteString = "Tracking that wolf took all day, but I finally bagged it. I’ll make a fine pelt out of it.";
					break;
				case 40:
					note.TitleString = "A Bandit’s Grin";
					note.NoteString = "The road’s been quiet, but the next caravan should be easy pickings.";
					break;
				case 41:
					note.TitleString = "A Sorcerer’s Contemplation";
					note.NoteString = "The ritual failed again. I need to find a better source of power.";
					break;
				case 42:
					note.TitleString = "A Sailor’s Promise";
					note.NoteString = "The sea may be unpredictable, but my crew will sail through any storm.";
					break;
				case 43:
					note.TitleString = "A Noble’s Disappointment";
					note.NoteString = "The ball was a disaster. I’ll have to rebuild my reputation.";
					break;
				case 44:
					note.TitleString = "An Alchemist’s Revelation";
					note.NoteString = "The potion is unstable. I need to find more of the rare herbs before attempting again.";
					break;
				case 45:
					note.TitleString = "A Traveler’s Tale";
					note.NoteString = "I’ve seen cities beyond count, but there’s something about this place that feels different.";
					break;
				case 46:
					note.TitleString = "A Knight’s Code";
					note.NoteString = "The code of honor is what drives me. Without it, I am nothing.";
					break;
				case 47:
					note.TitleString = "An Old Soldier’s Remembrance";
					note.NoteString = "The battles fade in my memory, but the comrades I’ve lost will never be forgotten.";
					break;
				case 48:
					note.TitleString = "A Merchant’s Bargain";
					note.NoteString = "I got a good deal on silk today. Should be able to sell it at a nice profit.";
					break;
				case 49:
					note.TitleString = "A Minstrel’s Song";
					note.NoteString = "The melody is stuck in my head. Maybe I’ll make a song of it.";
					break;
				case 50:
					note.TitleString = "A Monk’s Reflection";
					note.NoteString = "Peace within is the only path. The world’s chaos cannot touch me unless I allow it.";
					break;
				case 51:
					note.TitleString = "A Priest’s Sermon";
					note.NoteString = "The faithful gathered today, but I fear they are not truly listening.";
					break;
				case 52:
					note.TitleString = "A Student’s Dilemma";
					note.NoteString = "The teacher has been harder on me lately. I must try harder to earn their approval.";
					break;
				case 53:
					note.TitleString = "A Duelist’s Pride";
					note.NoteString = "My skill with a blade grows daily. Soon, no one will be able to challenge me.";
					break;
				case 54:
					note.TitleString = "A Cartographer’s Discovery";
					note.NoteString = "I found an uncharted island today. I’ll have to map it out in greater detail.";
					break;
				case 55:
					note.TitleString = "A Gardener’s Joy";
					note.NoteString = "The roses have bloomed beautifully this year. The garden looks perfect.";
					break;
				case 56:
					note.TitleString = "A Druid’s Wisdom";
					note.NoteString = "The forest speaks to me. I must listen closely to understand its needs.";
					break;
				case 57:
					note.TitleString = "A Wizard’s Worry";
					note.NoteString = "The spellbook is nearly complete. Just need a few more ingredients from the old forest.";
					break;
				case 58:
					note.TitleString = "A Gladiator’s Victory";
					note.NoteString = "Victory feels sweet. The crowd’s roars still echo in my ears.";
					break;
				case 59:
					note.TitleString = "A Town’s Gossip";
					note.NoteString = "Did you hear? The mayor’s daughter is missing! Some say she’s run away with the baker’s son.";
					break;
				case 60:
					note.TitleString = "A Cook’s Experiment";
					note.NoteString = "The new stew recipe was a hit. I think I’ll make it the special again tomorrow.";
					break;
				case 61:
					note.TitleString = "A Villager’s Concern";
					note.NoteString = "The roads are getting more dangerous. I’ll have to secure the gate better.";
					break;
				case 62:
					note.TitleString = "A Spy’s Report";
					note.NoteString = "The target is in place. The moment to strike will come soon.";
					break;
				case 63:
					note.TitleString = "A Guard’s Note";
					note.NoteString = "A suspicious figure was spotted near the castle gates. Keep watch.";
					break;
				case 64:
					note.TitleString = "A Hunter’s Tale";
					note.NoteString = "The beasts in the woods grow bolder. I’ll need to take stronger precautions next time.";
					break;
				case 65:
					note.TitleString = "A Baker’s Secret";
					note.NoteString = "The flour from that special mill makes the bread rise perfectly every time.";
					break;
				case 66:
					note.TitleString = "A Ship Captain’s Log";
					note.NoteString = "The seas were calm today, but the crew is getting restless. I think I need a diversion.";
					break;
				case 67:
					note.TitleString = "A Fisherman’s Secret";
					note.NoteString = "The catch today was plentiful. I think the lake holds more secrets than we know.";
					break;
				case 68:
					note.TitleString = "A Pilgrim’s Journey";
					note.NoteString = "I’m nearing my destination. The journey has been long, but I can feel I am close.";
					break;
				case 69:
					note.TitleString = "A Farmer’s Worry";
					note.NoteString = "The drought is getting worse. If we don’t see rain soon, the crops will fail.";
					break;					
                default:
                    note.TitleString = "A Curious Scribble";
                    note.NoteString = "A few words hastily written, their meaning unclear.";
                    break;
            }
            return note;
        }
    }
}
