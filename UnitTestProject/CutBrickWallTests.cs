using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codesthenics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class CutBrickWallTests
    {
        [TestMethod]
        public void Test1()
        {
            var input = new int[][]
            {
              new[] {3,5,1,1},
              new[] {2,3,3,2},
              new[] {5,5},
              new[] {4,4,2},
              new[] {1,3,3,3},
              new[] {1,1,6,1,1},
            };

            var returnedValue = CutBrickWall.FindMinimumCuts(input);

            Assert.IsTrue(2==returnedValue);
        }

        [TestMethod]
        public void Test2()
        {
            var input = new int[][]
            {
                new[] {3,5,1,1},
                new[] {2,3,3,2},
                new[] {5,3,1},
                new[] {4,4,2},
                new[] {1,3,3,3},
                new[] {1,1,6,1,1},
            };

            var returnedValue = CutBrickWall.FindMinimumCuts(input);

            Assert.IsTrue(1 == returnedValue);
        }

        [TestMethod]
        public void Test3()
        {
            var input = new int[][]
            {
                new[] {3,5,1,1},
                new[] {2,3,3,2},
                new[] {5,3,1},
                new[] {4,4,2},
                new[] {1,3,3,3},
                new[] {1,1,6,1,1},
                new[] {2,2,4,1,1}
            };

            var returnedValue = CutBrickWall.FindMinimumCuts(input);

            Assert.IsTrue(1 == returnedValue);
        }
    }
}
