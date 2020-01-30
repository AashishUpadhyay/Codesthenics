using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    class MaximuSumOfConsecutiveNumbers
    {
        //Test Input: [100, 30, -50, 40, 30, 10, 10, 20, -90, 10, 10]
        public static int MaxSubArraySumHardWay(int[] inputArr, int beginIndex = 0)
        {
            var returnValue = 0;
            var intermediateMaximumSum = 0;

            for (int i = beginIndex; i < inputArr.Length; i++)
            {
                intermediateMaximumSum += inputArr[i];

                if (intermediateMaximumSum < 0)
                {
                    intermediateMaximumSum = 0;
                }
                else if (intermediateMaximumSum < returnValue)
                {
                    var subArrayMaxSum = MaxSubArraySumHardWay(inputArr, i + 1);

                    if ((subArrayMaxSum + inputArr[i]) > 0)
                        returnValue = intermediateMaximumSum + subArrayMaxSum;
                    break;
                }
                returnValue = intermediateMaximumSum;
            }

            return returnValue;
        }

        public static int MaxSubArraySum(int[] a)
        {
            int size = a.Length;
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + a[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }

        public static int MaxSubArraySumCircularArray(int[] a)
        {
            int size = a.Length;
            int min_so_far = int.MaxValue,
                min_ending_here = 0;
            int total = 0;

            for (int i = 0; i < size; i++)
            {
                min_ending_here = min_ending_here + a[i];

                if (min_so_far > min_ending_here)
                    min_so_far = min_ending_here;

                if (min_ending_here > 0)
                    min_ending_here = 0;

                total = total + a[i];
            }

            return total - (min_so_far);
        }
    }
}
