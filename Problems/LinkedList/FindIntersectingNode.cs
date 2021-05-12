using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class FindIntersectingNode
    {
        public static int FindIntersectingNodeValue(SinglyLinkedList<int> list1, SinglyLinkedList<int> list2)
        {
            var list1Length = list1.FindLength();
            var list2Length = list2.FindLength();
            var difference = 0;
            SinglyLinkedList<int> longerList;
            SinglyLinkedList<int> shorterList;

            if (list1Length > list2Length)
            {
                difference = list1Length - list2Length;
                longerList = list1;
                shorterList = list2;
            }
            else
            {
                difference = list2Length - list1Length;
                longerList = list2;
                shorterList = list1;
            }

            var longerListPtr = longerList.Head;
            while (difference != 0)
            {
                difference--;
                longerListPtr = longerListPtr.Next;
            }

            var shorterListPtr = shorterList.Head;

            while (true)
            {
                if (longerListPtr.Value == shorterListPtr.Value && longerListPtr.Next == shorterListPtr.Next)
                    break;

                if (longerListPtr == null || shorterListPtr == null)
                    break;

                longerListPtr = longerListPtr.Next;
                shorterListPtr = shorterListPtr.Next;
            }

            return shorterListPtr.Value;
        }

        public static void Test1()
        {
            var commonPart = new SinglyLinkedListNode<int>()
            {
                Value = 19,
                Next = new SinglyLinkedListNode<int>()
                {
                    Value = 45,
                    Next = new SinglyLinkedListNode<int>()
                    {
                        Value = 23,
                        Next = new SinglyLinkedListNode<int>()
                        {
                            Value = 56,
                            Next = new SinglyLinkedListNode<int>()
                            {
                                Value = 1
                            }
                        }
                    }
                }
            };

            var list1 = new SinglyLinkedList<int>()
            {
                Head = new SinglyLinkedListNode<int>()
                {
                    Value = 100,
                    Next = new SinglyLinkedListNode<int>()
                    {
                        Value = 2,
                        Next = new SinglyLinkedListNode<int>()
                        {
                            Value = 45,
                            Next = commonPart
                        }
                    }
                }
            };

            var list2 = new SinglyLinkedList<int>()
            {
                Head = new SinglyLinkedListNode<int>()
                {
                    Value = 100,
                    Next = new SinglyLinkedListNode<int>()
                    {
                        Value = 2,
                        Next = new SinglyLinkedListNode<int>()
                        {
                            Value = 3,
                            Next = new SinglyLinkedListNode<int>()
                            {
                                Value = 4,
                                Next = new SinglyLinkedListNode<int>()
                                {
                                    Value = 11,
                                    Next = new SinglyLinkedListNode<int>()
                                    {
                                        Value = 2,
                                        Next = new SinglyLinkedListNode<int>()
                                        {
                                            Value = 96,
                                            Next = commonPart
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            Console.WriteLine("Is Successful: " + (FindIntersectingNodeValue(list1, list2) == 19).ToString());
        }
    }
}
