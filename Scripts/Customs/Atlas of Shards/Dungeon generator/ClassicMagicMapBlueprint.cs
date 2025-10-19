using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ProceduralDungeon
{
    /// <summary>
    /// Handles a “classic” MagicMapBase item by:
    ///  • choosing one random PredefinedLocation
    ///  • spawning six entry portals around the device all to that spot
    ///  • spawning one six-use return portal at that spot
    ///  • running the map’s SpawnChallenges + modifiers at that spot
    ///  • deleting the scroll
    /// </summary>
    public class ClassicMagicMapBlueprint
    {
        private readonly MagicMapBase        _mapItem;
        private readonly List<MapModifier>   _modsSnap;
        private readonly Mobile              _owner;

        public ClassicMagicMapBlueprint(MagicMapBase mapItem, Mobile owner)
        {
            _mapItem  = mapItem;
            _owner    = owner;
            // freeze the rolled modifiers so they apply exactly as on the scroll
            _modsSnap = mapItem.ActiveModifiers.ToList();
        }

        public void Activate(PDungeonController controller)
        {
            var deviceLoc = controller.Location;
            var deviceMap = controller.Map;
            var hue       = controller.PortalHue;
            var sound     = controller.PortalSound;

            // 1) Pick exactly one spot at random
            var allSpots = _mapItem.PredefinedLocations;
            if (allSpots == null || allSpots.Count == 0)
                return; // nothing to do

            var targetIdx = Utility.Random(allSpots.Count);
            var targetLoc = allSpots[targetIdx];
            var targetMap = _mapItem.DestinationFacet;

            // 2) Six one-use entry portals at the device
            for (int i = 0; i < 6; i++)
            {
                double angle = (Math.PI * 2 / 6) * i;
                int dx = (int)Math.Round(Math.Cos(angle) * 3);
                int dy = (int)Math.Round(Math.Sin(angle) * 3);

                var entry = new OriginPortal(hue, sound);
                entry.Destination    = targetLoc;
                entry.DestinationMap = targetMap;
                entry.MoveToWorld(
                    new Point3D(deviceLoc.X + dx, deviceLoc.Y + dy, deviceLoc.Z),
                    deviceMap
                );
            }

            // 3) One six-use return portal at the spot
            var ret = new ReturnPortal(hue, sound, uses: 6);
            ret.Destination    = controller.Location;
            ret.DestinationMap = controller.Map;
            ret.MoveToWorld(targetLoc, targetMap);

            // 4) Spawn the map’s challenges & apply modifiers
            var content = new MagicMapBase.SpawnedContent(
                              _mapItem, _owner, targetLoc, targetMap, _mapItem.ExpirationTime);

            _mapItem.SpawnChallenges(targetLoc, targetMap, content, _owner);
            foreach (var mod in _modsSnap)
                mod.Apply(_mapItem, content);

            // 5) Finally delete the scroll
            _mapItem.Delete();
        }
    }
}
