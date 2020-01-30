using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    class RearrangeListToAlternateLowAndHigh
    {
        public static void Rearrange(SinglyLinkedList<int> list)
        {
            var traverser = list.Head;

            bool shouldeBeLow = true;

            while (traverser != null)
            {
                if (traverser.Next != null &&
                    (
                        ((traverser.Value > traverser.Next.Value) && shouldeBeLow) ||
                        ((traverser.Value < traverser.Next.Value) && !shouldeBeLow)
                        ))
                {

                    var temp = traverser.Value;
                    traverser.Value = traverser.Next.Value;
                    traverser.Next.Value = temp;
                }

                shouldeBeLow = !shouldeBeLow;
                traverser = traverser.Next;
            }
        }

        public static void Test1()
        {
            var list = new SinglyLinkedList<int>()
            {
                Head = new SinglyLinkedListNode<int>()
                {
                    Value = 5,
                    Next = new SinglyLinkedListNode<int>()
                    {
                        Value = 4,
                        Next = new SinglyLinkedListNode<int>()
                        {
                            Value = 3,
                            Next = new SinglyLinkedListNode<int>()
                            {
                                Value = 2,
                                Next = new SinglyLinkedListNode<int>()
                                {
                                    Value = 1
                                }
                            }
                        }
                    }
                }
            };

            Rearrange(list);
            Utility.PrintAllElements<int>(list);
        }
    }
}
