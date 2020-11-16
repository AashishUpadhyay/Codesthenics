using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class MaximumRectangle
	{
		private int _len = 0;
		private int _wid = 0;
		private int _area = 0;
		private char[][] _matrix;
		public int Area(char[][] matrix)
		{
			_matrix = matrix;

			if (_matrix.Length == 0)
				return 0;

			_len = _matrix.Length;
			if (_matrix[0].Length > 0)
				_wid = _matrix[0].Length;

			for (int i = 0; i < _len; i++)
			{
				for (int j = 0; j < _wid; j++)
				{
					int[] _visited = new int[_wid];
					CalculateArea(i, j, 1, _visited, 0);
				}
			}

			return _area;
		}

		private void CalculateArea(int i, int j, int width, int[] visited, int height)
		{
			if (j < 0 || j > _wid - 1 || _matrix[i][j] == '0' || visited[j] == 1)
				return;

			visited[j] = 1;

			int ht = -1;
			if (height == 0)
				ht = CalculateHeight(i, j);
			else
				ht = Math.Min(height, CalculateHeight(i, j));

			_area = Math.Max(_area, ht * width);

			CalculateArea(i, j + 1, width + 1, visited, ht);
			CalculateArea(i, j - 1, width + 1, visited, ht);
		}

		private int CalculateHeight(int i, int j)
		{
			int ht = 0;
			for (int m = i; m > -1; m--)
			{
				if (_matrix[m][j] == '0')
					break;
				ht++;
			}
			return ht;
		}
	}

}
