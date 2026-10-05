using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Other
{
    public class Permutations
    {
        /* RECURSIVE APPROACH */

        // Generates all the permutations of a sequence of objects
        public static void GeneratePermutations(object[] sequence)
        {
            if (sequence == null) return;
            bool[] used = new bool[sequence.Length];
            int[] picked = new int[sequence.Length];
            permutations(0, used, picked, sequence);
        }

        // Recursive method to generate all the permutations of a sequence
        // at       -> Current element we're considering
        // used     -> The elements we have currently selected in our permutation
        // picked   -> The order of the indexes we have selected in our permutation
        // sequence -> The array we're generating permutations for
        private static void permutations(int at, bool[] used, int[] picked, Object[] sequence)
        {

            int N = sequence.Length;

            // We reached the end, so we've found a valid permutation!
            if (at == N)
            {

                // Print permutation
                Console.WriteLine("[ ");
                for (int i = 0; i < N; i++) Console.WriteLine(sequence[picked[i]] + " ");
                Console.WriteLine("]");

            }
            else
            {

                for (int i = 0; i < N; i++)
                {

                    // We can only select elements once, so make sure we do
                    // not select an element which has already been chosen
                    if (!used[i])
                    {

                        // Select this element and track in picked which
                        // element was chosen for this permutations
                        used[i] = true;
                        picked[at] = i;
                        permutations(at + 1, used, picked, sequence);

                        // Backtrack (unselect element)
                        used[i] = false;
                    }
                }
            }
        }

        /* ITERATIVE APPROACH */

        // Generates the next ordered permutation in-place (skips repeated permutations).
        // Calling this when the array is already at the highest permutation returns false.
        // Recommended usage is to start with the smallest permutations and use a do while
        // loop to generate each successive permutations (see main for example).
        //static <T extends Comparable<? super T>> boolean nextPermutation(T[] sequence)
        //{
        //    int first = getFirst(sequence);
        //    if (first == -1) return false;
        //    int toSwap = sequence.length - 1;
        //    while (sequence[first].compareTo(sequence[toSwap]) >= 0) --toSwap;
        //    swap(sequence, first++, toSwap);
        //    toSwap = sequence.length - 1;
        //    while (first < toSwap) swap(sequence, first++, toSwap--);
        //    return true;
        //}

        //static T int getFirst<T>(T[] sequence)
        //{
        //    for (int i = sequence.Length - 2; i >= 0; --i)
        //        if (sequence[i].(sequence[i + 1]) < 0) return i;
        //    return -1;
        //}

        //static <T extends Comparable<? super T>> void swap(T[] sequence, int i, int j)
        //{
        //    T tmp = sequence[i];
        //    sequence[i] = sequence[j];
        //    sequence[j] = tmp;
        //}
    }
}
