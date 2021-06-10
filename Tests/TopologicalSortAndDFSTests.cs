using System;
using Problems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
	[TestClass]
	public class TopologicalSortAndDFSTests
	{
		[TestMethod]
		public void TestDirectedCyclicGraph()
		{
			var tsd = new TopologicalSortAndDFS();
			int[][] edges = new int[6][]
			{
				new int[]{5, 0, 3 },
				new int[]{5, 2, 4 },
				new int[]{4, 0, 3 },
				new int[]{4, 1, 1 },
				new int[]{3, 1, 2 },
				new int[]{2, 3, 2 }
			};
			int[] received = tsd.CalculateDistance(5, 6, edges);
			int[] expected = new int[6] { 3, 8, 4, 6, Int32.MaxValue, 0 };
			Assert.IsTrue(Enumerable.SequenceEqual(received, expected));
		}
	}
}
