using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;           // SkillName
using Server.Engines.XmlSpawner2;     // XmlAttach, XmlAttachment

namespace Server.Items
{
    public class UnidentifiedClothing : BaseUnidentifiedItem
    {
        // ---------- STATIC LOOT TABLES (high‑tier clothing) ----------
        private static readonly Type[] Tier8Items =
        {
            typeof(CourtesansGracefulKimono),
            typeof(LorekeepersSash),
            typeof(AdventurersBoots),
            typeof(AerobicsInstructorsLegwarmers),
            typeof(AmbassadorsCloak),
            typeof(AnglersSeabreezeCloak),
            typeof(ArchivistsShoes),
            typeof(ArrowsmithsSturdyBoots),
            typeof(ArtisansTimberShoes),
            typeof(AssassinsBandana),
            typeof(AssassinsMaskedCap),
            typeof(BaggyHipHopPants),
            typeof(BakersSoftShoes),
            typeof(BalladeersMuffler),
            typeof(BanditsHiddenCloak),
            typeof(BardOfErinsMuffler),
            typeof(BardsTunicOfStonehenge),
            typeof(BaristasMuffler),
            typeof(BeastmastersTanic),
            typeof(BeastmastersTonic),
            typeof(BeastmastersTunic),
            typeof(BeastmiastersTunic),
            typeof(BeatniksBeret),
            typeof(BeggarsLuckyBandana),
            typeof(BlacksmithsReinforcedGloves),
            typeof(BobbySoxersShoes),
            typeof(BohoChicSundress),
            typeof(BootsOfTheDeepCaverns),
            typeof(BowcraftersProtectiveCloak),
            typeof(BowyersInsightfulBandana),
            typeof(BreakdancersCap),
            typeof(CarpentersStalwartTunic),
            typeof(CartographersExploratoryTunic),
            typeof(CartographersHat),
            typeof(CeltidDruidsRobe),
            typeof(ChampagneToastTunic),
            typeof(ChefsGourmetApron),
            typeof(ClericsSacredSash),
            typeof(CourtesansGracefulKimono),
            typeof(CourtisansRefinedGown),
            typeof(CouturiersSundress),
            typeof(CraftsmansProtectiveGloves),
            typeof(CropTopMystic),
            typeof(CuratorsKilt),
            typeof(CyberpunkNinjaTabi),
            typeof(DancersEnchantedSkirt),
            typeof(DapperFedoraOfInsight),
            typeof(DarkLordsRobe),
            typeof(DataMagesDigitalCloak),
            typeof(DeepSeaTunic),
            typeof(DenimJacketOfReflection),
            typeof(DiplomatsTunic),
            typeof(DiscoDivaBoots),
            typeof(ElementalistsProtectiveCloak),
            typeof(ElvenSnowBoots),
            typeof(EmoSceneHairpin),
            typeof(ExplorersBoots),
            typeof(FilmNoirDetectivesTrenchCoat),
            typeof(FishermansSunHat),
            typeof(FishermansVest),
            typeof(FishmongersKilt),
            typeof(FletchersPrecisionGloves),
            typeof(FlowerChildSundress),
            typeof(ForestersTunic),
            typeof(ForgeMastersBoots),
            typeof(GazeCapturingVeil),
            typeof(GeishasGracefulKasa),
            typeof(GhostlyShroud),
            typeof(GlamRockersJacket),
            typeof(GlovesOfStonemasonry),
            typeof(GoGoBootsOfAgility),
            typeof(GrapplersTunic),
            typeof(GreenwichMagesRobe),
            typeof(GroovyBellBottomPants),
            typeof(GrungeBandana),
            typeof(HackersVRGoggles),
            typeof(HammerlordsCap),
            typeof(HarmonistsSoftShoes),
            typeof(HealersBlessedSandals),
            typeof(HealersFurCape),
            typeof(HelmetOfTheOreWhisperer),
            typeof(HerbalistsProtectiveHat),
            typeof(HerdersMuffler),
            typeof(HippiePeaceBandana),
            typeof(HippiesPeacefulSandals),
            typeof(IntriguersFeatheredHat),
            typeof(JazzMusiciansMuffler),
            typeof(KnightsHelmOfTheRoundTable),
            typeof(LeprechaunsLuckyHat),
            typeof(LorekeepersSash),
            typeof(LuchadorsMask),
            typeof(MapmakersInsightfulMuffler),
            typeof(MarinersLuckyBoots),
            typeof(MelodiousMuffler),
            typeof(MendersDivineRobe),
            typeof(MidnightRevelersBoots),
            typeof(MinersSturdyBoots),
            typeof(MinstrelsTunedTunic),
            typeof(MistletoeMuffler),
            typeof(ModStyleTunic),
            typeof(MoltenCloak),
            typeof(MonksMeditativeRobe),
            typeof(MummysWrappings),
            typeof(MysticsFeatheredHat),
            typeof(NaturalistsCloak),
            typeof(NaturesMuffler),
            typeof(NavigatorsProtectiveCap),
            typeof(NecromancersCape),
            typeof(NeonStreetSash),
            typeof(NewWaveNeonShades),
            typeof(NinjasKasa),
            typeof(NinjasStealthyTabi),
            typeof(OreSeekersBandana),
            typeof(PickpocketsNimbleGloves),
            typeof(PickpocketsSleekTunic),
            typeof(PinUpHalterDress),
            typeof(PlatformSneakers),
            typeof(PoodleSkirtOfCharm),
            typeof(PopStarsFingerlessGloves),
            typeof(PopStarsGlitteringCap),
            typeof(PopStarsSparklingBandana),
            typeof(PreserversCap),
            typeof(PsychedelicTieDyeShirt),
            typeof(PsychedelicWizardsHat),
            typeof(PumpkinKingsCrown),
            typeof(QuivermastersTunic),
            typeof(RangersCap),
            typeof(RangersHat),
            typeof(RangersHatNightSight),
            typeof(ReindeerFurCap),
            typeof(ResolutionKeepersSash),
            typeof(RingmastersSandals),
            typeof(RockabillyRebelJacket),
            typeof(RoguesDeceptiveMask),
            typeof(RoguesShadowCloak),
            typeof(RoyalGuardsBoots),
            typeof(SamuraisHonorableTunic),
            typeof(SantasEnchantedRobe),
            typeof(SawyersMightyApron),
            typeof(ScholarsRobe),
            typeof(ScoutsWideBrimHat),
            typeof(ScribersRobe),
            typeof(ScribesEnlightenedSandals),
            typeof(ScriptoriumMastersRobe),
            typeof(SeductressSilkenShoes),
            typeof(SeersMysticSash),
            typeof(ShadowWalkersTabi),
            typeof(ShanachiesStorytellingShoes),
            typeof(ShepherdsKilt),
            typeof(SherlocksSleuthingCap),
            typeof(ShogunsAuthoritativeSurcoat),
            typeof(SilentNightCloak),
            typeof(SkatersBaggyPants),
            typeof(SmithsProtectiveTunic),
            typeof(SneaksSilentShoes),
            typeof(SnoopersSoftGloves),
            typeof(SommelierBodySash),
            typeof(SorceressMidnightRobe),
            typeof(SpellweaversEnchantedShoes),
            typeof(StarletsFancyDress),
            typeof(StarlightWizardsHat),
            typeof(StarlightWozardsHat),
            typeof(StreetArtistsBaggyPants),
            typeof(StreetPerformersCap),
            typeof(SubmissionsArtistsMuffler),
            typeof(SurgeonsInsightfulMask),
            typeof(SwingsDancersShoes),
            typeof(TailorsFancyApron),
            typeof(TamersKilt),
            typeof(TamersMuffler),
            typeof(TechGurusGlasses),
            typeof(TechnomancersHoodie),
            typeof(ThiefsShadowTunic),
            typeof(ThiefsSilentShoes),
            typeof(TidecallersSandals),
            typeof(TruckersIconicCap),
            typeof(UrbanitesSneakers),
            typeof(VampiresMidnightCloak),
            typeof(VestOfTheVeinSeeker),
            typeof(WarHeronsCap),
            typeof(WarriorOfUlstersTunic),
            typeof(WarriorsBelt),
            typeof(WhisperersBoots),
            typeof(WhisperersSandals),
            typeof(WhisperingSandals),
            typeof(WhisperingSondals),
            typeof(WhisperingWindSash),
            typeof(WitchesBewitchingRobe),
            typeof(WitchesBrewedHat),
            typeof(WoodworkersInsightfulCap)			
        };

