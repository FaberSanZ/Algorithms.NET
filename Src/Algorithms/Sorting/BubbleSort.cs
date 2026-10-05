using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class BubbleSort : InplaceSort
    {
        public BubbleSort()
        {
        }

        public BubbleSort(int[] values)
        {
            bubbleSort(values);
        }

        public BubbleSort(IEnumerable<int> values)
        {
            //int[] va = new int[values.Count()];
            //for (int i = 0; i < va.Length; i++)
            //{
            //    va[i] = values.ElementAt(i);
            //}

            bubbleSort(values.ToArray());
        }


        public override void Sort(int[] values)
        {
            bubbleSort(values);
        }


        // Sort the array using bubble sort. The idea behind
        // bubble sort is to look for adjacent indexes which
        // are out of place and interchange their elements
        // until the entire array is sorted.
        internal void bubbleSort(int[] ar)
        {
            if (ar is null || ar.Length is 0)
            {
                return;
            }

            bool sorted;
            do
            {
                sorted = true;
                for (int i = 1; i < ar.Length; i++)
                {
                    if (ar[i] < ar[i - 1])
                    {
                        Swap(ar, i - 1, i);
                        sorted = false;
                    }
                }
            } while (!sorted);
        }


        internal void Swap(int[] ar, int i, int j)
        {
            int tmp = ar[i];
            ar[i] = ar[j];
            ar[j] = tmp;
        }

    }
}
