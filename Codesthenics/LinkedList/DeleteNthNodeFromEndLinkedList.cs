/*
    Given a Linked List and a number n, write a function that deletes the n’th node from end of the Linked List.

    1->2->3->4->5->6->7->8->9
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    class DeleteNthNodeFromEndLinkedList
    {

        public static SinglyLinkedListNode<int> Delete(SinglyLinkedListNode<int> linkedListNode, int positionFromEndToDelete)
        {
            SinglyLinkedListNode<int> finalLinkedList = null;
            SinglyLinkedListNode<int> start = linkedListNode;
            SinglyLinkedListNode<int> positionFromEndToDeleteStart = linkedListNode;

            for (int i = 0; i < positionFromEndToDelete; i++)
            {
                positionFromEndToDeleteStart = positionFromEndToDeleteStart.Next;
            }

            if (positionFromEndToDeleteStart == null)
                finalLinkedList = linkedListNode.Next;
            else
            {
                SinglyLinkedListNode<int> nodePtr = new SinglyLinkedListNode<int>();
                finalLinkedList = new SinglyLinkedListNode<int>()
                {
                    Value = start.Value
                };

                nodePtr = finalLinkedList;
                start = start.Next;
                if (positionFromEndToDeleteStart != null)
                    positionFromEndToDeleteStart = positionFromEndToDeleteStart.Next;

                while (positionFromEndToDeleteStart != null)
                {
                    nodePtr.Next = start;
                    start = start.Next;
                    nodePtr = nodePtr.Next;
                    positionFromEndToDeleteStart = positionFromEndToDeleteStart.Next;
                }
                nodePtr.Next = start.Next;
            }
            bool stopPrinting = false;
            while (!stopPrinting)
            {
                Console.WriteLine(finalLinkedList.Value);
                finalLinkedList = finalLinkedList.Next;

                if (finalLinkedList == null)
                    stopPrinting = true;
            }

            return finalLinkedList;
        }
    }
}
