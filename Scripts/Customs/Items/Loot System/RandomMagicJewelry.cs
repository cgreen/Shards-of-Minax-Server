using System;
using Server;
using Server.Items;
using System.Collections.Generic;


#region RANDOM‑MAGIC‑JEWELRY

public class RandomMagicJewelry : BaseJewel
{
    private int _tier;

    // ───────────────── Tier configuration ────────────────────────────
    private class TierConfig
    {
        public int MinEffects, MaxEffects;   // # of attribute effects
        public int MinSkillBns, MaxSkillBns; // # of skill bonuses
        public int ResMin, ResMax;           // resist roll
    }

    // index 0 ⇒ T1, …, index 6 ⇒ T7
    private static readonly TierConfig[] _tiers = new[]
    {
        new TierConfig{ MinEffects=1, MaxEffects=2, MinSkillBns=0, MaxSkillBns=1, ResMin=1,  ResMax=5  }, // T1
        new TierConfig{ MinEffects=2, MaxEffects=3, MinSkillBns=1, MaxSkillBns=2, ResMin=2,  ResMax=7  }, // T2
        new TierConfig{ MinEffects=3, MaxEffects=4, MinSkillBns=1, MaxSkillBns=2, ResMin=3,  ResMax=9  }, // T3
        new TierConfig{ MinEffects=3, MaxEffects=5, MinSkillBns=2, MaxSkillBns=3, ResMin=4,  ResMax=12 }, // T4
        new TierConfig{ MinEffects=4, MaxEffects=6, MinSkillBns=2, MaxSkillBns=4, ResMin=5,  ResMax=14 }, // T5
        new TierConfig{ MinEffects=5, MaxEffects=7, MinSkillBns=3, MaxSkillBns=5, ResMin=6,  ResMax=16 }, // T6
        new TierConfig{ MinEffects=6, MaxEffects=8, MinSkillBns=4, MaxSkillBns=6, ResMin=7,  ResMax=18 }, // T7
    };

    // weighted tiers (sum=100)
    private static readonly Tuple<int,int>[] _tierWeights = new[]
    {
        Tuple.Create(1, 40),
        Tuple.Create(2, 25),
        Tuple.Create(3, 15),
        Tuple.Create(4, 10),
        Tuple.Create(5,  6),
        Tuple.Create(6,  3),
        Tuple.Create(7,  1),
    };

    private static readonly Type[] _jewelTypes = {
        typeof(GoldRing), typeof(SilverRing),
        typeof(GoldBracelet), typeof(SilverBracelet)
        // …add more if you like
    };

