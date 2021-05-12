using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class BuildAllBinarySearchTrees
    {
        public IList<TreeNode<int>> Build(int[] input)
        {
            var returnValue = new List<TreeNode<int>>();

            if (input.Length == 0)
                return returnValue;
            if (input.Length == 1)
            {
                returnValue.Add(new TreeNode<int>()
                {
                    Value = input[0]
                });
                return returnValue;
            }

            for (int i = 0; i < input.Length; i++)
            {
                var leftNodes = Build(input.Take(i).ToArray());
                var rightNodes = Build(input.Skip(i + 1).ToArray());

                if (leftNodes.Count > 0 && rightNodes.Count > 0)
                {
                    for (int j = 0; j < leftNodes.Count; j++)
                    {
                        for (int k = 0; k < rightNodes.Count; k++)
                        {
                            returnValue.Add(new TreeNode<int>()
                            {
                                Value = input[i],
                                LeftChild = leftNodes[j],
                                RightChild = rightNodes[k]
                            });
                        }
                    }
                }
                else if (leftNodes.Count > 0 || rightNodes.Count > 0)
                {
                    for (int j = 0; j < leftNodes.Count; j++)
                    {
                        returnValue.Add(new TreeNode<int>()
                        {
                            Value = input[i],
                            LeftChild = leftNodes[j]
                        });
                    }
            
                    for (int k = 0; k < rightNodes.Count; k++)
                    {
                        returnValue.Add(new TreeNode<int>()
                        {
                            Value = input[i],
                            RightChild = rightNodes[k]
                        });
                    }
                }
                else
                {
                    returnValue.Add(new TreeNode<int>()
                    {
                        Value = input[i]
                    });
                }
            }

            return returnValue;
        }
    }
}
