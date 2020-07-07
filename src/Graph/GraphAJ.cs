using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class GraphAJ<TVertex>
    {
        private Dictionary<TVertex, IList<TVertex>> adjacencyList = new Dictionary<TVertex, IList<TVertex>>();

        public Dictionary<TVertex, IList<TVertex>> AdjacencyList => adjacencyList;

        public GraphAJ(IList<TVertex> vertices, IList<Tuple<TVertex, TVertex>> edges)
        {
            foreach (var vertex in vertices)
                adjacencyList.Add(vertex, new List<TVertex>());

            foreach (var edge in edges)
                adjacencyList[edge.Item1].Add(edge.Item2);
        }

        public HashSet<TVertex> DFS(TVertex start)
        {
            var visited = new HashSet<TVertex>();

            if (!this.adjacencyList.ContainsKey(start))
                throw new ArgumentException("Vertex doesn't exists!");

            DFSInternal(start, visited);
            return visited;
        }

        private void DFSInternal(TVertex vertex, HashSet<TVertex> visited)
        {
            if (visited.Contains(vertex))
                return;

            visited.Add(vertex);

            foreach (var neigbour in adjacencyList[vertex])
                DFSInternal(neigbour, visited);
        }

        public HashSet<TVertex> BFS(TVertex start)
        {
            var visited = new HashSet<TVertex>();
            var queue = new Queue<TVertex>();

            if (!this.adjacencyList.ContainsKey(start))
                throw new ArgumentException("Vertex doesn't exists!");

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertexToProcess = queue.Dequeue();
                visited.Add(vertexToProcess);

                foreach (var vertex in this.adjacencyList[vertexToProcess])
                    if (!visited.Contains(vertex))
                        queue.Enqueue(vertex);
            }

            return visited;
        }
    }
}