    private static readonly string[] _prefixes = {
        "Mighty", "Powerful", "Mystic", "Enchanted", "Arcane", "Enchanted", "Mystical", "Elemental", "Eternal", "Infernal", "Celestial", "Eldritch", "Spectral", "Tempest", "Frozen", "Blazing", "Thunder", "Shadow", "Radiant", "Dark", "Light", "Phantom", "Void", "Ethereal", "Necrotic", "Divine", "Astral", "Prismatic", "Runic", "Venomous", "Frost", "Storm", "Invisible", "Invincible", "Majestic", "Cursed", "Blessed", "Soulbound", "Vortex", "Twilight", "Dawn", "Dusk", "Starforged", "Moonlit", "Sunflare", "Comet", "Eclipse", "Galactic", "Cosmic", "Dimensional", "Temporal", "Spatial", "Quantum", "Mythic", "Legendary", "Ancient", "Primordial", "Forgotten", "Unseen", "Chaos", "Harmony", "Balance", "Rage", "Serenity", "Oblivion", "Creation", "Destruction", "Rebirth", "Fate", "Dream", "Nightmare", "Illusion", "Reality", "Vision", "Ghostly", "Glorious", "Sacred", "Unholy", "Vigilant", "Warrior's", "Sorcerer's", "Seer's", "Dragon's", "Titan's", "Phoenix", "Demonic", "Angelic", "Heavenly", "Abyssal", "Solar", "Lunar", "Stellar", "Voidwalker's", "Battleworn", "Savage", "Berserker's", "Monarch's", "Guardian's", "Pirate's", "Royal", "Revenant", "Warden's", "Spectral", "Stormbringer's", "Windwalker's", "Flamebearer's", "Icewrought", "Thunderous", "Stoneskin", "Nature's", "Beastmaster's", "Shamanic", "Witch's", "Siren's", "Mercurial", "Adamant", "Sylvan", "Arcanist's", "Noble", "Explorer's", "Sentry's", "Ranger's", "Corsair's", "Assassin's", "Necromancer's", "Paladin's", "Rogue's", "Cleric's", "Elementalist's", "Chronomancer's", "Geomancer's", "Pyromancer's", "Hydromancer's", "Aeromancer's", "Biomancer's", "Cybernetic", "Technomancer's", "Alchemist's", "Summoner's", "Psionic", "Sage's", "Prophet's", "Martyr's", "Zealot's", "Reclaimer's", "Pioneer's", "Innovator's", "Vindicator's", "Arbiter's", "Sentinel's", "Defender's", "Avenger's", "Champion's", "Conqueror's", "Master's", "Primeval", "Arcadian", "Myrmidon's", "Valkyrie's", "Bard's", "Jester's", "Gladiator's", "Knight's", "Samurai's", "Ninja's", "Viking's", "Pilgrim's", "Hermit's", "Sculptor's", "Painter's", "Poet's", "Minstrel's", "Troubadour's", "Wanderer's", "Explorer's", "Adventurer's", "Seeker's", "Scholar's", "Philosopher's", "Oracle's", "Muse's", "Mystic's", "Seer's", "Soothsayer's", "Prognosticator's", "Diviner's", "Augur's", "Sibyl's", "Clairvoyant's", "Telepath's", "Empath's", "Psychic's", "Medium's", "Spiritualist's", "Channeler's", "Shapeshifter's", "Transformer's", "Metamorph's", "Changeling's", "Morpher's", "Transmuter's", "Alchemist's", "Chemist's", "Potioneer's", "Apothecary's", "Herbalist's", "Botanist's", "Horticulturist's", "Agronomist's", "Cultivator's", "Farmer's", "Gardener's", "Landscaper's", "Arborist's", "Forester's", "Logger's", "Woodcutter's", "Carpenter's", "Joiner's", "Cabinetmaker's", "Woodworker's", "Craftsman's", "Artisan's", "Maker's", "Creator's", "Inventor's", "Designer's", "Architect's", "Engineer's", "Builder's", "Constructor's", "Fabricator's", "Manufacturer's", "Producer's", "Director's", "Manager's", "Supervisor's", "Coordinator's", "Organizer's", "Planner's", "Strategist's", "Analyst's", "Consultant's", "Advisor's", "Counselor's", "Mentor's", "Tutor's", "Teacher's", "Instructor's", "Educator's", "Professor's", "Lecturer's", "Trainer's", "Coach's", "Drillmaster's", "Taskmaster's", "Mastermind's", "Genius's", "Savant's", "Expert's", "Specialist's", "Professional's", "Technician's", "Mechanic's", "Operator's", "Worker's", "Laborer's", "Handyman's", "Repairman's", "Serviceman's", "Maintenance's", "Custodian's", "Janitor's", "Cleaner's", "Sanitation's", "Hygienist's", "Health's", "Medical's", "Nurse's", "Doctor's", "Physician's", "Surgeon's", "Dentist's", "Pharmacist's", "Therapist's", "Psychologist's", "Psychiatrist's", "Counselor's", "Social Worker's", "Case Manager's", "Advocate's", "Mediator's", "Negotiator's", "Arbitrator's", "Judge's", "Magistrate's", "Jurist's", "Lawyer's", "Attorney's", "Counsel's", "Solicitor's", "Barrister's", "Advocate's", "Prosecutor's", "Defender's", "Litigator's", "Trial Lawyer's", "Appellate Lawyer's", "Legal Advisor's", "Legal Consultant's", "Legal Analyst's", "Paralegal's", "Legal Assistant's", "Clerk's", "Secretary's", "Assistant's", "Aide's", "Helper's", "Support's", "Backer's", "Sponsor's", "Patron's", "Benefactor's", "Donor's", "Contributor's", "Investor's", "Shareholder's", "Stakeholder's", "Partner's", "Co-owner's", "Joint Venture's", "Syndicate's", "Consortium's", "Alliance's", "Coalition's", "Federation's", "Union's", "Association's", "Society's", "Club's", "Group's", "Team's", "Crew's", "Gang's", "Band's", "Troupe's", "Company's", "Corporation's", "Enterprise's", "Firm's", "Business's", "Agency's", "Bureau's", "Office's", "Department's", "Division's", "Section's", "Unit's", "Branch's", "Subsidiary's", "Affiliate's", "Franchise's", "Chain's", "Outlet's", "Store's", "Shop's", "Boutique's", "Emporium's", "Marketplace's", "Mart's", "Mall's", "Plaza's", "Center's", "Complex's", "Hub's", "Terminal's", "Station's", "Port's", "Harbor's", "Marina's", "Dock's", "Wharf's", "Quay's", "Pier's", "Jetty's", "Breakwater's", "Seawall's", "Bulwark's", "Rampart's", "Bastion's", "Fortress's", "Castle's", "Palace's", "Manor's", "Mansion's", "Estate's", "Villa's", "Chateau's", "Lodge's", "Cabin's", "Cottage's", "Bungalow's", "Hut's", "Shack's", "Shed's", "Barn's", "Stable's", "Kennel's", "Cattery's", "Aviary's", "Aquarium's", "Zoo's", "Safari Park's", "Wildlife Reserve's", "Nature Preserve's", "National Park's", "State Park's", "Provincial Park's", "Regional Park's", "City Park's", "Public Garden's", "Botanical Garden's", "Arboretum's", "Greenhouse's", "Nursery's", "Farm's", "Ranch's", "Plantation's", "Orchard's", "Vineyard's", "Winery's", "Brewery's", "Distillery's", "Factory's", "Mill's", "Plant's", "Workshop's", "Studio's", "Gallery's", "Museum's", "Library's", "Archive's", "Repository's", "Depot's", "Warehouse's", "Storage's", "Silo's", "Tank's", "Reservoir's", "Container's", "Vessel's", "Ship's", "Boat's", "Vessel's", "Craft's", "Yacht's", "Sailboat's", "Motorboat's", "Speedboat's", "Ferry's", "Cruise Ship's", "Liner's", "Tanker's", "Freighter's", "Cargo Ship's", "Container Ship's", "Battleship's", "Destroyer's", "Frigate's", "Submarine's", "Aircraft Carrier's", "Warship's", "Naval Ship's", "Military Vessel's", "Patrol Boat's", "Coast Guard Cutter's", "Icebreaker's", "Research Vessel's", "Exploration Ship's", "Adventure's", "Expedition's", "Voyage's", "Journey's", "Trip's", "Tour's", "Excursion's", "Outing's", "Safari's", "Trek's", "Hike's", "Walk's", "Stroll's", "Ramble's", "Wander's", "Roam's", "Travel's", "Venture's", "Quest's", "Mission's", "Campaign's", "Crusade's", "Drive's", "Push's", "Effort's", "Attempt's", "Trial's", "Test's", "Experiment's", "Study's", "Investigation's", "Inquiry's", "Research's", "Exploration's", "Discovery's", "Find's", "Revelation's", "Uncovering's", "Exposure's", "Reveal's", "Show's", "Presentation's", "Display's", "Exhibition's", "Demonstration's", "Performance's", "Act's", "Scene's", "Episode's", "Chapter's", "Volume's", "Book's", "Publication's", "Release's", "Launch's", "Debut's", "Premiere's", "Opening's", "Introduction's", "Inauguration's", "Commencement's", "Start's", "Beginning's", "Origin's", "Genesis's", "Creation's", "Formation's", "Development's", "Evolution's", "Progress's", "Advancement's", "Improvement's", "Enhancement's", "Upgrade's", "Update's", "Revision's", "Modification's", "Change's", "Alteration's", "Transformation's", "Conversion's", "Switch's", "Substitution's", "Replacement's", "Exchange's", "Trade's", "Swap's", "Shift's", "Transfer's", "Movement's", "Motion's", "Action's", "Activity's", "Operation's", "Function's", "Process's", "Procedure's", "Method's", "Technique's", "Strategy's", "Tactic's", "Plan's", "Scheme's", "Design's", "Blueprint's", "Outline's", "Sketch's", "Draft's", "Diagram's", "Chart's", "Map's", "Plan's", "Layout's", "Arrangement's", "Organization's", "Structure's", "Framework's", "System's", "Network's", "Grid's", "Matrix's", "Web's", "Complex's", "Compound's", "Aggregate's", "Mixture's", "Blend's", "Combination's", "Amalgamation's", "Integration's", "Union's", "Fusion's", "Merger's", "Consolidation's", "Unification's", "Synthesis's", "Harmonization's", "Coordination's", "Alignment's", "Congruence's", "Correspondence's", "Match's", "Pairing's", "Coupling's", "Linkage's", "Connection's", "Bond's", "Tie's", "Relationship's", "Association's", "Affiliation's", "Partnership's", "Collaboration's", "Cooperation's", "Teamwork's", "Synergy's", "Interplay's", "Interaction's", "Interrelation's", "Interdependence's", "Mutuality's", "Reciprocity's", "Exchange's", "Dialogue's", "Conversation's", "Discussion's", "Debate's", "Argument's", "Dispute's", "Controversy's", "Conflict's", "Struggle's", "Fight's", "Battle's", "War's", "Combat's", "Engagement's", "Encounter's", "Skirmish's", "Clash's", "Confrontation's", "Showdown's", "Face-off's", "Duel's", "Matchup's", "Competition's", "Contest's", "Tournament's", "Championship's", "Race's", "Game's", "Sport's", "Event's", "Occasion's", "Celebration's", "Festival's", "Fair's", "Carnival's", "Party's", "Gathering's", "Meeting's", "Assembly's", "Convention's", "Conference's", "Symposium's", "Seminar's", "Workshop's", "Course's", "Class's"
        // …etc
    };

