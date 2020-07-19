using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codesthenics;

namespace UnitTestProject
{
	[TestClass]
	public class DjikstraTests
	{
		[TestMethod]
		public void Test1()
		{
			var dj = new Djikstra();
			var returedVal = dj.FindMinimum(new int[6][] {
			new int[3]{0,1,5},
			new int[3]{0,5,4},
			new int[3]{0,2,3},
			new int[3]{2,3,1},
			new int[3]{3,4,5},
			new int[3]{3,5,10}
			});
			Assert.IsTrue(returedVal == 9);
		}

		[TestMethod]
		public void Test2()
		{
			var dj = new Djikstra();
			var returedVal = dj.FindMinimum(new int[6][] {
			new int[3]{0,1,5},
			new int[3]{0,5,4},
			new int[3]{0,2,3},
			new int[3]{2,3,12},
			new int[3]{3,4,5},
			new int[3]{3,5,10}
			});
			Assert.IsTrue(returedVal == 20);
		}

		[TestMethod]
		public void Test3()
		{
			var dj = new Djikstra();
			var returedVal = dj.FindMinimum(new int[8][] {
			new int[3]{0,1,5},
			new int[3]{0,5,4},
			new int[3]{0,2,3},
			new int[3]{1,3,1},
			new int[3]{2,3,12},
			new int[3]{3,4,5},
			new int[3]{4,3,1},
			new int[3]{3,5,10}
			});
			Assert.IsTrue(returedVal == 11);
		}

		[TestMethod]
		public void Test4()
		{
			var dj = new Djikstra();
			var returedVal = dj.FindMinimum(new int[2][] {
			new int[3]{0,1,5},
			new int[3]{1,0,4}
			});
			Assert.IsTrue(returedVal == 5);
		}
	}
}
