using System;
using System.Linq;
using Server;
using Server.Commands;
using Server.Items;

public class MooringLineDebug
{
    public static void Initialize()
    {
        CommandSystem.Register("DumpMooringLines", AccessLevel.Administrator, DumpLines);
    }

    [Usage("DumpMooringLines")]
    [Description("Logs all MooringLine items and their map/coords.")]
    public static void DumpLines(CommandEventArgs e)
    {
        int count = 0;

        foreach (var line in World.Items.OfType<MooringLine>())
        {
            Console.WriteLine($"MooringLine #{line.Serial:X}: Map={line.Map}, Loc={line.Location}");
            count++;
        }

        e.Mobile.SendMessage($"Found {count} MooringLine item(s). Check server console.");
    }
}
