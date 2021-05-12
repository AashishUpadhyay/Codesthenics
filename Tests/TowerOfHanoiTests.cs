using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems;

namespace Tests
{
	[TestClass]
	public class TowerOfHanoiTests
	{
		[TestMethod]
		public void TowerOfHanoiTest()
		{
			Test(0);
			Test(1);
			Test(5);
			Test(10);
		}

		private void Test(int n)
		{
			var source = new Stack<int>();

			for (int i = n; i >= 1; i--)
				source.Push(i);

			var intermediate = new Stack<int>();
			var target = new Stack<int>();

			var towerOfHanoi = new TowerOfHanoi();
			towerOfHanoi.Move(n, source, intermediate, target);

			Assert.IsTrue(source.Count == 0 && intermediate.Count == 0 && target.Count == n);

			for (int j = 1; j < n; j++)
				Assert.IsTrue(target.Pop() == j);
		}
	}
}
