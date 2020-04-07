using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class ValidateBinarySearchTree
    {
        int? _max;
        int? _min;
        public bool IsValidBST(TreeNode<int> root)
        {
            if ((root == null) || (root.LeftChild == null && root.RightChild == null))
                return true;

            var isValid = true;
            if (root.LeftChild != null)
            {
                isValid = IsValidBST(root.LeftChild);
                if (isValid)
                {
                    _max = int.MinValue;
                    isValid = TryFindMax(root.LeftChild) && root.Value > _max;
                }
            }

            if (isValid && root.RightChild != null)
            {
                isValid = IsValidBST(root.RightChild);
                if (isValid)
                {
                    _min = int.MaxValue;
                    isValid = TryFindMin(root.RightChild) && root.Value < _min;
                }

            }

            return isValid;
        }

        private bool IsValidSubtree(TreeNode<int> node)
        {
            if (node.LeftChild == null && node.RightChild == null)
                return true;

            if (node.LeftChild != null && node.RightChild != null && node.LeftChild.Value < node.Value && node.RightChild.Value > node.Value)
                return true;

            if ((node.LeftChild == null && node.RightChild.Value > node.Value) || (node.RightChild == null && node.LeftChild.Value < node.Value))
                return true;

            return false;
        }

        private bool TryFindMax(TreeNode<int> node)
        {
            if (!IsValidSubtree(node))
                return false;

            var isValid = true;
            if (!(node.LeftChild == null && node.RightChild == null))
            {
                if (node.LeftChild != null)
                    isValid = TryFindMax(node.LeftChild) && node.Value > _max;

                if (isValid && node.RightChild != null)
                    isValid = TryFindMax(node.RightChild);
            }

            if (node.Value > _max)
                _max = node.Value;

            return isValid;
        }

        private bool TryFindMin(TreeNode<int> node)
        {
            if (!IsValidSubtree(node))
                return false;

            var isValid = true;
            if (!(node.LeftChild == null && node.RightChild == null))
            {
                if (isValid && node.RightChild != null)
                    isValid = TryFindMin(node.RightChild) && node.Value < _min;

                if (node.LeftChild != null)
                    isValid = TryFindMin(node.LeftChild);
            }

            if (node.Value < _min)
                _min = node.Value;

            return isValid;
        }

        private bool isBSTHelper(TreeNode<int> node, int lower_limit, int upper_limit)
        {
            if (node == null)
            {
                return true;
            }
            if (node.Value <= lower_limit || upper_limit <= node.Value)
            {
                return false;
            }
            return isBSTHelper(node.LeftChild, lower_limit, node.Value) && isBSTHelper(node.RightChild, node.Value, upper_limit);
        }

        public bool IsValidBSTCompact(TreeNode<int> root)
        {
            return isBSTHelper(root, int.MinValue, int.MaxValue);
        }
    }
}
