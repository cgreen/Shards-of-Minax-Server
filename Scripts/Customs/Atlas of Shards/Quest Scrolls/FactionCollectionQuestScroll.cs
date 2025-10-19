/*
 * FactionCollectionQuestScroll.cs
 *
 * A self-contained, parameter-friendly collection quest that awards faction reputation.
 * © 2025 – free to use / modify.
 */

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.Plants;
using Server.Items.Crops;
using Server.Targeting;
using Server.Gumps;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;   // for XmlAttach and XmlMobFactions

namespace Server.Items
{
    public class FactionCollectionQuestScroll : Item
    {
        // --- ❶ default pools --------------------------------------------------

        private static readonly Type[] DefaultChallengePool =
        {
            typeof(Log), 
			typeof(IronIngot), 
			typeof(Leather),
            typeof(Bone), 
			typeof(BlackPearl),
			typeof(IronIngot),
			typeof(DullCopperIngot),
			typeof(ShadowIronIngot),
			typeof(CopperIngot),
			typeof(BronzeIngot),
			typeof(GoldIngot),
			typeof(AgapiteIngot),
			typeof(VeriteIngot),
			typeof(ValoriteIngot),
			typeof(RefreshPotion),
			typeof(AgilityPotion),
			typeof(NightSightPotion),
			typeof(LesserHealPotion),
			typeof(StrengthPotion),
			typeof(LesserPoisonPotion),
			typeof(LesserCurePotion),
			typeof(LesserExplosionPotion),
			typeof(MortarPestle),
			typeof(BlackPearl),
			typeof(Bloodmoss),
			typeof(Garlic),
			typeof(Ginseng),
			typeof(MandrakeRoot),
			typeof(Nightshade),
			typeof(SpidersSilk),
			typeof(SulfurousAsh),
			typeof(Bottle),
			typeof(Bacon),
			typeof(Ham),
			typeof(Sausage),
			typeof(RawChickenLeg),
			typeof(RawBird),
			typeof(RawLambLeg),
			typeof(RawRibs),
			typeof(Board),
			typeof(BreadLoaf),
			typeof(ApplePie),
			typeof(Cake),
			typeof(Muffins),
			typeof(CheeseWheel),
			typeof(CookedBird),
			typeof(LambLeg),
			typeof(ChickenLeg),
			typeof(SackFlour),
			typeof(JarHoney),
			typeof(Cabbage),
			typeof(Cantaloupe),
			typeof(Carrot),
			typeof(HoneydewMelon),
			typeof(Squash),
			typeof(Lettuce),
			typeof(Onion),
			typeof(Pumpkin),
			typeof(GreenGourd),
			typeof(YellowGourd),
			typeof(Turnip),
			typeof(Watermelon),
			typeof(EarOfCorn),
			typeof(Eggs),
			typeof(Peach),
			typeof(Pear),
			typeof(Lemon),
			typeof(Lime),
			typeof(Grapes),
			typeof(Apple),
			typeof(SheafOfHay),
			typeof(RawFishSteak),
			typeof(SmallFish),
			typeof(Fish),
			typeof(Hides),
			typeof(GoldRing),
			typeof(Necklace),
			typeof(GoldNecklace),
			typeof(GoldBeadNecklace),
			typeof(Beads),
			typeof(GoldBracelet),
			typeof(GoldEarrings),
			typeof(StarSapphire),
			typeof(Emerald),
			typeof(Sapphire),
			typeof(Ruby),
			typeof(Citrine),
			typeof(Amethyst),
			typeof(Tourmaline),
			typeof(Amber),
			typeof(Diamond),
			typeof(BatWing),
			typeof(DaemonBlood),
			typeof(PigIron),
			typeof(NoxCrystal),
			typeof(GraveDust),
			typeof(BoltOfCloth),
			typeof(Cloth),
			typeof(UncutCloth),
			typeof(Cotton),
			typeof(Wool),
			typeof(Flax),
			typeof(SpoolOfThread),
			typeof(OakLog),
			typeof(AshLog),
			typeof(YewLog),
			typeof(BloodwoodLog),
			typeof(ElixirOfRebirth),
			typeof(MedusaBlood),
			typeof(BarrabHemolymphConcentrate),
			typeof(PlantClippings),
			typeof(MyrmidexEggsac),
			typeof(InvisibilityPotion),
			typeof(JukariBurnPoiltice),
			typeof(LavaBerry),
			typeof(Vanilla),
			typeof(BlueDiamond),
			typeof(TigerPelt),
			typeof(PerfectBanana),
			typeof(YellowScales),
			typeof(RiverMoss),
			typeof(UraliTranceTonic),
			typeof(PoisonPotion),
			typeof(GreaterPoisonPotion),
			typeof(DeadlyPoisonPotion),
			typeof(ParasiticPotion),
			typeof(ParasiticPlant),
			typeof(DarkglowPotion),
			typeof(LuminescentFungi),
			typeof(ScouringToxin),
			typeof(ToxicVenomSac),
			typeof(ExplosionPotion),
			typeof(GreaterExplosionPotion),
			typeof(TacticalBomb),
			typeof(StrategicBomb),
			typeof(MegaBombPotion),
			typeof(MinorPoisonBomb),
			typeof(PoisonBomb),
			typeof(UltraPoisonBomb),
			typeof(MegaHealthBomb),
			typeof(ConflagrationPotion),
			typeof(GreaterConflagrationPotion),
			typeof(ConfusionBlastPotion),
			typeof(GreaterConfusionBlastPotion),
			typeof(BlackPowder),
			typeof(Saltpeter),
			typeof(Charcoal),
			typeof(Matchcord),
			typeof(Potash),
			typeof(SmokeBomb),
			typeof(HoveringWisp),
			typeof(NaturalDye),
			typeof(ColorFixative),
			typeof(NexusCore),
			typeof(DarkSapphire),
			typeof(CrushedGlass),
			typeof(CrystalGranules),
			typeof(CrystalDust),
			typeof(SoftenedReeds),
			typeof(VialOfVitriol),
			typeof(DryReeds),
			typeof(CrystallineFragments),
			typeof(ShimmeringCrystals),
			typeof(SilverSerpentVenom),
			typeof(BottleIchor),
			typeof(GoldDust),
			typeof(Boots),
			typeof(Sandals),
			typeof(Shoes),
			typeof(NinjaTabi),
			typeof(FurBoots),
			typeof(ThighBoots),
			typeof(ElvenBoots),
			typeof(SamuraiTabi),
			typeof(Waraji),
			typeof(JesterShoes),
			typeof(Robe),
			typeof(FancyDress),
			typeof(GildedDress),
			typeof(DeathRobe),
			typeof(MonkRobe),
			typeof(Kamishimo),
			typeof(HakamaShita),
			typeof(MaleKimono),
			typeof(FemaleKimono),
			typeof(MaleElvenRobe),
			typeof(FemaleElvenRobe),
			typeof(FloweredDress),
			typeof(EveningGown),
			typeof(PlainDress),
			typeof(HoodedShroudOfShadows),
			typeof(Epaulette),
			typeof(Cloak),
			typeof(Quiver),
			typeof(FeatheredHat),
			typeof(JesterHat),
			typeof(FloppyHat),
			typeof(Cap),
			typeof(WideBrimHat),
			typeof(StrawHat),
			typeof(TallStrawHat),
			typeof(WizardsHat),
			typeof(Bonnet),
			typeof(TricorneHat),
			typeof(Bandana),
			typeof(SkullCap),
			typeof(Kasa),
			typeof(ClothNinjaHood),
			typeof(FlowerGarland),
			typeof(BearMask),
			typeof(DeerMask),
			typeof(HornedTribalMask),
			typeof(TribalMask),
			typeof(OrcishKinMask),
			typeof(OrcMask),
			typeof(SavageMask),
			typeof(ChefsToque),
			typeof(Bascinet),
			typeof(CloseHelm),
			typeof(NorseHelm),
			typeof(OrcHelm),
			typeof(Helmet),
			typeof(AssassinsCowl),
			typeof(ChainHatsuburi),
			typeof(ChainCoif),
			typeof(Circlet),
			typeof(DecorativePlateKabuto),
			typeof(DragonTurtleHideHelm),
			typeof(EvilOrcHelm),
			typeof(LeatherCap),
			typeof(LeatherJingasa),
			typeof(LeatherMempo),
			typeof(LeatherNinjaHood),
			typeof(LightPlateJingasa),
			typeof(PlateBattleKabuto),
			typeof(PlateHelm),
			typeof(PlateMempo),
			typeof(RavenHelm),
			typeof(SmallPlateJingasa),
			typeof(StandardPlateKabuto),
			typeof(StuddedMempo),
			typeof(TigerPeltHelm),
			typeof(VultureHelm),
			typeof(PlateHatsuburi),
			typeof(BoneHelm),
			typeof(DragonHelm),
			typeof(HeavyPlateJingasa),
			typeof(WingedHelm),
			typeof(FancyShirt),
			typeof(Tunic),
			typeof(BodySash),
			typeof(Shirt),
			typeof(ElvenShirt),
			typeof(FormalShirt),
			typeof(ClothNinjaJacket),
			typeof(Doublet),
			typeof(Surcoat),
			typeof(JinBaori),
			typeof(JesterSuit),
			typeof(PlateChest),
			typeof(RingmailChest),
			typeof(ChainChest),
			typeof(LeatherChest),
			typeof(FemaleLeatherChest),
			typeof(FemalePlateChest),
			typeof(StuddedChest),
			typeof(BoneChest),
			typeof(DragonChest),
			typeof(DragonTurtleHideChest),
			typeof(FemaleLeafChest),
			typeof(FemaleStuddedChest),
			typeof(HideFemaleChest),
			typeof(LeafChest),
			typeof(LeatherNinjaJacket),
			typeof(TigerPeltChest),
			typeof(WoodlandChest),
			typeof(HideChest),
			typeof(LeatherDo),
			typeof(PlateDo),
			typeof(StuddedDo),
			typeof(DragonTurtleHideBustier),
			typeof(TigerPeltBustier),
			typeof(LongPants),
			typeof(ShortPants),
			typeof(LeatherShorts),
			typeof(ElvenPants),
			typeof(HidePants),
			typeof(LeatherNinjaPants),
			typeof(TattsukeHakama),
			typeof(PlateLegs),
			typeof(LeatherLegs),
			typeof(ChainLegs),
			typeof(StuddedLegs),
			typeof(DragonLegs),
			typeof(DragonTurtleHideLegs),
			typeof(LeafLegs),
			typeof(RingmailLegs),
			typeof(LeafTonlet),
			typeof(TigerPeltLegs),
			typeof(TigerPeltShorts),
			typeof(LeatherHaidate),
			typeof(PlateHaidate),
			typeof(LeatherSkirt),
			typeof(LeatherSuneate),
			typeof(StuddedHaidate),
			typeof(PlateSuneate),
			typeof(StuddedSuneate),
			typeof(WoodlandLegs),
			typeof(Skirt),
			typeof(Kilt),
			typeof(Hakama),
			typeof(FurSarong),
			typeof(TigerPeltLongSkirt),
			typeof(GuildedKilt),
			typeof(CheckeredKilt),
			typeof(FancyKilt),
			typeof(TigerPeltSkirt),
			typeof(PlateArms),
			typeof(StuddedBustierArms),
			typeof(RingmailArms),
			typeof(DragonArms),
			typeof(LeafArms),
			typeof(LeatherArms),
			typeof(StuddedArms),
			typeof(WoodlandArms),
			typeof(BoneArms),
			typeof(DragonTurtleHideArms),
			typeof(HidePauldrons),
			typeof(LeatherBustierArms),
			typeof(LeatherHiroSode),
			typeof(PlateHiroSode),
			typeof(StuddedHiroSode),
			typeof(LeatherGloves),
			typeof(PlateGloves),
			typeof(StuddedGloves),
			typeof(BoneGloves),
			typeof(WoodlandGloves),
			typeof(DragonGloves),
			typeof(RingmailGloves),
			typeof(HideGloves),
			typeof(LeafGloves),
			typeof(LeatherNinjaMitts),
			typeof(FullApron),
			typeof(Obi),
			typeof(WoodlandBelt),
			typeof(HalfApron),
			typeof(LeatherGorget),
			typeof(PlateGorget),
			typeof(StuddedGorget),
			typeof(ElegantCollar),
			typeof(HideGorget),
			typeof(TigerPeltCollar),
			typeof(WoodlandGorget),
			typeof(LeafGorget),
			typeof(RandomTalisman),
			typeof(Longsword),
			typeof(Broadsword),
			typeof(Cutlass),
			typeof(Katana),
			typeof(Scimitar),
			typeof(VikingSword),
			typeof(Axe),
			typeof(BattleAxe),
			typeof(DoubleAxe),
			typeof(ExecutionersAxe),
			typeof(LargeBattleAxe),
			typeof(TwoHandedAxe),
			typeof(WarAxe),
			typeof(Club),
			typeof(HammerPick),
			typeof(Mace),
			typeof(Maul),
			typeof(WarHammer),
			typeof(WarMace),
			typeof(Bardiche),
			typeof(Halberd),
			typeof(Lance),
			typeof(Pike),
			typeof(ShortSpear),
			typeof(Spear),
			typeof(WarFork),
			typeof(CompositeBow),
			typeof(Crossbow),
			typeof(HeavyCrossbow),
			typeof(RepeatingCrossbow),
			typeof(Bow),
			typeof(Dagger),
			typeof(Kryss),
			typeof(SkinningKnife),
			typeof(Pitchfork),
			typeof(BlackStaff),
			typeof(GnarledStaff),
			typeof(QuarterStaff),
			typeof(ShepherdsCrook),
			typeof(BladedStaff),
			typeof(Scythe),
			typeof(Scepter),
			typeof(MagicWand),
			typeof(AnimalClaws),
			typeof(WrestlingBelt),
			typeof(ArtificerWand),
			typeof(BashingShield),
			typeof(BeggersStick),
			typeof(BoltRod),
			typeof(CampingLanturn),
			typeof(CarpentersHammer),
			typeof(CooksCleaver),
			typeof(DetectivesBoneHarvester),
			typeof(DistractingHammer),
			typeof(ExplorersMachete),
			typeof(FireAlchemyBlaster),
			typeof(FishermansTrident),
			typeof(FletchersBow),
			typeof(FocusKryss),
			typeof(GearLauncher),
			typeof(GourmandsFork),
			typeof(HolyKnightSword),
			typeof(IllegalCrossbow),
			typeof(IntelligenceEvaluator),
			typeof(LoreSword),
			typeof(MageWand),
			typeof(MallKatana),
			typeof(MeatPicks),
			typeof(MeditationFans),
			typeof(MerchantsShotgun),
			typeof(MysticStaff),
			typeof(NecromancersStaff),
			typeof(NinjaBow),
			typeof(Nunchucks),
			typeof(PoisonBlade),
			typeof(RangersCrossbow),
			typeof(ResonantHarp),
			typeof(RevealingAxe),
			typeof(Scalpel),
			typeof(ScribeSword),
			typeof(SewingNeedle),
			typeof(ShadowSai),
			typeof(SilentBlade),
			typeof(SleepAid),
			typeof(SmithSmasher),
			typeof(SnoopersPaddle),
			typeof(SpellWeaversWand),
			typeof(SpiritScepter),
			typeof(TacticalMultitool),
			typeof(TenFootPole),
			typeof(VeterinaryLance),
			typeof(VivisectionKnife),
			typeof(WitchBurningTorch),
			typeof(AssassinSpike),
			typeof(Bokuto),
			typeof(BoneHarvester),
			typeof(BoneMachete),
			typeof(Boomerang),
			typeof(ButcherKnife),
			typeof(Cleaver),
			typeof(CrescentBlade),
			typeof(Cyclone),
			typeof(Daisho),
			typeof(DiamondMace),
			typeof(DiscMace),
			typeof(DoubleBladedStaff),
			typeof(ElvenCompositeLongbow),
			typeof(ElvenMachete),
			typeof(ElvenSpellblade),
			typeof(JukaBow),
			typeof(Kama),
			typeof(Lajatang),
			typeof(Leafblade),
			typeof(MagicalShortbow),
			typeof(NoDachi),
			typeof(Nunchaku),
			typeof(Pickaxe),
			typeof(Tekagi),
			typeof(Tessen),
			typeof(Tetsubo),
			typeof(Wakizashi),
			typeof(WildStaff),
			typeof(Yumi),
			typeof(Shield),
			typeof(Lantern),
			typeof(BronzeShield),
			typeof(Buckler),
			typeof(HeaterShield),
			typeof(MetalKiteShield),
			typeof(MetalShield),
			typeof(OrderShield),
			typeof(ChaosShield),
			typeof(WoodenKiteShield),
			typeof(WoodenShield),
			typeof(Torch),
			typeof(FootStool),
			typeof(BarrelStaves),
			typeof(BarrelLid),
			typeof(Stool),
			typeof(WoodenBox),
			typeof(SmallCrate),
			typeof(MediumCrate),
			typeof(LargeCrate),
			typeof(WoodenChest),
			typeof(EmptyBookcase),
			typeof(WoodenBench),
			typeof(WoodenThrone),
			typeof(TallCabinet),
			typeof(ShortCabinet),
			typeof(RedArmoire),
			typeof(ElegantArmoire),
			typeof(MapleArmoire),
			typeof(CherryArmoire),
			typeof(LapHarp),
			typeof(Lute),
			typeof(Drums),
			typeof(Harp),
			typeof(PlainWoodenChest),
			typeof(OrnateWoodenChest),
			typeof(GildedWoodenChest),
			typeof(WoodenFootLocker),
			typeof(FinishedWoodenChest),
			typeof(SweetCocoaButter),
			typeof(Dough),
			typeof(UnbakedFruitPie),
			typeof(UnbakedPeachCobbler),
			typeof(UnbakedApplePie),
			typeof(UnbakedPumpkinPie),
			typeof(Cookies),
			typeof(ThreeTieredCake),
			typeof(MisoSoup),
			typeof(WhiteMisoSoup),
			typeof(RedMisoSoup),
			typeof(AwaseMisoSoup),
			typeof(WasabiClumps),
			typeof(SushiRolls),
			typeof(SushiPlatter),
			typeof(GreenTea),
			typeof(SweetDough),
			typeof(CakeMix),
			typeof(CookieMix),
			typeof(UnbakedQuiche),
			typeof(UnbakedMeatPie),
			typeof(UncookedSausagePizza),
			typeof(UncookedCheesePizza),
			typeof(Quiche),
			typeof(MeatPie),
			typeof(SausagePizza),
			typeof(CheesePizza),
			typeof(FruitPie),
			typeof(PeachCobbler),
			typeof(PumpkinPie),
			typeof(EnchantedApple),
			typeof(TribalPaint),
			typeof(GrapesOfWrath),
			typeof(EggBomb),
			typeof(FishSteak),
			typeof(FriedEggs),
			typeof(Ribs),
			typeof(Arrow),
			typeof(Bolt),
			typeof(Kindling),
			typeof(Shaft),
			typeof(ReactiveArmorScroll),
			typeof(ClumsyScroll),
			typeof(CreateFoodScroll),
			typeof(FeeblemindScroll),
			typeof(HealScroll),
			typeof(MagicArrowScroll),
			typeof(NightSightScroll),
			typeof(WeakenScroll),
			typeof(AgilityScroll),
			typeof(CunningScroll),
			typeof(CureScroll),
			typeof(HarmScroll),
			typeof(MagicTrapScroll),
			typeof(ProtectionScroll),
			typeof(StrengthScroll),
			typeof(BlessScroll),
			typeof(FireballScroll),
			typeof(MagicLockScroll),
			typeof(PoisonScroll),
			typeof(TelekinisisScroll),
			typeof(TeleportScroll),
			typeof(UnlockScroll),
			typeof(WallOfStoneScroll),
			typeof(ArchCureScroll),
			typeof(ArchProtectionScroll),
			typeof(CurseScroll),
			typeof(FireFieldScroll),
			typeof(GreaterHealScroll),
			typeof(LightningScroll),
			typeof(ManaDrainScroll),
			typeof(RecallScroll),
			typeof(BladeSpiritsScroll),
			typeof(DispelFieldScroll),
			typeof(IncognitoScroll),
			typeof(MagicReflectScroll),
			typeof(MindBlastScroll),
			typeof(ParalyzeScroll),
			typeof(PoisonFieldScroll),
			typeof(SummonCreatureScroll),
			typeof(DispelScroll),
			typeof(EnergyBoltScroll),
			typeof(ExplosionScroll),
			typeof(InvisibilityScroll),
			typeof(MarkScroll),
			typeof(MassCurseScroll),
			typeof(ParalyzeFieldScroll),
			typeof(RevealScroll),
			typeof(ChainLightningScroll),
			typeof(EnergyFieldScroll),
			typeof(GateTravelScroll),
			typeof(ManaVampireScroll),
			typeof(MassDispelScroll),
			typeof(MeteorSwarmScroll),
			typeof(PolymorphScroll),
			typeof(EarthquakeScroll),
			typeof(EnergyVortexScroll),
			typeof(ResurrectionScroll),
			typeof(SummonAirElementalScroll),
			typeof(SummonDaemonScroll),
			typeof(SummonEarthElementalScroll),
			typeof(SummonFireElementalScroll),
			typeof(SummonWaterElementalScroll),
			typeof(AnimateDeadScroll),
			typeof(BloodOathScroll),
			typeof(CorpseSkinScroll),
			typeof(CurseWeaponScroll),
			typeof(EvilOmenScroll),
			typeof(HorrificBeastScroll),
			typeof(LichFormScroll),
			typeof(MindRotScroll),
			typeof(PainSpikeScroll),
			typeof(PoisonStrikeScroll),
			typeof(StrangleScroll),
			typeof(SummonFamiliarScroll),
			typeof(VampiricEmbraceScroll),
			typeof(VengefulSpiritScroll),
			typeof(WitherScroll),
			typeof(WraithFormScroll),
			typeof(Spellbook),
			typeof(NecromancerSpellbook),
			typeof(Runebook),
			typeof(RunicAtlas),
			typeof(KeyRing),
			typeof(Key),
			typeof(Globe),
			typeof(Spyglass),
			typeof(BarrelTap),
			typeof(BarrelHoops),
			typeof(SmithyHammer),
			typeof(Skillet),
			typeof(SewingKit),
			typeof(FletcherTools),
			typeof(SpoonLeft),
			typeof(ForkLeft),
			typeof(Plate),
			typeof(KnifeLeft),
			typeof(Goblet),
			typeof(PewterMug),
			typeof(Clippers),
			typeof(Tongs),
			typeof(SledgeHammer),
			typeof(Saw),
			typeof(Froe),
			typeof(FlourSifter),
			typeof(JointingPlane),
			typeof(MouldingPlane),
			typeof(SmoothingPlane),
			typeof(Hatchet),
			typeof(Candelabra),
			typeof(Scales),
			typeof(Gears),
			typeof(Axle),
			typeof(Springs),
			typeof(AxleGears),
			typeof(ClockParts),
			typeof(Clock),
			typeof(PotionKeg),
			typeof(ClockFrame),
			typeof(MetalContainerEngraver),
			typeof(Hinge),
			typeof(SextantParts),
			typeof(RodOfOrcControl),
			typeof(Beeswax),
			typeof(WoodenBowlOfCarrots),
			typeof(WoodenBowlOfCorn),
			typeof(WoodenBowlOfLettuce),
			typeof(WoodenBowlOfPeas),
			typeof(EmptyPewterBowl),
			typeof(PewterBowlOfCorn),
			typeof(PewterBowlOfLettuce),
			typeof(PewterBowlOfPeas),
			typeof(PewterBowlOfPotatos),
			typeof(WoodenBowlOfStew),
			typeof(WoodenBowlOfTomatoSoup),
			typeof(Chessboard),
			typeof(CheckerBoard),
			typeof(Backgammon),
			typeof(Dices),
			typeof(ContractOfEmployment),
			typeof(BarkeepContract),
			typeof(VendorRentalContract),
			typeof(Wasabi),
			typeof(BentoBox),
			typeof(GreenTeaBasket),
			typeof(MaxxiaScroll),
			typeof(HeritageSovereign),
			typeof(GenderChangeDeed),
			typeof(MurderRemovalDeed),
			typeof(ClothingBlessDeed),
			typeof(AdventurersContract),
			typeof(TradeRouteContract),
			typeof(HeritageToken),
			typeof(FrenchBread),
			typeof(BowlFlour),
			typeof(DestroyingAngel),
			typeof(SpringWater),
			typeof(PetrafiedWood),
			typeof(HeatingStand),
			typeof(SkinTingeingTincture),
			typeof(TransmutationCauldron),
			typeof(GlassblowingBook),
			typeof(SandMiningBook),
			typeof(Blowpipe),
			typeof(Zychroline),
			typeof(Aetheralate),
			typeof(Neontrium),
			typeof(Oblivionate),
			typeof(Phantomide),
			typeof(Quarkothene),
			typeof(Stygiocarbon),
			typeof(Cryovitrin),
			typeof(Fluxidate),
			typeof(Novaesine),
			typeof(Xenocrylate),
			typeof(Gravitoxane),
			typeof(Eclipsium),
			typeof(Darkspirite),
			typeof(Photoplasmene),
			typeof(Vibranide),
			typeof(Duskenium),
			typeof(Chronodyne),
			typeof(Auroracene),
			typeof(Voidanate),
			typeof(Lumicryne),
			typeof(Prismalium),
			typeof(Etherothal),
			typeof(Pyrolythene),
			typeof(Radiacrylate),
			typeof(Synthionide),
			typeof(Morphaloxane),
			typeof(Astrocyne),
			typeof(Nyxiolate),
			typeof(Spectrovanate),
			typeof(Solvexium),
			typeof(Helionine),
			typeof(Thermodrithium),
			typeof(Arcvaloxate),
			typeof(Cinderathane),
			typeof(Zephyrenium),
			typeof(Kryotoxite),
			typeof(Starshardine),
			typeof(Omniplasium),
			typeof(Nebulifluxate),
			typeof(GraveNylon),
			typeof(Aeroglass),
			typeof(Infinityclay),
			typeof(Bloodglass),
			typeof(DenaturedMorphonite),
			typeof(Energite),
			typeof(FlammablePlasmine),
			typeof(Impervanium),
			typeof(NegativePhocite),
			typeof(OpaqueHydragyon),
			typeof(PositiveEvenium),
			typeof(RefractivePotamite),
			typeof(Schizonite),
			typeof(Thoril),
			typeof(TransparentAurarus),
			typeof(Turbesium),
			typeof(Uranimite),
			typeof(ChargedAcoustesium),
			typeof(ExoticEun),
			typeof(Fibrogen),
			typeof(Flurocite),
			typeof(GaseousAesthogen),
			typeof(HighdensityElectron),
			typeof(MorphicHeteril),
			typeof(Negite),
			typeof(GardeningContract),
			typeof(FishingPole),
			typeof(AquariumFishNet),
			typeof(AquariumFood),
			typeof(FishBowl),
			typeof(VacationWafer),
			typeof(AquariumNorthDeed),
			typeof(AquariumEastDeed),
			typeof(NewAquariumBook),
			typeof(FreshGinger),
			typeof(Pitcher),
			typeof(Hoe),
			typeof(BlackberrySeed),
			typeof(BlackRaspberrySeed),
			typeof(BlueberrySeed),
			typeof(CranberrySeed),
			typeof(PineappleSeed),
			typeof(RedRaspberrySeed),
			typeof(BlackRoseSeed),
			typeof(DandelionSeed),
			typeof(IrishRoseSeed),
			typeof(PansySeed),
			typeof(PinkCarnationSeed),
			typeof(PoppySeed),
			typeof(RedRoseSeed),
			typeof(SnapdragonSeed),
			typeof(SpiritRoseSeed),
			typeof(WhiteRoseSeed),
			typeof(YellowRoseSeed),
			typeof(CottonSeed),
			typeof(FlaxSeed),
			typeof(HaySeed),
			typeof(OatsSeed),
			typeof(RiceSeed),
			typeof(SugarcaneSeed),
			typeof(WheatSeed),
			typeof(GarlicSeed),
			typeof(TanGingerSeed),
			typeof(GinsengSeed),
			typeof(MandrakeSeed),
			typeof(NightshadeSeed),
			typeof(RedMushroomSeed),
			typeof(TanMushroomSeed),
			typeof(BitterHopsSeed),
			typeof(ElvenHopsSeed),
			typeof(SnowHopsSeed),
			typeof(SweetHopsSeed),
			typeof(CornSeed),
			typeof(FieldCornSeed),
			typeof(SunFlowerSeed),
			typeof(TeaSeed),
			typeof(BananaSeed),
			typeof(CoconutSeed),
			typeof(DateSeed),
			typeof(MiniAlmondSeed),
			typeof(MiniAppleSeed),
			typeof(MiniApricotSeed),
			typeof(MiniAvocadoSeed),
			typeof(MiniCherrySeed),
			typeof(MiniCocoaSeed),
			typeof(MiniCoffeeSeed),
			typeof(MiniGrapefruitSeed),
			typeof(MiniKiwiSeed),
			typeof(MiniMangoSeed),
			typeof(MiniOrangeSeed),
			typeof(MiniPeachSeed),
			typeof(MiniPearSeed),
			typeof(MiniPistacioSeed),
			typeof(MiniPomegranateSeed),
			typeof(SmallBananaSeed),
			typeof(AsparagusSeed),
			typeof(BeetSeed),
			typeof(BroccoliSeed),
			typeof(CabbageSeed),
			typeof(CarrotSeed),
			typeof(CauliflowerSeed),
			typeof(CelerySeed),
			typeof(EggplantSeed),
			typeof(GreenBeanSeed),
			typeof(LettuceSeed),
			typeof(OnionSeed),
			typeof(PeanutSeed),
			typeof(PeasSeed),
			typeof(PotatoSeed),
			typeof(RadishSeed),
			typeof(SnowPeasSeed),
			typeof(SoySeed),
			typeof(SpinachSeed),
			typeof(StrawberrySeed),
			typeof(SweetPotatoSeed),
			typeof(TurnipSeed),
			typeof(ChiliPepperSeed),
			typeof(CucumberSeed),
			typeof(GreenPepperSeed),
			typeof(OrangePepperSeed),
			typeof(RedPepperSeed),
			typeof(TomatoSeed),
			typeof(YellowPepperSeed),
			typeof(CantaloupeSeed),
			typeof(GreenSquashSeed),
			typeof(HoneydewMelonSeed),
			typeof(PumpkinSeed),
			typeof(SquashSeed),
			typeof(WatermelonSeed),
			typeof(AppleSeed),
			typeof(BananaTreeSeed),
			typeof(CantaloupeVineSeed),
			typeof(CoconutTreeSeed),
			typeof(DateTreeSeed),
			typeof(GrapeSeed),
			typeof(LemonSeed),
			typeof(LimeSeed),
			typeof(PeachSeed),
			typeof(PearSeed),
			typeof(SquashVineSeed),
			typeof(WatermelonVineSeed),
			typeof(BuildersHammer),
			typeof(CheeseAgingBarrel),
			typeof(PeaceableWoodenFence),
			typeof(MarijuanaSeeds),
			typeof(TaintedSeeds),
			typeof(SilverSaplingSeed),
			typeof(SeedOfLife),
			typeof(SeedOfRenewal),
			typeof(BeetleFeeder),
			typeof(BirdFeeder),
			typeof(BoarFeeder),
			typeof(BullFeeder),
			typeof(BullFrogFeeder),
			typeof(CatFeeder),
			typeof(CowFeeder),
			typeof(DesertOstardFeeder),
			typeof(DogFeeder),
			typeof(DolphinFeeder),
			typeof(ForestOstardFeeder),
			typeof(GamanFeeder),
			typeof(GiantToadFeeder),
			typeof(GoatFeeder),
			typeof(GorillaFeeder),
			typeof(GreatHartFeeder),
			typeof(HindFeeder),
			typeof(HiryuFeeder),
			typeof(HorseFeeder),
			typeof(KirinFeeder),
			typeof(LlamaFeeder),
			typeof(OstardFeeder),
			typeof(PigFeeder),
			typeof(RabbitFeeder),
			typeof(RatFeeder),
			typeof(RidgebackFeeder),
			typeof(SheepFeeder),
			typeof(SwampDragonFeeder),
			typeof(UnicornFeeder),
			typeof(WalrusFeeder),
			typeof(RaisedGardenDeed),
			typeof(SeedBox),
			typeof(AbyssChivesFruit),
			typeof(aggearangFruit),
			typeof(agleatainFruit),
			typeof(ameoyoteFruit),
			typeof(AngelRootFruit),
			typeof(AngelTurnipFruit),
			typeof(ArcticParsnipFruit),
			typeof(AshLycheeFruit),
			typeof(AshRootFruit),
			typeof(AutumnCherryFruit),
			typeof(AutumnPomegranateFruit),
			typeof(BitterDurianFruit),
			typeof(BittersweetChivesFruit),
			typeof(BlackChoyFruit),
			typeof(blattiovesFruit),
			typeof(blearelFruit),
			typeof(BlumbFruit),
			typeof(bosheaShootFruit),
			typeof(brafulalFruit),
			typeof(brongerFruit),
			typeof(BushCerimanFruit),
			typeof(BushSpinachFruit),
			typeof(CandyMorindaFruit),
			typeof(CaveAsparagusFruit),
			typeof(CavePersimmonFruit),
			typeof(CavernMangosteenFruit),
			typeof(chigionutFruit),
			typeof(chummionachFruit),
			typeof(ciarryFruit),
			typeof(CinderGingerFruit),
			typeof(CliffNectarineFruit),
			typeof(crennealeryFruit),
			typeof(criarianFruit),
			typeof(darantFruit),
			typeof(DaydreamPommeracFruit),
			typeof(DesertPlumFruit),
			typeof(DesertRowanFruit),
			typeof(DessertBroccoliFruit),
			typeof(DessertTomatoFruit),
			typeof(DewKiwiFruit),
			typeof(DewPawpawFruit),
			typeof(dimquatFruit),
			typeof(diowanFruit),
			typeof(DragoLimeFruit),
			typeof(DrakeLentilFruit),
			typeof(DrakeMangoFruit),
			typeof(eacketFruit),
			typeof(eacotFruit),
			typeof(earolaFruit),
			typeof(EasternBacuriFruit),
			typeof(eawanFruit),
			typeof(echocadoFruit),
			typeof(ElephantBreadnutFruit),
			typeof(EmberLaurelFruit),
			typeof(EmberLettuceFruit),
			typeof(FalseAlmondFruit),
			typeof(fliavesFruit),
			typeof(FluxxFruit),
			typeof(fucrucotFruit),
			typeof(fudishFruit),
			typeof(fushewFruit),
			typeof(geweodineFruit),
			typeof(gigliachokeFruit),
			typeof(girinFruit),
			typeof(glissidillaFruit),
			typeof(GoldenRocketFruit),
			typeof(grandaFruit),
			typeof(gropioveFruit),
			typeof(GroundPearFruit),
			typeof(grutatoFruit),
			typeof(HairyTomatoFruit),
			typeof(HateCalamansiFruit),
			typeof(HazelLimeFruit),
			typeof(hialoupeFruit),
			typeof(hiorolaFruit),
			typeof(iaconaFruit),
			typeof(IceRocketFruit),
			typeof(iddiochokeFruit),
			typeof(imberFruit),
			typeof(ingeFruit),
			typeof(intineFruit),
			typeof(ippiocressFruit),
			typeof(ittianaFruit),
			typeof(jeorraFruit),
			typeof(jigreapawFruit),
			typeof(jochiniFruit),
			typeof(kledamiaFruit),
			typeof(kleopeFruit),
			typeof(kraccaleryFruit),
			typeof(krevaFruit),
			typeof(LillypillyFruit),
			typeof(LoveKumquatFruit),
			typeof(LoveZucchiniFruit),
			typeof(MageCherryFruit),
			typeof(MageDateFruit),
			typeof(MellowGourdFruit),
			typeof(MoonPumpkinFruit),
			typeof(moyiarlanFruit),
			typeof(MutantLemonFruit),
			typeof(MysteryFruit),
			typeof(MysteryGuavaFruit),
			typeof(MysteryOrangeFruit),
			typeof(NativeRambutanFruit),
			typeof(NightCabbageFruit),
			typeof(NightmareSaguaroFruit),
			typeof(ocanateFruit),
			typeof(OceanMuscadineFruit),
			typeof(omondFruit),
			typeof(otilFruit),
			typeof(PeaceAmaranthFruit),
			typeof(PeaceDateFruit),
			typeof(PeaceNectarineFruit),
			typeof(phecceayoteFruit),
			typeof(piokinFruit),
			typeof(probbacheeFruit),
			typeof(puchiniFruit),
			typeof(PygmyOrangeFruit),
			typeof(qekliatilloFruit),
			typeof(RainLaurelFruit),
			typeof(RainPommeracFruit),
			typeof(rephoneFruit),
			typeof(satilFruit),
			typeof(siheonachFruit),
			typeof(SilverFruit),
			typeof(slirindFruit),
			typeof(slomeloFruit),
			typeof(SmellyCarrotFruit),
			typeof(SourAmaranthFruit),
			typeof(StormBrambleFruit),
			typeof(striachiniFruit),
			typeof(strondaFruit),
			typeof(SwampNectarineFruit),
			typeof(SweetBoquilaFruit),
			typeof(TigerBeanFruit),
			typeof(TropicalCherryFruit),
			typeof(unaFruit),
			typeof(uyerdFruit),
			typeof(veapeFruit),
			typeof(VoidBrambleFruit),
			typeof(VoidOkraFruit),
			typeof(VoidPulasanFruit),
			typeof(VoidSproutFruit),
			typeof(vrecequilaFruit),
			typeof(vropperrotFruit),
			typeof(vuveFruit),
			typeof(WinterCoconutFruit),
			typeof(WonderRambutanFruit),
			typeof(wriggumondFruit),
			typeof(XeenBerryFruit),
			typeof(xekraFruit),
			typeof(xemeloFruit),
			typeof(zanioperFruit),
			typeof(ziongerFruit),			
			typeof(Bottle)
        };

