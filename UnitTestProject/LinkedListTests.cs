using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void TestAdd()
        {
            var linkedList = new DoublyinkedList<int>();

            linkedList.Add(new DoublyinkedListNode<int>(1));
            linkedList.Add(new DoublyinkedListNode<int>(2));
            linkedList.Add(new DoublyinkedListNode<int>(3));

            var node = new DoublyinkedListNode<int>(1);
            node.Next = new DoublyinkedListNode<int>(2);
            node.Next.Prev = node;

            node.Next.Next = new DoublyinkedListNode<int>(3);
            node.Next.Next.Prev = node.Next;

            var linkedList2 = new DoublyinkedList<int>()
            {
                Head = node,
                Tail = node.Next.Next
            };

            //1
            Assert.IsTrue(linkedList.Head.Value == linkedList2.Head.Value);
            Assert.IsTrue(linkedList.Head.Next.Prev.Value == linkedList2.Head.Next.Prev.Value);

            //2
            Assert.IsTrue(linkedList.Head.Next.Value == linkedList2.Head.Next.Value);
            Assert.IsTrue(linkedList.Head.Next.Next.Prev.Value == linkedList2.Head.Next.Next.Prev.Value);

            //3
            Assert.IsTrue(linkedList.Head.Next.Next.Value == linkedList2.Head.Next.Next.Value);

            //null check
            Assert.IsTrue(linkedList.Head.Next.Next.Next == linkedList2.Head.Next.Next.Next);
            Assert.IsTrue(linkedList.Head.Prev == linkedList2.Head.Prev);

            //tail
            Assert.IsTrue(linkedList.Tail.Value == linkedList2.Tail.Value);
            Assert.IsTrue(linkedList.Tail.Next == linkedList2.Tail.Next);
            Assert.IsTrue(linkedList.Tail.Prev.Value == linkedList2.Tail.Prev.Value);

            Assert.IsTrue(linkedList.Count == 3);
        }

        [TestMethod]
        public void TestHeadRemoval()
        {
            var linkedList = new DoublyinkedList<int>();

            var node1 = new DoublyinkedListNode<int>(1);
            linkedList.Add(node1);

            var node2 = new DoublyinkedListNode<int>(2);
            linkedList.Add(node2);

            var node3 = new DoublyinkedListNode<int>(3);
            linkedList.Add(node3);

            linkedList.Remove(node1);

            Assert.IsTrue(linkedList.Count == 2);
            Assert.IsTrue(linkedList.Head.Value == 2);
            Assert.IsTrue(linkedList.Head.Prev == null);

            Assert.IsTrue(linkedList.Head.Next.Value == 3);
            Assert.IsTrue(linkedList.Head.Next.Next== null);
            Assert.IsTrue(linkedList.Head.Next.Prev.Value == 2);

            Assert.IsTrue(linkedList.Tail.Value == 3);
            Assert.IsTrue(linkedList.Tail.Next == null);
            Assert.IsTrue(linkedList.Tail.Prev.Value == 2);
        }

        [TestMethod]
        public void TestTailRemoval()
        {
            var linkedList = new DoublyinkedList<int>();

            var node1 = new DoublyinkedListNode<int>(1);
            linkedList.Add(node1);

            var node2 = new DoublyinkedListNode<int>(2);
            linkedList.Add(node2);

            var node3 = new DoublyinkedListNode<int>(3);
            linkedList.Add(node3);

            linkedList.Remove(node3);

            Assert.IsTrue(linkedList.Count == 2);
            Assert.IsTrue(linkedList.Head.Value == 1);
            Assert.IsTrue(linkedList.Head.Prev == null);

            Assert.IsTrue(linkedList.Head.Next.Value == 2);
            Assert.IsTrue(linkedList.Head.Next.Next == null);
            Assert.IsTrue(linkedList.Head.Next.Prev.Value == 1);

            Assert.IsTrue(linkedList.Tail.Value == 2);
            Assert.IsTrue(linkedList.Tail.Next == null);
            Assert.IsTrue(linkedList.Tail.Prev.Value == 1);
        }
    }
}
