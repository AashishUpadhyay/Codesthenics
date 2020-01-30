using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    /*
    Sample: [98, 20, 12, 66, 13, 22, 19] 

    Pass 1: [20, 12, 22, 13, 66, 98, 19] 
    Pass 2: [12, 13, 19, 20, 22, 66, 98]
     
    */

    class RadixSort
    {
        public static int[] Sort(int[] arr)
        {
            var max = Utility.GetMax(arr);

            for (int i = 1; (max / i) > 0; i = i * 10)
            {
                arr = CountingSort(arr, i);
            }

            return arr;
        }

        private static int[] CountingSort(int[] arr, int exp)
        {
            var returnValue = new int[arr.Length];

            var countRecord = new int[256];
            for (int i = 0; i < arr.Length; i++)
                countRecord[((arr[i] / exp) % (10))]++;

            var runningTotal = 0;
            for (int i = 0; i < 10; i++)
            {
                runningTotal += countRecord[i];
                countRecord[i] = runningTotal;
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                var index = countRecord[((arr[i] / exp) % 10)];
                countRecord[((arr[i] / exp) % 10)]--;
                returnValue[index - 1] = arr[i];
            }

            return returnValue;
        }
    }
}
