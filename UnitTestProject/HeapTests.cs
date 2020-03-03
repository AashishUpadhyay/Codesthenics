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
    public class HeapTests
    {
        [TestMethod]
        public void HeapPushTest()
        {
            var input = new int[] { 9, 6, 3, 9, 0, 4, 5 };
            var heap = new Heap<int>();

            foreach (var item in input)
                heap.Push(item);

            var allHeapItems = heap.GetAll();

            var allHeapItemsArray = allHeapItems.ToArray();

            Assert.IsTrue(allHeapItemsArray.SequenceEqual(new int[] { 0, 3, 4, 9, 9, 6, 5 }));
        }

        [TestMethod]
        public void HeapPopTest()
        {
            var input = new int[] { 9, 6, 3, 9, 0, 4, 5 };
            var heap = new Heap<int>();

            foreach (var item in input)
                heap.Push(item);

            Assert.IsTrue(heap.Pop() == 0);
            Assert.IsTrue(heap.Pop() == 3);
            Assert.IsTrue(heap.Pop() == 4);
            Assert.IsTrue(heap.Pop() == 5);
            Assert.IsTrue(heap.Pop() == 6);
            Assert.IsTrue(heap.Pop() == 9);
            Assert.IsTrue(heap.Pop() == 9);
            Assert.IsTrue(heap.Length == 0);
        }

        [TestMethod]
        public void DecreasingHeapPushTest()
        {
            var input = new int[] { 0, 3, 4, 9, 9, 6, 5 };
            var heap = new Heap<int>(Comparer<int>.Create(MaxHeapComparer));

            foreach (var item in input)
                heap.Push(item);

            var allHeapItems = heap.GetAll();

            var allHeapItemsArray = allHeapItems.ToArray();

            Assert.IsTrue(allHeapItemsArray.SequenceEqual(new int[] { 9, 9, 6, 0, 4, 3, 5 }));
        }

        [TestMethod]
        public void DecreasingHeapPopTest()
        {
            var input = new int[] { 0, 3, 4, 9, 9, 6, 5 };
            var heap = new Heap<int>(Comparer<int>.Create(MaxHeapComparer));

            foreach (var item in input)
                heap.Push(item);

            Assert.IsTrue(heap.Pop() == 9);
            Assert.IsTrue(heap.Pop() == 9);
            Assert.IsTrue(heap.Pop() == 6);
            Assert.IsTrue(heap.Pop() == 5);
            Assert.IsTrue(heap.Pop() == 4);
            Assert.IsTrue(heap.Pop() == 3);
            Assert.IsTrue(heap.Pop() == 0);
            Assert.IsTrue(heap.Length == 0);
        }

        private int MaxHeapComparer(int x, int y)
        {
            if (x == y)
                return 0;
            else if (x > y)
                return -1;
            else
                return 1;
        }
    }
}
