using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class NumberOfWaysToClimbStaircase
	{
		public int CountUsingBruteForce(int totalSteps, int[] steps)
		{
			if (totalSteps < 0)
				return 0;

			if (totalSteps == 0)
				return 1;

			int returnVal = 0;
			for (int i = 0; i < steps.Length; i++)
				returnVal += CountUsingBruteForce(totalSteps - steps[i], steps);
			return returnVal;
		}

		private int[] cache;
		public int CountUsingDP(int totalSteps, int[] steps)
		{
			cache = new int[totalSteps + 1];
			return CountUsingDPPrivate(totalSteps, steps);
		}

		private int CountUsingDPPrivate(int totalSteps, int[] steps)
		{
			if (totalSteps < 0)
				return 0;

			if (totalSteps == 0)
				return 1;

			if (cache[totalSteps] != 0)
				return cache[totalSteps];

			int returnVal = 0;
			for (int i = 0; i < steps.Length; i++)
				returnVal += CountUsingDPPrivate(totalSteps - steps[i], steps);

			cache[totalSteps] = returnVal;
			return returnVal;
		}
	}
}
