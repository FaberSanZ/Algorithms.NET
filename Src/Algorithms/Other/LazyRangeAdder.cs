namespace Algorithms.Other
{
    public class LazyRangeAdder
    {
        // The number of elements in the input array.
        private readonly int n;

        // The original input array
        private readonly int[] _array;

        // The difference array with the deltas between values, size n+1
        private readonly int[] differenceArray;



        // Initialize an instance of a LazyRangeAdder on some input values
        public LazyRangeAdder(int[] array)
        {
            _array = array;
            n = array.Length;

            differenceArray = new int[n + 1];
            differenceArray[0] = array[0];
            for (int i = 1; i < n; i++)
            {
                differenceArray[i] = array[i] - array[i - 1];
            }
        }

        // Add `x` to the range [l, r] inclusive
        public void Add(int l, int r, int x)
        {
            differenceArray[l] += x;
            differenceArray[r + 1] -= x;
        }

        // IMPORTANT: Make certain to call this method once all the additions
        // have been made with add(l, r, x)
        public void Done()
        {
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    _array[i] = differenceArray[i];
                }
                else
                {
                    _array[i] = differenceArray[i] + _array[i - 1];
                }
            }
        }
    }
}
