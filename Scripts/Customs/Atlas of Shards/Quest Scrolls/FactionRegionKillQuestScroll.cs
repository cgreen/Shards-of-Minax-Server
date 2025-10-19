/*
 * FactionRegionKillQuestScroll.cs
 *
 * A “kill any monster in a region” quest scroll that grants
 * MobFactions reputation instead of gold.
 * © 2025 – free to use / modify.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Targeting;
using Server.Network;
using Server.Engines.XmlSpawner2;  // for XmlMobFactions

namespace Server.Items
{
    public class FactionRegionKillQuestScroll : Item
    {
        // ── ❶ Default region names ───────────────────────────────────────
        private static readonly string[] DefaultRegionPool =
        {
            "Moongates",
            "Heartwood",
            "ElfCity",
            "Sanctuary",
            "Dungeon9",
            "Painted Caves",
            "Dungeon9",
            "Prism of Light",
            "Dungeon9",
            "Blighted Grove",
            "MelisandesLair",
            "Palace of Paroxysmus",
            "ParoxysmusLair",
            "Huntsman's Forest",
            "Cove",
            "Cove",
            "Britain",
            "Britain1",
            "Blackthorn Castle",
            "LBCastle",
            "A Wheatfield in Britain 1",
            "A Wheatfield in Britain 2",
            "A Wheatfield in Britain 3",
            "A Carrot Field in Britain 1",
            "An Onion Field in Britain 1",
            "A Cabbage Field in Britain 1",
            "A Turnip Field in Britain 1",
            "A Wheatfield in Britain 4",
            "A Wheatfield in Britain 5",
            "A Turnip Field in Britain 2",
            "A Carrot Field in Britain 2",
            "Britain Graveyard",
            "Jhelom Islands",
            "Jhelom",
            "Jhelom",
            "Jhelom",
            "Minoc",
            "Minoc",
            "Ocllo",
            "Ocllo",
            "Trinsic",
            "Trinsic",
            "Vesper",
            "Vesper",
            "Yew",
            "Yew",
            "A Field of Sheep in Yew 1",
            "A Field of Sheep in Yew",
            "A Field of Sheep in Yew 2",
            "A Field of Sheep in Yew",
            "A Farm in Yew",
            "A Farm in Yew",
            "A Wheatfield in Yew 1",
            "A Wheatfield in Yew",
            "A Wheatfield in Yew 2",
            "A Wheatfield in Yew",
            "Wind",
            "Wind",
            "Serpent's Hold",
            "Serpents",
            "Skara Brae",
            "Skarabra",
            "Nujel'm",
            "Nujelm",
            "Moonglow",
            "Moonglow",
            "Magincia",
            "Magincia",
            "Buccaneer's Den",
            "Bucsden",
            "Covetous",
            "Dungeon9",
            "Deceit",
            "Dungeon9",
            "Despise",
            "Dungeon9",
            "Destard",
            "Dungeon9",
            "Hythloth",
            "Dungeon9",
            "Khaldun",
            "Dungeon9",
            "Jail",
            "Green Acres",
            "Shame",
            "Dungeon9",
            "Wrong",
            "Dungeon9",
            "Cave 1",
            "Cave 2",
            "Cave 3",
            "Cave 4",
            "Britain Mine 1",
            "Britain Mine 2",
            "Minoc Cave 1",
            "Minoc Cave 2",
            "Minoc Cave 3",
            "Minoc Mine",
            "Avatar Isle Cave",
            "Ice Isle Cave 1",
            "Ice Isle Cave 2",
            "North Territory Cave",
            "Yew Cave",
            "North Territory Mine 1",
            "North Territory Mine 2",
            "Mt Kendall",
            "Covetous Mine",
            "Terathan Keep",
            "Dungeon9",
            "Throne Room",
            "Fire",
            "Dungeon9",
            "Ice",
            "Dungeon9",
            "BlackthornDungeon",
            "Dungeon9",
            "Delucia",
            "Papua",
            "Wrong Entrance",
            "Mountn_a",
            "Covetous Entrance",
            "Vesper",
            "Despise Entrance",
            "Despise Passage",
            "Misc Dungeons",
            "Dungeon9",
            "Orc Cave",
            "Dungeon9",
            "A Cotton Field in Moonglow",
            "A Cotton Field in Moonglow",
            "A Wheatfield in Skara Brae 1",
            "A Wheatfield in Skara Brae",
            "A Carrot Field in Skara Brae",
            "An Onion Field in Skara Brae",
            "A Cabbage Field in Skara Brae 1",
            "A Cabbage Field in Skara Brae 2",
            "A Wheatfield in Skara Brae 2",
            "A Cotton Field in Skara Brae",
            "Shrine of Compassion",
            "Chaos Shrine",
            "Shrine of Honesty",
            "Shrine of Honor",
            "Shrine of Humility",
            "Shrine of Justice",
            "Shrine of Sacrifice",
            "Shrine of Spirituality",
            "Shrine of Valor",
            "South Britannian Sea",
            "Paroxysmus Exit",
            "Sanctuary Entrance",
            "Solen Hives",
            "Sea Market",
            "Trammel",
            "Khaldun",
            "Dungeon9",
            "Underwater World",
            "Moongates",
            "Heartwood",
            "ElfCity",
            "Sanctuary",
            "Dungeon9",
            "Painted Caves",
            "Dungeon9",
            "Prism of Light",
            "Dungeon9",
            "Blighted Grove",
            "MelisandesLair",
            "Palace of Paroxysmus",
            "ParoxysmusLair",
            "Bravehorn's drinking pool",
            "Huntsman's Forest",
            "Cove",
            "Cove",
            "Britain",
            "Britain1",
            "Custeau Perron House",
            "A Wheatfield in Britain 1",
            "A Wheatfield in Britain 2",
            "A Wheatfield in Britain 3",
            "A Carrot Field in Britain 1",
            "An Onion Field in Britain 1",
            "A Cabbage Field in Britain 1",
            "A Turnip Field in Britain 1",
            "A Wheatfield in Britain 4",
            "A Wheatfield in Britain 5",
            "A Turnip Field in Britain 2",
            "A Carrot Field in Britain 2",
            "Britain Graveyard",
            "Jhelom Islands",
            "Jhelom",
            "Jhelom",
            "Jhelom",
            "Minoc",
            "Minoc",
            "Haven Island",
            "Enhanced Tracking Skill",
            "the New Haven Bard",
            "the New Haven Carpenter",
            "the New Haven Farm",
            "Old Haven Training",
            "Haven Mountains",
            "Haven Moongate",
            "New Haven",
            "New Haven City",
            "InTown01",
            "the New Haven Alchemist",
            "the New Haven Warrior",
            "the New Haven Bowyer",
            "the New Haven Tailor",
            "the New Haven Mapmaker",
            "the New Haven Mage",
            "the New Haven Inn",
            "the New Haven Docks",
            "the New Haven Bank",
            "Springs And Things Workshop",
            "Haven Dojo",
            "Gorge's Shop",
            "Haven Library",
            "Trinsic",
            "Trinsic",
            "Vesper",
            "Vesper",
            "Yew",
            "Yew",
            "A Field of Sheep in Yew 1",
            "A Field of Sheep in Yew",
            "A Field of Sheep in Yew 2",
            "A Field of Sheep in Yew",
            "A Farm in Yew",
            "A Farm in Yew",
            "A Wheatfield in Yew 1",
            "A Wheatfield in Yew",
            "A Wheatfield in Yew 2",
            "A Wheatfield in Yew",
            "Wind",
            "Wind",
            "Serpent's Hold",
            "Serpents",
            "Skara Brae",
            "Skarabra",
            "Nujel'm",
            "Nujelm",
            "Moonglow",
            "Moonglow",
            "The Scholar's Inn",
            "Magincia",
            "Magincia",
            "Buccaneer's Den",
            "BucsDen",
            "Covetous",
            "Dungeon9",
            "Deceit",
            "Dungeon9",
            "Despise",
            "Dungeon9",
            "Destard",
            "Dungeon9",
            "Obsidian Wyvern",
            "Hythloth",
            "Dungeon9",
            "Jail",
            "Green Acres",
            "Shame",
            "Dungeon9",
            "Wrong",
            "Dungeon9",
            "Cave 1",
            "Cave 2",
            "Cave 3",
            "Cave 4",
            "Britain Mine 1",
            "Britain Mine 2",
            "Minoc Cave 1",
            "Minoc Cave 2",
            "Minoc Cave 3",
            "Minoc Mine",
            "Avatar Isle Cave",
            "Ice Isle Cave 1",
            "Ice Isle Cave 2",
            "North Territory Cave",
            "Yew Cave",
            "North Territory Mine 1",
            "North Territory Mine 2",
            "Mt Kendall",
            "Covetous Mine",
            "Terathan Keep",
            "Dungeon9",
            "Fire",
            "Dungeon9",
            "Ice",
            "Dungeon9",
            "Ice Wyrm",
            "Mercutio The Unsavory",
            "BlackthornDungeon",
            "Dungeon9",
            "Blackthorn Castle",
            "LBCastle",
            "Delucia",
            "Papua",
            "Wrong Entrance",
            "Mountn_a",
            "Covetous Entrance",
            "Vesper",
            "Despise Entrance",
            "Despise Passage",
            "Misc Dungeons",
            "Dungeon9",
            "Orc Cave",
            "Dungeon9",
            "Orc Engineer",
            "A Cotton Field in Moonglow",
            "A Cotton Field in Moonglow",
            "A Wheatfield in Skara Brae 1",
            "A Wheatfield in Skara Brae",
            "A Carrot Field in Skara Brae",
            "An Onion Field in Skara Brae",
            "A Cabbage Field in Skara Brae 1",
            "A Cabbage Field in Skara Brae 2",
            "A Wheatfield in Skara Brae 2",
            "A Cotton Field in Skara Brae",
            "FireIsleCasino",
            "Shrine of Compassion",
            "Chaos Shrine",
            "Shrine of Honesty",
            "Shrine of Honor",
            "Shrine of Humility",
            "Shrine of Justice",
            "Shrine of Sacrifice",
            "Shrine of Spirituality",
            "Shrine of Valor",
            "South Britannian Sea",
            "Paroxysmus Exit",
            "Sanctuary Entrance",
            "Solen Hives",
            "Sea Market",
            "Ilshenar",
            "Djinn",
            "Twisted Weald",
            "DreadHornArea",
            "Twisted Weald Desert",
            "Sheep Farm",
            "Shrine of Valor",
            "Chaos Shrine",
            "Shrine of Sacrifice",
            "Shrine of Honesty",
            "Shrine of Compassion",
            "Shrine of Spirituality",
            "Shrine of Humility",
            "Shrine of Honor",
            "Terort Skitas",
            "Ver Lor Reg",
            "Pormir Harm",
            "Stones2",
            "Pormir Felwis",
            "Cyclops Temple",
            "Rat Fort",
            "Rat Fort Cellar",
            "Entrance to Central Ilshenar 1",
            "Entrance to Central Ilshenar 2",
            "Montor",
            "Termir Flam",
            "Ancient Citadel",
            "Alexandretta's Bowl",
            "Entrance to Rock Dungeon",
            "Rock Dungeon",
            "Lenmir Anfinmotas",
            "Entrance to Spider Cave",
            "Spider Cave",
            "Twin Oaks",
            "Reg Volon",
            "Entrance Spectre Dungeon",
            "Spectre Dungeon",
            "Entrance Blood Dungeon",
            "Blood Dungeon",
            "Entrance Mushroom Cave",
            "Mushroom Cave",
            "Lake Shire",
            "Entrance Rat Cave",
            "Rat Cave Territory",
            "Ratman Cave",
            "Bet-Lem Reg",
            "Mistas",
            "Entrance Serpentine Passage",
            "Serpentine Passage",
            "Ankh Dungeon",
            "Kirin passage",
            "Entrance Lizards Passage",
            "Wisp Dungeon",
            "Lizard Passage",
            "Exodus Dungeon",
            "Lizard Man's Huts",
            "Nox Tereg",
            "Sorcerer's Dungeon",
            "Entrance Ancient Lair",
            "Ancient Lair",
            "Gypsy Camp",
            "Gypsy Camp 1",
            "Gypsy Camp 2",
            "Juka Camp",
            "Gypsy Camp 3",
            "Gypsy Camp 4",
            "Gypsy Camp 5",
            "Gypsy Camp 6",
            "Lord Blackthorn's Ilshenar Castle",
            "Shrine of the Virtues",
            "Pass of Karnaugh",
            "Vinculum Inn",
            "Malas",
            "Gravewater Lake [Underwater]",
            "Gravewater Dock",
            "Bedlam",
            "GrizzleDungeon",
            "Labyrinth",
            "Dungeon9",
            "TheCitadel",
            "Dungeon9",
            "Luna",
            "tavern04",
            "Umbra",
            "Doom",
            "Dungeon9",
            "Doom Guardian Room",
            "Doom Gauntlet",
            "Dungeon9",
            "Orc Fortress",
            "Crystal Cave Entrance",
            "Protected Island",
            "Grand Arena",
            "Hanse's Hostel",
            "Yomotsu Mines",
            "TokunoDungeon",
            "Fan Dancer's Dojo",
            "TokunoDungeon",
            "Samurai start location",
            "Zento",
            "Ninja start location",
            "Zento",
            "Ninja cave",
            "Isle of the Divide",
            "Tokuno",
            "Moongates",
            "Zento",
            "Zento",
            "Fan Dancer's Dojo",
            "Bushido Dojo",
            "Tokuno Docks",
            "TerMur",
            "Abyss",
            "StygianAbyss",
            "Abyssal Lair",
            "MedusasLair",
            "NPC Encampment",
            "Cavern of the Discarded",
            "Chamber of Virtue",
            "Crimson Veins",
            "Enslaved Goblins",
            "Fairy Dragon Lair",
            "Fire Temple Ruins",
            "Fractured City",
            "Lands of the Lich",
            "Lava Caldera",
            "Passage of Tears",
            "Secret Garden",
            "Serpents Lair",
            "Silver Sapling",
            "Skeletal Dragon",
            "Sutek the Mage",
            "Underworld",
            "HumanLevel",
            "Atoll Bend",
            "Chicken Chase",
            "Chicken Chase",
            "Fishermans Reach",
            "Gated Isle",
            "High Plain",
            "Holy City",
            "Holycity",
            "Kepetch Waste",
            "Lost Settlement",
            "Moongates",
            "Northern Steppes",
            "Raptor Island",
            "Royal City",
            "RoyalCity",
            "Queen's Palace",
            "QueenPalace",
            "Royal City Inn",
            "Royal Park",
            "Slith Valley",
            "Spider Island",
            "StygianDragonLair",
            "StygianDragon",
            "Talon Point",
            "Toxic Desert",
            "Toxic Desert",
            "Void Island",
            "Volcano",
            "Walled Circus",
            "Waterfall Point",
            "Shrine of Singularity",
            "CodexShrine",
            "Tomb of Kings",
            "ToK Bridge",
            "GreatApeLair",
            "ZipactriotlLair",
            "MyrmidexQueenLair",
            "MyrmidexBattleground",
            "KotlCity",
            "Sosaria",
            "Death Gulch",
            "Cove",
            "Death Gulch Inn",
            "Death Gulch Inn",
            "Devil Guard",
            "Serpents",
            "Devil Guard Inn",
            "Devil Guard Inn",
            "the town of Moon",
            "ElfCity",
            "Trinsic Inn",
            "Trinsic Inn",
            "the town of Grey",
            "Ocllo",
            "Grey Inn",
            "Grey Inn",
            "the town of West Montor",
            "Minoc",
            "West Montor Inn",
            "West Montor Inn",
            "the town of East Montor",
            "Minoc",
            "East Montor Inn",
            "East Montor Inn",
            "the town of Fawn",
            "Nujelm",
            "Fawn Inn",
            "Fawn Inn",
            "the town of Yew",
            "Yew",
            "Yew Inn",
            "Yew Inn",
            "the town of Britain",
            "Britain1",
            "Britain Inn",
            "Britain Inn",
            "Pirate Isle",
            "BucsDen",
            "Jail",
            "Linelle",
            "some Farmlands",
            "an Abandoned Home",
            "the Lighthouse",
            "a Haunted Forest",
            "Dungeon9",
            "Orc Territory",
            "Samlethe",
            "some Old Ruins",
            "Approach",
            "a Cemetary",
            "Dungeon2",
            "an Old Fortress",
            "Approach",
            "the Dark Tower",
            "Approach",
            "a Mountain Stronghold",
            "Approach",
            "Vinterdale Isle",
            "Vesper",
            "the Iceclad Fisherman's Village",
            "Paws",
            "Fisherman's Inn",
            "Fisherman's Inn",
            "the Mountain Crest Village",
            "Skarabra",
            "Mountain Crest Inn",
            "Mountain Crest Inn",
            "the Shingorr Village",
            "Jhelom",
            "Shingorr Inn",
            "Shingorr Inn",
            "Unknown Land",
            "MinocNegative",
            "Inn",
            "Unknown Inn",
            "the town of Renika",
            "Magincia",
            "Renika Inn",
            "Renika Inn",
            "a Cathedral",
            "Ambrosia",
            "Vesper",
            "a Ababdoned Town",
            "Moonglow",
            "Dawn",
            "Vesper",
            "the town of Dawn",
            "Wind",
            "Dawn Inn",
            "Dawn Inn",
            "Etherial Plane",
            "Vesper",
            "the etherial town of Dawn",
            "Wind",
            "Etherial Inn",
            "Etherial Inn",
            "Green Acres",
            "Moonglow",
            "the Start Room",
            "Minoc",
            "the Town Room",
            "Minoc",
            "at or near a Dungeon Entrance",
            "the Caverns under the Britain Cemetery",
            "Dungeon9",
            "the Sewers under Britain",
            "Dungeon9",
            "the Doom Dungeon",
            "Dungeon9",
            "the Dardin's Pit Dungeon",
            "ParoxysmusLair",
            "the Perinia Depths Dungeon",
            "Dungeon9",
            "the Time Awaits Dungeon",
            "MelisandesLair",
            "the Clues Dungeon",
            "Dungeon9",
            "the Mines Of Morinia Dungeon",
            "Dungeon9",
            "the Fires Of Hell Dungeon",
            "Dungeon9",
            "the Ancient Pyramid",
            "Dungeon9",
            "the Kings Chamber",
            "Dungeon9",
            "the Time Lord's Chamber",
            "Dungeon9",
            "a Player's Dungeon",
            "Dungeon9",
            "the Caverns under Dawn",
            "Dungeon9",
            "a Cave",
            "Mountn_a",
            "the Frost Guard Dungeon",
            "Dungeon9",
            "the Cresent Cavern Dungeon",
            "Dungeon9",
            "the Ice Cavern Dungeon",
            "Dungeon9",
            "the Icy Depths Dungeon",
            "Dungeon9",
            "the Witchen Delve Dungeon",
            "Dungeon9",
            "the Dragon's Eye Watch Dungeon",
            "Dungeon9",
            "the Ancient Catacombs",
            "Dungeon9",
            "the Exodus Dungeon",
            "Dungeon9"
        };

        // ── ❷ Shared rewards ────────────────────────────────────────────
        private static readonly Type[] DefaultRewardPool =
            QuestScrollRewards.m_Rewards;                           

        // ── ❸ Quest state ─────────────────────────────────────────────
        private string                             _regionName;
        private int                                _needKills;
        private int                                _gotKills;
        private int                                _repReward;
        private XmlMobFactions.GroupTypes         _faction;
        private List<Type>                        _rewardTypes;

        // ── ❹ GM-exposed properties ────────────────────────────────────
        [CommandProperty(AccessLevel.GameMaster)]
        public string RegionName  => _regionName;                         

        [CommandProperty(AccessLevel.GameMaster)]
        public int NeedKills      { get => _needKills; set => _needKills  = Math.Max(1, value); }

        [CommandProperty(AccessLevel.GameMaster)]
        public int GotKills       { get => _gotKills;  set => _gotKills   = Math.Max(0, value); }

        [CommandProperty(AccessLevel.GameMaster)]
        public XmlMobFactions.GroupTypes Faction
            { get => _faction;    set => _faction   = value; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RepReward      { get => _repReward; set => _repReward = Math.Max(0, value); }

        // ── ❺ Constructors ────────────────────────────────────────────

        // Parameterless: defaults region & faction; picks random kills and rep
        [Constructable]
        public FactionRegionKillQuestScroll()
            : this(null, 0, XmlMobFactions.GroupTypes.Player, 0, new Type[0])
        {
        }

        // Full customization: region, kills, faction, rep, and item rewards
        [Constructable]
        public FactionRegionKillQuestScroll(
            string customRegion,
            int    customKills,
            XmlMobFactions.GroupTypes faction,
            int    customRep,
            params Type[] customRewards
        ) : base(0x14EF) // parchment scroll graphic
        {
            Weight   = 1.0;
            LootType = LootType.Blessed;
            Hue      = 0x4B5;

            // 1️⃣ pick a region name
            _regionName = !String.IsNullOrEmpty(customRegion)
                          ? customRegion
                          : DefaultRegionPool[Utility.Random(DefaultRegionPool.Length)];

            // 2️⃣ pick kill count
            _needKills  = (customKills > 0) ? customKills : Utility.RandomMinMax(10, 20);

            // 3️⃣ set faction & rep reward
            _faction    = faction;
            _repReward  = (customRep  > 0) ? customRep  : _needKills * 50;

            // 4️⃣ pick item rewards
            _rewardTypes = (customRewards != null && customRewards.Length > 0)
                           ? customRewards.ToList()
                           : PickRandomRewardTypes();

            Name = $"Faction Region Kill Quest: {_needKills} kills in {_regionName}";
        }

        // Shortcut for staff: [add FactionRegionKillQuestScroll <Faction> <Rep> ...]
        [Constructable]
        public FactionRegionKillQuestScroll(
            XmlMobFactions.GroupTypes faction,
            int    repAmount,
            params Type[] customRewards
        ) : this(null, 0, faction, repAmount, customRewards)
        {
        }

        // Helper to grab 1–4 random item rewards
        private static List<Type> PickRandomRewardTypes()
        {
            int count = Utility.RandomMinMax(1, 4);
            return DefaultRewardPool
                   .OrderBy(_ => Utility.Random(0x10000))
                   .Take(count)
                   .ToList();
        }

        // ── ❻ Show the quest gump ──────────────────────────────────────
        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1047012); // must be in backpack
                return;
            }

            from.SendGump(new FactionRegionKillQuestGump(from, this));
        }

        private class FactionRegionKillQuestGump : Gump
        {
            private readonly FactionRegionKillQuestScroll _scroll;

            public FactionRegionKillQuestGump(Mobile from, FactionRegionKillQuestScroll scroll)
                : base(75, 50)
            {
                _scroll = scroll;

                int lines  = _scroll._rewardTypes.Count;
                int height = 180 + lines * 25;

                AddPage(0);
                AddBackground(0, 0, 300, height, 9270);

                AddLabel(40, 20, 54, "Faction Region Kill Quest");

                int y = 50;
                AddLabel(40, y, 54, $"Region:      {_scroll._regionName}"); y += 20;
                AddLabel(40, y, 54, $"Need kills:  {_scroll._needKills}");   y += 20;
                AddLabel(40, y, 54, $"Killed:      {_scroll._gotKills}");    y += 20;
                AddLabel(40, y, 54, 
                    $"Faction Rep: {_scroll._repReward} ({_scroll._faction})"
                );                                                       y += 20;

                AddLabel(40, y, 54, "Rewards:"); y += 20;
                foreach (var rt in _scroll._rewardTypes)
                {
                    AddLabel(60, y, 54, rt.Name);
                    y += 20;
                }

                if (_scroll._gotKills < _scroll._needKills)
                {
                    AddButton(40, y, 4005, 4007, 1, GumpButtonType.Reply, 0);
                    AddLabel(75, y, 54, "Add Kill");
                }
                else
                {
                    AddButton(40, y, 4005, 4007, 2, GumpButtonType.Reply, 0);
                    AddLabel(75, y, 54, "Claim Reward");
                }
            }

            public override void OnResponse(NetState state, RelayInfo info)
            {
                var from = state.Mobile;

                if (info.ButtonID == 1)
                    from.Target = new RegionKillQuestTarget(_scroll);
                else if (info.ButtonID == 2)
                    _scroll.TryClaim(from);
            }
        }

        // ── ❼ Target a corpse in the region ────────────────────────────
        private class RegionKillQuestTarget : Target
        {
            private readonly FactionRegionKillQuestScroll _scroll;

            public RegionKillQuestTarget(FactionRegionKillQuestScroll scroll)
                : base(1, false, TargetFlags.None)
            {
                _scroll = scroll;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Corpse corpse)
                {
                    var reg = Region.Find(corpse.Location, corpse.Map);
                    if (reg != null && reg.Name == _scroll._regionName)
                    {
                        _scroll._gotKills++;
                        from.SendMessage("Kill recorded!");
                        corpse.Delete();

                        if (_scroll._gotKills < _scroll._needKills)
                            from.Target = new RegionKillQuestTarget(_scroll);
                        else
                            from.SendGump(new FactionRegionKillQuestGump(from, _scroll));
                        return;
                    }
                    from.SendMessage("That corpse isn’t in the required region.");
                }
                else
                {
                    from.SendMessage("That is not a corpse.");
                }
            }
        }

        // ── ❽ Claiming the reward ───────────────────────────────────────
        private void TryClaim(Mobile from)
        {
            if (_gotKills < _needKills)
            {
                from.SendMessage("You haven’t completed the quest yet.");
                return;
            }

            // Award faction reputation instead of gold
            GiveFactionRep(from, _faction, _repReward);

            // Item rewards
            foreach (var t in _rewardTypes)
                if (Activator.CreateInstance(t) is Item itm)
                    from.AddToBackpack(itm);

            from.SendMessage("Your rewards are in your backpack!");
            Delete();
        }

        // ── ❾ Persistence ───────────────────────────────────────────────
        public FactionRegionKillQuestScroll(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version

            writer.Write(_regionName);
            writer.Write(_needKills);
            writer.Write(_gotKills);

            writer.Write((int)_faction);
            writer.Write(_repReward);

            writer.Write(_rewardTypes.Count);
            foreach (var t in _rewardTypes)
                writer.Write(t.AssemblyQualifiedName);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            _regionName = reader.ReadString();
            _needKills  = reader.ReadInt();
            _gotKills   = reader.ReadInt();

            _faction    = (XmlMobFactions.GroupTypes)reader.ReadInt();
            _repReward  = reader.ReadInt();

            int count = reader.ReadInt();
            _rewardTypes = new List<Type>();
            for (int i = 0; i < count; i++)
            {
                var t = Type.GetType(reader.ReadString());
                if (t != null)
                    _rewardTypes.Add(t);
            }
        }

        // ── 🔧 Helper to safely add faction rep ─────────────────────────
        private static void GiveFactionRep(
            Mobile player,
            XmlMobFactions.GroupTypes faction,
            int amount)
        {
            if (amount <= 0) return;

            // Try to find the existing attachment
            var x = XmlAttach.FindAttachment(
                        player, typeof(XmlMobFactions), "Standard"
                    ) as XmlMobFactions;

            // If none, create one
            if (x == null)
            {
                x = new XmlMobFactions();
                XmlAttach.AttachTo(player, player, x);
            }

            int current = x.GetFactionLevel(faction);
            x.SetFactionLevel(faction, current + amount);
            player.SendMessage($"You gain {amount} reputation with {faction}!");
        }
    }
}
