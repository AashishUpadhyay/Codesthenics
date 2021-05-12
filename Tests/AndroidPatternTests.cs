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
	public class AndroidPatternTests
	{
		[TestMethod]
		public void Test1()
		{
			var ap = new AndroidPattern();
			var count = ap.NumberOfPatterns(2, 2);
			Assert.IsTrue(count == 56);
		}

		[TestMethod]
		public void Test2()
		{
			var ap = new AndroidPattern();
			var count = ap.NumberOfPatterns(1, 1);
			Assert.IsTrue(count == 9);
		}

		[TestMethod]
		public void Test3()
		{
			var ap = new AndroidPattern();
			var count = ap.NumberOfPatterns(3, 3);
			Assert.IsTrue(count == 320);
		}

		[TestMethod]
		public void Test4()
		{
			var ap = new AndroidPattern();
			var count = ap.NumberOfPatterns(4, 6);
			Assert.IsTrue(count == 34792);
		}
	}
}
