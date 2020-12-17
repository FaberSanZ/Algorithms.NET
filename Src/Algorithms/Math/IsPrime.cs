using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Math
{
    public static class IsPrime
    {
        public static bool Is_Prime(long n)
        {
            if (n < 2) 
                return false;

            if (n == 2 || n == 3) 
                return true;

            if (n % 2 == 0 || n % 3 == 0) 
                return false;

            long limit = (long)System.Math.Sqrt(n);

            for (long i = 5; i <= limit; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
