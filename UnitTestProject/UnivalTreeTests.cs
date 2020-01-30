using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class UnivalTreeTests
    {
        [TestMethod]
        public void BuildUnivalTree1()
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

            Assert.IsTrue(UnivalTreeRevision<int>.CountUnivalTrees(root) == 4);
        }

        [TestMethod]
        public void BuildUnivalTree2()
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

            Assert.IsTrue(UnivalTreeRevision<int>.CountUnivalTrees(root) == 5);
        }

        [TestMethod]
        public void BuildUnivalTree3()
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

            Assert.IsTrue(UnivalTreeRevision<string>.CountUnivalTrees(root) == 3);
        }

        [TestMethod]
        public void BuildUnivalTree4()
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

            Assert.IsTrue(UnivalTreeRevision<string>.CountUnivalTrees(root) == 5);
        }
    }
}
