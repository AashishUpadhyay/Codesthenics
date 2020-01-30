/*
This problem was asked by Airbnb.
Given a list of integers, write a function that returns the largest sum of non-adjacent numbers. Numbers can be 0 or negative.
For example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5. [5, 1, 1, 5] should return 10, since we pick 5 and 5.
Follow-up: Can you do this in O(N) time and constant space?
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
   public class LargestSumOfNonAdjacentNumbers
    {
        public static void Start()
        {
            var arr = new int[] { 5, 5, 10, 100, 10, 5 };
            var maxSum = FindMaxSum(arr, arr.Length);

            var largestSum = GetLargestSum(arr, 0, 0);
            var sumFromOneAfterStart = GetLargestSum(arr, 1, 0);

            if (sumFromOneAfterStart > largestSum)
                largestSum = sumFromOneAfterStart;
            Console.WriteLine("Largest Sum:" + largestSum);
        }

        private static int GetLargestSum(int[] arr, int start, int hop)
        {
            var returnValue = 0;

            if (arr.Length - 1 < start)
                return 0;
            if ((arr.Length - 1) < (start + hop))
                return arr[start];

            var nPlus2Sum = arr[start] + GetLargestSum(arr, start + 2, 2);
            var nPlus3Sum = arr[start] + GetLargestSum(arr, start + 3, 3);

            if (nPlus2Sum > nPlus3Sum)
                returnValue = nPlus2Sum;
            else
                returnValue = nPlus3Sum;

            return returnValue;
        }

        static int FindMaxSum(int[] arr, int n)
        {
            int incl = arr[0];
            int excl = 0;
            int excl_new;
            int i;

            for (i = 1; i < n; i++)
            {
                /* current max excluding i */
                excl_new = (incl > excl) ?
                                incl : excl;

                /* current max including i */
                incl = excl + arr[i];
                excl = excl_new;
            }

            /* return max of incl and excl */
            return ((incl > excl) ?
                                incl : excl);
        }
    }
}
