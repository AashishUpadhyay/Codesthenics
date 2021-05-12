using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	/*
    Sample: [98, 20, 12, 66, 13, 22, 19] 

    Pass 1: [20, 12, 22, 13, 66, 98, 19] 
    Pass 2: [12, 13, 19, 20, 22, 66, 98]
     
    */

	public class RadixSort
	{
		public int[] Sort(int[] arr)
		{
			var cs = new CountingSort();
			var max = Utility.GetMax(arr);
			var digitCount = 0;
			while (max > 0)
			{
				digitCount++;
				max = max / 10;
			}

			for (int i = 1; i <= digitCount; i++)
			{
				arr = cs.Sort(arr, i);
			}

			return arr;
		}
	}
}
