using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codesthenics;

namespace UnitTestProject
{
	[TestClass]
	public class MaximumRectangleTests
	{
		[TestMethod]
		public void Test1()
		{
			var grid = new int[3][]
				{
					new int[3]{1,1,0},
					new int[3]{1,1,0},
					new int[3]{1,1,0},
				};

			var ar = (new MaximumRectangle()).Area(grid);
			Assert.IsTrue(ar == 6);
		}

		[TestMethod]
		public void Test2()
		{
			var grid = new int[4][]
				{
					new int[5]{1,0,1,0,0},
					new int[5]{1,0,1,1,1},
					new int[5]{1,1,1,1,1},
					new int[5]{1,0,0,1,0},
				};

			var ar = (new MaximumRectangle()).Area(grid);
			Assert.IsTrue(ar == 6);
		}

		[TestMethod]
		public void Test3()
		{
			var grid = new int[0][];

			var ar = (new MaximumRectangle()).Area(grid);
			Assert.IsTrue(ar == 0);
		}

		[TestMethod]
		public void Test4()
		{
			var grid = new int[1][] {
				new int[1]{0}
			};

			var ar = (new MaximumRectangle()).Area(grid);
			Assert.IsTrue(ar == 0);
		}

		[TestMethod]
		public void Test5()
		{
			var grid = new int[1][] {
				new int[1]{1}
			};

			var ar = (new MaximumRectangle()).Area(grid);
			Assert.IsTrue(ar == 1);
		}

		[TestMethod]
		public void Test6()
		{
			var grid = new int[1][] {
				new int[2]{0,0}
			};

			var ar = (new MaximumRectangle()).Area(grid);
			Assert.IsTrue(ar == 0);
		}
	}
}
