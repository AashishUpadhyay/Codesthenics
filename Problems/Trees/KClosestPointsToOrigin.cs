using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace Problems
{
    public class KClosestPointsToOrigin<T>
    {
        private IDistanceCalculator _distanceCalculator;
        private IPointsService _pointsService;
        private Point _origin;

        public KClosestPointsToOrigin(IDistanceCalculator distanceCalculator, IPointsService pointsService, Point origin)
        {
            _distanceCalculator = distanceCalculator;
            _pointsService = pointsService;
            _origin = origin;
        }

        public IList<Point> FindKClosestPointsToOrigin(int k)
        {
            var result = new List<Point>();
            var tree = new SortedDictionary<double, IList<Point>>();

            var cnter = 0;
            foreach(var point in _pointsService.GetPoint())
            {
                double dist = -1 * _distanceCalculator.Calculate(point, _origin);
                if (cnter < k)
                {
                    if (!tree.ContainsKey(dist))
                        tree[dist] = new List<Point>();

                    tree[dist].Add(point);
                }
                else
                {
                    var maxdist = tree.First().Key;
                    if (dist >= maxdist)
                    {
                        tree[maxdist].RemoveAt(tree[maxdist].Count - 1);

                        if (!tree.ContainsKey(dist))
                            tree[dist] = new List<Point>();

                        tree[dist].Add(point);

                        if (tree[maxdist].Count == 0)
                            tree.Remove(maxdist);
                    }
                }
                cnter += 1;
            }

            return tree.Values.SelectMany(v => v).ToList();
        }
    }

    public class Point
    {
        private double _x;
        private double _y;
        private double _z;

        public Point(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }

        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }
        public double Z { get { return _z; } set { _z = value; } }

        public string PointKey => $"x={_x}y={_y}z={_z}";
    }

    public interface IDistanceCalculator
    {
        double Calculate(Point p1, Point p2);
    }

    public interface IPointsService
    {
        IEnumerable<Point> GetPoint();
    }

    public class DistanceCalculator : IDistanceCalculator
    {
        public double Calculate(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        }
    }

    public class PointsService : IPointsService
    {
        private IList<Point> _list;
        public PointsService(IList<Point> list)
        {
            _list = list;
        }

        public IEnumerable<Point> GetPoint()
        {
            foreach (var item in _list)
                yield return item;
        }
    }
}
