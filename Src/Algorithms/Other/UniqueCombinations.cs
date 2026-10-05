using System;
using System.Collections.Generic;

namespace Algorithms.Other
{
    public class UniqueCombinations
    {
        public static void Combinations(int[] set, int r)
        {

            if (set == null)
            {
                return;
            }

            if (r < 0)
            {
                return;
            }

            // Sort the numbers so we can easily skip duplicates.
            Array.Sort(set);

            bool[] used = new bool[set.Length];
            combinations(0, r, used, set);
        }

        private static void combinations(int at, int r, bool[] used, int[] set)
        {

            int n = set.Length;

            // We select 'r' elements so we found a valid subset!
            if (r == 0)
            {

                List<int> subset = new List<int>(r);
                for (int i = 0; i < n; i++)
                {
                    if (used[i])
                    {
                        subset.Add(set[i]);
                    }
                }

                Console.WriteLine(subset);

            }
            else
            {
                for (int i = at; i < n; i++)
                {

                    // Since the elements are sorted we can skip duplicate
                    // elements to ensure the uniqueness of our output.
                    if (i > at && set[i - 1] == set[i])
                    {
                        continue;
                    }

                    used[i] = true;
                    combinations(i + 1, r - 1, used, set);
                    used[i] = false;
                }
            }
        }
    }
}
