using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class MaxesAndNums
	{
		public List<int> Find(List<int> nums, List<int> maxes)
		{
			var result = new List<int>();

			var numsSorted = nums.OrderBy(u => u).ToList();

			foreach (var max in maxes)
			{
				int bi = 0;
				int ei = numsSorted.Count() - 1;
				int mid = -1;

				while (bi <= ei)
				{
					mid = bi + (ei - bi) / 2;

					if (numsSorted[mid] > max)
					{
						ei = mid - 1;
					}
					else if (numsSorted[mid] < max)
					{
						bi = mid + 1;
					}
					else
						break;
				}

				int i = mid;
				if (numsSorted[i] > max)
				{
					while (i > 0 && numsSorted[i] > max)
					{
						--i;
					}

					result.Add(i + 1);
				}
				else
				{
					while (i < numsSorted.Count() && numsSorted[i] <= max)
					{
						++i;
					}
					result.Add(i);
				}

			}

			return result;
		}
	}
}
