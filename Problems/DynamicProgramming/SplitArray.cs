using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class SplitArray
	{
		private int[] _arr;
		private int[][] _dp;

		public int FindLeastMaximumSumOfParts(int[] arr, int parts)
		{
			_dp = new int[arr.Length][];
			for (int i = 0; i < _dp.Length; i++)
				_dp[i] = new int[parts + 1];
			_arr = arr;
			int returnVal = FindLeastMaximumSumOfParts(0, parts);
			return returnVal == Int32.MaxValue ? 0 : returnVal;
		}

		private int FindLeastMaximumSumOfParts(int index, int parts)
		{
			if (index == _arr.Length)
				return 0;

			if (parts == 1)
				return FindArraySum(index);

			if (_dp[index][parts] != 0)
				return _dp[index][parts];

			int returnVal = Int32.MaxValue;
			int sum = 0;
			for (int i = index; i < _arr.Length; i++)
			{
				sum += _arr[i];
				int sumReturned = FindLeastMaximumSumOfParts(i + 1, parts - 1);
				if (sumReturned > 0)
					returnVal = Math.Min(returnVal, Math.Max(sum, sumReturned));
			}
			_dp[index][parts] = returnVal;
			return returnVal;
		}

		private int FindArraySum(int index)
		{
			int returnValue = 0;
			for (int i = index; i < _arr.Length; i++)
				returnValue += _arr[i];
			return returnValue;
		}
	}
}
