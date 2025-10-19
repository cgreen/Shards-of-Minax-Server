using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;           // SkillName
using Server.Engines.XmlSpawner2;    // XmlAttach, XmlAttachment

namespace Server.Items
{
    public class UnidentifiedWeapon : BaseUnidentifiedItem
    {
        // ---------- STATIC LOOT TABLES (exotic weapons) ----------
        private static readonly Type[] Tier8Items = { 
		typeof(VoyageursPaddle), 
		typeof(WandOfWoh),
		typeof(AegisShield),
		typeof(AeonianBow),
		typeof(AlamoDefendersAxe),
		typeof(AlucardsBlade),
		typeof(AnubisWarMace),
		typeof(ApepsCoiledScimitar),
		typeof(ApollosSong),
		typeof(ArchersYewBow),
		typeof(AssassinsKryss),
		typeof(AtmaBlade),
		typeof(AxeOfTheJuggernaut),
		typeof(AxeOfTheRuneweaver),
		typeof(BaneOfTheDead),
		typeof(BanshoFanClub),
		typeof(BarbarossaScimitar),
		typeof(BardsBowOfDiscord),
		typeof(BeowulfsWarAxe),
		typeof(BismarckianWarAxe),
		typeof(Blackrazor),
		typeof(BlacksmithsWarHammer),
		typeof(BlackSwordOfMondain),
		typeof(BlackTailWhip),
		typeof(BladeOfTheStars),
		typeof(Bonehew),
		typeof(BowiesLegacy),
		typeof(BowOfAuriel),
		typeof(BowOfIsrafil),
		typeof(BowspritOfBluenose),
		typeof(BulKathosTribalGuardian),
		typeof(BusterSwordReplica),
		typeof(ButchersCleaver),
		typeof(CaduceusStaff),
		typeof(CelestialLongbow),
		typeof(CelestialScimitar),
		typeof(CetrasStaff),
		typeof(ChakramBlade),
		typeof(CharlemagnesWarAxe),
		typeof(CherubsBlade),
		typeof(ChillrendLongsword),
		typeof(ChuKoNu),
		typeof(CrissaegrimEdge),
		typeof(CthulhusGaze),
		typeof(CursedArmorCleaver),
		typeof(CustersLastStandBow),
		typeof(DaggerOfShadows),
		typeof(DavidsSling),
		typeof(DawnbreakerMace),
		typeof(DeadMansLegacy),
		typeof(DestructoDiscDagger),
		typeof(DianasMoonBow),
		typeof(DoomfletchsPrism),
		typeof(Doomsickle),
		typeof(DragonClaw),
		typeof(DragonsBreath),
		typeof(DragonsBreathWarAxe),
		typeof(DragonsScaleDagger),
		typeof(DragonsWrath),
		typeof(Dreamseeker),
		typeof(EarthshakerMaul),
		typeof(EbonyWarAxeOfVampires),
		typeof(EldritchBowOfShadows),
		typeof(EldritchWhisper),
		typeof(ErdricksBlade),
		typeof(Excalibur),
		typeof(ExcaliburLongsword),
		typeof(ExcalibursLegacy),
		typeof(FangOfStorms),
		typeof(FlamebaneWarAxe),
		typeof(FrostfireCleaver),
		typeof(FrostflameKatana),
		typeof(FuHaosBattleAxe),
		typeof(GenjiBow),
		typeof(GeomancersStaff),
		typeof(GhoulSlayersLongsword),
		typeof(GlassSword),
		typeof(GlassSwordOfValor),
		typeof(GoldbrandScimitar),
		typeof(GreenDragonCrescentBlade),
		typeof(Grimmblade),
		typeof(GrimReapersCleaver),
		typeof(GriswoldsEdge),
		typeof(GrognaksAxe),
		typeof(GuardianOfTheFey),
		typeof(GuillotineBladeDagger),
		typeof(HalberdOfHonesty),
		typeof(HanseaticCrossbow),
		typeof(HarmonyBow),
		typeof(HarpeBlade),
		typeof(HeartbreakerSunder),
		typeof(HelmOfDarkness),
		typeof(IlluminaDagger),
		typeof(InuitUluOfTheNorth),
		typeof(JoansDivineLongsword),
		typeof(JuggernautHammer),
		typeof(KaomsCleaver),
		typeof(KaomsMaul),
		typeof(Keenstrike),
		typeof(KhufusWarSpear),
		typeof(KingsSwordOfHaste),
		typeof(MaatsBalancedBow),
		typeof(MablungsDefender),
		typeof(MaceOfTheVoid),
		typeof(MageMasher),
		typeof(MageMusher),
		typeof(MagesStaff),
		typeof(MagicAxeOfGreatStrength),
		typeof(MagusRod),
		typeof(MakhairaOfAchilles),
		typeof(ManajumasKnife),
		typeof(MarssBattleAxeOfValor),
		typeof(MasamuneBlade),
		typeof(MasamuneKatana),
		typeof(MasamunesEdge),
		typeof(MasamunesGrace),
		typeof(MaulOfSulayman),
		typeof(MehrunesCleaver),
		typeof(MortuarySword),
		typeof(MosesStaff),
		typeof(MuramasasBloodlust),
		typeof(MusketeersRapier),
		typeof(MysticBowOfLight),
		typeof(MysticStaffOfElements),
		typeof(NaginataOfTomoeGozen),
		typeof(NebulaBow),
		typeof(NecromancersDagger),
		typeof(NeptunesTrident),
		typeof(NormanConquerorsBow),
		typeof(PaladinsChrysblade),
		typeof(PlasmaInfusedWarHammer),
		typeof(PlutosAbyssalMace),
		typeof(PotaraEarringClub),
		typeof(PowerPoleHalberd),
		typeof(PowersBeacon),
		typeof(ProhibitionClub),
		typeof(QamarDagger),
		typeof(QuasarAxe),
		typeof(RainbowBlade),
		typeof(RasSearingDagger),
		typeof(ReflectionShield),
		typeof(RevolutionarySabre),
		typeof(RielsRebellionSabre),
		typeof(RuneAss),
		typeof(RuneAxe),
		typeof(SaiyanTailWhip),
		typeof(SamsonsJawbone),
		typeof(SaxonSeax),
		typeof(SearingTouch),
		typeof(SerpentsFang),
		typeof(SerpentsVenomDagger),
		typeof(ShadowstrideBow),
		typeof(ShavronnesRapier),
		typeof(SkyPiercer),
		typeof(SoulTaker),
		typeof(StaffOfAeons),
		typeof(StaffOfApocalypse),
		typeof(StaffOfRainsWrath),
		typeof(StaffOfTheElements),
		typeof(StarfallDagger),
		typeof(Sunblade),
		typeof(SwordOfAlBattal),
		typeof(SwordOfGideon),
		typeof(TabulasDagger),
		typeof(TantoOfThe47Ronin),
		typeof(TempestHammer),
		typeof(TeutonicWarMace),
		typeof(TheFurnace),
		typeof(TheOculus),
		typeof(ThorsHammer),
		typeof(Thunderfury),
		typeof(Thunderstroke),
		typeof(TitansFury),
		typeof(TomahawkOfTecumseh),
		typeof(TouchOfAnguish),
		typeof(TriLithiumBlade),
		typeof(TwoShotCrossbow),
		typeof(UltimaGlaive),
		typeof(UmbraWarAxe),
		typeof(UndeadCrown),
		typeof(ValiantThrower),
		typeof(VampireKiller),
		typeof(VATSEnhancedDagger),
		typeof(VenomsSting),
		typeof(VoidsEmbrace),
		typeof(VolendrungWarHammer),
		typeof(VolendrungWorHammer),
		typeof(VoltaxicRiftLance),
		typeof(VoyageursPaddle),
		typeof(VulcansForgeHammer),
		typeof(WabbajackClub),
		typeof(WandOfWoh),
		typeof(Whelm),
		typeof(WhisperingWindWarMace),
		typeof(WhisperwindBow),
		typeof(WindDancersDagger),
		typeof(WindripperBow),
		typeof(Wizardspike),
		typeof(WondershotCrossbow),
		typeof(Xcalibur),
		typeof(YumiOfEmpressJingu),
		typeof(ZhugeFeathersFan),
		typeof(Zulfiqar)		
		};
        private static readonly Type[] Tier9Items = { 
		typeof(BerserkersFuryWarAxe),
		typeof(AbyssalEcho),
		typeof(Avalanche),
		typeof(AxeOfTheLeviathan),
		typeof(AxeOfTheWhiteDragon),
		typeof(BansheesWail),
		typeof(BansheesWlil),
		typeof(BeastsMastersEdge),
		typeof(BerserkersFury),
		typeof(BerserkersFuryWarAxe),
		typeof(BerserkersSury),
		typeof(BoltOfTheAbyss),
		typeof(CelestialArbalest),
		typeof(CelestialBeaver),
		typeof(CelestialCleaver),
		typeof(CelestialDivide),
		typeof(CelestialFury),
		typeof(CelestialHarmony),
		typeof(CelestialPierce),
		typeof(CelestialPounder),
		typeof(CelestialStaff),
		typeof(CosmicHarmony),
		typeof(CrimsonBleaver),
		typeof(CrimsonCleaver),
		typeof(CrimsonCutter),
		typeof(CrimsonRipper),
		typeof(CrimsonTide),
		typeof(CursedCarver),
		typeof(DemiseOfTheDepths),
		typeof(DesertViperScimitar),
		typeof(DivineDecree),
		typeof(DragonsClaw),
		typeof(DragonsMaw),
		typeof(DrakescaleLongbow),
		typeof(DraugrsRemorse),
		typeof(DreadSpike),
		typeof(DruidsFury),
		typeof(Duskfall),
		typeof(EarthboundStave),
		typeof(EarthsEmbrace),
		typeof(Earthshaker),
		typeof(Earthsplitter),
		typeof(EchoesOfSilence),
		typeof(EchoesOfTheMountain),
		typeof(EldritchAegis),
		typeof(ElementalAdge),
		typeof(ElementalCarver),
		typeof(ElementalEdge),
		typeof(ElementalFury),
		typeof(ElementalPiercer),
		typeof(ElementalSpike),
		typeof(ElementalWdge),
		typeof(EnchantersAide),
		typeof(FiendsFork),
		typeof(FlameDancerScimitar),
		typeof(FrosFringer),
		typeof(FrostbiteCleaver),
		typeof(FrostbiteEdge),
		typeof(FrostbiteGlaive),
		typeof(FrostbiteHatchet),
		typeof(FrostbiteLauncher),
		typeof(FrostbittenMiner),
		typeof(Frostbringer),
		typeof(FrostDang),
		typeof(FrostEdgeScimitar),
		typeof(Frostfang),
		typeof(FrostfangPiercer),
		typeof(FrostGeaver),
		typeof(Frostrang),
		typeof(Frostreaver),
		typeof(FrostReckoner),
		typeof(FrostWeaver),
		typeof(GaeasImpaler),
		typeof(GaeasWrath),
		typeof(GaleCleaver),
		typeof(GaleForce),
		typeof(GaleforceString),
		typeof(GargoylesBane),
		typeof(GargoylesBone),
		typeof(GargoylesDemise),
		typeof(GargoylesHane),
		typeof(GargoylesSane),
		typeof(GargoylesSnipe),
		typeof(GargoylesWane),
		typeof(GavelOfJustice),
		typeof(GlimmerOfHope),
		typeof(GnomesGouge),
		typeof(GolemsDemise),
		typeof(GorefeastButcherKnife),
		typeof(HarbingerOfBilence),
		typeof(HarbingerOfFrost),
		typeof(HarbingerOfSilence),
		typeof(HarbingerOfTilence),
		typeof(HarpysCry),
		typeof(HarvesterOfSorrow),
		typeof(HarvestersBlessing),
		typeof(HarvestersFury),
		typeof(Heartseeker),
		typeof(HeraldOfDoom),
		typeof(InfernoBlade),
		typeof(InfernoCleaver),
		typeof(InfernoEdge),
		typeof(InfernoScepter),
		typeof(InfernosReach),
		typeof(InquisitorsGavel),
		typeof(KatanaOfCelestialHarmony),
		typeof(KatanaOfTheArcticWind),
		typeof(KatanaOfTheEclipse),
		typeof(KatanaOfTheForsaken),
		typeof(KatanaOfTheInferno),
		typeof(KatanaOfTheSerpentsFang),
		typeof(NecromancersVengeance),
		typeof(NetherCore),
		typeof(Nightfall),
		typeof(NightmareMace),
		typeof(Nightshade),
		typeof(NightsKiss),
		typeof(PhantomPiercer),
		typeof(PiratesDread),
		typeof(ReapersGrasp),
		typeof(ReapersJodgment),
		typeof(ReapersJudgment),
		typeof(ReapersToll),
		typeof(RuneEtchedBlade),
		typeof(RunicEcho),
		typeof(RunicFammer),
		typeof(RunicHammer),
		typeof(SeafarersHook),
		typeof(SeersCompanion),
		typeof(SerpentsCoil),
		typeof(SerpentsCrush),
		typeof(SerpentsFang),
		typeof(SerpentsFung),
		typeof(SerpentsGang),
		typeof(SerpentsGpite),
		typeof(SerpentsHiss),
		typeof(SerpentsLament),
		typeof(SerpentsMaul),
		typeof(SerpentsSaul),
		typeof(SerpentsTaul),
		typeof(ShadesEdge),
		typeof(ShadowReaver),
		typeof(ShadowStinger),
		typeof(ShadowstrikeScimitar),
		typeof(Skullcrusher),
		typeof(SpectresTouch),
		typeof(StaffOfEldritchPower),
		typeof(Starfall),
		typeof(StarfallGallet),
		typeof(StarfallMallet),
		typeof(StarfallMullet),
		typeof(StarfallPick),
		typeof(StarlightScimitar),
		typeof(Stormbringer),
		typeof(StormsEdge),
		typeof(Stormsringer),
		typeof(Stormtringer),
		typeof(TempestBolt),
		typeof(TempestsEdge),
		typeof(TempestsFury),
		typeof(TempestsReach),
		typeof(TempestsReaich),
		typeof(TempestsRetch),
		typeof(TempestsWury),
		typeof(TerrasWrath),
		typeof(TheDecapitator),
		typeof(TheJudge),
		typeof(TheMysticsTouch),
		typeof(TheNightingale),
		typeof(ThePeacekeeper),
		typeof(ThePeacemaker),
		typeof(TheReapersHarvest),
		typeof(TheSoulDivider),
		typeof(ThunderbladeScimitar),
		typeof(ThunderclapForger),
		typeof(ThunderlordsJudgment),
		typeof(ThunderousDecree),
		typeof(ThundersEdge),
		typeof(ThunderStrike),
		typeof(Tidebringer),
		typeof(TitansCudgel),
		typeof(TitansReach),
		typeof(TritonsWrath),
		typeof(VeinBreaker),
		typeof(VengeanceSeeker),
		typeof(Vindicator),
		typeof(VipersKiss),
		typeof(VipersPiss),
		typeof(VipersStrike),
		typeof(VoidsWhisper),
		typeof(WhisperingWind),
		typeof(WhisperOfDeath),
		typeof(WhisperOfDrath),
		typeof(WhisperOfTheValkyrie),
		typeof(WhisperOfTheWoods),
		typeof(WhisperOfVenom),
		typeof(WhisperwindBlade),
		typeof(WhisperwindBolt),
		typeof(WraithsHarvest),
		typeof(WraithsWhisper),
		typeof(WyrmsBane),
		typeof(ZephyrsFury),
		typeof(Arcspike),
		typeof(AshVialMarkI),
		typeof(BackstreetBolt),
		typeof(BargainBreaker),
		typeof(BlessingOfTheSilverSun),
		typeof(BloodbarkCleaver),
		typeof(Bonewake),
		typeof(Bramblebite),
		typeof(CircuitOfTheEchoingWill),
		typeof(Clockfang),
		typeof(Cogfang),
		typeof(CraftmothersHand),
		typeof(CragsWoe),
		typeof(DancersCrescent),
		typeof(Deepcaller),
		typeof(Dreadhowl),
		typeof(Earthsplinter),
		typeof(EyestoneTuner),
		typeof(FangOfTheFifthEye),
		typeof(FangOfTheGreenWidow),
		typeof(FlameOfFinalJudgement),
		typeof(Forgeheart),
		typeof(GeminiFang),
		typeof(GhostOfTheFirstReaper),
		typeof(GirdleOfTheMountainEcho),
		typeof(Glimmerchant),
		typeof(Gloambite),
		typeof(Gravemaker),
		typeof(Gutterthorn),
		typeof(HarvestersCurse),
		typeof(HellspikeOfGlutch),
		typeof(Hopebreaker),
		typeof(HungerEnd),
		typeof(ImpalerOfGloomhill),
		typeof(IsobelsWhisper),
		typeof(JudgementInAsh),
		typeof(LeystoneBough),
		typeof(Lifebringer),
		typeof(LightOfTheLastStar),
		typeof(Masksplitter),
		typeof(MercysEdge),
		typeof(MoonmarkAegis),
		typeof(MoonpetalFang),
		typeof(Moonpiercer),
		typeof(NaptimeObliterator),
		typeof(NavisRequiem),
		typeof(NerdsRage),
		typeof(Noiseblight),
		typeof(OathcarverOfTheSilentGuard),
		typeof(Pathcleaver),
		typeof(PsychicNeedle),
		typeof(Pulsebreaker),
		typeof(Quillfang),
		typeof(RazorrootGauntlets),
		typeof(RiftReaver),
		typeof(Rootsong),
		typeof(Scriptcutter),
		typeof(SerpentsCry),
		typeof(Shardgrin),
		typeof(SilentFlight),
		typeof(Skullveil),
		typeof(SoftstepsDelight),
		typeof(SongOfTheSleeplessHollow),
		typeof(Soulleech),
		typeof(StarforgedVow),
		typeof(Stormfang),
		typeof(Stormflight),
		typeof(SunkenThunder),
		typeof(Tenderfangs),
		typeof(TheAdaptix),
		typeof(TheFrozenFang),
		typeof(TheMoonherder),
		typeof(TheUmbralFlame),
		typeof(ThistlesThorn),
		typeof(Threadbinder),
		typeof(Threadpiercer),
		typeof(TombwoodKnocker),
		typeof(TongueOfTheGods),
		typeof(TouchOfTheVoid),
		typeof(Trailpiercer),
		typeof(Truthrender),
		typeof(Truthslicer),
		typeof(Veinspike),
		typeof(VoiceOfRuin),
		typeof(VoiceOfTheStarborn),
		typeof(WailOfTheForgotten),
		typeof(WardenOfTheGrove),
		typeof(WaylonsLastLaugh),
		typeof(Whisperfang),
		typeof(WhisperingBranch),
		typeof(WhispersOfChaos),
		typeof(WindsOfClarity),
		typeof(WyrmlanceOfDrakkonsEnd)		
		};
        private static readonly Type[] Tier10Items = { 
		typeof(CelestialDivide),
		typeof(TerathanMatriarchsScepter),
		typeof(StaffOfBoneSummoning),
		typeof(StaffOfJukaMagi),
		typeof(StaffOfOphidianDomination),
		typeof(StaffOfTheAncientGrove),
		typeof(StaffOfTheArcaneDaemon),
		typeof(StaffOfTheArcaneMeer),
		typeof(StaffOfTheHive),
		typeof(StaffOfTheLichKing),
		typeof(SkeletalReapersBardiche),
		typeof(TritonsTempestTrident),
		typeof(TrollKingsWarHammer),
		typeof(ScepterOfTheEternalWail),
		typeof(ScepterOfTheUndyingHorde),
		typeof(ScepterOfTheVoidWanderer),
		typeof(ScepterOfTheWraithLord),		
		typeof(TroglodyteSummonerKryss)		
		};

