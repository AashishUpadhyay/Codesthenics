using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
	[TestClass]
	public class RearrangeStringTests
	{
		[TestMethod]
		public void Test1()
		{
			var rs = new RearrangeString();
			var retVal = rs.ReorganizeString("aab");
			Assert.IsTrue(retVal == "aba");
		}

		[TestMethod]
		public void Test2()
		{
			var rs = new RearrangeString();
			var retVal = rs.ReorganizeString("aabb");
			Assert.IsTrue(retVal == "abab");
		}

		[TestMethod]
		public void Test3()
		{
			var rs = new RearrangeString();
			var retVal = rs.ReorganizeString("vvvlo");
			Assert.IsTrue(retVal == "vlvov");
		}

		[TestMethod]
		public void Test4()
		{
			var rs = new RearrangeString();
			var retVal = rs.ReorganizeString("abcdefghijklmnopqrstuvwxyz");
			Assert.IsTrue(retVal != "");
		}

		[TestMethod]
		public void Test5()
		{
			var rs = new RearrangeString();
			var retVal = rs.ReorganizeString("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz");
			Assert.IsTrue(retVal != "");
		}

		[TestMethod]
		public void Test6()
		{
			var rs = new RearrangeString();
			var retVal = rs.ReorganizeString("aaab");
			Assert.IsTrue(retVal == "");
		}
	}
}
