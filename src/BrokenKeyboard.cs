using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	/// <summary>
	/// There is a broken keyboard in which space gets typed when you type the letter 'e'. Given an input string which is the output from the keyboard. A dictionary of possible words is also provided as an input parameter of the method. Return a list of possible actual input typed by the user.
	/// Example Input: String: "can s r n " Dictionary: ["can", "canes", "serene", "rene", "sam"]
	/// Expected Output: ["can serene", "canes rene"]
	/// </summary>
	public class BrokenKeyboard
	{
		private BrokenKeyboardTrie _trie;
		private IList<string> _actualInputs = new List<string>();
		public IList<string> ActualInputs(string str, IList<string> possibleInputs)
		{
			_trie = BuildTrie(possibleInputs);
			DFS(0, str, new StringBuilder(), new List<string>(), _trie);
			return _actualInputs;
		}

		private void DFS(int index, string str, StringBuilder sb, List<string> words, BrokenKeyboardTrie trie)
		{
			if (index > str.Length - 1)
			{
				var lastWord = sb.ToString();
				if (lastWord.Length > 0)
					words.Add(lastWord);
				_actualInputs.Add(string.Join(" ", words));
				return;
			}

			char nextChar;
			if (str[index] == ' ')
			{
				if (trie.Items.ContainsKey('#'))
				{
					List<string> nw = new List<string>();
					nw.AddRange(words);
					nw.Add(sb.ToString());
					DFS(index + 1, str, new StringBuilder(), nw, _trie);
				}

				if (trie.Items.ContainsKey('e'))
					nextChar = 'e';
				else
					nextChar = str[index];
			}
			else
			{
				nextChar = str[index];
			}

			if (nextChar != '#')
			{
				sb.Append(nextChar);
				DFS(index + 1, str, sb, words, trie.Items[nextChar]);
			}
		}

		private BrokenKeyboardTrie BuildTrie(IList<string> input)
		{
			BrokenKeyboardTrie retVal = new BrokenKeyboardTrie();
			foreach (var item in input)
			{
				Dictionary<char, BrokenKeyboardTrie> trie = retVal.Items;
				foreach (var ch in item)
				{
					if (!trie.ContainsKey(ch))
						trie.Add(ch, new BrokenKeyboardTrie());

					trie = trie[ch].Items;
				}

				trie.Add('#', null);
			}

			return retVal;
		}

		public class BrokenKeyboardTrie
		{
			public BrokenKeyboardTrie()
			{
				Items = new Dictionary<char, BrokenKeyboardTrie>();
			}

			public Dictionary<char, BrokenKeyboardTrie> Items { get; set; }
		}
	}
}
