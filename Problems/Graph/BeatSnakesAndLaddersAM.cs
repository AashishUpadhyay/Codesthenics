using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class BeatSnakesAndLaddersAM
	{
		private int _colLength = 0;
		public int SnakesAndLadders(int[][] board)
		{

			if (board.Length == 0)
				return 0;

			_colLength = board[0].Length;
			int maxCellNo = _colLength * _colLength;

			int minMoves = Int32.MaxValue;
			Queue<int[]> queue = new Queue<int[]>();
			queue.Enqueue(new int[2] { 1, 0 });
			HashSet<int> visited = new HashSet<int>();
			while (queue.Count() > 0)
			{
				var dqedItem = queue.Dequeue();
				var cellNo = dqedItem[0];
				var cellMove = dqedItem[1];

				if (cellNo == maxCellNo)
				{
					minMoves = Math.Min(minMoves, cellMove);
				}

				if (visited.Contains(cellNo))
					continue;

				visited.Add(cellNo);

				var count = Math.Min(maxCellNo, cellNo + 6) - cellNo;
				var moves = Enumerable.Range(cellNo + 1, count).ToList();

				if (moves.Count() == 0)
					continue;

				var cellIds = BuildCellIds(moves);

				foreach (var ci in cellIds)
				{
					if (board[ci[0]][ci[1]] != -1)
					{
						queue.Enqueue(new int[2] { board[ci[0]][ci[1]], cellMove + 1 });
					}
					else
					{
						queue.Enqueue(new int[2] { ci[2], cellMove + 1 });
					}
				}
			}

			return minMoves == Int32.MaxValue ? -1 : minMoves;
		}

		private List<int[]> BuildCellIds(IList<int> moves)
		{
			var returnValue = new List<int[]>();

			foreach (var move in moves)
			{
				returnValue.Add(BuildCellId(move));
			}

			return returnValue;
		}

		private int[] BuildCellId(int move)
		{
			var quo = move / _colLength;
			var rem = move % _colLength;

			if (rem == 0)
			{
				if ((quo & 1) == 0)
				{
					return new int[3] { _colLength - quo, 0, move };
				}
				else
				{
					return new int[3] { _colLength - quo, _colLength - 1, move };
				}
			}
			else
			{
				if ((quo & 1) == 0)
				{
					return new int[3] { _colLength - quo - 1, rem - 1, move };
				}
				else
				{
					return new int[3] { _colLength - quo - 1, _colLength - rem, move };
				}
			}
		}
	}
}
