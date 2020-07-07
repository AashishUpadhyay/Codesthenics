using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    /*Sample:   [8, 4, 7, 9, 7, 2, 2] -     [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                                            [0, 0, 2, 0, 1, 0, 0, 2, 1, 1]
                                    
                [8, 4, 7, 9, 7, 2, 2] -     [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                                            [0, 0, 2, 2, 3, 3, 3, 5, 6, 7]       

                [2, 2, 4, 7, 7, 8, 9]
     */


    class CountingSort
    {
        public static int[] Sort(int[] arr)
        {
            var max = GetMax(arr);
            var min = GetMin(arr);

            var returnValue = new int[arr.Length];

            var countRecord = new int[256];
            for (int i = 0; i < arr.Length; i++)
                countRecord[arr[i]]++;

            var runningTotal = 0;
            for (int i = min; i <= max; i++)
            {
                runningTotal += countRecord[i];
                countRecord[i] = runningTotal;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                var index = countRecord[arr[i]];
                countRecord[arr[i]]--;
                returnValue[index - 1] = arr[i];
            }

            return returnValue;
        }

        private static int GetMax(int[] arr)
        {
            var returnVale = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (returnVale < arr[i])
                {
                    returnVale = arr[i];
                }
            }

            return returnVale;
        }

        private static int GetMin(int[] arr)
        {
            var returnVale = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (returnVale > arr[i])
                {
                    returnVale = arr[i];
                }
            }

            return returnVale;
        }
    }
}
