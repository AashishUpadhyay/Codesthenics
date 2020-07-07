using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class BrailleEncoder
    {
        public string Encode(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            var sb = new StringBuilder();
            var dict = BuildCodeDictionary();
            foreach (var character in s)
            {
                if ((character - 65) >= 0 && (character - 65) < 26)
                {
                    var capBrailleCode = GetCode(dict[26]);
                    var charBraillerCode = GetCode(dict[character - 65]);
                    sb.Append(capBrailleCode).Append(charBraillerCode);
                }
                else if (((character - 97) >= 0 && (character - 97) < 26))
                {
                    var charBraillerCode = GetCode(dict[character - 97]);
                    sb.Append(charBraillerCode);
                }
                else if (character == 32)
                {
                    var charBraillerCode = GetCode(dict[27]);
                    sb.Append(charBraillerCode);
                }
            }

            return sb.ToString();
        }

        private string GetCode(int v)
        {
            var sb = new StringBuilder();
            var hashSet = new int[7];
            var rem = v % 10;
            while (rem > 0)
            {
                hashSet[rem]++;
                v = v / 10;
                rem = v % 10;
            }

            for (int i = 1; i <= 6; i++)
            {
                if (hashSet[i] == 1)
                    sb.Append(1);
                else
                    sb.Append(0);
            }
            return sb.ToString();
        }

        private int[] BuildCodeDictionary()
        {
            return new int[]
            {
                1,
                12,
                14,
                145,
                15,
                124,
                1245,
                125,
                24,
                245,
                 13,
                 123,
                 134,
                 1345,
                 135,
                 1234,
                 12345,
                 1235,
                 234,
                 2345,
                 136,
                 1236,
                 2456,
                 1346,
                 13456,
                 1356,
                  6,
                 0
            };
        }
    }
}
