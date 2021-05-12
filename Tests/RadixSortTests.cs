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
	public class RadixSortTests
	{
		[TestMethod]
		public void Test1()
		{
			var rs = new RadixSort();
			var ret = rs.Sort(new int[9] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
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
			var rs = new RadixSort();
			var ret = rs.Sort(new int[7] { 98, 20, 12, 66, 13, 22, 19 });
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
			var rs = new RadixSort();
			var ret = rs.Sort(new int[17] { 98, 20, 12, 66, 13, 22, 19, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 });
			var prev = 0;
			foreach (var item in ret)
			{
				Assert.IsTrue(item >= prev);
				prev = item;
			}
		}
	}
}
