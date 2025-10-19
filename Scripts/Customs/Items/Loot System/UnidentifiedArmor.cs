using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Engines.XmlSpawner2;    // XmlAttach, XmlAttachment
using Server.SkillHandlers;         // SkillName

namespace Server.Items
{
    public class UnidentifiedArmor : BaseUnidentifiedItem
    {
        // --- Tier 8, 9, 10 exotic armor lists ---
        private static readonly Type[] Tier8Items = {
            typeof(AlchemistsAmbition), 
			typeof(ArkainesValorArms),
            typeof(AegisOfAthena),
            typeof(AegisOfValor),
            typeof(AlchemistsAmbition),
            typeof(AlchemistsConduit),
            typeof(AlchemistsGroundedBoots),
            typeof(AlchemistsHeart),
            typeof(AlchemistsPreciseGloves),
            typeof(AlchemistsResilientLeggings),
            typeof(AlchemistsVisionaryHelm),
            typeof(ApronOfFlames),
            typeof(ArkainesValorArms),
            typeof(ArtisansCraftedGauntlets),
            typeof(ArtisansHelm),
            typeof(AshlandersResilience),
            typeof(AstartesBattlePlate),
            typeof(AstartesGauntletsOfMight),
            typeof(AstartesHelmOfVigilance),
            typeof(AstartesShoulderGuard),
            typeof(AstartesWarBoots),
            typeof(AstartesWarGreaves),
            typeof(AtzirisStep),
            typeof(AVALANCHEDefender),
            typeof(AvatarsVestments),
            typeof(BardsNimbleStep),
            typeof(BeastmastersCrown),
            typeof(BeastmastersGrips),
            typeof(BeastsWhisperersRobe),
            typeof(BerserkersEmbrace),
            typeof(BlackMagesMysticRobe),
            typeof(BlackMagesRuneRobe),
            typeof(BlacksmithsBurden),
            typeof(BlackthornesSpur),
            typeof(BladedancersCloseHelm),
            typeof(BladedancersPlateArms),
            typeof(BladeDancersPlateChest),
            typeof(BladeDancersPlateLegs),
            typeof(BlazePlateLegs),
            typeof(BombDisposalPlate),
            typeof(BootsOfBalladry),
            typeof(BootsOfFleetness),
            typeof(BootsOfSwiftness),
            typeof(BootsOfTheNetherTraveller),
            typeof(CarpentersCrown),
            typeof(CelesRunebladeBuckler),
            typeof(CetrasBlessing),
            typeof(ChefsHatOfFocus),
            typeof(CourtesansDaintyBuckler),
            typeof(CourtesansFlowingRobe),
            typeof(CourtesansGracefulHelm),
            typeof(CourtesansWhisperingBoots),
            typeof(CourtesansWhisperingGloves),
            typeof(CourtierDashingBoots),
            typeof(CourtiersEnchantedAmulet),
            typeof(CourtierSilkenRobe),
            typeof(CourtiersRegalCirclet),
            typeof(CovensShadowedHood),
            typeof(CreepersLeatherCap),
            typeof(CrownOfTheAbyss),
            typeof(DaedricWarHelm),
            typeof(DarkFathersCrown),
            typeof(DarkFathersDreadnaughtBoots),
            typeof(DarkFathersHeartplate),
            typeof(DarkFathersSoulGauntlets),
            typeof(DarkFathersVoidLeggings),
            typeof(DarkKnightsCursedChestplate),
            typeof(DarkKnightsObsidianHelm),
            typeof(DarkKnightsShadowedGauntlets),
            typeof(DarkKnightsVoidLeggings),
            typeof(DemonspikeGuard),
            typeof(DespairsShadow),
            typeof(Doombringer),
            typeof(DragonbornChestplate),
            typeof(DragonsBulwark),
            typeof(DragoonsAegis),
            typeof(DwemerAegis),
            typeof(EbonyChainArms),
            typeof(EdgarsEngineerChainmail),
            typeof(EldarRuneGuard),
            typeof(ElixirProtector),
            typeof(EmberPlateArms),
            typeof(EnderGuardiansChestplate),
            typeof(ExodusBarrier),
            typeof(FalconersCoif),
            typeof(FlamePlateGorget),
            typeof(FortunesGorget),
            typeof(FortunesHelm),
            typeof(FortunesPlateArms),
            typeof(FortunesPlateChest),
            typeof(FortunesPlateLegs),
            typeof(FrostwardensBascinet),
            typeof(FrostwardensPlateChest),
            typeof(FrostwardensPlateGloves),
            typeof(FrostwardensPlateLegs),
            typeof(GauntletsOfPrecision),
            typeof(GauntletsOfPurity),
            typeof(GauntletsOfTheWild),
            typeof(GloomfangChain),
            typeof(GlovesOfTheSilentAssassin),
            typeof(GlovesOfTransmutation),
            typeof(GoronsGauntlets),
            typeof(GreyWanderersStride),
            typeof(GuardianAngelArms),
            typeof(GuardianOfTheAbyss),
            typeof(GuardiansHeartplate),
            typeof(GuardiansHelm),
            typeof(HammerlordsArmguards),
            typeof(HammerlordsChestplate),
            typeof(HammerlordsHelm),
            typeof(HammerlordsLegplates),
            typeof(HarmonyGauntlets),
            typeof(HarmonysGuard),
            typeof(HarvestersFootsteps),
            typeof(HarvestersGrasp),
            typeof(HarvestersGuard),
            typeof(HarvestersHelm),
            typeof(HarvestersStride),
            typeof(HexweaversMysticalGloves),
            typeof(HlaaluTradersCuffs),
            typeof(ImmortalKingsIronCrown),
            typeof(InfernoPlateChest),
            typeof(InquisitorsGuard),
            typeof(IstarisTouch),
            typeof(JestersGleefulGloves),
            typeof(JestersMerryCap),
            typeof(JestersMischievousBuckler),
            typeof(JestersPlayfulTunic),
            typeof(JestersTricksterBoots),
            typeof(KnightsAegis),
            typeof(LeggingsOfTheRighteous),
            typeof(LioneyesRemorse),
            typeof(LionheartPlate),
            typeof(LockesAdventurerLeather),
            typeof(LocksleyLeatherChest),
            typeof(LyricalGreaves),
            typeof(LyricistsInsight),
            typeof(MagitekInfusedPlate),
            typeof(MakoResonance),
            typeof(MaskedAvengersAgility),
            typeof(MaskedAvengersDefense),
            typeof(MaskedAvengersFocus),
            typeof(MaskedAvengersPrecision),
            typeof(MaskedAvengersVoice),
            typeof(MelodicCirclet),
            typeof(MerryMensStuddedGloves),
            typeof(MeteorWard),
            typeof(MinersHelmet),
            typeof(MinstrelsMelody),
            typeof(MisfortunesChains),
            typeof(MondainsSkull),
            typeof(MonksBattleWraps),
            typeof(MonksSoulGloves),
            typeof(MysticSeersPlate),
            typeof(MysticsGuard),
            typeof(NajsArcaneVestment),
            typeof(NaturesEmbraceBelt),
            typeof(NaturesEmbraceHelm),
            typeof(NaturesGuardBoots),
            typeof(NecklaceOfAromaticProtection),
            typeof(NecromancersBoneGrips),
            typeof(NecromancersDarkLeggings),
            typeof(NecromancersHood),
            typeof(NecromancersRobe),
            typeof(NecromancersShadowBoots),
            typeof(NightingaleVeil),
            typeof(NinjaWrappings),
            typeof(NottinghamStalkersLeggings),
            typeof(OrkArdHat),
            typeof(OutlawsForestBuckler),
            typeof(PhilosophersGreaves),
            typeof(PyrePlateHelm),
            typeof(RadiantCrown),
            typeof(RatsNest),
            typeof(ReconnaissanceBoots),
            typeof(RedoranDefendersGreaves),
            typeof(RedstoneArtificersGloves),
            typeof(RoguesShadowBoots),
            typeof(RoyalCircletHelm),
            typeof(SabatonsOfDawn),
            typeof(SerenadesEmbrace),
            typeof(SerpentScaleArmor),
            typeof(SerpentsEmbrace),
            typeof(ShadowGripGloves),
            typeof(ShaftstopArmor),
            typeof(ShaminosGreaves),
            typeof(SherwoodArchersCap),
            typeof(ShinobiHood),
            typeof(ShurikenBracers),
            typeof(SilentStepTabi),
            typeof(SilksOfTheVictor),
            typeof(SirensLament),
            typeof(SirensResonance),
            typeof(SkinOfTheVipermagi),
            typeof(SlitheringSeal),
            typeof(SolarisAegis),
            typeof(SolarisLorica),
            typeof(SOLDIERSMight),
            typeof(SorrowsGrasp),
            typeof(StealthOperatorsGear),
            typeof(StormcrowsGaze),
            typeof(StormforgedBoots),
            typeof(StormforgedGauntlets),
            typeof(StormforgedHelm),
            typeof(StormforgedLeggings),
            typeof(StormforgedPlateChest),
            typeof(StringOfEars),
            typeof(SummonersEmbrace),
            typeof(TabulaRasa),
            typeof(TacticalVest),
            typeof(TailorsTouch),
            typeof(TalsRashasRelic),
            typeof(TamersBindings),
            typeof(TechPriestMantle),
            typeof(TelvanniMagistersCap),
            typeof(TerrasMysticRobe),
            typeof(TheThinkingCap),
            typeof(ThiefsNimbleCap),
            typeof(ThievesGuildPants),
            typeof(ThundergodsVigor),
            typeof(TinkersTreads),
            typeof(ToxinWard),
            typeof(TunicOfTheWild),
            typeof(TyraelsVigil),
            typeof(ValkyriesWard),
            typeof(VeilOfSteel),
            typeof(Venomweave),
            typeof(VialWarden),
            typeof(VipersCoif),
            typeof(VirtueGuard),
            typeof(VortexMantle),
            typeof(VyrsGraspingGauntlets),
            typeof(WardensAegis),
            typeof(WhispersHeartguard),
            typeof(WhiteMagesDivineVestment),
            typeof(WhiteRidersGuard),
            typeof(WhiteSageCap),
            typeof(WildwalkersGreaves),
            typeof(WinddancerBoots),
            typeof(WisdomsCirclet),
            typeof(WisdomsEmbrace),
            typeof(WitchesBindingGloves),
            typeof(WitchesCursedRobe),
            typeof(WitchesEnchantedHat),
            typeof(WitchesEnchantedRobe),
            typeof(WitchesHeartAmulet),
            typeof(WitchesWhisperingBoots),
            typeof(WitchwoodGreaves),
            typeof(WraithsBane),
            typeof(WrestlersArmsOfPrecision),
            typeof(WrestlersChestOfPower),
            typeof(WrestlersGrippingGloves),
            typeof(WrestlersHelmOfFocus),
            typeof(WrestlersLeggingsOfBalance),
            typeof(ZorasFins)
        };
        private static readonly Type[] Tier9Items = {
            typeof(AstartesBattlePlate),
            typeof(ArmsOfTheHearthguard),
            typeof(BeastwardShoulders),
            typeof(BlightTouchedWarhelm),
            typeof(BondsOfTheSpiraledVine),
            typeof(BoneArms),
            typeof(BreakersHauberk),
            typeof(BreathlessMask),
            typeof(CanopysDescent),
            typeof(ChestOfThePaleLegion),
            typeof(ChestOfTheRoaringLineage),
            typeof(CollarOfTheGildedSecret),
            typeof(CrownOfTheForgottenOath),
            typeof(CrownOfTheJungleKing),
            typeof(DawnguardKabuto),
            typeof(DrakkonsFlamebinders),
            typeof(DrakkonsRootedStance),
            typeof(DruidsRootbind),
            typeof(FawnweaveJerkin),
            typeof(FeralGraceRaiment),
            typeof(FingersOfTheDustbound),
            typeof(FortressBornShinplates),
            typeof(FrondsOfTheDreamingTouch),
            typeof(GaitOfTheHollowStag),
            typeof(GauntletsOfTheFinalHammer),
            typeof(GlovesOfTheOrchardsGrasp),
            typeof(GownOfTheBloomguard),
            typeof(GreenwardensWreath),
            typeof(GrimjawsCradle),
            typeof(HatredOfTheSlumberingForge),
            typeof(HauberkOfSilentPaths),
            typeof(HearthstitchWrap),
            typeof(HeartwoodCurio),
            typeof(HelmOfTheUnyieldingStar),
            typeof(HideOfTheForestKin),
            typeof(HideOfTheHuntersPact),
            typeof(HollowbeakVisage),
            typeof(HuntingQueensTrail),
            typeof(IronHeartplate),
            typeof(IronOrchardPauldrons),
            typeof(KabutoOfIronTempests),
            typeof(KabutoOfTheBloomingSteel),
            typeof(KnucklebindsOfTheThornedPath),
            typeof(LatticeOfTheFallenLegion),
            typeof(LeggingsOfTheGhostBell),
            typeof(LegguardsOfTheCrashingLine),
            typeof(MantleOfBeastsWill),
            typeof(MarinersEmbrace),
            typeof(MindflameVisageOfDrakkon),
            typeof(NailspikeGrips),
            typeof(NecklaceOfTheSylvanPact),
            typeof(NomadsSunsetGuard),
            typeof(OceanclaspBands),
            typeof(PathspikeGreaves),
            typeof(PeltknitBreeches),
            typeof(RingsOfTheLostTide),
            typeof(SageWrappedLimbs),
            typeof(ScaleborneWyrmplate),
            typeof(ScavengersWarding),
            typeof(ShadebindWrap),
            typeof(ShattermarchGreaves),
            typeof(ShellforgeVest),
            typeof(ShellsongVisor),
            typeof(SilentClawsOfTheVeil),
            typeof(SilentVowOfTheWatcher),
            typeof(SilverWreathOfEddasVision),
            typeof(SkirtOfTheCrescentRoar),
            typeof(SkullOfTheSixthMoon),
            typeof(SpinebraidBodice),
            typeof(SpinesOfTheQuietRebellion),
            typeof(SteelbloomCrest),
            typeof(SteelroseCorslet),
            typeof(StepOfTheGladewalker),
            typeof(StormstepGuards),
            typeof(StormweldBracers),
            typeof(StrideOfTheJungleShade),
            typeof(SunmirrorDome),
            typeof(TatamiBranchguards),
            typeof(TheAscendantGale),
            typeof(TheGrovesFinalReach),
            typeof(TheShadowsLastStep),
            typeof(ThistlelineGreaves),
            typeof(ThornwovenBracers),
            typeof(ThroatOfTheRoaringFlame),
            typeof(ThroatOfTheWildBond),
            typeof(TidewornEmbracers),
            typeof(TorsoOfEternalSentinel),
            typeof(TracklessWyrmbinders),
            typeof(TravelersLacedBreeches),
            typeof(TreadOfTheThornMarch),
            typeof(UndertideTreads),
            typeof(VeilOfTheDrownedVoice),
            typeof(VerdantEmbrace),
            typeof(VerdigrisPanels),
            typeof(VestmentOfEchoingRings),
            typeof(VigilantLayering),
            typeof(VoiceguardOfValor),
            typeof(WanderersShadowhood),
            typeof(WanderingFlameDo),
            typeof(WhisperOfTheHollowKings),
            typeof(WhisperspikeCollar),
            typeof(WingsOfTheSkyborne),
            typeof(WyrmhowlHelm),
            typeof(AlchemistsVisionHelmet),
            typeof(AlmsmansAegis),
            typeof(AnglersWaders),
            typeof(AnvilsGuardLegs),
            typeof(ArchersStuddedLeggingsOfAgility),
            typeof(ArchmagesGloves),
            typeof(ArchonsMysticRobe),
            typeof(ArtificersLeggings),
            typeof(ArtisansTunic),
            typeof(BakersResilientApron),
            typeof(BanditsLegs),
            typeof(BardsMythicalTunic),
            typeof(BeastmastersChest),
            typeof(BeggarsBondLeggings),
            typeof(BellowsPoweredCoif),
            typeof(BlademastersChestplate),
            typeof(BladesDancersChest),
            typeof(BowmastersRingmailArms),
            typeof(BowyersLeggings),
            typeof(ChampionsChampionshipBelt),
            typeof(ChampionsLeggingsOfParry),
            typeof(ChefsAegisApron),
            typeof(ChestplateOfEternalFlame),
            typeof(ChoirsHandwear),
            typeof(CrusadersHelmet),
            typeof(CrushersGauntlets),
            typeof(DaimyosHonorTekko),
            typeof(DeathwhispersCap),
            typeof(DefendersEnchantedBuckler),
            typeof(DisarmingLeatherArms),
            typeof(DragonscaleBuckler),
            typeof(DreadlordsBoneChest),
            typeof(DruidsProtector),
            typeof(DuelistsFullHelm),
            typeof(DuelistsLegplates),
            typeof(DuelistsVisionHelm),
            typeof(ElementalistsGauntlets),
            typeof(ElixirsGraspGloves),
            typeof(EnGardeLegs),
            typeof(FalconersGloves),
            typeof(FishmastersHauberk),
            typeof(FootpadsArms),
            typeof(ForestersGauntlets),
            typeof(ForestersPlateBoots),
            typeof(ForgeMastersChest),
            typeof(GadgeteersGauntlets),
            typeof(GarbOfTheGrandCouturier),
            typeof(GauntletsOfSecrecy),
            typeof(GauntletsOfTheMasterArtisan),
            typeof(GladiatorsHelmet),
            typeof(GrandmastersArmguards),
            typeof(GrandmastersParryingChest),
            typeof(GrappleKingsChestguard),
            typeof(GravekeepersBoneLegs),
            typeof(GreavesOfTheFallenStars),
            typeof(GrillmastersChainLeggings),
            typeof(GuardiansPlatemailGloves),
            typeof(HarmonicHelm),
            typeof(HarmonysLeggings),
            typeof(HawkeyesGauntlets),
            typeof(HelmOfTheAbyss),
            typeof(InvokersCrown),
            typeof(KenseisResolveGreaves),
            typeof(KnightsGauntlets),
            typeof(LockmastersChestplate),
            typeof(LuchadorsMask),
            typeof(MacebearersLeggings),
            typeof(MacefightersGrips),
            typeof(MaestrosDo),
            typeof(MantleOfShadows),
            typeof(MarksmansLeatherChestguard),
            typeof(MasterFencersGorget),
            typeof(MasterFletchersCoif),
            typeof(MastersThiefsHood),
            typeof(MasterTinkerersHelmet),
            typeof(MaulersHelmOfMastery),
            typeof(MendicantsMysticRobe),
            typeof(MinersPlateChest),
            typeof(MinstrelsArmguards),
            typeof(MysticsAegis),
            typeof(MysticsGuardBuckler),
            typeof(NecromancersChestOfEternity),
            typeof(PaupersPlateGorget),
            typeof(PeacekeepersArms),
            typeof(PhilosophersStonePlateChest),
            typeof(PiledriversPauldrons),
            typeof(PotionmastersRingmailArms),
            typeof(ProspectorsArms),
            typeof(ProwlersGloves),
            typeof(RangersHoodOfPrecision),
            typeof(RapierMastersArms),
            typeof(RoguesKabuto),
            typeof(RoninsSpiritKote),
            typeof(RudosReinforcedGreaves),
            typeof(SabreursJingasa),
            typeof(SafecrackersGorget),
            typeof(SamuraisDestinyHauberk),
            typeof(SeamstresssGloves),
            typeof(SeersLinkedSandals),
            typeof(SerenitysHelm),
            typeof(ShadowdancersPants),
            typeof(ShadowlurkersChestguard),
            typeof(ShadowMastersTreads),
            typeof(ShogunsWisdomKabuto),
            typeof(SilentSteps),
            typeof(SmithsPrecisionGauntlets),
            typeof(SorcerersEnchantedLeggings),
            typeof(SousChefsPrecisionGloves),
            typeof(SovereignsStreetwiseHelmet),
            typeof(SpectralGuardiansChest),
            typeof(SpiritcallersGloves),
            typeof(SwordSaintsArmguards),
            typeof(TailorsEmbrace),
            typeof(TechnicosTassets),
            typeof(TimberlordsHelm),
            typeof(TransmutationThighBoots),
            typeof(VagrantsVambraces),
            typeof(VeilOfTheNightwalker),
            typeof(VenomweaversArms),
            typeof(VirtuososGreaves),
            typeof(WardenOfTheWestsArms),
            typeof(WarlordsChestguard),
            typeof(WarlordsEmbraceYodareKake),
            typeof(WarlordsGorget),
            typeof(WhisperingWindLeggings)			
        };
        private static readonly Type[] Tier10Items = {
            typeof(BeastmastersCrown),
            typeof(AbyssalCrownOfCommand),
            typeof(AcidlordsCrown),
            typeof(AlchemistsExperimentalBracers),
            typeof(AntLionsEmbraceLeggings),
            typeof(BeetlemastersCarapace),
            typeof(BloodwormBreastplate),
            typeof(BoneKnightArmor),
            typeof(BronzeGauntlets),
            typeof(BullmastersHelm),
            typeof(ChaosDragoonArmor),
            typeof(ChaosDragoonChestplate),
            typeof(ChestOfTheHiveLord),
            typeof(ChitinousHelm),
            typeof(CopperCrown),
            typeof(CrownOfMaddeningWhispers),
            typeof(CrownOfTheInfernalKing),
            typeof(CrownOfTheLichKing),
            typeof(CyclopeanWarriorHelm),
            typeof(DeathWatchCarapace),
            typeof(DestroyersAegis),
            typeof(DragonheartSamuraiChest),
            typeof(DragonsHeartBreastplate),
            typeof(DrakeCommandersBreastplate),
            typeof(EarthWardensPlateChest),
            typeof(EldersGauntlets),
            typeof(ElementalCommandCrown),
            typeof(ElementalistsCrown),
            typeof(EttinSummonerHelm),
            typeof(ExodusVanguardPlate),
            typeof(FrostboundWarhelm),
            typeof(GargoyleSummonerHelm),
            typeof(GargishStoneChestOfTheHiveLord),
            typeof(GolemControllerBracers),
            typeof(GrizzlyGuardiansHelm),
            typeof(HeadlessHorrorHelm),
            typeof(HarpyQueensCrown),
            typeof(HellfireCrown),
            typeof(HellfireGreaves),
            typeof(HelmOfThePlagueLord),
            typeof(HelmOfTheUndeadMaster),
            typeof(InfernalGrasp),
            typeof(KepetchSummonerHelm),
            typeof(KhaldunAcolyteRobe),
            typeof(MimicsChestplate),
            typeof(MinotaurLordHornedHelm),
            typeof(MoltenCoreChestplate),
            typeof(NaturesWrathPlateChest),
            typeof(NaturesSentinelChestplate),
            typeof(NecromancersBoneChest),
            typeof(OgresGauntlets),
            typeof(OrcBombersGauntlets),
            typeof(OphidianSerpentineHelm),
            typeof(OrcWarlordsPlateChest),
            typeof(OrcWarchiefsBattleHelm),
            typeof(PharaohsGoldenCrown),
            typeof(PrimalWardensHelm),
            typeof(PyromancerCuirass),
            typeof(RousingWingArmor),
            typeof(ShadowlordsPlateChest),
            typeof(SkeletalDrakeBreastplate),
            typeof(SkullLordsHelm),
            typeof(SlithlordsStoneChest),
            typeof(SpectralGuardPlate),
            typeof(StoneTitansHelm),
            typeof(SwamplordsCrown),
            typeof(TriceratopsBoneHelm),
            typeof(WyvernBoneHelm)			
        };

