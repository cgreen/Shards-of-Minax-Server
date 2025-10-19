using System.Collections.Generic;

namespace Server.CustomPoisons
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Utility.Random(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
