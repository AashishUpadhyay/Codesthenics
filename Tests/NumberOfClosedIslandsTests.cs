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
	public class NumberOfClosedIslandsTests
	{
		[TestMethod]
		public void Test1()
		{
			var grid = new int[5][]
				{
					new int[5]{0,1,1,1,0},
					new int[5]{1,0,1,0,1},
					new int[5]{1,0,1,0,1},
					new int[5]{1,0,0,0,1},
					new int[5]{0,1,1,1,0}
				};

			var cnt = (new NumberOfClosedIslands()).ClosedIslands(grid);
			Assert.IsTrue(cnt == 1);
		}
	}
}
