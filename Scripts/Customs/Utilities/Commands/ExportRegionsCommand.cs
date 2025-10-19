// File: ExportRegionsCommand.cs
// Location: Scripts/Commands (or wherever you keep your custom commands)
// Usage in-game: [ExportRegions
// Output file: /Data/RegionNames.txt

using System;
using System.IO;
using Server;
using Server.Commands;
using Server.Regions;

namespace Server.Scripts.Commands
{
    public class ExportRegionsCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("ExportRegions", AccessLevel.GameMaster, new CommandEventHandler(ExportRegions_OnCommand));
        }

        [Usage("ExportRegions")]
        [Description("Exports the names of all regions to Data/RegionNames.txt")]
        private static void ExportRegions_OnCommand(CommandEventArgs e)
        {
            var filePath = Path.Combine(Core.BaseDirectory, "Data", "RegionNames.txt");

            try
            {
                using (var writer = new StreamWriter(filePath, false))
                {
                    foreach (var reg in Region.Regions)
                    {
                        writer.WriteLine(reg.Name);
                    }
                }

                e.Mobile.SendMessage($"Region list exported successfully to Data/RegionNames.txt ({Region.Regions.Count} regions).");
            }
            catch (Exception ex)
            {
                e.Mobile.SendMessage("Error exporting regions: " + ex.Message);
            }
        }
    }
}
