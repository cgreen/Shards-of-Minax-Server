using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;   // for SkillName

namespace Server.Items
{
    public class UnidentifiedDocument : BaseUnidentifiedItem
    {
        // ———— DOCUMENT TABLES ————
        private static readonly Type[] Tier1Potions = {
            typeof(AdventurersContract),
            typeof(ArachnidSlayerDeed),
            typeof(ArmSlotChangeDeed),
            typeof(ArtifactDeed),
            typeof(BalancingDeed),
            typeof(BalronSlayerDeed),
            typeof(BankStorageIncreaseDeed),
            typeof(BeltSlotChangeDeed),
            typeof(BloodDrinkingSlayerDeed),
            typeof(BonusDexDeed),
            typeof(BonusIntDeed),
            typeof(BonusHitsDeed),		
            typeof(BraceletSlotChangeDeed),
            typeof(CandleToShieldDeed),
            typeof(CapacityIncreaseDeed),
            typeof(ChestSlotChangeDeed),
            typeof(AbyssalWaveTalentScroll),
            typeof(AirborneEscapeTalentScroll),
            typeof(ArcaneExplosionScroll),
            typeof(AstralStrikeScroll),
            typeof(AxeBreathScroll),
            typeof(AxeCircleScroll),
            typeof(AxeLineScroll),
            typeof(BackstabScroll),
            typeof(BackStrikeTalentScroll),
            typeof(BananaBombTalentScroll),
            typeof(BeeBreathScroll),
            typeof(BeeCircleScroll),
            typeof(BeeLineScroll),
            typeof(BladesBreathScroll),
            typeof(BladesCircleScroll),
            typeof(BladesLineScroll),
            typeof(BladeStrikeScroll),
            typeof(BlastStrikeScroll),
            typeof(BlazeStrikeScroll),
            typeof(BlazingChargeTalentScroll),
            typeof(BlazingTrailTalentScroll),
            typeof(BoilingSurgeTalentScroll),			
            typeof(AnimalControlDeed)			
        };
        private static readonly Type[] Tier2Potions = {
            typeof(DaemonSlayerDeed),
            typeof(DemonSlayerDeed),
            typeof(DragonSlayerDeed),
            typeof(EarringSlotChangeDeed),
            typeof(EarthShatterSlayerDeed),
            typeof(ElementalHealthSlayerDeed),
            typeof(ElementalSlayerDeed),
            typeof(FeySlayerDeed),
            typeof(FlameDousingSlayerDeed),
            typeof(FootwearSlotChangeDeed),
            typeof(GargoyleSlayerDeed),
            typeof(GenderChangeDeed),
            typeof(BoulderBreathScroll),
            typeof(BoulderCircleScroll),
            typeof(BoulderLineScroll),
            typeof(BreathAttackScroll),
            typeof(BreezeHealTalentScroll),
            typeof(BubbleBurstTalentScroll),
            typeof(BubbleShieldTalentScroll),
            typeof(ChaoticSurgeTalentScroll),
            typeof(ChillTouchScroll),
            typeof(CircleFireAttackScroll),
            typeof(CosmicCloakTalentScroll),
            typeof(CrankBreathScroll),
            typeof(CrankCircleScroll),
            typeof(CrankLineScroll),
            typeof(CrescendoOfJoyTalentScroll),
            typeof(CursedTouchScroll),
            typeof(CurtainBreathScroll),			
            typeof(HeadSlotChangeDeed)			
        };
        private static readonly Type[] Tier3Potions = {
            typeof(LanternToShieldDeed),
            typeof(LegsSlotChangeDeed),
            typeof(LizardmanSlayerDeed),
            typeof(LowerRegCostDeed),
            typeof(LrcDeed),
            typeof(LuckDeed),
            typeof(LuckIncreaseDeed),
            typeof(MedalOfHonor),
            typeof(MirrorOfHonesty),
            typeof(MirrorOfKalandra),
            typeof(MurderRemovalDeed),
            typeof(NeckSlotChangeDeed),
            typeof(NightSightDeed),
            typeof(CurtainCircleScroll),
            typeof(CurtainLineScroll),
            typeof(CycloneChargeTalentScroll),
            typeof(CycloneRampageTalentScroll),
            typeof(DeerBreathScroll),
            typeof(DeerCircleScroll),
            typeof(DeerLineScroll),
            typeof(DevourScroll),
            typeof(DisarmorScroll),
            typeof(DisarmScroll),
            typeof(DisguiseTalentScroll),
            typeof(DreamDustTalentScroll),
            typeof(DreamWeaveTalentScroll),
            typeof(DreamyAuraTalentScroll),
            typeof(DVortexBreathScroll),
            typeof(DVortexCircleScroll),
            typeof(DVortexLineScroll),
            typeof(EarthquakeStrikeScroll),
            typeof(EarthquakeTalentScroll),
            typeof(ElectricalSurgeTalentScroll),
            typeof(EnrageScroll),
            typeof(EruptionTalentScroll),
            typeof(EvasiveManeuverTalentScroll),
            typeof(FieryIllusionTalentScroll),
            typeof(FireBreathAttackTalentScroll),
            typeof(FireWalkTalentScroll),
            typeof(FlameCoilTalentScroll),			
            typeof(OgreSlayerDeed)		
        };
        private static readonly Type[] Tier4Potions = {
            typeof(OneHandedTransformDeed),
            typeof(OphidianSlayerDeed),
            typeof(OrcSlayerDeed),
            typeof(PetBondDeed),
            typeof(FlaskBreathScroll),
            typeof(FlaskCircleScroll),
            typeof(FlaskLineScroll),
            typeof(FlesheaterScroll),
            typeof(FossilBurstTalentScroll),
            typeof(FreezeStrikeScroll),
            typeof(FrenziedAttackTalentScroll),
            typeof(FrenzyScroll),
            typeof(FrostBreathTalentScroll),
            typeof(FrostNovaTalentScroll),
            typeof(FrostStrikeScroll),
            typeof(FrostyTrailTalentScroll),
            typeof(FTreeBreathScroll),
            typeof(FTreeCircleScroll),
            typeof(FTreeLineScroll),
            typeof(GaleStrikeTalentScroll),
            typeof(GasBreathScroll),
            typeof(GasCircleScroll),			
            typeof(PetSlotDeed)
        };
        private static readonly Type[] Tier5Potions = {
            typeof(RegenHitsDeed),
            typeof(RegenManaDeed),
            typeof(RegenStamDeed),
            typeof(RepondSlayerDeed),
            typeof(GasLineScroll),
            typeof(GateBreathScroll),
            typeof(GateCircleScroll),
            typeof(GateLineScroll),
            typeof(GlitterShieldTalentScroll),
            typeof(GlowBreathScroll),
            typeof(GlowCircleScroll),
            typeof(GlowLineScroll),
            typeof(GoldRainTalentScroll),
            typeof(GraniteSlamTalentScroll),
            typeof(GraspScroll),
            typeof(GravityWarpTalentScroll),
            typeof(GroundSlamTalentScroll),
            typeof(GuillotineBreathScroll),
            typeof(GuillotineCircleScroll),
            typeof(GuillotineLineScroll),
            typeof(GustBarrierTalentScroll),
            typeof(HarmonyEchoTalentScroll),
            typeof(HeadBreathScroll),
            typeof(HeadCircleScroll),
            typeof(HeadLineScroll),
            typeof(HeartBreathScroll),
            typeof(HeartCircleScroll),
            typeof(HeartLineScroll),
            typeof(HeavenlyStrikeTalentScroll),
            typeof(HellfireStormTalentScroll),
            typeof(IllusionAbilityTalentScroll),
            typeof(InfernoAuraTalentScroll),
            typeof(InvisibilityTalentScroll),
            typeof(LavaFlowTalentScroll),
            typeof(LavaWaveTalentScroll),
            typeof(LightningStrikeTalentScroll),
            typeof(LineAttackScroll),			
            typeof(ReptileSlayerDeed)
        };
        private static readonly Type[] Tier6Potions = {
            typeof(RingSlotChangeDeed),
            typeof(RoyalPetsCharter),
            typeof(MagmaThrowScroll),
            typeof(MaidenBreathScroll),
            typeof(MaidenCircleScroll),
            typeof(MaidenLineScroll),
            typeof(ManaBurnScroll),
            typeof(MelodyOfPeaceTalentScroll),
            typeof(MistyStepTalentScroll),
            typeof(MoltenBlastTalentScroll),
            typeof(MudBombTalentScroll),
            typeof(MudTrapTalentScroll),
            typeof(MushroomBreathScroll),
            typeof(MushroomCircleScroll),
            typeof(MushroomLineScroll),
            typeof(NaturesWrathScroll),
            typeof(NukeTalentScroll),
            typeof(NutcrackerBreathScroll),
            typeof(NutcrackerCircleScroll),
            typeof(NutcrackerLineScroll),
            typeof(OFlaskBreathScroll),
            typeof(OFlaskCircleScroll),
            typeof(OFlaskLineScroll),
            typeof(ParaBreathScroll),
            typeof(ParaCircleScroll),			
            typeof(RoyalSkillCharter)
        };
        private static readonly Type[] Tier7Potions = {
            typeof(RoyalStatCharter),
            typeof(ScorpionSlayerDeed),
            typeof(ParaLineScroll),
            typeof(PhantomBurnTalentScroll),
            typeof(PhantomStrikeTalentScroll),
            typeof(PoisonAppleThrowScroll),
            typeof(PoisonCloudScroll),
            typeof(PoisonStrikeTalentScroll),
            typeof(PrismaticBurstTalentScroll),
            typeof(PrismaticSprayScroll),
            typeof(RadiantShieldTalentScroll),
            typeof(RageTalentScroll),
            typeof(RainOfWrathTalentScroll),
            typeof(RallyingRoarTalentScroll),
            typeof(RandomAbilityTalentScroll),
            typeof(RandomMinionStrikeTalentScroll),
            typeof(ResonantAuraTalentScroll),
            typeof(RuneBreathScroll),
            typeof(RuneCircleScroll),
            typeof(RuneLineScroll),
            typeof(SavageStrikeTalentScroll),
            typeof(SawBreathScroll),
            typeof(SawCircleScroll),
            typeof(SawLineScroll),
            typeof(ScorchedBiteTalentScroll),			
            typeof(ShirtSlotChangeDeed)
        };
        private static readonly Type[] Tier8Potions = {
            typeof(SkillOrb),
            typeof(SlayerRemovalDeed),
            typeof(SilenceStrikeScroll),
            typeof(SilentGaleTalentScroll),
            typeof(SkeletonBreathScroll),
            typeof(SkeletonCircleScroll),
            typeof(SkeletonLineScroll),
            typeof(SkullBreathScroll),
            typeof(SkullCircleScroll),
            typeof(SkullLineScroll),
            typeof(SmokeBreathScroll),
            typeof(SmokeCircleScroll),
            typeof(SmokeLineScroll),
            typeof(SmokeStrikeScroll),
            typeof(SolarBurstTalentScroll),
            typeof(SolarFlareTalentScroll),
            typeof(SoothingWindTalentScroll),
            typeof(SparkleBlastTalentScroll),
            typeof(SparkleBreathScroll),
            typeof(SparkleCircleScroll),
            typeof(SparkleLineScroll),
            typeof(SparklingAuraTalentScroll),
            typeof(SpikeBreathScroll),
            typeof(SpikeCircleScroll),
            typeof(SpikeLineScroll),
            typeof(SpineBarrageScroll),
            typeof(StardustBeamTalentScroll),
            typeof(StarlightBurstTalentScroll),
            typeof(StarShowerTalentScroll),
            typeof(StaticShockTalentScroll),
            typeof(StaticStrikeScroll),			
            typeof(SnakeSlayerDeed)
        };
        private static readonly Type[] Tier9Potions = {
            typeof(SpidersDeathSlayerDeed),
            typeof(StatCapDeed),
            typeof(StatCapOrb),
            typeof(SummerWindSlayerDeed),
            typeof(StingScroll),
            typeof(StoneBreathScroll),
            typeof(StoneCircleScroll),
            typeof(StoneLineScroll),
            typeof(StormDashTalentScroll),
            typeof(SummonStrikeScroll),
            typeof(SunlitHealTalentScroll),
            typeof(TeleportAbilityTalentScroll),
            typeof(TeleportTalentScroll),
            typeof(TempestBreathTalentScroll),
            typeof(TheftStrikeScroll),
            typeof(TidalPullTalentScroll),
            typeof(TideSurgeTalentScroll),
            typeof(TimeBreathScroll),
            typeof(TimeCircleScroll),
            typeof(TimeLineScroll),
            typeof(ToxicSludgeTalentScroll),
            typeof(TrapBreathScroll),
            typeof(TrapCircleScroll),
            typeof(TrapLineScroll),
            typeof(TrapTalentScroll),
            typeof(TrickDecoyTalentScroll),
            typeof(TrickstersGambitTalentScroll),
            typeof(TrueFearTalentScroll),
            typeof(VolcanicEruptionTalentScroll),
            typeof(VortexBreathScroll),
            typeof(VortexCircleScroll),
            typeof(VortexLineScroll),
            typeof(VortexPullTalentScroll),
            typeof(WaterBreathScroll),
            typeof(WaterCircleScroll),
            typeof(WaterLineScroll),
            typeof(WaterStrikeScroll),
            typeof(WaterVortexTalentScroll),
            typeof(WeakenTalentScroll),
            typeof(WebCooldownScroll),
            typeof(WhirlwindFuryTalentScroll),
            typeof(WhirlwindScroll),
            typeof(WindBlastTalentScroll),
            typeof(ABCsForBarbarians),
            typeof(ACyclopsPerspective),
            typeof(AdventurersAccoutrements),
            typeof(AHerpetomancersTale),
            typeof(AlchemistsCompendium),
            typeof(ALeprechaunsLedger),
            typeof(AlmanacOfAethericArtifacts),
            typeof(AnAmphibianAnecdote),
            typeof(AnatomyOfCorporealUndead),
            typeof(AnatomyOfKrakens),
            typeof(AnatomyOfReapers),
            typeof(AnatomyOfSlimes),
            typeof(AnatomyOfSpectralUndead),
            typeof(AncestorsAndTheOrcs),
            typeof(AnEldersAnthology),
            typeof(AnOrcishCookbook),
            typeof(AntecedantsOfElvenLaw),
            typeof(BakingWithABarbaricTwist),
            typeof(BakingWithBasilisks),
            typeof(BalladsOfTheBattleborne),
            typeof(BalladsOfTheBefuddledBard),
            typeof(BardsGuideToBizarreCreatures),
            typeof(BardsWorstBallads),
            typeof(BlacksmithsGuideToBuildingInterstellarSpaceships),
            typeof(ChildsGuideToBeginnerWitchcraft),
            typeof(ChroniclesOfMalidrex),
            typeof(ChroniclesOfTheCrimsonSorcerer),
            typeof(ChroniclesOfTheCrystalCaverns),
            typeof(CodexOfCelestialAlignments),
            typeof(CodicilsOfTheCrypticConjurers),
            typeof(CompassionTalesOfEmpathy),
            typeof(CompendiumOfCharmedCreatures),
            typeof(CompendiumOfCuriousConstellations),
            typeof(CompendiumOfMythicalBeasts),
            typeof(ConfessionsOfADisenchantedDryad),
            typeof(ConfessionsOfMinax),
            typeof(DarkTalesOfHiddenCults),
            typeof(DeitiesOfBritannia),
            typeof(DiariesOfADwarvenDentist),
            typeof(DiaryOfARogueGargoyle),
            typeof(EchoesOfEtherealEmpires),
            typeof(EchoesOfTheEtherealPlane),
            typeof(ElementalistsEthos),
            typeof(ElvenCarpentry),
            typeof(EnchantmentsOfTheElvenShoemaker),
            typeof(EnigmaOfElementalEquilibrium),
            typeof(EnigmaOfTheWhisperingWoods),
            typeof(EnigmasOfTheEldritchElves),
            typeof(EttinElegiesPoetryAnthology),
            typeof(EttinPoetry),
            typeof(FablesOfTheFey),
            typeof(FineDiningInTheUnderworld),
            typeof(FragmentsOfFuturity),
            typeof(GazerGossip),
            typeof(GnomesGuideToGiantNegotiations),
            typeof(GnomishGadgetsAndHowToTinkerThem),
            typeof(GoblinEtiquette),
            typeof(GoblinGastronomyGoneWild),
            typeof(GoblinsGuideToGreed),
            typeof(GuardiansOfTheGrimoire),
            typeof(GuideToNonHumanHorticulture),
            typeof(HilariousHarpyHijinks),
            typeof(HistoryAirElementals),
            typeof(HistoryFireElementals),
            typeof(HistoryOfDragons),
            typeof(HistoryOfEarthElementals),
            typeof(HistoryOfEttins),
            typeof(HistoryOfImps),
            typeof(HistoryOfLiches),
            typeof(HistoryOfLizardmen),
            typeof(HistoryOfMongbats),
            typeof(HistoryOfNecromancy),
            typeof(HistoryOfTerathans),
            typeof(HistoryOfTheCyclopes),
            typeof(HistoryOfTheDaemons),
            typeof(HistoryOfTheGargoyles),
            typeof(HistoryOfTheGazers),
            typeof(HistoryOfTheHarpies),
            typeof(HistoryOfTheHeadless),
            typeof(HistoryOfTheOphidians),
            typeof(HistoryOfTheOrcs),
            typeof(HistoryOfTheRatmen),
            typeof(HistoryOfTheTitans),
            typeof(HistoryOfTrolls),
            typeof(HistoryOfWaterElementals),
            typeof(HowToHaggleWithAHag),
            typeof(HumilitysTriumph),
            typeof(JestersJestBook),
            typeof(KnightsGuideToDragonDiplomacy),
            typeof(LegendsOfTheLostLyricum),
            typeof(LibrariansSecretSpells),
            typeof(LizardmensLostLegacy),
            typeof(LycanthropicLegends),
            typeof(MagicalPropertiesOfBlackPearl),
            typeof(MagicalPropertiesOfBloodMoss),
            typeof(MagicalPropertiesOfGarlic),
            typeof(MagicalPropertiesOfMandrakeRoot),
            typeof(MagicalPropertiesOfNightshade),
            typeof(MagicalPropertiesOfSpiderSilk),
            typeof(MagicalPropertiesOfSulfurousAsh),
            typeof(MalidrexHistory),
            typeof(MermaidMannersForLandwalkers),
            typeof(MimicMusingsAChestsPerspective),			
            typeof(TalismanSlotChangeDeed)
        };
        private static readonly Type[] Tier10Potions = {
            typeof(TerathanSlayerDeed),
            typeof(TorchToShieldDeed),
            typeof(TrollSlayerDeed),
            typeof(UndeadSlayerDeed),
            typeof(VacuumSlayerDeed),
            typeof(VelocityDeed),
            typeof(WaterDissipationSlayerDeed),
            typeof(WeaponRenamingTool),
            typeof(MinotaurMazeMasters),
            typeof(MisadventuresOfABumblingMage),
            typeof(MisadventuresOfAHalfTrollDiplomat),
            typeof(MisdeedsOfMischievousMimics),
            typeof(MoansOfMournfulGhosts),
            typeof(OdesToTheFallen),
            typeof(OdesToTheObsidianOgres),
            typeof(OgreBaking),
            typeof(OgreCoutureTailoringTips),
            typeof(OgreCuisineBeyondTheStewpot),
            typeof(OgreHaikus),
            typeof(OgreLordsAndHierarchy),
            typeof(OgrePoetryBook),
            typeof(OgreTailoringBook),
            typeof(OnJestersBook),
            typeof(OnTheOriginOfGiantFrogs),
            typeof(OnTheVirtueOfCompassion),
            typeof(OnTheVirtueOfHonesty),
            typeof(OnTheVirtueOfHonor),
            typeof(OnTheVirtueOfHumility),
            typeof(OnTheVirtueOfJustice),
            typeof(OnTheVirtueOfSacrifice),
            typeof(OnTheVirtueOfSpirituality),
            typeof(OnTheVirtueOfValor),
            typeof(OrcishAlchemy),
            typeof(OrcishAlchemy2),
            typeof(OrcishBaking),
            typeof(OrcishBlacksmithingBook),
            typeof(OrcishCarpentryBook),
            typeof(OrcishFishingTechniques),
            typeof(OrcishHistory),
            typeof(OrcishStandUpComedy),
            typeof(OrcishTailoringBook),
            typeof(OrcishTinkeringBook),
            typeof(PathwaysToPerdition),
            typeof(PhantomsPhylactery),
            typeof(PixiePotions),
            typeof(PixiePranks),
            typeof(ProphetsOfThePast),
            typeof(QuixoticQuestsOfQuibbleQuasit),
            typeof(RatmenRiddles),
            typeof(RedBookOfRiddles),
            typeof(RiddleMastersBlueBook),
            typeof(RiddlesOfTheRunestone),
            typeof(RiseAndFallOfShadowlords),
            typeof(RulesOfAcquisition),
            typeof(RunesAndRuins),
            typeof(ScrollsOfTheSemiSaneSorcerer),
            typeof(ScrollsOfTheSubliminal),
            typeof(SecretLivesOfImps),
            typeof(SecretsOfTheLunarCult),
            typeof(SecretsOfTheSeers),
            typeof(ShadowsBehindTheStars),
            typeof(SilentSongsOfTheStoneGargoyles),
            typeof(SirensSingingLessons),
            typeof(SpeculationsOnGiantAnimals),
            typeof(SpeculationsOnIceAndFrost),
            typeof(SpeculationsOnOriginOfLordBritish),
            typeof(SpeculationsOnTheOriginOfMinax),
            typeof(SpeculationsOnWisps),
            typeof(StoriesOfRighteousness),
            typeof(TalesOfTheMysteriousMoonstones),
            typeof(TheAffairsOfWizards),
            typeof(TheAgeOfShadows),
            typeof(TheAlchemistsFormulary),
            typeof(TheArtOfWarMagic),
            typeof(TheClumsyNecromancer),
            typeof(TheCodeOfHonesty),
            typeof(TheDrunkenDragon),
            typeof(TheEclipsedMoon),
            typeof(TheForgottenFortress),
            typeof(TheHungoverHydra),
            typeof(TheJestersCode),
            typeof(TheMagicalPropertiesOfGinseng),
            typeof(TheMaidensQuest),
            typeof(TheNeedForOrderInBritannia),
            typeof(ThePhantomPipersOfPaws),
            typeof(TheRedAndTheGreyDragons),
            typeof(TheShardRealms),
            typeof(TheSirensCookbook),
            typeof(TheSovereignScrolls),
            typeof(TheSpectralCourt),
            typeof(TheThriftyThaumaturge),
            typeof(TheTitansForgottenLegacy),
            typeof(TheVirtueOfChaos),
            typeof(TheWraithWars),
            typeof(TreatisesOnTranscendentalMagics),
            typeof(TrollsGuideToBridgeEtiquette),
            typeof(TrollTalesFromTheBridge),
            typeof(UnheardTalesOfSosaria),
            typeof(UnlikelyUnityOfElvesAndEnts),
            typeof(VagrantVampires),
            typeof(VampiresGuideToBloodTypeDiets),
            typeof(VirtueLegendaryDeeds),
            typeof(VivaciousVenturesOfVexingValkyries),
            typeof(WerewolfsGuideToFur),
            typeof(WhenGolemsGrumble),
            typeof(WhispersFromTheVoid),
            typeof(WhispersOfWaterElementals),
            typeof(WizardsGuideToCulinaryMagic),
            typeof(WizardsGuideToWandering),
            typeof(WordsOfWispyWisdom),
            typeof(XenodochialXorns),
            typeof(YarnsOfTheYeti),
            typeof(ZenAndTheArtOfZombieMaintenance),
            typeof(AscendOrStagnate),
            typeof(BrokenStarPendantBlueprint),
            typeof(ClausesOfAscendantDebt),
            typeof(DoctrineOfBalanceAndCorrection),
            typeof(FiscalMysticismOfCosmicEquilibrium),
            typeof(FoundersLedger),
            typeof(OTLoyaltyOathScroll),
            typeof(OTPyramidOfProgress),
            typeof(SevenStepsToAscension),
            typeof(SilentCompliance),
            typeof(TestimoniesOfTheAscended),
            typeof(TheAxisHypothesis),
            typeof(TheStarBeyondScarcity),
            typeof(UnlockingTheBrokenStar),
            typeof(WealthWithoutEffort),
            typeof(SocketDeed),
            typeof(SocketDeed1),
            typeof(SocketDeed2),
            typeof(SocketDeed3),
            typeof(SocketDeed4),
            typeof(SocketDeed5),			
            typeof(WeightlessDeed)
        };

