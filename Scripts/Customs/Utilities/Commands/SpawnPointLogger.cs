using System;
using System.IO;
using Server;
using Server.Commands;
using Server.Mobiles;

namespace Server.Custom
{
    public class SpawnPointLogger
    {
        private static readonly string FilePath = "SpawnPoints.txt"; // File is saved in the ServUO root folder

        public static void Initialize()
        {
            CommandSystem.Register("AddSpawnPoint", AccessLevel.Administrator, new CommandEventHandler(AddSpawnPoint_OnCommand));
        }

        [Usage("AddSpawnPoint")]
        [Description("Logs your current position to SpawnPoints.txt in the correct format.")]
        public static void AddSpawnPoint_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from == null)
                return;

            string mapName = GetMapName(from.Map);
            Point3D location = from.Location;

            string output = $"new SpawnPoint(Map.{mapName}, new Point3D({location.X}, {location.Y}, {location.Z})),";
            File.AppendAllText(FilePath, output + Environment.NewLine);

            from.SendMessage(0x40, $"Spawn point logged: {output}");
        }

        private static string GetMapName(Map map)
        {
            if (map == Map.Felucca) return "Felucca";
            if (map == Map.Trammel) return "Trammel";
            if (map == Map.Ilshenar) return "Ilshenar";
            if (map == Map.Malas) return "Malas";
            if (map == Map.Tokuno) return "Tokuno";
            if (map == Map.TerMur) return "TerMur";
            if (map == Map.Sosaria) return "Sosaria";
            if (map == Map.Map7) return "Map7";
            if (map == Map.Map8) return "Map8";
            if (map == Map.Map9) return "Map9";
            if (map == Map.Map10) return "Map10";
            if (map == Map.Map11) return "Map11";
            if (map == Map.Map12) return "Map12";
            if (map == Map.Map13) return "Map13";
            if (map == Map.Map14) return "Map14";
            if (map == Map.Map15) return "Map15";			
            return "Internal";
        }
    }
}
