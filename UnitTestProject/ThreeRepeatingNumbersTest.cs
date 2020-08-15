using System;
using Codesthenics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
	[TestClass]
	public class ThreeRepeatingNumbersTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			var trn = new ThreeRepeatingNumbers();
			var nrn = trn.FindNonRepeatingNumber(new int[] { 1, 2, 3, 1, 5, 2, 3, 1, 2, 3 });
			Assert.AreEqual(nrn, 5);
		}
	}
}
