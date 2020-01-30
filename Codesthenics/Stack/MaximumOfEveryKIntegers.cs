using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    public class MaximumOfEveryKIntegers
    {
        public static void Do(int[] input, int k)
        {
            int resetStackTracker = k;
            var stack = new Stack<int>(3);
            for (int i = 0; i < input.Length; i++)
            {
                var currentMax = stack.Count > 0 ? stack.Pop() : 0;

                if ((input[i] > currentMax))
                {
                    currentMax = input[i];
                    resetStackTracker = k;
                }

                if (i >= k - 1)
                    Console.WriteLine(currentMax);

                stack.Push(resetStackTracker == 1 ? input[i] : currentMax);
                resetStackTracker -= 1;
            }
        }

        public static void Test1()
        {
            Do(new int[] { 10, 5, 7, 8, 7, 8, 7 }, 4);
            Console.WriteLine("Test 1 Complete");
        }

        public static void Test2()
        {
            Do(new int[] { 3, 6, 9, 8, 15, 2, 4, 11, 16, 8, 9 }, 4);
            Console.WriteLine("Test 2 Complete");
        }

        public static void Test3()
        {
            Do(new int[] { 3, 6, 9, 8, 15, 2, 4, 11, 16, 8, 9 }, 5);
            Console.WriteLine("Test 3 Complete");
        }
    }
}
