using System;
using Server;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Custom;
using System.Collections.Generic;

namespace Server.Custom.Commands
{
    public class FillEmptyBookshelvesCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("FillEmptyBookshelves", AccessLevel.Administrator, new CommandEventHandler(FillBookshelves_OnCommand));
        }

        [Usage("FillEmptyBookshelves")]
        [Description("Searches for all EmptyBookcase items in the world and fills them with SpecialLootHelper loot.")]
		private static void FillBookshelves_OnCommand(CommandEventArgs e)
		{
			int filledCount = 0;

			// Copy to avoid collection modification during iteration
			List<Item> allItems = new List<Item>(World.Items.Values);

			foreach (Item item in allItems)
			{
				if (item is EmptyBookcase bookcase && bookcase.Items.Count == 0)
				{
					FillBookcase(bookcase);
					filledCount++;
				}
			}

			e.Mobile.SendMessage($"Filled {filledCount} empty bookshelf{(filledCount == 1 ? "" : "s")} with loot.");
		}


        private static void FillBookcase(Container bookcase)
        {
            int itemCount = Utility.RandomMinMax(5, 15);
            HashSet<int> usedIndexes = new HashSet<int>();

            for (int i = 0; i < itemCount && usedIndexes.Count < 10; i++)
            {
                int index;
                do
                {
                    index = Utility.Random(SpecialLootHelper.LootTableCount);
                }
                while (!usedIndexes.Add(index));

                Item lootItem = SpecialLootHelper.GetLootByIndex(index);

                if (lootItem != null)
                    bookcase.DropItem(lootItem);
            }
        }
    }
}
