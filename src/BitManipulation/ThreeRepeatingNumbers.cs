using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class ThreeRepeatingNumbers
	{
		private int[] binaryRepresentation = new int[32];
		public int FindNonRepeatingNumber(int[] arr)
		{
			int returnValue = 0;

			foreach (var item in arr)
			{
				for (int i = 0; i < 32; i++)
				{
					binaryRepresentation[i] += ((1 << i) & item) > 0 ? 1 : 0;
				}
			}

			var returnValueBinaryRepresentation = new int[32];
			for (int i = 0; i < 32; i++)
			{
				if(!(binaryRepresentation[i]%3==0))
				{
					returnValue += Convert.ToInt32(Math.Pow(2, i));
				}
			}

			return returnValue;
		}
	}
}
