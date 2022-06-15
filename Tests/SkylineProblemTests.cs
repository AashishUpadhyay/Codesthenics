using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
	[TestClass]
	public class SkylineProblemTestsTests
	{
		[TestMethod]
		public void Test1()
		{
			var skylineProblem = new SkylineProblem();
			var received = skylineProblem.GetSkyline(new int[2][] { new int[3] { 2,9,10}, new int[3] { 9, 12, 10 } });
			var expected = new List<IList<int>>() { new List<int>() {2,10}, new List<int>() { 12, 0 } };
			var received_set = received.Select(u => new Tuple<int, int>(u[0], u[1])).ToHashSet();
			var expected_set = expected.Select(u => new Tuple<int, int>(u[0], u[1])).ToHashSet();

			Assert.IsTrue(received_set.Except(expected_set).Count() == 0);
		}

		[TestMethod]
		public void Test2()
		{
			var skylineProblem = new SkylineProblem();
			var received = skylineProblem.GetSkyline(new int[5][] { new int[3] { 2, 9, 10 }, new int[3] { 3, 7, 15 }, new int[3] { 5, 12, 12 }, new int[3] { 15, 20, 10 }, new int[3] { 19, 24, 8 } });
			var expected = new List<IList<int>>() { new List<int>() { 2, 10 }, new List<int>() { 3, 15 }, new List<int>() { 7, 12 }, new List<int>() { 12, 0 }, new List<int>() { 15, 10 }, new List<int>() { 20, 8 }, new List<int>() { 24, 0 } };
			var received_set = received.Select(u => new Tuple<int, int>(u[0], u[1])).ToHashSet();
			var expected_set = expected.Select(u => new Tuple<int, int>(u[0], u[1])).ToHashSet();

			Assert.IsTrue(received_set.Except(expected_set).Count() == 0);
		}


		[TestMethod]
		public void Test3()
		{
			var skylineProblem = new SkylineProblem();
			var received = skylineProblem.GetSkyline(new int[2][] { new int[3] { 0, 2, 3 }, new int[3] { 2, 5, 3 }});
			var expected = new List<IList<int>>() { new List<int>() { 0, 3 }, new List<int>() { 5, 0 }};
			var received_set = received.Select(u => new Tuple<int, int>(u[0], u[1])).ToHashSet();
			var expected_set = expected.Select(u => new Tuple<int, int>(u[0], u[1])).ToHashSet();

			Assert.IsTrue(received_set.Except(expected_set).Count() == 0);
		}
	}
}
