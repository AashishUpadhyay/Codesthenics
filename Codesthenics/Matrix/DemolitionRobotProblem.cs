using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    A robot is tasked to remove obstacle from a field laid out as a two dimensional matrix, 0 represents trench, 1 represent flat surface, 9 represents obstacle. Write a program to find the path length to reach obstacle
 */

namespace HitmanList
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

        public static int FindPath(int[,] fieldSpecifications, int rows, int cols)
        {
            m_fieldSpecifications = fieldSpecifications;
            m_rows = rows;
            m_cols = cols;

            var path = new List<Cell>();
            var returnValue = 0;
            ObstacleFound(new Cell() { RowId = 0, ColId = 0 }, new Cell() { RowId = -1, ColId = -1 }, ref returnValue, ref path);
            return returnValue;
        }

        private static bool ObstacleFound(Cell currentCell, Cell parentCell, ref int length, ref List<Cell> path)
        {
            var returnValue = false;

            if (currentCell.RowId < 0 ||
                currentCell.RowId >= m_rows ||
                currentCell.ColId < 0 ||
                currentCell.ColId >= m_cols ||
                m_fieldSpecifications[currentCell.RowId, currentCell.ColId] == 0)
                return false;

            if (m_fieldSpecifications[currentCell.RowId, currentCell.ColId] == 9)
            {
                path.Add(currentCell);
                return true;
            }

            var leftNeighbour = new Cell() { RowId = currentCell.RowId, ColId = currentCell.ColId - 1 };
            var rightNeighbour = new Cell() { RowId = currentCell.RowId, ColId = currentCell.ColId + 1 };
            var upNeighbour = new Cell() { RowId = currentCell.RowId - 1, ColId = currentCell.ColId };
            var downNeighbour = new Cell() { RowId = currentCell.RowId + 1, ColId = currentCell.ColId };

            if (!IsParentCell(leftNeighbour, parentCell) && ObstacleFound(leftNeighbour, currentCell, ref length, ref path) ||
                (!IsParentCell(rightNeighbour, parentCell) && ObstacleFound(rightNeighbour, currentCell, ref length, ref path)) ||
                (!IsParentCell(upNeighbour, parentCell) && ObstacleFound(upNeighbour, currentCell, ref length, ref path)) ||
                (!IsParentCell(downNeighbour, parentCell) && ObstacleFound(downNeighbour, currentCell, ref length, ref path)))
            {
                returnValue = true;
            }

            if (!returnValue)
                return false;

            path.Add(currentCell);
            length++;
            return true;
        }

        private static bool IsParentCell(Cell cell, Cell parentCell)
        {
            return (cell.RowId == parentCell.RowId) && (cell.ColId == parentCell.ColId);
        }

        struct Cell
        {
            public int RowId;
            public int ColId;
        }
    }

}
