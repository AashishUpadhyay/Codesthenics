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
	public class EvaluateReversePolishNotationTests
	{
		[TestMethod]
		public void Test1()
		{
			var erpn = new EvaluateReversePolishNotation();
			var val = erpn.EvalRPN(new string[5] { "2", "1", "+", "3", "*" });
			Assert.IsTrue(val == 9);
		}

		[TestMethod]
		public void Test2()
		{
			var erpn = new EvaluateReversePolishNotation();
			var val = erpn.EvalRPN(new string[5] { "4", "13", "5", "/", "+" });
			Assert.IsTrue(val == 6);
		}

		[TestMethod]
		public void Test3()
		{
			var erpn = new EvaluateReversePolishNotation();
			var val = erpn.EvalRPN(new string[13] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" });
			Assert.IsTrue(val == 22);
		}
	}
}
