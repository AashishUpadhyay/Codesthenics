using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class FindNumberAmazonGoStoresTests
    {
        [TestMethod]
        public void Test1()
        {
            var grid = new int[,] {
                { 1, 1, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 1, 1 },
                { 0, 0, 0, 0 }
            };
            var received = new FindNumberAmazonGoStores().NumberAmazonGoStores(4, 4, grid);
            Assert.IsTrue(received == 2);
        }

        [TestMethod]
        public void Test2()
        {
            var grid = new int[,] {
                { 1, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 1 },

            };
            var received = new FindNumberAmazonGoStores().NumberAmazonGoStores(7, 7, grid);
            Assert.IsTrue(received == 7);
        }

        [TestMethod]
        public void Test3()
        {
            var grid = new int[,] {
                { 1, 0, 1, 1 },
                { 1, 0, 1, 0 },
                { 0, 0, 0, 0 },
                { 1, 0, 1, 1 },
                { 1, 1, 1, 1 }
            };
            var received = new FindNumberAmazonGoStores().NumberAmazonGoStores(5, 4, grid);
            Assert.IsTrue(received == 3);
        }

        [TestMethod]
        public void Test4()
        {
            var grid = new int[,] {
                { 0, 1, 1, 1, 0 },
                { 0, 1, 1, 0, 0 },
                { 0, 0, 0, 1, 0 },
                { 1, 0, 1, 1, 0 },
                { 1, 1, 0, 0, 0 },
            };
            var received = new FindNumberAmazonGoStores().NumberAmazonGoStores(5, 5, grid);
            Assert.IsTrue(received == 2);
        }
    }
}
