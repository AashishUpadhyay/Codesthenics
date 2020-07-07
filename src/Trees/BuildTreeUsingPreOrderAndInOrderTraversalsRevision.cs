using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class BuildTreeUsingPreOrderAndInOrderTraversalsRevision
    {
        public static TreeNode<T> BuildTree<T>(T[] preorder, T[] inorder)
        {
            if (!(inorder.Length == preorder.Length))
                throw new Exception("Invalid Operation!");

            if (inorder.Length == 0)
                throw new Exception("Empty Array!");

            if (preorder.Length == 1)
                return new TreeNode<T>()
                {
                    Value = inorder[0]
                };

            var root = inorder[0];
            var preOrderSubLeftTree = new List<T>();
            int i;
            for (i = 0; i < preorder.Length; i++)
            {
                if (root.Equals(preorder[i]))
                    break;
                else
                {
                    preOrderSubLeftTree.Add(preorder[i]);
                }
            }

            var preOrderSubRightTree = preorder.Skip(i + 1);

            var inorderSubLeftTree = inorder.Skip(1).Take(preOrderSubLeftTree.Count);
            var inorderSubRightTree = inorder.Skip(preOrderSubLeftTree.Count + 1);

            var leftNode = BuildTree<T>(preOrderSubLeftTree.ToArray(), inorderSubLeftTree.ToArray());
            var rightNode = BuildTree<T>(preOrderSubRightTree.ToArray(), inorderSubRightTree.ToArray());

            return new TreeNode<T>()
            {
                Value = inorder[0],
                LeftChild = leftNode,
                RightChild = rightNode
            };
        }
    }
}
