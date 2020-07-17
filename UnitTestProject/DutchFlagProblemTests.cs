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
	public class DutchFlagProblemTests
	{
		[TestMethod]
		public void Test1()
		{
			var dfp = new DutchFlagProblem();
			dfp.SortColors(new int[6] { 2, 0, 2, 1, 1, 0 });
		}
	}
}
