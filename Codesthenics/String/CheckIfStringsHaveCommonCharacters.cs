using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    class CheckIfStringsHaveCommonCharacters
    {
        public static bool Check(string input1, string input2)
        {
            var arr = new int[256];
            foreach (var character in input1)
            {
                arr[character]++;
            }

            foreach (var character in input2)
            {
                if (arr[character] > 0)
                    return true;
            }

            return false;
        }

        public static bool CheckIfInputContainsSpecialCharacters(string input)
        {
            var specialCharactersStr = "~`!@#$%^&*()_ -+={[}]|\\;:\"'<,>.?/";
            var arr = new int[256];
            foreach (var character in specialCharactersStr)
            {
                arr[character]++;
            }

            foreach (var character in input)
            {
                if (arr[character] > 0)
                    return true;
            }

            return false;
        }
    }
}
