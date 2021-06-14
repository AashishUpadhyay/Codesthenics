using System;
using Problems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
	[TestClass]
	public class BellmanFordTests
    {
		[TestMethod]
        public void Test1()
		{
			var bf = new BellmanFord();
			int[][] edges = new int[8][]
			{
				new int[]{0, 1, -1 },
				new int[]{0, 2, 4 },
				new int[]{1, 2, 3 },
				new int[]{1, 3, 1 },
				new int[]{1, 4, 2 },
				new int[]{3, 1, 2 },
				new int[]{3, 2, 5 },
				new int[]{4, 3, -3 },
			};
			int[] received = bf.CalculateDistance(0, 5, edges);
			int[] expected = new int[5] { 0, -1, 2, -2, 1 };
			Assert.IsTrue(Enumerable.SequenceEqual(received, expected));
		}

		[TestMethod]
		public void TestDirectedCyclicGraph()
		{
			var bf = new BellmanFord();
			int[][] edges = new int[6][]
			{
				new int[]{5, 0, 3 },
				new int[]{5, 2, 4 },
				new int[]{4, 0, 3 },
				new int[]{4, 1, 1 },
				new int[]{3, 1, 2 },
				new int[]{2, 3, 2 }
			};
			int[] received = bf.CalculateDistance(5, 6, edges);
			int[] expected = new int[6] { 3, 8, 4, 6, Int32.MaxValue, 0 };
			Assert.IsTrue(Enumerable.SequenceEqual(received, expected));
		}
	}
}
