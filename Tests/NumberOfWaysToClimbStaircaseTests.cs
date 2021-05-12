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
	public class NumberOfWaysToClimbStaircaseTests
	{
		[TestMethod]
		public void Test1()
		{
			var nwtcs = new NumberOfWaysToClimbStaircase();
			Assert.IsTrue(nwtcs.CountUsingBruteForce(1, new int[2] { 1, 2 }) == 1);
			Assert.IsTrue(nwtcs.CountUsingBruteForce(2, new int[2] { 1, 2 }) == 2);
			Assert.IsTrue(nwtcs.CountUsingBruteForce(3, new int[2] { 1, 2 }) == 3);
			Assert.IsTrue(nwtcs.CountUsingBruteForce(4, new int[2] { 1, 2 }) == 5);
			Assert.IsTrue(nwtcs.CountUsingBruteForce(5, new int[2] { 1, 2 }) == 8);
		}

		[TestMethod]
		public void Test2()
		{
			var nwtcs = new NumberOfWaysToClimbStaircase();
			Assert.IsTrue(nwtcs.CountUsingBruteForce(1, new int[3] { 1, 3, 5 }) == 1);
			Assert.IsTrue(nwtcs.CountUsingBruteForce(2, new int[3] { 1, 3, 5 }) == 1);
			Assert.IsTrue(nwtcs.CountUsingBruteForce(3, new int[3] { 1, 3, 5 }) == 2);
			Assert.IsTrue(nwtcs.CountUsingBruteForce(4, new int[3] { 1, 3, 5 }) == 3);
			Assert.IsTrue(nwtcs.CountUsingBruteForce(5, new int[3] { 1, 3, 5 }) == 5);
		}

		[TestMethod]
		public void Test3()
		{
			var nwtcs = new NumberOfWaysToClimbStaircase();
			Assert.IsTrue(nwtcs.CountUsingDP(1, new int[2] { 1, 2 }) == 1);
			Assert.IsTrue(nwtcs.CountUsingDP(2, new int[2] { 1, 2 }) == 2);
			Assert.IsTrue(nwtcs.CountUsingDP(3, new int[2] { 1, 2 }) == 3);
			Assert.IsTrue(nwtcs.CountUsingDP(4, new int[2] { 1, 2 }) == 5);
			Assert.IsTrue(nwtcs.CountUsingDP(5, new int[2] { 1, 2 }) == 8);
		}

		[TestMethod]
		public void Test4()
		{
			var nwtcs = new NumberOfWaysToClimbStaircase();
			Assert.IsTrue(nwtcs.CountUsingDP(1, new int[3] { 1, 3, 5 }) == 1);
			Assert.IsTrue(nwtcs.CountUsingDP(2, new int[3] { 1, 3, 5 }) == 1);
			Assert.IsTrue(nwtcs.CountUsingDP(3, new int[3] { 1, 3, 5 }) == 2);
			Assert.IsTrue(nwtcs.CountUsingDP(4, new int[3] { 1, 3, 5 }) == 3);
			Assert.IsTrue(nwtcs.CountUsingDP(5, new int[3] { 1, 3, 5 }) == 5);
		}

		[TestMethod]
		public void Test5()
		{
			var nwtcs = new NumberOfWaysToClimbStaircase();
			int retVal = nwtcs.CountUsingDP(40, new int[2] { 1, 2 });
			Assert.IsTrue(retVal == 165580141);
		}

		[TestMethod]
		public void Test6()
		{
			var nwtcs = new NumberOfWaysToClimbStaircase();
			int retVal = nwtcs.CountUsingBruteForce(40, new int[2] { 1, 2 });
			Assert.IsTrue(retVal == 165580141);
		}
	}
}
