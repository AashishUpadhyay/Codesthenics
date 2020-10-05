using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class NumberofDistinctIslands
    {
        private int _rl;
        private int _cl;
        private int[][] _grid;
        private HashSet<string> _visited = new HashSet<string>();
        public int NumDistinctIslands(int[][] grid)
        {
            _rl = grid.Length;
            if (_rl > 0)
                _cl = grid[0].Length;

            if (_rl == 0 || _cl == 0)
                return 0;

            _grid = grid;

            HashSet<string> distinctIslands = new HashSet<string>();
            for (int i = 0; i <= _rl - 1; i++)
            {
                for (int j = 0; j <= _cl - 1; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    DFS(i, j, sb, 0);
                    if (sb.ToString().Length > 0)
                    {
                        distinctIslands.Add(sb.ToString());
                    }
                }
            }

            return distinctIslands.Count();
        }

        private void DFS(int ri, int ci, StringBuilder sb, int path)
        {
            string cellId = (new Cell(ri, ci)).CellId;
            if (!IsValid(ri, ci) || _grid[ri][ci] == 0 || _visited.Contains(cellId))
                return;

            _visited.Add(cellId);
            sb.Append(path);
            DFS(ri, ci + 1, sb, 1);
            DFS(ri + 1, ci, sb, 2);
            DFS(ri, ci - 1, sb, 3);
            DFS(ri - 1, ci, sb, 4);
            sb.Append(5);
        }

        private bool IsValid(int ri, int ci)
        {
            if (ri < 0 || ci < 0 || (ri > (_rl - 1)) || (ci > (_cl - 1)))
                return false;

            return true;
        }

        struct Cell
        {
            public Cell(int ri, int ci)
            {
                RowId = ri;
                ColId = ci;
            }

            public int RowId;
            public int ColId;

            public string CellId => RowId.ToString() + "-" + ColId.ToString();
        }
    }
}
