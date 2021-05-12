using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class AndroidPattern
	{
		private int _count;
		private int _max;
		private int _min;

		private int[][] graph = new int[10][]
		{
			new int[10]{-1,-1,-1,-1,-1, -1, -1, -1, -1, -1 }, //0
			new int[10]{-1,-1,2,-1,4, 5, 6, -1, 8, -1 }, //1
			new int[10]{-1,1,-1,3,4, 5, 6, 7, -1, 9 }, //2
			new int[10]{-1,-1,2,-1,4, 5, 6, -1, 8, -1 }, //3
			new int[10]{-1,1,2,3,-1, 5, -1, 7, 8, 9 }, //4
			new int[10]{-1,1,2,3,4, -1, 6, 7, 8, 9 }, //5
			new int[10]{-1,1,2,3,-1, 5, -1, 7, 8, 9 }, //6
			new int[10]{-1,-1,2,-1,4, 5, 6, -1, 8, -1 }, //7
			new int[10]{-1,1,-1,3,4, 5, 6, 7, -1, 9 }, //8
			new int[10]{-1,-1,2,-1,4, 5, 6, -1, 8, -1 } //9
		};

		private int[][] splCase = new int[10][]
		{
			new int[10]{-1,-1,-1,-1,-1, -1, -1, -1, -1, -1 }, //0
			new int[10]{-1,-1,-1,2,-1, -1, -1, 4, -1, 5 }, //1
			new int[10]{-1,-1,-1,-1,-1, -1, -1, -1, 5, -1 }, //2
			new int[10]{-1,2,-1,-1,-1, -1, -1, 5, -1, 6 },  //3
			new int[10]{-1,-1,-1,-1,-1, -1, 5, -1, -1, -1 }, //4
			new int[10]{-1,-1,-1,-1,-1, -1, -1, -1, -1, -1 }, //5
			new int[10]{-1,-1,-1,-1,5, -1, -1, -1, -1, -1 }, //6
			new int[10]{-1,4,-1,5,-1, -1, -1, -1, -1, 8 }, //7
			new int[10]{-1,-1,5,-1,-1, -1, -1, -1, -1, -1 }, //8
			new int[10]{-1,5,-1,6,-1, -1, -1, 8, -1, -1 }, //9
		};


		public int NumberOfPatterns(int m, int n)
		{
			_max = n;
			_min = m;
			_count = 0;
			CountPatterns(1, new List<int>(), new int[10]);
			int returnValue = 4 * _count;
			_count = 0;
			CountPatterns(2, new List<int>(), new int[10]);
			returnValue += 4 * _count;
			_count = 0;
			CountPatterns(5, new List<int>(), new int[10]);
			returnValue += _count;
			return returnValue;
		}

		private void CountPatterns(int num, List<int> pattern, int[] tracker)
		{
			pattern.Add(num);
			tracker[num] = 1;

			if (pattern.Count() <= _max)
			{
				if (pattern.Count() >= _min)
					_count++;

				for (int i = 1; i <= 9; i++)
				{
					if (isValid(i, num, tracker))
						CountPatterns(i, pattern, tracker);
				}
			}

			pattern.RemoveAt(pattern.Count() - 1);
			tracker[num] = 0;
		}

		private bool isValid(int nbr, int src, int[] tracker)
		{
			if (tracker[nbr] == 1)
				return false;

			if (graph[src][nbr] > 0 || tracker[splCase[src][nbr]] == 1)
				return true;

			return false;
		}
	}
}
