using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class NetworkDelayTimeDFS
    {
        Dictionary<int, int> visited;
        public int NetworkDelayTime(int[][] times, int N, int K)
        {
            var graph = new Dictionary<int, List<Tuple<int, int>>>();
            visited = new Dictionary<int, int>();

            foreach (var t in times)
            {
                if (graph.ContainsKey(t[0]))
                    graph[t[0]].Add(new Tuple<int, int>(t[1], t[2]));
                else graph.Add(t[0], new List<Tuple<int, int>> { new Tuple<int, int>(t[1], t[2]) });
            }

            var keys = graph.Keys.ToList();
            foreach (var key in keys)
            {
                graph[key] = graph[key].OrderBy(u => u.Item2).ToList();
            }

            for (int node = 1; node <= N; ++node)
                visited.Add(node, Int32.MaxValue);

            DFS(graph, K, 0);

            var maxTimeTaken = 0;
            foreach (var item in visited.Values)
            {
                if (item == Int32.MaxValue) return -1;
                maxTimeTaken = Math.Max(maxTimeTaken, item);
            }

            return maxTimeTaken;
        }

        private void DFS(Dictionary<int, List<Tuple<int, int>>> graph, int destNode, int time)
        {
            if (visited[destNode] < time)
                return;

            visited[destNode] = time;
            if (graph.ContainsKey(destNode))
            {
                var neighbours = graph[destNode];
                foreach (var neighbour in neighbours)
                {
                    DFS(graph, neighbour.Item1, time + neighbour.Item2);
                }
            }
        }
    }

    public class NetworkDelayTimeBFS
    {
        public int NetworkDelayTime(int[][] times, int N, int K)
        {
            var visited = new Dictionary<int, int>();
            var graph = new Dictionary<int, List<Tuple<int, int>>>();
            foreach (var t in times)
            {
                if (graph.ContainsKey(t[0]))
                    graph[t[0]].Add(new Tuple<int, int>(t[1], t[2]));
                else graph.Add(t[0], new List<Tuple<int, int>> { new Tuple<int, int>(t[1], t[2]) });
            }

            var queue = new Queue<int>();
            visited.Add(K, 0);
            queue.Enqueue(K);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (graph.ContainsKey(node))
                {
                    foreach (var neighbour in graph[node])
                    {
                        if (!visited.ContainsKey(neighbour.Item1) ||
                            visited[neighbour.Item1] > visited[node] + neighbour.Item2)
                        {
                            if (visited.ContainsKey(neighbour.Item1))
                                visited[neighbour.Item1] = visited[node] + neighbour.Item2;
                            else visited.Add(neighbour.Item1, visited[node] + neighbour.Item2);
                            queue.Enqueue(neighbour.Item1);
                        }
                    }
                }

            }

            return visited.Count == N ? visited.Max(v => v.Value) : -1;
        }
    }
}
