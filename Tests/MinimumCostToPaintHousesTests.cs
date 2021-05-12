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
	public class MinimumCostToPaintHousesTests
	{
		[TestMethod]
		public void Test1()
		{
			var mctph = new MinimumCostToPaintHouses();
			var cost = mctph.CostBruteForce(new int[3][]
			{
				new int[3]{12, 16, 5},
				new int[3]{4, 18, 4},
				new int[3]{9, 14, 6},
			});
			var dpcost = mctph.CostBruteDP(new int[3][]
			{
				new int[3]{12, 16, 5},
				new int[3]{4, 18, 4},
				new int[3]{9, 14, 6},
			});
			Assert.IsTrue(cost == dpcost);
		}

		[TestMethod]
		public void Test2()
		{
			var mctph = new MinimumCostToPaintHouses();
			var cost = mctph.CostBruteForce(new int[3][]
			{
				new int[3]{17,2,17},
				new int[3]{16,16,5},
				new int[3]{14,3,19},
			});
			var dpcost = mctph.CostBruteDP(new int[3][]
			{
				new int[3]{17,2,17},
				new int[3]{16,16,5},
				new int[3]{14,3,19},
			});
			Assert.IsTrue(cost == dpcost);
		}

		[TestMethod]
		public void Test3()
		{
			var mctph = new MinimumCostToPaintHouses();
			var cost = mctph.CostBruteForce(new int[0][]);
			var dpcost = mctph.CostBruteDP(new int[0][]);
			Assert.IsTrue(cost == dpcost);
		}

		[TestMethod]
		public void Test4()
		{
			var mctph = new MinimumCostToPaintHouses();
			var cost = mctph.CostBruteForce(new int[17][] {
			new int[3]{7,8,12},
			new int[3]{18,16,1},
			new int[3]{14,7,7},
			new int[3]{16,2,20},
			new int[3]{9,13,18},
			new int[3]{14,18,17},
			new int[3]{7,10,6},
			new int[3]{8,4,11},
			new int[3]{20,5,2},
			new int[3]{9,8,4},
			new int[3]{13,1,6},
			new int[3]{2,3,10},
			new int[3]{7,4,16},
			new int[3]{7,19,17},
			new int[3]{10,6,8},
			new int[3]{14,6,13},
			new int[3]{15,7,6}
			});
			var dpcost = mctph.CostBruteDP(new int[17][] {
			new int[3]{7,8,12},
			new int[3]{18,16,1},
			new int[3]{14,7,7},
			new int[3]{16,2,20},
			new int[3]{9,13,18},
			new int[3]{14,18,17},
			new int[3]{7,10,6},
			new int[3]{8,4,11},
			new int[3]{20,5,2},
			new int[3]{9,8,4},
			new int[3]{13,1,6},
			new int[3]{2,3,10},
			new int[3]{7,4,16},
			new int[3]{7,19,17},
			new int[3]{10,6,8},
			new int[3]{14,6,13},
			new int[3]{15,7,6}
			});
			Assert.IsTrue(cost == dpcost);
		}

		[TestMethod]
		public void Test5()
		{
			var mctph = new MinimumCostToPaintHouses();
			var cost = mctph.CostBruteForce(new int[37][] {
			new int[3]{10,6,7},
			new int[3]{19,9,8},
			new int[3]{18,20,3},
			new int[3]{17,8,13},
			new int[3]{15,11,16},
			new int[3]{11,20,10},
			new int[3]{8,6,5},
			new int[3]{5,19,5},
			new int[3]{14,14,20},
			new int[3]{6,6,1},
			new int[3]{15,3,12},
			new int[3]{17,7,5},
			new int[3]{7,6,8},
			new int[3]{19,5,6},
			new int[3]{15,10,7},
			new int[3]{19,4,12},
			new int[3]{13,8,16},
			new int[3]{3,14,12},
			new int[3]{4,12,5},
			new int[3]{19,20,3},
			new int[3]{19,10,15},
			new int[3]{1,7,17},
			new int[3]{6,15,13},
			new int[3]{11,6,20},
			new int[3]{7,6,7},
			new int[3]{14,13,15},
			new int[3]{19,17,13},
			new int[3]{5,11,8},
			new int[3]{2,17,12},
			new int[3]{12,13,4},
			new int[3]{9,19,4},
			new int[3]{20,5,6},
			new int[3]{20,16,7},
			new int[3]{17,18,3},
			new int[3]{8,10,2},
			new int[3]{6,19,16},
			new int[3]{20,1,10}
			});
			Assert.IsTrue(268 == cost);
		}

		[TestMethod]
		public void Test6()
		{
			var mctph = new MinimumCostToPaintHouses();
			var dpcost = mctph.CostBruteDP(new int[37][] {
			new int[3]{10,6,7},
			new int[3]{19,9,8},
			new int[3]{18,20,3},
			new int[3]{17,8,13},
			new int[3]{15,11,16},
			new int[3]{11,20,10},
			new int[3]{8,6,5},
			new int[3]{5,19,5},
			new int[3]{14,14,20},
			new int[3]{6,6,1},
			new int[3]{15,3,12},
			new int[3]{17,7,5},
			new int[3]{7,6,8},
			new int[3]{19,5,6},
			new int[3]{15,10,7},
			new int[3]{19,4,12},
			new int[3]{13,8,16},
			new int[3]{3,14,12},
			new int[3]{4,12,5},
			new int[3]{19,20,3},
			new int[3]{19,10,15},
			new int[3]{1,7,17},
			new int[3]{6,15,13},
			new int[3]{11,6,20},
			new int[3]{7,6,7},
			new int[3]{14,13,15},
			new int[3]{19,17,13},
			new int[3]{5,11,8},
			new int[3]{2,17,12},
			new int[3]{12,13,4},
			new int[3]{9,19,4},
			new int[3]{20,5,6},
			new int[3]{20,16,7},
			new int[3]{17,18,3},
			new int[3]{8,10,2},
			new int[3]{6,19,16},
			new int[3]{20,1,10}
			});
			Assert.IsTrue(dpcost == 268);
		}
	}
}
