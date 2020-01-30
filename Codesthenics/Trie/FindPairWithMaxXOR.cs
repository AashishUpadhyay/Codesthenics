using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    public class FindPairWithMaxXOR
    {
        private const int INT_SIZE = 30;

        public int[] Find(int[] inputArray)
        {
            var returnValue = new int[2];
            var trie = new Trie();
            int maxXOR = 0;
            foreach (var item in inputArray)
            {
                var binary = GetBinary(item);
                trie.Insert(binary);
                int compliment = 0;
                var currentMaxXOR = FindMaxXORInTrie(trie.Nodes, binary, out compliment);
                if (currentMaxXOR > maxXOR)
                {
                    maxXOR = currentMaxXOR;
                    returnValue[0] = item;
                    returnValue[1] = compliment;
                }
            }

            return returnValue;
        }

        private int FindMaxXORInTrie(TrieNode[] nodesToBegin, int[] numberAsBinary, out int compliment)
        {
            var returnValue = 0;
            var trieNodes = nodesToBegin;
            var itemAsBinary = numberAsBinary;
            var numberTraversed = 0;
            for (int i = 0; i < INT_SIZE; i++)
            {
                if (trieNodes[0] != null && trieNodes[1] != null)
                {
                    if (trieNodes[0].Value != itemAsBinary[i])
                    {
                        numberTraversed += (trieNodes[0].Value != 1) ? 0 : (1 << ((INT_SIZE - 1) - i));
                        trieNodes = trieNodes[0].Nodes;
                    }
                    else if (trieNodes[1].Value != itemAsBinary[i])
                    {
                        numberTraversed += (trieNodes[1].Value != 1) ? 0 : (1 << ((INT_SIZE - 1) - i));
                        trieNodes = trieNodes[1].Nodes;
                    }

                    returnValue += (1 << ((INT_SIZE - 1) - i));
                }
                else if (trieNodes[0] != null)
                {
                    if (trieNodes[0].Value != itemAsBinary[i])
                    {
                        returnValue += (1 << ((INT_SIZE - 1) - i));
                    }
                    numberTraversed += (trieNodes[0].Value != 1) ? 0 : (1 << ((INT_SIZE - 1) - i));
                    trieNodes = trieNodes[0].Nodes;
                }
                else if (trieNodes[1] != null)
                {
                    if (trieNodes[1].Value != itemAsBinary[i])
                    {
                        returnValue += (1 << ((INT_SIZE - 1) - i));
                    }
                    numberTraversed += (trieNodes[1].Value != 1) ? 0 : (1 << ((INT_SIZE - 1) - i));
                    trieNodes = trieNodes[1].Nodes;
                }
            }

            compliment = numberTraversed;
            return returnValue;
        }

        private int[] GetBinary(int number)
        {
            var trieItems = new int[INT_SIZE];

            for (int i = 0; i < INT_SIZE; i++)
            {
                var x = (number & 1 << ((INT_SIZE - 1) - i)) > 0 ? 1 : 0; //MSB

                trieItems[i] = x;
            }

            return trieItems;
        }

        private class Trie
        {
            private const int END_TOKEN = -999;

            public TrieNode[] Nodes = new TrieNode[3];

            public void Insert(int[] items)
            {
                if (items.Length == 0)
                    throw new ArgumentException("Empty Array!");

                InsertInternal(Nodes, items);
            }

            private void InsertInternal(TrieNode[] nodes, int[] items)
            {
                if (items.Length == 0)
                {
                    nodes[2] = new TrieNode()
                    {
                        Value = END_TOKEN
                    };
                    return;
                }

                if (items[0] < 0 || items[0] > 1)
                    throw new ArgumentException($"Invalid Value: {items[0]}");

                if (nodes[items[0]] == null)
                {
                    nodes[items[0]] = new TrieNode()
                    {
                        Value = items[0]
                    };
                }
                InsertInternal(nodes[items[0]].Nodes, items.Skip(1).ToArray());
            }
        }

        private class TrieNode
        {
            public int Value { get; set; }

            public TrieNode[] Nodes = new TrieNode[3];
        }
    }
}
