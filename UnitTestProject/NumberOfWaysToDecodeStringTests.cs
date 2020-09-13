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
			var w = nwtds.Count("111");
			Assert.IsTrue(ways.Count == w);
		}

		[TestMethod]
		public void Test2()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("11111");
			var w = nwtds.Count("11111");
			Assert.IsTrue(ways.Count == w);
		}

		[TestMethod]
		public void Test3()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("133");
			var w = nwtds.Count("133");
			Assert.IsTrue(ways.Count == w);
		}

		[TestMethod]
		public void Test4()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("3133");
			var w = nwtds.Count("3133");
			Assert.IsTrue(ways.Count == w);
		}

		[TestMethod]
		public void Test5()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("1133");
			var w = nwtds.Count("1133");
			Assert.IsTrue(ways.Count == w);
		}

		[TestMethod]
		public void Test6()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("993");
			var w = nwtds.Count("993");
			Assert.IsTrue(ways.Count == w);
		}

		[TestMethod]
		public void Test7()
		{
			var nwtds = new NumberOfWaysToDecodeString();
			var ways = nwtds.NumberOfWays("141131331111111339936341111114116343133111133111");
			var w = nwtds.Count("141131331111111339936341111114116343133111133111");
			Assert.IsTrue(ways.Count == w);
		}
	}
}
