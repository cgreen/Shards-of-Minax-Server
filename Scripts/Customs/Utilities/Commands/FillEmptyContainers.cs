using System;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Custom;

namespace Server.Custom.Commands
{
    public class FillEmptyContainersCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("FillEmptyContainers", AccessLevel.Administrator, new CommandEventHandler(FillContainers_OnCommand));
        }

        [Usage("FillEmptyContainers")]
        [Description("Fills all empty containers in the world with random loot using SpecialLootHelper.")]
        private static void FillContainers_OnCommand(CommandEventArgs e)
        {
            int filledCount = 0;

            List<Item> allItems = new List<Item>(World.Items.Values);

            foreach (Item item in allItems)
            {
                if (item is Container container && container.Items.Count == 0)
                {
                    FillContainer(container);
                    filledCount++;
                }
            }

            e.Mobile.SendMessage($"Filled {filledCount} empty container{(filledCount == 1 ? "" : "s")} with loot.");
        }

        private static void FillContainer(Container container)
        {
            int itemCount = Utility.RandomMinMax(3, 12);
            HashSet<int> usedIndexes = new HashSet<int>();

            for (int i = 0; i < itemCount && usedIndexes.Count < SpecialLootHelper.LootTableCount; i++)
            {
                int index;
                do
                {
                    index = Utility.Random(SpecialLootHelper.LootTableCount);
                }
                while (!usedIndexes.Add(index));

                Item lootItem = SpecialLootHelper.GetLootByIndex(index);

                if (lootItem != null)
                    container.DropItem(lootItem);
            }
        }
    }
}
