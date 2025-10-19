using System;
using System.Collections.Generic;
using Server;                // for Point3D, Map
using Server.Items;          // for MagicMapBase, MapModifier
using Server.Mobiles;        // for Mobile
using Server.Engines.ProceduralDungeon;  // for TileDef, IMapBlueprint
using Server.Engines.ProceduralDungeon;  // for RoomMazeGenerator
using Server.Items;          // for EarthClanNinjaLairMap

namespace Server.Engines.ProceduralDungeon
{
    /// <summary>
    /// A totally random maze.
    /// </summary>
    public class RandomMazeBlueprint : IMapBlueprint
    {
        public string   Id          => "Maze";
        public string   DisplayName => "Chaotic Maze";
        public int      Tier        => 1;
        public TimeSpan Lifetime    => TimeSpan.FromMinutes(30);

        public IEnumerable<TileDef> GenerateTiles(Point3D centre)
        {
            // Uses your RoomMazeGenerator under the hood
            return RoomMazeGenerator.Generate(
                gridSize: 100,
                roomCount: 10,
                minRoomSize: 5,
                maxRoomSize: 10
            );
        }

        public void SpawnContent(Point3D centre, Map map, Mobile owner)
        {
            // no special spawns beyond rooms; you could drop loot here
        }

        public void OnCleanup() { }
    }

    /// <summary>
    /// Hybrid: carve a maze, then run EarthClanNinjaLairMap spawns inside it.
    /// </summary>
    public class CombinedEarthClanMazeBlueprint : IMapBlueprint
    {
        private readonly EarthClanNinjaLairMap _map = new EarthClanNinjaLairMap();

        public string   Id          => "EarthClanMaze";
        public string   DisplayName => "Earth Clan Maze Lair";
        public int      Tier        => _map.Tier;
        public TimeSpan Lifetime    => TimeSpan.FromMinutes(30);

        public IEnumerable<TileDef> GenerateTiles(Point3D centre)
        {
            return RoomMazeGenerator.Generate(
                gridSize: 100,
                roomCount: 10,
                minRoomSize: 5,
                maxRoomSize: 10
            );
        }

        public void SpawnContent(Point3D centre, Map map, Mobile owner)
        {
            var content = new MagicMapBase.SpawnedContent(
                              _map, owner, centre, map, Lifetime);

            _map.SpawnChallenges(centre, map, content, owner);
            foreach (var mod in _map.ActiveModifiers)
                mod.Apply(_map, content);
        }

        public void OnCleanup()
        {
            // delete the underlying template map if desired
            _map.Delete();
        }
    }

    /// <summary>
    /// Holds all the static, code-only blueprints.
    /// </summary>
    public static class MapBlueprintRegistry
    {
        private static readonly Dictionary<string, IMapBlueprint> _all
            = new Dictionary<string, IMapBlueprint>(StringComparer.OrdinalIgnoreCase);

        static MapBlueprintRegistry()
        {
            Register(new RandomMazeBlueprint());
            Register(new CombinedEarthClanMazeBlueprint());
            // …add more here
        }

        public static void Register(IMapBlueprint bp) => _all[bp.Id] = bp;
        public static IEnumerable<IMapBlueprint> All => _all.Values;
        public static IMapBlueprint Get(string id)
            => _all.TryGetValue(id, out var bp) ? bp : null;
    }
}
