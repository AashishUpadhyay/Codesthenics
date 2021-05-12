using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class DutchFlagProblem
	{
        public void SortColors(int[] nums)
        {
            var s = 0;
            var e = nums.Length - 1;
            var m = 0;
            while (m <= e)
            {
                if (nums[m] == 0)
                {
                    Swap(nums, s, m);
                    s++;
                    m++;
                }
                else if (nums[e] == 1)
                    m++;
                else
                {
                    Swap(nums, m, e);
                    e--;
                }
            }
        }

        public void Swap(int[] nums, int l, int r)
        {
            var temp = nums[l];
            nums[l] = nums[r];
            nums[r] = temp;
        }
    }
}
