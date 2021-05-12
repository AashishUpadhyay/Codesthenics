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
	public class CountingSortTests
	{
		[TestMethod]
		public void Test1()
		{
			var cs = new CountingSort();
			var ret = cs.Sort(new int[9] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 1);
			var prev = 0;
			foreach (var item in ret)
			{
				Assert.IsTrue(item >= prev);
				prev = item;
			}
		}

		[TestMethod]
		public void Test2()
		{
			var cs = new CountingSort();
			var ret = cs.Sort(new int[5] { 8, 4, 7, 9, 2 }, 1);
			var prev = 0;
			foreach (var item in ret)
			{
				Assert.IsTrue(item >= prev);
				prev = item;
			}
		}

		[TestMethod]
		public void Test3()
		{
			var cs = new CountingSort();
			var ret = cs.Sort(new int[3] { 32, 22, 12 }, 2);
			var prev = 0;
			foreach (var item in ret)
			{
				Assert.IsTrue(item >= prev);
				prev = item;
			}
		}

		[TestMethod]
		public void Test4()
		{
			var cs = new CountingSort();
			var ret = cs.Sort(new int[4] { 32, 2, 22, 12 }, 2);
			var prev = 0;
			foreach (var item in ret)
			{
				Assert.IsTrue(item >= prev);
				prev = item;
			}
		}
	}
}
