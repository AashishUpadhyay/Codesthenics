using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class CurrencyArbitrage_BellmanFord
	{
		public bool IsPossible(double[][] currencies)
		{
			var transformedGraph = new double[4][] {
				new double[4]{0,0,0,0},
				new double[4]{0,0,0,0},
				new double[4]{0,0,0,0},
				new double[4]{0,0,0,0}
			};

			var dist = new double[currencies.Length];
			for (int h = 0; h < dist.Length; h++)
				dist[h] = double.MaxValue;

			dist[0] = 0;

			for (int i = 0; i < currencies.Length; i++)
			{
				for (int j = 0; j < currencies[i].Length; j++)
				{
					transformedGraph[i][j] = -1 * Math.Log(currencies[i][j], 2);
				}
			}

			//bellman-ford
			for (int k = 0; k < currencies.Length - 1; k++)
			{
				for (int l = 0; l < currencies.Length; l++)
				{
					for (int m = 0; m < currencies.Length; m++)
					{
						if (dist[l] != double.MaxValue && (dist[m] > dist[l] + transformedGraph[l][m]))
							dist[m] = dist[l] + transformedGraph[l][m];
					}
				}
			}

			//check for -ve cycle
			for (int n = 0; n < currencies.Length; n++)
			{
				for (int o = 0; o < currencies.Length; o++)
				{
					if (dist[n] != double.MaxValue && (dist[o] > dist[n] + transformedGraph[n][o]))
						return true;
				}
			}

			return false;
		}
	}
}
