using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//[12,3,45,6,7,91,1]
namespace Problems
{
    public class BinarySearchTree
    {
        public TreeNode<int> Build(int[] input)
        {
            var root = new TreeNode<int>()
            {
                Value = input[0]
            };

            BuildInternal(input.Skip(1).ToArray(), root);
            return root;
        }

        private void BuildInternal(int[] input, TreeNode<int> root)
        {
            if (input.Length == 0)
                return;

            if (input[0] < root.Value)
            {
                if (root.LeftChild == null)
                    root.LeftChild = new TreeNode<int>() { Value = input[0] };
                else
                {
                    BuildInternal(new int[] {input[0]}, root.LeftChild);
                }
            }
            else
            {
                if (root.RightChild == null)
                    root.RightChild = new TreeNode<int>() { Value = input[0] };
                else
                {
                    BuildInternal(new int[] {input[0]}, root.RightChild);
                }
            }

            BuildInternal(input.Skip(1).ToArray(), root);
        }
    }
}