        private static readonly Type[] Tier9Items =
        {
            typeof(WitchesBewitchingRobe),
            typeof(AlchemistsSmockOfStains),
            typeof(AncestorsGaze),
            typeof(AntlerborneVeil),
            typeof(BakersHexguard),
            typeof(BannercladSkirtOfTheFirstHold),
            typeof(BarkbindLoop),
            typeof(BloodleafTotemMask),
            typeof(BloomwakeWaltz),
            typeof(BlossomcircleOfDawn),
            typeof(ChesswardensResolve),
            typeof(CinderskullCap),
            typeof(CragstepBoots),
            typeof(DancersOath),
            typeof(DriftcapOfRenika),
            typeof(DuskfeastBlouse),
            typeof(EchoveilRobe),
            typeof(ElderbloomBonnet),
            typeof(EmberhideWrap),
            typeof(FangwardensMaw),
            typeof(FlamewhiskerHat),
            typeof(GaleplumeCrest),
            typeof(GildedEveningOfDawn),
            typeof(GoldenwroughtElegy),
            typeof(GroveboundTunic),
            typeof(GrudgehideVisage),
            typeof(HearthfieldShade),
            typeof(HeraldSoulguardSurcoat),
            typeof(HonorboundTreads),
            typeof(IronrootGaiters),
            typeof(KnightsBreathDoublet),
            typeof(LaughingCrownOfEchoes),
            typeof(LilyveilKimono),
            typeof(LoomsoledWanderers),
            typeof(MaskOfTheHollowHerd),
            typeof(MeadowlightDress),
            typeof(MirageblessedCollar),
            typeof(MoonspunTunic),
            typeof(NightstepThreads),
            typeof(PatchbornPandemonium),
            typeof(PathboundSilence),
            typeof(PetalstrideSandals),
            typeof(PilgrimsRopewalkers),
            typeof(RainfoldOvercoat),
            typeof(RainwhisperBrim),
            typeof(ReapersWeft),
            typeof(RootsingerLeggings),
            typeof(SakurawindRobe),
            typeof(SashOfTheMoonBound),
            typeof(ScripturewovenRobe),
            typeof(SeaSerpentsScarf),
            typeof(ShadowleafWrap),
            typeof(ShroudOfTheHollowSky),
            typeof(SilentwaveWrap),
            typeof(SkycleftHakama),
            typeof(SkyleafTreads),
            typeof(SpiralknotObi),
            typeof(SprintersDilemma),
            typeof(StarlitDisciplineGarb),
            typeof(StarpiercersCone),
            typeof(StillwaterUndergarment),
            typeof(StonefireTartanKilt),
            typeof(StonewritBind),
            typeof(StormmarkCrests),
            typeof(StridersEmberweave),
            typeof(SunwardensCrest),
            typeof(SylphshimmerGown),
            typeof(ThornwovenHeritage),
            typeof(ThreshkingsHat),
            typeof(TumblesparkSoles),
            typeof(UmbralEmbrace),
            typeof(VeilOfTheSilentThread),
            typeof(VelvetfallRadiance),
            typeof(WanderersMantleOfMist),
            typeof(WarhowlHelm),
            typeof(WatchersKasaOfTheEastWinds),
            typeof(WayfarersLuckhorn),
            typeof(WhisperskirtOfFawn),
            typeof(WispweftRaiment),
            typeof(WolfspineMarchers),
            typeof(WyrmhideBreeches)		
        };

