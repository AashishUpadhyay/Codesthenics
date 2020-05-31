using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class SortElevatorVersions
    {
        public string[] Sort(string[] versions)
        {
            int[][] versionsToIntArr = ConvertToIntArr(versions);
            Sort(versionsToIntArr, 0, versionsToIntArr.Length - 1, 0);
            GroupThenSort(versionsToIntArr, 0);
            GroupThenSort(versionsToIntArr, 1);
            return ConvertToStrArr(versionsToIntArr);
        }

        private string[] ConvertToStrArr(int[][] versionsToIntArr)
        {
            string[] returnValue = new string[versionsToIntArr.Length];
            for (int i = 0; i < versionsToIntArr.Length; i++)
            {
                returnValue[i] = Join(versionsToIntArr[i]);
            }
            return returnValue;
        }

        private int[][] ConvertToIntArr(string[] versions)
        {
            int[][] returnValue = new int[versions.Length][];

            for (int i = 0; i < versions.Length; i++)
            {
                int[] splittedArr = Split(versions[i]);
                returnValue[i] = splittedArr;
            }
            return returnValue;
        }

        private int[] Split(string s)
        {
            int[] returnValue = new int[3];
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach (char character in s)
            {
                if (character == 46)
                {
                    returnValue[index] = Convert.ToInt32(sb.ToString());
                    index++;
                    sb = new StringBuilder();
                }
                else
                {
                    sb.Append(character);
                }
            }
            returnValue[index] = Convert.ToInt32(sb.ToString());
            index++;
            while (index < returnValue.Length)
            {
                returnValue[index] = -1;
                index++;
            }
            return returnValue;
        }

        private string Join(int[] intArr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < intArr.Length; i++)
            {
                if (intArr[i] >= 0)
                {
                    if (i > 0)
                        sb.Append('.');
                    sb.Append(intArr[i]);
                }
            }
            return sb.ToString();
        }

        private void Sort(int[][] arr, int lb, int ub, int level)
        {
            if (ub < 0 || lb >= ub)
                return;

            int[] pivot = arr[lb];
            int m = lb + 1;
            int n = ub;
            while (m <= n)
            {
                if (arr[m][level] <= pivot[level])
                    m++;
                else if (arr[n][level] >= pivot[level])
                    n--;
                else
                {
                    int[] temp = arr[m];
                    arr[m] = arr[n];
                    arr[n] = temp;
                }
            }

            int[] temp1 = arr[n];
            if (pivot[level] > temp1[level])
            {
                arr[n] = pivot;
                arr[lb] = temp1;
            }

            Sort(arr, lb, n - 1, level);
            Sort(arr, n + 1, ub, level);
        }

        private void GroupThenSort(int[][] arr, int level)
        {
            int si = 0;
            int i = 1;
            for (; i < arr.Length; i++)
            {
                if (arr[i][level] != arr[si][level])
                {
                    if ((i - si) > 1)
                        Sort(arr, si, i - 1, level + 1);
                    si = i;
                }
            }
            if ((i - si) > 1)
                Sort(arr, si, i - 1, level + 1);
        }
    }
}
