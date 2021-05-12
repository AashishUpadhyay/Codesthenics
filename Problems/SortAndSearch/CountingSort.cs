using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	/*Sample:   [8, 4, 7, 9, 7, 2, 2] -     [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                                            [0, 0, 2, 0, 1, 0, 0, 2, 1, 1]
                                    
                [8, 4, 7, 9, 7, 2, 2] -     [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                                            [0, 0, 2, 2, 3, 3, 3, 5, 6, 7]       

                [2, 2, 4, 7, 7, 8, 9]
     */


	public class CountingSort
	{
		public int[] Sort(int[] arr, int digit)
		{
			int divisor = 1;
			while(digit>0)
			{
				divisor *= 10;
				digit--;
			}
			List<int>[] bucket = new List<int>[10];
			for (int i = 0; i < arr.Length; i++)
			{
				var val = (arr[i] % divisor)/(divisor/10);
				if (bucket[val] == null)
					bucket[val] = new List<int>();
				bucket[val].Add(arr[i]);
			}

			var returnValue = new List<int>();
			foreach (var item in bucket)
			{
				if (item != null)
				{
					foreach (var num in item)
					{
						returnValue.Add(num);
					}
				}
			}
			return returnValue.ToArray();
		}
	}
}
