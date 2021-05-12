using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class CoinWays
	{
		private long?[] dict;

		private void Initialize(int n)
		{
			if (dict == null)
			{
				dict = new long?[n + 1];
				dict[0] = 1;
			}
		}

		public long NumberOfWays(int n, int[] coins)
		{
			Initialize(n);

			if (n < 0)
				return 0;

			if (dict[n] != null)
				return dict[n].Value;

			long returnValue = 0;
			foreach (var coin in coins)
				returnValue += NumberOfWays(n - coin, coins);

			dict[n] = returnValue;
			return returnValue;
		}

		public long NumberOfWaysBottomUp(int n, int[] coins)
		{
			Initialize(n);

			for (int i = 1; i <= n; i++)
			{
				long ways = 0;
				foreach (var coin in coins)
					ways += GetValue(i - coin);

				dict[i] = ways;
			}

			return dict[n].Value;
		}

		private long GetValue(int v)
		{
			if (v >= 0)
				return dict[v].Value;

			return 0;
		}
	}
}
