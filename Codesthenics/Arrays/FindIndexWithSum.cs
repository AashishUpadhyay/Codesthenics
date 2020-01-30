using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class FindIndexWithSum
    {
        public int Find(int[] inputArr, int sumValue)
        {
            bool found = false;
            int sumSoFar = 0;
            int i = inputArr.Length - 1;
            int lastResetIndex = i;

            for (; i >= 0; i--)
            {
                sumSoFar += inputArr[i];

                if (sumSoFar > sumValue)
                {
                    i = lastResetIndex - 1;
                    sumSoFar = inputArr[i];
                    lastResetIndex = i;
                }

                if (sumSoFar == sumValue)
                {
                    found = true;
                    break;
                }
            }

            if (found)
                return i;

            return -1;
        }
    }
}
