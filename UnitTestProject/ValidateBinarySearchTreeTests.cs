using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class ValidateBinarySearchTreeTests
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
                        LeftChild = new TreeNode<int>()
                        {
                            Value = 10
                        }
                    },
                    RightChild = new TreeNode<int>()
                    {
                        Value = 42,
                        RightChild = new TreeNode<int>()
                        {
                            Value = 45,
                            RightChild = new TreeNode<int>()
                            {
                                Value = 60
                            }
                        }
                    }
                }
            };

            Assert.IsTrue((new ValidateBinarySearchTree()).IsValidBSTCompact(tree) == true);
        }
    }
}
