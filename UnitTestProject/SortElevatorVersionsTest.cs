using System;
using Codesthenics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class SortElevatorVersionsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sev = new SortElevatorVersions();
            var returnedValue = sev.Sort(new string[] { "1.11", "2.0", "2", "1.2.0", "1.0", "1.2.3", "0.1" });
            Assert.AreEqual(returnedValue[0], "0.1");
            Assert.AreEqual(returnedValue[3], "1.2.3");
            Assert.AreEqual(returnedValue[returnedValue.Length - 1], "2.0");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sev = new SortElevatorVersions();
            var returnedValue = sev.Sort(new string[] { "2.0.1", "1.11", "2.0.1", "2", "1.2.0", "1.0", "2.0.0", "1.2.3", "0.1", "1.9.3", "0.0.0" });
            Assert.AreEqual(returnedValue[0], "0.0.0");
            Assert.AreEqual(returnedValue[1], "0.1");
            Assert.AreEqual(returnedValue[4], "1.2.3");
            Assert.AreEqual(returnedValue[returnedValue.Length - 3], "2.0.0");
            Assert.AreEqual(returnedValue[returnedValue.Length - 2], "2.0.1");
            Assert.AreEqual(returnedValue[returnedValue.Length - 1], "2.0.1");
        }

        [TestMethod]
        public void TestMethod3()
        {
            var sev = new SortElevatorVersions();
            var returnedValue = sev.Sort(new string[] { "1.11", "2.0.0", "1.2", "2", "0.1", "1.2.1", "1.1.1", "2.0" });
            Assert.AreEqual(returnedValue[0], "0.1");
            Assert.AreEqual(returnedValue[3], "1.2.1");
            Assert.AreEqual(returnedValue[returnedValue.Length - 1], "2.0.0");
        }

        [TestMethod]
        public void TestMethod4()
        {
            var sev = new SortElevatorVersions();
            var returnedValue = sev.Sort(new string[] { "1.1.2", "1.0", "1.3.3", "1.0.12", "1.0.2" });
            Assert.AreEqual(returnedValue[0], "1.0");
            Assert.AreEqual(returnedValue[1], "1.0.2");
            Assert.AreEqual(returnedValue[2], "1.0.12");
            Assert.AreEqual(returnedValue[3], "1.1.2");
            Assert.AreEqual(returnedValue[4], "1.3.3");
        }

        [TestMethod]
        public void TestMethod5()
        {
            var sev = new SortElevatorVersions();
            var returnedValue = sev.Sort(new string[] { "1.1.2", "1.0", "1.3.3", "1.0.12", "1.0.2" });
            Assert.AreEqual(returnedValue[0], "1.0");
            Assert.AreEqual(returnedValue[1], "1.0.2");
            Assert.AreEqual(returnedValue[2], "1.0.12");
            Assert.AreEqual(returnedValue[3], "1.1.2");
            Assert.AreEqual(returnedValue[4], "1.3.3");
        }
    }
}
