using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class NumberOfWaysToDecodeString
	{
		private Dictionary<string, List<string>> codesDictNOW = new Dictionary<string, List<string>>() {
		 {"0", new List<string>() },
		 {"1", new List<string>(){ "a"}},
		 {"2", new List<string>(){ "b"}},
		 {"3", new List<string>(){ "c"}},
		 {"4", new List<string>(){ "d"}},
		 {"5", new List<string>(){ "e"}},
		 {"6", new List<string>(){ "f"}},
		 {"7", new List<string>(){ "g"}},
		 {"8", new List<string>(){ "h"}},
		 {"9", new List<string>(){ "i"}},
		 {"10", new List<string>(){ "j"}},
		 {"11", new List<string>(){ "aa", "k"}},
		 {"12", new List<string>(){ "ab", "l"}},
		 {"13", new List<string>(){ "ac", "m"}},
		 {"14", new List<string>(){ "ad", "n" }},
		 {"15", new List<string>(){ "ae", "o" }},
		 {"16", new List<string>(){ "af", "p" }},
		 {"17", new List<string>(){ "ag", "q"}},
		 {"18", new List<string>(){ "ah", "r" }},
		 {"19", new List<string>(){ "ai", "s" }},
		 {"20", new List<string>(){ "t" }},
		 {"21", new List<string>(){ "u"}},
		 {"22", new List<string>(){ "v"}},
		 {"23", new List<string>(){ "w"}},
		 {"24", new List<string>(){ "x"}},
		 {"25", new List<string>(){ "y"}},
		 {"26", new List<string>(){ "z"}}
		};
		private Dictionary<string, List<string>> cacheNOW = new Dictionary<string, List<string>>();

		public List<string> NumberOfWays(string s)
		{
			if (string.IsNullOrEmpty(s) || s[0] == '0')
				return new List<string>();

			if (codesDict.ContainsKey(s))
				return codesDictNOW[s];

			if (cacheNOW.ContainsKey(s))
				return cacheNOW[s];

			List<string> totalWays = new List<string>();
			List<string> totalWaysSS1 = NumberOfWays(s.Substring(1, s.Length - 1));

			foreach (var way in totalWaysSS1)
			{
				totalWays.Add(s.Substring(0, 1) + way);
			}

			if (codesDict.ContainsKey(s.Substring(0, 2)))
			{
				List<string> totalWaysSS2 = NumberOfWays(s.Substring(2, s.Length - 2));
				foreach (var way in totalWaysSS2)
				{
					totalWays.Add(s.Substring(0, 2) + way);
				}
			}

			cacheNOW.Add(s, totalWays);
			return totalWays;
		}

		private Dictionary<string, int> codesDict = new Dictionary<string, int>() {
		 {"0", 0 },
		 {"1", 1 },
		 {"2", 1 },
		 {"3", 1 },
		 {"4", 1 },
		 {"5", 1 },
		 {"6", 1 },
		 {"7", 1 },
		 {"8", 1 },
		 {"9", 1 },
		 {"10", 1 },
		 {"11", 2 },
		 {"12", 2 },
		 {"13", 2 },
		 {"14", 2 },
		 {"15", 2 },
		 {"16", 2 },
		 {"17", 2 },
		 {"18", 2 },
		 {"19", 2 },
		 {"20", 1 },
		 {"21", 2 },
		 {"22", 2 },
		 {"23", 2 },
		 {"24", 2 },
		 {"25", 2 },
		 {"26", 2 }
		};
		private Dictionary<string, int> cache = new Dictionary<string, int>();

		public int Count(string s)
		{
			if (string.IsNullOrEmpty(s) || s[0] == '0')
				return 0;

			if (codesDict.ContainsKey(s))
				return codesDict[s];

			if (cache.ContainsKey(s))
				return cache[s];

			int total = Count(s.Substring(1, s.Length - 1));
			if (codesDict.ContainsKey(s.Substring(0, 2)))
				total += Count(s.Substring(2, s.Length - 2));

			cache.Add(s, total);
			return total;
		}
	}
}
