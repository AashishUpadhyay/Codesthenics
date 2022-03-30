using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns;

namespace Tests
{
    public class Node
    {
        public Node(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    [TestClass]
    public class TestCache
    {
        public TestCache()
        {

        }

        [TestMethod]
        public void Test1()
        {
            var cache = new Cache(3);
            cache.Put("A", new Node(1, "A"));
            cache.Put("B", new Node(2, "B"));
            cache.Put("C", new Node(3, "C"));

            Assert.AreEqual(((Node)cache.Get("A")).Name, "A");
            cache.Put("D", new Node(4, "D"));
            Assert.AreEqual(cache.Get("B"), null);
        }

        [TestMethod]
        public void Test2()
        {
            var cache = new Cache(3);
            cache.Put("A", new Node(1, "A"));
            cache.Put("B", new Node(2, "B"));
            cache.Put("C", new Node(3, "C"));
            cache.Put("D", new Node(4, "D"));
            Assert.AreEqual(cache.Get("A"), null);
        }

        [TestMethod]
        public void Test3()
        {
            var cache = new Cache(3);
            cache.Put("A", new Node(1, "A"));
            cache.Put("B", new Node(2, "B"));
            cache.Put("C", new Node(3, "C"));
            cache.Get("A");
            cache.Get("B");
            cache.Get("C");
            cache.Put("D", new Node(4, "D"));
            Assert.AreEqual(cache.Get("A"), null);
        }

        [TestMethod]
        public void Test4()
        {
            var cache = new Cache(1000);
            var tasks = new List<Task>();

            int batchSize = 50000;
            for (int i = 0; i < 8; i++)
            {
                tasks.Add(Task.Factory.StartNew((object obj) =>
                {
                    try
                    {
                        var id = 0;
                        int si = id * batchSize;
                        int ei = si + batchSize;

                        Console.WriteLine($"si = {si.ToString()} and ei = {ei.ToString()}");

                        for (var idx = si; idx < ei; idx++)
                        {
                            Console.WriteLine($"Adding {idx.ToString()}");
                            cache.Put(idx.ToString(), idx.ToString());
                            Console.WriteLine($"Reading {cache.Get(idx.ToString())}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                }, i));
            }


            Task.WaitAll(tasks.ToArray());
            Assert.IsTrue(cache.Count == 1000);
            Console.WriteLine("All tasks completed!");
        }
    }
}
