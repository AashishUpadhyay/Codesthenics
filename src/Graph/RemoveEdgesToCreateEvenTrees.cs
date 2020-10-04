using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class RemoveEdgesToCreateEvenTrees
	{
		private GraphAJ<int> _graph;
		public IList<Tuple<int, int>> RemoveableEdges(GraphAJ<int> graph, int root)
		{
			_graph = graph;
			var returnValue = new List<Tuple<int, int>>();
			var removeableEdges = new Dictionary<string, Edge>();

			var neighbours = _graph.AdjacencyList[root];

			foreach (var neighbor in neighbours)
			{
				var descendantCount = CountDescendants(root, neighbor, removeableEdges);
				if (descendantCount % 2 == 0)
				{
					var edge = new Edge(root, neighbor);
					removeableEdges.Add(edge.HashCode, edge);
				}
			}

			if (removeableEdges.Count > 0)
				returnValue = removeableEdges.Values.Select(u => new Tuple<int, int>(u.Vertex1, u.Vertex2)).ToList();
			return returnValue;
		}

		private int CountDescendants(int fromVertex, int toVertex, Dictionary<string, Edge> removeableEdges)
		{
			var descendantCount = 1;
			var neighbours = _graph.AdjacencyList[toVertex];

			foreach (var neighbor in neighbours)
			{
				var currentDescendantCount = CountDescendants(toVertex, neighbor, removeableEdges);
				if (currentDescendantCount % 2 == 0)
				{
					var edge = new Edge(toVertex, neighbor);
					removeableEdges.Add(edge.HashCode, edge);
				}
				descendantCount += currentDescendantCount;
			}

			return descendantCount;
		}

		struct Edge
		{
			public Edge(int vertex1, int vertex2)
			{
				Vertex1 = vertex1;
				Vertex2 = vertex2;
			}

			public int Vertex1;
			public int Vertex2;

			public string HashCode => Vertex1.ToString() + Vertex2.ToString();
		}

		private Dictionary<int, IList<int>> _aj = new Dictionary<int, IList<int>>();
		private List<int[]> _removableEdges = new List<int[]>();
		public int RemoveableEdgesCount(int[][] grid)
		{
			if (grid.Length == 0)
				return 0;

			foreach (var item in grid)
			{
				if (!_aj.ContainsKey(item[0]))
					_aj.Add(item[0], new List<int>());

				_aj[item[0]].Add(item[1]);
			}

			RemoveableEdgesCountInternal(1);
			return _removableEdges.Count;
		}

		private int RemoveableEdgesCountInternal(int vertex)
		{
			if (!_aj.ContainsKey(vertex))
				return 1;

			var neighbours = _aj[vertex];

			int totalDescCount = 0;
			foreach (var n in neighbours)
			{
				int descCount = RemoveableEdgesCountInternal(n);
				if ((descCount & 1) == 0)
					_removableEdges.Add(new int[2] { vertex, n});

				totalDescCount += descCount;
			}

			return totalDescCount + 1;
		}
	}
}
