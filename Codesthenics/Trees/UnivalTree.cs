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
    public class UnivalTree
    {
        public static TreeNode<int> BuildUnivalTree1()
        {
            var root = new TreeNode<int>()
            {
                Value = 5,
                LeftChild = new TreeNode<int>()
                {
                    Value = 1,
                    LeftChild = new TreeNode<int>()
                    {
                        Value = 5
                    },
                    RightChild = new TreeNode<int>()
                    {
                        Value = 5
                    },
                },
                RightChild = new TreeNode<int>()
                {
                    Value = 5,
                    RightChild = new TreeNode<int>()
                    {
                        Value = 5,
                    }
                }
            };

            return root;
        }

        public static TreeNode<int> BuildUnivalTree2()
        {
            var root = new TreeNode<int>()
            {
                Value = 5,
                LeftChild = new TreeNode<int>()
                {
                    Value = 4,
                    LeftChild = new TreeNode<int>()
                    {
                        Value = 4
                    },
                    RightChild = new TreeNode<int>()
                    {
                        Value = 4
                    },
                },
                RightChild = new TreeNode<int>()
                {
                    Value = 5,
                    RightChild = new TreeNode<int>()
                    {
                        Value = 5,
                    }
                }
            };

            return root;
        }

        public static TreeNode<string> BuildUnivalTree3()
        {
            var root = new TreeNode<string>()
            {
                Value = "a",
                LeftChild = new TreeNode<string>()
                {
                    Value = "a",
                },
                RightChild = new TreeNode<string>()
                {
                    Value = "a",
                    LeftChild = new TreeNode<string>()
                    {
                        Value = "a",
                    },
                    RightChild = new TreeNode<string>()
                    {
                        Value = "a",
                        RightChild = new TreeNode<string>()
                        {
                            Value = "a",
                            RightChild = new TreeNode<string>()
                            {
                                Value = "b",
                            }
                        }
                    }
                }
            };

            return root;
        }

        public static TreeNode<string> BuildUnivalTree4()
        {
            var root = new TreeNode<string>()
            {
                Value = "a",
                LeftChild = new TreeNode<string>()
                {
                    Value = "c",
                },
                RightChild = new TreeNode<string>()
                {
                    Value = "b",
                    LeftChild = new TreeNode<string>()
                    {
                        Value = "b",
                    },
                    RightChild = new TreeNode<string>()
                    {
                        Value = "b",
                        RightChild = new TreeNode<string>()
                        {
                            Value = "b"
                        }
                    }
                }
            };

            return root;
        }

        public static bool IsUnivalTree<T>(TreeNode<T> root, ref int count)
        {
            var lhsValue = IsUnivalTreeInternal(root.LeftChild, root.Value, ref count);
            var rhsValue = IsUnivalTreeInternal(root.RightChild, root.Value, ref count);
            return lhsValue && rhsValue;
        }

        private static bool IsUnivalTreeInternal<T>(TreeNode<T> root, T parentValue, ref int count)
        {
            var returnValue = true;
            if (root.LeftChild == null && root.RightChild == null)
            {
                count++;
                if (!root.Value.Equals(parentValue))
                    returnValue = false;
            }
            else
            {
                if (root.LeftChild == null)
                    returnValue = IsUnivalTreeInternal(root.RightChild, root.Value, ref count);
                else if (root.RightChild == null)
                    returnValue = IsUnivalTreeInternal(root.LeftChild, root.Value, ref count);
                else
                {
                    var lhsValue = IsUnivalTreeInternal(root.LeftChild, root.Value, ref count);
                    var rhsValue = IsUnivalTreeInternal(root.RightChild, root.Value, ref count);
                    returnValue = lhsValue && rhsValue;
                }

                if (returnValue == true)
                    count++;

            }
            return returnValue;
        }
    }
}
