using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class MyCalender
	{
		private IList<int[]> _slots;
		public MyCalender()
		{
			_slots = new List<int[]>();
		}

		public bool Book(int start, int end)
		{
			int[] slot = new int[2] { start, end };

			if (_slots.Count() == 0)
				_slots.Add(slot);

			int si;
			int ei;

			if(!StartsOverlap(slot, si) && !EndsOverlap(slot, si))
			{
				if (si != ei)
					return false;
			}

			return true;
		}
	}
}
