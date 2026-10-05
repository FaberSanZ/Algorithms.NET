using System;

namespace Algorithms.Other
{
    public static class Combinations
    {
        // This method finds all the combinations of size r in a set
        public static void CombinationsChooseR(int[] set, int r)
        {

            if (r < 0)
            {
                return;
            }

            if (set == null)
            {
                return;
            }

            bool[] used = new bool[set.Length];
            combinations(set, r, 0, used);
        }

        // To find all the combinations of size r we need to recurse until we have
        // selected r elements (aka r = 0), otherwise if r != 0 then we need to select
        // an element which is found after the position of our last selected element
        private static void combinations(int[] set, int r, int at, bool[] used)
        {

            int N = set.Length;

            // Return early if there are more elements left to select than what is available.
            int elementsLeftToPick = N - at;
            if (elementsLeftToPick < r)
            {
                return;
            }

            // We selected 'r' elements so we found a valid subset!
            if (r == 0)
            {
                Console.WriteLine("{ ");
                for (int i = 0; i < N; i++)
                {
                    if (used[i])
                    {
                        Console.WriteLine(set[i] + " ");
                    }
                }

                Console.WriteLine("}");

            }
            else
            {

                for (int i = at; i < N; i++)
                {

                    // Try including this element
                    used[i] = true;

                    combinations(set, r - 1, i + 1, used);

                    // Backtrack and try the instance where we did not include this element
                    used[i] = false;
                }
            }
        }

        // Use this method in combination with a do while loop to generate all the combinations
        // of a set choosing r elements in a iterative fashion. This method returns
        // false once the last combination has been generated.
        // NOTE: Originally the selection needs to be initialized to {0,1,2,3 ... r-1}
        public static bool nextCombination(int[] selection, int N, int r)
        {
            if (r > N)
            {
                throw new Exception("r must be <= N");
            }

            int i = r - 1;
            while (selection[i] == N - r + i)
            {
                if (--i < 0)
                {
                    return false;
                }
            }

            selection[i]++;
            for (int j = i + 1; j < r; j++)
            {
                selection[j] = selection[i] + j - i;
            }

            return true;
        }
    }
}
