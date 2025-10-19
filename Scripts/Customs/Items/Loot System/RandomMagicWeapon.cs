using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.XmlSpawner2;
using System.Collections.Generic;

#region  RANDOM‑MAGIC‑WEAPON  (the placeholder)
/*  ░ RandomMagicWeapon ░  – A lightweight “seed” item that instantly
 *    replaces itself with a real weapon of the chosen tier.            */
public class RandomMagicWeapon : Item
{
    private int _tier;   // 1‑7

    /* Default: pick a tier using the factory’s weighted table */
    [Constructable]
    public RandomMagicWeapon() : this(RandomMagicWeaponFactory.GetWeightedRandomTier()) { }

    /* Alternate: caller decides the tier */
    [Constructable]
    public RandomMagicWeapon(int tier) : base(0x1F14)
    {
        _tier = Math.Max(1, Math.Min(7, tier));   // hard‑clamp
        Name     = $"Random Magic Weapon (T{_tier})";
        LootType = LootType.Blessed;

        Timer.DelayCall(TimeSpan.FromSeconds(0.1), TransformWeapon);
    }

    public RandomMagicWeapon(Serial serial) : base(serial) { }

    private void TransformWeapon()
    {
        if (Deleted) return;

        BaseWeapon wpn = RandomMagicWeaponFactory.CreateRandomMagicWeapon(_tier);

        if (Parent is Container c)
            c.AddItem(wpn);
        else
            wpn.MoveToWorld(Location, Map);

        Delete();   // remove the seed
    }

    /* ===== persistence ===== */
    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write(0);          // version
        writer.Write(_tier);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        _tier = reader.ReadInt();

        Timer.DelayCall(TimeSpan.FromSeconds(0.1), TransformWeapon);
    }
}
#endregion

#region  RANDOM‑MAGIC‑WEAPON‑FACTORY
public static class RandomMagicWeaponFactory
{
    /* ───────────────── Tier configuration table ─────────────────── */
    private class TierConfig
    {
        public int MinEffects, MaxEffects;     // # of special WeaponAttributes
        public int MinSkillBns, MaxSkillBns;   // # of SkillBonus entries
        public int AtkMin, AtkMax;             // AttackChance roll
        public int DefMin, DefMax;             // DefendChance roll
        public int MinDmgMin, MinDmgMax;       // MinDamage roll
        public int MaxDmgMin, MaxDmgMax;       // MaxDamage roll
        public int ResMin, ResMax;             // Resist* bonus roll
    }

    /* Index 0 ⇒ tier1, 1 ⇒ tier2, … 6 ⇒ tier7 */
    private static readonly TierConfig[] _tier =
    {
        /*  T1 */ new TierConfig{MinEffects=0, MaxEffects=1, MinSkillBns=0, MaxSkillBns=1,
                                AtkMin=1,  AtkMax=10,  DefMin=1,  DefMax=10,
                                MinDmgMin=1,  MinDmgMax=15, MaxDmgMin=15, MaxDmgMax=30,
                                ResMin=1,  ResMax=5},

        /*  T2 */ new TierConfig{MinEffects=1, MaxEffects=2, MinSkillBns=1, MaxSkillBns=2,
                                AtkMin=5,  AtkMax=15,  DefMin=5,  DefMax=15,
                                MinDmgMin=5,  MinDmgMax=20, MaxDmgMin=20, MaxDmgMax=40,
                                ResMin=1,  ResMax=7},

        /*  T3 */ new TierConfig{MinEffects=2, MaxEffects=3, MinSkillBns=1, MaxSkillBns=2,
                                AtkMin=10, AtkMax=20, DefMin=10, DefMax=20,
                                MinDmgMin=10, MinDmgMax=25, MaxDmgMin=25, MaxDmgMax=50,
                                ResMin=2,  ResMax=9},

        /*  T4 */ new TierConfig{MinEffects=2, MaxEffects=4, MinSkillBns=2, MaxSkillBns=3,
                                AtkMin=15, AtkMax=30, DefMin=15, DefMax=30,
                                MinDmgMin=15, MinDmgMax=35, MaxDmgMin=35, MaxDmgMax=65,
                                ResMin=3,  ResMax=12},

        /*  T5 */ new TierConfig{MinEffects=3, MaxEffects=5, MinSkillBns=2, MaxSkillBns=4,
                                AtkMin=20, AtkMax=40, DefMin=20, DefMax=40,
                                MinDmgMin=20, MinDmgMax=45, MaxDmgMin=45, MaxDmgMax=80,
                                ResMin=4,  ResMax=14},

        /*  T6 */ new TierConfig{MinEffects=4, MaxEffects=6, MinSkillBns=3, MaxSkillBns=4,
                                AtkMin=25, AtkMax=50, DefMin=25, DefMax=50,
                                MinDmgMin=25, MinDmgMax=55, MaxDmgMin=55, MaxDmgMax=100,
                                ResMin=5,  ResMax=16},

        /*  T7 */ new TierConfig{MinEffects=5, MaxEffects=7, MinSkillBns=4, MaxSkillBns=5,
                                AtkMin=30, AtkMax=60, DefMin=30, DefMax=60,
                                MinDmgMin=30, MinDmgMax=70, MaxDmgMin=70, MaxDmgMax=120,
                                ResMin=6,  ResMax=18},
    };

