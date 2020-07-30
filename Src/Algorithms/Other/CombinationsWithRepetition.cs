using System;

namespace Algorithms.Other
{
    public static class CombinationsWithRepetition
    {
        /**
        * Computes all combinations of elements of 'r' elements which can be repeated at most 'k' times
        * each.
        *
        * @param sequence - The sequence containing all the elements we wish to take combinations from
        * @param usedCount - Tracks how many of each element we currently have selected
        * @param at - The current position we're at in the sequence
        * @param r - The number of elements we're choosing
        * @param k - The maximum number of times each element is allowed to be picked
        */
        private static void combinationsWithRepetition(int[] sequence, int[] usedCount, int at, int r, int k)
        {

            int N = sequence.Length;

            // We reached the end
            if (at == N)
            {

                // We selected 'r' elements in total
                if (r == 0)
                {

                    // Print combination
                    Console.WriteLine("{ ");
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < usedCount[i]; j++)
                        {
                            Console.WriteLine(sequence[i] + " ");
                        }
                    }

                    Console.WriteLine("}");
                }

            }
            else
            {

                // For this particular time at position 'at' try including it each of [0, k] times
                for (int itemCount = 0; itemCount <= k; itemCount++)
                {

                    // Try including this element itemCount number of times (this is possibly more than once)
                    usedCount[at] = itemCount;

                    combinationsWithRepetition(sequence, usedCount, at + 1, r - itemCount, k);
                }
            }
        }

        // Given a sequence this method prints all the combinations of size
        // 'r' in a given sequence which has each element repeated at most 'k' times
        public static void PrintCombinationsWithRepetition(int[] sequence, int r, int k)
        {

            if (sequence == null)
            {
                return;
            }

            int n = sequence.Length;
            if (r > n)
            {
                throw new Exception("r must be <= n");
            }

            if (k > r)
            {
                throw new Exception("k must be <= r");
            }

            int[] usedCount = new int[sequence.Length];
            combinationsWithRepetition(sequence, usedCount, 0, r, k);
        }
    }
}
