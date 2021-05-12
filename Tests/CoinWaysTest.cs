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
	public class CoinWaysTests
	{
		[TestMethod]
		public void CoinWaysTest1()
		{
			var coinWays1 = new CoinWays();
			var coinWays2 = new CoinWays();
			Assert.IsTrue(coinWays1.NumberOfWays(1, new int[] { 1,5 }) == coinWays2.NumberOfWaysBottomUp(1, new int[] { 1,5 }));
		}

		[TestMethod]
		public void CoinWaysTest2()
		{
			var coinWays1 = new CoinWays();
			var coinWays2 = new CoinWays();
			Assert.IsTrue(coinWays1.NumberOfWays(4, new int[] { 1,5 }) == coinWays2.NumberOfWaysBottomUp(4, new int[] { 1,5 }));
		}

		[TestMethod]
		public void CoinWaysTest3()
		{
			var coinWays1 = new CoinWays();
			var coinWays2 = new CoinWays();
			Assert.IsTrue(coinWays1.NumberOfWays(5, new int[] { 1,5 }) == coinWays2.NumberOfWaysBottomUp(5, new int[] { 1,5 }));
		}

		[TestMethod]
		public void CoinWaysTest4()
		{
			var coinWays1 = new CoinWays();
			var coinWays2 = new CoinWays();
			Assert.IsTrue(coinWays1.NumberOfWays(10, new int[] { 1,5 }) == coinWays2.NumberOfWaysBottomUp(10, new int[] { 1,5 }));
		}

		[TestMethod]
		public void CoinWaysTest5()
		{
			var coinWays1 = new CoinWays();
			var coinWays2 = new CoinWays();
			Assert.IsTrue(coinWays1.NumberOfWays(50, new int[] { 1,5 }) == coinWays2.NumberOfWaysBottomUp(50, new int[] { 1,5 }));
		}

		[TestMethod]
		public void CoinWaysTest6()
		{
			var coinWays1 = new CoinWays();
			var coinWays2 = new CoinWays();
			var x = coinWays1.NumberOfWays(100, new int[] { 1,5 });
			var y = coinWays2.NumberOfWaysBottomUp(100, new int[] { 1,5 });
			Assert.IsTrue(823322219501 == x);
			Assert.IsTrue(x == y);
		}
	}
}
