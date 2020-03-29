using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class TopologicalSortTests
    {
        [TestMethod]
        public void Test()
        {
            var topologicalSort = new TopologicalSort();
            var returnedValue = topologicalSort.Sort(new Dictionary<string, IList<string>>()
            {
                {"A", new List<string>() {"B","C" } },
                {"B", new List<string>() {"C","D" } },
                {"D", new List<string>() {"E" } },
                {"C", new List<string>() {"F","E" } },
                {"E", new List<string>() {"F" } },
                {"F", new List<string>()},
            });

            Assert.IsTrue(returnedValue[0] == "F");
            Assert.IsTrue(returnedValue[1] == "E");
            Assert.IsTrue(returnedValue[2] == "C" || returnedValue[2] == "D");
            Assert.IsTrue(returnedValue[3] == "C" || returnedValue[3] == "D");
            Assert.IsTrue(returnedValue[4] == "B");
            Assert.IsTrue(returnedValue[5] == "A");
        }

        [TestMethod]
        public void Test1()
        {
            var topologicalSort = new TopologicalSort();
            var returnedValue = topologicalSort.Sort(new Dictionary<string, IList<string>>()
            {
                {"CS003", new List<string>() { "CS002", "CS001" } },
                {"CS002", new List<string>() { "CS001"} },
                {"CS001", new List<string>() }
            });

            Assert.IsTrue(returnedValue[0] == "CS001");
            Assert.IsTrue(returnedValue[1] == "CS002");
            Assert.IsTrue(returnedValue[2] == "CS003");
        }
    }
}