        // ———— CTORS ————
        [Constructable]
        public UnidentifiedDocument() : base(0x1F44) // bottle ID
        {
            Name = "Unidentified Document";
			Hue = 2274;
        }

        [Constructable]
        public UnidentifiedDocument(int quality) : base(0x1F44, quality)
        {
            Name = "Unidentified Document";
			Hue = 2274;
        }

        public UnidentifiedDocument(Serial serial) : base(serial) { }

        // ———— IDENTIFY METHOD ————
        public override void Identify(Mobile from)
        {
            // 1) Roll tier
            int skillBonus = (int)(from.Skills[SkillName.ItemID].Base / 10);
            int roll       = Utility.RandomMinMax(1, 100) + Quality + skillBonus;
            int tier;

            if      (roll >= 100) tier = 10;
            else if (roll >= 98)  tier =  9;
            else if (roll >= 95)  tier =  8;
            else if (roll >= 90)  tier =  7;
            else if (roll >= 82)  tier =  6;
            else if (roll >= 71)  tier =  5;
            else if (roll >= 58)  tier =  4;
            else if (roll >= 42)  tier =  3;
            else if (roll >= 22)  tier =  2;
            else                  tier =  1;

            // 2) Pick a potion for that tier
            Item newPotion = CreateFromTier(tier);

            // 3) Place it in the world or container
            if (Parent is Container c)
                c.AddItem(newPotion);
            else
                newPotion.MoveToWorld(Location, Map);

            // 4) Notify & delete
            from.SendMessage(
                $"You identify the potion (Quality {Quality}) – it becomes “{newPotion.Name}” (Tier {tier})."
            );
            Delete();
        }

        // ———— HELPER TO SELECT POTION BY TIER ————
        private static Item CreateFromTier(int tier)
        {
            Type[] list;

            switch (tier)
            {
                case  1: list = Tier1Potions;  break;
                case  2: list = Tier2Potions;  break;
                case  3: list = Tier3Potions;  break;
                case  4: list = Tier4Potions;  break;
                case  5: list = Tier5Potions;  break;
                case  6: list = Tier6Potions;  break;
                case  7: list = Tier7Potions;  break;
                case  8: list = Tier8Potions;  break;
                case  9: list = Tier9Potions;  break;
                case 10: list = Tier10Potions; break;
                default: list = Tier1Potions;  break;
            }

            if (list == null || list.Length == 0)
                return new LesserHealPotion(); // fallback

            var t = list[Utility.Random(list.Length)];
            return (Item)Activator.CreateInstance(t);
        }

        // ———— SERIALIZE / DESERIALIZE ————
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
