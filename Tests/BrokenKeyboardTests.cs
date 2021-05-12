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
	public class BrokenKeyboardTests
	{
		[TestMethod]
		public void Test1()
		{
			var bk = new BrokenKeyboard();
			var retVal = bk.ActualInputs("can s r n ", new List<string>() { "caneserene", "caneseren", "can", "canes", "serene", "rene", "sam", "s", "r", "n", "n " });
			var retValHS = retVal.ToHashSet();

			Assert.IsTrue(retValHS.Contains("caneserene"));
			Assert.IsTrue(retValHS.Contains("caneseren"));
			Assert.IsTrue(retValHS.Contains("can serene"));
			Assert.IsTrue(retValHS.Contains("canes rene"));
			Assert.IsTrue(retValHS.Contains("can s r n"));
			Assert.IsTrue(retValHS.Contains("can s r n "));
		}
	}
}
