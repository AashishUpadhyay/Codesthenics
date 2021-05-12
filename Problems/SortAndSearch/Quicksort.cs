using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    /*partitionIndex = -1;
     Sample:
      [98, 20, 12, 66, 13, 22, 19] {i= 0; partitionIndex = -1;}
      [98, 20, 12, 66, 13, 22, 19] {i= 1; partitionIndex = -1;}
      [98, 20, 12, 66, 13, 22, 19] {i= 2; partitionIndex = 0;} swap
      [12, 20, 98, 66, 13, 22, 19] {i= 3; partitionIndex = 0;}
      [12, 20, 98, 66, 13, 22, 19] {i= 4; partitionIndex = 1;} swap
      [12, 13, 98, 66, 20, 22, 19] {i= 5; partitionIndex = 1;}
      [12, 13, 98, 66, 20, 22, 19] {i= 6; partitionIndex = 2;} swap
      [12, 13, 19, 66, 20, 22, 98] {i= 6; partitionIndex = 2;} swap*/

    class Quicksort
    {
        //static int loopCounter = 0;
        public static int[] Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void Sort(int[] arr, int start, int end)
        {
            var returnValue = new int[arr.Length];

            var partitionIndex = GetPartitionIndex(arr, start, end);

            if (start < partitionIndex - 1)
                Sort(arr, start, partitionIndex - 1);

            if (end > partitionIndex + 1)
                Sort(arr, partitionIndex + 1, end);

            return;
        }

        private static int GetPartitionIndex(int[] arr, int start, int end)
        {
            var pivot = arr[end];

            int partitionIndex = start - 1;
            for (int i = start; i <= end; i++)
            {
                  //Console.WriteLine("CheckComplexityByUncommentingThisLine" + loopCounter++);
                if (arr[i] <= pivot)
                {
                    partitionIndex++;
                    var temp = arr[i];
                    arr[i] = arr[partitionIndex];
                    arr[partitionIndex] = temp;
                }
            }

            return partitionIndex;
        }
    }
}
