using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class TreeNode<T>
    {
        public T Value
        {
            get { return _fieldValue; }
            set
            {
                // operator== is undefined for generic T; EqualityComparer solves this
                if (!EqualityComparer<T>.Default.Equals(_fieldValue, value))
                {
                    _fieldValue = value;
                }
            }
        }

        private T _fieldValue;
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }

    }
}
