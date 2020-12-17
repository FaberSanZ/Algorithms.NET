using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Search
{
    public class TernarySearchDiscrete
    {
        // Define a very small epsilon value to compare double values.
        static readonly double EPS = 0.000000001;

        // A discrete function is just a set of data points.
        static readonly double[] function = { 16, 12, 10, 3, 6, 7, 9, 10, 11, 12, 13, 17 };

        // Define your own function on whatever you're attempting to ternary
        // search. Remember that your function must be a discrete and a unimodal
        // function, this means a function which decreases then increases (U shape)

        public TernarySearchDiscrete()
        {

        }

        public TernarySearchDiscrete(int lo, int hi)
        {
            TernarySearchDiscreteData = Search(lo, hi);
        }

        public double TernarySearchDiscreteData { get; set; }

        double f(int i)
        {
            return function[i];
        }

        public double Search(int lo, int hi)
        {
            while (lo != hi)
            {
                if (hi - lo == 1) return System.Math.Min(f(lo), f(hi));
                if (hi - lo == 2) return System.Math.Min(f(lo), System.Math.Min(f(lo + 1), f(hi)));
                int mid1 = (2 * lo + hi) / 3, mid2 = (lo + 2 * hi) / 3;
                double res1 = f(mid1), res2 = f(mid2);
                if (System.Math.Abs(res1 - res2) < 0.000000001)
                {
                    lo = mid1;
                    hi = mid2;
                }
                else if (res1 > res2) lo = mid1;
                else hi = mid2;
            }
            return lo;
        }
    }
}
