using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Other
{
    public class SquareRootDecomposition
    {
        internal long[] arr, blocks;
        internal int blockSize, nBlocks;

        // Creates an empty range [0,n]
        public SquareRootDecomposition(int size)
        {

            blockSize = (int)Math.Sqrt(size);
            nBlocks = (size / blockSize) + 1;
            blocks = new long[nBlocks];
            arr = new long[size];
        }

        public SquareRootDecomposition(int[] values) : this(values.Length)
        {

            for (int i = 0; i < values.Length; i++) Set(i, values[i]);
        }

        public int BlockID(int index)
        {
            return index / blockSize;
        }

        // Sets [index, index] = val
        public void Set(int index, int val)
        {
            blocks[BlockID(index)] -= arr[index];
            blocks[BlockID(index)] += val;
            arr[index] = val;
        }

        // Get sum query from [lo, hi] in O(sqrt(n))
        public long Query(int lo, int hi)
        {

            long sum = 0;
            int loId = BlockID(lo);
            int hiId = BlockID(hi);
            for (int i = loId + 1; i < hiId; i++) sum += blocks[i];

            if (loId == hiId)
            {
                for (int i = lo; i <= hi; i++) sum += arr[i];
                return sum;
            }

            int loMax = (((lo / blockSize) + 1) * blockSize) - 1;
            int hiMin = (hi / blockSize) * blockSize;
            for (int i = lo; i <= loMax; i++) sum += arr[i];
            for (int i = hiMin; i <= hi; i++) sum += arr[i];

            return sum;
        }
    }
}
