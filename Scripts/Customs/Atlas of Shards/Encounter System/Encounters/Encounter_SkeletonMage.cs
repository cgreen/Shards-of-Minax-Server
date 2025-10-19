using System;
using Server.Mobiles;

namespace Server.Commands.Encounters
{
    public static class Encounter_SkeletonMage
    {
        /// <summary>
        /// Returns a 2‐Skeleton + 1‐SkeletalMage (Hue=2108) encounter.
        /// </summary>
        public static XmlSpawner.SpawnObject[] GetSpawnObjects()
        {
            return new XmlSpawner.SpawnObject[]
            {
                new XmlSpawner.SpawnObject("Skeleton",             2),
                new XmlSpawner.SpawnObject("SkeletalMage/Hue/2108", 1)
            };
        }
    }
}
