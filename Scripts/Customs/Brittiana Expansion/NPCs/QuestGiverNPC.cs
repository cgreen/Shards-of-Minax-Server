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
    [CorpseName("the remains of a mysterious wanderer")]
    public class RandomQuestGiver : BaseCreature
    {
        private static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(30);
        private DateTime _nextQuestUtc = DateTime.MinValue;

        // ------------------- Equipment Pool copied from RandomNPC ------------------------
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

        // This is a trimmed-down version (add/remove slots/items as you wish)
		private static readonly Dictionary<string, SlotDef> _slotDefs = new Dictionary<string, SlotDef>( StringComparer.OrdinalIgnoreCase )
		{
			// almost always shoes
			{ "Footwear",   new SlotDef(0.95,
				 () => new Boots(), 
				 () => new Sandals(), 
				 () => new Shoes(),
				 () => new NinjaTabi(),
				 () => new FurBoots(),
				 () => new ThighBoots(),			 
				 () => new ElvenBoots(),
				 () => new SamuraiTabi(),
				 () => new Waraji(),	
				 () => new JesterShoes()			 
				 
			)},

			// robes only sometimes
			{ "Robe",       new SlotDef(0.25,
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
				 () => new FancyDress(),
				 () => new HoodedShroudOfShadows(),			 
				 () => new Epaulette()			 
			)},

			// cloak is rare
			{ "Back",       new SlotDef(0.10,
				 () => new Cloak(), 
				 () => new Quiver()
			)},

			// headgear
			{ "Head",       new SlotDef(0.50,
				 () => new FeatheredHat(), 
				 () => new JesterHat(), 
				 () => new FloppyHat(),
				 () => new Cap(),
				 () => new WideBrimHat(),
				 () => new StrawHat(),
				 () => new TallStrawHat(),
				 () => new WizardsHat(),
				 () => new Bonnet(),
				 () => new FeatheredHat(),
				 () => new TricorneHat(),
				 () => new JesterHat(),
				 () => new FloppyHat(),
				 () => new Bandana(),
				 () => new SkullCap(),
				 () => new Kasa(),
				 () => new ClothNinjaHood(),
				 () => new FlowerGarland(),
				 () => new Bandana(),
				 () => new BearMask(),
				 () => new DeerMask(),
				 () => new HornedTribalMask(),
				 () => new TribalMask(),
				 () => new OrcishKinMask(),
				 () => new OrcMask(),
				 () => new SavageMask(),
				 () => new ChefsToque(),
				 () => new Bascinet (),
				 () => new CloseHelm (),
				 () => new NorseHelm (),
				 () => new OrcHelm (),
				 () => new Helmet(),
				 () => new AssassinsCowl(),
				 () => new Bascinet(),
				 () => new ChainHatsuburi(),
				 () => new ChainCoif(),
				 () => new Circlet(),
				 () => new CloseHelm(),
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
				 () => new WingedHelm()			 
			)},

			// shirt / chest non‐armor
			{ "Shirt",      new SlotDef(0.75,
				 () => new FancyShirt(), 
				 () => new Tunic(), 
				 () => new BodySash(),
				 () => new Shirt(),
				 () => new ElvenShirt(),
				 () => new FormalShirt(),
				 () => new FancyShirt(),
				 () => new ClothNinjaJacket(),
				 () => new BodySash(),
				 () => new Doublet(),
				 () => new Tunic(),
				 () => new Surcoat(),
				 () => new JinBaori(),			 
				 () => new JesterSuit()			 
				 
			)},

			// chest armor
			{ "Chest",      new SlotDef(0.30,
				 () => new PlateChest(),
				 () => new RingmailChest (),
				 () => new ChainChest (),
				 () => new PlateChest (),
				 () => new LeatherChest(),
				 () => new FemaleLeatherChest (),
				 () => new FemalePlateChest (),
				 () => new StuddedChest (),
				 () => new BoneChest(),
				 () => new DragonChest(),
				 () => new DragonTurtleHideChest(),
				 () => new FemaleLeafChest(),
				 () => new FemaleLeatherChest(),
				 () => new FemalePlateChest(),
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
				 () => new LeatherChest()
			)},

			// legs
			{ "Legs",       new SlotDef(0.80,
				 () => new LongPants(), 
				 () => new ShortPants(),
				 () => new LeatherShorts(),			 
				 () => new ElvenPants(),
				 () => new HidePants(),
				 () => new LeatherNinjaPants(),
				 () => new TattsukeHakama(),
				 () => new PlateLegs (),
				 () => new LeatherLegs (),
				 () => new ChainLegs (),
				 () => new StuddedLegs (),
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
				 () => new WoodlandLegs()			 

			)},

			// skirt
			{ "Skirt",       new SlotDef(0.30,
				 () => new Skirt(),
				 () => new Kilt(),
				 () => new Hakama(),			 
				 () => new FurSarong(),
				 () => new TigerPeltLongSkirt(),
				 () => new GuildedKilt(),
				 () => new CheckeredKilt(),
				 () => new FancyKilt(),			 
				 () => new TigerPeltSkirt()			 

				 
			)},

			// arms
			{ "Arms",       new SlotDef(0.40,
				 () => new PlateArms(),
				 () => new StuddedBustierArms(),
				 () => new RingmailArms(),
				 () => new DragonArms(),
				 () => new LeafArms(),
				 () => new LeatherArms (),
				 () => new PlateArms (),
				 () => new StuddedArms (),
				 () => new WoodlandArms(),			 
				 () => new BoneArms(),
				 () => new DragonTurtleHideArms(),
				 () => new HidePauldrons(),
				 () => new LeatherBustierArms(),
				 () => new LeatherHiroSode(),
				 () => new PlateHiroSode(),
				 () => new StuddedHiroSode(),			 
				 () => new LeatherArms()
			)},

			// hands
			{ "Hands",      new SlotDef(0.50,
				 () => new LeatherGloves(),
				 () => new LeatherGloves (),
				 () => new PlateGloves (),
				 () => new StuddedGloves (),
				 () => new BoneGloves(),
				 () => new WoodlandGloves(),
				 () => new DragonGloves(),
				 () => new RingmailGloves(),
				 () => new StuddedGloves(),
				 () => new HideGloves(),
				 () => new LeafGloves(),
				 () => new PlateGloves(),			 
				 () => new LeatherNinjaMitts(),			 
				 () => new PlateGloves()
			)},

			// belt/apron
			{ "Belt",       new SlotDef(0.60,
				 () => new FullApron(),
				 () => new Obi(),
				 () => new WoodlandBelt(),			 
				 () => new HalfApron()
			)},

			// necklace/gorget
			{ "Neck",       new SlotDef(0.20,
				 () => new Necklace(),
				 () => new LeatherGorget (),
				 () => new PlateGorget (),
				 () => new StuddedGorget (),
				 () => new ElegantCollar(),
				 () => new HideGorget(),
				 () => new TigerPeltCollar(),
				 () => new WoodlandGorget(),
				 () => new LeafGorget(),			 
				 () => new LeatherGorget()
			)},

			// earrings (humans/elves only—you can check Female or race)
			{ "Earring",    new SlotDef(0.15,
				 () => new GoldEarrings()
			)},

			// bracelet
			{ "Bracelet",   new SlotDef(0.10,
				 () => new GoldBracelet()
			)},

			// ring
			{ "Ring",       new SlotDef(0.10,
				 () => new GoldRing()
			)},

			// talisman
			{ "Talisman",   new SlotDef(0.05,
				 () => new RandomTalisman()
			)},

			// right hand weapon/shield
			{ "RightHand",  new SlotDef(0.80,
				 () => new Longsword(),
				 () => new Broadsword (),
				 () => new Cutlass (),
				 () => new Katana (),
				 () => new Longsword (),
				 () => new Scimitar (),
				 () => new VikingSword(),
				 () => new Axe (),
				 () => new BattleAxe (),
				 () => new DoubleAxe (),
				 () => new ExecutionersAxe (),
				 () => new LargeBattleAxe(),
				 () => new TwoHandedAxe (),
				 () => new WarAxe (),
				 () => new Club (),
				 () => new HammerPick (),
				 () => new Mace (),
				 () => new Maul(),
				 () => new WarHammer (),
				 () => new WarMace (),
				 () => new Bardiche (),
				 () => new Halberd (),
				 () => new Lance (),
				 () => new Pike(),
				 () => new ShortSpear (),
				 () => new Spear (),
				 () => new WarFork (),
				 () => new CompositeBow (),
				 () => new Crossbow(),
				 () => new HeavyCrossbow (),
				 () => new RepeatingCrossbow (),
				 () => new Bow (),
				 () => new Dagger (),
				 () => new Kryss(),
				 () => new SkinningKnife (),
				 () => new ShortSpear (),
				 () => new Spear (),
				 () => new Pitchfork (),
				 () => new BlackStaff(),
				 () => new GnarledStaff (),
				 () => new QuarterStaff (),
				 () => new ShepherdsCrook (),
				 () => new BladedStaff(),
				 () => new Scythe(),
				 () => new Scepter (),
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
				 () => new Maul(),
				 () => new NoDachi(),
				 () => new Nunchaku(),
				 () => new Pickaxe(),
				 () => new Scythe(),
				 () => new Tekagi(),
				 () => new Tessen(),
				 () => new Tetsubo(),
				 () => new Wakizashi(),
				 () => new WildStaff(),
				 () => new Yumi(),			 
				 () => new Dagger()
			)},

			// left hand (off‐hand)
			{ "LeftHand",   new SlotDef(0.30,
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
				 () => new Torch()
			)},
		};

        // ------------------- Quest scroll constructors (see previous answer) ----------------
        private static readonly List<Func<Item>> _questFactories = new List<Func<Item>>
        {
            () => new CollectionQuestScroll(),
            () => new CollectionQuestScroll("Leather", 20, 5000),
            () => new CollectionQuestScroll(typeof(IronIngot), 30, 8000, typeof(Bottle)),

            () => new DeliveryQuestScroll(),
            () => new DeliveryQuestScroll("Rat Nemesis"),
            () => new DeliveryQuestScroll("Rat Nemesis", 2500),
            () => new DeliveryQuestScroll("Rat Nemesis", 2500, typeof(Bottle), typeof(Bandage)),

            () => new KillQuestScroll(),
            () => new KillQuestScroll("Dragon", 5, 12000),
            () => new KillQuestScroll(typeof(Orc), 15, 6000, typeof(BlackPearl)),

            () => new RegionKillQuestScroll(),
            () => new RegionKillQuestScroll("Destard", 12, 7200),
            () => new RegionKillQuestScroll("Wrong", 18, 9000, typeof(Bone)),

            () => new TamingQuestScroll(),
            () => new TamingQuestScroll("Horse", 3, 1500),
            () => new TamingQuestScroll(typeof(HellHound), 6, 5000, typeof(BlackPearl)),

            () => new FactionCollectionQuestScroll(),
            () => new FactionCollectionQuestScroll("Leather", 25, "Humanoid", 750),
            () => new FactionCollectionQuestScroll("IronIngot", 40, XmlMobFactions.GroupTypes.Player, 1200),
            () => new FactionCollectionQuestScroll(typeof(Log), 15, XmlMobFactions.GroupTypes.Humanoid, 500, typeof(Bottle)),

            () => new FactionDeliveryQuestScroll("Rat Nemesis", "Humanoid", 250),
            () => new FactionDeliveryQuestScroll("Rat Nemesis", "Humanoid", "400"),
            () => new FactionDeliveryQuestScroll(),
            () => new FactionDeliveryQuestScroll("Rat Nemesis"),
            () => new FactionDeliveryQuestScroll("Rat Nemesis", XmlMobFactions.GroupTypes.Humanoid, 300),
            () => new FactionDeliveryQuestScroll("Rat Nemesis", XmlMobFactions.GroupTypes.Undead, 450, typeof(Bottle)),

            () => new FactionKillQuestScroll(),
            () => new FactionKillQuestScroll("Dragon", "5", "Humanoid", "500"),
            () => new FactionKillQuestScroll("Dragon", 5, "Humanoid", 500),
            () => new FactionKillQuestScroll("Dragon", 5, XmlMobFactions.GroupTypes.Humanoid, 500),
            () => new FactionKillQuestScroll(typeof(OrcCaptain), 12, XmlMobFactions.GroupTypes.Humanoid, 900, typeof(Bandage)),

            () => new FactionRegionKillQuestScroll(),
            () => new FactionRegionKillQuestScroll("Covetous", 16, XmlMobFactions.GroupTypes.Humanoid, 800, typeof(BlackPearl)),
            () => new FactionRegionKillQuestScroll(XmlMobFactions.GroupTypes.Player, 600, typeof(Bottle)),

            () => new FactionTamingQuestScroll(),
            () => new FactionTamingQuestScroll(XmlMobFactions.GroupTypes.Player, 350),
            () => new FactionTamingQuestScroll(typeof(HellCat), 4, XmlMobFactions.GroupTypes.Humanoid, 700, typeof(Bone)),
        };

        // ------------------- Random appearance/stats/name/etc ----------------
        [Constructable]
        public RandomQuestGiver()
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
				Name  = parts[0] + " " + parts[1]; // first + last
				Title = parts.Length > 2 ? parts[2] : "";
			}
			else
			{
				Name = fullName;
				Title = "";
			}
            SetStr(Utility.RandomMinMax(50, 100));
            SetDex(Utility.RandomMinMax(50, 100));
            SetInt(Utility.RandomMinMax(50, 100));
            SpeechHue = Utility.RandomMinMax(1, 2999);
        }

		private static string GenerateRandomName()
		{
			string[] firstNames = new[]
			{
				"Arin", "Bryn", "Calen", "Dara", "Eamon", "Fara", "Galen", "Hale", "Iris", "Jorin",
				"Kael", "Lira", "Mira", "Nerys", "Orin", "Perrin", "Quinn", "Rhea", "Soren", "Talia",
				"Ulric", "Vera", "Wren", "Xander", "Yara", "Zane", "Alaric", "Blaise", "Celia", "Dorian",
				"Elara", "Finn", "Greta", "Hadrian", "Isolde", "Jace", "Kara", "Luna", "Marek", "Nina",
				"Oren", "Petra", "Quint", "Riven", "Selene", "Theron", "Una", "Vance", "Willow", "Xenia",
				"Ysolde", "Zara", "Alden", "Brynna", "Cyrus", "Daphne", "Emrys", "Faelan", "Giselle", "Hector",
				"Imara", "Jorah", "Kellan", "Lyra", "Magnus", "Nola", "Olivier", "Persephone", "Quilla", "Ragnar",
				"Seren", "Tamsin", "Uriel", "Vesper", "Wynn", "Xavi", "Yvette", "Zion", "Alina", "Barin",
				"Cedric", "Daria", "Elias", "Fiona", "Gareth", "Helena", "Ilan", "Jessa", "Kiran", "Lys",
				"Malik", "Nara", "Odelia", "Pax", "Quinn", "Rhea", "Sylas", "Tove", "Ula", "Vion",
				"Willa", "Xander", "Yara", "Zephyr", "Ash", "Bren", "Cora", "Dain", "Elin", "Fynn",
				"Greer", "Hale", "Isla", "Jace", "Kaia", "Lior", "Mira", "Niko", "Orla", "Perrin",
				"Quin", "Riven", "Sage", "Talia", "Una", "Vale", "Wren", "Xia", "Yven", "Zane",
				"Aeris", "Balin", "Corin", "Drea", "Eira", "Finn", "Galen", "Hira", "Ivor", "Jara",
				"Keir", "Lana", "Milo", "Niamh", "Oren", "Pia", "Quill", "Runa", "Soren", "Tess",
				"Uriah", "Vela", "Wren", "Xan", "Yara", "Zuri", 
				"Aethelred", "Aethelstan", "Aelfric", "Aelfwine", "Aelfwynn", "Aethelthryth", "Alfred", "Alfward", "Alhheard", "Alhstan", "Beorn", "Beornwulf", "Beorhtwulf", "Beorhthelm",
				"Beorhtwine", "Burgred", "Ceawlin", "Ceolwulf", "Ceolmund", "Ceolred", "Ceorl", "Cuthbert", "Cuthred", "Cuthwine", "Cynesige", "Cynric", "Cynewulf", "Daegberht", "Dudda",
				"Dunstan", "Eadburh", "Eadfrith", "Eadgar", "Eadgifu", "Eadmund", "Eadric", "Eadward", "Eadwig", "Eadwine", "Ealdgyth", "Ealhstan", "Eanflæd", "Eanmund", "Eanred",
				"Eardwulf", "Ecgwynn", "Edith", "Edmund", "Edward", "Edwin", "Egbert", "Elfrida", "Ella", "Elfleda", "Elfwine", "Elystan", "Eormenred", "Eormenhild", "Ethelbert",
				"Ethelburh", "Etheldreda", "Ethelred", "Ethelstan", "Ethelwin", "Ethelwold", "Ethelwulf", "Frithuwald", "Frithuswith", "Godgifu", "Godwin", "Guthlac", "Harold",
				"Hereward", "Hilda", "Hrothgar", "Kenelm", "Leofric", "Leofwine", "Leofsige", "Leofwaru", "Mildburg", "Mildgyth", "Mildred", "Odo", "Offa", "Osbeorn", "Osburh",
				"Osfrith", "Osgar", "Osmund", "Osred", "Osric", "Oswald", "Oswine", "Oswulf", "Otta", "Saeward", "Saewulf", "Sigeberht", "Sigeferth", "Sigebehrt", "Sigefrith",
				"Sigebald", "Sigebeald", "Sigewine", "Sigeweard", "Sigewulf", "Stigand", "Swithun", "Theodric", "Thored", "Thurstan", "Uhtred", "Unferth", "Waerburh", "Waerheard",
				"Waerstan", "Weland", "Werferth", "Wiglaf", "Wulfric", "Wulfstan", "Wulfsige", "Wulfthryth", "Wulfrun", "Wulfwynn", "Wynnflæd", "Aethelgifu", "Aethelhild",
				"Aethelwynn", "Aldhelm", "Aldred", "Aldwulf", "Aethelmod", "Aethelheard", "Aethelweard", "Aethelwald", "Aethelthryth", "Aethelhild", "Aethelburh", "Aelfhild",
				"Aelfgifu", "Aelfrida", "Aelfleda", "Aethelgyth", "Aethelrun", "Beorhtgyth", "Ceolwynn", "Cuthburg", "Cwenburh", "Eadgifu", "Eadgyth", "Eadwynn", "Ealdgith",
				"Ealhswith", "Eanflaed", "Edburga", "Edgitha", "Elditha", "Elgiva", "Eormenhild", "Godith", "Godgifu", "Leofe", "Leofrun", "Leofsige", "Mildryth", "Osgifu",
				"Osthryth", "Oswynn", "Saewynn", "Sigeburh", "Sigegifu", "Sigewynn", "Wulfgifu", "Wulfrun", "Wulfgifu", "Wulfsige", "Wulfwaru", "Wynnflaed"				
			};

			string[] lastNames = new[]
			{
				"Alderton",
				"Smith", "Ironfist", "Stormrider", "Windwalker", "Nightshade", "Duskbane", "Flameheart", "Ravenwood",
				"Ashbane", "Shadowalker", "Moonwhisper", "Stoneforge", "Dawnbringer", "Frosthammer", "Silverblade",
				"Darkwater", "Fireforge", "Stormcaller", "Brightshield", "Grimshadow", "Ironheart", "Thunderstrike",
				"Blackthorn", "Silvershield", "Windrider", "Shadowbane", "Wolfclaw", "Steelbreaker", "Nightfall",
				"Mistborn", "Bloodraven", "Stormcloak", "Ironwolf", "Darkmoon", "Goldmane", "Silvermoon", "Ashenforge",
				"Frostborn", "Shadowfire", "Ironclad", "Brightblade", "Thunderhoof", "Stonefist", "Moonblade",
				"Windshadow", "Firebrand", "Duskwood", "Blackwater", "Stormborn", "Ironfang", "Silentfoot",
				"Graveborn", "Nightstalker", "Stormforge", "Ironhelm", "Dawnshadow", "Firesong", "Silverwing",
				"Darkflame", "Stonebreaker", "Moonshadow", "Ashwalker", "Stormwatcher", "Ironthorn", "Shadowstrike",
				"Flameborn", "Blackwolf", "Frostwing", "Windraven", "Ironbane", "Nightblade", "Thunderheart",
				"Stonecloak", "Darkfang", "Silversong", "Firewalker", "Moonstrike", "Stormfang", "Ironshadow",
				"Brightstorm", "Shadowclaw", "Wolfbane", "Steelshadow", "Nightstorm", "Mistwalker", "Bloodfang",
				"Stormraven", "Ironstorm", "Darkshield", "Goldblade", "Silverstorm", "Ashenblade", "Frostshadow",
				"Shadowbane", "Ironstrike", "Brightfang", "Thunderclaw", "Stoneheart", "Moonrider", "Windblade",
				"Firestorm", "Duskfang", "Blackhammer", "Stormclaw", "Ironwing", "Silentstorm", "Gravewalker",
				"Nightfire", "Stormbane", "Ironclaw", "Dawnfire", "Fireshadow", "Silverfang", "Darkrider",
				"Stonefang", "Moonwalker", "Ashenfang", "Stormrider", "Ironwalker", "Shadowrider", "Flameshield",
				"Blackfire", "Frostclaw", "Windstorm", "Ironraven", "Nightwing", "Thunderstrike", "Stonewalker",
				"Darkraven", "Silverbane", "Firefang", "Moonclaw", "Stormshadow", "Ironfire", "Brightrider",				
				"Appleton",
				"Ashdown",
				"Ashfield",
				"Ashworth",
				"Atwood",
				"Baldwin",
				"Bancroft",
				"Bardsley",
				"Barrow",
				"Barton",
				"Beaumont",
				"Beldon",
				"Benton",
				"Blackwood",
				"Blakeslee",
				"Blakesley",
				"Blanchard",
				"Blythe",
				"Bosworth",
				"Bradford",
				"Bradley",
				"Branston",
				"Brayton",
				"Brentwood",
				"Bridgeman",
				"Briarwood",
				"Bromley",
				"Brookfield",
				"Brookshire",
				"Buckland",
				"Buckley",
				"Burton",
				"Bywater",
				"Camden",
				"Carling",
				"Chadwick",
				"Chamberlain",
				"Chandler",
				"Chapman",
				"Chilton",
				"Clayden",
				"Clifton",
				"Cromwell",
				"Dalton",
				"Darcy",
				"Darlington",
				"Davenport",
				"Denholm",
				"Denman",
				"Devonshire",
				"Digby",
				"Dudley",
				"Dunstan",
				"Eastwood",
				"Eddington",
				"Eldridge",
				"Ellington",
				"Ellis",
				"Elwood",
				"Fairfax",
				"Fairchild",
				"Fairweather",
				"Falkner",
				"Fanshawe",
				"Farley",
				"Farnsworth",
				"Fenwick",
				"Fielding",
				"Fitzroy",
				"Fleetwood",
				"Foxley",
				"Frost",
				"Gainsborough",
				"Goddard",
				"Godwin",
				"Goodwin",
				"Greenwood",
				"Grimsby",
				"Grove",
				"Hadley",
				"Hale",
				"Hampton",
				"Hargrove",
				"Harrington",
				"Hartley",
				"Harwood",
				"Hastings",
				"Hawthorne",
				"Hayden",
				"Hayes",
				"Hemingway",
				"Henley",
				"Henshaw",
				"Hickman",
				"Hightower",
				"Hollingworth",
				"Holmes",
				"Hornby",
				"Howell",
				"Huxley",
				"Kendrick",
				"Kenwood",
				"Kingsley",
				"Kinsley",
				"Langley",
				"Langston",
				"Larkspur",
				"Latham",
				"Laxton",
				"Layton",
				"Leighton",
				"Lockwood",
				"Loxley",
				"Lyndon",
				"Mansfield",
				"Markham",
				"Marlow",
				"Marwood",
				"Mayhew",
				"Merrick",
				"Middleton",
				"Milton",
				"Montague",
				"Montgomery",
				"Moore",
				"Morley",
				"Nash",
				"Nettleton",
				"Norwood",
				"Oakley",
				"Osborne",
				"Oswald",
				"Overton",
				"Parker",
				"Parsons",
				"Pemberton",
				"Pendleton",
				"Pennington",
				"Pickering",
				"Pike",
				"Radcliffe",
				"Radley",
				"Ravenwood",
				"Redfern",
				"Redgrave",
				"Redmond",
				"Redwood",
				"Ridley",
				"Ridgway",
				"Rochester",
				"Rockwell",
				"Rowley",
				"Rowntree",
				"Rutherford",
				"Rycroft",
				"Salisbury",
				"Sanderson",
				"Sedgwick",
				"Selwyn",
				"Sheffield",
				"Shelton",
				"Sherburne",
				"Sheridan",
				"Sherwood",
				"Shirley",
				"Shrewsbury",
				"Sinclair",
				"Smallwood",
				"Somerset",
				"Spalding",
				"Stafford",
				"Stanford",
				"Stanhope",
				"Stanley",
				"Stanton",
				"Statham",
				"Stonebridge",
				"Stonefield",
				"Stoughton",
				"Stratford",
				"Stroud",
				"Summers",
				"Sutton",
				"Swann",
				"Swinton",
				"Sydenham",
				"Tanner",
				"Templeton",
				"Thatcher",
				"Thornbury",
				"Thornhill",
				"Thornton",
				"Thurlow",
				"Tillinghast",
				"Townsend",
				"Trentham",
				"Trueman",
				"Turner",
				"Underwood",
				"Wakefield",
				"Wainwright",
				"Wakeley",
				"Waldron",
				"Wallace",
				"Walpole",
				"Walton",
				"Warburton",
				"Ward",
				"Waring",
				"Warrick",
				"Warwick",
				"Washburn",
				"Waterman",
				"Waterworth",
				"Weatherby",
				"Wellman",
				"Wesley",
				"Westcott",
				"Weston",
				"Wharton",
				"Wheaton",
				"Whitaker",
				"Whitby",
				"Whitfield",
				"Whitley",
				"Whitmore",
				"Wilcox",
				"Wilkinson",
				"Willoughby",
				"Wilmot",
				"Windsor",
				"Winfield",
				"Winterbourne",
				"Withers",
				"Woodford",
				"Woodruff",
				"Woodward",
				"Wycliffe",
				"Wyndham",
				"Yarborough"
			};


			string[] titles = new[]
			{
				"the Blacksmith", "the Wise", "of the North", "Lord of Rivers", "the Seer", "Warden of Shadows", "Mistress of Blades", "the Wanderer", "Keeper of Secrets",
				"the Blacksmith",
				"the Cooper",
				"the Fletcher",
				"the Thatcher",
				"the Reeve",
				"the Steward",
				"the Scribe",
				"the Falconer",
				"the Miller",
				"the Weaver",
				"the Wainwright",
				"the Mason",
				"the Tinker",
				"the Carter",
				"the Brewer",
				"the Potter",
				"the Tanner",
				"the Chandler",
				"the Dyer",
				"the Mercer",
				"the Bowyer",
				"the Piper",
				"the Minstrel",
				"the Jester",
				"the Herald",
				"the Huntsman",
				"the Fletcher",
				"the Carpenter",
				"the Gardener",
				"the Harbinger",
				"the Squire",
				"the Page",
				"the Chamberlain",
				"the Bailiff",
				"the Provost",
				"the Burgess",
				"the Seneschal",
				"the Warden",
				"the Bailiff",
				"the Beadle",
				"the Goodman",
				"the Goodman of the Vale",
				"the Goodman of the Glen",
				"the Goodman of the Moor",
				"the Goodman of the Heath",
				"the Knight of the Realm",
				"the Dame of the Court",
				"the Lord of the Manor",
				"the Lady of the Lake",
				"the Baron of the Marches",
				"the Baroness of the Reach",
				"the Viscount of the Hills",
				"the Viscountess of the Glade",
				"the Earl of the Downs",
				"the Count of the Woodlands",
				"the Countess of the Riverlands",
				"the Duke of the North",
				"the Duchess of the South",
				"the Marquess of the East",
				"the Marchioness of the West",
				"the Prior",
				"the Prioress",
				"the Abbot",
				"the Abbess",
				"the Friar",
				"the Nun",
				"the Parson",
				"the Vicar",
				"the Chaplain",
				"the Sexton",
				"the Pilgrim",
				"the Wayfarer",
				"the Wanderer",
				"the Outrider",
				"the Watchman",
				"the Yeoman",
				"the Forester",
				"the Sheriff",
				"the Constable",
				"the Marshall",
				"the Sergeant",
				"the Captain of the Guard",
				"the Gatekeeper",
				"the Castellan",
				"the Almoner",
				"the Apothecary",
				"the Barber",
				"the Physician",
				"the Midwife",
				"the Crofter",
				"the Herdsman",
				"the Shepherd",
				"the Ploughman",
				"the Swineherd",
				"the Cowherd",
				"the Carter",
				"the Ostler",
				"the Groom",
				"the Falconer",
				"the Huntsman",
				"the Fisherman",
				"the Sailor",
				"the Mariner",
				"the Shipwright",
				"the Innkeeper",
				"the Tavernkeeper",
				"the Alewife",
				"the Cook",
				"the Scullion",
				"the Steward of the Hall",
				"the Castellan of the Keep",
				"the Bellman",
				"the Town Crier",
				"the Scrivener",
				"the Cutler",
				"the Spicer",
				"the Merchant",
				"the Pedlar",
				"the Chandler",
				"the Draper",
				"the Glover",
				"the Hosier",
				"the Laird of the Fells",
				"the Lady of the Dale",
				"Master of the Forge",
				"Master of the Hunt",
				"Master of Revels",
				"Master of the Wardrobe",
				"Master of the Horse",
				"Master of the Hounds",
				"Master of the Lists",
				"Master of Coin",
				"Master of Arms",
				"Mistress of the Loom",
				"Mistress of Herbs",
				"Mistress of the Pantry",
				"Mistress of the Cellar",
				"Mistress of the Robes",
				"Mistress of the Keys",
				"Guardian of the Gate",
				"Guardian of the Forest",
				"Guardian of the Bridge",
				"Warden of the North",
				"Warden of the South",
				"Warden of the Marches",
				"Warden of the Grain",
				"Warden of the Wood",
				"Warden of the Road",
				"Bearer of the Seal",
				"Bearer of Tidings",
				"Bearer of the Standard",
				"Bearer of the Ring",
				"Bearer of the Sword",
				"Bearer of the Cup",
				"Bearer of the Crown",
				"Bearer of the Light",
				"Seeker of Truth",
				"Seeker of Lore",
				"Seeker of Fortune",
				"Keeper of Secrets",
				"Keeper of the Books",
				"Keeper of the Flame",
				"Keeper of the Keys",
				"Keeper of the Peace",
				"Keeper of the Hounds",
				"Keeper of the Bridge",
				"Lord of the Manor",
				"Lady of the Manor",
				"Lord of the Isles",
				"Lady of the Isles",
				"Lord of the Greenwood",
				"Lady of the Greenwood",
				"Lord of the Fens",
				"Lady of the Fens",
				"Lord of the Highlands",
				"Lady of the Highlands",
				"Knight Errant",
				"Knight of the Realm",
				"Knight of the Sword",
				"Knight of the Cross",
				"Witchfinder",
				"Witch of the Woods",
				"Cunning Man",
				"Wise Woman",
				"Sage of the Hills",
				"Sage of the Glen",
				"Oracle of the Stones",
				"Oracle of the Lake",
				"Prophet of the Moon",
				"Prophetess of the Sun",
				"Mage of the Tower",
				"Enchantress of the Vale",
				"Scholar of the Quill",
				"Scholar of the Stars",
				"Loremaster",
				"Runecaster",
				"Chronicler",
				"Harper",
				"Minstrel of the Hall",
				"Bard of the Marches",
				"Poet of the Court"				
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
                    item.Hue = Utility.RandomMinMax(1, 3000);
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
                player.SendMessage("Here, take this quest scroll!");
                _nextQuestUtc = DateTime.UtcNow + Cooldown;
            }
        }

        private class QuestEntry : ContextMenuEntry
        {
            private readonly RandomQuestGiver _npc;
            private readonly Mobile _from;

            public QuestEntry(Mobile from, RandomQuestGiver npc)
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
        public RandomQuestGiver(Serial serial) : base(serial) { }

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
