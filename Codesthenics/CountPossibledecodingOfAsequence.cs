/*
Count Possible Decodings of a given Digit Sequence
Let 1 represent ‘A’, 2 represents ‘B’, etc. Given a digit sequence, count the number of possible decodings of the given digit sequence.
Examples:

Input:  digits[] = "121"
Output: 3
// The possible decodings are "ABA", "AU", "LA"

Input: digits[] = "1234"
Output: 3
// The possible decodings are "ABCD", "LCD", "AWD"
An empty digit sequence is considered to have one decoding. It may be assumed that the input contains valid digits from 0 to 9 and there are no leading 0’s, no extra trailing 0’s and no two or more consecutive 0’s.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    class CountPossibledecodingOfAsequence
    {
        public static int CountDecodingRecursive(char[] digits, int n)
        {

            // base cases 
            if (n == 0 || n == 1)
                return 1;

            // Initialize count 
            int count = 0;

            // If the last digit is not 0, then  
            // last digit must add to 
            // the number of words 
            if (digits[n - 1] > '0')
                count = CountDecodingRecursive(digits, n - 1);

            // If the last two digits form a number 
            // smaller than or equal to 26, then  
            // consider last two digits and recur 
            if (digits[n - 2] == '1' ||
                        (digits[n - 2] == '2' &&
                           digits[n - 1] < '7'))
                count += CountDecodingRecursive(digits, n - 2);

            return count;
        }

        public static int CountDecodingComplexityOrderN(char[] digits)
        {
            /*The problem can be solved using fibonacci logic, if two digits together form a valid message than add start and end else continue with end */
            var lengthOfArray = digits.Count();
            int count = 1;
            int start = 1;

            if (lengthOfArray == 1)
                return count;

            for (int i = 1; i < lengthOfArray; i++)
            {
                if ((digits[i - 1] == '2' && (digits[i] > '0' && digits[i] < '7')) || (digits[i - 1] == '1'))
                {
                    var temp = count;
                    count = start + temp;
                    start = temp;
                }
            }

            return count;
        }
    }
}
