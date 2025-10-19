// DeliveryQuestCommands.cs
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Server;
using Server.Commands;
using Server.Items;


namespace Server.Commands
{
    public static class DeliveryQuestCommands
    {
        public static void Initialize()
        {
            // you can type [AddDQS ...] or [AddDeliveryQuest ...]
            CommandSystem.Register("AddDQS",           AccessLevel.GameMaster, new CommandEventHandler(OnAddDQS));
            CommandSystem.Register("AddDeliveryQuest", AccessLevel.GameMaster, new CommandEventHandler(OnAddDQS));
        }

        [Usage("AddDQS \"<Trait Name>\" [<Gold>] [<RewardType1> <RewardType2> ...]")]
        [Description("Spawns a DeliveryQuestScroll targeting a quoted multi-word trait, with optional gold and reward items.")]
        private static void OnAddDQS(CommandEventArgs e)
        {
            var from  = e.Mobile;
            var input = e.ArgString.Trim();

            // 1) Extract "Trait Name", optional gold, then rest
            var m = Regex.Match(input, "^\"([^\"]+)\"(?:\\s+(\\d+))?(.*)$");
            if (!m.Success)
            {
                from.SendMessage(
                  "Usage: [AddDQS \"Trait Name\" [Gold] [RewardType1 RewardType2 ...]]");
                return;
            }

            string traitName = m.Groups[1].Value;
            int gold         = 0;
            if (m.Groups[2].Success)
                Int32.TryParse(m.Groups[2].Value, out gold);

            // 2) Parse any reward item types
            var rewards = new List<Type>();
            var rest    = m.Groups[3].Value.Trim();
            if (!String.IsNullOrEmpty(rest))
            {
                foreach (var tok in rest.Split(' '))
                {
                    var t = ScriptCompiler.FindTypeByName(tok);
                    if (t == null || !typeof(Item).IsAssignableFrom(t))
                        from.SendMessage($"Invalid item type: {tok}");
                    else
                        rewards.Add(t);
                }
            }

            // 3) Instantiate the scroll
            DeliveryQuestScroll scroll;
            if (rewards.Count > 0)
                scroll = new DeliveryQuestScroll(traitName, gold, rewards.ToArray());
            else
                scroll = new DeliveryQuestScroll(traitName, gold);

            // 4) Give it to the GM
            from.AddToBackpack(scroll);
            from.SendMessage(
              $"[AddDQS] spawned a scroll for trait “{traitName}” with {gold} gold" +
              (rewards.Count > 0 ? " and custom rewards." : "."));
        }
    }
}