        [Constructable]
        public UnidentifiedArmor() : base(0x13D3) 
        {
            Name = "Unidentified Armor";
			Hue = 2274;
        }

        [Constructable]
        public UnidentifiedArmor(int quality) : base(0x13D3, quality)
        {
            Name = "Unidentified Armor";
			Hue = 2274;
        }

        public UnidentifiedArmor(Serial serial) : base(serial) { }

        public override void Identify(Mobile from)
        {
            // 1) Determine tier exactly as weapons do
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

            // 2) Create the base armor
            Item newItem;
            if (tier <= 7)
                newItem = new RandomMagicArmor(tier);
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

            // 3) Roll how many attachments
            int toAdd = GetAttachmentCount(tier);

            // 4) Build pool & attach
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

            // 5) Place and inform
            if (Parent is Container cont)
                cont.AddItem(newItem);
            else
                newItem.MoveToWorld(Location, Map);

            from.SendMessage(String.Format(
                "You identify the armor (Quality {0}) – it becomes {1} (Tier {2}){3}.",
                Quality, newItem.Name, tier,
                toAdd > 0 ? " and gains " + toAdd + " attachment" + (toAdd > 1 ? "s" : "") : ""
            ));

            Delete();
        }

        // --- Exactly the same attachment‑count logic as weapons ---
        private static int GetAttachmentCount(int tier)
        {
            double roll = Utility.RandomDouble();

            if (tier <= 5)                        // 80% none, 20% one
                return roll < 0.20 ? 1 : 0;

            if (tier <= 7)                        // 60% one, 30% two, 10% none
                return roll < 0.60 ? 1 : (roll < 0.90 ? 2 : 0);

            // tier 8–10: 50% one, 35% two, 15% three
            return roll < 0.50 ? 1 : (roll < 0.85 ? 2 : 3);
        }

        // --- Same pool, scaled by tier ---
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

        private static Item CreateFromList(Type[] list)
        {
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
