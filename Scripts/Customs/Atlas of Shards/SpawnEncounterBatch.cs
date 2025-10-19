using System;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.Mobiles;
using Server.Items;
using Server.Network;

// Replace this with whatever namespace your Encounter_*.cs files live under:
using Server.Commands.Encounters;

namespace Server.Commands.Custom
{
    public class SpawnEncounterBatch
    {
        public static void Initialize()
        {
            CommandSystem.Register(
                "SpawnEncounterBatch",
                AccessLevel.GameMaster,
                new CommandEventHandler(SpawnEncounterBatch_OnCommand)
            );
        }

        [Usage("SpawnEncounterBatch")]
        [Description("Spawns XmlSpawner‐based encounters at random points. " +
                     "If there are more encounters than points (or vice versa), " +
                     "it will wrap around and reuse entries.")]
        private static void SpawnEncounterBatch_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            //
            // 1) Build a weighted list of all available encounters.
            //
            List<XmlSpawner.SpawnObject[]> encounters = new List<XmlSpawner.SpawnObject[]>();

            // Helper method (local to this function) to add 'weight' copies of a given encounter
            void AddWeighted(List<XmlSpawner.SpawnObject[]> list, Func<XmlSpawner.SpawnObject[]> generator, int weight)
            {
                for (int w = 0; w < weight; w++)
                    list.Add(generator());
            }

            // Example: give Orc+Ogre a weight of 3, Goblin+Hobgoblin a weight of 2, 
            // SkeletonMage a weight of 1, BrownBear a weight of 1.
            //
            AddWeighted(encounters, Encounter_OrcOgre.GetSpawnObjects,       3);
            AddWeighted(encounters, Encounter_GoblinHobgoblin.GetSpawnObjects, 2);
            AddWeighted(encounters, Encounter_SkeletonMage.GetSpawnObjects,   1);
            AddWeighted(encounters, Encounter_BrownBear.GetSpawnObjects,      1);

            // …if you add more Encounter_*.cs files, just call AddWeighted for each, 
            // adjusting the last parameter (weight) as desired.

            if (encounters.Count == 0)
            {
                from.SendMessage("Error: No encounters defined. Did you forget to add at least one Encounter_*.cs?");
                return;
            }

            //
            // 2) Build your list of world spawn points. Replace these with your own X, Y, Z coords.
            //
            List<Point3D> spawnPoints = new List<Point3D>
            {
                new Point3D(5445, 1153, 0),
                new Point3D(5455, 1153, 0),
                new Point3D(5465, 1153, 0),
                new Point3D(5445, 1163, 0),
                new Point3D(5445, 1173, 0)
                // … add more points if you like
            };

            if (spawnPoints.Count == 0)
            {
                from.SendMessage("Error: No spawn points defined. Please add at least one Point3D to spawnPoints.");
                return;
            }

            //
            // 3) Shuffle both lists so the pairing is random.
            //
            Random rnd = new Random();

            // Fisher–Yates shuffle for encounters
            for (int i = encounters.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                var tmp = encounters[i];
                encounters[i] = encounters[j];
                encounters[j] = tmp;
            }

            // Fisher–Yates shuffle for spawnPoints
            for (int i = spawnPoints.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                var tmp = spawnPoints[i];
                spawnPoints[i] = spawnPoints[j];
                spawnPoints[j] = tmp;
            }

            //
            // 4) Determine how many spawners to create. We’ll do:
            //      total = Math.Max(encounters.Count, spawnPoints.Count)
            //    so that if one list is shorter, we “wrap around” and reuse entries.
            //
            int totalToSpawn = Math.Max(encounters.Count, spawnPoints.Count);
            Map targetMap   = from.Map;

            // Configuration: adjust these as needed
            int minDelayMinutes = 1;
            int maxDelayMinutes = 3;
            int team            = 0;
            int homeRange       = 3;
            int proximityRange  = -1;      // no proximity trigger
            int proximitySound  = 0x1F4;   // default sparkle sound
            TimeSpan duration   = TimeSpan.Zero; // no automatic “timeout” for the spawner

            for (int i = 0; i < totalToSpawn; i++)
            {
                // Wrap around if we run out of encounters or out of points
                XmlSpawner.SpawnObject[] encounterSo = encounters[i % encounters.Count];
                Point3D               spawnLoc       = spawnPoints[i % spawnPoints.Count];

                // Sum up the “max count” for this encounter (e.g. 5+1=6 for Orc+Ogre)
                int totalMaxCount = 0;
                foreach (var so in encounterSo)
                    totalMaxCount += so.ActualMaxCount;

                // Create a brand‐new GUID for uniqueness
                Guid spawnId = Guid.NewGuid();

                // Instantiate the XmlSpawner with the multi‐object constructor:
                XmlSpawner spawner = new XmlSpawner(
                    /* uniqueId */       spawnId,
                    /* x */              0,
                    /* y */              0,
                    /* width */          0,
                    /* height */         0,
                    /* name */           "Encounter #" + (i + 1),
                    /* maxCount */       totalMaxCount,
                    /* minDelay */       TimeSpan.FromMinutes(minDelayMinutes),
                    /* maxDelay */       TimeSpan.FromMinutes(maxDelayMinutes),
                    /* duration */       duration,
                    /* proximityRange */ proximityRange,
                    /* proximitySound */ proximitySound,
                    /* amount */         1,
                    /* team */           team,
                    /* homeRange */      homeRange,
                    /* isRelativeHome */ false,
                    /* objectsToSpawn */ encounterSo,
                    /* minRefractory */  TimeSpan.Zero,
                    /* maxRefractory */  TimeSpan.Zero,
                    /* todStart */       TimeSpan.Zero,
                    /* todEnd */         TimeSpan.Zero,
                    /* objectPropertyItem */  null,
                    /* objectPropertyName */  null,
                    /* proximityMessage */    null,
                    /* itemTriggerName */     null,
                    /* noItemTriggerName */   null,
                    /* speechTriggerName */   null,
                    /* mobTriggerName */      null,
                    /* mobPropertyName */     null,
                    /* playerPropertyName */  null,
                    /* triggerProbability */  1.0,
                    /* setPropertyItem */     null,
                    /* isGroup */             false,
                    /* todMode */             0,  // default/realtime
                    /* killReset */           1,
                    /* externalTriggering */  false,
                    /* sequentialSpawning */  -1,
                    /* regionName */          null,
                    /* allowGhost */          false,
                    /* allowNPC */            false,
                    /* spawnOnTrigger */      false,
                    /* configFile */          null,
                    /* despawnTime */         TimeSpan.Zero,
                    /* skillTrigger */        null,
                    /* smartSpawning */       false,
                    /* wayPoint */            null
                );

                // If you want a non‐zero “spawn range” (so mobs can pop in 
                // up to N tiles away), set it here. Otherwise leave default (0).
                spawner.SpawnRange = 3;

                // Mark it “player created” so it appears in XmlSpawnerSave, etc.
                spawner.PlayerCreated = true;

                // Finally, put it into the world
                spawner.MoveToWorld(spawnLoc, targetMap);

                from.SendMessage(
                    "Placed {0} (cap {1}) at {2}.",
                    spawner.Name, totalMaxCount, spawnLoc
                );
            }

            from.SendMessage("{0} encounter spawners created total.", totalToSpawn);
        }
    }
}
