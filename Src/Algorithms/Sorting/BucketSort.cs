using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class BucketSort : InplaceSort
    {
        public BucketSort()
        {

        }

        public BucketSort(IEnumerable<int> values)
        {
            Sort(values.ToArray());
        }

        public BucketSort(int[] values)
        {
            int minValue = int.MaxValue;
            int maxValue = int.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < minValue)
                {
                    minValue = values[i];
                }

                if (values[i] > maxValue)
                {
                    maxValue = values[i];
                }
            }
            bucketSort(values, minValue, maxValue);
        }


        public override void Sort(int[] values)
        {
            int minValue = int.MaxValue;
            int maxValue = int.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < minValue)
                {
                    minValue = values[i];
                }

                if (values[i] > maxValue)
                {
                    maxValue = values[i];
                }
            }
            bucketSort(values, minValue, maxValue);
        }

        // Performs a bucket sort of an array in which all the elements are
        // bounded in the range [minValue, maxValue]. For bucket sort to give linear
        // performance the elements need to be uniformly distributed
        internal void bucketSort(int[] ar, int minValue, int maxValue)
        {
            if (ar is null || ar.Length is 0 || minValue == maxValue) 
            {
                return;
            }

            // N is number elements and M is the range of values
            int N = ar.Length, M = maxValue - minValue + 1, numBuckets = M / N + 1;
            List<List<int>> buckets = new List<List<int>>(numBuckets);
            for (int i = 0; i < numBuckets; i++)
            {
                buckets.Add(new List<int>());
            }

            // Place each element in a bucket
            for (int i = 0; i < N; i++)
            {
                int bi = (ar[i] - minValue) / M;
                List<int> bucket = buckets[bi];
                bucket.Add(ar[i]);
            }

            // Sort buckets and stitch together answer
            for (int bi = 0, j = 0; bi < numBuckets; bi++)
            {
                List<int> bucket = buckets[bi];
                if (bucket != null)
                {
                    //Array.Sort(bucket.ToArray());
                    bucket.Sort();
                    for (int k = 0; k < bucket.Count; k++)
                    {
                        ar[j++] = bucket[k];
                    }
                }
            }
        }

    }
}
