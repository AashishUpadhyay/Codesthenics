using System;
using System.Linq;
using System.Collections.Generic;
namespace Problems
{
    public class SkylineProblem
    {
        public SkylineProblem()
        {
        }

        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            var result = new List<IList<int>>();
            var pointsMap = new SortedDictionary<int, List<int[]>>();
            foreach (var building in buildings)
            {
                if (!pointsMap.ContainsKey(building[0]))
                {
                    pointsMap.Add(building[0], new List<int[]>());
                }

                if (!pointsMap.ContainsKey(building[1]))
                {
                    pointsMap.Add(building[1], new List<int[]>());
                }
                pointsMap[building[0]].Add(new int[2] { building[2], 0 });
                pointsMap[building[1]].Add(new int[2] { building[2], 1 });
            }

            var height_map = new SortedList<int, int>();
            height_map.Add(0, 1);
            foreach (var point_key in pointsMap.Keys)
            {
                var start_points = pointsMap[point_key].Where(u => u[1] == 0).OrderByDescending(v => v[0]);
                var end_points = pointsMap[point_key].Where(u => u[1] == 1).OrderBy(v => v[0]);
                var prev_max = height_map.Keys[height_map.Count()-1];
                foreach (var sp in start_points)
                {
                    if(!height_map.ContainsKey(sp[0]))
                    {
                        height_map.Add(sp[0], 0);
                    }
                    height_map[sp[0]] += 1;
                    var next_max = height_map.Keys[height_map.Count() - 1];
                    if (next_max != prev_max)
                        result.Add(new List<int>() { point_key, sp[0]});
                    prev_max = next_max;
                }

                foreach (var ep in end_points)
                {
                    height_map[ep[0]] -= 1;
                    if (height_map[ep[0]] == 0)
                        height_map.Remove(ep[0]);
                    var next_max = height_map.Keys[height_map.Count() - 1];
                    if (next_max != prev_max)
                        result.Add(new List<int>() { point_key, next_max });
                }
            }

            return result;
        }
    }
}
