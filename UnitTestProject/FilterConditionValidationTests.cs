using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace UnitTestProject
{
	[TestClass]
	public class FilterConditionValidationTests
	{
		[TestMethod]
		public void Test1()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("11 AND 2"));
			Assert.IsTrue(fcv.Evaluate("11 AND 2") == 22);
		}

		[TestMethod]
		public void Test2()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("1 AND 2 AND 3 AND 7"));
			Assert.IsTrue(fcv.Evaluate("1 AND 2 AND 3 AND 7") == 42);
		}

		[TestMethod]
		public void Test3()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("1 AND (2 OR 3) AND 8"));
			Assert.IsTrue(fcv.Evaluate("1 AND (2 OR 3) AND 8") == 40);

		}

		[TestMethod]
		public void Test4()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("1 AND (2 OR 3) OR (8 NOT 9)"));
			Assert.IsTrue(fcv.Evaluate("1 AND (2 OR 3) OR (8 NOT 9)") == 4);
		}

		[TestMethod]
		public void Test5()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsFalse(fcv.IsValid("(1 OR 2) AND (3 NOT 4) AND 5 (1 OR 2) AND (3 NOT 4) AND 5"));
			Assert.IsTrue(fcv.Evaluate("(1 OR 2) AND (3 NOT 4) AND 5 (1 OR 2) AND (3 NOT 4) AND 5") == -1);
		}

		[TestMethod]
		public void Test6()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsFalse(fcv.IsValid("1 AND 1(23 AND 4)"));
		}

		[TestMethod]
		public void Test7()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("(1 OR 2) AND (3 AND 5)"));
		}

		[TestMethod]
		public void Test8()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("1 AND 2 AND 3 NOT 4"));
		}

		[TestMethod]
		public void Test9()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("1 OR 3 AND 8 OR (6 NOT 7)"));
		}

		[TestMethod]
		public void Test10()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsFalse(fcv.IsValid("2 AND (7 OR 8"));
		}

		[TestMethod]
		public void Test11()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsFalse(fcv.IsValid("1 AND"));
		}

		[TestMethod]
		public void Test12()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsFalse(fcv.IsValid("(1 OR 2) AND (3 NOT 4 AND"));
		}

		[TestMethod]
		public void Test13()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("(1 OR 2) AND (3 NOT 4) AND 5 AND (1 OR 2) AND (3 NOT 4) AND 5"));
			Assert.IsTrue(fcv.Evaluate("(1 OR 2) AND (3 NOT 4) AND 5 AND (1 OR 2) AND (3 NOT 4) AND 5") == 225);
		}

		[TestMethod]
		public void Test14()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("(1 OR 2) AND ((3 NOT 4) AND (1 OR 2)) AND 5 AND (1 OR 2) AND (3 NOT 4) AND 5"));
		}

		[TestMethod]
		public void Test15()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("((1 OR 2))"));
		}

		[TestMethod]
		public void Test16()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("((3 NOT 4) AND (1 OR 2))"));
		}

		[TestMethod]
		public void Test17()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("(1 OR 2) AND ((3 NOT 4) AND (((1 OR 2)))) AND 5 AND (1 OR 2) AND (3 NOT 4) AND 5"));
			Assert.IsTrue(fcv.Evaluate("(1 OR 2) AND ((3 NOT 4) AND (((1 OR 2)))) AND 5 AND (1 OR 2) AND (3 NOT 4) AND 5") == 675);
		}

		[TestMethod]
		public void Test18()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("(5 AND 4 AND 6)"));
			Assert.IsTrue(fcv.Evaluate("((5 AND 4 AND 6))") == 120);
		}

		[TestMethod]
		public void Test19()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("((5 AND 4 AND 6 AND (((1 OR 2) AND ((3 NOT 4) AND (((1 OR 2)))) AND 5 AND (1 OR 2) AND (3 NOT 4) AND 5))))"));
		}

		[TestMethod]
		public void Test20()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("((5 AND 4 AND 6 AND (((1 OR 2) AND ((3 NOT 4) AND (((1 OR 2))) AND 2) AND 5 AND (1 OR 2) AND (3 NOT 4) AND 5))))"));
		}

		[TestMethod]
		public void Test21()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsFalse(fcv.IsValid("((5 AND 4 AND 6 AND (((1 OR 2) AND ((3 NOT 4) MOCK (((1 OR 2))) AND 2) AND 5 AND (1 OR 2) AND (3 NOT 4) AND 5))))"));
		}

		[TestMethod]
		public void Test22()
		{
			var fcv = new FilterConditionValidation();
			Assert.IsTrue(fcv.IsValid("5 AND 4 NOT 3"));
			Assert.IsTrue(fcv.Evaluate("5 AND 4 NOT 3") == 17);
		}
	}
}
