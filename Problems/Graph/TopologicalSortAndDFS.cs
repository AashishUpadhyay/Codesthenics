using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class TopologicalSortAndDFS
    {
        public int[] CalculateDistance(int source, int n, int[][] edges)
        {
            List<int> topological_sort = TopologicalSort(n, edges);
            Dictionary<int, Dictionary<int, int>> graph = BuildGraph(edges);

            if (topological_sort.Count < n)
                return null;

            int[] result = new int[n];
            for (int i = 0; i < result.Length; i++)
                result[i] = Int32.MaxValue;

            result[source] = 0;

            for (int i = topological_sort.Count-1; i >= 0; i--)
                RelaxNodes(topological_sort[i], result, graph);
            return result;
        }

        private List<int> TopologicalSort(int n, int[][] edges)
        {
            Dictionary<int, Dictionary<int, int>> graph = BuildGraph(edges);
            Queue<int> todo = new Queue<int>();
            HashSet<int> completed = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                if (!graph.ContainsKey(i))
                    todo.Enqueue(i);
            }

            while (todo.Count > 0)
            {
                var new_todo = todo.Dequeue();

                foreach(var key in graph.Keys)
                {
                    if (graph[key].ContainsKey(new_todo))
                        graph[key].Remove(new_todo);

                    if (graph[key].Count == 0 && !completed.Contains(key))
                        todo.Enqueue(key);
                }
                completed.Add(new_todo);
            }
            return completed.ToList();
        }

        private Dictionary<int, Dictionary<int, int>> BuildGraph(int[][] edges)
        {
            var result = new Dictionary<int, Dictionary<int,int>>();

            foreach(var edge in edges)
            {
                if (!result.ContainsKey(edge[0]))
                    result.Add(edge[0], new Dictionary<int,int>());

                result[edge[0]].Add(edge[1], edge[2]);
            }

            return result;
        }

        private void RelaxNodes(int source, int[] result, Dictionary<int, Dictionary<int, int>> graph)
        {
            if (result[source] == Int32.MaxValue)
                return;

            int dist = result[source];

            if (!graph.ContainsKey(source))
                return;

            Dictionary<int, int> nbours = graph[source];

            foreach(var nb in nbours.Keys)
            {
                int newDist = dist + nbours[nb];
                if (result[nb] > newDist)
                    result[nb] = newDist;
            }
        }
    }
}
