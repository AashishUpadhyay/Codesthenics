using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	//100
	//134
	public class StepsToOne
	{
		public int Calculate(string s)
		{
			int returnValue = 0;
			while (s != "1")
			{
				int lastDigit = Convert.ToInt32(s[s.Length - 1].ToString());
				string next;
				if ((lastDigit & 1) == 0)
				{
					next = Divide(s, 2)[0];
				}
				else
				{
					string remBy4 = Divide(s, 4)[1];
					if (s == "3" || remBy4 == "1")
					{
						next = MinusOne(s);
					}
					else
					{
						next = AddOne(s);
						if (next == "INVALID")
							next = MinusOne(s);
					}
				}
				returnValue++;
				s = next;
				Console.WriteLine(s);
			}

			return returnValue;
		}

		public string MinusOne(string s)
		{
			if (s == "1")
				return "0";

			StringBuilder sb = new StringBuilder();
			int borrow = 0;
			int prevBorrow = 0;
			for (int i = s.Length - 1; i >= 0; i--)
			{
				prevBorrow = borrow;
				borrow = 0;

				int num = Convert.ToInt32(s[i].ToString());

				if (num < prevBorrow)
				{
					borrow = 1;
					num = num + borrow * 10;
				}

				num = num - prevBorrow;
				prevBorrow = 0;

				int result;
				int toSubtract = 0;
				if (i == s.Length - 1)
					toSubtract = 1;

				if (num < toSubtract)
				{
					borrow = 1;
					num = num + borrow * 10;
				}

				result = num - toSubtract;

				if (!(result == 0 && i == 0))
					sb.Insert(0, result);
			}

			return sb.ToString();
		}

		public string AddOne(string s)
		{
			StringBuilder sb = new StringBuilder();
			int carry = 0;
			for (int i = s.Length - 1; i >= 0; i--)
			{
				int num = Convert.ToInt32(s[i].ToString());
				int result = 0;
				if (i == s.Length - 1)
					result = num + carry + 1;
				else
					result = num + carry;
				carry = result / 10;
				sb.Insert(0, result % 10);
			}
			if (carry > 0)
				sb.Insert(0, carry);

			if (sb.ToString().Length > 309)
				return "INVALID";
			return sb.ToString();
		}

		public string[] Divide(string s, int divisor)
		{
			StringBuilder sb = new StringBuilder();
			string num = string.Empty;
			int remainder = 0;
			for (int i = 0; i < s.Length; i++)
			{
				num = s[i].ToString();
				int numToInt = Convert.ToInt32(num) + 10 * remainder;

				if (numToInt == 0)
				{
					sb.Append(0);
					continue;
				}

				if (numToInt < divisor)
				{
					if (sb.Length > 0)
						sb.Append(0);
					remainder = numToInt;
					continue;
				}

				int result = numToInt / divisor;
				remainder = numToInt % divisor;
				sb.Append(result);
				num = string.Empty;
			}
			return new string[] { ((sb.ToString() == "") ? "0" : sb.ToString()), remainder.ToString() };
		}

		public int CalculateUsingInt(int s)
		{
			int returnValue = 0;
			int next = 0;
			while (s > 1)
			{
				if ((s & 1) == 0)
				{
					next = s / 2;
				}
				else
				{
					if (s == 3 || s % 4 == 1)
					{
						next = s - 1;
					}
					else
					{
						next = s + 1;
					}
				}
				returnValue++;
				s = next;
			}

			return returnValue;
		}
	}
}