    private static readonly string[] _suffixes = {
        "Amulet", "Talisman", "Gem", "Orb", "Ring", "Pendant", "Bracelet", "Charm", "Bead", "Chain",
		"Crystal", "Diamond", "Emerald", "Garnet", "Jade", "Opal", "Pearl", "Ruby", "Sapphire", "Topaz",
		"Agate", "Beryl", "Citrine", "Jasper", "Moonstone", "Quartz", "Turquoise", "Zircon", "Onyx", "Peridot",
		"Sunstone", "TigerEye", "Lapis", "Obsidian", "Amber", "Aquamarine", "Sardonyx", "Spinel", "Tourmaline", "Carnelian",
		"Chrysoprase", "Heliotrope", "Iolite", "Kunzite", "Labradorite", "Malachite", "Morganite", "Rhodochrosite", "Rhodonite", "Tanzanite",
		"Azurite", "Bloodstone", "Chalcedony", "Fluorite", "Hematite", "Larimar", "Moonstone", "Prehnite", "Pyrite", "Sodalite",
		"Sunstone", "Tektite", "Variscite", "Vesuvianite", "Zoisite", "Seraphinite", "Shungite", "Spirit", "Aura", "Eclipse",
		"Galaxy", "Meteor", "Nebula", "Void", "Astral", "Celestial", "Comet", "Cosmos", "Ether", "Nexus",
		"Phantom", "Shadow", "Ethereal", "Inferno", "Mystic", "Phenomenon", "Reverie", "Serenity", "Vision", "Wraith"
        // …etc
    };

