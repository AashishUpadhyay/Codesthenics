using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class ZigzagLevelOrderTraversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode<int> root)
        {
            if (root == null)
                return new List<IList<int>>();

            var levelOrderedNodeItems = new List<LinkedList<int>>();
            BuildLevelOrder(root, 0, levelOrderedNodeItems, false);

            var returnValue = new List<IList<int>>();
            levelOrderedNodeItems.ForEach(u =>
            {
                returnValue.Add(u.ToList());
            });
            return returnValue;
        }

        private void BuildLevelOrder(TreeNode<int> root, int level, List<LinkedList<int>> levelOrderTraversalList, bool addFirst)
        {
            if (root == null)
                return;

            if (!(levelOrderTraversalList.Count() > level))
                levelOrderTraversalList.Add(new LinkedList<int>());

            if (addFirst)
                levelOrderTraversalList[level].AddFirst(root.Value);
            else
                levelOrderTraversalList[level].AddLast(root.Value);

            BuildLevelOrder(root.LeftChild, level + 1, levelOrderTraversalList, !addFirst);
            BuildLevelOrder(root.RightChild, level + 1, levelOrderTraversalList, !addFirst);
        }
    }
}
