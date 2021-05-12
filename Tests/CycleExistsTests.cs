using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems;

namespace Tests
{
	[TestClass]
	public class CycleExistsTests
	{
		[TestMethod]
		public void Test1()
		{
			var grid = new int[9][]
				{
					new int[2]{1,2},
					new int[2]{2,1},
					new int[2]{1,3},
					new int[2]{3,1},
					new int[2]{3,4},
					new int[2]{4,5},
					new int[2]{5,4},
					new int[2]{5,1},
					new int[2]{1,5}
				};

			bool cycleExists = (new CycleExists()).IsCyclic(grid);
			Assert.IsTrue(cycleExists);
		}

		[TestMethod]
		public void Test2()
		{
			var grid = new int[8][]
				{
					new int[2]{1,2},
					new int[2]{1,6},
					new int[2]{2,1},
					new int[2]{2,3},
					new int[2]{3,4},
					new int[2]{4,3},
					new int[2]{3,5},
					new int[2]{5,3}
				};

			bool cycleExists = (new CycleExists()).IsCyclic(grid);
			Assert.IsFalse(cycleExists);
		}

		[TestMethod]
		public void Test3()
		{
			var grid = new int[6][]
				{
					new int[2]{1,2},
					new int[2]{2,1},
					new int[2]{2,3},
					new int[2]{3,2},
					new int[2]{3,4},
					new int[2]{4,3},
				};

			bool cycleExists = (new CycleExists()).IsCyclic(grid);
			Assert.IsFalse(cycleExists);
		}
	}
}
