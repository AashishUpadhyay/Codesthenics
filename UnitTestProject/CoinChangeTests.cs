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
	public class CoinChangeTests
	{
		[TestMethod]
		public void Test1()
		{
			var cc = new CoinChange();
			var count = cc.BottomUp(new int[3] { 1, 2, 5 }, 11);
			Assert.IsTrue(count == 3);
		}

		[TestMethod]
		public void Test2()
		{
			var cc = new CoinChange();
			var count = cc.BottomUp(new int[2] { 2, 5 }, 11);
			Assert.IsTrue(count == 4);
		}

		[TestMethod]
		public void Test3()
		{
			var cc = new CoinChange();
			var count = cc.BruteForce(new int[3] { 1, 2, 5 }, 11);
			Assert.IsTrue(count == 3);
		}

		[TestMethod]
		public void Test4()
		{
			var cc = new CoinChange();
			var count = cc.BruteForce(new int[2] { 2, 5 }, 11);
			Assert.IsTrue(count == 4);
		}

		[TestMethod]
		public void Test5()
		{
			var cc = new CoinChange();
			var count = cc.BruteForce(new int[3] { 1, 2, 5 }, 5);
			Assert.IsTrue(count == 1);
		}

		[TestMethod]
		public void Test6()
		{
			var cc = new CoinChange();
			var count = cc.BruteForce(new int[1] { 2 }, 3);
			Assert.IsTrue(count == -1);
		}

		[TestMethod]
		public void Test7()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[3] { 1, 2, 5 }, 11);
			Assert.IsTrue(count == 3);
		}

		[TestMethod]
		public void Test8()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[2] { 2, 5 }, 11);
			Assert.IsTrue(count == 4);
		}

		[TestMethod]
		public void Test9()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[3] { 1, 2, 5 }, 5);
			Assert.IsTrue(count == 1);
		}

		[TestMethod]
		public void Test10()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[1] { 2 }, 3);
			Assert.IsTrue(count == -1);
		}

		[TestMethod]
		public void Test11()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[1] { 1 }, 3);
			Assert.IsTrue(count == 3);
		}


		[TestMethod]
		public void Test12()
		{
			var cc = new CoinChange();
			var count = cc.BruteForce(new int[1] { 1 }, 3);
			Assert.IsTrue(count == 3);
		}

		[TestMethod]
		public void Test13()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[1] { 2 }, 5);
			Assert.IsTrue(count == -1);
		}

		[TestMethod]
		public void Test14()
		{
			var cc = new CoinChange();
			var count = cc.BruteForce(new int[1] { 2 }, 3);
			Assert.IsTrue(count == -1);
		}

		[TestMethod]
		public void Test15()
		{
			var cc = new CoinChange();
			var count = cc.BruteForce(new int[2] { 2, 3 }, 2);
			Assert.IsTrue(count == 1);
		}

		[TestMethod]
		public void Test16()
		{
			var cc = new CoinChange();
			var count = cc.BruteForce(new int[2] { 3, 2 }, 2);
			Assert.IsTrue(count == 1);
		}

		[TestMethod]
		public void Test17()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[1] { 2 }, 3);
			Assert.IsTrue(count == -1);
		}

		[TestMethod]
		public void Test18()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[2] { 2, 3 }, 2);
			Assert.IsTrue(count == 1);
		}

		[TestMethod]
		public void Test19()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[2] { 3, 2 }, 2);
			Assert.IsTrue(count == 1);
		}

		[TestMethod]
		public void Test20()
		{
			var cc = new CoinChange();
			var count = cc.TopDown(new int[4] { 186, 419, 83, 408 }, 6249);
			Assert.IsTrue(count == 20);
		}

		[TestMethod]
		public void Test21()
		{
			var cc = new CoinChange();
			var count = cc.TopDownLC(new int[4] { 186, 419, 83, 408 }, 6249);
			Assert.IsTrue(count == 20);
		}

		[TestMethod]
		public void Test22()
		{
			var cc = new CoinChange();
			var count = cc.BruteForce(new int[4] { 186, 419, 83, 408 }, 6249);
			Assert.IsTrue(count == 20);
		}
	}
}
