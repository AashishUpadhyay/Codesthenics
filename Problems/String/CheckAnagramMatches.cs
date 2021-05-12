using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class CheckAnagramMatches
    {
        public static int[] PrintIndexOfAllAnagramMatches(string word, string text)
        {
            var returnValue = new List<int>();
            var wordArray = new int[256];
            var checkingArray = new int[256];

            for (int i = 0; i < word.Length; i++)
                wordArray[word[i]]++;

            wordArray.CopyTo(checkingArray, 0);
            int wordLengthCompleteIndicator = 0;
            for (int i = 0; i < text.Length; i++)
            {
                checkingArray[text[i]]--;
                wordLengthCompleteIndicator++;

                if ((wordLengthCompleteIndicator % word.Length == 0))
                {
                    if (IsPatternRemovedFromArray(checkingArray, word))
                    {
                        returnValue.Add((i - word.Length) + 1);
                    }

                    wordArray.CopyTo(checkingArray, 0);
                    wordLengthCompleteIndicator = 0;
                    checkingArray[text[i]]--;
                    wordLengthCompleteIndicator++;
                }
            }

            return returnValue.ToArray();
        }

        private static bool IsPatternRemovedFromArray(int[] checkingArray, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (checkingArray[word[i]] != 0)
                    return false;
            }

            return true;
        }
    }
}
