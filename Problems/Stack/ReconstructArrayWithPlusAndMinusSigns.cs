using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class ReconstructArrayWithPlusAndMinusSigns
    {
        public static void Do(string[] input)
        {
            var length = input.Length;
            var stack = new Stack<int>();
            var resultSet = new List<int>();
            int i;

            for (i = 0; i < length - 1; i++)
            {
                if (input[i + 1] == "-")
                    stack.Push(i);
                else
                {
                    resultSet.Add(i);
                    while (stack.Count > 0)
                    {
                        resultSet.Add(stack.Pop());
                    }
                }
            }

            resultSet.Add(i);

            while (stack.Count > 0)
            {
                resultSet.Add(stack.Pop());
            }

            Console.WriteLine("Resultset: ");
            for (int j = 0; j < resultSet.Count; j++)
            {
                Console.WriteLine(resultSet[j]);
            }
        }

        public static void Test1()
        {
            //expected [0, 4, 3, 2, 1]
            Do(new string[] { "None", "+", "-", "-", "-" });
            Console.WriteLine("Test 1 Complete");
        }

        public static void Test2()
        {
            //expected [0, 1, 3, 2, 4]
            Do(new string[] { "None", "+", "+", "-", "+" });
            Console.WriteLine("Test 2 Complete");
        }

        public static void Test3()
        {
            //expected [0, 1, 2, 4, 3]
            Do(new string[] { "None", "+", "+", "+", "-" });
            Console.WriteLine("Test 3 Complete");
        }
    }
}
