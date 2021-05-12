using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class CycleExists
	{
		private Dictionary<int, IList<int>> graph = new Dictionary<int, IList<int>>();
		public bool IsCyclic(int[][] grid)
		{
			if (grid.Length == 0)
				return false;

			foreach (var item in grid)
			{
				if (!graph.ContainsKey(item[0]))
					graph.Add(item[0], new List<int>());

				graph[item[0]].Add(item[1]);
			}

			foreach (var key in graph.Keys)
			{
				HashSet<int> visited = new HashSet<int>();
				if (DFSInternal(key, -1, visited))
					return true;
			}
			return false;
		}

		private bool DFSInternal(int vertex, int parent, HashSet<int> visited)
		{
			if (visited.Contains(vertex))
				return true;

			visited.Add(vertex);

			if (graph.ContainsKey(vertex))
			{
				var neighbours = graph[vertex];
				foreach (var n in neighbours)
				{
					if (n == parent)
						continue;

					if (DFSInternal(n, vertex, visited))
						return true;
				}
			}

			visited.Remove(vertex);
			return false;
		}
	}
}
