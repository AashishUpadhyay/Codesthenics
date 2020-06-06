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

		private int FindGreatest(int[][] numbers)
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

		private int BuildGreatestNumber(int[] items)
		{
			var returnValue = 0;
			Sort(items, 0, items.Length - 1);

			var mupFac = 1;
			for (int i = 0; i < items.Length; i++)
			{
				returnValue += items[i] * mupFac;
				mupFac = mupFac * 10;
			}
			return returnValue;
		}

		private int[][] Selection(int[] numbers, int bi, int selection)
		{
			if (selection == 0)
				return new int[0][];

			var total = numbers.Length - bi;
			var maxSelections = GetMaxSelections(total, selection);
			var returnValue = new int[maxSelections][];


			var si = 0;
			for (int i = bi; i <= numbers.Length - selection; i++)
			{
				var selections = Selection(numbers, i + 1, selection - 1);

				if (!(selections.Length > 0))
				{
					returnValue[si] = new int[] { numbers[i] };
					si++;
				}
				else
				{
					foreach (var item in selections)
					{
						var ns = new int[selection];
						for (int j = 0; j < item.Length; j++)
							ns[j] = item[j];
						ns[ns.Length - 1] = numbers[i];
						returnValue[si] = ns;
						si++;
					}
				}
			}

			return returnValue;
		}

		private int GetMaxSelections(int total, int selection)
		{
			return (Factorial(total)) / (Factorial(selection) * Factorial(total - selection));
		}

		private void Sort(int[] arr, int lb, int ub)
		{
			if (ub < 0 || lb >= ub)
				return;

			int pivot = arr[lb];
			int m = lb + 1;
			int n = ub;
			while (m <= n)
			{
				if (arr[m] <= pivot)
					m++;
				else if (arr[n] >= pivot)
					n--;
				else
				{
					int temp = arr[m];
					arr[m] = arr[n];
					arr[n] = temp;
				}
			}

			int temp1 = arr[n];
			if (pivot > temp1)
			{
				arr[n] = pivot;
				arr[lb] = temp1;
			}

			Sort(arr, lb, n - 1);
			Sort(arr, n + 1, ub);
		}

		private int Factorial(int f)
		{
			if (f == 0)
				return 1;
			else
				return f * Factorial(f - 1);
		}
	}
}
