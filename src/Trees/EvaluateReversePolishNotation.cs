using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class EvaluateReversePolishNotation
    {
        private HashSet<string> _operators;
        private string[] _tokens;
        private const string NULL_REP = "NULL";
        private int treeTraversalIndex;
        public int EvalRPN(string[] tokens)
        {
            _operators = new HashSet<string>(new List<string>() { "+", "-", "*", "/" });
            _tokens = tokens;
            treeTraversalIndex = _tokens.Length - 1;
            var tree = BuildTree();
            string returnedValue = EvalRPNInternal(tree);

            int returnVal;
            if (!int.TryParse(returnedValue, out returnVal))
                return 0;

            return returnVal;
        }

        private string EvalRPNInternal(TreeNode node)
        {
            if (node == null)
                return NULL_REP;

            string left = EvalRPNInternal(node.left);
            string right = EvalRPNInternal(node.right);

            if (left != NULL_REP && right != NULL_REP)
            {
                int leftVal = Convert.ToInt32(left);
                int rightVal = Convert.ToInt32(right);
                int result = 0;

                switch (node.val)
                {
                    case "+":
                        result = leftVal + rightVal;
                        break;
                    case "-":
                        result = leftVal - rightVal;
                        break;
                    case "*":
                        result = leftVal * rightVal;
                        break;
                    case "/":
                        result = leftVal / rightVal;
                        break;
                    default:
                        return NULL_REP;
                }
                return Convert.ToString(result);
            }
            else
                return node.val;
        }

        private TreeNode BuildTree()
        {
            if (treeTraversalIndex < 0)
                return null;

            TreeNode returnValue = new TreeNode();
            if (_operators.Contains(_tokens[treeTraversalIndex]))
            {
                returnValue.val = _tokens[treeTraversalIndex];
                treeTraversalIndex--;
                returnValue.right = BuildTree();
                treeTraversalIndex--;
                returnValue.left = BuildTree();
            }
            else
                returnValue.val = _tokens[treeTraversalIndex];

            return returnValue;
        }

        class TreeNode
        {
            public string val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }
    }
}
