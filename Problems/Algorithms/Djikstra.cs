using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	/// <summary>
	/// Time Complexity: N vertices. O(NLogN)
	/// Space Complexity: O(N + E)
	/// </summary>
	public class Djikstra
	{
		HashSet<int> vertices = new HashSet<int>();
		private int?[] nodeTime;
		private Heap<int> heap = new Heap<int>();
		private Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();
		public int FindMinimum(int[][] input)
		{
			graph = BuildGraph(input);
			nodeTime = new int?[vertices.Count];
			var heap = new Heap<int>();
			heap.Push(0);
			nodeTime[0] = 0;
			while (heap.Length > 0)
			{
				var dqedItem = heap.Pop();
				if (graph.ContainsKey(dqedItem))
				{
					var nebours = graph[dqedItem];
					foreach (var nebour in nebours)
					{
						if (nodeTime[nebour[0]] == null)
							heap.Push(nebour[0]);

						var newTime = (nodeTime[dqedItem] ?? 0) + nebour[1];
						if (nodeTime[nebour[0]] == null || newTime < nodeTime[nebour[0]])
							nodeTime[nebour[0]] = newTime;
					}
				}
			}

			return FindMaximum(nodeTime);
		}

		private Dictionary<int, List<int[]>> BuildGraph(int[][] input)
		{
			foreach (var i in input)
			{
				if (!graph.ContainsKey(i[0]))
					graph.Add(i[0], new List<int[]>());

				graph[i[0]].Add(new int[2] { i[1], i[2] });
				vertices.Add(i[0]);
				vertices.Add(i[1]);
			}
			return graph;
		}

		private int FindMaximum(int?[] nodeTime)
		{
			var ret = -1;
			foreach (var nt in nodeTime)
			{
				if (nt != null && nt > ret)
					ret = nt.Value;
			}
			return ret;
		}
	}
}
