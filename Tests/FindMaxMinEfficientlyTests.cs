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
	public class FindMaxMinEfficientlyTests
	{
		[TestMethod]
		public void Test1()
		{
			var fmmet = new FindMaxMinEfficiently();
			int[] returnedValue = fmmet.Find(new int[] { 10, 2, 3, 15, 16, 8, 9, 12, 20, 6, 14 });
			Assert.IsTrue(returnedValue[0] == 2 && returnedValue[1] == 20);
		}

		[TestMethod]
		public void Test2()
		{
			var fmmet = new FindMaxMinEfficiently();
			int[] returnedValue = fmmet.Find(new int[] { 6, 12, 32, 115, 216, 8, 19, 122, 120, 6, 14 });
			Assert.IsTrue(returnedValue[0] == 6 && returnedValue[1] == 216);
		}

		[TestMethod]
		public void Test3()
		{
			var fmmet = new FindMaxMinEfficiently();
			int[] returnedValue = fmmet.Find(new int[] { 1, 2, 3,4, 6, -1, 19, 2, 11, 61, -14 });
			Assert.IsTrue(returnedValue[0] == -14 && returnedValue[1] == 61);
		}
	}
}
