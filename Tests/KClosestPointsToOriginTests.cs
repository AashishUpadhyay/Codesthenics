using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems;

namespace Tests
{
	[TestClass]
	public class KClosestPointsToOriginTests
	{
		[TestMethod]
		public void Test1()
		{
			IList<Point> _list = new List<Point>()
			{
				new Point(10,10,10),
				new Point(9,9,9),
				new Point(8,8,8),
				new Point(7,7,7),
				new Point(6,6,6),
				new Point(5,5,5),
				new Point(4,4,4),
				new Point(3,3,3),
				new Point(2,2,2),
				new Point(1,1,1)
			};

			Point _origin = new Point(0, 0, 0);
			KClosestPointsToOrigin<double> kclosestPointsToOrigin = new KClosestPointsToOrigin<double>(new DistanceCalculator(), new PointsService(_list), _origin);
			var received = kclosestPointsToOrigin.FindKClosestPointsToOrigin(3);
			var receivedMap = received.Select(u=>u.PointKey).ToHashSet();

			Assert.IsTrue(receivedMap.Count() == 3);
			Assert.IsTrue(receivedMap.Contains((new Point(1, 1, 1)).PointKey));
			Assert.IsTrue(receivedMap.Contains((new Point(2, 2, 2)).PointKey));
			Assert.IsTrue(receivedMap.Contains((new Point(3, 3, 3)).PointKey));
		}

		[TestMethod]
		public void Test2()
		{
			IList<Point> _list = new List<Point>()
			{
				new Point(10,10,10),
				new Point(9,9,9),
				new Point(8,8,8),
				new Point(7,7,7),
				new Point(6,6,6),
				new Point(5,5,5),
				new Point(4,4,4),
				new Point(3,3,3),
				new Point(2,2,2),
				new Point(1,1,1),
				new Point(1,1,1)
			};

			Point _origin = new Point(0, 0, 0);
			KClosestPointsToOrigin<double> kclosestPointsToOrigin = new KClosestPointsToOrigin<double>(new DistanceCalculator(), new PointsService(_list), _origin);
			var received = kclosestPointsToOrigin.FindKClosestPointsToOrigin(3);
			var receivedMap = received.Select(u => u.PointKey).ToHashSet();

			Assert.IsTrue(receivedMap.Count() == 2);
			Assert.IsTrue(receivedMap.Contains((new Point(1, 1, 1)).PointKey));
			Assert.IsTrue(receivedMap.Contains((new Point(2, 2, 2)).PointKey));
			Assert.IsTrue(!receivedMap.Contains((new Point(3, 3, 3)).PointKey));
		}

		[TestMethod]
		public void Test3()
		{
			IList<Point> _list = new List<Point>()
			{
				new Point(10,10,10),
				new Point(9,9,9),
				new Point(8,8,8),
				new Point(7,7,7),
				new Point(6,6,6),
				new Point(5,5,5),
				new Point(4,4,4),
				new Point(3,3,3),
				new Point(2,2,2),
				new Point(2,2,2),
				new Point(1,1,1),
				new Point(1,1,1)
			};

			Point _origin = new Point(0, 0, 0);
			KClosestPointsToOrigin<double> kclosestPointsToOrigin = new KClosestPointsToOrigin<double>(new DistanceCalculator(), new PointsService(_list), _origin);
			var received = kclosestPointsToOrigin.FindKClosestPointsToOrigin(3);
			var receivedMap = received.Select(u => u.PointKey).ToHashSet();

			Assert.IsTrue(receivedMap.Count() == 2);
			Assert.IsTrue(receivedMap.Contains((new Point(1, 1, 1)).PointKey));
			Assert.IsTrue(receivedMap.Contains((new Point(2, 2, 2)).PointKey));
			Assert.IsTrue(!receivedMap.Contains((new Point(3, 3, 3)).PointKey));
		}

		[TestMethod]
		public void Test4()
		{
			IList<Point> _list = new List<Point>()
			{
				new Point(10,10,10),
				new Point(9,9,9),
				new Point(8,8,8),
				new Point(7,7,7),
				new Point(6,6,6),
				new Point(5,5,5),
				new Point(4,4,4),
				new Point(3,3,3),
				new Point(2,2,2),
				new Point(2,2,2),
				new Point(1,1,1),
				new Point(1,1,1)
			};

			Point _origin = new Point(0, 0, 0);
			KClosestPointsToOrigin<double> kclosestPointsToOrigin = new KClosestPointsToOrigin<double>(new DistanceCalculator(), new PointsService(_list), _origin);
			var received = kclosestPointsToOrigin.FindKClosestPointsToOrigin(4);
			var receivedMap = received.Select(u => u.PointKey).ToHashSet();

			Assert.IsTrue(receivedMap.Count() == 2);
			Assert.IsTrue(receivedMap.Contains((new Point(1, 1, 1)).PointKey));
			Assert.IsTrue(receivedMap.Contains((new Point(2, 2, 2)).PointKey));
			Assert.IsTrue(!receivedMap.Contains((new Point(3, 3, 3)).PointKey));
		}

		[TestMethod]
		public void Test5()
		{
			IList<Point> _list = new List<Point>()
			{
				new Point(10,10,10),
				new Point(9,9,9),
				new Point(8,8,8),
				new Point(7,7,7),
				new Point(6,6,6),
				new Point(5,5,5),
				new Point(4,4,4),
				new Point(3,3,3),
				new Point(2,2,2),
				new Point(2,2,2),
				new Point(1,1,1),
				new Point(1,1,1)
			};

			Point _origin = new Point(0, 0, 0);
			KClosestPointsToOrigin<double> kclosestPointsToOrigin = new KClosestPointsToOrigin<double>(new DistanceCalculator(), new PointsService(_list), _origin);
			var received = kclosestPointsToOrigin.FindKClosestPointsToOrigin(5);
			var receivedMap = received.Select(u => u.PointKey).ToHashSet();

			Assert.IsTrue(receivedMap.Count() == 3);
			Assert.IsTrue(receivedMap.Contains((new Point(1, 1, 1)).PointKey));
			Assert.IsTrue(receivedMap.Contains((new Point(2, 2, 2)).PointKey));
			Assert.IsTrue(receivedMap.Contains((new Point(3, 3, 3)).PointKey));
		}
	}
}
