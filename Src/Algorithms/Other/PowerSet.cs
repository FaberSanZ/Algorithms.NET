using System;

namespace Algorithms.Other
{
    public class PowerSet
    {
        // Use the fact that numbers represented in binary can be
        // used to generate all the subsets of an array
        public static void PowerSetUsingBinary(int[] set)
        {

            int N = set.Length;
            int MAX_VAL = 1 << N;

            for (int subset = 0; subset < MAX_VAL; subset++)
            {
                Console.WriteLine("{ ");
                for (int i = 0; i < N; i++)
                {
                    int mask = 1 << i;
                    if ((subset & mask) == mask)
                    {
                        Console.WriteLine(set[i] + " ");
                    }
                }
                Console.WriteLine("}");
            }
        }

        // Recursively generate the powerset (set of all subsets) of an array by maintaining
        // a boolean array used to indicate which element have been selected
        public static void PowerSetRecursive(int at, int[] set, bool[] used)
        {

            if (at == set.Length)
            {

                // Print found subset!
                Console.WriteLine("{ ");
                for (int i = 0; i < set.Length; i++)
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

                // Include this element
                used[at] = true;
                PowerSetRecursive(at + 1, set, used);

                // Backtrack and don't include this element
                used[at] = false;
                PowerSetRecursive(at + 1, set, used);
            }
        }
    }
}
