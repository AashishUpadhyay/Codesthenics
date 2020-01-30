﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    public class Heap<T>
    {
        private IList<T> _heap = new List<T>();
        private readonly IComparer<T> _comparer;

        public int Length => _heap.Count;

        public Heap()
        {
            _comparer = Comparer<T>.Default;
        }

        public Heap(IList<T> input) : this()
        {
            _heap = input;
        }

        public void Push(T input)
        {
            _heap.Add(input);
            HeapifyEndToBeginning(_heap.Count - 1);
        }

        private void HeapifyEndToBeginning(int inputIndex)
        {
            if (inputIndex < 1)
                return;

            int parentIndex = GetParentIndex(inputIndex);
            if (_comparer.Compare(_heap[parentIndex], _heap[inputIndex]) > 0)
            {
                Exchange(parentIndex, inputIndex);
                HeapifyEndToBeginning(parentIndex);
            }
        }

        private void Exchange(int leftIndex, int rightIndex)
        {
            var temp = _heap[leftIndex];
            _heap[leftIndex] = _heap[rightIndex];
            _heap[rightIndex] = temp;
        }

        private void HeapifyBeginningToEnd(int inputIndex)
        {
            if ((2 * inputIndex + 2) >_heap.Count)
                return;

            int leftIndex = (2 * inputIndex + 1);
            int rightIndex = (2 * inputIndex + 2);
            var smallerIndex = inputIndex;

            if (leftIndex < _heap.Count
                && _comparer.Compare(_heap[inputIndex], _heap[leftIndex]) > 0)
            {
                smallerIndex = leftIndex;
            }

            if (rightIndex < _heap.Count
                && _comparer.Compare(_heap[smallerIndex], _heap[rightIndex]) > 0)
            {
                smallerIndex = rightIndex;
            }

            if (smallerIndex != inputIndex)
            {
                Exchange(inputIndex, smallerIndex);
                HeapifyBeginningToEnd(smallerIndex);
            }
        }

        public T Pop()
        {
            if (_heap.Count == 0)
                throw new InvalidOperationException();

            var returnValue = _heap[0];
            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);

            HeapifyBeginningToEnd(0);

            return returnValue;
        }

        private int GetParentIndex(int inputIndex)
        {
            if (inputIndex == 0)
                return 0;

            return (inputIndex - 1) / 2;
        }

        public IList<T> GetAll()
        {
            return _heap;
        }
    }
}
