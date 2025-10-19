// File: Server/Items/SatyrGroveXml.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.Items;
using Server.Engines.XmlSpawner2;
using Server.Engines.ProceduralDungeon;
using Server.Mobiles;
using Server.Commands.Encounters;

namespace Server.Items
{
    public class SatyrGroveXml : ProceduralMagicMapBase
    {
        // ───────────────────────── CONFIG ─────────────────────────
        private static readonly List<Func<XmlSpawner.SpawnObject[]>> _encounterPool =
            new List<Func<XmlSpawner.SpawnObject[]>>()
            {
                Encounter_BrownBear.GetSpawnObjects
            };

        private int SpawnersToCreate => Tier;   // 1 spawner per tier level
        // ───────────────────────────────────────────────────────────

        [Constructable]
        public SatyrGroveXml()
            : base(0x14EB,
                   "Bear Test",
                   550)
        { }

        public SatyrGroveXml(Serial s) : base(s) { }

        // identical to TestGrove – keep your mossy maze
        public override IEnumerable<TileDef> GenerateTiles(Point3D centre)
            => RoomMazeGenerator.Generate(
                   gridSize: 100,
                   roomCount: 8,
                   minRoomSize: 6,
                   maxRoomSize: 11,
                   floorItemID: 0x177D,
                   fillItemID: 0x1797,
                   floorHue: 1417,
                   fillHue: 298);

        public override void SpawnChallenges(Point3D centre, Map map,
                                             SpawnedContent content, Mobile owner)
        {
            // ─── ① gather all token substitutions from the active modifiers
            var tokens = ActiveModifiers
                         .SelectMany(m => m.StringTokens())
                         .ToArray();

            for (int i = 0; i < SpawnersToCreate; i++)
            {
                // pick an encounter definition
                var soOriginal = _encounterPool[Utility.Random(_encounterPool.Count)]();

				// ─── ② apply tokens to each spawn string
				var soPatched = soOriginal
					.Select(o => new XmlSpawner.SpawnObject(
						MagicMapBase.ApplyStringTokens(o.TypeName, tokens),   // <- use TypeName
						o.ActualMaxCount))                                    //     (keep this)
					.ToArray();


                // ─── ③ build spawner with the patched list
                var sp = new XmlSpawner(
                    Guid.NewGuid(),                    // uniqueId
                    0, 0, 0, 0,                        // xOffset, yOffset, width, height
                    "Satyr Encounter",                 // name
                    soPatched.Sum(o => o.ActualMaxCount),     // maxCount
                    TimeSpan.FromSeconds(1),          // minDelay
                    TimeSpan.FromSeconds(2),          // maxDelay
                    TimeSpan.Zero,                     // duration
                    -1,                                // proximityRange
                    0x1F4,                             // proximityTriggerSound
                    1,                                 // amount
                    0,                                 // team
                    SpawnRadius,                       // homeRange
                    false,                             // isRelativeHomeRange
                    soPatched,                         // spawnObjects

                    // ──── EXTRA ──── (rest unchanged)
					TimeSpan.Zero,                     // minRefractory
					TimeSpan.Zero,                     // maxRefractory
					TimeSpan.Zero,                     // todStart
					TimeSpan.Zero,                     // todEnd
					null,                              // objectPropertyItem
					"",                                // objectPropertyName
					"",                                // proximityMessage
					"",                                // itemTriggerName
					"",                                // noItemTriggerName
					"",                                // speechTrigger
					"",                                // mobTriggerName
					"",                                // mobPropertyName
					"",                                // playerPropertyName   ← **this was missing**
					1.0,                               // triggerProbability
					null,                              // setPropertyItem
					false,                             // isGroup
					0,       						   // todMode
					0,                                 // killReset
					false,                             // externalTriggering
					-1,                                // sequentialSpawning
					null,                              // regionName
					false,                             // allowGhost
					false,                             // allowNpc
					false,                             // spawnOnTrigger
					null,                              // configFile
					TimeSpan.Zero,                     // despawnTime
					null,                              // skillTrigger
					false,                             // smartSpawning
					null                               // wayPoint
                );

                sp.SpawnRange = SpawnRadius;   // allow each spawn to scatter

                // place it in the world
                var loc = GetValidItemSpawnPoint(sp, centre, map, SpawnRadius);
                sp.MoveToWorld(loc, map);
                content.SpawnedEntities.Add(sp);
            }

            // chests & ore as usual
            base.SpawnChallenges(centre, map, content, owner);
        }

        public override void Serialize(GenericWriter w)
        {
            base.Serialize(w);
            w.Write(0);
        }

        public override void Deserialize(GenericReader r)
        {
            base.Deserialize(r);
            _ = r.ReadInt();
        }
    }
}
