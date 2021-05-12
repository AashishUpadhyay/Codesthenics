/*
 Given a string str and no of lines k, print the string characters in Zig-Zag form in k lines for example if the string is thisisazigzag and k = 4, the output should be:

t     a     g
 h   s z   a
  i i   i z
   s     g

t     a     g
 h   s z   a
  i i   i z
   s     g
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class LettersInZigZagForm
    {
        public static string[] PrintLettersInZigZagForm(string word, int k)
        {
            var substrings = new string[k];
            int substringIndex = 0;
            bool incrementIndex = false;

            for (int i = 0; i < word.Length; i++)
            {
                AddCharactersToStringArray(substrings, word[i], substringIndex);

                if (substringIndex == 0 || substringIndex >= k-1)
                    incrementIndex = !incrementIndex;

                if (incrementIndex)
                    substringIndex++;
                else
                    substringIndex--;
            }

            return substrings;
        }

        private static void AddCharactersToStringArray(string[] substrings, char p, int substringIndex)
        {
            for (int i = 0; i < substrings.Length; i++)
            {
                if (i == substringIndex)
                    substrings[i] += p;
                else
                    substrings[i] += " ";
            }
        }
    }
}
