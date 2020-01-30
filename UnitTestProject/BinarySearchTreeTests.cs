using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HitmanList;

namespace UnitTestProject
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void Test1()
        {
            var expected = new TreeNode<int>()
            {
                Value = 12,
                LeftChild = new TreeNode<int>()
                {
                    Value = 3,
                    LeftChild = new TreeNode<int>()
                    {
                        Value = 1
                    },
                    RightChild = new TreeNode<int>()
                    {
                        Value = 6,
                        RightChild = new TreeNode<int>()
                        {
                            Value = 7
                        }
                    },
                },
                RightChild = new TreeNode<int>()
                {
                    Value = 45,
                    RightChild = new TreeNode<int>()
                    {
                        Value = 91,
                    }
                }
            };

            var received = (new BinarySearchTree().Build(new[] { 12, 3, 45, 6, 7, 91, 1 }));
            Assert.IsTrue(Utility.CompareTrees<int>(expected, received));
        }
    }
}
