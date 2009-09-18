using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Framework
{
    public static class ListUtils
    {
        /// <summary>
        /// Adapted from http://en.wikipedia.org/wiki/Knuth_shuffle
        /// </summary>
        /// <param name="list">List to be shuffled</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random(); // random number generator
            int n = list.Count;       // The number of items left to shuffle (loop invariant).
            while (n > 1)
            {
                n--; // n is now the last pertinent index
                int k = rng.Next(n + 1);  // 0 <= k <= n.
                T tmp = list[k];
                list[k] = list[n];
                list[n] = tmp;
            }
        }

    }
}
