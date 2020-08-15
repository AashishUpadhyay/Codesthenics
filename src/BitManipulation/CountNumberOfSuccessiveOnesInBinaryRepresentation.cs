using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class CountNumberOfSuccessiveOnesInBinaryRepresentation
	{
		public int Count(int num)
		{
			int returnValue = 0;
			int counter = 0;
			while(num>0)
			{
				if ((num & 1) == 0)
					counter = 0;
				else
				{
					counter++;
					if (returnValue < counter)
						returnValue = counter;
				}
				num = num >> 1;
			}

			return returnValue;
		}
	}
}
