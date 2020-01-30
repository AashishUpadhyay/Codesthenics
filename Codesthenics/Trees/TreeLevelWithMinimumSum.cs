using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    public class TreeLevelWithMinimumSum
    {
        private int minSum;
        private int levelWithMinimumSum;
        private Dictionary<int, int> levelSumMap = new Dictionary<int, int>();

        public int FindLevelWithMinimumSum(TreeNode<int> input)
        {
            minSum = input.Value;
            levelWithMinimumSum = 0;    
            FindLevelWithMinimumSumInternal(input, 0);
            return levelWithMinimumSum;
        }

        private void FindLevelWithMinimumSumInternal(TreeNode<int> input, int level)
        {
            if (input.LeftChild != null)
                FindLevelWithMinimumSumInternal(input.LeftChild, level + 1);

            if (input.RightChild != null)
                FindLevelWithMinimumSumInternal(input.RightChild, level + 1);

            if (levelSumMap.ContainsKey(level))
                levelSumMap[level] += input.Value;
            else
            {
                levelSumMap.Add(level, input.Value);
            }

            if (minSum > levelSumMap[level])
            {
                minSum = levelSumMap[level];
                levelWithMinimumSum = level;
            }
        }
    }
}
