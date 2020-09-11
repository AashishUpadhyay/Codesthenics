using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class MinimumCostForTickets
	{
		private int[] _costs;
		private int[] _validity;
		private int[] _days;
		private int _minCost;
		public int MincostTickets(int[] days, int[] costs)
		{
			_costs = costs;

			_validity = new int[costs.Length];
			_validity[0] = 1;
			_validity[1] = 7;
			_validity[2] = 30;

			_days = days;
			_minCost = Int32.MaxValue;

			MincostTicketsPrivate(0, 0, 0);
			return _minCost;
		}

		private void MincostTicketsPrivate(int ni, int validity, int costSoFar)
		{
			if (costSoFar > _minCost)
				return;

			if (ni > _days.Length - 1)
			{
				if (costSoFar < _minCost)
				{
					_minCost = costSoFar;
				}

				return;
			}

			int remValidity = validity - _days[ni];

			if (remValidity >= 0)
				MincostTicketsPrivate(ni + 1, validity, costSoFar);
			else
			{
				for (int i = 0; i < _costs.Length; i++)
				{
					MincostTicketsPrivate(ni + 1, _days[ni] + _validity[i] - 1, costSoFar + _costs[i]);
				}
			}
		}

		private int[] _dp;
		private HashSet<int> _travelDays;
		public int MincostTicketsDP(int[] days, int[] costs)
		{
			if (days.Length == 0)
				return 0;

			_costs = costs;
			_validity = new int[costs.Length];
			_validity[0] = 1;
			_validity[1] = 7;
			_validity[2] = 30;

			_travelDays = new HashSet<int>(days);

			_dp = new int[days[days.Length - 1] + 1];
			return dp(days[days.Length - 1]);
		}

		private int dp(int day)
		{
			if (day < 1)
				return 0;

			if (_dp[day] == 0)
			{
				if (_travelDays.Contains(day))
					_dp[day] = Math.Min(Math.Min(dp(day - _validity[0]) + _costs[0], dp(day - _validity[1]) + _costs[1]), dp(day - _validity[2]) + _costs[2]);
				else
					_dp[day] = dp(day - 1);
			}
			return _dp[day];
		}
	}
}
