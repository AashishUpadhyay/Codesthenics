using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class BeatSnakesAndLadders
	{
		public int SmallestNumberOfMoves(Dictionary<int, int> snakes, Dictionary<int, int> ladders)
		{
			var minimumMoves = 0;
			bool finished = false;

			var cellsToProcess = new Queue<Cell>();
			var cellsToProcessTracker = new HashSet<int>();

			cellsToProcess.Enqueue(new Cell(0, 0));
			while (cellsToProcess.Count > 0 && !finished)
			{
				var currentCell = cellsToProcess.Dequeue();

				if (ladders.ContainsKey(currentCell.Id))
				{
					if (!cellsToProcessTracker.Contains(ladders[currentCell.Id]))
					{
						cellsToProcess.Enqueue(new Cell(ladders[currentCell.Id], currentCell.Move));
					}
				}
				else if (snakes.ContainsKey(currentCell.Id))
				{
					if (!cellsToProcessTracker.Contains(snakes[currentCell.Id]))
					{
						cellsToProcess.Enqueue(new Cell(snakes[currentCell.Id], currentCell.Move));
					}
				}
				else
				{
					for (int i = 1; i <= 6; i++)
					{
						var newCellId = currentCell.Id + i;
						var possibleCell = new Cell(newCellId, currentCell.Move + 1);
						if (possibleCell.Id == 100)
						{
							finished = true;
							minimumMoves = currentCell.Move + 1;
							break;
						}

						if (!cellsToProcessTracker.Contains(possibleCell.Id))
						{
							cellsToProcess.Enqueue(possibleCell);
							cellsToProcessTracker.Add(possibleCell.Id);
						}
					}
				}
			}

			return minimumMoves;
		}

		private int _minMoves = Int32.MaxValue;
		public int MinimumMoves(Dictionary<int, int> snakesAndLadders)
		{
			Queue<int[]> queue = new Queue<int[]>();

			queue.Enqueue(new int[2] { 1, 0 });
			HashSet<int> visited = new HashSet<int>();
			while (queue.Count > 0)
			{
				var dqedItem = queue.Dequeue();
				var currentCell = dqedItem[0];
				var currentTurn = dqedItem[1];

				if (currentCell == 100)
				{
					_minMoves = Math.Min(_minMoves, currentTurn);
					continue;
				}

				if (visited.Contains(currentCell))
					continue;

				visited.Add(currentCell);

				if (snakesAndLadders.ContainsKey(currentCell))
				{
					queue.Enqueue(new int[2] { snakesAndLadders[currentCell], currentTurn });
					continue;
				}

				var limit = Math.Min(100, currentCell + 6);
				var nextMoves = Enumerable.Range(currentCell + 1, (limit - currentCell)).ToList();

				var filteredMoves = nextMoves.Where(u => snakesAndLadders.ContainsKey(u));
				if (filteredMoves.Count()==0)
				{
					queue.Enqueue(new int[2] { nextMoves[nextMoves.Count() - 1], currentTurn + 1 });
				}
				else
				{
					filteredMoves.ToList().ForEach(u =>
					{
						visited.Add(u);
						queue.Enqueue(new int[2] { snakesAndLadders[u], currentTurn + 1 });
					});
				}
			}

			return _minMoves;
		}

		public struct Cell
		{
			public Cell(int id, int move)
			{
				Id = id;
				Move = move;
			}

			public int Id { get; set; }
			public int Move { get; set; }
		}
	}
}
