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
	public class KnightProbabilityInChessboardTests
	{
		[TestMethod]
		public void Test1()
		{
			var kpic = new KnightProbabilityInChessboard();
			var rv = kpic.KnightProbability(4, 3, 0, 0);
			Assert.IsTrue(Math.Abs(rv - 0.03906) < 0.0001);
		}
	}
}
