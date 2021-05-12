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
	public class MaxesAndNumsTests
	{
		[TestMethod]
		public void Test1()
		{
			var mn = new MaxesAndNums();
			var result = mn.Find(new List<int>() { 1, 2, 4, 4 }, new List<int>() { 3, 5 });
			Assert.IsTrue(result[0] == 2);
			Assert.IsTrue(result[1] == 4);
		}

		[TestMethod]
		public void Test2()
		{
			var mn = new MaxesAndNums();
			var result = mn.Find(new List<int>() { 1, 2, 4, 4, 8, 4, 3, 6, 8, 4, 1, 5, 6, 3, 3, 7, 8 }, new List<int>() { 3, 5, 9, 1 });
			Assert.IsTrue(result[0] == 6);
			Assert.IsTrue(result[1] == 11);
			Assert.IsTrue(result[2] == 17);
			Assert.IsTrue(result[3] == 2);
		}
	}
}
