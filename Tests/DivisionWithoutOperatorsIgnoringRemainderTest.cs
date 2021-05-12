using System;
using Problems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class DivisionWithoutOperatorsIgnoringRemainderTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			var dwr = new DivisionWithoutOperatorsIgnoringRemainder();
			var q = dwr.Quotient(31, 3);
			Assert.AreEqual(q, 10);
		}

		[TestMethod]
		public void TestMethod2()
		{
			var dwr = new DivisionWithoutOperatorsIgnoringRemainder();
			var q = dwr.Quotient(31, 4);
			Assert.AreEqual(q, 7);
		}

		[TestMethod]
		public void TestMethod3()
		{
			var dwr = new DivisionWithoutOperatorsIgnoringRemainder();
			var q = dwr.Quotient(48, 4);
			Assert.AreEqual(q, 12);
		}
	}
}
