using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;
using System.Collections.Generic;

namespace UnitTestProject
{
	[TestClass]
	public class StepsToOneTests
	{
		[TestMethod]
		public void Test1()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.AddOne("100");
			Assert.IsTrue(result == "101");
			result = stepsToOne.AddOne("99");
			Assert.IsTrue(result == "100");
			result = stepsToOne.AddOne("134");
			Assert.IsTrue(result == "135");
			result = stepsToOne.AddOne("46");
			Assert.IsTrue(result == "47");
			result = stepsToOne.AddOne("0");
			Assert.IsTrue(result == "1");

			result = stepsToOne.MinusOne("100");
			Assert.IsTrue(result == "99");
			result = stepsToOne.MinusOne("99");
			Assert.IsTrue(result == "98");
			result = stepsToOne.MinusOne("134");
			Assert.IsTrue(result == "133");
			result = stepsToOne.MinusOne("46");
			Assert.IsTrue(result == "45");
			result = stepsToOne.MinusOne("1");
			Assert.IsTrue(result == "0");

			result = stepsToOne.Divide("100", 2)[0];
			Assert.IsTrue(result == "50");
			result = stepsToOne.Divide("134", 2)[0];
			Assert.IsTrue(result == "67");
			result = stepsToOne.Divide("200", 2)[0];
			Assert.IsTrue(result == "100");
			result = stepsToOne.Divide("2", 2)[0];
			Assert.IsTrue(result == "1");

			result = stepsToOne.AddOne("999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999");
			Assert.IsTrue(result == "INVALID");

			result = stepsToOne.Divide("999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999998", 2)[0];

			var result1 = stepsToOne.Divide("597", 4);
			Assert.IsTrue(result1[0] == "149");
			Assert.IsTrue(result1[1] == "1");

			result1 = stepsToOne.Divide("81", 4);
			Assert.IsTrue(result1[0] == "20");
			Assert.IsTrue(result1[1] == "1");
		}

		[TestMethod]
		public void Test2()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("15");
			Assert.IsTrue(result == 5);
		}

		[TestMethod]
		public void Test3()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("10");
			Assert.IsTrue(result == 4);
		}

		[TestMethod]
		public void Test4()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("100");
			Assert.IsTrue(result == 8);
		}

		[TestMethod]
		public void Test5()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("1000");
			Assert.IsTrue(result == 12);
		}

		[TestMethod]
		public void Test6()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("10000");
			Assert.IsTrue(result == 16);
		}

		[TestMethod]
		public void Test9()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("10000000");
			Assert.IsTrue(result == 30);
		}

		[TestMethod]
		public void Test10()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999");
			Assert.IsTrue(result == 1279);
		}

		[TestMethod]
		public void Test11()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999");
			Assert.IsTrue(result == 1114);
		}

		[TestMethod]
		public void Test13()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("2441");
			Assert.IsTrue(result == 15);
		}

		[TestMethod]
		public void Test14()
		{
			var stepsToOne = new StepsToOne();
			var result = stepsToOne.Calculate("1000000000000000000000000");
			Assert.IsTrue(result == 98);
		}

		[TestMethod]
		public void Test15()
		{
			var stepsToOne = new StepsToOne();
			for (int i = 1; i < 1000000; i++)
			{
				Assert.IsTrue((i - 1).ToString() == (stepsToOne.MinusOne(i.ToString())));
			}
		}

		[TestMethod]
		public void Test16()
		{
			var stepsToOne = new StepsToOne();
			for (int i = 1; i < 1000000; i++)
			{
				Assert.IsTrue((i + 1).ToString() == (stepsToOne.AddOne(i.ToString())));
			}
		}

		[TestMethod]
		public void Test17()
		{
			var stepsToOne = new StepsToOne();
			for (int i = 1; i < 1000000; i++)
			{
				var res = stepsToOne.Divide(i.ToString(), 4);
				Assert.IsTrue((i / 4).ToString() == res[0]);
				Assert.IsTrue((i % 4).ToString() == res[1]);
			}
		}

		[TestMethod]
		public void Test18()
		{
			var stepsToOne = new StepsToOne();
			for (int i = 1; i < 1000000; i++)
			{
				var val = stepsToOne.Calculate(i.ToString());
				var val1 = stepsToOne.CalculateUsingInt(i);
				Assert.IsTrue(val == val1);
			}
		}

		[TestMethod]
		public void Test19()
		{
			var stepsToOne = new StepsToOne();
			var val = stepsToOne.Calculate("23");
			Assert.IsTrue(val == 6);
		}
	}
}
