namespace Algorithms.Sorting
{
    // A shared abstract amongst sorting algorithms which
    public abstract class InplaceSort
    {
        public abstract void Sort(int[] values);

    }
    public class BubbleSort : InplaceSort
    {
        public BubbleSort()
        {
        }

        public BubbleSort(int[] values)
        {
            bubbleSort(values);
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
            if (ar is null || ar.Length <= 0)
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
