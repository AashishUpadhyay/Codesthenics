using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class TopologicalSort
    {
        public IList<string> Sort(IDictionary<string, IList<string>> dict)
        {
            var visited = new HashSet<string>();

            foreach (var vertex in dict.Keys)
            {
                if (!visited.Contains(vertex))
                    DFS(vertex, dict, visited);
            }

            return visited.ToList();
        }

        private void DFS(string vertex, IDictionary<string, IList<string>> dict, HashSet<string> visited)
        {
            Console.WriteLine("Vertex: " + vertex);
            if (visited.Contains(vertex))
                return;

            if (dict[vertex].Count == 0)
            {
                visited.Add(vertex);
            }
            else
            {
                foreach (var neighbor in dict[vertex])
                    DFS(neighbor, dict, visited);

                visited.Add(vertex);
            }
        }
    }
}
