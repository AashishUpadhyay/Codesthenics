using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
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
	}
}
