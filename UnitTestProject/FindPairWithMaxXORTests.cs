using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class FindPairWithMaxXORTests
    {
        [TestMethod]
        public void FindPairWithMaxXORTest()
        {
            var findPairWithMaxXOR = new FindPairWithMaxXOR();
            var returnValue = findPairWithMaxXOR.Find(new[] { 7, 4, 8, 15 });
            Assert.IsTrue(returnValue.Any(u => u == 7) && returnValue.Any(u => u == 8));
        }

        [TestMethod]
        public void FindPairWithMaxXORTest1()
        {
            var findPairWithMaxXOR = new FindPairWithMaxXOR();
            var returnValue = findPairWithMaxXOR.Find(new[] { 7, 4, 8, 15, 16 });
            Assert.IsTrue(returnValue.Any(u => u == 15) && returnValue.Any(u => u == 16));
        }

        [TestMethod]
        public void FindPairWithMaxXORTest2()
        {
            var findPairWithMaxXOR = new FindPairWithMaxXOR();
            var returnValue = findPairWithMaxXOR.Find(new[] { 1024, 34, 890, 11, 1232, 1023 });
            Assert.IsTrue(returnValue.Any(u => u == 1024) && returnValue.Any(u => u == 1023));
        }
    }
}
