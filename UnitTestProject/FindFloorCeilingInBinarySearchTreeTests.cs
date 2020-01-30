using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HitmanList;

namespace UnitTestProject
{
    [TestClass]
    public class FindFloorCeilingInBinarySearchTreeTests
    {
        [TestMethod]
        public void FindFloorCeilingInBinarySearchTreeTest1()
        {
            /*
                      7
                     / \
                    /   \
                   /     \
                  5       10
                 / \      /\
                /   \    /  \
               -1    6  9    10
                 \             \
                  4             15
                               /
                              11
             */
            var root = (new BinarySearchTree().Build(new[] { 7, 5, 10, -1, 6, 10, 9, 15, 4, 11 }));

            var returnValue = (new FindFloorCeilingInBinarySearchTree()).Find(root, 8);

            Assert.IsTrue(9 == returnValue.Ceiling);
            Assert.IsTrue(7 == returnValue.Floor);
        }
    }
}
