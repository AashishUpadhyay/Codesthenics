using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
	[TestClass]
	public class FindLargestNumberDivisibleByThreeTests
	{
		[TestMethod]
		public void Test1()
		{
			var findLargestNumberDivisibleByThree = new FindLargestNumberDivisibleByThree();
			var returnedValue = findLargestNumberDivisibleByThree.Number(new int[] { 1, 4, 1, 3 });
			Assert.IsTrue(returnedValue == 4311);
		}

		[TestMethod]
		public void Test2()
		{
			var findLargestNumberDivisibleByThree = new FindLargestNumberDivisibleByThree();
			var returnedValue = findLargestNumberDivisibleByThree.Number(new int[] { 1, 4, 3, 3 });
			Assert.IsTrue(returnedValue == 33);
		}

		[TestMethod]
		public void Test3()
		{
			var findLargestNumberDivisibleByThree = new FindLargestNumberDivisibleByThree();
			var returnedValue = findLargestNumberDivisibleByThree.Number(new int[] { 5, 4, 5, 4, 5 });
			Assert.IsTrue(returnedValue == 5544);
		}

		[TestMethod]
		public void Test4()
		{
			var findLargestNumberDivisibleByThree = new FindLargestNumberDivisibleByThree();
			var returnedValue = findLargestNumberDivisibleByThree.Number(new int[] { 3, 1, 4, 1, 5, 9 });
			Assert.IsTrue(returnedValue == 94311);
		}

		[TestMethod]
		public void Test5()
		{
			var findLargestNumberDivisibleByThree = new FindLargestNumberDivisibleByThree();
			var returnedValue = findLargestNumberDivisibleByThree.Number(new int[] { 5, 5, 5, 5, 5 });
			Assert.IsTrue(returnedValue == 555);
		}

		[TestMethod]
		public void Test6()
		{
			var findLargestNumberDivisibleByThree = new FindLargestNumberDivisibleByThree();
			var returnedValue = findLargestNumberDivisibleByThree.Number(new int[] { 2, 3 });
			Assert.IsTrue(returnedValue == 3);
		}

		[TestMethod]
		public void Test7()
		{
			var findLargestNumberDivisibleByThree = new FindLargestNumberDivisibleByThree();
			var returnedValue = findLargestNumberDivisibleByThree.Number(new int[] { 17, 11 });
			Assert.IsTrue(returnedValue == 0);
		}
	}
}