        private static readonly Type[] DefaultRewardPool =
            QuestScrollRewards.m_Rewards;

        // --- ❷ state ---------------------------------------------------------

        private Type                          _targetItem;
        private int                           _amountNeeded;
        private int                           _amountCollected;
        private int                           _repReward;
        private XmlMobFactions.GroupTypes    _faction;
        private List<Type>                   _rewardTypes;

        // --- ❸ properties (GM-tweakable) -------------------------------------

        [CommandProperty(AccessLevel.GameMaster)]
        public string TargetItemName => _targetItem?.Name ?? "undefined";

        [CommandProperty(AccessLevel.GameMaster)]
        public int AmountNeeded      { get => _amountNeeded;     set => _amountNeeded     = Math.Max(1, value); }
        [CommandProperty(AccessLevel.GameMaster)]
        public int AmountCollected   { get => _amountCollected;  set => _amountCollected = Math.Max(0, value); }

        [CommandProperty(AccessLevel.GameMaster)]
        public XmlMobFactions.GroupTypes Faction
        {
            get => _faction;
            set => _faction = value;
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RepReward
        {
            get => _repReward;
            set => _repReward = Math.Max(0, value);
        }

        // --- ❹ constructors ---------------------------------------------------

        [Constructable]
        public FactionCollectionQuestScroll()
            : this(null, 0, XmlMobFactions.GroupTypes.Player, 0, new Type[0])
        {
        }

		// ❹a overload for XML loader: (itemName, amount, factionName, repReward)
		[Constructable]
		public FactionCollectionQuestScroll(string itemName, int amountNeeded, string factionName, int repReward)
			: this(
				LookupTargetType(itemName),
				amountNeeded,
				ParseFaction(factionName),
				repReward,
				new Type[0]
			  )
		{
			// ensure the display name matches what was in XML
			Name = $"Collection Quest: bring {amountNeeded} {itemName}";
		}

		// helper to turn "TrialOfStrength" into the enum, defaulting to Player
		private static XmlMobFactions.GroupTypes ParseFaction(string s)
		{
			if (Enum.TryParse<XmlMobFactions.GroupTypes>(s, true, out var f))
				return f;

			return XmlMobFactions.GroupTypes.Player;
		}


        // --- ❹a 4-parameter convenience ctor ------------------------------

        [Constructable]
        public FactionCollectionQuestScroll(
            string                     itemName,
            int                        amountNeeded,
            XmlMobFactions.GroupTypes  faction,
            int                        repReward
        )
            : this(
                LookupTargetType(itemName),  // resolve any item type by name
                amountNeeded,
                faction,
                repReward,
                new Type[0]                  // let rewards be random
              )
        {
            // Override the display name to exactly reflect what was passed in:
            Name = $"Collection Quest: bring {amountNeeded} {itemName}";
        }

        // --- helper to resolve ANY Item-derived Type by simple name ---------
        private static Type LookupTargetType(string name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                // 1) try fully-qualified lookup, e.g. "Server.Items.Cotton"
                var fullName = $"Server.Items.{name}";
                var t = Type.GetType(fullName, false, true);

                // 2) if not found, scan all loaded assemblies for a matching simple name
                if (t == null)
                {
                    t = AppDomain.CurrentDomain
                                 .GetAssemblies()
                                 .SelectMany(a => a.GetTypesSafe())
                                 .FirstOrDefault(x =>
                                     x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                                     && typeof(Item).IsAssignableFrom(x));
                }

                if (t != null)
                    return t;
            }

            // 3) fallback: random pick from your default pool
            return DefaultChallengePool[Utility.Random(DefaultChallengePool.Length)];
        }


