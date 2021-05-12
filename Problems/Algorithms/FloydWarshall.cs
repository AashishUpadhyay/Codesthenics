using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class FloydWarshall
	{
		private const int CURRENT_CONTEXT_INFINITI = 10000000;
		int m_vertices;
		private int[][] graph;
		public int[][] BuildGraph(int[][] input, int vertices)
		{
			m_vertices = vertices;
			graph = new int[vertices][];
			for (int m = 0; m < vertices; m++)
			{
				graph[m] = new int[vertices];
				for (int n = 0; n < vertices; n++)
				{
					graph[m][n] = CURRENT_CONTEXT_INFINITI;
				}
			}

			BuildGraphInternal(input);

			for (int k = 0; k < vertices; k++)
			{
				for (int i = 0; i < vertices; i++)
				{
					for (int j = 0; j < vertices; j++)
					{
						if (graph[i][j] > (graph[i][k] + graph[k][j]))
							graph[i][j] = graph[i][k] + graph[k][j];
					}
				}
			}

			return graph;
		}

		private void BuildGraphInternal(int[][] input)
		{
			foreach (var item in input)
			{
				for (int i = 0; i < item.Length; i++)
				{
					if (graph[item[0]] == null)
						graph[item[0]] = new int[m_vertices];

					graph[item[0]][item[1]] = item[2];
				}
			}
		}
	}
}