        private static readonly Type[] Tier10Items =
        {
            typeof(DarkLordsRobe),
            typeof(ArachnidQueensVeil),
            typeof(ArchmageMantle),
            typeof(BeastmastersMantle),
            typeof(BeastmastersSaddle),
            typeof(BetrayersShroud),
            typeof(BirdmastersPlume),
            typeof(BloodFoxCloak),
            typeof(BloodmastersRobes),
            typeof(BoglingsEmbrace),
            typeof(BogThingsEmbrace),
            typeof(BrigandsCloak),
            typeof(BootsofHaste),
            typeof(BrigandLordCloak),
            typeof(CapybaraWhispererSash),
            typeof(CelestialMantle),
            typeof(CentaurianCloak),
            typeof(ChangelingsEmbrace),
            typeof(ChaosbringerShroud),
            typeof(ChaoslordsMantle),
            typeof(ChickenWranglerSash),
            typeof(ChitinousCloak),
            typeof(CloakOfEffervescentMantra),
            typeof(CloakOfEtherealWings),
            typeof(CloakOfMoltenSerpents),
            typeof(CloakOfTheGargoylesVengeance),
            typeof(CloakOfTheHellCat),
            typeof(CloakOfTheHerd),
            typeof(CloakOfTheNightborn),
            typeof(CloakOfTheWailingBanshee),
            typeof(CloakOfTwistingVines),
            typeof(CloakOfViscera),
            typeof(CloakOfWinds),
            typeof(CluckmasterCloak),
            typeof(CraneMastersRobe),
            typeof(CrimsonDragonEmbrace),
            typeof(CrystalElementalistRobes),
            typeof(CrystalSummonersCirclet),
            typeof(DancerRobes),
            typeof(DarkArchmagesShroud),
            typeof(DecayedBoneHelm),
            typeof(DeepSeaSurgeCrown),
            typeof(DemonicOniMask),
            typeof(DesertWanderersSandals),
            typeof(DevourerCloak),
            typeof(DoomcallersMantle),
            typeof(DragonmastersRobe),
            typeof(DragonsFlameGrandMageStaff),
            typeof(DragonlordsHelm),
            typeof(DrakescaleCloak),
            typeof(DreamWraithCloak),
            typeof(DullCopperAegis),
            typeof(EternalWisdomRobe),
            typeof(ExecutionersCloak),
            typeof(FeatheredFarmersApron),
            typeof(FerretSummonersCloak),
            typeof(FlamesoulShroud),
            typeof(FlamingVeilOfTheFireRabbit),
            typeof(FleshRenderersCloak),
            typeof(ForgottenMantle),
            typeof(FlamecallersCrown),
            typeof(FrostbindersCloak),
            typeof(FrostcallersCape),
            typeof(FrostcallersCloak),
            typeof(FrostcallersShard),
            typeof(FrostDrakeCloak),
            typeof(FrostlaceCloak),
            typeof(FrostLordsCape),
            typeof(FrostMantleOfTheGlacier),
            typeof(FrostTrollCrown),
            typeof(FrostwardCape),
            typeof(FrostweaverCloak),
            typeof(FrostwraithCloak),
            typeof(FrostwyrmDominionStaff),
            typeof(GargoyleMastersRobes),
            typeof(GargoylesEmbrace),
            typeof(GargoyleShadesShroud),
            typeof(GargoyleSummonerSash),
            typeof(GargoylesVeil),
            typeof(GazersEmbrace),
            typeof(GibberlingSummonersHood),
            typeof(GlacialCommandersPlate),
            typeof(GoblinsCloakOfMischief),
            typeof(GoblinShamansMantle),
            typeof(GoldenAegis),
            typeof(GolemforgeChestplate),
            typeof(GravekeepersMantle),
            typeof(GrayGoblinShamanMask),
            typeof(GregoriosMantle),
            typeof(GremlinSummonerCap),
            typeof(GreyWolfSummonerCloak),
            typeof(HeartOfTheSlith),
            typeof(HordeMastersMask),
            typeof(HornedCrownOfTheLabyrinth),
            typeof(HornOfTheLabyrinth),
            typeof(HydraSummonerHelm),
            typeof(InfernalCloakOfHounds),
            typeof(InfernalPactCloak),
            typeof(InfernalPactRobe),
            typeof(InfernalRiderCloak),
            typeof(InfernalSummonerRobe),
            typeof(InfernosEmbraceCloak),
            typeof(InfiltratorsCloak),
            typeof(InsectlordsGauntlets),
            typeof(IronSentinelPlate),
            typeof(JuggernautsMightyGirdle),
            typeof(JukaWarlordsCloak),
            typeof(KepetchShroudOfShadows),
            typeof(KhaldunNecromancersShroud),
            typeof(KitsuneSummonerKimono),
            typeof(KrakenlordsShroud),
            typeof(LabyrinthMastersHelm),
            typeof(LavaforgedGauntlets),
            typeof(LavaLordsEmbrace),
            typeof(LeafWovenCirclet),
            typeof(LeatherWolfsCowl),
            typeof(LeviathansEmbraceShield),
            typeof(LichKingsCloak),
            typeof(LionheartMantle),
            typeof(LizardlordMantle),
            typeof(LlamamastersRobes),
            typeof(LlamaPackMasterBelt),
            typeof(LuminaCrystalRobe),
            typeof(MaggotmastersCloak),
            typeof(MarshwalkersBoots),
            typeof(MechanistsGloves),
            typeof(MimicsShroud),
            typeof(MistshaperCloak),
            typeof(MongbatCloak),
            typeof(MongbatSummoningCloak),
            typeof(NecromancerApron),
            typeof(NecromancerKiteShield),
            typeof(NecromancersMantle),
            typeof(NecroticSash),
            typeof(NightmaresMantle),
            typeof(NiporailemsShroud),
            typeof(OceanmastersRobes),
            typeof(OphidianKnightRelic),
            typeof(OphidianMatriarchSash),
            typeof(OphidiansArcaneSash),
            typeof(OrcishMageRobe),
            typeof(OrcishWarchiefsCloak),
            typeof(OrtanordsCrownOfFrost),
            typeof(OsseinSummonersHorn),
            typeof(OverseerControlCirclet),
            typeof(PackmastersCloak),
            typeof(ParoxysmusBreastplate),
            typeof(PixieWhisperRobes),
            typeof(PlaguebearersCloak),
            typeof(PlaguebearersShroud),
            typeof(PlagueBringersHood),
            typeof(PlaguelordShroud),
            typeof(PlagueweaversShroud),
            typeof(PredatorClawMantle),
            typeof(PrimalStalkerBoots),
            typeof(ProtectorsGuardianShield),
            typeof(PutridGuardianRobe),
            typeof(QuagmiresMantle),
            typeof(QueensGuardRobes),
            typeof(QueensSummonerRobe),
            typeof(RabbitmastersRobes),
            typeof(RaijusEmbrace),
            typeof(RancherHat),
            typeof(RaptorLordCloak),
            typeof(RatcatchersSash),
            typeof(RatmanArchersRobes),
            typeof(RatmanArchmageRobe),
            typeof(RatmastersRobes),
            typeof(RatmastersSash),
            typeof(RatsMastersRobes),
            typeof(RavagersRobes),
            typeof(ReaperlordsMantle),
            typeof(RedSolenWarriorRobes),
            typeof(RedSolenWorkerRobes),
            typeof(RenegadeMastersCloak),
            typeof(ReptalonMastersRobes),
            typeof(RevenantLionCrown),
            typeof(RevenantmastersRobes),
            typeof(RidersGoldenCloak),
            typeof(RidgebackMasterSash),
            typeof(RobeOfTheEvilArchmage),
            typeof(RobeOfTheMeerCommander),
            typeof(RobesOfThePhoenix),
            typeof(RoninBlade),
            typeof(RoninMastersRobe),
            typeof(RotweaversCloak),
            typeof(RotwormMastersRobes),
            typeof(RuddyBouraMastersRobes),
            typeof(RunemastersRobes),
            typeof(SabertoothMantle),
            typeof(SandmastersRobes),
            typeof(SashOfTheCatacombs),
            typeof(SashOfTheHiryu),
            typeof(SashOfTheMilitiaCommander),
            typeof(SatyrsEmbrace),
            typeof(SavageLordRobes),
            typeof(SavageMastersRobe),
            typeof(SavageShamansRegalia),
            typeof(SavageWardenBoots),
            typeof(SavageWarlordsCloak),
            typeof(ScelestusDarkMantle),
            typeof(ScorpionLordsSash),
            typeof(ScoutmastersCunningApron),
            typeof(SeductressApron),
            typeof(SentinelsAegis),
            typeof(SentinelsAegisRobes),
            typeof(SerpentcallerAmulet),
            typeof(SerpentineWarlordsRobe),
            typeof(SerpentLordSash),
            typeof(SerpentmastersGauntlets),
            typeof(SerpentsFangShroud),
            typeof(SerpentsStride),
            typeof(ShaadowmastersRobes),
            typeof(ShadecloakOfTheAbyss),
            typeof(ShadowcloakOfTheImpaler),
            typeof(ShadowlordsCloak),
            typeof(ShadowmastersRobes),
            typeof(ShadowNinjasCloak),
            typeof(ShadowPantherCloak),
            typeof(ShadowweaversRobes),
            typeof(ShadowWispRobes),
            typeof(ShardmastersDiadem),
            typeof(ShepherdsCloak),
            typeof(ShepherdsHartCloak),
            typeof(ShepherdsHat),
            typeof(ShepherdsMantle),
            typeof(ShepherdsRobe),
            typeof(ShieldOfTheWightLord),
            typeof(ShroudOfTheLifestealer),
            typeof(ShroudOfTheYomotsuPriest),
            typeof(SilverSerpentsEmbrace),
            typeof(SkitteringSash),
            typeof(SkreeSummonersHat),
            typeof(SkywatcherCloak),
            typeof(SlimeboundSash),
            typeof(SnowmastersBearMask),
            typeof(SnowStalkersCape),
            typeof(SolenHiveMasterSash),
            typeof(SolenInfiltratorTunic),
            typeof(SoulbindersRobe),
            typeof(SpectralShroud),
            typeof(SpellbindersOrb),
            typeof(SpiderlordsWebcloak),
            typeof(SpiderWeaverApron),
            typeof(SquirrelWhisperersSash),
            typeof(SteedmastersApron),
            typeof(StoneguardsAegis),
            typeof(StoneHarpyWingArmor),
            typeof(StormlordsCloak),
            typeof(StygianDrakeSash),
            typeof(SummonersMacawBandana),
            typeof(SummonersRingOfTheGoreFiend),
            typeof(SwamplardsSash),
            typeof(SwampLordsCloak),
            typeof(SwamplordsSash),
            typeof(SwampwardenGreaves),
            typeof(SylvanWardenBoots),
            typeof(TidecallersRobes),
            typeof(TigersClawHarness),
            typeof(TigersClawSash),
            typeof(TitanforgedStoneChest),
            typeof(ToxicDefenderShield),
            typeof(ToxicMantleOfCorrosion),
            typeof(ToxicWardensSash),
            typeof(TrapdoorWeaversWings),
            typeof(TropicsCallRobe),
            typeof(TsukiWolfsGaze),
            typeof(TurkeySummonersSash),
            typeof(TurkeyTamerSash),
            typeof(UnicornsGraceSash),
            typeof(VenomlordsShroud),
            typeof(VenomousMantle),
            typeof(VerdantGuardianPlate),
            typeof(VineweaversSash),
            typeof(VirulentWarlordsSash),
            typeof(VoidcallersStoneChest),
            typeof(VolcanicKasa),
            typeof(VorpalBunnyHeaddress),
            typeof(WalrusSummonerBoots),
            typeof(WarbossHelm),
            typeof(WarbringersGirdle),
            typeof(WarchiefHelm),
            typeof(WarChiefsBattleCrown),
            typeof(WardensGargoyleAmulet),
            typeof(WardensRobeOfTheForest),
            typeof(WatercallersKimono),
            typeof(WhiskersCloak),
            typeof(WhisperingOrb),
            typeof(WhiteWolfsHowl),
            typeof(WidowsVeil),
            typeof(WildBoarGirdle),
            typeof(WildkeeperSash),
            typeof(WildTigerSash),
            typeof(WildwoodMantle),
            typeof(WindrunnersBulwark),
            typeof(WintersEmbraceCloak),
            typeof(WispcallerScepter),
            typeof(WispsOfShadowCloak),
            typeof(WolfmastersPelt),
            typeof(WolfsbaneCloak),
            typeof(WraithboundMantle),
            typeof(WyrmcallersCloak),
            typeof(YamandonLordsStoneChest),
            typeof(YomotsuWarlordsYumi),
            typeof(YoungNinjasShadowblade)			
        };

