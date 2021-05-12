using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class SudokuSolver
	{
        private char[][] _board;
        public char[][] SolveSudoku(char[][] board)
        {
            _board = board;
            SolveSudoku(0, 0);
            return _board;
        }

        private bool SolveSudoku(int ri, int ci)
        {
            if (ri > 8)
                return true;

            bool success = false;
            var nextIndex = GetNextIndex(ri, ci);

            if (_board[ri][ci] != '.')
                success = SolveSudoku(nextIndex[0], nextIndex[1]);
            else
            {
                var possibleMoves = GetPossibleMoves(ri, ci);
                foreach (var pm in possibleMoves)
                {
                    _board[ri][ci] = pm;
                    if (!SolveSudoku(nextIndex[0], nextIndex[1]))
                    {
                        _board[ri][ci] = '.';
                    }
                    else
                    {
                        success = true;
                        break;
                    }
                }
            }

            return success;
        }

        private int[] GetNextIndex(int ri, int ci)
        {
            if (ci == 8)
                return new int[] { ri + 1, 0 };
            else
                return new int[] { ri, ci + 1 };

        }

        private IList<char> GetPossibleMoves(int ri, int ci)
        {
            var moves = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 9; i++)
            {
                if (_board[ri][i] != '.')
                {
                    var index = Convert.ToInt16(_board[ri][i]) - 48;
                    moves[index] = 0;
                }
            }

            for (int j = 0; j < 9; j++)
            {
                if (_board[j][ci] != '.')
                {
                    var index = Convert.ToInt16(_board[j][ci]) - 48;
                    moves[index] = 0;
                }
            }

            var rowRange = GetRanges(ri);
            var colRange = GetRanges(ci);

            for (int u = rowRange[0]; u <= rowRange[1]; u++)
            {
                for (int v = colRange[0]; v <= colRange[1]; v++)
                {
                    if (_board[u][v] != '.')
                    {
                        var index = Convert.ToInt16(_board[u][v]) - 48;
                        moves[index] = 0;
                    }
                }
            }

            var retVal = new List<char>();
            for (int m = 1; m <= 9; m++)
            {
                if (moves[m] != 0)
                {
                    retVal.Add(Convert.ToChar(m + 48));
                }
            }
            return retVal;
        }

        private int[] GetRanges(int input)
        {
            if (input >= 0 && input <= 2)
                return new int[] { 0, 2 };

            if (input >= 3 && input <= 5)
                return new int[] { 3, 5 };

            if (input >= 6 && input <= 8)
                return new int[] { 6, 8 };

            return new int[] { 0, 0 };
        }
    }
}
