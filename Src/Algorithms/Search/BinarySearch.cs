using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Search
{
    public class BinarySearch
    {
        // Comparing double values directly is bad practice.
        // Using a small epsilon value is the preferred approach
        private static readonly double EPS = 0.00000001;

        public double BinarySearchData { get; set; }


        public BinarySearch(double lo, double hi, double target, Func<double, double> function)
        {
            BinarySearchData = binarySearch(lo, hi, target, function);
        }



        internal double binarySearch( double lo, double hi, double target, Func<double , double> function)
        {

            if (hi <= lo) throw new Exception("hi should be greater than lo");

            double mid;
            do
            {

                // Find the middle point
                mid = (hi + lo) / 2.0;

                // Compute the value of our function for the middle point
                // Note that f can be any function not just the square root function
                double value = function(mid);

                if (value > target)
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }

            } while ((hi - lo) > EPS);

            return mid;
        }
    }
}
