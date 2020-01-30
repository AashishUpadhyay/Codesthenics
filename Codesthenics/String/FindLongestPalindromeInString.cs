/*
    Find longest palindrome in string
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    class LongestPalindromeInStringFinder
    {
        public static string LongestString(string input)
        {
            input = input.ToLowerInvariant();
            var returnValue = string.Empty;
            SortedDictionary<int, IList<string>> sortedStrings = new SortedDictionary<int, IList<string>>();
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 2])
                {
                    var palindrome = GetPalindrome(i, i + 2, input);

                    if (sortedStrings.ContainsKey(palindrome.Length))
                        sortedStrings[palindrome.Length].Add(palindrome);
                    else
                        sortedStrings.Add(palindrome.Length, new List<string>() { palindrome });
                }
            }

            if(sortedStrings.Any())
                returnValue = sortedStrings[sortedStrings.Keys.Max()].FirstOrDefault();

            return returnValue;
        }

        private static string GetPalindrome(int leftPointer, int rightPointer, string input)
        {
            while (input[leftPointer] == input[rightPointer])
            {
                --leftPointer;
                ++rightPointer;
            }
            return input.Substring((leftPointer + 1), ((rightPointer - 1) - (leftPointer + 1) + 1));
        }
    }
}
