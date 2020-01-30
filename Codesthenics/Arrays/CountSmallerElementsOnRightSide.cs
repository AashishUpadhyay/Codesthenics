using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    class CountSmallerElementsOnRightSide
    {
        //Test Input: [8, -1, 3, 4]
        public static void PrintCountOfSmallerElementsOnRightSide(int[] inputArr)
        {
            int[] sortedArr = new int[inputArr.Length];
            int[] countOfSmallerElementsOnRightSideArr = new int[inputArr.Length];
            int elementsProcessedCount = 0;

            for (int i = inputArr.Length - 1; i >= 0; i--)
            {
                var currentElement = inputArr[i];

                if (i == inputArr.Length - 1)
                {
                    sortedArr[0] = currentElement;
                    countOfSmallerElementsOnRightSideArr[i] = 0;
                    elementsProcessedCount += 1;
                }
                else
                {
                    bool set = false;
                    int countOfSmallerElementsOnRightSide = 0;
                    for (int j = 0; j < elementsProcessedCount; j++)
                    {
                        if (sortedArr[j] < currentElement)
                        {
                            countOfSmallerElementsOnRightSide = elementsProcessedCount - j;
                            for (int k = elementsProcessedCount; k > j; k--)
                            {
                                sortedArr[k] = sortedArr[k - 1];
                            }
                            sortedArr[j] = currentElement;
                            set = true;
                            break;
                        }
                    }
                    if (!set)
                        sortedArr[elementsProcessedCount] = currentElement;
                    elementsProcessedCount += 1;
                    countOfSmallerElementsOnRightSideArr[i] = countOfSmallerElementsOnRightSide;
                }
            }

            Utility.PrintAllElements(countOfSmallerElementsOnRightSideArr);
        }
    }
}
