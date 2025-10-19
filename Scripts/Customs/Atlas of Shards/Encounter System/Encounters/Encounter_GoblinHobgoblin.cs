using System;
using Server.Mobiles;

namespace Server.Commands.Encounters
{
    public static class Encounter_GoblinHobgoblin
    {
        /// <summary>
        /// Returns a 3‐Goblin + 2‐Hobgoblin encounter (no extra modifiers).
        /// </summary>
        public static XmlSpawner.SpawnObject[] GetSpawnObjects()
        {
            return new XmlSpawner.SpawnObject[]
            {
                new XmlSpawner.SpawnObject("Troll",     3),
                new XmlSpawner.SpawnObject("Llama",  2)
            };
        }
    }
}
