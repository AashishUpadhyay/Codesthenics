using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class FindMostSimilarWebsitesTests
    {
        [TestMethod]
        public void Test()
        {
            var findMostSimilarWebsites = new FindMostSimilarWebsites();

            var input = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("google.com", 1),
                new Tuple<string, int>("google.com", 3),
                new Tuple<string, int>("google.com", 5),
                new Tuple<string, int>("pets.com", 1),
                new Tuple<string, int>("pets.com", 2),
                new Tuple<string, int>("yahoo.com", 6),
                new Tuple<string, int>("yahoo.com", 2),
                new Tuple<string, int>("yahoo.com", 3),
                new Tuple<string, int>("yahoo.com", 4),
                new Tuple<string, int>("yahoo.com", 5),
                new Tuple<string, int>("wikipedia.org", 4),
                new Tuple<string, int>("wikipedia.org", 5),
                new Tuple<string, int>("wikipedia.org", 6),
                new Tuple<string, int>("wikipedia.org", 7),
                new Tuple<string, int>("bing.com", 1),
                new Tuple<string, int>("bing.com", 3),
                new Tuple<string, int>("bing.com", 5),
                new Tuple<string, int>("bing.com", 6),
            };

            var returnedValue = findMostSimilarWebsites.Find(input, 1);
            Assert.IsTrue(returnedValue[0].Item1 == "google.com" && returnedValue[0].Item2 == "bing.com");
        }

        [TestMethod]
        public void Test1()
        {
            var findMostSimilarWebsites = new FindMostSimilarWebsites();

            var input = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("google.com", 1),
                new Tuple<string, int>("google.com", 3),
                new Tuple<string, int>("google.com", 5),
                new Tuple<string, int>("pets.com", 1),
                new Tuple<string, int>("pets.com", 2),
                new Tuple<string, int>("yahoo.com", 6),
                new Tuple<string, int>("yahoo.com", 2),
                new Tuple<string, int>("yahoo.com", 3),
                new Tuple<string, int>("yahoo.com", 4),
                new Tuple<string, int>("yahoo.com", 5),
                new Tuple<string, int>("wikipedia.org", 4),
                new Tuple<string, int>("wikipedia.org", 5),
                new Tuple<string, int>("wikipedia.org", 6),
                new Tuple<string, int>("wikipedia.org", 7),
                new Tuple<string, int>("bing.com", 1),
                new Tuple<string, int>("bing.com", 3),
                new Tuple<string, int>("bing.com", 5),
                new Tuple<string, int>("bing.com", 6),
            };

            var returnedValue = findMostSimilarWebsites.Find(input, 2);
            Assert.IsTrue(returnedValue[0].Item1 == "google.com" && returnedValue[0].Item2 == "bing.com");
            Assert.IsTrue(returnedValue[1].Item1 == "google.com" && returnedValue[1].Item2 == "yahoo.com");
            Assert.IsTrue(returnedValue[2].Item1 == "wikipedia.org" && returnedValue[2].Item2 == "bing.com");
        }
    }
}
