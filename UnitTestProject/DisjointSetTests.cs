using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace UnitTestProject
{
    [TestClass]
    public class DisjointSetTests
    {
        [TestMethod]
        public void Test1()
        {
            var disjointSet = new DisjointSet<int>();
            var input = new Dictionary<int, IList<int>>();
            input.Add(1, new List<int>() { 2, 3 });
            input.Add(2, new List<int>() { 3 });
            input.Add(3, new List<int>() { 4 });
            input.Add(4, new List<int>() { 3 });
            input.Add(5, new List<int>());
            input.Add(6, new List<int>() { 7 });
            input.Add(7, new List<int>() { 8, 9 });
            input.Add(8, new List<int>() { 7 });
            input.Add(9, new List<int>() { 7 });
            var returnedValue = disjointSet.Group(input);
            var returnedValueSorted = returnedValue.OrderBy(u => u.Count).ToList();
            Assert.IsTrue(returnedValueSorted.Count == 3);
            Assert.IsTrue(returnedValueSorted[0].Count == 1);
            Assert.IsTrue(returnedValueSorted[1].Count == 4);
            Assert.IsTrue(returnedValueSorted[2].Count == 4);
        }
    }
}