    /* ───────────────── weighted rarity (sum = 100) ───────────────── */
	private static readonly Tuple<int, int>[] _tiersWithWeight =
	{
		Tuple.Create(1, 40),
		Tuple.Create(2, 25),
		Tuple.Create(3, 15),
		Tuple.Create(4, 10),
		Tuple.Create(5, 6),
		Tuple.Create(6, 3),
		Tuple.Create(7, 1)
	};


	public static int GetWeightedRandomTier()
	{
		int roll = _rand.Next(100);
		int cumulative = 0;
		foreach (var pair in _tiersWithWeight)
		{
			cumulative += pair.Item2;
			if (roll < cumulative)
				return pair.Item1;
		}
		return 1;
	}


    /* ───────────────── public factory ─────────────────────────────── */
	public static BaseWeapon CreateRandomMagicWeapon(int tier)
	{
		tier = Math.Max(1, Math.Min(7, tier));
		TierConfig cfg = _tier[tier - 1];

		/* pick weapon, name & hue */
		Type wType = _weaponTypes[_rand.Next(_weaponTypes.Length)];
		BaseWeapon wpn = (BaseWeapon)Activator.CreateInstance(wType);

		wpn.ItemID = GetItemID(wType);
		wpn.Name   = $"{_prefixes[_rand.Next(_prefixes.Length)]} {_suffixes[_rand.Next(_suffixes.Length)]}";
		wpn.Hue    = _rand.Next(1, 3001);

		/* base attributes that scale with tier */
		wpn.Attributes.AttackChance = _rand.Next(cfg.AtkMin, cfg.AtkMax + 1);
		wpn.Attributes.DefendChance = _rand.Next(cfg.DefMin, cfg.DefMax + 1);
		wpn.Attributes.SpellChanneling = 1;
		wpn.WeaponAttributes.DurabilityBonus = _rand.Next(1, 25);

		wpn.MinDamage = _rand.Next(cfg.MinDmgMin, cfg.MinDmgMax + 1);
		wpn.MaxDamage = _rand.Next(cfg.MaxDmgMin, cfg.MaxDmgMax + 1);
		wpn.Speed = (float)Math.Round(_rand.NextDouble() * 9.9 + 0.1, 1);

		// now treat the resists as just more random effects:
		AddRandomEffects(wpn, cfg);
		AddSkillBonuses  (wpn, cfg);

		XmlAttach.AttachTo(wpn, new XmlSockets(_rand.Next(tier - 1, tier + 1)));
		return wpn;
	}