        [Constructable]
        public FactionCollectionQuestScroll(
            Type                           customTarget    = null,
            int                            customAmount    = 0,
            XmlMobFactions.GroupTypes      faction         = XmlMobFactions.GroupTypes.Player,
            int                            customRep       = 0,
            params Type[]                  customRewards)
            : base(0x14EF) // looks like a parchment scroll
        {
            Weight         = 1.0;
            LootType       = LootType.Blessed;
            Hue            = 0x4B5;

            _targetItem    = customTarget ?? PickRandom(DefaultChallengePool);
            _amountNeeded  = (customAmount > 0) ? customAmount : Utility.RandomMinMax(10, 25);
            _faction       = faction;
            _repReward     = (customRep   > 0) ? customRep   : _amountNeeded * 50;

            _rewardTypes   = (customRewards != null && customRewards.Length > 0)
                             ? customRewards.ToList()
                             : PickRandomRewardTypes();

            Name = $"Collection Quest: bring {_amountNeeded} {_targetItem.Name}";
        }

        private static Type PickRandom(Type[] pool) => pool[Utility.Random(pool.Length)];

        private static List<Type> PickRandomRewardTypes()
        {
            int count = Utility.RandomMinMax(1, 4);
            return DefaultRewardPool.OrderBy(t => Utility.Random(10000)).Take(count).ToList();
        }

