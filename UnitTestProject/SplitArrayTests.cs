using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace UnitTestProject
{
	[TestClass]
	public class SplitArrayTests
	{
		[TestMethod]
		public void Test1()
		{
			var sa = new SplitArray();
			var retVal = sa.FindLeastMaximumSumOfParts(new int[5] { 7, 2, 5, 10, 8 }, 4);
			Assert.IsTrue(retVal == 10);
		}

		[TestMethod]
		public void Test2()
		{
			var sa = new SplitArray();
			var retVal = sa.FindLeastMaximumSumOfParts(new int[5] { 7, 2, 5, 10, 8 }, 3);
			Assert.IsTrue(retVal == 14);
		}

		[TestMethod]
		public void Test3()
		{
			var sa = new SplitArray();
			var retVal = sa.FindLeastMaximumSumOfParts(new int[5] { 7, 2, 5, 10, 8 }, 2);
			Assert.IsTrue(retVal == 18);
		}

		[TestMethod]
		public void Test4()
		{
			var sa = new SplitArray();
			var retVal = sa.FindLeastMaximumSumOfParts(new int[5] { 7, 2, 5, 10, 8 }, 1);
			Assert.IsTrue(retVal == 32);
		}

		[TestMethod]
		public void Test5()
		{
			var sa = new SplitArray();
			var retVal = sa.FindLeastMaximumSumOfParts(new int[5] { 7, 2, 5, 10, 8 }, 5);
			Assert.IsTrue(retVal == 10);
		}

		[TestMethod]
		public void Test6()
		{
			var sa = new SplitArray();
			var retVal = sa.FindLeastMaximumSumOfParts(new int[5] { 7, 2, 5, 10, 8 }, 6);
			Assert.IsTrue(retVal == 0);
		}
	}
}
