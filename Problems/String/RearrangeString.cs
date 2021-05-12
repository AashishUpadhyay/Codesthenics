using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
	public class RearrangeString
	{
		private char[] charArr = new char[26]
		{
			'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
		};

		public string ReorganizeString(string S)
		{
			int[] arr = new int[26];
			foreach (var c in S)
				arr[c - 97] += 1;

			var sortedList = new SortedList<int, List<int>>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] > 0)
				{
					if (!sortedList.ContainsKey(arr[i]))
						sortedList.Add(arr[i], new List<int>());

					sortedList[arr[i]].Add(i);
				}
			}

			var sb = new StringBuilder();
			while (sortedList.Count() > 0)
			{
				var items = new int[2][];

				items[0] = FetchItem(sortedList);
				items[1] = FetchItem(sortedList);

				if (items[0] != null)
				{
					sb.Append(charArr[items[0][1]]);
					AddToList(sortedList, items[0]);
				}

				if (items[1] != null)
				{
					sb.Append(charArr[items[1][1]]);
					AddToList(sortedList, items[1]);
				}
			}

			return IsValidString(sb.ToString()) ? sb.ToString() : "";
		}

		private bool IsValidString(string S)
		{
			for (int i = 1; i < S.Length; i++)
			{
				if (S[i] == S[i - 1])
					return false;
			}
			return true;
		}

		private int[] FetchItem(SortedList<int, List<int>> sortedList)
		{
			if (sortedList.Count() == 0)
				return null;

			var retVal = new int[2] { sortedList.Keys[0], sortedList.Values[0][0] };

			if (sortedList.Values[0].Count == 1)
				sortedList.RemoveAt(0);
			else
				sortedList.Values[0].RemoveAt(0);

			return retVal;
		}

		private void AddToList(SortedList<int, List<int>> sortedList, int[] item)
		{
			if (item[0] > 1)
			{
				if (!sortedList.ContainsKey(item[0] - 1))
					sortedList.Add((item[0] - 1), new List<int>());

				sortedList[(item[0] - 1)].Add(item[1]);
			}
		}
	}
}
