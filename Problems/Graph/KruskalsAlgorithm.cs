using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class KruskalsAlgorithm
    {
        public int MinimumSpanningTreeCost(int n, int[][] edges)
        {
            var ds = new DisjointSet();
            var groups = ds.Group(edges);

            if (groups.Count > 1)
                return -1;

            var costs = edges.ToList().Select(u => u[2]).ToList();
            int cost = 0;
            var costsSorted = costs.OrderBy(u=>u).ToList();
            int i = 0;
            while (i < n - 1)
            {
                cost += costsSorted[i];
                i += 1;
            }


            return cost;
        }

        class DisjointSet
        {
            Dictionary<int, List<int>> groups = new Dictionary<int, List<int>>();
            Dictionary<int, int> nodeGroupMap = new Dictionary<int, int>();
            int group_counter = 0;

            public List<List<int>> Group(int[][] edges)
            {
                List<List<int>> result = new List<List<int>>();

                foreach (var edge in edges)
                    Union(edge);

                return groups.Values.ToList();
            }

            private void Union(int[] edge)
            {
                int x = edge[0];
                int y = edge[1];

                int x_group = Find(x);
                int y_group = Find(y);

                if (x_group == -1 && y_group == -1)
                {
                    group_counter += 1;
                    groups.Add(group_counter, new List<int>());
                    groups[group_counter].Add(x);
                    groups[group_counter].Add(y);

                    nodeGroupMap.Add(x, group_counter);
                    nodeGroupMap.Add(y, group_counter);
                }
                else if (x_group == -1 && y_group > 0)
                {
                    groups[y_group].Add(x);
                    nodeGroupMap.Add(x, y_group);
                }
                else if (x_group > 0 && y_group == -1)
                {
                    groups[x_group].Add(y);
                    nodeGroupMap.Add(y, x_group);
                }
                else if (x_group == y_group)
                    return;
                else
                {
                    if (groups[y_group].Count > groups[x_group].Count)
                    {
                        int t_group = x_group;
                        x_group = y_group;
                        y_group = t_group;
                    }

                    foreach (var item in groups[y_group])
                    {
                        groups[x_group].Add(item);
                        nodeGroupMap[item] = x_group;
                    }

                    groups.Remove(y_group);
                }
            }

            private int Find(int x)
            {
                if (nodeGroupMap.ContainsKey(x))
                    return nodeGroupMap[x];

                return -1;
            }
        }
    }
}
