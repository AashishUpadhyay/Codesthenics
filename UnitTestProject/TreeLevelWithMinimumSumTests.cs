using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HitmanList;

namespace UnitTestProject
{
    [TestClass]
    public class TreeLevelWithMinimumSumTests
    {
        [TestMethod]
        public void Test1()
        {
            var root = new TreeNode<int>()
            {
                Value = 10,
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

            Assert.IsTrue((new TreeLevelWithMinimumSum()).FindLevelWithMinimumSum(root) == 1);
        }

        [TestMethod]
        public void Test2()
        {
            var root = new TreeNode<int>()
            {
                Value = 9,
                LeftChild = new TreeNode<int>()
                {
                    Value = 4,
                    LeftChild = new TreeNode<int>()
                    {
                        Value = 1
                    },
                    RightChild = new TreeNode<int>()
                    {
                        Value = 2
                    },
                },
                RightChild = new TreeNode<int>()
                {
                    Value = 5,
                    RightChild = new TreeNode<int>()
                    {
                        Value = 3,
                    }
                }
            };

            Assert.IsTrue((new TreeLevelWithMinimumSum()).FindLevelWithMinimumSum(root) == 2);
        }

        [TestMethod]
        public void Test3()
        {
            var root = new TreeNode<int>()
            {
                Value = 1,
                LeftChild = new TreeNode<int>()
                {
                    Value = 2,
                    LeftChild = new TreeNode<int>()
                    {
                        Value = 4
                    },
                    RightChild = new TreeNode<int>()
                    {
                        Value = 5
                    },
                },
                RightChild = new TreeNode<int>()
                {
                    Value = 3,
                    RightChild = new TreeNode<int>()
                    {
                        Value = 6,
                    }
                }
            };

            Assert.IsTrue((new TreeLevelWithMinimumSum()).FindLevelWithMinimumSum(root) == 0);
        }
    }
}