	private static void AddRandomEffects(BaseWeapon wpn, TierConfig cfg)
	{
		var effects = new List<Action>
		{
			() => wpn.WeaponAttributes.HitLightning     = _rand.Next(1, 51),
			() => wpn.WeaponAttributes.HitFireball      = _rand.Next(1, 41),
			() => wpn.WeaponAttributes.HitHarm          = _rand.Next(1, 31),
			() => wpn.WeaponAttributes.HitMagicArrow    = _rand.Next(1, 21),
			() => wpn.WeaponAttributes.HitDispel        = _rand.Next(1, 21),
			() => wpn.WeaponAttributes.HitColdArea      = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.HitFireArea      = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.HitPoisonArea    = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.HitEnergyArea    = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.HitPhysicalArea  = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.HitLeechHits     = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.HitLeechMana     = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.HitLeechStam     = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.HitLowerAttack   = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.HitLowerDefend   = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.UseBestSkill     = 1,
			() => wpn.WeaponAttributes.MageWeapon       = _rand.Next(-10, 11),
			() => wpn.WeaponAttributes.LowerStatReq     = _rand.Next(1, 26),
			() => wpn.WeaponAttributes.SelfRepair       = _rand.Next(1, 6),
			// ← new: resist‐bonuses now in the same pool
			() => wpn.WeaponAttributes.ResistPhysicalBonus = _rand.Next(cfg.ResMin, cfg.ResMax + 1),
			() => wpn.WeaponAttributes.ResistFireBonus     = _rand.Next(cfg.ResMin, cfg.ResMax + 1),
			() => wpn.WeaponAttributes.ResistColdBonus     = _rand.Next(cfg.ResMin, cfg.ResMax + 1),
			() => wpn.WeaponAttributes.ResistPoisonBonus   = _rand.Next(cfg.ResMin, cfg.ResMax + 1),
			() => wpn.WeaponAttributes.ResistEnergyBonus   = _rand.Next(cfg.ResMin, cfg.ResMax + 1)
		};

		int toAdd = _rand.Next(cfg.MinEffects, cfg.MaxEffects + 1);
		for (int i = 0; i < toAdd && effects.Count > 0; i++)
		{
			int idx = _rand.Next(effects.Count);
			effects[idx]();
			effects.RemoveAt(idx);
		}
	}



	private static void AddSkillBonuses(BaseWeapon wpn, TierConfig cfg)
	{
		int slots = _rand.Next(cfg.MinSkillBns, cfg.MaxSkillBns + 1);
		List<SkillName> pool = new List<SkillName>(_allSkills);

		for (int i = 0; i < slots && pool.Count > 0; i++)
		{
			int idx = _rand.Next(pool.Count);
			SkillName skill = pool[idx];
			pool.RemoveAt(idx);

			int amt = _rand.Next(1 + cfg.MinEffects, 5 + cfg.MaxEffects);
			wpn.SkillBonuses.SetValues(i, skill, amt);
		}
	}


    private static int GetItemID(Type t)
    {
        BaseWeapon tmp = (BaseWeapon)Activator.CreateInstance(t);
        int id = tmp.ItemID;
        tmp.Delete();
        return id;
    }

    /* ───────────────── static data ───────────────────────────────── */
    private static readonly Random _rand = new Random();

