using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class KnightProbabilityInChessboard
	{
		private double[][][] _cache;
		private int[][] _moves;
		private int _N;
		public double KnightProbability(int N, int K, int r, int c)
		{
			_cache = new double[N][][];
			for (int i = 0; i < N; i++)
			{
				_cache[i] = new double[N][];
				for (int j = 0; j < N; j++)
				{
					_cache[i][j] = new double[K+1];
				}
			}
			_N = N;
			_moves = new int[8][]{
				new int[2]{2,1},
				new int[2]{2,-1},
				new int[2]{-2,1},
				new int[2]{-2,-1},
				new int[2]{1,2},
				new int[2]{1,-2},
				new int[2]{-1,2},
				new int[2]{-1,-2}
			};
			var rv = DFS(1, r, c, K);
			return rv;
		}

		private double DFS(double prob, int sr, int sc, int k)
		{
			if (k == 0)
			{
				_cache[sr][sc][k] = prob;
				return prob;
			}

			if (_cache[sr][sc][k] > 0)
				return _cache[sr][sc][k];

			double tpb = 0;
			foreach (var move in _moves)
			{
				var nr = sr + move[0];
				var nc = sc + move[1];
				if (IsValid(nr, nc))
				{
					tpb += DFS(prob / 8, nr, nc, k - 1);
				}
			}

			_cache[sr][sc][k] = tpb;
			return tpb;
		}

		private bool IsValid(int r, int c)
		{
			if (r < 0 || c < 0 || r >= _N || c >= _N)
				return false;
			return true;
		}
	}
}
