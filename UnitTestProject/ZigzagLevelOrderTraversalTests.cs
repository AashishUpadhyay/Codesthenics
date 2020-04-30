using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class ZigzagLevelOrderTraversalTests
    {
        [TestMethod]
        public void Test1()
        {
            var tree = new TreeNode<int>()
            {
                Value = 50,
                LeftChild = new TreeNode<int>()
                {
                    Value = 40,
                    LeftChild = new TreeNode<int>()
                    {
                        Value = 30,
                    },
                    RightChild = new TreeNode<int>()
                    {
                        Value = 42,
                    }
                },
                RightChild = new TreeNode<int>()
                {
                    Value = 100,
                    LeftChild = new TreeNode<int>()
                    {
                        Value = 30,
                    },
                    RightChild = new TreeNode<int>()
                    {
                        Value = 142,
                    }
                }
            };

            var returnedValue = new ZigzagLevelOrderTraversal().ZigzagLevelOrder(tree);
        }
    }
}
