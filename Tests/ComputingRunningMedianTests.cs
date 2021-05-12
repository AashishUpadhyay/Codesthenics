using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems;

namespace Tests
{
    [TestClass]
    public class ComputingRunningMedianTests
    {
        [TestMethod]
        public void ComputingRunningMedianTest1()
        {
            var input = new double[] { 2, 1, 5, 7, 2, 0, 5 };
            var returnedValue = (new ComputingRunningMedian()).CalculateRunningMedian(input);
            Assert.IsTrue(returnedValue.SequenceEqual(new double[] { 2, 1.5, 2, 3.5, 2, 2, 2 }));
        }
    }
}
