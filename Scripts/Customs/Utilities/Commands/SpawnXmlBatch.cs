using System;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.Mobiles;
using Server.Network;
using Server.Items;   // needed for Map enumeration
using Server.Gumps;

namespace Server.Commands.Custom
{
    public class SpawnXmlBatch
    {
        public static void Initialize()
        {
            // Register the command "SpawnXmlBatch" (GM only)
            CommandSystem.Register("SpawnXmlBatch", AccessLevel.GameMaster, new CommandEventHandler(SpawnXmlBatch_OnCommand));
        }

        [Usage("SpawnXmlBatch")]
        [Description("Spawns a batch of XmlSpawners at predefined coordinates, each with a unique creature chosen randomly from a list.")]
        private static void SpawnXmlBatch_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            // 1) Define the list of NPC type names (must exactly match the TypeName used by XmlSpawner, e.g. "BrownBear", "ForestOstard", etc.).
            //    You can expand or contract this list however you like.
            List<string> creatureTypes = new List<string>
            {
                "UltimateAlchemyMaster",
                "AnimalLoreQuestDealer",
                "AnimalTamingQuestDealer",
                "UltimateBlacksmithMaster",
                "CampingQuestDealer"
            };

            // 2) Define the list of world coordinates where you want the XmlSpawners to appear.
            //    Replace these with your actual desired X/Y/Z coordinates and Map.
            List<Point3D> spawnPoints = new List<Point3D>
            {
                new Point3D(5445, 1153, 0),
                new Point3D(5455, 1153, 0),
                new Point3D(5465, 1153, 0),
                new Point3D(5445, 1163, 0),
                new Point3D(5445, 1173, 0)
            };

            // Sanity check: Make sure we have exactly as many creature types as spawn points.
            if (creatureTypes.Count != spawnPoints.Count)
            {
                from.SendMessage(
                    "Error: The creature list count ({0}) does not match the spawn point count ({1}). " +
                    "Please make them equal so each location gets a unique creature.",
                    creatureTypes.Count, spawnPoints.Count
                );
                return;
            }

            // 3) Shuffle the creatureTypes list so assignment to spawnPoints is random.
            Random rnd = new Random();
            for (int i = creatureTypes.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                string tmp = creatureTypes[i];
                creatureTypes[i] = creatureTypes[j];
                creatureTypes[j] = tmp;
            }

            // 4) Now iterate over each coordinate, take one creatureType, and spawn an XmlSpawner.
            //    In this example, we use:
            //      amount = 1,
            //      minDelay = 1 (minutes),
            //      maxDelay = 5 (minutes),
            //      team = 0 (no grouping),
            //      homeRange = 3 (tiles).
            //
            //    Feel free to replace these parameters with whatever suits your world.
            int minDelayMinutes = 1;
            int maxDelayMinutes = 5;
            int team = 0;
            int homeRange = 3;

            Map targetMap = from.Map;  // place all spawners on the GM's current map

            for (int idx = 0; idx < spawnPoints.Count; idx++)
            {
                string creatureName = creatureTypes[idx];
                Point3D loc = spawnPoints[idx];

                // Instantiate a new XmlSpawner that spawns exactly one of creatureName
                XmlSpawner spawner = new XmlSpawner(
                    /* amount */    1,
                    /* minDelay */  minDelayMinutes,
                    /* maxDelay */  maxDelayMinutes,
                    /* team */      team,
                    /* homeRange */ homeRange,
                    /* creatureName */ creatureName
                );

                // Mark this as “player created” so you can see it in XmlSpawnerSave, etc.
                spawner.PlayerCreated = true;

                // Position it in the world at the given coordinate
                spawner.MoveToWorld(loc, targetMap);

                // You can tweak any other properties here, for example:
                //   spawner.SpawnRange = 5;      // override homeRange if desired
                //   spawner.MinDelay =  TimeSpan.FromSeconds(30);
                //   spawner.MaxDelay =  TimeSpan.FromSeconds(60);

                // Finally, you may want to let the GM know:
                from.SendMessage("XmlSpawner for \"{0}\" created at {1}.", creatureName, loc);
            }

            from.SendMessage("{0} XmlSpawners successfully created.", spawnPoints.Count);
        }
    }
}
