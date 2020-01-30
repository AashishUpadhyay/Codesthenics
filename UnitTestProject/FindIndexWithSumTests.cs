using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class FindIndexWithSumTests
    {
        [TestMethod]
        public void Test1()
        {
            var index = (new FindIndexWithSum()).Find(new int[] { 0, 5, 5, 1, 1, 2, 6, 8 }, 7);
            Assert.IsTrue(index == 2);
        }

        [TestMethod]
        public void Test2()
        {
            var index = (new FindIndexWithSum()).Find(new int[] { 0, 5, 4, 1, 1, 2, 6, 8 }, 7);
            Assert.IsTrue(index == -1);
        }

        [TestMethod]
        public void Test3()
        {
            var index = (new FindIndexWithSum()).Find(new int[] { 0, 5, 5, 1, 1, 2, 3, 6, 8 }, 7);
            Assert.IsTrue(index == 3);
        }

        [TestMethod]
        public void Test4()
        {
            var index = (new FindIndexWithSum()).Find(new int[] { 0, 5, 5, 1, 1, 2, 6, 8 }, 10);
            Assert.IsTrue(index == 3);
        }

        [TestMethod]
        public void Test5()
        {
            var index = (new FindIndexWithSum()).Find(new int[] { 0, 5, 5, 1, 1, 2, 6, 8 }, 8);
            Assert.IsTrue(index == 7);
        }
    }
}
