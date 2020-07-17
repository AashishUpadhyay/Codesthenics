using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class AndroidPattern
	{
		private Dictionary<int, List<int>> dict;
		private Dictionary<int, List<int[]>> dictsplcase;
		private bool[] used = new bool[10];
		private int totalPatterns = 0;
		private int max;
		private int min;
		public int NumberOfPatterns(int m, int n)
		{
			dict = BuildDictionary();
			dictsplcase = BuildDictionarySplCase();
			min = m;
			max = n;
			for (int i = 1; i <= 9; i++)
			{
				var pattern = new List<int>();
				CountPatterns(i, pattern);
			}
			return totalPatterns;
		}

		private void CountPatterns(int next, List<int> pattern)
		{
			pattern.Add(next);
			used[next] = true;

			if (pattern.Count <= max)
			{
				if (pattern.Count() >= min)
					totalPatterns++;

				var neighbours = GetNeighbors(next);
				foreach (var n in neighbours)
				{
					if (!used[n])
						CountPatterns(n, pattern);
				}
			}
			pattern.RemoveAt(pattern.Count() - 1);
			used[next] = false;
		}

		private List<int> GetNeighbors(int next)
		{
			var returnVal = new List<int>();
			returnVal.AddRange(dict[next]);

			var addlNeighbors = dictsplcase[next];
			foreach(var an in addlNeighbors)
			{
				if (used[an[1]])
					returnVal.Add(an[0]);
			}

			return returnVal;
		}

		private Dictionary<int, List<int>> BuildDictionary()
		{
			var dict = new Dictionary<int, List<int>>();
			dict.Add(1, new List<int>() { 2, 5, 4, 6, 8 });
			dict.Add(2, new List<int>() { 1, 3, 4, 5, 6, 7, 9 });
			dict.Add(3, new List<int>() { 2, 5, 6, 4, 8 });
			dict.Add(4, new List<int>() { 1, 2, 5, 8, 7, 3, 9 });
			dict.Add(5, new List<int>() { 1, 2, 3, 4, 6, 7, 8, 9 });
			dict.Add(6, new List<int>() { 3, 2, 5, 8, 9, 1, 7 });
			dict.Add(7, new List<int>() { 4, 5, 8, 2, 6 });
			dict.Add(8, new List<int>() { 7, 4, 5, 6, 9, 1, 3 });
			dict.Add(9, new List<int>() { 8, 5, 6, 2, 4 });
			return dict;
		}

		private Dictionary<int, List<int[]>> BuildDictionarySplCase()
		{
			var dict = new Dictionary<int, List<int[]>>();
			dict.Add(1, new List<int[]>() { new int[2] { 3, 2 }, new int[2] { 9, 5 }, new int[2] { 7, 4 } });
			dict.Add(2, new List<int[]>() { new int[2] { 8, 5 } });
			dict.Add(3, new List<int[]>() { new int[2] { 1, 2 }, new int[2] { 7, 5 }, new int[2] { 9, 6 } });

			dict.Add(4, new List<int[]>() { new int[2] { 6, 5 } });
			dict.Add(5, new List<int[]>());
			dict.Add(6, new List<int[]>() { new int[2] { 4, 5 } });

			dict.Add(7, new List<int[]>() { new int[2] { 1, 4 }, new int[2] { 3, 5 }, new int[2] { 9, 8 } });
			dict.Add(8, new List<int[]>() { new int[2] { 2, 5 } });
			dict.Add(9, new List<int[]>() { new int[2] { 3, 6 }, new int[2] { 1, 5 }, new int[2] { 7, 8 } });
			return dict;
		}
	}
}
