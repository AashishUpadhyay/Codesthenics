using System;
using System.Collections.Generic;
using System.Linq;
namespace Problems
{
    public class FindMedianOfTwoArrays
    {
        private int _total = -1;
        public FindMedianOfTwoArrays()
        {
        }

        private int ParY(int parX) => ((_total + 1) / 2) - (parX + 1); 

        public decimal Median(List<int> arrX, List<int> arrY)
        {
            _total = arrX.Count() + arrY.Count();
            var temp = new List<int>();

            if (arrX.Count() > arrY.Count())
            {
                arrX.ForEach(u => temp.Add(u));

                arrX = new List<int>();
                arrY.ForEach(u => arrX.Add(u));

                arrY = temp;
            }

            int parX = arrX.Count() > 0 ? ((arrX.Count() - 1) / 2) : -1;
            int parY = ParY(parX);
            return MedianInternal(parX, parY, arrX, arrY);
        }

        private decimal MedianInternal(int parX, int parY, List<int> arrX, List<int> arrY)
        {
            int x = FindItemAtIndex(parX, arrX, false);
            int y = FindItemAtIndex(parY, arrY, true);

            int x1 = FindItemAtIndex(parX + 1, arrX, true);
            int y1 = FindItemAtIndex(parY - 1, arrY, false);

            if (x<=y && y1<=x1)
            {
                if ((_total & 1) == 0)
                    return (Math.Max(x, y1) + Math.Min(y, x1)) / Convert.ToDecimal(2);
                else 
                    return Math.Max(x, y1);
            }
            else if (x < y)
            {
                int new_parX = parX + 1;
                int new_parY = ParY(new_parX);
                return MedianInternal(new_parX, new_parY, arrX, arrY);
            }
            else
            {
                int new_parX = parX - 1;
                int new_parY = ParY(new_parX);
                return MedianInternal(new_parX, new_parY, arrX, arrY);
            }
        }

        private int FindItemAtIndex(int index, List<int> arr, bool setToMax)
        {
            if (index < 0 || index > arr.Count() - 1)
                return setToMax ? Int32.MaxValue : Int32.MinValue;

            return arr[index];
        }
    }

    public class FindMedianOfTwoArraysLC
    {
        private int totalLength = 0;
        private int partitionDef = 0;
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            totalLength = nums1.Length + nums2.Length;
            partitionDef = (totalLength + 1) / 2;
            var parX = 0;
            var parY = 0;
            if (nums1.Length < nums2.Length)
            {
                parX = nums1.Length / 2;
                parY = partitionDef - parX;
                return FindMedian(parX, parY, nums1, nums2);
            }
            else
            {
                parX = nums2.Length / 2;
                parY = partitionDef - parX;
                return FindMedian(parX, parY, nums2, nums1);
            }
        }

        private double FindMedian(int parX, int parY, int[] arrX, int[] arrY)
        {
            if (CompareValues(parX - 1, parY, arrX, arrY) && CompareValues(parY - 1, parX, arrY, arrX))
            {
                if (totalLength % 2 == 0)
                {
                    var max = GetMax(parX - 1, parY - 1, arrX, arrY);
                    var min = GetMin(parX, parY, arrX, arrY);
                    return (max + min) / 2;
                }
                else
                    return GetMax(parX - 1, parY - 1, arrX, arrY);
            }
            else if (!CompareValues(parY - 1, parX, arrY, arrX))
                return FindMedian(parX + 1, (partitionDef - (parX + 1)), arrX, arrY);
            else
                return FindMedian(parX - 1, (partitionDef - (parX - 1)), arrX, arrY);
        }

        private bool CompareValues(int indexX, int indexY, int[] arrX, int[] arrY)
        {
            int X = Int32.MinValue;
            int Y = Int32.MaxValue;

            if (indexX >= 0)
                X = arrX[indexX];

            if (indexY < arrY.Length)
                Y = arrY[indexY];

            return X <= Y;
        }

        private double GetMax(int indexX, int indexY, int[] arrX, int[] arrY)
        {
            int X = Int32.MinValue;
            int Y = Int32.MinValue;

            if (indexX >= 0 && indexX < arrX.Length)
                X = arrX[indexX];

            if (indexY >= 0 && indexY < arrY.Length)
                Y = arrY[indexY];

            return Math.Max(X, Y);
        }

        private double GetMin(int indexX, int indexY, int[] arrX, int[] arrY)
        {
            int X = Int32.MaxValue;
            int Y = Int32.MaxValue;

            if (indexX >= 0 && indexX < arrX.Length)
                X = arrX[indexX];

            if (indexY >= 0 && indexY < arrY.Length)
                Y = arrY[indexY];

            return Math.Min(X, Y);
        }
    }
}
