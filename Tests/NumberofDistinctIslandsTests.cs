using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using System.Collections.Generic;

namespace Tests
{
	[TestClass]
	public class NumberofDistinctIslandsTests
	{
		[TestMethod]
		public void Test()
		{
			var ndi = new NumberofDistinctIslands();
			var returnedValue = ndi.NumDistinctIslands(new int[4][] {
			new int[5]{1,1,0,0,0},
			new int[5]{1,1,0,0,0},
			new int[5]{0,0,0,1,1},
			new int[5]{0,0,0,1,1},
			});

			Assert.IsTrue(returnedValue == 1);
		}

		[TestMethod]
		public void Test1()
		{
			var ndi = new NumberofDistinctIslands();
			var returnedValue = ndi.NumDistinctIslands(new int[4][] {
			new int[5]{1,1,0,0,0},
			new int[5]{1,0,0,0,0},
			new int[5]{0,0,0,0,1},
			new int[5]{0,0,0,1,1},
			});

			Assert.IsTrue(returnedValue == 2);
		}

		[TestMethod]
		public void Test2()
		{
			var ndi = new NumberofDistinctIslands();
			var returnedValue = ndi.NumDistinctIslands(new int[4][] {
			new int[5]{1,1,1,1,1},
			new int[5]{1,1,1,1,1},
			new int[5]{1,1,1,1,1},
			new int[5]{1,1,1,1,1},
			});

			Assert.IsTrue(returnedValue == 1);
		}

		[TestMethod]
		public void Test3()
		{
			var ndi = new NumberofDistinctIslands();
			var returnedValue = ndi.NumDistinctIslands(new int[4][] {
			new int[5]{1,1,0,0,0},
			new int[5]{1,0,0,0,0},
			new int[5]{0,0,0,1,1},
			new int[5]{0,0,0,1,0},
			});

			Assert.IsTrue(returnedValue == 1);
		}

		[TestMethod]
		public void Test4()
		{
			var ndi = new NumberofDistinctIslands();
			var returnedValue = ndi.NumDistinctIslands(new int[2][] {
			new int[3]{0,0,1},
			new int[3]{1,1,0},
			});

			Assert.IsTrue(returnedValue == 2);
		}

		[TestMethod]
		public void Test5()
		{
			var ndi = new NumberofDistinctIslands();
			var returnedValue = ndi.NumDistinctIslands(new int[4][] {
				new int[50]{0,0,1,0,1,0,1,1,1,0,0,0,0,1,0,0,1,0,0,1,1,1,0,1,1,1,0,0,0,1,1,0,1,1,0,1,0,1,0,1,0,0,0,0,0,1,1,1,1,0},
				new int[50]{0,0,1,0,0,1,1,1,0,0,1,0,1,0,0,1,1,0,0,1,0,0,0,1,0,1,1,1,0,0,0,0,0,0,0,1,1,1,0,0,0,1,0,1,1,0,1,0,0,0},
				new int[50]{0,1,0,1,0,1,1,1,0,0,1,1,0,0,0,0,1,0,1,0,1,1,1,0,1,1,1,0,0,0,1,0,1,0,1,0,0,0,1,1,1,1,1,0,0,1,0,0,1,0},
				new int[50]{1,0,1,0,0,1,0,1,0,0,1,0,0,1,1,1,0,1,0,0,0,0,1,0,1,0,0,1,0,1,1,1,0,1,0,0,0,1,1,1,0,0,0,0,1,1,1,1,1,1}
			});

			Assert.IsTrue(returnedValue == 15);
		}

		[TestMethod]
		public void Test6()
		{
			var ndi = new NumberofDistinctIslands();
			var returnedValue = ndi.NumDistinctIslands(new int[2][] {
				new int[7]{1,1,1,0,1,1,1},
				new int[7]{0,0,1,0,1,0,0},
			});

			Assert.IsTrue(returnedValue == 2);
		}
	}
}
