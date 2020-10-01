using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class PreOrderPostOrder
	{
		public TreeNode<int> Build(int[] pre, int[] post)
		{
			if (pre.Length != post.Length || pre.Length == 0)
				return null;

			TreeNode<int> returnValue = new TreeNode<int>();
			if (pre.Length == 1)
			{
				returnValue.Value = pre[0];
				return returnValue;
			}

			List<int> leftPre = new List<int>();
			List<int> leftPost = new List<int>();
			List<int> rightPre = new List<int>();
			List<int> rightPost = new List<int>();

			int root = pre[0];
			int leftNode = pre[1];
			bool buildLeftPost = true;
			bool buildRightPost = false;
			for (int i = 0; i < post.Length - 1; i++)
			{
				if (buildLeftPost)
				{
					leftPost.Add(post[i]);
					if (post[i] == leftNode)
					{
						buildLeftPost = false;
						buildRightPost = true;
						continue;
					}
				}

				if (buildRightPost)
					rightPost.Add(post[i]);
			}

			for (int i = 1; i < pre.Length; i++)
			{
				if (leftPre.Count() < leftPost.Count())
				{
					leftPre.Add(pre[i]);
					continue;
				}

				if (rightPre.Count() < rightPost.Count())
					rightPre.Add(pre[i]);
			}

			return new TreeNode<int>()
			{
				Value = root,
				LeftChild = Build(leftPre.ToArray(), leftPost.ToArray()),
				RightChild = Build(rightPre.ToArray(), rightPost.ToArray())
			};
		}
	}
}
