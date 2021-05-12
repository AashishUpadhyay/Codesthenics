using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;

namespace Tests
{
    [TestClass]
    public class BuildTreeUsingPreOrderAndInOrderTraversalTests
    {
        [TestMethod]
        public void TestTreeEqual()
        {
            var expected = new TreeNode<string>()
            {
                Value = "a",
                LeftChild = new TreeNode<string>()
                {
                    Value = "b",
                    LeftChild = new TreeNode<string>()
                    {
                        Value = "d"
                    },
                    RightChild = new TreeNode<string>()
                    {
                        Value = "e"
                    },
                },
                RightChild = new TreeNode<string>()
                {
                    Value = "c",
                    LeftChild = new TreeNode<string>()
                    {
                        Value = "f"
                    },
                    RightChild = new TreeNode<string>()
                    {
                        Value = "g",
                    }
                }
            };

            var inorder = new[] { "a", "b", "d", "e", "c", "f", "g" };
            var preorder = new[] { "d", "b", "e", "a", "f", "c", "g" };

            var received = BuildTreeUsingPreOrderAndInOrderTraversalsRevision.BuildTree(preorder, inorder);

            bool areTreeEqual = Utility.CompareTrees(expected, received);
            Assert.IsTrue(areTreeEqual);
        }

        [TestMethod]
        public void TestTreeNotEqual()
        {
            var expected = new TreeNode<string>()
            {
                Value = "a",
                LeftChild = new TreeNode<string>()
                {
                    Value = "b",
                    LeftChild = new TreeNode<string>()
                    {
                        Value = "d"
                    },
                    RightChild = new TreeNode<string>()
                    {
                        Value = "e"
                    },
                },
                RightChild = new TreeNode<string>()
                {
                    Value = "f",
                    LeftChild = new TreeNode<string>()
                    {
                        Value = "g"
                    }
                }
            };

            var inorder = new[] { "a", "b", "d", "e", "c", "f", "g" };
            var preorder = new[] { "d", "b", "e", "a", "f", "c", "g" };

            var received = BuildTreeUsingPreOrderAndInOrderTraversalsRevision.BuildTree(preorder, inorder);

            bool areTreeEqual = Utility.CompareTrees(expected, received);
            Assert.IsFalse(areTreeEqual);
        }
    }
}
