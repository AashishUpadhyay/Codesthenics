using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class PlayNim
	{
		public bool CanWin(int[] nums)
		{
			if (nums[0] == 0 && nums[1] == 0 && nums[2] == 0)
				return true;

			for (int i = 0; i < nums.Length; i++)
			{
				for (int j = 1; j < nums[i]; j++)
				{
					var preList = nums.Take(i).ToList();
					preList.Add(nums[i] - j);
					preList.AddRange(nums.Skip(i + 1).Take(nums.Length - (i + 1)));
					if (!CanWin(preList.ToArray()))
						return true;
				}
			}

			return false;
		}
	}
}
