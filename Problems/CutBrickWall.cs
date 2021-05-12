using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class CutBrickWall
    {
        public static int FindMinimumCuts(int[][] input)
        {
            var hashSet = new Dictionary<int, int>();

            foreach (var row in input)
            {
                var length = 0;
                for (int i = 0; i < row.Length - 1; i++)
                {
                    length += row[i];
                    if (hashSet.ContainsKey(length))
                        hashSet[length] += 1;
                    else
                        hashSet.Add(length, 1);
                }
            }

            return input.Length - hashSet.Values.Max();
        }
    }
}
