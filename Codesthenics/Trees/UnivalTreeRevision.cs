/*
This problem was asked by Google.
A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.
Given the root to a binary tree, count the number of unival subtrees.

for e.g.
Input: root of below tree
              5
             / \
            1   5
           / \   \
          5   5   5
Output: 4
There are 4 subtrees with single values.


Input: root of below tree
              5
             / \
            4   5
           / \   \
          4   4   5                
Output: 5
There are five subtrees with single values.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    public class UnivalTreeRevision<T>
    {
        public static int CountUnivalTrees(TreeNode<T> input)
        {
            int count = 0;
            IsUnivalTree(input, ref count);
            return count;
        }

        private static bool IsUnivalTree(TreeNode<T> input, ref int count)
        {
            var isLeftUnival = input.LeftChild == null || IsUnivalTree(input.LeftChild, ref count);
            var isRightUnival = input.RightChild == null || IsUnivalTree(input.RightChild, ref count);

            bool isUnival = isLeftUnival && isRightUnival && (input.LeftChild == null || input.Value.Equals(input.LeftChild.Value)) && (input.RightChild == null || input.Value.Equals(input.RightChild.Value));

            if (isUnival) count++;

            return isUnival;
        }
    }
}
