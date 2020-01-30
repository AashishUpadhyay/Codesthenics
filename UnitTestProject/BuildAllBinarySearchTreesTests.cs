using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class BuildAllBinarySearchTreesTests
    {
        [TestMethod]
        public void Test1()
        {
            var received = (new BuildAllBinarySearchTrees().Build(new[] { 1,2,3 }));
            foreach (var treeNode in received)
            {
                Assert.IsTrue(Utility.IsBinarySearchTree(treeNode));
            }
            Assert.IsTrue(received.Count == 5);
        }

        [TestMethod]
        public void Test2()
        {
            var received = (new BuildAllBinarySearchTrees().Build(new[] { 1, 2, 3, 4 }));
            foreach (var treeNode in received)
            {
                Assert.IsTrue(Utility.IsBinarySearchTree(treeNode));
            }
            Assert.IsTrue(received.Count == 14);
        }

        [TestMethod]
        public void Test3()
        {
            var received = (new BuildAllBinarySearchTrees().Build(new[] { 1, 2, 3, 4, 5 }));
            foreach (var treeNode in received)
            {
                Assert.IsTrue(Utility.IsBinarySearchTree(treeNode));
            }
            Assert.IsTrue(received.Count == 42);
        }
    }
}
