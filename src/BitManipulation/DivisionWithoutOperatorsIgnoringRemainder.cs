using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class DivisionWithoutOperatorsIgnoringRemainder
	{
		public int Quotient(int dividend, int divisor)
		{
			int returnValue = 0;

			int rem = dividend;
			while (rem >= divisor)
			{
				int q = QuotientPrivate(rem, divisor);
				rem = rem - (divisor * q);
				returnValue += q;
			}

			return returnValue;
		}

		private int QuotientPrivate(int rem, int divisor)
		{
			int index = 1;
			while (divisor * Convert.ToInt32(Math.Pow(2, index)) <= rem)
				index++;
			return Convert.ToInt32(Math.Pow(2, index-1));
		}
	}
}
