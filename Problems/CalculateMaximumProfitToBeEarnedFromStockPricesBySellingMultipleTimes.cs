/*
This problem was asked by Facebook.
Given a array of numbers representing the stock prices of a company in chronological order, write a function that calculates the maximum profit you could have made from buying and selling that stock. You must buy before you can sell it.
For example, given [9, 11, 8, 5, 7, 10], you should return 5, since you could buy the stock at 5 dollars and sell it at 10 dollars.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class CalculateMaximumProfitToBeEarnedFromStockPricesBySellingMultipleTimes
    {
        //[ 1, 2, 7, 6, 5, 11, 8, 7, 12]
        public static int MaximumDifference(int[] arr)
        {
            var returnValue = 0;
            int greatestNo = 0;
            int smallestNo = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                    smallestNo = greatestNo = arr[i];

                if (arr[i] > greatestNo)
                {
                    greatestNo = arr[i];
                }

                if (arr[i] < greatestNo)
                {
                    returnValue += (greatestNo - smallestNo);
                    smallestNo = greatestNo = arr[i];
                }
            }

            returnValue += (greatestNo - smallestNo);
            return returnValue;
        }


        //[ 1, 2, 7, 6, 5, -2, 3, 4, 5]
        //[ 1, 2, 7, 6, 5, -2, 3, 12, 5]
        public static int MaximumDifferenceRevision(int[] arr)
        {
            var returnValue = 0;
            int minValue = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
                else if ((arr[i] - minValue) > returnValue)
                {
                    returnValue = arr[i] - minValue;
                }
            }
            return returnValue;
        }

    }
}
