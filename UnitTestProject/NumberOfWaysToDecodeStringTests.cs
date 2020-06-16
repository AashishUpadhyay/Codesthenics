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
	public class NumberOfWaysToDecodeStringTests
	{
		[TestMethod]
		public void Test1()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("111");
			Assert.IsTrue(ways.Count == 3);
		}

		[TestMethod]
		public void Test2()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("11111");
			Assert.IsTrue(ways.Count == 8);
		}

		[TestMethod]
		public void Test3()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("133");
			Assert.IsTrue(ways.Count == 2);
		}

		[TestMethod]
		public void Test4()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("3133");
			Assert.IsTrue(ways.Count == 2);
		}


		[TestMethod]
		public void Test5()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("1133");
			Assert.IsTrue(ways.Count == 3);
		}
	}
}
