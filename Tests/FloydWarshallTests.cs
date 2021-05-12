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
	public class FloydWarshallTests
	{
		[TestMethod]
		public void Test1()
		{
			var fw = new FloydWarshall();
			var returedVal = fw.BuildGraph(new int[2][] {
			new int[3]{0,1,2},
			new int[3]{1,2,3},
			}, 3);
			Assert.IsTrue(returedVal[0][1] == 2);
			Assert.IsTrue(returedVal[0][2] == 5);
			Assert.IsTrue(returedVal[1][2] == 3);
		}

		[TestMethod]
		public void Test2()
		{
			var fw = new FloydWarshall();
			var returedVal = fw.BuildGraph(new int[6][] {
			new int[3]{0,1,5},
			new int[3]{0,5,4},
			new int[3]{0,2,3},
			new int[3]{2,3,1},
			new int[3]{3,4,5},
			new int[3]{3,5,10}
			}, 6);
			Assert.IsTrue(returedVal[0][3] == 4);
			Assert.IsTrue(returedVal[0][4] == 9);
			Assert.IsTrue(returedVal[0][5] == 4);
		}
	}
}
