using System;
using System.Collections.Generic;
using Server;               // for Point3D, Map
using Server.Mobiles;      // for Mobile
using Server.Items;        // for Item, TileDef

namespace Server.Engines.ProceduralDungeon
{
    /// <summary>
    /// Encapsulates: (a) terrain generation, (b) mob/chest/etc. spawning,
    /// (c) cleanup (e.g. deleting portals or the scroll itself).
    /// </summary>
    public interface IMapBlueprint
    {
        /// <summary> Unique key (e.g. "EarthClanLair", "Maze") </summary>
        string Id { get; }
        /// <summary> What the gump will display </summary>
        string DisplayName { get; }
        /// <summary> Tier or Level, if you care to sort </summary>
        int    Tier { get; }
        /// <summary> How long until this instance auto-expires </summary>
        TimeSpan Lifetime { get; }

        /// <summary>
        /// Produce all the statics for this map,
        /// *relative* to centre.
        /// </summary>
        IEnumerable<TileDef> GenerateTiles(Point3D centre);

        /// <summary>
        /// Do all the spawns (monsters, chests, pets, return portals, etc.).
        /// </summary>
        void SpawnContent(Point3D centre, Map map, Mobile owner);

        /// <summary>
        /// Called when the pad cleans up.  Delete portals, or
        /// delete the scroll item, etc.
        /// </summary>
        void OnCleanup();
    }
}
