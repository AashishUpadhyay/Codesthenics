using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class FenwickTreeTests
    {
        [TestMethod]
        public void CreateTest()
        {
            var ft = new FenwickTree();
            var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var returnedValue = ft.Create(input);
            CollectionAssert.AreEqual(new int[] { 1, 3, 3, 10, 5, 11, 7, 36, 9, 19 }, returnedValue);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var ft = new FenwickTree();
            var input = new int[] { 1, 3, 3, 10, 5, 11, 7, 36, 9, 19 };
            ft.Update(4, 5, input);
            CollectionAssert.Equals(new int[] { 1, 3, 4, 10, 10, 16, 7, 41, 9, 19 }, input);
        }

        [TestMethod]
        public void QueryTest()
        {
            var ft = new FenwickTree();
            var input = new int[] { 1, 3, 3, 10, 5, 11, 7, 36, 9, 19 };
            var returnedValue = ft.Query(10, input);
            Assert.AreEqual(55, returnedValue);
            returnedValue = ft.Query(9, input);
            Assert.AreEqual(45, returnedValue);
            returnedValue = ft.Query(8, input);
            Assert.AreEqual(36, returnedValue);
            returnedValue = ft.Query(4, input);
            Assert.AreEqual(10, returnedValue);
        }
    }
}
