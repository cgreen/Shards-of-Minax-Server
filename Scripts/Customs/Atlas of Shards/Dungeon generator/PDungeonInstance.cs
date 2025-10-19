using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Regions;

namespace Server.Engines.ProceduralDungeon
{
    public class PDungeonInstance
    {
        public PDungeonController Controller { get; }
        public Point3D Center { get; }
		public int Radius => _radius;

        private readonly int _radius;
        private readonly List<Item> _tiles = new List<Item>();
        private readonly List<Item> _portals = new List<Item>();
        private readonly BaseRegion _region;
        private IMapBlueprint _blueprint;
        private DateTime _started;

        /// <summary>When the run actually began.</summary>
        public DateTime Started { get; private set; }

        /// <summary>How many terrain statics we dropped.</summary>
        public int TileCount => _tiles.Count;

        public bool InUse => _tiles.Count > 0 || _portals.Count > 0;

        public PDungeonInstance(PDungeonController controller, Point3D center, int radius)
        {
            Controller = controller;
            Center = center;
            _radius = radius;

            var bounds = new Rectangle2D(
                center.X - radius, center.Y - radius,
                radius * 2, radius * 2
            );
            _region = new BaseRegion("PDungeon", Map.Trammel, 30, bounds);
            _region.Register();
        }

        /// <summary>
        /// Try to kick off a run: spawns portals, terrain, content, teleports leader.
        /// </summary>
        public bool TryStart(PlayerMobile leader, IMapBlueprint blueprint)
        {
            if (InUse)
                return false;

            _blueprint = blueprint;

            // 1) Terrain
            foreach (var def in blueprint.GenerateTiles(Center))
            {
                var loc = new Point3D(
                    Center.X + def.Offset.X,
                    Center.Y + def.Offset.Y,
                    Center.Z + def.Offset.Z
                );

                var stat = new Static(def.ItemID) { Hue = def.Hue };
                stat.MoveToWorld(loc, Map.Trammel);
                _tiles.Add(stat);
            }

            // 2) Content
            blueprint.SpawnContent(Center, Map.Trammel, leader);

            // 3) Find a valid walkable spawn location inside the pad
            var spawnLoc = FindValidSpawnLocation(Center, Map.Trammel);

            // 4) Spawn entry/return portals at correct locations
            SpawnPortals(spawnLoc);

            // 5) Teleport leader into the instance
            leader.MoveToWorld(spawnLoc, Map.Trammel);

            // 6) Mark the pad as in-use
            _started = DateTime.UtcNow;
            Started = _started;

            return true;
        }

        /// <summary>
        /// Tries up to 20 times to find a walkable spot inside the pad's bounds.
        /// </summary>
        private Point3D FindValidSpawnLocation(Point3D centre, Map map)
        {
            for (int i = 0; i < 20; i++)
            {
                int x = centre.X + Utility.RandomMinMax(-_radius, _radius);
                int y = centre.Y + Utility.RandomMinMax(-_radius, _radius);
                int z = map.GetAverageZ(x, y);
                var pt = new Point3D(x, y, z);

                if (map.CanSpawnMobile(pt))
                    return pt;
            }
            // fallback: dead‐center
            return centre;
        }

        public void Tick()
        {
            if (!InUse) return;

            if (DateTime.UtcNow - _started > Controller.LifeTime)
                CleanUp();
        }

        /// <summary>Removes statics, portals, and notifies blueprint to clean up.</summary>
        public void CleanUp()
        {
            foreach (var t in _tiles.ToArray())
                t.Delete();
            _tiles.Clear();

            foreach (var p in _portals.ToArray())
                p.Delete();
            _portals.Clear();

            _blueprint?.OnCleanup();
        }

        /// <summary>
        /// Spawns six entry portals around the device and a single six-use return portal at the spawn location.
        /// </summary>
        private void SpawnPortals(Point3D playerSpawn)
        {
            var ctrl = Controller;
            var deviceLoc = ctrl.Location;   // Map Device world pos
            var deviceMap = ctrl.Map;

            // Six one-use entry portals (like PoE)
            for (int i = 0; i < 6; i++)
            {
                double angle = (Math.PI * 2 / 6) * i;
                int dx = (int)Math.Round(Math.Cos(angle) * 3);
                int dy = (int)Math.Round(Math.Sin(angle) * 3);

                var entry = new OriginPortal(ctrl.PortalHue, ctrl.PortalSound);
                entry.Destination = playerSpawn;
                entry.DestinationMap = Map.Trammel;

                entry.MoveToWorld(
                  new Point3D(deviceLoc.X + dx, deviceLoc.Y + dy, deviceLoc.Z),
                  deviceMap
                );

                _portals.Add(entry);
            }

            // One six-use return portal at spawn location
            var ret = new ReturnPortal(ctrl.PortalHue, ctrl.PortalSound, uses: 6);
            ret.Destination = ctrl.Location;
            ret.DestinationMap = ctrl.Map;

            ret.MoveToWorld(playerSpawn, Map.Trammel);
            _portals.Add(ret);
        }
    }
}
