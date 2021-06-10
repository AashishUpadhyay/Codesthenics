using System;
using System.Collections.Generic;

namespace Problems
{
    public class BellmanFord
    {
        public int[] CalculateDistance(int source, int n, int[][] edges)
        {
            var result = new int[n];
            for (int i = 0; i < result.Length; i++)
                result[i] = Int32.MaxValue;

            result[source] = 0;
            Dictionary<int, List<int[]>> graph = BuildGraph(edges);

            for (int i=0;i< n-1;i++)
            {
                for (int j = 0;j<n;j++)
                {
                    RelaxNodes(j, result, graph);
                }
            }
            return result;
        }

        private Dictionary<int, List<int[]>> BuildGraph(int[][] edges)
        {
            var result = new Dictionary<int, List<int[]>>();

            foreach(var edge in edges)
            {
                if (!result.ContainsKey(edge[0]))
                    result.Add(edge[0], new List<int[]>());

                result[edge[0]].Add(new int[] { edge[1], edge[2] });
            }

            return result;
        }

        private void RelaxNodes(int source, int[] result, Dictionary<int, List<int[]>> graph)
        {
            if (result[source] == Int32.MaxValue)
                return;

            int dist = result[source];

            if (!graph.ContainsKey(source))
                return;

            List<int[]> nbours = graph[source];

            foreach(var nb in nbours)
            {
                int newDist = dist + nb[1];
                if (result[nb[0]] > newDist)
                    result[nb[0]] = newDist;
            }
        }
    }
}