        // --- helper: safely give faction rep ----------------------------------

        private static void GiveFactionRep(Mobile player, XmlMobFactions.GroupTypes faction, int amount)
        {
            if (amount <= 0) return;

            var x = XmlAttach.FindAttachment(player, typeof(XmlMobFactions), "Standard") as XmlMobFactions;
            if (x == null)
            {
                x = new XmlMobFactions();
                XmlAttach.AttachTo(player, player, x);
            }

            int current = x.GetFactionLevel(faction);
            x.SetFactionLevel(faction, current + amount);
            player.SendMessage($"You gain {amount} reputation with {faction}!");
        }

        // --- ❺ double-click interaction --------------------------------------

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1047012); // must be in backpack
                return;
            }

            from.SendGump(new CollectionQuestGump(from, this));
        }

        // --- ❻ gump -----------------------------------------------------------

        private class CollectionQuestGump : Gump
        {
            private readonly FactionCollectionQuestScroll _scroll;

            public CollectionQuestGump(Mobile from, FactionCollectionQuestScroll scroll) : base(75, 50)
            {
                _scroll = scroll;

                int rewardLines = _scroll._rewardTypes.Count;
                int height = 160 + (rewardLines * 25);

                AddPage(0);
                AddBackground(0, 0, 300, height, 9270);

                AddLabel(40, 20, 88, "Collection Quest");

                int y = 50;
                AddLabel(40, y, 54, $"Need: {_scroll._amountNeeded} {_scroll._targetItem.Name}"); y += 20;
                AddLabel(40, y, 54, $"Have: {_scroll._amountCollected}");                 y += 20;
                AddLabel(40, y, 54, $"Faction Rep: {_scroll._repReward} ({_scroll._faction})"); y += 20;

                AddLabel(40, y, 54, "Items:");                                             y += 20;
                foreach (var reward in _scroll._rewardTypes)
                {
                    AddLabel(60, y, 54, reward.Name);
                    y += 20;
                }

                if (_scroll._amountCollected < _scroll._amountNeeded)
                {
                    AddButton(40, y, 4005, 4007, 1, GumpButtonType.Reply, 0);
                    AddLabel(75, y, 58, "Add Item");
                }
                else
                {
                    AddButton(40, y, 4005, 4007, 2, GumpButtonType.Reply, 0);
                    AddLabel(75, y, 54, "Claim Reward");
                }
            }

            public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
            {
                Mobile from = sender.Mobile;
                switch (info.ButtonID)
                {
                    case 1: // add item
                        from.SendMessage("Target the required item in your backpack.");
                        from.Target = new CollectionQuestTarget(_scroll);
                        break;
                    case 2: // claim reward
                        _scroll.TryClaim(from);
                        break;
                }
            }
        }

        // --- ❼ targeting logic -----------------------------------------------

        private class CollectionQuestTarget : Target
        {
            private readonly FactionCollectionQuestScroll _scroll;

            public CollectionQuestTarget(FactionCollectionQuestScroll scroll)
                : base(1, false, TargetFlags.None)
            {
                _scroll = scroll;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Item item &&
                    item.IsChildOf(from.Backpack) &&
                    item.GetType() == _scroll._targetItem)
                {
                    int amount = item.Stackable ? item.Amount : 1;
                    int needed = _scroll._amountNeeded - _scroll._amountCollected;

                    if (amount > needed)
                    {
                        item.Amount -= needed;
                        amount = needed;
                    }
                    else
                    {
                        item.Delete();
                    }

                    _scroll._amountCollected += amount;

                    if (_scroll._amountCollected >= _scroll._amountNeeded)
                        from.SendMessage("All items collected! Double-click the scroll to claim your reward.");
                    else
                        from.Target = new CollectionQuestTarget(_scroll);
                }
                else
                {
                    from.SendMessage("That isn’t the required item (or it isn’t in your pack).");
                }
            }
        }

        // --- ❽ reward logic ---------------------------------------------------

        private void TryClaim(Mobile from)
        {
            if (_amountCollected < _amountNeeded)
            {
                from.SendMessage("You haven’t finished the collection yet.");
                return;
            }

            // award faction reputation
            GiveFactionRep(from, _faction, _repReward);

            // award item rewards
            foreach (Type t in _rewardTypes)
                if (Activator.CreateInstance(t) is Item reward)
                    from.AddToBackpack(reward);

            from.SendMessage("Your rewards have been placed in your backpack!");
            Delete();
        }

        // --- ❾ persistence ----------------------------------------------------

        public FactionCollectionQuestScroll(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version

            writer.Write(_targetItem?.AssemblyQualifiedName ?? "");
            writer.Write(_amountNeeded);
            writer.Write(_amountCollected);
            writer.Write(_repReward);
            writer.Write((int)_faction);

            writer.Write(_rewardTypes.Count);
            foreach (Type t in _rewardTypes)
                writer.Write(t.AssemblyQualifiedName);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            _targetItem      = Type.GetType(reader.ReadString());
            _amountNeeded    = reader.ReadInt();
            _amountCollected = reader.ReadInt();

            if (version >= 1)
            {
                _repReward = reader.ReadInt();
                _faction   = (XmlMobFactions.GroupTypes)reader.ReadInt();
            }
            else
            {
                // backwards‐compat: old gold reward becomes rep, default to Player
                int oldGold = reader.ReadInt();
                _repReward = oldGold;
                _faction   = XmlMobFactions.GroupTypes.Player;
            }

            int count = reader.ReadInt();
            _rewardTypes = new List<Type>();
            for (int i = 0; i < count; i++)
            {
                Type t = Type.GetType(reader.ReadString());
                if (t != null) _rewardTypes.Add(t);
            }
        }
    }
}
