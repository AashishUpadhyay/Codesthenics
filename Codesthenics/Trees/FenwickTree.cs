using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    /// <summary>
    /// Reference 
    /// https://notes.tweakblogs.net/blog/9835/fenwick-trees-demystified.html
    /// </summary>
    public class FenwickTree
    {
        public int[] Create(int[] input)
        {
            var returnValue = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                Update(i, input[i], returnValue);
            }
            return returnValue;
        }

        public void Update(int index, int value, int[] target)
        {
            while (index < target.Length)
            {
                target[index] += value;
                index |= index + 1;
            }
        }

        public int Query(int count, int[] target)
        {
            var returnValue = 0;
            while (count > 0)
            {
                returnValue += target[count - 1];
                count &= count - 1;
            }
            return returnValue;
        }
    }
}