        // ---------- CTORS ----------
        [Constructable]
        public UnidentifiedWeapon() : base(0x13BA) 
		{ 
			Name = "Unidentified Weapon";
			Hue = 2274;		
		}

        [Constructable]
        public UnidentifiedWeapon(int quality) : base(0x13BA, quality) 
		{ 
			Name = "Unidentified Weapon";
			Hue = 2274;
		}

        public UnidentifiedWeapon(Serial serial) : base(serial) { }

        // =========================================================
        //                      I D E N T I F Y
        // =========================================================
        public override void Identify(Mobile from)
        {
            // ----- 1) roll the item tier (unchanged from original) -----
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

            // ----- 2) generate the BASE WEAPON -----
            Item newItem;
            if (tier <= 7)
                newItem = new RandomMagicWeapon(tier);
            else if (tier == 8)
                newItem = CreateFromList(Tier8Items);
            else if (tier == 9)
            {
                var combo = new List<Type>(Tier8Items); combo.AddRange(Tier9Items);
                newItem = CreateFromList(combo.ToArray());
            }
            else // tier 10
            {
                var combo = new List<Type>(Tier8Items); combo.AddRange(Tier9Items); combo.AddRange(Tier10Items);
                newItem = CreateFromList(combo.ToArray());
            }

            // ----- 3) decide HOW MANY attachments to add -----
            int toAdd = GetAttachmentCount(tier);

            // ----- 4) pick & attach them (unique per weapon) -----
            if (toAdd > 0)
            {
                List<XmlAttachment> pool = BuildAttachmentPool(tier);
                for (int i = 0; i < toAdd && pool.Count > 0; i++)
                {
                    int idx = Utility.Random(pool.Count);
                    XmlAttach.AttachTo(newItem, pool[idx]);
                    pool.RemoveAt(idx);             // prevent duplicates
                }
            }

            // ----- 5) move the identified weapon to the world -----
            if (Parent is Container c) c.AddItem(newItem);
            else                       newItem.MoveToWorld(Location, Map);

            from.SendMessage(String.Format(
                "You identify the item (Quality {0}) – it becomes {1} (Tier {2}){3}.",
                Quality, newItem.Name ?? "a weapon", tier,
                toAdd > 0 ? " and gains " + toAdd + " special attachment" + (toAdd > 1 ? "s" : "") : ""
            ));
            Delete();
        }

