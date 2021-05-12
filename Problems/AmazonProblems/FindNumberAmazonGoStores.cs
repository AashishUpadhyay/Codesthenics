using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class FindNumberAmazonGoStores
    {
        private int _rows;
        private int _columns;
        private int[,] _grid;

        //Diagonals opposited elements are different cluster
        public int NumberAmazonGoStores(int rows, int columns, int[,] grid)
        {
            _rows = rows;
            _columns = columns;
            _grid = grid;

            //Console.WriteLine("_rows _columns " + " " + _rows + " " + columns);

            var returnValue = 0;

            var queue = new Queue<Cell>();
            var visited = new HashSet<string>();
            queue.Enqueue(new Cell(0, 0));

            while (queue.Count > 0)
            {
                var cellToProcess = queue.Dequeue();

                if (grid[cellToProcess.RowId, cellToProcess.ColId] == 1)
                {
                    //Console.WriteLine("DFS RowId ColId " + " " + cellToProcess.RowId + " " + cellToProcess.ColId);
                    if (IsAnIsland(cellToProcess.RowId, cellToProcess.ColId, visited, queue))
                    {
                        returnValue++;
                    }
                }
                else
                {
                    visited.Add(cellToProcess.CellUniqueId);
                    for (int x = cellToProcess.RowId - 1; x <= cellToProcess.RowId + 1; x++)
                    {
                        for (int y = cellToProcess.ColId - 1; y <= cellToProcess.ColId + 1; y++)
                        {
                            var newCell = new Cell(x, y);
                            if (IsValidCell(newCell.RowId, newCell.ColId) && !visited.Contains(newCell.CellUniqueId))
                            {
                                //Console.WriteLine("BFS RowId ColId " + " " + newCell.RowId + " " + newCell.ColId);
                                queue.Enqueue(newCell);
                            }
                        }
                    }
                }
            }

            return returnValue;
        }

        private bool CheckForDiagonals(int rowId, int colId)
        {
            if ((IsValidCell(rowId - 1, colId - 1) && _grid[rowId - 1, colId - 1] == 1) ||
                (IsValidCell(rowId - 1, colId + 1) && _grid[rowId - 1, colId + 1] == 1) ||
                (IsValidCell(rowId + 1, colId - 1) && _grid[rowId + 1, colId - 1] == 1) ||
                (IsValidCell(rowId + 1, colId + 1) && _grid[rowId + 1, colId + 1] == 1))
                return true;

            return false;
        }

        private bool IsAnIsland(int rowId, int colId, HashSet<string> visited, Queue<Cell> queue)
        {
            bool returnValue = false;
            var incomingCell = new Cell(rowId, colId);
            if (visited.Contains(incomingCell.CellUniqueId))
                return returnValue;
          
            visited.Add(incomingCell.CellUniqueId);
            Console.WriteLine("Visited in IsAnIsland" + " "+ incomingCell.CellUniqueId);

            for (int x = rowId - 1; x <= rowId + 1; x++)
            {
                for (int y = colId - 1; y <= colId + 1; y++)
                {
                    var newCell = new Cell(x, y);
                    if (IsValidCell(newCell.RowId, newCell.ColId) &&
                        !IsDiagonal(incomingCell.RowId, incomingCell.ColId, newCell.RowId, newCell.ColId)
                        && newCell.CellUniqueId != incomingCell.CellUniqueId)
                    {
                        if (_grid[newCell.RowId, newCell.ColId] == 0)
                        {
                            if (!visited.Contains(newCell.CellUniqueId))
                            {
                                //Console.WriteLine("DFS RowId ColId " + " " + newCell.RowId + " " + newCell.ColId);
                                queue.Enqueue(new Cell(x, y));
                            }
                        }
                        else
                        {
                            IsAnIsland(x, y, visited, queue);
                            //Console.WriteLine("IsAnIsland DFS RowId ColId " + " " + newCell.RowId + " " + newCell.ColId);
                            returnValue = true;
                        }
                    }
                }
            }

            if (returnValue == false && (CheckForDiagonals(incomingCell.RowId, incomingCell.ColId)))
                returnValue = true;

            return returnValue;
        }

        private bool IsValidCell(int rowId, int colId)
        {
            if (rowId < 0 || rowId > (_rows - 1) || colId < 0 || colId > (_columns - 1))
                return false;

            return true;
        }

        private bool IsDiagonal(int originalCellRowId, int originalCellColId, int newCellRowId, int newCellColId)
        {
            if ((newCellRowId == originalCellRowId - 1 && newCellColId == originalCellColId + 1) ||
                (newCellRowId == originalCellRowId - 1 && newCellColId == originalCellColId - 1) ||
                (newCellRowId == originalCellRowId + 1 && newCellColId == originalCellColId + 1) ||
                (newCellRowId == originalCellRowId + 1 && newCellColId == originalCellColId - 1))
                return true;

            return false;
        }

        public class Cell
        {
            public Cell(int rowId, int colId)
            {
                RowId = rowId;
                ColId = colId;
            }

            public string CellUniqueId => RowId.ToString() + ColId.ToString();

            public int RowId;
            public int ColId;
        }
    }
}
