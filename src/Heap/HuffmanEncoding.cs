using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class HuffmanEncoding
    {
        public Dictionary<char, string> EncodeCharacters(IDictionary<char, int> characterFrequencies)
        {
            IHuffmanTreeNode<int> huffmanTree = new HuffmanTreeNode<int>();
            var heap = new Heap<IHuffmanTreeNode<int>>(Comparer<IHuffmanTreeNode<int>>.Create((IHuffmanTreeNode<int> node1, IHuffmanTreeNode<int> node2) =>
            {
                if (node1.Frequency > node2.Frequency)
                    return 1;
                else if (node1.Frequency < node2.Frequency)
                    return -1;
                else
                    return 0;
            }));

            foreach (var frequency in characterFrequencies)
                heap.Push(new HuffmanTreeLeafNode<int>()
                {
                    Data = frequency.Key,
                    Frequency = frequency.Value
                });

            while (heap.Length > 0)
            {
                var node1 = heap.Pop();
                if (heap.Length > 0)
                {
                    var node2 = heap.Pop();

                    var mergedNode = new HuffmanTreeNode<int>()
                    {
                        Frequency = node1.Frequency + node2.Frequency,
                        LeftChild = node1,
                        RightChild = node2
                    };
                    heap.Push(mergedNode);
                }
                else
                    huffmanTree = node1;
            }

            return EncodeCharacters(huffmanTree);
        }

        private Dictionary<char, string> EncodeCharacters(IHuffmanTreeNode<int> huffmanTree)
        {
            var encoding = new Dictionary<char, string>();
            var node = (HuffmanTreeNode<int>)huffmanTree;
            if (node.LeftChild == null && node.RightChild == null)
                return encoding;

            EncodeInternal(huffmanTree, encoding);

            return encoding;
        }

        private void EncodeInternal(IHuffmanTreeNode<int> huffmanTree, Dictionary<char, string> encoding, string code = "")
        {
            var huffmanTreeLeafNode = huffmanTree as HuffmanTreeLeafNode<int>;
            if (huffmanTreeLeafNode != null)
            {
                encoding.Add(huffmanTreeLeafNode.Data, code);
                return;
            }

            var huffmanTreeNode = huffmanTree as HuffmanTreeNode<int>;
            if (huffmanTreeNode.LeftChild != null)
                EncodeInternal(huffmanTreeNode.LeftChild, encoding, $"{code}{"0"}");

            if (huffmanTreeNode.RightChild != null)
                EncodeInternal(huffmanTreeNode.RightChild, encoding, $"{code}{"1"}");
        }
    }

    interface IHuffmanTreeNode<T>
    {
        T Frequency { get; set; }
    }

    class HuffmanTreeNode<T> : IHuffmanTreeNode<T>
    {
        public T Frequency { get; set; }

        public IHuffmanTreeNode<T> LeftChild { get; set; }

        public IHuffmanTreeNode<T> RightChild { get; set; }
    }

    class HuffmanTreeLeafNode<T> : IHuffmanTreeNode<T>
    {
        public T Frequency { get; set; }

        public char Data { get; set; }
    }
}
