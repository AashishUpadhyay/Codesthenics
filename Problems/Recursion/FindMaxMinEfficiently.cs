using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class FindMaxMinEfficiently
	{
		public int[] Find(int[] arr)
		{
			return FindInternal(arr, 0, arr.Length-1);
		}

		private int[] FindInternal(int[] arr, int i, int j)
		{
			if (i == j)
				return new int[2] { arr[i], arr[j] };

			if (j - i == 1)
				return (arr[i] > arr[j]) ? new int[2] { arr[j], arr[i] } : new int[2] { arr[i], arr[j] };

			var mid = i + (j - i) / 2;

			int[] arr1 = FindInternal(arr, i, mid);
			int[] arr2 = FindInternal(arr, mid + 1, j);

			return new int[2] { Math.Min(arr1[0], arr2[0]), Math.Max(arr1[1], arr2[1]) };
		}
	}
}
