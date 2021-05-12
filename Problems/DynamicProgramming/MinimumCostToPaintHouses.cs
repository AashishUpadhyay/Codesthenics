using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class MinimumCostToPaintHouses
	{
		private int minCost = Int32.MaxValue;
		private int[][] costColorArr;
		public int CostBruteForce(int[][] arr)
		{
			costColorArr = arr;
			CostBruteForcePrivate(0, -1, 0);
			return minCost;
		}

		private void CostBruteForcePrivate(int ri, int lci, int costSoFar)
		{
			if (costSoFar > minCost)
				return;

			if (ri == costColorArr.Length)
			{
				if (costSoFar < minCost)
					minCost = costSoFar;
				return;
			}

			for (int i = 0; i < costColorArr[0].Length; i++)
			{
				if (lci == i)
					continue;

				CostBruteForcePrivate(ri + 1, i, costSoFar + costColorArr[ri][i]);
			}
		}

		private int[][] _dp;
		private int dpMinCost = Int32.MaxValue;
		public int CostBruteDP(int[][] arr)
		{
			if (arr.Length == 0)
				return 0;

			costColorArr = arr;
			_dp = new int[arr.Length][];
			for (int i = 0; i < arr.Length; i++)
				_dp[i] = new int[arr[0].Length];

			for (int i = 0; i < arr[0].Length; i++)
			{
				int cost = CostBruteDPPrivate(0, i);
				if (cost < dpMinCost)
					dpMinCost = cost;
			}

			return dpMinCost == Int32.MaxValue ? 0 : dpMinCost;
		}

		private int CostBruteDPPrivate(int ri, int ci)
		{
			if (ri > costColorArr.Length - 1)
				return 0;

			if (_dp[ri][ci] != 0)
				return _dp[ri][ci];

			int cost = Int32.MaxValue;
			for (int i = 0; i < costColorArr[0].Length; i++)
			{
				if (i == ci)
					continue;

				int bottomUpCost = CostBruteDPPrivate(ri + 1, i);
				if (bottomUpCost < cost)
					cost = bottomUpCost;
			}
			_dp[ri][ci] = cost + costColorArr[ri][ci];
			return _dp[ri][ci];
		}
	}
}
