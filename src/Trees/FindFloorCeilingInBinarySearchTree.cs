using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//[12,3,45,6,7,91,1]
namespace Codesthenics
{
    public class FindFloorCeilingInBinarySearchTree
    {
        public FloorCeiling Find(TreeNode<int> root, int input)
        {
            var returnValue = new FloorCeiling()
            {
                Ceiling = int.MaxValue,
                Floor = int.MinValue
            };

            FindInternal(root, input, returnValue);
            return returnValue;
        }

        private void FindInternal(TreeNode<int> root, int input, FloorCeiling returnValue)
        {
            if (input >= root.Value)
            {
                if (returnValue.Floor < root.Value)
                    returnValue.Floor = root.Value;

                if (root.RightChild != null)
                    FindInternal(root.RightChild, input, returnValue);
            }
            else
            {
                if (returnValue.Ceiling > root.Value)
                    returnValue.Ceiling = root.Value;

                if (root.LeftChild != null)
                    FindInternal(root.LeftChild, input, returnValue);
            }
        }

        public class FloorCeiling
        {
            public int Floor { get; set; }
            public int Ceiling { get; set; }

        }
    }
}
