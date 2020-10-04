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
	public class BeatSnakesAndLaddersTests
	{
		[TestMethod]
		public void FindMinimumMovesTest1()
		{
			var beatSnakesAndLadders = new BeatSnakesAndLadders();

			var snakes = new Dictionary<int, int>()
			{
				{ 17,13},
				{ 52,29},
				{ 57,40},
				{ 62,22},
				{ 88,18},
				{ 95,51},
				{ 97,79}
		 };

			var ladders = new Dictionary<int, int>()
			{
				{ 3,21},
				{ 8,30},
				{ 28,84},
				{ 58,77},
				{ 75,86},
				{ 80,100},
				{ 90,91}
		 };

			var returnedValue = beatSnakesAndLadders.SmallestNumberOfMoves(snakes, ladders);
			Assert.IsTrue(returnedValue == 6);
		}

		[TestMethod]
		public void FindMinimumMovesTest2()
		{
			var beatSnakesAndLadders = new BeatSnakesAndLadders();

			var snakes = new Dictionary<int, int>()
			{
				{ 17,7},
				{ 54,34},
				{ 62,19},
				{ 64,60},
				{ 87,36},
				{ 93,73},
				{ 95,75},
				{ 98,79}
		 };

			var ladders = new Dictionary<int, int>()
			{
				{1,38},
				{ 4,14},
				{ 9,31},
				{ 21,42},
				{ 28,84},
				{ 51,67},
				{ 72,91},
				{ 80,99}
		 };

			var returnedValue = beatSnakesAndLadders.SmallestNumberOfMoves(snakes, ladders);
			Assert.IsTrue(returnedValue == 7);
		}

		[TestMethod]
		public void FindMinimumMovesTest3()
		{
			var beatSnakesAndLadders = new BeatSnakesAndLadders();

			var snakesAndLadders = new Dictionary<int, int>()
			{
				{ 17,13},
				{ 52,29},
				{ 57,40},
				{ 62,22},
				{ 88,18},
				{ 95,51},
				{ 97,79},
				{ 3,21},
				{ 8,30},
				{ 28,84},
				{ 58,77},
				{ 75,86},
				{ 80,100},
				{ 90,91}
			 };

			var returnedValue = beatSnakesAndLadders.MinimumMoves(snakesAndLadders);
			Assert.IsTrue(returnedValue == 6);
		}

		[TestMethod]
		public void FindMinimumMovesTest4()
		{
			var beatSnakesAndLadders = new BeatSnakesAndLadders();

			var snakesAndLadders = new Dictionary<int, int>()
			{
				{ 17,7},
				{ 54,34},
				{ 62,19},
				{ 64,60},
				{ 87,36},
				{ 93,73},
				{ 95,75},
				{ 98,79},
				{1,38},
				{4,14},
				{9,31},
				{21,42},
				{28,84},
				{51,67},
				{72,91},
				{80,99}
			};

			var returnedValue = beatSnakesAndLadders.MinimumMoves(snakesAndLadders);
			Assert.IsTrue(returnedValue == 7);
		}

		[TestMethod]
		public void FindMinimumMovesTest5()
		{
			var beatSnakesAndLadders = new BeatSnakesAndLadders();

			var snakesAndLadders = new Dictionary<int, int>()
			{
				{ 17,13},
				{ 22,16},
				{ 52,29},
				{ 57,40},
				{ 62,22},
				{ 88,18},
				{ 95,51},
				{ 97,79},
				{ 3,21},
				{ 8,30},
				{ 18,99},
				{ 28,84},
				{ 58,77},
				{ 75,86},
				{ 80,100},
				{ 90,91}
			};

			var returnedValue = beatSnakesAndLadders.MinimumMoves(snakesAndLadders);
			Assert.IsTrue(returnedValue == 4);
		}
	}
}
