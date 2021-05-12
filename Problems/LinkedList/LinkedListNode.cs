using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class SinglyLinkedListNode<T>
    {
        public T Value;
        public SinglyLinkedListNode<T> Next { get; set; }
    }

    public class DoublyinkedListNode<T>
    {
        public DoublyinkedListNode(T value)
        {
            Value = value;
        }

        public T Value;
        public DoublyinkedListNode<T> Next { get; set; }

        public DoublyinkedListNode<T> Prev { get; set; }
    }
}
