using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class CoinChange
	{
		private int[] _coins;
		private int[] _dp;

		public int BruteForce(int[] coins, int amount)
		{
			_coins = coins;
			_dp = new int[amount + 1];
			for (int i = 1; i < _dp.Length; i++)
				_dp[i] = amount + 1;
			if (!BruteForcePrivate(amount))
				return -1;
			return _dp[amount];
		}

		private bool BruteForcePrivate(int amount)
		{
			if (amount == 0)
				return true;

			if (amount < 0)
				return false;

			bool returnValue = false;
			for (int i = 0; i < _coins.Length; i++)
			{
				int remainingAmt = amount - _coins[i];
				if (remainingAmt >= 0 && BruteForcePrivate(remainingAmt))
				{
					_dp[amount] = Math.Min(_dp[amount], _dp[remainingAmt] + 1);
					returnValue = true;
				}
			}

			return returnValue;
		}

		public int BottomUp(int[] coins, int amount)
		{
			if (coins.Length == 0)
				return -1;

			int[] dp = new int[amount + 1];
			for (int i = 1; i < dp.Length; i++)
				dp[i] = amount + 1;

			for (int i = 0; i < coins.Length; i++)
			{
				for (int j = 1; j <= amount; j++)
				{
					if (coins[i] <= j)
					{
						dp[j] = Math.Min(dp[j - coins[i]] + 1, dp[j]);
					}
				}
			}
			return dp[amount] > amount ? -1 : dp[amount];
		}

		public int TopDown(int[] coins, int amount)
		{
			_dp = new int[amount + 1];
			for (int i = 1; i < _dp.Length; i++)
				_dp[i] = amount + 1;
			_coins = coins;
			if (!TopDownPrivate(amount))
				return -1;
			return _dp[amount];
		}

		private bool TopDownPrivate(int amount)
		{
			if (amount == 0)
				return true;

			if (amount < 0 || _dp[amount] < 0)
				return false;

			if (_dp[amount] < amount + 1)
				return true;

			bool returnValue = false;
			foreach (var coin in _coins)
			{
				int remainingAmt = amount - coin;
				if (TopDownPrivate(remainingAmt))
				{
					_dp[amount] = Math.Min(_dp[amount], _dp[remainingAmt] + 1);
					returnValue = true;
				}
			}

			if (!returnValue)
				_dp[amount] = -1;

			return returnValue;
		}

		public int TopDownLC(int[] coins, int amount)
		{
			if (amount < 1) return 0;
			return TopDownLCPrivate(coins, amount, new int[amount]);
		}

		private int TopDownLCPrivate(int[] coins, int rem, int[] count)
		{
			if (rem < 0) return -1;
			if (rem == 0) return 0;
			if (count[rem - 1] != 0) return count[rem - 1];
			int min = Int32.MaxValue;
			foreach(var coin in coins)
			{
				int res = TopDownLCPrivate(coins, rem - coin, count);
				if (res >= 0 && res < min)
					min = 1 + res;
			}
			count[rem - 1] = (min == Int32.MaxValue) ? -1 : min;
			return count[rem - 1];
		}
	}
}
