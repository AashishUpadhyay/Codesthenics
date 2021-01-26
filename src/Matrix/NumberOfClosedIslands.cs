using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class NumberOfClosedIslands
	{
		private int _rl = 0;
		private int _cl = 0;
		private int[][] _grid;
		private bool isClosed = true;
		public int ClosedIslands(int[][] grid)
		{
			_grid = grid;
			_rl = _grid.Length;

			if (_rl > 0)
				_cl = _grid[0].Length;

			int[][] visited = new int[_rl][];
			Enumerable.Range(0, _rl).ToList().ForEach(u =>
			{
				visited[u] = new int[_cl];
			});

			int retVal = 0;

			for (int i = 0; i < _grid.Length; i++)
			{
				for (int j = 0; j < _grid[0].Length; j++)
				{
					if (DFS(i, j, visited) == 1)
					{
						if (isClosed)
							retVal++;
						else
							isClosed = true;
					}
				}
			}

			return retVal;
		}

		private int DFS(int i, int j, int[][] visited)
		{
			if (!IsValid(i, j) || _grid[i][j] == 1 || visited[i][j] == 1)
				return 0;

			visited[i][j] = 1;

			if (i == _rl - 1 || j == _cl - 1 || i == 0 || j == 0)
				isClosed = false;

			DFS(i + 1, j, visited);
			DFS(i - 1, j, visited);
			DFS(i, j + 1, visited);
			DFS(i, j - 1, visited);

			return 1;
		}

		private bool IsValid(int i, int j)
		{
			return !(i >= _rl || i < 0 || j >= _cl || j < 0);
		}
	}
}
