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
	public class BinarySearchTests
	{
		[TestMethod]
		public void Test1()
		{
			var bs = new BinarySearch();
			var result = bs.Find(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1);
			Assert.IsTrue(result == 0);
		}

		[TestMethod]
		public void Test2()
		{
			var bs = new BinarySearch();
			var result = bs.Find(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10);
			Assert.IsTrue(result == 9);
		}

		[TestMethod]
		public void Test3()
		{
			var bs = new BinarySearch();
			var result = bs.Find(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 7);
			Assert.IsTrue(result == 6);
		}

		[TestMethod]
		public void Test4()
		{
			var bs = new BinarySearch();
			var result = bs.Find(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 7, 7, 10 }, 7);
			Assert.IsTrue(result == 6 || result == 7 || result == 8);
		}

		[TestMethod]
		public void Test5()
		{
			var bs = new BinarySearch();
			var result = bs.FindLeftMost(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 7, 7, 10 }, 1);
			Assert.IsTrue(result == 0);
		}

		[TestMethod]
		public void Test6()
		{
			var bs = new BinarySearch();
			var result = bs.FindRightMost(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 7, 7, 10 }, 10);
			Assert.IsTrue(result == 9);
		}

		[TestMethod]
		public void Test7()
		{
			var bs = new BinarySearch();
			var result = bs.FindLeftMost(new List<int>() { 1, 2, 6, 6, 6, 6, 7, 7, 7, 10 }, 6);
			Assert.IsTrue(result == 2);

			result = bs.FindLeftMost(new List<int>() { 1, 2, 6, 6, 6, 6, 7, 7, 7, 10 }, 7);
			Assert.IsTrue(result == 6);
		}

		[TestMethod]
		public void Test8()
		{
			var bs = new BinarySearch();
			var result = bs.FindRightMost(new List<int>() { 1, 2, 6, 6, 6, 6, 7, 7, 7, 10 }, 6);
			Assert.IsTrue(result == 5);

			result = bs.FindRightMost(new List<int>() { 1, 2, 6, 6, 6, 6, 7, 7, 7, 10 }, 7);
			Assert.IsTrue(result == 8);
		}
	}
}
