using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class AddTwoLinkedListThatRepresentNumber
    {
        public static int Add(SinglyLinkedList<int> list1, SinglyLinkedList<int> list2)
        {
            var returnValue = 0;

            bool breakLoop = false;
            var sum = 0;
            var multiplier = 1;
            var carry = 0;

            var list1Traverser = list1.Head;
            var list2Traverser = list2.Head;

            int num1, num2;

            while (!breakLoop)
            {
                num1 = num2 = 0;
                if (list1Traverser != null)
                {
                    num1 = list1Traverser.Value;
                    list1Traverser = list1Traverser.Next;
                }

                if (list2Traverser != null)
                {
                    num2 = list2Traverser.Value;
                    list2Traverser = list2Traverser.Next;
                }

                var total = (num1 + num2 + carry);
                sum += ((total % 10) * multiplier);
                carry = total / 10;

                multiplier *= 10;

                if (list1Traverser == null && list2Traverser == null)
                    breakLoop = true;
            }

            returnValue = sum;
            return returnValue;
        }

        public static void Test1()
        {
            Console.WriteLine(Add(new SinglyLinkedList<int>()
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

            }, new SinglyLinkedList<int>()
            {
                Head = new SinglyLinkedListNode<int>()
                {
                    Value = 9,
                    Next = new SinglyLinkedListNode<int>()
                    {
                        Value = 5
                    }
                }
            }));
        }

        public static void Test2()
        {
            Console.WriteLine(AddTwoLinkedListThatRepresentNumber.Add(new SinglyLinkedList<int>(), new SinglyLinkedList<int>()
            {
                Head = new SinglyLinkedListNode<int>()
                {
                    Value = 1
                }
            }));
        }
    }
}
