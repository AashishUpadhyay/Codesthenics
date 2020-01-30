using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    class ProductOfAllOtherElements
    {
        public static int[] GetProductOfAllOtherElements(int[] inputArr)
        {
            if (inputArr.Length == 0)
                throw new ArgumentException("Invalid Input");

            var product_prefix = new int[inputArr.Length];
            var product_suffix = new int[inputArr.Length];
            var returnValue = new int[inputArr.Length];

            var product = 1;
            for (int i = 0; i < inputArr.Length; i++)
            {
                product = product_prefix[i] = inputArr[i] * product;
            }

            product = 1;

            for (int i = inputArr.Length - 1; i > 0; i--)
            {
                product = product_suffix[i] = inputArr[i] * product;
            }

            for (int i = 0; i < returnValue.Length; i++)
            {
                if (i == 0)
                    returnValue[i] = product_suffix[i + 1];
                else if (i == returnValue.Length - 1)
                    returnValue[i] = product_prefix[i - 1];
                else
                    returnValue[i] = product_prefix[i - 1] * product_suffix[i + 1];
            }

            return returnValue;
        }
    }
}
