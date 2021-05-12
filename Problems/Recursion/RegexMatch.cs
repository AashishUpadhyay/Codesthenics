using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	/// <summary>
	/// . (period) single character match
	/// * (asterisk) 0 or one character match
	/// </summary>
	public class RegexMatch
	{
		public bool IsAMatch(string exp, string input)
		{
			return IsAMatch(exp, input, 0, 0);
		}

		private bool IsAMatch(string exp, string input, int ri, int si)
		{
			if (ri > exp.Length || si > input.Length)
				return false;

			if ((ri == exp.Length && si == input.Length) || (ri + 1 == exp.Length && exp[ri] == '*'))
				return true;

			if (ri < exp.Length && si < input.Length)
			{
				if ((exp[ri] == input[si] || exp[ri] == '.'))
					return IsAMatch(exp, input, ri + 1, si + 1);
				else if (exp[ri] == '*')
				{
					if ((exp[ri + 1] == input[si] || exp[ri + 1] == '*'))
						return IsAMatch(exp, input, ri + 1, si);
					else
						return IsAMatch(exp, input, ri, si + 1);
				}
			}
			return false;
		}
	}
}
