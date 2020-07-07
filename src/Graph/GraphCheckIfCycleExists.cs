using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class GraphCheckIfCycleExists<TVertex>
    {
        public bool CycleExists(GraphAJ<TVertex> graph)
        {
            if (graph.AdjacencyList.Count == 0)
                throw new ArgumentException("Empty Graph!");

            var visited = new HashSet<TVertex>();
            var returnValue = CycleExistsInternal(graph, graph.AdjacencyList.First().Key, graph.AdjacencyList.First().Key, visited);
            return returnValue;
        }

        private bool CycleExistsInternal(GraphAJ<TVertex> graph, TVertex vertex, TVertex sourceVertex, HashSet<TVertex> visited)
        {
            bool returnValue = false;

            if (visited.Contains(vertex))
                return returnValue;

            visited.Add(vertex);

            foreach (var neighbour in graph.AdjacencyList[vertex])
            {
                if (visited.Contains(neighbour) && !neighbour.Equals(sourceVertex))
                {
                    returnValue = true;
                    break;
                }
                returnValue = CycleExistsInternal(graph, neighbour, vertex, visited);
            }

            return returnValue;
        }
    }
}
