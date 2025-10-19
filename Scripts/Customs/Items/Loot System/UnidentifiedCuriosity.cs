using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.SkillHandlers;   // for SkillName

namespace Server.Items
{
    public class UnidentifiedCuriosity : BaseUnidentifiedItem
    {
        // ———— TREASURE TABLES ————
        private static readonly Type[] Tier1Potions = {
            typeof(MaxxiaDust),
            typeof(TrexSkull),
            typeof(RootThrone),
            typeof(BabyLavos),
            typeof(CowToken),
            typeof(WallFlowers),
            typeof(ColoredLamppost),
            typeof(EarthRelic),
            typeof(ExoticWhistle),
            typeof(GrandmasKnitting),
            typeof(FancyShipWheel),
            typeof(ExoticBoots),
            typeof(FineIronWire),
            typeof(SeaSerpantSteak),
            typeof(RareOil),
            typeof(SpikedChair),
            typeof(KrakenTrophy),
            typeof(ZttyCrystal),
            typeof(FineCopperWire),
            typeof(GraniteHammer),
            typeof(StuffedDoll),
            typeof(FancyMirror),
            typeof(ExoticPlum),
            typeof(Shears),
            typeof(FillerPowder),
            typeof(HorrorPumpkin),
            typeof(HumanCarvingKit),
            typeof(HangingMask),
            typeof(SkullIncense),
            typeof(AncientRunes),
            typeof(WeddingChest),
            typeof(ExoticShipInABottle),
            typeof(FancySewingMachine),
            typeof(CowPoo),
            typeof(FeedingTrough),
            typeof(SkullBottle),
            typeof(AncientDrum),
            typeof(BrassBell),
            typeof(PlagueBanner),
            typeof(BeeHive),
            typeof(FestiveChampagne),
            typeof(DecorativeFishTank),
            typeof(SkullsStack),
            typeof(VenusFlytrap),
            typeof(HorribleMask),
            typeof(Meteorite),
            typeof(TotumPole),
            typeof(ExcitingTome),
            typeof(WindRelic),
            typeof(FancyCopperWings),
            typeof(RareGrease),
            typeof(EnchantedRose),
            typeof(HeartChair),
            typeof(PicnicDayBasket),
            typeof(HorseToken),
            typeof(AutoPounder),
            typeof(WatermelonTray),
            typeof(MasterTrumpet),
            typeof(WeaponBottle),
            typeof(LeatherStrapBelt),
            typeof(JackPumpkin),
            typeof(MiniYew),
            typeof(ImportantFlag),
            typeof(HutFlower),
            typeof(CookingTalisman),
            typeof(LampPostA),
            typeof(LampPostB),
            typeof(MasterGyro),
            typeof(MemorialStone),
            typeof(MemorialCopper),
            typeof(LargeVat),
            typeof(YardCupid),
            typeof(FieldPlow),
            typeof(ChaliceOfPilfering),
            typeof(Jet),
            typeof(InfinitySymbol),
            typeof(AncientWood)
        };
        private static readonly Type[] Tier2Potions = {
            typeof(RareMinerals),
            typeof(QuestWineRack),
            typeof(FancyCrystalSkull),
            typeof(StoneHead),
            typeof(FluxCompound),
            typeof(ArtisanHolidayTree),
            typeof(TinyWizard),
            typeof(MiniKeg),
            typeof(DemonPlatter),
            typeof(Hotdogs),
            typeof(PersonalMortor),
            typeof(RareWire),
            typeof(ForbiddenTome),
            typeof(CompoundF),
            typeof(MonsterBones),
            typeof(MagicOrb),
            typeof(RibEye),
            typeof(ButterChurn),
            typeof(StainedWindow),
            typeof(MutantStarfish),
            typeof(WatermelonSliced),
            typeof(ImperiumCrest),
            typeof(ExoticWoods),
            typeof(ZombieHand),
            typeof(EasterDayEgg),
            typeof(FancyXmasTree),
            typeof(CrabBushel),
            typeof(PersonalCannon),
            typeof(GalvanizedTub),
            typeof(FixedScales),
            typeof(NexusShard),
            typeof(RareSausage),
            typeof(WatermelonFruit),
            typeof(ToolBox),
            typeof(HorrodrickCube),
            typeof(TrophieAward),
            typeof(ClutteredDesk),
            typeof(TinkeringTalisman),
            typeof(DeathBlowItem),
            typeof(DeadBody),
            typeof(FairyOil),
            typeof(FleshLight),
            typeof(EssentialBooks),
            typeof(PileOfChains),
            typeof(FancyCopperSunflower),
            typeof(FineHoochJug),
            typeof(SpookyGhost),
            typeof(ScentedCandle),
            typeof(SnowSculpture),
            typeof(MasterShrubbery),
            typeof(MilkingPail),
            typeof(MonsterTrophy),
            typeof(DistilledEssence),
            typeof(WigStand),
            typeof(BrassFountain),
            typeof(HandOfFate),
            typeof(NameTapestry),
            typeof(OpalBranch),
            typeof(SilverMirror),
            typeof(MarbleHourglass),
            typeof(KnightStone)		
        };
        private static readonly Type[] Tier3Potions = {
            typeof(HolidayCandleArran),
            typeof(ValentineTeddybear),
            typeof(WitchesCauldron),
            typeof(FireRelic),
            typeof(CartographyDesk),
            typeof(BirdStatue),
            typeof(Hamburgers),
            typeof(SerpantCrest),
            typeof(AstroLabe),
            typeof(OrganicHeart),
            typeof(Birdhouse),
            typeof(SabertoothSkull),
            typeof(ZebulinVase),
            typeof(PineResin),
            typeof(SpiderTree),
            typeof(RopeSpindle),
            typeof(DailyNewspaper),
            typeof(FunPumpkinCannon),
            typeof(VirtueRune),
            typeof(BonFire),
            typeof(MiniCherryTree),
            typeof(SkullShield),
            typeof(UnluckyDice),
            typeof(ImportantBooks)
        };
        private static readonly Type[] Tier4Potions = {
            typeof(StarMap),
            typeof(SkullRing),
            typeof(BrandingIron),
            typeof(OldBones),
            typeof(MillStones),
            typeof(Steroids),
            typeof(HildebrandtBunting),
            typeof(LexxVase),
            typeof(OrnateHarp),
            typeof(FletchingTalisman),
            typeof(TinTub),
            typeof(FishingBear),
            typeof(WorldShard),
            typeof(SheepCarcass),
            typeof(TailoringTalisman),
            typeof(DecorativeOrchid),
            typeof(SubOil),
            typeof(FancyPainting),
            typeof(MedusaHead),
            typeof(PetRock),
            typeof(MeatHooks),
            typeof(GamerJelly),
            typeof(ShardCrest),
            typeof(EvilCandle),
            typeof(HotFlamingScarecrow),
            typeof(AmatureTelescope),
            typeof(AnniversaryPainting),
            typeof(MagicBookStand),
            typeof(SmugglersCrate),
            typeof(HolidayPillow),
            typeof(UncrackedGeode),
            typeof(DrapedBlanket),
            typeof(BlacksmithTalisman),
            typeof(CityBanner),
            typeof(BookTwentyfive),
            typeof(WelcomeMat)
        };
        private static readonly Type[] Tier5Potions = {
            typeof(LampPostC),
            typeof(BlueSand),
            typeof(FunMushroom),
            typeof(ReactiveHormones),
            typeof(CandleStick),
            typeof(LuckyDice),
            typeof(JudasCradle),
            typeof(GlassFurnace),
            typeof(LovelyLilies),
            typeof(CupOfSlime),
            typeof(GingerbreadCookie),
            typeof(CarvingMachine),
            typeof(GargoyleLamp),
            typeof(AnimalTopiary),
            typeof(TinCowbell),
            typeof(WoodAlchohol),
            typeof(ChocolateFountain),
            typeof(PowerGem),
            typeof(AtomicRegulator),
            typeof(JesterSkull),
            typeof(GamerGirlFeet),
            typeof(HildebrandtTapestry),
            typeof(AnimalBox),
            typeof(BakingBoard),
            typeof(SatanicTable),
            typeof(WaterFountain),
            typeof(FountainWall),
            typeof(HildebrandtFlag),
            typeof(MysteryOrb),
            typeof(BlueberryPie),
            typeof(BioSamples),
            typeof(OldEmbroideryTool),
            typeof(DistillationFlask),
            typeof(SexWhip),
            typeof(FrostToken),
            typeof(SoftTowel),
            typeof(WeddingDayCake),
            typeof(LargeTome),
            typeof(GargishTotem),
            typeof(InscriptionTalisman),
            typeof(HeavyAnchor),
            typeof(PunishmentStocks)
        };
        private static readonly Type[] Tier6Potions = {
            typeof(MahJongTile),
            typeof(AlchemyTalisman),
            typeof(CartographyTable),
            typeof(StrappedBooks),
            typeof(CarpentryTalisman),
            typeof(CharcuterieBoard),
            typeof(BottledPlague),
            typeof(NixieStatue),
            typeof(GrandmasSpecialRolls),
            typeof(ExoticFish),
            typeof(HildebrandtShield),
            typeof(GarbageBag),
            typeof(GlassOfBubbly),
            typeof(FishBasket),
            typeof(FineSilverWire),
            typeof(PlatinumChip),
            typeof(TribalHelm),
            typeof(GlassTable),
            typeof(WaterWell),
            typeof(RibbonAward),
            typeof(RookStone),
            typeof(AlchemistBookcase),
            typeof(ElementRegular),
            typeof(Satchel),
            typeof(LayingChicken),
            typeof(EssenceOfToad),
            typeof(SalvageMachine),
            typeof(TwentyfiveShield),
            typeof(DaggerSign),
            typeof(MultiPump),
            typeof(HeartPillow),
            typeof(HydroxFluid),
            typeof(MasterCello),
            typeof(DressForm),
            typeof(LargeWeatheredBook),
            typeof(WeddingCandelabra),
            typeof(DeckOfMagicCards),
            typeof(BrokenBottle),
            typeof(FancyHornOfPlenty),
            typeof(FineGoldWire),
            typeof(WaterRelic),
            typeof(EnchantedAnnealer)
        };
        private static readonly Type[] Tier7Potions = {
            typeof(BagOfBombs),
            typeof(BagOfHealth),
            typeof(BagOfJuice),
            typeof(BanishingOrb),
            typeof(BanishingRod),
            typeof(BeggarKingsCrown),
            typeof(BloodSword),
            typeof(BloodwoodAxe),
            typeof(GlovesOfTheGrandmasterThief),
            typeof(MagicMasterKey),
            typeof(PlantingGloves),
            typeof(QuickswordEnilno),
            typeof(RodOfOrcControl),
            typeof(ScryingOrb),
            typeof(SiegeHammer),
            typeof(SnoopersMasterScope),
            typeof(ThiefsGlove),
            typeof(TileExcavatorShovel),
            typeof(TomeOfTime),
            typeof(UniversalAbsorbingDyeTub)
        };
        private static readonly Type[] Tier8Potions = {
            typeof(LightLordsScepter),
            typeof(MasterBall),
            typeof(MasterWeaponOil),
            typeof(Pokeball),
            typeof(ShadowIronShovel),
            typeof(TrapGloves),
            typeof(TrapGorget),
            typeof(TrapLegs),
            typeof(TrapSleeves),
            typeof(TrapTunic),
            typeof(WeaponOil),
            typeof(WizardKey),
            typeof(YewAxe),
            typeof(AssassinsDagger)
        };
        private static readonly Type[] Tier9Potions = {
            typeof(BraceletOfNaturesBounty),
            typeof(CampersBackpack),
            typeof(ExtraPack),
            typeof(FrostwoodAxe),
            typeof(HeartwoodAxe),
            typeof(IcicleStaff)
        };
        private static readonly Type[] Tier10Potions = {
            typeof(BootsOfCommand),
            typeof(GlovesOfCommand),
            typeof(GrandmastersRobe),
            typeof(JesterHatOfCommand),
            typeof(PlateLeggingsOfCommand),
            typeof(AshAxe)
        };

        // ———— CTORS ————
        [Constructable]
        public UnidentifiedCuriosity() : base(0x9F6C) // bottle ID
        {
            Name = "Unidentified Curiosity";
        }

        [Constructable]
        public UnidentifiedCuriosity(int quality) : base(0x9F6C, quality)
        {
            Name = "Unidentified Curiosity";
        }

        public UnidentifiedCuriosity(Serial serial) : base(serial) { }

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
