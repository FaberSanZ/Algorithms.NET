using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Algorithms.Utils.DataStructures
{
    public static class TestUtils
    {
        /// <summary>
        /// TODO:
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        // Generates a list of random values where every number is between
        // [min, max) and there are possible repeats.
        public static List<int> randomIntegerList(int sz, int min, int max)
        {
            List<int> lst = new List<int>(sz);
            for (int i = 0; i < sz; i++)
            {
                lst.Add(RandInt(min, max));
            }

            return lst;
        }

        // Generates a list of shuffled values where every number in the array
        // is in the range of [0, sz)
        public static List<int> RandomUniformUniqueIntegerList(int sz)
        {
            List<int> lst = new List<int>(sz);
            for (int i = 0; i < sz; i++)
            {
                lst.Add(i);
            }
            lst.Shuffle();
            return lst;
        }

        public static List<int> RandomUniformUniqueIntegerList(int min, int max)
        {
            List<int> lst = new List<int>(max - min); ;
            for (int i = min; i < max; i++)
            {
                lst.Add(i);
            }
            lst.Shuffle();
            return lst;
        }

        // Generates a random int between [min, max)
        public static int RandInt(int min, int max)
        {
            return min + (new Random().Next(max - min));
        }

        // Generates a random long between [min, max)
        public static long randLong(long min, long max)
        {
            return min + new Random().Next((int)(max - min));
        }

        // Generates sorted data in the range of [min,max[
        public static List<int> SortedIntegerList(int min, int max)
        {
            List<int> lst = new List<int>(max - min);

            for (int i = min; i < max; i++)
            {
                lst.Add(i);
            }

            return lst;
        }
    }
}
