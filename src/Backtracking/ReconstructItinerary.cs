using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	/*
		Given a list of airline tickets represented by pairs of departure and arrival airports [from, to], reconstruct the itinerary in order. All of the tickets belong to a man who departs from JFK. Thus, the itinerary must begin with JFK.

		Note:

		If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string. For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
		All airports are represented by three capital letters (IATA code).
		You may assume all tickets form at least one valid itinerary.
		One must use all the tickets once and only once.
	*/
	public class ReconstructItinerary
	{
		Dictionary<string, IList<string[]>> graph;
		private int ticketCounter;
		public IList<string> FindItinerary(IList<IList<string>> tickets)
		{
			ticketCounter = tickets.Count() + 1;
			graph = BuildGraph(tickets);
			var path = new List<string>();
			var visited = new HashSet<string>();
			DFS("JFK", "0", path, visited);
			return path;
		}

		private Dictionary<string, IList<string[]>> BuildGraph(IList<IList<string>> tickets)
		{
			var graph = new Dictionary<string, IList<string[]>>();
			var ticketCounter = 0;
			foreach (var ticket in tickets)
			{
				if (!graph.ContainsKey(ticket[0]))
					graph.Add(ticket[0], new List<string[]>());

				ticketCounter++;
				var destTicket = new string[] { ticket[1], ticketCounter.ToString() };
				graph[ticket[0]].Add(destTicket);
			}
			return graph;
		}

		private bool DFS(string orig, string edge, IList<string> path, HashSet<string> visited)
		{
			path.Add(orig);

			if (visited.Contains(edge))
				return false;

			if (path.Count() == ticketCounter)
				return true;

			visited.Add(edge);

			if (graph.ContainsKey(orig))
			{
				var destns = graph[orig].OrderBy(u => u[0]).ToList();
				foreach (string[] d in destns)
				{
					if (DFS(d[0], d[1], path, visited))
						return true;
					else
						path.RemoveAt(path.Count() - 1);

				}
			}

			visited.Remove(edge);
			return false;
		}
	}
}
