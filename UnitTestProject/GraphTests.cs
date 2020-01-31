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
    public class GraphTests
    {
        [TestMethod]
        public void GraphTestDFS()
        {
            var graph = new GraphAJ<int>(
                new List<int>() { 1, 2, 3, 5 },
                new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,2),
                    new Tuple<int, int>(2,5),
                    new Tuple<int, int>(2,3),
                    new Tuple<int, int>(3,5),
                    new Tuple<int, int>(5,1)
                });

            var visited = graph.DFS(2);
            var expected = new HashSet<int>() { 1, 2, 3, 5 };

            foreach (var item in expected)
            {
                Assert.IsTrue(visited.Contains(item));
            }
        }

        [TestMethod]
        public void DisconnectedGraphTestDFS()
        {
            var graph = new GraphAJ<int>(
                new List<int>() { 1, 2, 3, 4, 5 },
                new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,2),
                    new Tuple<int, int>(1,3),
                    new Tuple<int, int>(1,4),
                    new Tuple<int, int>(4,5),
                    new Tuple<int, int>(5,3)
                });

            var visited = graph.DFS(1);
            var expected = new HashSet<int>() { 1, 2, 3, 4, 5 };

            foreach (var item in expected)
            {
                Assert.IsTrue(visited.Contains(item));
            }

            visited = graph.DFS(5);
            expected = new HashSet<int>() { 3, 5 };

            foreach (var item in expected)
            {
                Assert.IsTrue(visited.Contains(item));
            }
        }

        [TestMethod]
        public void GraphTestBFS()
        {
            var graph = new GraphAJ<int>(
                new List<int>() { 1, 2, 3, 5 },
                new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,2),
                    new Tuple<int, int>(2,5),
                    new Tuple<int, int>(2,3),
                    new Tuple<int, int>(3,5),
                    new Tuple<int, int>(5,1)
                });

            var visited = graph.BFS(2);
            var expected = new HashSet<int>() { 1, 2, 3, 5 };

            foreach (var item in expected)
            {
                Assert.IsTrue(visited.Contains(item));
            }
        }

        [TestMethod]
        public void DisconnectedGraphTestBFS()
        {
            var graph = new GraphAJ<int>(
                new List<int>() { 1, 2, 3, 4, 5 },
                new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,2),
                    new Tuple<int, int>(1,3),
                    new Tuple<int, int>(1,4),
                    new Tuple<int, int>(4,5),
                    new Tuple<int, int>(5,3)
                });

            var visited = graph.BFS(1);
            var expected = new HashSet<int>() { 1, 2, 3, 4, 5 };

            foreach (var item in expected)
            {
                Assert.IsTrue(visited.Contains(item));
            }

            visited = graph.BFS(5);
            expected = new HashSet<int>() { 3, 5 };

            foreach (var item in expected)
            {
                Assert.IsTrue(visited.Contains(item));
            }
        }

        [TestMethod]
        public void GraphCheckIfCycleExistsTests()
        {
            var graph = new GraphAJ<int>(
                new List<int>() { 1, 2, 3, 4, 5 },
                new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,2),
                    new Tuple<int, int>(2,1),
                    new Tuple<int, int>(1,3),
                    new Tuple<int, int>(3,1),
                    new Tuple<int, int>(3,4),
                    new Tuple<int, int>(4,5),
                    new Tuple<int, int>(5,4),
                    new Tuple<int, int>(5,1),
                    new Tuple<int, int>(1,5)
                });

            bool cycleExists = (new GraphCheckIfCycleExists<int>()).CycleExists(graph);

            Assert.IsTrue(cycleExists);
        }

        [TestMethod]
        public void GraphCheckIfCycleExistsTestsNegative()
        {
            var graph = new GraphAJ<int>(
                new List<int>() { 1, 2, 3, 4, 5, 6 },
                new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,2),
                    new Tuple<int, int>(1,6),
                    new Tuple<int, int>(2,1),
                    new Tuple<int, int>(2,3),
                    new Tuple<int, int>(3,4),
                    new Tuple<int, int>(4,3),
                    new Tuple<int, int>(3,5),
                    new Tuple<int, int>(5,3)
                });

            bool cycleExists = (new GraphCheckIfCycleExists<int>()).CycleExists(graph);

            Assert.IsFalse(cycleExists);
        }

        [TestMethod]
        public void GraphAMDFS()
        {
            var graph = new GraphAM<int>(
                new int[,] {
                {0,0,0},
                {0,0,0},
                {0,0,0}
            }, 3, 3);

            var result = graph.DFS();
            var expected = new HashSet<GraphCellCoordinates>()
            {
                new GraphCellCoordinates(0,0),
                new GraphCellCoordinates(0,1),
                new GraphCellCoordinates(0,2),
                new GraphCellCoordinates(1,0),
                new GraphCellCoordinates(1,1),
                new GraphCellCoordinates(1,2),
                new GraphCellCoordinates(2,0),
                new GraphCellCoordinates(2,1),
                new GraphCellCoordinates(2,2)
            };

            foreach (var item in expected)
            {
                Assert.IsTrue(result.Contains(item));
            }
        }

        [TestMethod]
        public void GraphAMBFS()
        {
            var graph = new GraphAM<int>(
                new int[,] {
                {0,0,0},
                {0,0,0},
                {0,0,0}
            }, 3, 3);

            var result = graph.BFS();
            var expected = new HashSet<GraphCellCoordinates>()
            {
                new GraphCellCoordinates(0,0),
                new GraphCellCoordinates(0,1),
                new GraphCellCoordinates(0,2),
                new GraphCellCoordinates(1,0),
                new GraphCellCoordinates(1,1),
                new GraphCellCoordinates(1,2),
                new GraphCellCoordinates(2,0),
                new GraphCellCoordinates(2,1),
                new GraphCellCoordinates(2,2)
            };

            foreach (var item in expected)
            {
                Assert.IsTrue(result.Contains(item));
            }
        }
    }
}
