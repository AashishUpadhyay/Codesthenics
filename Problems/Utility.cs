using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class Utility
    {
        public static void PrintAllElements<T>(T[] inputArr)
        {
            foreach (var item in inputArr)
            {
                Console.WriteLine(item);
            }
        }

        public static bool IsPalindrome(string input)
        {
            var inputLowerCase = input.ToLowerInvariant();
            if (inputLowerCase.Length == 0)
                return false;
            if (inputLowerCase.Length == 1)
                return true;
            else
            {
                bool returnValue = true;
                for (int i = 0; i < inputLowerCase.Length / 2; i++)
                {
                    if (inputLowerCase[i] != inputLowerCase[inputLowerCase.Length - 1 - i])
                    {
                        returnValue = false;
                        break;
                    }
                }

                return returnValue;
            }
        }

        public static int GetMax(int[] arr)
        {
            var returnVale = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (returnVale < arr[i])
                {
                    returnVale = arr[i];
                }
            }

            return returnVale;
        }

        public static int GetMin(int[] arr)
        {
            var returnVale = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (returnVale > arr[i])
                {
                    returnVale = arr[i];
                }
            }

            return returnVale;
        }

        public static void PrintAllElements<T>(SinglyLinkedList<T> input)
        {
            var nodePtr = input.Head;
            do
            {
                Console.WriteLine(nodePtr.Value);
                nodePtr = nodePtr.Next;
            } while (nodePtr != null);
        }

        public static SinglyLinkedList<T> ReverseLinkedList<T>(SinglyLinkedList<T> input)
        {
            SinglyLinkedListNode<T> prev = null;
            SinglyLinkedListNode<T> back = null;
            SinglyLinkedListNode<T> forw = input.Head;

            do
            {
                back = forw;
                forw = forw.Next;
                back.Next = prev;
                prev = back;
            } while (forw != null);

            input.Head = back;
            return input;
        }

        public static SinglyLinkedListNode<T> ReverseLinkedListRecursively<T>(SinglyLinkedList<T> list)
        {
            return ReverseNodeDirection(list.Head, list);
        }

        public static SinglyLinkedListNode<T> ReverseNodeDirection<T>(SinglyLinkedListNode<T> next, SinglyLinkedList<T> list)
        {
            if (next.Next == null)
            {
                list.Head = next;
                return next;
            }

            var reversedNode = ReverseNodeDirection(next.Next, list);
            reversedNode.Next = next;
            next.Next = null;

            return next;
        }

        public static SinglyLinkedListNode<int> BuildLinkedListNode()
        {
            var linkedList = new SinglyLinkedListNode<int>()
            {
                Value = 1,
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
                                Value = 5,
                                Next = new SinglyLinkedListNode<int>()
                                {
                                    Value = 6,
                                    Next = new SinglyLinkedListNode<int>()
                                    {
                                        Value = 7,
                                        Next = new SinglyLinkedListNode<int>()
                                        {
                                            Value = 8,
                                            Next = new SinglyLinkedListNode<int>()
                                            {
                                                Value = 9,
                                                Next = null
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return linkedList;
        }

        public static SinglyLinkedList<int> BuildLinkedList()
        {
            return new SinglyLinkedList<int>()
            {
                Head = new SinglyLinkedListNode<int>()
                {
                    Value = 1,
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
                                    Value = 5,
                                    Next = new SinglyLinkedListNode<int>()
                                    {
                                        Value = 6,
                                        Next = new SinglyLinkedListNode<int>()
                                        {
                                            Value = 7,
                                            Next = new SinglyLinkedListNode<int>()
                                            {
                                                Value = 8,
                                                Next = new SinglyLinkedListNode<int>()
                                                {
                                                    Value = 9,
                                                    Next = null
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            };
        }

        public static int FindLength<T>(this SinglyLinkedList<T> list)
        {
            var returnValue = 0;
            var node = list.Head;

            while (node != null)
            {
                returnValue++;
                node = node.Next;
            }

            return returnValue;
        }

        public static bool CompareTrees<T>(TreeNode<T> expected, TreeNode<T> received)
        {
            var isLeftSideEqual = ((expected == null && received != null) || (received == null && expected != null)) ? false : (expected.LeftChild == null && received.LeftChild == null) || CompareTrees(expected.LeftChild, received.LeftChild);
            var isRightSideEqual = ((expected == null && received != null) || (received == null && expected != null)) ? false : (expected.RightChild == null && received.RightChild == null) || CompareTrees(expected.RightChild, received.RightChild);

            return isLeftSideEqual && isRightSideEqual && (expected != null && received != null && expected.Value.Equals(received.Value));
        }

        public static bool IsBinarySearchTree(TreeNode<int> node)
        {
            if (node.LeftChild == null && node.RightChild == null)
                return true;

            bool leftSide = false;
            bool rightSide = false;

            if (node.LeftChild != null && node.Value > node.LeftChild.Value)
                leftSide = IsBinarySearchTree(node.LeftChild);
            else if (node.LeftChild == null)
            {
                leftSide = true;
            }

            if (node.RightChild != null && node.RightChild.Value > node.Value)
                rightSide = IsBinarySearchTree(node.RightChild);
            else if (node.RightChild == null)
            {
                rightSide = true;
            }

            return leftSide && rightSide;
        }

        public static TreeNode<int> BuildTreeFromArray(int?[] values)
        {
            var dictionary = new Dictionary<int, TreeNode<int>>();
            for (int i = values.Length - 1; i >= 1; i--)
            {
                if (values[i] == null)
                {
                    continue;
                }

                var parentIndex = (i - 1) / 2;
                TreeNode<int> parentNode;
                if (dictionary.ContainsKey(parentIndex))
                {
                    parentNode = dictionary[parentIndex];
                }
                else
                {
                    if (values[parentIndex] == null)
                        throw new InvalidOperationException();

                    parentNode = new TreeNode<int>()
                    {
                        Value = values[parentIndex].Value
                    };
                    dictionary.Add(parentIndex, parentNode);
                }

                TreeNode<int> childNode;
                if (dictionary.ContainsKey(i))
                {
                    childNode = dictionary[i];
                }
                else
                    childNode = new TreeNode<int>()
                    {
                        Value = values[i].Value
                    };

                if (i % 2 == 0)
                    parentNode.RightChild = childNode;
                else
                    parentNode.LeftChild = childNode;

            }

            return dictionary[0];
        }
    }
}
