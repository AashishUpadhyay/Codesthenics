/*
    Given an array of strings print index of strings that form a palindrome e.g for an input ["code", "edoc", "da", "d"] output should be [{0,1}, {1,0}, {2,3}]
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class PalindromePairGenerator
    {
        private static Dictionary<string, IList<int>> _stringIndicesDictionary;

        public static string[] GeneratePalindromePairs(string[] input)
        {
            var returnValue = new List<string>();

            _stringIndicesDictionary = new Dictionary<string, IList<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                if (_stringIndicesDictionary.ContainsKey(input[i]))
                    _stringIndicesDictionary[input[i]].Add(i);
                else
                    _stringIndicesDictionary.Add(input[i], new List<int>() { i });
            }

            for (int i = 0; i < input.Length; i++)
            {
                var indices = LookForPalindromePairs(input[i]);

                if (indices.Any())
                {
                    indices.ToList().ForEach(u =>
                    {
                        if (i != u)
                            returnValue.Add("{" + i + ", " + u + "}");
                    });
                }
            }

            return returnValue.ToArray();
        }

        private static IList<int> LookForPalindromePairs(string str)
        {
            var returnValue = new List<int>();

            Action<string> doIfSubstringIsPalindrome = (substr) =>
            {
                if (_stringIndicesDictionary.ContainsKey(substr))
                {
                    var indices = _stringIndicesDictionary[substr];
                    if (indices != null)
                    {
                        returnValue.AddRange(indices);
                    }
                }
            };

            var substring = string.Empty;
            for (int i = str.Length; i > 0; i--)
            {
                substring += str[i - 1];
                if (Utility.IsPalindrome(substring))
                {
                    var key = str.Substring(0, str.Length - substring.Length);
                    doIfSubstringIsPalindrome(key);
                }
            }

            doIfSubstringIsPalindrome(substring);
            return returnValue;
        }
    }
}
