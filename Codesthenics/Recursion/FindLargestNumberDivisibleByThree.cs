using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class FindLargestNumberDivisibleByThree
	{
		public int Number(int[] numbers)
		{
			for (int i = numbers.Length; i > 0; i--)
			{
				var selections = Selection(numbers, 0, i);
				var greatestNumber = FindGreatest(selections);
				if (greatestNumber > 0)
					return greatestNumber;
			}

			return 0;
		}

		private int FindGreatest(IList<IList<int>> numbers)
		{
			var returnValue = 0;
			foreach (var item in numbers)
			{
				var sum = 0;
				foreach (var num in item)
				{
					sum += num;
				}
				if (sum % 3 == 0)
				{
					var greatestNumber = BuildGreatestNumber(item);
					if (greatestNumber > returnValue)
						returnValue = greatestNumber;
				}
			}
			return returnValue;
		}

		private int BuildGreatestNumber(IList<int> item)
		{
			var returnValue = 0;
			var sortedItems = item.ToList().OrderBy(u => u).ToList();

			var mupFac = 1;
			for (int i = 0; i < sortedItems.Count(); i++)
			{
				returnValue += sortedItems[i] * mupFac;
				mupFac = mupFac * 10;
			}
			return returnValue;
		}

		private IList<IList<int>> Selection(int[] numbers, int bi, int selection)
		{
			var returnValue = new List<IList<int>>();

			if (selection == 0)
				return returnValue;


			for (int i = bi; i <= numbers.Length - selection; i++)
			{
				var selections = Selection(numbers, i + 1, selection - 1);

				if (!(selections.Count > 0))
				{
					returnValue.Add(new List<int>() { numbers[i] });
				}
				else
				{
					foreach (var item in selections)
					{
						item.Add(numbers[i]);
						returnValue.Add(item);
					}
				}
			}

			return returnValue;
		}
	}
}
