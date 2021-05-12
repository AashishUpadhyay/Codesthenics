using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class FindTwoNonOverlappingSubArraysEachWithTargetSum
	{
		public int MinSumOfLengths(int[] arr, int target)
		{
            int[] minLengths = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                minLengths[i] = int.MaxValue;
            }

            int sum = 0;
            int start = 0;
            int result = int.MaxValue;
            int currentMinLength = int.MaxValue;

            for (int end = 0; end < arr.Length; end++)
            {
                sum += arr[end];

                while (sum > target)
                {
                    sum -= arr[start];
                    start++;
                }

                if (sum == target)
                {
                    int currentLength = end - start + 1;

                    if (start > 0 && minLengths[start - 1] != int.MaxValue)
                    {
                        result = Math.Min(result, minLengths[start - 1] + currentLength);
                    }

                    currentMinLength = Math.Min(currentMinLength, currentLength);
                }

                minLengths[end] = currentMinLength;
            }

            return result == int.MaxValue ? -1 : result;
        }
	}
}
