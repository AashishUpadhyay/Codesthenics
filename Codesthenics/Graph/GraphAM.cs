﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class GraphAM<T>
    {
        private int _rows;
        private int _cols;
        private T[,] _adjacencyMatrix;

        public GraphAM(T[,] arr, int rows, int cols)
        {
            _adjacencyMatrix = arr;
            _rows = rows;
            _cols = cols;
        }

        public HashSet<GraphCellCoordinates> DFS()
        {
            var visited = new HashSet<GraphCellCoordinates>();

            DFSInternal(0, 0, visited);

            return visited;
        }

        private void DFSInternal(int i, int j, HashSet<GraphCellCoordinates> visited)
        {
            if (visited.Contains(new GraphCellCoordinates(i, j)))
                return;

            visited.Add(new GraphCellCoordinates(i, j));

            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j + 1; y++)
                {
                    if (IsCellValid(x, y) && !(x == i && y == j))
                    {
                        DFSInternal(x, y, visited);
                    }
                }
            }
        }

        private bool IsCellValid(int rowIndex, int colIndex)
        {
            if (rowIndex > _rows - 1 || rowIndex < 0 || colIndex > _cols - 1 || colIndex < 0)
                return false;

            return true;
        }
    }

    public class GraphCellCoordinates
    {
        public GraphCellCoordinates(int row, int col)
        {
            RowIndex = row;
            ColIndex = col;
        }

        public int RowIndex;
        public int ColIndex;

        public override bool Equals(Object obj)
        {
            var graphCellCoordinates = obj as GraphCellCoordinates;
            return this.RowIndex == graphCellCoordinates.RowIndex && this.ColIndex == graphCellCoordinates.ColIndex;
        }

        public override int GetHashCode()
        {
            return (this.RowIndex.ToString() + this.ColIndex.ToString()).GetHashCode();
        }
    }
}
