using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class BinarySearch
	{
		public int Find(List<int> nums, int target)
		{
			var numsSorted = nums.OrderBy(u => u).ToList();

			int bi = 0;
			int ei = numsSorted.Count() - 1;
			int mid = -1;

			while (bi <= ei)
			{
				mid = bi + (ei - bi) / 2;

				if (numsSorted[mid] > target)
				{
					ei = mid - 1;
				}
				else if (numsSorted[mid] < target)
				{
					bi = mid + 1;
				}
				else
					return mid;
			}

			return -1;
		}

		public int FindLeftMost(List<int> nums, int target)
		{
			var numsSorted = nums.OrderBy(u => u).ToList();

			int bi = 0;
			int ei = numsSorted.Count() - 1;
			int mid = -1;
			int result = -1;

			while (bi <= ei)
			{
				mid = bi + (ei - bi) / 2;

				if (numsSorted[mid] > target)
				{
					ei = mid - 1;
				}
				else if (numsSorted[mid] < target)
				{
					bi = mid + 1;
				}
				else
				{
					result = mid;
					break;
				}
			}

			int ti = result;
			if (numsSorted[ti] == target)
			{
				while (ti >= 0 && numsSorted[ti] == target)
				{
					--ti;
				}
			}

			return ti+1;
		}

		public int FindRightMost(List<int> nums, int target)
		{
			var numsSorted = nums.OrderBy(u => u).ToList();

			int bi = 0;
			int ei = numsSorted.Count() - 1;
			int mid = -1;
			int result = -1;

			while (bi <= ei)
			{
				mid = bi + (ei - bi) / 2;

				if (numsSorted[mid] > target)
				{
					ei = mid - 1;
				}
				else if (numsSorted[mid] < target)
				{
					bi = mid + 1;
				}
				else
				{
					result = mid;
					break;
				}
			}

			int ti = result;
			if (numsSorted[ti] == target)
			{
				while (ti < numsSorted.Count() && numsSorted[ti] == target)
				{
					++ti;
				}
			}

			return ti-1;
		}
	}
}
