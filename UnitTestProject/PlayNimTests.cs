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
	public class PlayNimTests
	{
		[TestMethod]
		public void PlayNimTest()
		{
			var playNim = new PlayNim();
			Assert.IsTrue(playNim.CanWin(new int[] { 2, 1, 1 }));
			Assert.IsTrue(playNim.CanWin(new int[] { 1, 1, 2 }));
			Assert.IsTrue(playNim.CanWin(new int[] { 1, 2, 1 }));
			Assert.IsFalse(playNim.CanWin(new int[] { 1, 1, 1 }));
			Assert.IsFalse(playNim.CanWin(new int[] { 0, 0, 1 }));
			Assert.IsFalse(playNim.CanWin(new int[] { 0, 1, 0 }));
			Assert.IsFalse(playNim.CanWin(new int[] { 1, 0, 0 }));
			Assert.IsTrue(playNim.CanWin(new int[] { 3, 4, 5 }));
			Assert.IsTrue(playNim.CanWin(new int[] { 1, 2, 3 }));


			Assert.IsTrue(playNim.CanWin(new int[] { 3, 3, 3 }));
			Assert.IsFalse(playNim.CanWin(new int[] { 1, 3, 3 }));
		}
	}
}