        // ---------- CTORS ----------
        [Constructable]
        public UnidentifiedClothing() : base(0x1F04)
        {
            Name = "Unidentified Clothing";
			Hue = 2274;
        }

        [Constructable]
        public UnidentifiedClothing(int quality) : base(0x1F04, quality)
        {
            Name = "Unidentified Clothing";
			Hue = 2274;
        }

        public UnidentifiedClothing(Serial serial) : base(serial) { }

        // =========================================================
        //                      I D E N T I F Y
        // =========================================================
        public override void Identify(Mobile from)
        {
            // 1) determine tier (same roll as weapons)
            int skillBonus = (int)(from.Skills[SkillName.ItemID].Base / 10);
            int roll       = Utility.RandomMinMax(1, 100) + Quality + skillBonus;
            int tier;

            if      (roll >= 100) tier = 10;
            else if (roll >= 98)  tier = 9;
            else if (roll >= 95)  tier = 8;
            else if (roll >= 90)  tier = 7;
            else if (roll >= 82)  tier = 6;
            else if (roll >= 71)  tier = 5;
            else if (roll >= 58)  tier = 4;
            else if (roll >= 42)  tier = 3;
            else if (roll >= 22)  tier = 2;
            else                  tier = 1;

            // 2) generate the base clothing
            Item newItem;
            if (tier <= 7)
                newItem = new RandomMagicClothing(tier);
            else if (tier == 8)
                newItem = CreateFromList(Tier8Items);
            else if (tier == 9)
            {
                var combo = new List<Type>(Tier8Items);
                combo.AddRange(Tier9Items);
                newItem = CreateFromList(combo.ToArray());
            }
            else // tier 10
            {
                var combo = new List<Type>(Tier8Items);
                combo.AddRange(Tier9Items);
                combo.AddRange(Tier10Items);
                newItem = CreateFromList(combo.ToArray());
            }

            // 3) decide how many attachments
            int toAdd = GetAttachmentCount(tier);

            // 4) pick & attach them
            if (toAdd > 0)
            {
                var pool = BuildAttachmentPool(tier);
                for (int i = 0; i < toAdd && pool.Count > 0; i++)
                {
                    int idx = Utility.Random(pool.Count);
                    XmlAttach.AttachTo(newItem, pool[idx]);
                    pool.RemoveAt(idx);
                }
            }

			// 5) place the item & inform
			if (Parent is Container c)
				c.AddItem(newItem);
			else
				newItem.MoveToWorld(Location, Map);

			// build a single message string using C# string interpolation
			string msg = $"You identify the clothing (Quality {Quality}) – it becomes {(newItem.Name ?? "magical clothing")} (Tier {tier})";

			if (toAdd > 0)
				msg += $" and gains {toAdd} special attachment{(toAdd > 1 ? "s" : "")}";

			from.SendMessage(msg);

			Delete();

        }

