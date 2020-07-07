using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; }
    }

    public class DoublyinkedList<T>
    {
        public DoublyinkedListNode<T> Head { get; set; }
        public DoublyinkedListNode<T> Tail { get; set; }

        public int Count { get; set; }

        public void Add(DoublyinkedListNode<T> node)
        {
            if (Head == null && Tail == null)
                Head = Tail = node;
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }
            Count++;
        }

        public void Remove(DoublyinkedListNode<T> node)
        {
            if (node.Prev != null)
                node.Prev.Next = node.Next;

            if (node.Equals(Head))
            {
                Head = node.Next;
                Head.Prev = null;
                if (Head.Next != null)
                    Head.Next.Prev = Head;
            }

            if (node.Equals(Tail))
            {
                Tail = node.Prev;
                Tail.Next = null;
            }
            Count--;
        }
    }
}
