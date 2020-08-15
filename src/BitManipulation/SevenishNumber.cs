using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class SevenishNumber
	{
		public int FindNthSevenishNumber(int n)
		{
			int pow = -1;
			int counter = 0;
			int powerValue = 0;
			while (counter < n)
			{
				for (int i = 0; i <= pow-1; i++)
				{
					counter++;
					int counterValue = powerValue + Convert.ToInt32(Math.Pow(7, i));
					if (counter == n)
						return counterValue;
				}

				counter++;
				pow++;
				powerValue = Convert.ToInt32(Math.Pow(7, pow));
			}

			return powerValue;
		}
	}
}
