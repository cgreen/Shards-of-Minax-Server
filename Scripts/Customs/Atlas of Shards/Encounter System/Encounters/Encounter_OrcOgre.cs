using System;
using Server.Mobiles;

namespace Server.Commands.Encounters
{
    public static class Encounter_OrcOgre
    {
        /// <summary>
        /// Returns a 5‐Orc (Hue=1160, Name=Grunt) + 1‐Ogre (Hue=1150, Name=Bruiser) encounter.
        /// </summary>
        public static XmlSpawner.SpawnObject[] GetSpawnObjects()
        {
            return new XmlSpawner.SpawnObject[]
            {
                new XmlSpawner.SpawnObject("Orc/Hue/1160/Name/Grunt", 5),
                new XmlSpawner.SpawnObject("Ogre/Hue/1150/Name/Bruiser", 1)
            };
        }
    }
}
