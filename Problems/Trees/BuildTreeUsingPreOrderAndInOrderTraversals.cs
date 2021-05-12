using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class BuildTreeUsingPreOrderAndInOrderTraversals
    {
        public static TreeNode<T> BuildTree<T>(T[] preorder, T[] inorder)
        {
            if (preorder.Length != inorder.Length)
                throw new ArgumentException("Invalid Input!");

            var root = new TreeNode<T>()
            {
                Value = preorder[0]
            };

            if (preorder.Length == 1)
                return root;

            var i = 0;
            while (!inorder[i].Equals(root.Value))
                i++;

            root.LeftChild = BuildTree(preorder.Skip(1).Take(i).ToArray(), inorder.Skip(0).Take(i).ToArray());
            root.RightChild = BuildTree(preorder.Skip(i + 1).Take(preorder.Length - (i + 1)).ToArray(), inorder.Skip(i + 1).Take(preorder.Length - (i + 1)).ToArray());

            return root;
        }
    }
}
