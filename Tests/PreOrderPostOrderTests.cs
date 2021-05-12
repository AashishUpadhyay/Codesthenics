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
	public class PreOrderPostOrderTests
	{
		[TestMethod]
		public void PreOrderPostOrderTest()
		{
			var prpo = new PreOrderPostOrder();
			var received = prpo.Build(new int[7] { 1, 2, 4, 5, 3, 6, 7 }, new int[7] { 4, 5, 2, 6, 7, 3, 1 });
			var expected = new TreeNode<int>()
			{
				Value = 1,
				LeftChild = new TreeNode<int>()
				{
					Value = 2,
					LeftChild = new TreeNode<int>()
					{
						Value = 4
					},
					RightChild = new TreeNode<int>()
					{
						Value = 5
					}
				},
				RightChild = new TreeNode<int>()
				{
					Value = 3,
					LeftChild = new TreeNode<int>()
					{
						Value = 6
					},
					RightChild = new TreeNode<int>()
					{
						Value = 7
					}
				}
			};
			Assert.IsTrue(Utility.CompareTrees(received, expected));
		}

		[TestMethod]
		public void PreOrderPostOrderTest1()
		{
			var prpo = new PreOrderPostOrder();
			var received = prpo.Build(new int[3] { 1, 2, 3 }, new int[3] { 2, 3, 1 });
			var expected = new TreeNode<int>()
			{
				Value = 1,
				LeftChild = new TreeNode<int>()
				{
					Value = 2
				},
				RightChild = new TreeNode<int>()
				{
					Value = 3
				}
			};
			Assert.IsTrue(Utility.CompareTrees(received, expected));
		}

		[TestMethod]
		public void PreOrderPostOrderTest2()
		{
			var prpo = new PreOrderPostOrder();
			var received = prpo.Build(new int[3] { 1, 2, 3 }, new int[3] { 2, 3, 1 });
			var expected = new TreeNode<int>()
			{
				Value = 1,
				LeftChild = new TreeNode<int>()
				{
					Value = 2
				},
				RightChild = new TreeNode<int>()
				{
					Value = 3
				}
			};
			Assert.IsTrue(Utility.CompareTrees(received, expected));
		}

		[TestMethod]
		public void PreOrderPostOrderTest3()
		{
			var prpo = new PreOrderPostOrder();
			var received = prpo.Build(new int[2] { 1, 2 }, new int[2] { 2, 1 });
			var expected = new TreeNode<int>()
			{
				Value = 1,
				LeftChild = new TreeNode<int>()
				{
					Value = 2
				}
			};
			Assert.IsTrue(Utility.CompareTrees(received, expected));
		}

		[TestMethod]
		public void PreOrderPostOrderTest4()
		{
			var prpo = new PreOrderPostOrder();
			var received = prpo.Build(new int[1] { 1 }, new int[1] { 1 });
			var expected = new TreeNode<int>()
			{
				Value = 1
			};
			Assert.IsTrue(Utility.CompareTrees(received, expected));
		}
	}
}
