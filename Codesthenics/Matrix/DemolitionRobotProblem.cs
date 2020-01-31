using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    A robot is tasked to remove obstacle from a field laid out as a two dimensional matrix, 0 represents trench, 1 represent flat surface, 9 represents obstacle. Write a program to find the path length to reach obstacle
 */

namespace Codesthenics
{
    /*
            { 1, 1, 0, 0, 0 }
            { 0, 1, 1, 0, 0 }
            { 0, 9, 1, 0, 0 }
            { 0, 1, 1, 0, 0 }
            { 0, 1, 0, 0, 0 }
     */
    public class DemolitionRobotProblem
    {
        private static int[,] m_fieldSpecifications;
        private static int m_rows;
        private static int m_cols;

        public int FindPathUsingBFS(int[,] fieldSpecifications, int rows, int cols)
        {
            m_fieldSpecifications = fieldSpecifications;
            m_rows = rows;
            m_cols = cols;

            var queue = new Queue<Cell>();
            var visited = new HashSet<string>();

            queue.Enqueue(new Cell(0, 0, 0));
            int pathLength = 0;

            while (queue.Count > 0)
            {
                var cellToProcess = queue.Dequeue();
                visited.Add(cellToProcess.CellIdentifier);

                for (int x = cellToProcess.RowId - 1; x <= cellToProcess.RowId + 1; x++)
                {
                    for (int y = cellToProcess.ColId - 1; y <= cellToProcess.ColId + 1; y++)
                    {
                        var newCell = new Cell(x, y, cellToProcess.CellWeight + 1);
                        if (IsCellValid(x, y) && !IsDiagonal(cellToProcess, newCell) && !visited.Contains(newCell.CellIdentifier))
                        {
                            if (m_fieldSpecifications[x, y] == 9)
                            {
                                if (pathLength == 0)
                                    pathLength = newCell.CellWeight;
                                else
                                {
                                    if (pathLength > newCell.CellWeight)
                                        pathLength = newCell.CellWeight;
                                }
                            }
                            else if (m_fieldSpecifications[x, y] == 1)
                            {
                                queue.Enqueue(newCell);
                            }
                        }
                    }
                }
            }

            return pathLength;
        }

        private static bool IsDiagonal(Cell cellProcessed, Cell newCell)
        {
            if ((newCell.RowId == cellProcessed.RowId - 1 && newCell.ColId == cellProcessed.ColId - 1) ||
                (newCell.RowId == cellProcessed.RowId - 1 && newCell.ColId == cellProcessed.ColId + 1) ||
                (newCell.RowId == cellProcessed.RowId + 1 && newCell.ColId == cellProcessed.ColId - 1) ||
                (newCell.RowId == cellProcessed.RowId + 1 && newCell.ColId == cellProcessed.ColId + 1))
                return true;

            return false;
        }

        private static bool IsCellValid(int x, int y)
        {
            if (x < 0 || x > m_rows - 1 || y < 0 || y > m_cols - 1)
                return false;

            return true;
        }

        struct Cell
        {
            public Cell(int rowId, int colId, int cellWeight)
            {
                RowId = rowId;
                ColId = colId;
                CellWeight = cellWeight;
            }

            public int RowId;
            public int ColId;
            public int CellWeight;

            public string CellIdentifier => (RowId.ToString() + ColId.ToString());
        }
    }

}
