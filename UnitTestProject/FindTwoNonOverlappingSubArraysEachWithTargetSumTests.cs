using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codesthenics;

namespace UnitTestProject
{
	[TestClass]
	public class FindTwoNonOverlappingSubArraysEachWithTargetSumTests
	{
		[TestMethod]
		public void Test4()
		{
			var ftno = new FindTwoNonOverlappingSubArraysEachWithTargetSum();

			var retVal = ftno.MinSumOfLengths(new int[] { 3,2,2,4,3 }, 3);
			Assert.IsTrue(retVal == 2);
		}

		[TestMethod]
		public void Test1()
		{
			var ftno = new FindTwoNonOverlappingSubArraysEachWithTargetSum();

			var retVal = ftno.MinSumOfLengths(new int[] { 1, 2, 2, 3, 2, 6, 7, 2, 1, 4, 8 }, 5);
			Assert.IsTrue(retVal == 4);
		}

		[TestMethod]
		public void Test2()
		{
			var ftno = new FindTwoNonOverlappingSubArraysEachWithTargetSum();

			var retVal = ftno.MinSumOfLengths(new int[] { 1, 6, 1 }, 7);
			Assert.IsTrue(retVal == -1);
		}

		[TestMethod]
		public void Test3()
		{
			var ftno = new FindTwoNonOverlappingSubArraysEachWithTargetSum();

			var retVal = ftno.MinSumOfLengths(new int[] { 1, 1, 1, 2, 2, 2, 4, 4 }, 6);
			Assert.IsTrue(retVal == 6);
		}

		[TestMethod]
		public void Test5()
		{
			var ftno = new FindTwoNonOverlappingSubArraysEachWithTargetSum();

			var retVal = ftno.MinSumOfLengths(new int[] { 2, 2, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 20);
			Assert.IsTrue(retVal == 23);
		}
	}
}