    private static readonly Random _rand = new Random();

    // ──────── ctors ───────────────────────────────────────────────────

    [Constructable]
    public RandomMagicJewelry() : this(GetWeightedRandomTier()) { }

    [Constructable]
    public RandomMagicJewelry(int tier)
        : base(GetRandomItemID(), GetRandomLayer())
    {
        _tier = Math.Max(1, Math.Min(7, tier));
        Name = $"{_prefixes[_rand.Next(_prefixes.Length)]} {_suffixes[_rand.Next(_suffixes.Length)]}";
        Hue  = _rand.Next(1, 3001);

        ApplyTieredBonuses(_tiers[_tier - 1]);
    }

    public RandomMagicJewelry(Serial serial) : base(serial) { }

    // ──────── internal logic ───────────────────────────────────────────

    private void ApplyTieredBonuses(TierConfig cfg)
    {
        // 1) random number of attribute‐effects
        int effects = _rand.Next(cfg.MinEffects, cfg.MaxEffects + 1);
        AddRandomAttributes(effects, cfg);

        // 2) random number of skill bonuses
        int skills  = _rand.Next(cfg.MinSkillBns, cfg.MaxSkillBns + 1);
        AddRandomSkillBonuses(skills);
    }

    private void AddRandomAttributes(int count, TierConfig cfg)
    {
        var pool = new List<Action>
        {
            () => Attributes.Luck           += _rand.Next(1, 51),
            () => Attributes.RegenHits      += _rand.Next(1, 11),
            () => Attributes.RegenMana      += _rand.Next(1, 11),
            () => Attributes.RegenStam      += _rand.Next(1, 11),
            () => Attributes.BonusDex       += _rand.Next(1, 21),
            () => Attributes.BonusInt       += _rand.Next(1, 21),
            () => Attributes.BonusStr       += _rand.Next(1, 21),
            () => Attributes.BonusHits      += _rand.Next(1, 31),
            () => Attributes.BonusMana      += _rand.Next(1, 31),
            () => Attributes.BonusStam      += _rand.Next(1, 31),
            () => Attributes.CastSpeed      += _rand.Next(0, 2),
            () => Attributes.CastRecovery   += _rand.Next(0, 3),
            () => Attributes.LowerManaCost  += _rand.Next(1, 21),
            () => Attributes.LowerRegCost   += _rand.Next(1, 21),
            () => Attributes.ReflectPhysical+= _rand.Next(1, 21),
            () => Attributes.EnhancePotions += _rand.Next(1, 31),
            () => Attributes.SpellDamage    += _rand.Next(1, 31),
            () => Attributes.NightSight      = 1,
            // now the resistances
            () => Resistances.Physical     += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
            () => Resistances.Fire         += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
            () => Resistances.Cold         += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
            () => Resistances.Poison       += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
            () => Resistances.Energy       += _rand.Next(cfg.ResMin, cfg.ResMax + 1),
        };

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int idx = _rand.Next(pool.Count);
            pool[idx]();
            pool.RemoveAt(idx);
        }
    }

    private void AddRandomSkillBonuses(int count)
    {
        var skills = new List<SkillName>((SkillName[])Enum.GetValues(typeof(SkillName)));
        for (int i = 0; i < count && skills.Count > 0; i++)
        {
            int idx = _rand.Next(skills.Count);
            SkillName sel = skills[idx];
            skills.RemoveAt(idx);

            int val = _rand.Next(1, 11 * _tier); // scale bonus by tier
            SkillBonuses.SetValues(i, sel, val);
        }
    }

    private static int GetWeightedRandomTier()
    {
        int roll = _rand.Next(100), cum = 0;
        foreach (var t in _tierWeights)
        {
            cum += t.Item2;
            if (roll < cum) return t.Item1;
        }
        return 1;
    }

    private static int GetRandomItemID()
    {
        var t = _jewelTypes[_rand.Next(_jewelTypes.Length)];
        var tmp = (BaseJewel)Activator.CreateInstance(t);
        int id = tmp.ItemID;
        tmp.Delete();
        return id;
    }

    private static Layer GetRandomLayer()
    {
        return (_rand.Next(2) == 0 ? Layer.Ring : Layer.Bracelet);
    }

    // ──────── persistence ─────────────────────────────────────────────

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write(0);          // version
        writer.Write(_tier);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
        _tier = reader.ReadInt();
    }
}

#endregion
