using System;
using Server.Mobiles;

namespace Server.Commands.Encounters
{
    public static class Encounter_Camps
    {
        /// <summary>
        /// Returns camp entry.
        /// </summary>
        public static XmlSpawner.SpawnObject[] GetSpawnObjects()
        {
            return new XmlSpawner.SpawnObject[]
            {
                new XmlSpawner.SpawnObject("BankerCamp", 2),
                new XmlSpawner.SpawnObject("ElfBrigandCamp", 2),
                new XmlSpawner.SpawnObject("BrigandCamp", 2),
                new XmlSpawner.SpawnObject("HealerCamp", 2),
                new XmlSpawner.SpawnObject("LizardmenCamp", 2),
                new XmlSpawner.SpawnObject("MageCamp", 2),
                new XmlSpawner.SpawnObject("OrcCamp", 2),
                new XmlSpawner.SpawnObject("PrisonerCamp", 2),
                new XmlSpawner.SpawnObject("RatCamp", 2),
                new XmlSpawner.SpawnObject("LargeMerchantTower1Addon", 1),				
                new XmlSpawner.SpawnObject("BankerCamp", 2)
            };
        }
    }
}
