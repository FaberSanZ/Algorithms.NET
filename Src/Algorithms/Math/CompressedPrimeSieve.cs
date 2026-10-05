namespace Algorithms.Math
{
    public static class CompressedPrimeSieve
    {
        private static readonly double NUM_BITS = 128.0;
        private static readonly int NUM_BITS_SHIFT = 7; // 2^7 = 128

        // Sets the bit representing n to 1 indicating this number is not prime
        private static void SetBit(long[] arr, int n)
        {
            if ((n & 1) == 0)
            {
                return; // n is even
            }

            arr[n >> NUM_BITS_SHIFT] |= 1L << ((n - 1) >> 1);
        }

        // Returns true if the bit for n is off (meaning n is a prime).
        // Note: do use this method to access numbers outside your prime sieve range!
        private static bool IsNotSet(long[] arr, int n)
        {
            if (n < 2)
            {
                return false; // n is not prime
            }

            if (n == 2)
            {
                return true; // two is prime
            }

            if ((n & 1) == 0)
            {
                return false; // n is even
            }

            long chunk = arr[n >> NUM_BITS_SHIFT];
            long mask = 1L << ((n - 1) >> 1);
            return (chunk & mask) != mask;
        }

        // Returns true/false depending on whether n is prime.
        public static bool IsPrime(long[] sieve, int n)
        {
            return IsNotSet(sieve, n);
        }

        // Returns an array of longs with each bit indicating whether a number
        // is prime or not. Use the isNotSet and setBit methods to toggle to bits for each number.
        public static long[] PrimeSieve(int limit)
        {
            int numChunks = (int)System.Math.Ceiling(limit / NUM_BITS);
            int sqrtLimit = (int)System.Math.Sqrt(limit);
            // if (limit < 2) return 0; // uncomment for primeCount purposes
            // int primeCount = (int) Math.ceil(limit / 2.0); // Counts number of primes <= limit
            long[] chunks = new long[numChunks];
            chunks[0] = 1; // 1 as not prime
            for (int i = 3; i <= sqrtLimit; i += 2)
            {
                if (IsNotSet(chunks, i))
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        if (IsNotSet(chunks, j))
                        {
                            SetBit(chunks, j);
                            // primeCount--;
                        }
                    }
                }
            }

            return chunks;
        }
    }
}