    private static readonly string[] _prefixes = { "Mighty", "Powerful", "Mystic", "Enchanted", "Arcane", "Enchanted", "Mystical", "Elemental", "Eternal", "Infernal", "Celestial", "Eldritch", "Spectral", "Tempest", "Frozen", "Blazing", "Thunder", "Shadow", "Radiant", "Dark", "Light", "Phantom", "Void", "Ethereal", "Necrotic", "Divine", "Astral", "Prismatic", "Runic", "Venomous", "Frost", "Storm", "Invisible", "Invincible", "Majestic", "Cursed", "Blessed", "Soulbound", "Vortex", "Twilight", "Dawn", "Dusk", "Starforged", "Moonlit", "Sunflare", "Comet", "Eclipse", "Galactic", "Cosmic", "Dimensional", "Temporal", "Spatial", "Quantum", "Mythic", "Legendary", "Ancient", "Primordial", "Forgotten", "Unseen", "Chaos", "Harmony", "Balance", "Rage", "Serenity", "Oblivion", "Creation", "Destruction", "Rebirth", "Fate", "Dream", "Nightmare", "Illusion", "Reality", "Vision", "Ghostly", "Glorious", "Sacred", "Unholy", "Vigilant", "Warrior's", "Sorcerer's", "Seer's", "Dragon's", "Titan's", "Phoenix", "Demonic", "Angelic", "Heavenly", "Abyssal", "Solar", "Lunar", "Stellar", "Voidwalker's", "Battleworn", "Savage", "Berserker's", "Monarch's", "Guardian's", "Pirate's", "Royal", "Revenant", "Warden's", "Spectral", "Stormbringer's", "Windwalker's", "Flamebearer's", "Icewrought", "Thunderous", "Stoneskin", "Nature's", "Beastmaster's", "Shamanic", "Witch's", "Siren's", "Mercurial", "Adamant", "Sylvan", "Arcanist's", "Noble", "Explorer's", "Sentry's", "Ranger's", "Corsair's", "Assassin's", "Necromancer's", "Paladin's", "Rogue's", "Cleric's", "Elementalist's", "Chronomancer's", "Geomancer's", "Pyromancer's", "Hydromancer's", "Aeromancer's", "Biomancer's", "Cybernetic", "Technomancer's", "Alchemist's", "Summoner's", "Psionic", "Sage's", "Prophet's", "Martyr's", "Zealot's", "Reclaimer's", "Pioneer's", "Innovator's", "Vindicator's", "Arbiter's", "Sentinel's", "Defender's", "Avenger's", "Champion's", "Conqueror's", "Master's", "Primeval", "Arcadian", "Myrmidon's", "Valkyrie's", "Bard's", "Jester's", "Gladiator's", "Knight's", "Samurai's", "Ninja's", "Viking's", "Pilgrim's", "Hermit's", "Sculptor's", "Painter's", "Poet's", "Minstrel's", "Troubadour's", "Wanderer's", "Explorer's", "Adventurer's", "Seeker's", "Scholar's", "Philosopher's", "Oracle's", "Muse's", "Mystic's", "Seer's", "Soothsayer's", "Prognosticator's", "Diviner's", "Augur's", "Sibyl's", "Clairvoyant's", "Telepath's", "Empath's", "Psychic's", "Medium's", "Spiritualist's", "Channeler's", "Shapeshifter's", "Transformer's", "Metamorph's", "Changeling's", "Morpher's", "Transmuter's", "Alchemist's", "Chemist's", "Potioneer's", "Apothecary's", "Herbalist's", "Botanist's", "Horticulturist's", "Agronomist's", "Cultivator's", "Farmer's", "Gardener's", "Landscaper's", "Arborist's", "Forester's", "Logger's", "Woodcutter's", "Carpenter's", "Joiner's", "Cabinetmaker's", "Woodworker's", "Craftsman's", "Artisan's", "Maker's", "Creator's", "Inventor's", "Designer's", "Architect's", "Engineer's", "Builder's", "Constructor's", "Fabricator's", "Manufacturer's", "Producer's", "Director's", "Manager's", "Supervisor's", "Coordinator's", "Organizer's", "Planner's", "Strategist's", "Analyst's", "Consultant's", "Advisor's", "Counselor's", "Mentor's", "Tutor's", "Teacher's", "Instructor's", "Educator's", "Professor's", "Lecturer's", "Trainer's", "Coach's", "Drillmaster's", "Taskmaster's", "Mastermind's", "Genius's", "Savant's", "Expert's", "Specialist's", "Professional's", "Technician's", "Mechanic's", "Operator's", "Worker's", "Laborer's", "Handyman's", "Repairman's", "Serviceman's", "Maintenance's", "Custodian's", "Janitor's", "Cleaner's", "Sanitation's", "Hygienist's", "Health's", "Medical's", "Nurse's", "Doctor's", "Physician's", "Surgeon's", "Dentist's", "Pharmacist's", "Therapist's", "Psychologist's", "Psychiatrist's", "Counselor's", "Social Worker's", "Case Manager's", "Advocate's", "Mediator's", "Negotiator's", "Arbitrator's", "Judge's", "Magistrate's", "Jurist's", "Lawyer's", "Attorney's", "Counsel's", "Solicitor's", "Barrister's", "Advocate's", "Prosecutor's", "Defender's", "Litigator's", "Trial Lawyer's", "Appellate Lawyer's", "Legal Advisor's", "Legal Consultant's", "Legal Analyst's", "Paralegal's", "Legal Assistant's", "Clerk's", "Secretary's", "Assistant's", "Aide's", "Helper's", "Support's", "Backer's", "Sponsor's", "Patron's", "Benefactor's", "Donor's", "Contributor's", "Investor's", "Shareholder's", "Stakeholder's", "Partner's", "Co-owner's", "Joint Venture's", "Syndicate's", "Consortium's", "Alliance's", "Coalition's", "Federation's", "Union's", "Association's", "Society's", "Club's", "Group's", "Team's", "Crew's", "Gang's", "Band's", "Troupe's", "Company's", "Corporation's", "Enterprise's", "Firm's", "Business's", "Agency's", "Bureau's", "Office's", "Department's", "Division's", "Section's", "Unit's", "Branch's", "Subsidiary's", "Affiliate's", "Franchise's", "Chain's", "Outlet's", "Store's", "Shop's", "Boutique's", "Emporium's", "Marketplace's", "Mart's", "Mall's", "Plaza's", "Center's", "Complex's", "Hub's", "Terminal's", "Station's", "Port's", "Harbor's", "Marina's", "Dock's", "Wharf's", "Quay's", "Pier's", "Jetty's", "Breakwater's", "Seawall's", "Bulwark's", "Rampart's", "Bastion's", "Fortress's", "Castle's", "Palace's", "Manor's", "Mansion's", "Estate's", "Villa's", "Chateau's", "Lodge's", "Cabin's", "Cottage's", "Bungalow's", "Hut's", "Shack's", "Shed's", "Barn's", "Stable's", "Kennel's", "Cattery's", "Aviary's", "Aquarium's", "Zoo's", "Safari Park's", "Wildlife Reserve's", "Nature Preserve's", "National Park's", "State Park's", "Provincial Park's", "Regional Park's", "City Park's", "Public Garden's", "Botanical Garden's", "Arboretum's", "Greenhouse's", "Nursery's", "Farm's", "Ranch's", "Plantation's", "Orchard's", "Vineyard's", "Winery's", "Brewery's", "Distillery's", "Factory's", "Mill's", "Plant's", "Workshop's", "Studio's", "Gallery's", "Museum's", "Library's", "Archive's", "Repository's", "Depot's", "Warehouse's", "Storage's", "Silo's", "Tank's", "Reservoir's", "Container's", "Vessel's", "Ship's", "Boat's", "Vessel's", "Craft's", "Yacht's", "Sailboat's", "Motorboat's", "Speedboat's", "Ferry's", "Cruise Ship's", "Liner's", "Tanker's", "Freighter's", "Cargo Ship's", "Container Ship's", "Battleship's", "Destroyer's", "Frigate's", "Submarine's", "Aircraft Carrier's", "Warship's", "Naval Ship's", "Military Vessel's", "Patrol Boat's", "Coast Guard Cutter's", "Icebreaker's", "Research Vessel's", "Exploration Ship's", "Adventure's", "Expedition's", "Voyage's", "Journey's", "Trip's", "Tour's", "Excursion's", "Outing's", "Safari's", "Trek's", "Hike's", "Walk's", "Stroll's", "Ramble's", "Wander's", "Roam's", "Travel's", "Venture's", "Quest's", "Mission's", "Campaign's", "Crusade's", "Drive's", "Push's", "Effort's", "Attempt's", "Trial's", "Test's", "Experiment's", "Study's", "Investigation's", "Inquiry's", "Research's", "Exploration's", "Discovery's", "Find's", "Revelation's", "Uncovering's", "Exposure's", "Reveal's", "Show's", "Presentation's", "Display's", "Exhibition's", "Demonstration's", "Performance's", "Act's", "Scene's", "Episode's", "Chapter's", "Volume's", "Book's", "Publication's", "Release's", "Launch's", "Debut's", "Premiere's", "Opening's", "Introduction's", "Inauguration's", "Commencement's", "Start's", "Beginning's", "Origin's", "Genesis's", "Creation's", "Formation's", "Development's", "Evolution's", "Progress's", "Advancement's", "Improvement's", "Enhancement's", "Upgrade's", "Update's", "Revision's", "Modification's", "Change's", "Alteration's", "Transformation's", "Conversion's", "Switch's", "Substitution's", "Replacement's", "Exchange's", "Trade's", "Swap's", "Shift's", "Transfer's", "Movement's", "Motion's", "Action's", "Activity's", "Operation's", "Function's", "Process's", "Procedure's", "Method's", "Technique's", "Strategy's", "Tactic's", "Plan's", "Scheme's", "Design's", "Blueprint's", "Outline's", "Sketch's", "Draft's", "Diagram's", "Chart's", "Map's", "Plan's", "Layout's", "Arrangement's", "Organization's", "Structure's", "Framework's", "System's", "Network's", "Grid's", "Matrix's", "Web's", "Complex's", "Compound's", "Aggregate's", "Mixture's", "Blend's", "Combination's", "Amalgamation's", "Integration's", "Union's", "Fusion's", "Merger's", "Consolidation's", "Unification's", "Synthesis's", "Harmonization's", "Coordination's", "Alignment's", "Congruence's", "Correspondence's", "Match's", "Pairing's", "Coupling's", "Linkage's", "Connection's", "Bond's", "Tie's", "Relationship's", "Association's", "Affiliation's", "Partnership's", "Collaboration's", "Cooperation's", "Teamwork's", "Synergy's", "Interplay's", "Interaction's", "Interrelation's", "Interdependence's", "Mutuality's", "Reciprocity's", "Exchange's", "Dialogue's", "Conversation's", "Discussion's", "Debate's", "Argument's", "Dispute's", "Controversy's", "Conflict's", "Struggle's", "Fight's", "Battle's", "War's", "Combat's", "Engagement's", "Encounter's", "Skirmish's", "Clash's", "Confrontation's", "Showdown's", "Face-off's", "Duel's", "Matchup's", "Competition's", "Contest's", "Tournament's", "Championship's", "Race's", "Game's", "Sport's", "Event's", "Occasion's", "Celebration's", "Festival's", "Fair's", "Carnival's", "Party's", "Gathering's", "Meeting's", "Assembly's", "Convention's", "Conference's", "Symposium's", "Seminar's", "Workshop's", "Course's", "Class's" };
    private static readonly string[] _suffixes = { "Promise", "Destiny", "Legacy", "Fury", "Whisper", "Echo", "Bane", "Dream", "Nightmare", "Vision", "Wraith", "Phantom", "Mirage", "Eclipse", "Aurora", "Vortex", "Tempest", "Inferno", "Blizzard", "Torrent", "Quake", "Rift", "Void", "Nebula", "Galaxy", "Meteor", "Comet", "Astral", "Cosmos", "Reverie", "Serenity", "Chaos", "Harmony", "Zenith", "Nadir", "Apex", "Nexus", "Genesis", "Terminus", "Vertex", "Maelstrom", "Cyclone", "Tsunami", "Inferno", "Cataclysm", "Paradox", "Anomaly", "Enigma", "Phenomenon", "Mystique", "Oblivion", "Eternity", "Infinity", "Epoch", "Era", "Saga", "Myth", "Legend", "Fable", "Tale", "Odyssey", "Quest", "Journey", "Voyage", "Expedition", "Crusade", "War", "Rebellion", "Revolution", "Uprising", "Empire", "Dynasty", "Realm", "Dominion", "Kingdom", "Ascendancy", "Conquest", "Triumph", "Dominance", "Supremacy", "Guardian", "Protector", "Sentinel", "Avenger", "Crusader", "Martyr", "Champion", "Behemoth", "Leviathan", "Titan", "Colossus", "Goliath", "Sphinx", "Phoenix", "Dragon", "Serpent", "Wyrm", "Gryphon", "Pegasus", "Unicorn", "Cerberus", "Kraken", "Hydra", "Chimera", "Basilisk", "Valkyrie", "Sorcerer", "Necromancer", "Paladin", "Ranger", "Assassin", "Berserker", "Monk", "Priest", "Shaman", "Wizard", "Warlock", "Mage", "Druid", "Knight", "Squire", "Arcanist", "Enchanter", "Sage", "Prophet", "Seer", "Oracle", "Diviner", "Mystic", "Hermit", "Recluse", "Nomad", "Pilgrim", "Wanderer", "Explorer", "Adventurer", "Pioneer", "Vanguard", "Pathfinder", "Trailblazer", "Scout", "Reaver", "Slayer", "Warrior", "Hunter", "Silhouette", "Reflection", "Glimmer", "Shimmer", "Spark", "Flame", "Ember", "Flash", "Shadow", "Light", "Dawn", "Dusk", "Noon", "Midnight", "Twilight", "Eclipse", "Solstice", "Equinox", "Horizon", "Zenith" };

