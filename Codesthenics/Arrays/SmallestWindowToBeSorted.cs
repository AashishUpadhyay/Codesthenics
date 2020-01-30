using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    class SmallestWindowToBeSorted
    {
        public static void PrintSmallestWindowToBeSorted(int[] inputArr)
        {
            int lowerBound = 0;
            int upperBound = 0;
            if (inputArr.Length == 0 || inputArr.Length == 1)
                throw new ArgumentException("Illegal Argments!");
            int max_seen = 0;
            int min_seen = int.MaxValue;
            for (int i = 0; i < inputArr.Length; i++)
            {
                max_seen = GetMax(max_seen, inputArr[i]);
                if (inputArr[i] < max_seen)
                    upperBound = i;
            }

            for (int i = inputArr.Length - 1; i >= 0; i--)
            {
                min_seen = GetMin(min_seen, inputArr[i]);
                if (min_seen < inputArr[i])
                    lowerBound = i;
            }

            Console.WriteLine("Smallest Windows : { " + lowerBound + ", " + upperBound + " }");
        }

        private static int GetMin(int min_seen, int v)
        {
            if (min_seen < v)
                return min_seen;
            else
                return v;
        }

        private static int GetMax(int max_seen, int v)
        {
            if (max_seen > v)
                return max_seen;
            else
                return v;
        }

        public static void PrintSmallestWindowToBeSortedRevision(int[] inputArr)
        {
            int minIndex = 0;
            int maxIndex = 0;

            int minNonSortedFromBeginning = int.MaxValue;
            int indexOfMinNonSortedFromBeginning = -1;

            for (int i = 0; i < inputArr.Length - 1; i++)
            {
                if (inputArr[i] > inputArr[i + 1] && inputArr[i + 1] < minNonSortedFromBeginning)
                {
                    indexOfMinNonSortedFromBeginning = i + 1;
                    minNonSortedFromBeginning = inputArr[i + 1];
                }
            }

            int maxNonSortedFromEnd = int.MinValue;
            int indexOfMaxNonSortedFromEnd = -1;

            for (int i = inputArr.Length - 1; i > 0; i--)
            {
                if (inputArr[i - 1] > inputArr[i] && inputArr[i - 1] > maxNonSortedFromEnd)
                {
                    maxNonSortedFromEnd = inputArr[i - 1];
                    indexOfMaxNonSortedFromEnd = i - 1;
                }
            }

            for (int i = indexOfMinNonSortedFromBeginning - 1; i >= 0; i--)
            {
                if (inputArr[i] < minNonSortedFromBeginning)
                {
                    break;
                }
                minIndex = i;
            }

            for (int i = indexOfMaxNonSortedFromEnd + 1; i < inputArr.Length; i++)
            {
                if (inputArr[i] > maxNonSortedFromEnd)
                {
                    break;
                }
                maxIndex = i;
            }

            Console.WriteLine("SmallestWindowToBeSorted {" + minIndex + ", " + maxIndex + "}");
        }
    }
}
