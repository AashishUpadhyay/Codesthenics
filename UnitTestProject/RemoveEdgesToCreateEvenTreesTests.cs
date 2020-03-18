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
    public class RemoveEdgesToCreateEvenTreesTests
    {
        [TestMethod]
        public void RemoveEdgesToCreateEvenTreesTest1()
        {
            var graph = new GraphAJ<int>(
                new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 },
                new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,2),
                    new Tuple<int, int>(1,3),
                    new Tuple<int, int>(3,4),
                    new Tuple<int, int>(3,5),
                    new Tuple<int, int>(4,6),
                    new Tuple<int, int>(4,7),
                    new Tuple<int, int>(4,8)
                });

            var removeEdgesToCreateEvenTrees = new RemoveEdgesToCreateEvenTrees();
            var expected = removeEdgesToCreateEvenTrees.RemoveableEdges(graph, 1);

            Assert.IsTrue(expected.Count == 2);
        }
    }
}