	private static readonly Type[] _weaponTypes =
	{
		typeof(Broadsword), typeof(Cutlass), typeof(Katana), typeof(Longsword), typeof(Scimitar), typeof(VikingSword),
		typeof(Axe), typeof(BattleAxe), typeof(DoubleAxe), typeof(ExecutionersAxe), typeof(LargeBattleAxe),
		typeof(TwoHandedAxe), typeof(WarAxe), typeof(Club), typeof(HammerPick), typeof(Mace), typeof(Maul),
		typeof(WarHammer), typeof(WarMace), typeof(Bardiche), typeof(Halberd), typeof(Lance), typeof(Pike),
		typeof(ShortSpear), typeof(Spear), typeof(WarFork), typeof(CompositeBow), typeof(Crossbow),
		typeof(HeavyCrossbow), typeof(RepeatingCrossbow), typeof(Bow), typeof(Dagger), typeof(Kryss),
		typeof(SkinningKnife), typeof(ShortSpear), typeof(Spear), typeof(Pitchfork), typeof(BlackStaff),
		typeof(GnarledStaff), typeof(QuarterStaff), typeof(ShepherdsCrook), typeof(BladedStaff), typeof(Scythe),
		typeof(Scepter), typeof(MagicWand), typeof(AnimalClaws), typeof(WrestlingBelt), typeof(ArtificerWand),
		typeof(BashingShield), typeof(BeggersStick), typeof(BoltRod), typeof(CampingLanturn), typeof(CarpentersHammer),
		typeof(CooksCleaver), typeof(DetectivesBoneHarvester), typeof(DistractingHammer), typeof(ExplorersMachete),
		typeof(FireAlchemyBlaster), typeof(FishermansTrident), typeof(FletchersBow), typeof(FocusKryss),
		typeof(GearLauncher), typeof(GourmandsFork), typeof(HolyKnightSword), typeof(IllegalCrossbow),
		typeof(IntelligenceEvaluator), typeof(LoreSword), typeof(MageWand), typeof(MallKatana), typeof(MeatPicks),
		typeof(MeditationFans), typeof(MerchantsShotgun), typeof(MysticStaff), typeof(NecromancersStaff),
		typeof(NinjaBow), typeof(Nunchucks), typeof(PoisonBlade), typeof(RangersCrossbow), typeof(ResonantHarp),
		typeof(RevealingAxe), typeof(Scalpel), typeof(ScribeSword), typeof(SewingNeedle), typeof(ShadowSai),
		typeof(SilentBlade), typeof(SleepAid), typeof(SmithSmasher), typeof(SnoopersPaddle), typeof(SpellWeaversWand),
		typeof(SpiritScepter), typeof(TacticalMultitool), typeof(TenFootPole), typeof(VeterinaryLance),
		typeof(VivisectionKnife), typeof(WitchBurningTorch), typeof(AssassinSpike), typeof(Bokuto), typeof(BoneHarvester),
		typeof(BoneMachete), typeof(Boomerang), typeof(ButcherKnife), typeof(Cleaver), typeof(CrescentBlade),
		typeof(Cyclone), typeof(Daisho), typeof(DiamondMace), typeof(DiscMace), typeof(DoubleBladedStaff),
		typeof(ElvenCompositeLongbow), typeof(ElvenMachete), typeof(ElvenSpellblade), typeof(JukaBow), typeof(Kama),
		typeof(Lajatang), typeof(Leafblade), typeof(MagicalShortbow), typeof(Maul), typeof(NoDachi), typeof(Nunchaku),
		typeof(Pickaxe), typeof(Scythe), typeof(Tekagi), typeof(Tessen), typeof(Tetsubo), typeof(Wakizashi),
		typeof(WildStaff), typeof(Yumi)
	};


    private static readonly SkillName[] _allSkills =
        (SkillName[])Enum.GetValues(typeof(SkillName));
}
#endregion
