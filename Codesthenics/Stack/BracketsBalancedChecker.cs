/*
Good morning! Here's your coding interview problem for today.
This problem was asked by Facebook.
Given a string of round, curly, and square open and closing brackets, return whether the brackets are balanced (well-formed).
For example, given the string "([])[]({})", you should return true.
Given the string "([)]" or "((()", you should return false.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    public class BracketsBalancedChecker
    {
        static Dictionary<char, char> bracketDictionary = new Dictionary<char, char>() { { ']', '[' }, { ')', '(' }, { '}', '{' } };

        public static bool AreBracketsBalanced(string input)
        {
            var stack = new Stack();
            for (int i = 0; i < input.Length; i++)
            {
                if (!bracketDictionary.ContainsKey(input[i]) || stack.Count == 0)
                    stack.Push(input[i]);
                else if (stack.Count > 0 && Convert.ToChar(stack.Peek()) == bracketDictionary[input[i]])
                    stack.Pop();
            }

            if (stack.Count == 0)
                return true;
            return false;
        }
    }
}
