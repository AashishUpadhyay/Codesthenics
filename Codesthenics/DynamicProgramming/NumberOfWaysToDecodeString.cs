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
		private char[] codes;
		public NumberOfWaysToDecodeString()
		{
			codes = new char[27];
			for (int i = 1; i <= 26; i++)
				codes[i] = Convert.ToChar(96 + i);
		}
		private Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();

		public List<string> NumberOfWays(string s)
		{
			if (string.IsNullOrEmpty(s))
				return new List<string>();

			if (dict.ContainsKey(s))
				return dict[s].ToList();

			var decodedString = new HashSet<string>();
			var maxIndex = Math.Min(2, s.Length);
			for (int i = 0; i < maxIndex; i++)
			{
				var startString = s.Substring(0, i + 1);
				var ways = new List<string>();

				if (s.Length > i + 1)
					ways = NumberOfWays(s.Substring(i + 1, s.Length - (i + 1)));

				var startStringToInt = Convert.ToInt32(startString);
				if (startStringToInt > 26)
					continue;

				var c = codes[startStringToInt];
				if (ways.Count() > 0)
				{
					foreach (var way in ways)
					{
						var ns = c.ToString() + way;
						decodedString.Add(ns);
					}
				}
				else
					decodedString.Add(c.ToString());
			}

			dict.Add(s, decodedString.ToList());
			return decodedString.ToList();
		}
	}
}
