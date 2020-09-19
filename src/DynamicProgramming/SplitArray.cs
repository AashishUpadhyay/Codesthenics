using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class SplitArray
	{
		private List<int> maxSumList = new List<int>();
		private int[] _arr;

		public int FindLeastMaximumSumOfParts(int[] arr, int parts)
		{
			_arr = arr;
			if (FindLeastMaximumSumOfParts(0, parts, 0))
				return maxSumList.Min();
			return 0;
		}

		private bool FindLeastMaximumSumOfParts(int index, int parts, int maxSum)
		{
			if (index == _arr.Length)
				return false;

			if (parts == 1)
			{
				int part1Sum = FindArraySum(index);
				maxSumList.Add(Math.Max(part1Sum, maxSum));
				return true;
			}

			bool returnVal = false;
			int sum = 0;
			for (int i = index; i < _arr.Length; i++)
			{
				sum += _arr[i];
				if (FindLeastMaximumSumOfParts(i + 1, parts - 1, Math.Max(sum, maxSum)))
					returnVal = true;
			}
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