        // =========================================================
        //                 A T T A C H M E N T   L O G I C
        // =========================================================

        private static int GetAttachmentCount(int tier)
        {
            double roll = Utility.RandomDouble();

            if (tier <= 5)                        // 80% none, 20% one
                return roll < 0.20 ? 1 : 0;

            if (tier <= 7)                        // 60% one, 30% two, 10% none
                return roll < 0.60 ? 1 : (roll < 0.90 ? 2 : 0);

            // tiers 8–10: 50% one, 35% two, 15% three
            return roll < 0.50 ? 1 : (roll < 0.85 ? 2 : 3);
        }

        private static List<XmlAttachment> BuildAttachmentPool(int tier)
        {
            var list = new List<XmlAttachment>();

            // Tier 1
            if (tier >= 1)
            {
                list.Add(new XmlMinionBonus(1));
            }

            // Tier 2
            if (tier >= 2)
            {
                list.Add(new XmlAstralStrike(2, 4));
            }

            // Tier 3
            if (tier >= 3)
            {
                list.Add(new XmlMinionBonus(2));
            }

            // Tier 4
            if (tier >= 4)
            {
                list.Add(new XmlMinionBonus(2));
            }

            // Tier 5
            if (tier >= 5)
            {
                list.Add(new XmlMinionBonus(3));
            }

            // Tier 6
            if (tier >= 6)
            {
                list.Add(new XmlMinionBonus(3));
            }

            // Tier 7
            if (tier >= 7)
            {
                list.Add(new XmlMinionBonus(4));
            }

            // Tier 8
            if (tier >= 8)
            {
                list.Add(new XmlMinionBonus(4));
            }

            // Tier 9
            if (tier >= 9)
            {
                list.Add(new XmlMinionBonus(5));
            }

            // Tier 10
            if (tier >= 10)
            {
                list.Add(new XmlMinionBonus(5));
            }

            // -------- AOS BASE ATTRIBUTES --------
            // We'll scale most attributes as +tier
            if (tier >= 1)
            {
                list.Add(new XmlAosAttributes { BonusStr        = tier });
                list.Add(new XmlAosAttributes { BonusDex        = tier });
                list.Add(new XmlAosAttributes { BonusInt        = tier });
                list.Add(new XmlAosAttributes { RegenHits       = tier });
                list.Add(new XmlAosAttributes { RegenStam       = tier });
                list.Add(new XmlAosAttributes { RegenMana       = tier });
                list.Add(new XmlAosAttributes { BonusHits       = tier * 2 });
                list.Add(new XmlAosAttributes { BonusStam       = tier * 2 });
                list.Add(new XmlAosAttributes { BonusMana       = tier * 2 });
            }
            if (tier >= 3)
            {
                list.Add(new XmlAosAttributes { DefendChance    = tier });
                list.Add(new XmlAosAttributes { AttackChance    = tier });
                list.Add(new XmlAosAttributes { SpellDamage     = tier });
                list.Add(new XmlAosAttributes { CastSpeed       = tier });
                list.Add(new XmlAosAttributes { CastRecovery    = tier });
            }
            if (tier >= 5)
            {
                list.Add(new XmlAosAttributes { LowerManaCost   = tier });
                list.Add(new XmlAosAttributes { LowerRegCost    = tier });
                list.Add(new XmlAosAttributes { ReflectPhysical = tier });
                list.Add(new XmlAosAttributes { EnhancePotions  = tier });
                list.Add(new XmlAosAttributes { Luck            = tier * 5 });
            }
            if (tier >= 7)
            {
                list.Add(new XmlAosAttributes { WeaponDamage    = tier });
                list.Add(new XmlAosAttributes { WeaponSpeed     = tier });
                list.Add(new XmlAosAttributes { NightSight      = 1 });
                list.Add(new XmlAosAttributes { SpellChanneling = 1 });
            }

            // -------- AOS WEAPON ATTRIBUTES --------
            if (tier >= 2)
            {
                list.Add(new XmlAosWeaponAttributes { LowerStatReq     = tier });
                list.Add(new XmlAosWeaponAttributes { SelfRepair       = tier });
                list.Add(new XmlAosWeaponAttributes { DurabilityBonus  = tier });
            }
            if (tier >= 4)
            {
                list.Add(new XmlAosWeaponAttributes { HitLeechHits     = tier });
                list.Add(new XmlAosWeaponAttributes { HitLeechStam     = tier });
                list.Add(new XmlAosWeaponAttributes { HitLeechMana     = tier });
                list.Add(new XmlAosWeaponAttributes { HitLowerAttack   = tier });
                list.Add(new XmlAosWeaponAttributes { HitLowerDefend   = tier });
                list.Add(new XmlAosWeaponAttributes { UseBestSkill     = 1 });
                list.Add(new XmlAosWeaponAttributes { MageWeapon       = 1 });
            }
            if (tier >= 6)
            {
                list.Add(new XmlAosWeaponAttributes { HitMagicArrow    = tier });
                list.Add(new XmlAosWeaponAttributes { HitHarm          = tier });
                list.Add(new XmlAosWeaponAttributes { HitFireball      = tier });
                list.Add(new XmlAosWeaponAttributes { HitColdArea      = tier });
                list.Add(new XmlAosWeaponAttributes { HitFireArea      = tier });
                list.Add(new XmlAosWeaponAttributes { HitEnergyArea    = tier });
                list.Add(new XmlAosWeaponAttributes { HitPoisonArea    = tier });
            }
            if (tier >= 8)
            {
                list.Add(new XmlAosWeaponAttributes { HitDispel        = tier });
                list.Add(new XmlAosWeaponAttributes { ResistPhysicalBonus = tier });
                list.Add(new XmlAosWeaponAttributes { ResistFireBonus     = tier });
                list.Add(new XmlAosWeaponAttributes { ResistColdBonus     = tier });
                list.Add(new XmlAosWeaponAttributes { ResistPoisonBonus   = tier });
                list.Add(new XmlAosWeaponAttributes { ResistEnergyBonus   = tier });
            }

            // -------- AOS ARMOR ATTRIBUTES --------
            if (tier >= 2)
            {
                list.Add(new XmlAosArmorAttributes { LowerStatReq    = tier });
                list.Add(new XmlAosArmorAttributes { SelfRepair      = tier });
                list.Add(new XmlAosArmorAttributes { DurabilityBonus = tier });
            }
            if (tier >= 5)
            {
                list.Add(new XmlAosArmorAttributes { MageArmor       = tier });
            }

            // -------- AOS ELEMENT ATTRIBUTES --------
            if (tier >= 3)
            {
                list.Add(new XmlAosElementAttributes { Physical = tier });
                list.Add(new XmlAosElementAttributes { Fire     = tier });
                list.Add(new XmlAosElementAttributes { Cold     = tier });
            }
            if (tier >= 6)
            {
                list.Add(new XmlAosElementAttributes { Poison   = tier });
                list.Add(new XmlAosElementAttributes { Energy   = tier });
            }

            return list;
        }

        // =========================================================
        //                      H E L P E R S
        // =========================================================
        private static Item CreateFromList(Type[] list)
        {
            if (list == null || list.Length == 0)
                return new RandomMagicClothing(7);  // fallback to mid‑tier
            Type t = list[Utility.Random(list.Length)];
            return (Item)Activator.CreateInstance(t);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
