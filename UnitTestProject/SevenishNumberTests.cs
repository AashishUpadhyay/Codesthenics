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
	public class SevenishNumberTests
	{
		[TestMethod]
		public void Test1()
		{
			var sn = new SevenishNumber();
			Assert.IsTrue(sn.FindNthSevenishNumber(1) == 1);
			Assert.IsTrue(sn.FindNthSevenishNumber(2) == 7);
			Assert.IsTrue(sn.FindNthSevenishNumber(3) == 8);
			Assert.IsTrue(sn.FindNthSevenishNumber(4) == 49);
			Assert.IsTrue(sn.FindNthSevenishNumber(5) == 50);
			Assert.IsTrue(sn.FindNthSevenishNumber(6) == 56);
			Assert.IsTrue(sn.FindNthSevenishNumber(7) == 343);
			Assert.IsTrue(sn.FindNthSevenishNumber(8) == 344);
			Assert.IsTrue(sn.FindNthSevenishNumber(9) == 350);
			Assert.IsTrue(sn.FindNthSevenishNumber(10) == 392);
		}
	}
}
