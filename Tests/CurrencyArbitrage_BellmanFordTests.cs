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
	public class CurrencyArbitrage_BellmanFordTests
	{
		[TestMethod]
		public void Test1()
		{
			var ca_bt = new CurrencyArbitrage_BellmanFord();
			var input = new double[4][] {
			new double[4]{0,.77,71.71,.87},
			new double[4]{1.3,0,93.55,1.14},
			new double[4]{.014,.011,0,.012},
			new double[4]{1.14,.88,81.95,0}
			};
			ca_bt.IsPossible(input);
			Assert.IsTrue(ca_bt.IsPossible(input));
		}

		[TestMethod]
		public void Test2()
		{
			var ca_bt = new CurrencyArbitrage_BellmanFord();
			var input = new double[4][] {
			new double[4]{0,.77,.71,.87},
			new double[4]{.3,0,.55,.14},
			new double[4]{.014,.011,0,.012},
			new double[4]{.14,.88,.95,0}
			};
			ca_bt.IsPossible(input);
			Assert.IsTrue(ca_bt.IsPossible(input) == false);
		}
	}
}

