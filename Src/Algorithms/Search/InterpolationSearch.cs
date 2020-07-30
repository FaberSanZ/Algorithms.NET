using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Search
{
    public class InterpolationSearch
    {

        /// <summary>
        /// A fast alternative to a binary search when the elements are uniformly distributed. This
        /// algorithm runs in a time complexity of ~O(log(log(n))).
        /// </summary>
        /// <param name="nums">an ordered list containing uniformly distributed values.</param>
        /// <param name="val">the value we're looking for in 'nums'</param>
        public InterpolationSearch(int[] nums, int val)
        {
            InterpolationSearchData = interpolationSearch(nums, val);
        }

        public int InterpolationSearchData { get; set; }


        private int interpolationSearch(int[] nums, int val)
        {
            int lo = 0, mid = 0, hi = nums.Length - 1;
            while (nums[lo] <= val && nums[hi] >= val)
            {
                mid = lo + ((val - nums[lo]) * (hi - lo)) / (nums[hi] - nums[lo]);
                if (nums[mid] < val)
                {
                    lo = mid + 1;
                }
                else if (nums[mid] > val)
                {
                    hi = mid - 1;
                }
                else return mid;
            }
            if (nums[lo] == val) return lo;
            return -1;
        }

    }
}
