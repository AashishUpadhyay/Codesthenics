using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class ArrayTrie
    {
        private ArrayTrieNode[] Value;

        public const char END_TOKEN = '#';

        public ArrayTrie()
        {
            Value = new ArrayTrieNode[256];
        }

        public void Insert(string input)
        {
            InsertInternal(this.Value, input);
        }

        private void InsertInternal(ArrayTrieNode[] trieNodes, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                trieNodes[END_TOKEN] = new ArrayTrieNode()
                {
                    Key = END_TOKEN,
                    Exists = true
                };
                return;
            }

            if (trieNodes[input[0]] == null)
            {
                trieNodes[input[0]] = new ArrayTrieNode()
                {
                    Value = new ArrayTrieNode[256]
                };
            }

            if (trieNodes[input[0]].Key == null)
            {
                trieNodes[input[0]].Key = input[0];
                trieNodes[input[0]].Exists = true;
            }
            InsertInternal(trieNodes[input[0]].Value, input.Substring(1));
        }

        public bool Contains(string input)
        {
            if (Value == null || Value.Length == 0)
                return false;

            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("input");

            return ContainsInternal(Value, input);
        }

        public ArrayTrieNode FindNode(string input)
        {
            ArrayTrieNode returnValue = null;

            if (Value == null || Value.Length == 0)
                return null;

            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("input");

            if (Value[input[0]].Exists && FindNodeInternal(Value[input[0]].Value, input.Substring(1)))
                returnValue = Value[input[0]];

            return returnValue;
        }

        public IList<string> FindAllStringsMatchingPrefix(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException();

            List<StringBuilder> allStrings;
            TryFindAllStringsMatchingPrefixInternal(Value[input[0]], input.Substring(1), out allStrings);
            return allStrings?.Select(u => string.Concat(input, u.ToString())).ToList();
        }

        private bool TryFindAllStringsMatchingPrefixInternal(ArrayTrieNode node, string input, out List<StringBuilder> matchingStrings)
        {
            if (string.IsNullOrEmpty(input))
            {
                matchingStrings = ReadAllStrings(node);
                return true;
            }

            if (node.Value[input[0]] != null && node.Value[input[0]].Exists && TryFindAllStringsMatchingPrefixInternal(node.Value[input[0]], input.Substring(1), out matchingStrings))
            {
                return true;
            }

            matchingStrings = null;
            return false;
        }

        private List<StringBuilder> ReadAllStrings(ArrayTrieNode node)
        {
            var returnValue = new List<StringBuilder>();
            var nonNullNodes = node?.Value?.Where(u => u != null);

            if (nonNullNodes == null || !nonNullNodes.Any())
                return new List<StringBuilder>() { new StringBuilder() };

            foreach (var nonNullNode in nonNullNodes)
            {
                var returnedValue = ReadAllStrings(nonNullNode);

                returnedValue.ForEach(u =>
                {
                    returnValue.Add(new StringBuilder(nonNullNode.Key == END_TOKEN ? string.Empty : nonNullNode.Key.ToString()).Append(u));
                });
            }

            return returnValue;
        }

        private bool FindNodeInternal(ArrayTrieNode[] nodes, string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            if (nodes[input[0]] != null && nodes[input[0]].Exists)
                return FindNodeInternal(nodes[input[0]].Value, input.Substring(1));

            return false;
        }

        private bool ContainsInternal(ArrayTrieNode[] trieNodes, string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            if (trieNodes != null && trieNodes.Length > 0 && trieNodes[input[0]] != null && trieNodes[input[0]].Contains(input))
                return true;
            else
            {
                return false;
            }
        }
    }

    public class ArrayTrieNode
    {
        public char? Key;

        public bool Exists;

        public ArrayTrieNode[] Value;

        public bool Contains(string input)
        {
            if (Value == null || Value.Length == 0)
                return false;

            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("input");

            return Key == input[0] && ContainsInternal(Value, input.Substring(1));
        }

        private bool ContainsInternal(ArrayTrieNode[] trieNodes, string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            if (trieNodes[input[0]] != null && trieNodes[input[0]].Exists)
                return ContainsInternal(trieNodes[input[0]].Value, input.Substring(1));
            else
            {
                return false;
            }
        }
    }
}
