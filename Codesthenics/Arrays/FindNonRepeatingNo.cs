/*
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class FindNonRepeatingNo
    {
        static int INT_SIZE = 32;

        public static int GetNonRepeatingNo(int[] input, int repeatingNos)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                    dict.Add(input[i], (repeatingNos * input[i]) - input[i]);
                else
                    dict[input[i]] = dict[input[i]] - input[i];

                if (dict[input[i]] == 0)
                    dict.Remove(input[i]);

            }
            return dict.Keys.FirstOrDefault();
        }

        // Method to find the element  
        // that occur only once 
        public static int GetSingle(int[] arr)
        {
            int n = arr.Length;
            int result = 0;
            int x, sum;

            // Iterate through every bit 
            for (int i = 0; i < INT_SIZE; i++)
            {
                // Find sum of set bits at ith  
                // position in all array elements 
                sum = 0;
                x = (1 << i);
                for (int j = 0; j < n; j++)
                {
                    if ((arr[j] & x) != 0)
                        sum++;
                }

                // The bits with sum not multiple 
                // of 3, are the bits of element  
                // with single occurrence. 
                if (!((sum % 3) == 0))
                    result |= x;
            }
            return result;
        }
    }
}