        // =========================================================
        //                 A T T A C H M E N T   L O G I C
        // =========================================================

        /// <summary>Chance table for how many attachments a tier may receive.</summary>
        private static int GetAttachmentCount(int tier)
        {
            double roll = Utility.RandomDouble();

            if (tier <= 5)                        // 80 % none, 20 % one
                return roll < 0.20 ? 1 : 0;

            if (tier <= 7)                        // 60 % one, 30 % two, 10 % none
                return roll < 0.60 ? 1 : (roll < 0.90 ? 2 : 0);

            /* tier 8‑10 */                       // 50 % one, 35 % two, 15 % three
            return roll < 0.50 ? 1 : (roll < 0.85 ? 2 : 3);
        }

        /// <summary>Builds the pool of attachments available up to the given tier.</summary>
        private static List<XmlAttachment> BuildAttachmentPool(int tier)
        {
            var list = new List<XmlAttachment>();

            // ---- Tier 1 ----
            if (tier >= 1)
            {
                list.Add(new XmlMinionBonus(1));                          // +1 follower  :contentReference[oaicite:3]{index=3}
                list.Add(new XmlFireBreathAttack(10, 4, 1.0));            // low damage  :contentReference[oaicite:4]{index=4}
                list.Add(new XmlAbyssalWave());
                list.Add(new XmlAirborneEscape());
                list.Add(new XmlArcaneExplosion(2, 4));
                list.Add(new XmlAstralStrike(2, 4));
                list.Add(new XmlAxeBreath());
                list.Add(new XmlAxeCircle());
                list.Add(new XmlAxeLine());
                list.Add(new XmlBackstab());
                list.Add(new XmlBackStrike());
                list.Add(new XmlBananaBomb());
                list.Add(new XmlBeeBreath());
                list.Add(new XmlBeeCircle());
                list.Add(new XmlBeeLine());
                list.Add(new XmlBladesBreath());
                list.Add(new XmlBladesCircle());
                list.Add(new XmlBladesLine());
                list.Add(new XmlBladeStrike(2, 4));
                list.Add(new XmlBlastStrike(2, 4));
                list.Add(new XmlBlazeStrike(2, 4));
                list.Add(new XmlBlazingCharge());
                list.Add(new XmlBlazingTrail());
                list.Add(new XmlBoilingSurge());
                list.Add(new XmlBoulderBreath());
                list.Add(new XmlBoulderCircle());
                list.Add(new XmlBoulderLine());
                list.Add(new XmlBreathAttack());
                list.Add(new XmlBreezeHeal());
                list.Add(new XmlBubbleBurst());
                list.Add(new XmlBubbleShield());
                list.Add(new XmlChaoticSurge());
                list.Add(new XmlChillTouch());
                list.Add(new XmlCircleFireAttack());
                list.Add(new XmlCosmicCloak());
                list.Add(new XmlCrankBreath());
                list.Add(new XmlCrankCircle());
                list.Add(new XmlCrankLine());
                list.Add(new XmlCrescendoOfJoy());
                list.Add(new XmlCursedTouch(2, 4));
                list.Add(new XmlCurtainBreath());
                list.Add(new XmlCurtainCircle());
                list.Add(new XmlCurtainLine());
                list.Add(new XmlCycloneCharge());
                list.Add(new XmlCycloneRampage());
                list.Add(new XmlDeerBreath());
                list.Add(new XmlDeerCircle());
                list.Add(new XmlDeerLine());
                list.Add(new XmlDevour());
                list.Add(new XmlDisarm());
                list.Add(new XmlDisarmor());
                list.Add(new XmlDisguise());
                list.Add(new XmlDreamDust());
                list.Add(new XmlDreamWeave());
                list.Add(new XmlDreamyAura());
                list.Add(new XmlDVortexBreath());
                list.Add(new XmlDVortexCircle());
                list.Add(new XmlDVortexLine());
                list.Add(new XmlEarthquake());
                list.Add(new XmlEarthquakeStrike(2, 4));
                list.Add(new XmlElectricalSurge());
                list.Add(new XmlEnrage());
                list.Add(new XmlEruption());
                list.Add(new XmlEvasiveManeuver());
                list.Add(new XmlFieryIllusion());
                list.Add(new XmlFireBreathAttack());
                list.Add(new XmlFireWalk());
                list.Add(new XmlFlameCoil());
                list.Add(new XmlFlaskBreath());
                list.Add(new XmlFlaskCircle());
                list.Add(new XmlFlaskLine());
                list.Add(new XmlFlesheater());
                list.Add(new XmlFossilBurst());
                list.Add(new XmlFreezeStrike());
                list.Add(new XmlFrenziedAttack());
                list.Add(new XmlFrenzy());
                list.Add(new XmlFrostBreath());
                list.Add(new XmlFrostNova());
                list.Add(new XmlFrostStrike(2, 4));
                list.Add(new XmlFrostyTrail());
                list.Add(new XmlFTreeBreath());
                list.Add(new XmlFTreeCircle());
                list.Add(new XmlFTreeLine());
                list.Add(new XmlGaleStrike());
                list.Add(new XmlGasBreath());
                list.Add(new XmlGasCircle());
                list.Add(new XmlGasLine());
                list.Add(new XmlGateBreath());
                list.Add(new XmlGateCircle());
                list.Add(new XmlGateLine());
                list.Add(new XmlGlitterShield());
                list.Add(new XmlGlowBreath());
                list.Add(new XmlGlowCircle());
                list.Add(new XmlGlowLine());
                list.Add(new XmlGoldRain());
                list.Add(new XmlGraniteSlam());
                list.Add(new XmlGrasp());
                list.Add(new XmlGravityWarp());
                list.Add(new XmlGroundSlam());
                list.Add(new XmlGuillotineBreath());
                list.Add(new XmlGuillotineCircle());
                list.Add(new XmlGuillotineLine());
                list.Add(new XmlGustBarrier());
                list.Add(new XmlHarmonyEcho());
                list.Add(new XmlHeadBreath());
                list.Add(new XmlHeadCircle());
                list.Add(new XmlHeadLine());
                list.Add(new XmlHeartBreath());
                list.Add(new XmlHeartCircle());
                list.Add(new XmlHeartLine());
                list.Add(new XmlHeavenlyStrike());
                list.Add(new XmlHellfireStorm());
                list.Add(new XmlIllusionAbility());
                list.Add(new XmlInfernoAura());
                list.Add(new XmlInvisibility());
                list.Add(new XmlLavaFlow());
                list.Add(new XmlLavaWave());
                list.Add(new XmlLightningStrike());
                list.Add(new XmlLineAttack());
                list.Add(new XmlMagmaThrow());
                list.Add(new XmlMaidenBreath());
                list.Add(new XmlMaidenCircle());
                list.Add(new XmlMaidenLine());
                list.Add(new XmlManaBurn(2, 4));
                list.Add(new XmlMelodyOfPeace());
                list.Add(new XmlMinionBonus());
                list.Add(new XmlMistyStep());
                list.Add(new XmlMoltenBlast());
                list.Add(new XmlMudBomb());
                list.Add(new XmlMudTrap());
                list.Add(new XmlMushroomBreath());
                list.Add(new XmlMushroomCircle());
                list.Add(new XmlMushroomLine());
                list.Add(new XmlNaturesWrath(2, 4));
                list.Add(new XmlNuke());
                list.Add(new XmlNutcrackerBreath());
                list.Add(new XmlNutcrackerCircle());
                list.Add(new XmlNutcrackerLine());
                list.Add(new XmlOFlaskBreath());
                list.Add(new XmlOFlaskCircle());
                list.Add(new XmlOFlaskLine());
                list.Add(new XmlParaBreath());
                list.Add(new XmlParaCircle());
                list.Add(new XmlParaLine());
                list.Add(new XmlPhantomBurn());
                list.Add(new XmlPhantomStrike());
                list.Add(new XmlPoisonAppleThrow());
                list.Add(new XmlPoisonCloud(2, 4));
                list.Add(new XmlPrismaticBurst());
                list.Add(new XmlPrismaticSpray());
                list.Add(new XmlRadiantShield());
                list.Add(new XmlRage());
                list.Add(new XmlRainOfWrath());
                list.Add(new XmlRallyingRoar());
                list.Add(new XmlRandomAbility());
                list.Add(new XmlRandomMinionStrike());
                list.Add(new XmlResonantAura());
                list.Add(new XmlRuneBreath());
                list.Add(new XmlRuneCircle());
                list.Add(new XmlRuneLine());
                list.Add(new XmlSavageStrike());
                list.Add(new XmlSawBreath());
                list.Add(new XmlSawCircle());
                list.Add(new XmlSawLine());
                list.Add(new XmlScorchedBite());
                list.Add(new XmlSilenceStrike(2, 4));
                list.Add(new XmlSilentGale());
                list.Add(new XmlSkeletonBreath());
                list.Add(new XmlSkeletonCircle());
                list.Add(new XmlSkeletonLine());
                list.Add(new XmlSkullBreath());
                list.Add(new XmlSkullCircle());
                list.Add(new XmlSkullLine());
                list.Add(new XmlSmokeBreath());
                list.Add(new XmlSmokeCircle());
                list.Add(new XmlSmokeLine());
                list.Add(new XmlSmokeStrike(2, 4));
                list.Add(new XmlSolarBurst());
                list.Add(new XmlSolarFlare());
                list.Add(new XmlSoothingWind());
                list.Add(new XmlSparkleBlast());
                list.Add(new XmlSparkleBreath());
                list.Add(new XmlSparkleCircle());
                list.Add(new XmlSparkleLine());
                list.Add(new XmlSparklingAura());
                list.Add(new XmlSpikeBreath());
                list.Add(new XmlSpikeCircle());
                list.Add(new XmlSpikeLine());
                list.Add(new XmlSpineBarrage());
                list.Add(new XmlStardustBeam());
                list.Add(new XmlStarlightBurst());
                list.Add(new XmlStarShower());
                list.Add(new XmlStaticShock());
                list.Add(new XmlStaticStrike(2, 4));
                list.Add(new XmlStatusEffectAttachment());
                list.Add(new XmlSting());
                list.Add(new XmlStoneBreath());
                list.Add(new XmlStoneCircle());
                list.Add(new XmlStoneLine());
                list.Add(new XmlStormDash());
                list.Add(new XmlSunlitHeal());
                list.Add(new XmlTeleport());
                list.Add(new XmlTeleportAbility());
                list.Add(new XmlTempestBreath());
                list.Add(new XmlTheftStrike());
                list.Add(new XmlTidalPull());
                list.Add(new XmlTideSurge());
                list.Add(new XmlTimeBreath());
                list.Add(new XmlTimeCircle());
                list.Add(new XmlTimeLine());
                list.Add(new XmlToxicSludge());
                list.Add(new XmlTrap());
                list.Add(new XmlTrapBreath());
                list.Add(new XmlTrapCircle());
                list.Add(new XmlTrapLine());
                list.Add(new XmlTrickDecoy());
                list.Add(new XmlTrickstersGambit());
                list.Add(new XmlTrueFear());
                list.Add(new XmlVolcanicEruption());
                list.Add(new XmlVortexBreath());
                list.Add(new XmlVortexCircle());
                list.Add(new XmlVortexLine());
                list.Add(new XmlVortexPull());
                list.Add(new XmlWaterBreath());
                list.Add(new XmlWaterCircle());
                list.Add(new XmlWaterLine());
                list.Add(new XmlWaterStrike(2, 4));
                list.Add(new XmlWaterVortex());
                list.Add(new XmlWeaken());
                list.Add(new XmlWebCooldown());
                list.Add(new XmlWhirlwind(2, 4));
                list.Add(new XmlWhirlwindFury());
                list.Add(new XmlWindBlast());				
            }

            // ---- Tier 2 ----
            if (tier >= 2)
            {
                list.Add(new XmlAstralStrike(2, 4));                      // 2 dmg / 4 s  :contentReference[oaicite:5]{index=5}
                list.Add(new XmlFireBreathAttack(15, 5, 0.9));
            }

            // ---- Tier 3 ----
            if (tier >= 3)
            {
                list.Add(new XmlMinionBonus(2));
                list.Add(new XmlFireBreathAttack(20, 6, 0.8));
                list.Add(new XmlAstralStrike(3, 5));
            }

            // ---- Tier 4 ----
            if (tier >= 4)
            {
                list.Add(new XmlMinionBonus(2));
                list.Add(new XmlFireBreathAttack(25, 7, 0.7));
                list.Add(new XmlAstralStrike(4, 6));
            }

            // ---- Tier 5 ----
            if (tier >= 5)
            {
                list.Add(new XmlMinionBonus(3));
                list.Add(new XmlFireBreathAttack(30, 8, 0.6));
                list.Add(new XmlAstralStrike(5, 7));
            }

            // ---- Tier 6 ----
            if (tier >= 6)
            {
                list.Add(new XmlMinionBonus(3));
                list.Add(new XmlFireBreathAttack(40, 9, 0.5));
                list.Add(new XmlAstralStrike(6, 8));
            }

            // ---- Tier 7 ----
            if (tier >= 7)
            {
                list.Add(new XmlMinionBonus(4));
                list.Add(new XmlFireBreathAttack(50, 10, 0.4));
                list.Add(new XmlAstralStrike(7, 10));
            }

            // ---- Tier 8 ----
            if (tier >= 8)
            {
                list.Add(new XmlMinionBonus(4));
                list.Add(new XmlFireBreathAttack(60, 11, 0.35));
                list.Add(new XmlAstralStrike(8, 12));
            }

            // ---- Tier 9 ----
            if (tier >= 9)
            {
                list.Add(new XmlMinionBonus(5));
                list.Add(new XmlFireBreathAttack(75, 12, 0.30));
                list.Add(new XmlAstralStrike(9, 14));
            }

            // ---- Tier 10 ----
            if (tier >= 10)
            {
                list.Add(new XmlMinionBonus(5));
                list.Add(new XmlFireBreathAttack(90, 14, 0.25));
                list.Add(new XmlAstralStrike(10, 15));
            }

            return list;
        }

        // =========================================================
        //                      H E L P E R S
        // =========================================================
        private static Item CreateFromList(Type[] list)
        {
            Type t = list[Utility.Random(list.Length)];
            return (Item)Activator.CreateInstance(t);
        }

        public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
    }
}
