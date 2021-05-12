using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
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

        private Dictionary<int, IList<int>> _graph = new Dictionary<int, IList<int>>();
        private Stack<int> _stack = new Stack<int>();
        private HashSet<int> _completed = new HashSet<int>();
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {

            foreach (var p in prerequisites)
            {
                if (!_graph.ContainsKey(p[0]))
                    _graph.Add(p[0], new List<int>());

                _graph[p[0]].Add(p[1]);
            }

            foreach (var u in Enumerable.Range(0, numCourses))
            {
                if (!_graph.ContainsKey(u))
                    _graph.Add(u, new List<int>());
            };

            foreach (var item in _graph)
            {
                HashSet<int> visited = new HashSet<int>();
                if (_completed.Contains(item.Key))
                    continue;

                if (!DFS(item.Key, visited))
                    return new int[0];
            }

            return _stack.Reverse().ToList().ToArray();
        }

        private bool DFS(int vertex, HashSet<int> visited)
        {
            if (visited.Contains(vertex))
                return false;

            visited.Add(vertex);
            if (_graph.ContainsKey(vertex))
            {
                var neighbours = _graph[vertex];
                if (neighbours.Count() > 0)
                {
                    foreach (var n in neighbours)
                    {
                        if (_completed.Contains(n))
                            continue;

                        if (!DFS(n, visited))
                            return false;
                    }
                }
            }
            visited.Remove(vertex);
            _completed.Add(vertex);
            _stack.Push(vertex);
            return true;
        }
    }
}
