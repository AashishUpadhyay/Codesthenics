using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class Trie
    {
        private Dictionary<string, Trie> Value;

        private const string END_TOKEN = "#";

        public Trie()
        {
            Value = new Dictionary<string, Trie>();
        }

        public void Insert(string input)
        {
            InsertInternal(this, input);
        }

        private void InsertInternal(Trie trie, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                trie.Value.Add(END_TOKEN, null);
                return;
            }

            if (!trie.Value.ContainsKey(input[0].ToString()))
            {
                trie.Value.Add(input[0].ToString(), new Trie());
            }

            InsertInternal(trie.Value[input[0].ToString()], input.Substring(1));
        }

        public bool Contains(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("input");

            return ContainsInternal(this, input);
        }

        private bool ContainsInternal(Trie trie, string input)
        {
            if (string.IsNullOrEmpty(input) || (trie.Value.ContainsKey(input[0].ToString()) && ContainsInternal(trie.Value[input[0].ToString()], input.Substring(1))))
                return true;

            return false;
        }

        public Trie FindNode(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("input");

            if (Value.ContainsKey(input[0].ToString()) &&
                FindNodeInternal(Value[input[0].ToString()], input.Substring(1)))
                return this;

            return null;
        }

        private bool FindNodeInternal(Trie trie, string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            if (trie.Value.ContainsKey(input[0].ToString()))
                return FindNodeInternal(trie.Value[input[0].ToString()], input.Substring(1));

            return false;
        }


        public IList<string> FindAllStringsMatchingPrefix(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException();

            List<StringBuilder> allStrings;
            TryFindAllStringsMatchingPrefixInternal(Value[input[0].ToString()], input.Substring(1), out allStrings);
            return allStrings?.Select(u => string.Concat(input, u.ToString())).ToList();
        }

        private bool TryFindAllStringsMatchingPrefixInternal(Trie node, string input, out List<StringBuilder> matchingStrings)
        {
            if (string.IsNullOrEmpty(input))
            {
                matchingStrings = ReadAllStrings(node);
                return true;
            }

            if (node.Value.ContainsKey(input[0].ToString()) && TryFindAllStringsMatchingPrefixInternal(node.Value[input[0].ToString()], input.Substring(1), out matchingStrings))
            {
                return true;
            }

            matchingStrings = null;
            return false;
        }

        private List<StringBuilder> ReadAllStrings(Trie node)
        {
            var returnValue = new List<StringBuilder>();

            if (node == null)
                return new List<StringBuilder>() { new StringBuilder() };

            foreach (var key in node.Value.Keys)
            {
                var returnedValue = ReadAllStrings(node.Value[key]);

                returnedValue.ForEach(u =>
                {
                    returnValue.Add(new StringBuilder(key == END_TOKEN ? string.Empty : key).Append(u));
                });
            }

            return returnValue;
        }
    }
}
