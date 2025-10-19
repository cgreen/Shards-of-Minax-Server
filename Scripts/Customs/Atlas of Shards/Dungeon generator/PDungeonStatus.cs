using System;
using Server;
using Server.Commands;

namespace Server.Engines.ProceduralDungeon
{
    public static class PDungeonCommands
    {
        public static void Initialize()
        {
            CommandSystem.Register("PDungeonStatus", AccessLevel.GameMaster, e =>
            {
                var from = e.Mobile;

                if (PDungeonController.Instance == null)
                {
                    from.SendMessage("No dungeon controller exists.");
                    return;
                }

                from.SendMessage("Dungeon Pad Status:");
                int i = 0;
                foreach (var pad in PDungeonController.Instance.Instances)
                {
                    i++;

                    if (!pad.InUse)
                    {
                        from.SendMessage($"Pad {i}: Ready");
                    }
                    else
                    {
                        var timeLeft = (pad.Started + PDungeonController.Instance.LifeTime) - DateTime.UtcNow;
                        from.SendMessage($"Pad {i}: In Use — {pad.TileCount} tiles — {timeLeft.TotalSeconds:F0}s remaining");
                    }
                }
            });
        }
    }
}
