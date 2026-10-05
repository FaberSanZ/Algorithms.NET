using System;

namespace Algorithms.Search
{
    public class TernarySearch
    {
        // Define a very small epsilon value to compare double values
        private static readonly double EPS = 0.000000001;

        public TernarySearch()
        {

        }


        /// <summary>
        /// Perform a ternary search on the interval low to high.
        /// Remember that your function must be a continuous unimodal
        /// function, this means a function which decreases then increases (U shape)
        /// </summary>
        // <param name="low"></param>
        // <param name="high"></param>
        // <param name="function"></param>
        public TernarySearch(double low, double high, Func<double, double> function)
        {
            TernarySearchData = ternarySearch(low, high, function);
        }

        public double TernarySearchData { get; set; }



        /// <summary>
        /// Perform a ternary search on the interval low to high.
        /// Remember that your function must be a continuous unimodal
        /// function, this means a function which decreases then increases (U shape)
        /// </summary>
        // <param name="low"></param>
        // <param name="high"></param>
        // <param name="function"></param>
        public double Search(double low, double high, Func<double, double> function)
        {
            return ternarySearch(low, high, function);
        }

        // Perform a ternary search on the interval low to high.
        // Remember that your function must be a continuous unimodal
        // function, this means a function which decreases then increases (U shape)
        private double ternarySearch(double low, double high, Func<double, double> function)
        {
            double best = default;

            while (true)
            {
                double mid1 = (2 * low + high) / 3, mid2 = (low + 2 * high) / 3;
                double res1 = function(mid1), res2 = function(mid2);
                if (res1 > res2)
                {
                    low = mid1;
                }
                else
                {
                    high = mid2;
                }

                if (best != null && System.Math.Abs(best - mid1) < EPS)
                {
                    break;
                }

                best = mid1;
            }
            return best;
        }
    }
}
