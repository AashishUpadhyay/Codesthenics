using System;
using Problems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class CountNumberOfSuccessiveOnesInBinaryRepresentationTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			var snosoibr = new CountNumberOfSuccessiveOnesInBinaryRepresentation();
			var count = snosoibr.Count(156);
			Assert.AreEqual(count, 3);
		}

		[TestMethod]
		public void TestMethod2()
		{
			var snosoibr = new CountNumberOfSuccessiveOnesInBinaryRepresentation();
			var count = snosoibr.Count(10);
			Assert.AreEqual(count, 1);
		}

		[TestMethod]
		public void TestMethod3()
		{
			var snosoibr = new CountNumberOfSuccessiveOnesInBinaryRepresentation();
			var count = snosoibr.Count(31);
			Assert.AreEqual(count, 5);
		}
	}
}
