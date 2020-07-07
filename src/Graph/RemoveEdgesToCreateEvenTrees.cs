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
    }
}
