using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;
using System.Collections.Generic;

namespace UnitTestProject
{
	[TestClass]
	public class BeatSnakesAndLaddersAMTests
	{
		[TestMethod]
		public void Test()
		{
			var beatSnakesAndLaddersAM = new BeatSnakesAndLaddersAM();
			var returnedValue = beatSnakesAndLaddersAM.SnakesAndLadders(new int[6][] {
			new int[6]{-1,-1,-1,-1,-1,-1},
			new int[6]{-1,-1,-1,-1,-1,-1},
			new int[6]{-1,-1,-1,-1,-1,-1},
			new int[6]{-1,35,-1,-1,13,-1},
			new int[6]{-1,-1,-1,-1,-1,-1},
			new int[6]{-1,15,-1,-1,-1,-1}
			});

			Assert.IsTrue(returnedValue == 4);
		}

		[TestMethod]
		public void Test2()
		{
			var beatSnakesAndLaddersAM = new BeatSnakesAndLaddersAM();
			var returnedValue = beatSnakesAndLaddersAM.SnakesAndLadders(new int[2][] {
				new int[2]{-1,-1},
				new int[2]{-1,3}
			});

			Assert.IsTrue(returnedValue == 1);
		}

		[TestMethod]
		public void Test3()
		{
			var beatSnakesAndLaddersAM = new BeatSnakesAndLaddersAM();
			var returnedValue = beatSnakesAndLaddersAM.SnakesAndLadders(new int[4][] {
				new int[4]{-1,1,2,-1},
				new int[4]{2,13,15,-1},
				new int[4]{-1,10,-1,-1},
				new int[4]{ -1, 6, 2, 8 }
			});

			Assert.IsTrue(returnedValue == 2);
		}

		[TestMethod]
		public void Test4()
		{
			var beatSnakesAndLaddersAM = new BeatSnakesAndLaddersAM();
			var returnedValue = beatSnakesAndLaddersAM.SnakesAndLadders(new int[7][] {
				new int[7]{-1,-1,27,13,-1,25,-1},
				new int[7]{-1,-1,-1,-1,-1,-1,-1},
				new int[7]{44,-1,8,-1,-1,2,-1},
				new int[7]{-1,30,-1,-1,-1,-1,-1},
				new int[7]{3,-1,20,-1,46,6,-1},
				new int[7]{-1,-1,-1,-1,-1,-1,29},
				new int[7]{-1,29,21,33,-1,-1,-1 }
			});

			Assert.IsTrue(returnedValue == 4);
		}
	}
}
