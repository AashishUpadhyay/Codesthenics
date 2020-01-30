using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class ComputingRunningMedian
    {
        public double[] CalculateRunningMedian(double[] input)
        {
            var returnValue = new double[input.Length];

            if (input.Length == 0)
                return returnValue;

            var heap = new Heap<double>();
            for (int i = 0; i < input.Length; i++)
            {
                heap.Push(input[i]);
                var heapItemsCopy = new double[heap.Length];
                heap.GetAll().CopyTo(heapItemsCopy, 0);
                var heapCopy = new Heap<double>(heapItemsCopy.ToList());
                returnValue[i] = CalculateMedian(heapCopy);
            }

            return returnValue;
        }

        private double CalculateMedian(Heap<double> heapCopy)
        {
            int heapCount = heapCopy.Length;
            int medianIndex = heapCount / 2;
            int popIndexCounter = 0;
            double medianValue = 0;

            if (heapCount % 2 == 0)
            {
                while (popIndexCounter <= medianIndex)
                {
                    var value = heapCopy.Pop();
                    if (popIndexCounter == medianIndex - 1 || popIndexCounter == medianIndex)
                        medianValue += value;
                    popIndexCounter++;
                }

                return medianValue / 2;
            }
            else
            {
                while (popIndexCounter <= medianIndex)
                {
                    var value = heapCopy.Pop(); ;
                    if (popIndexCounter == medianIndex)
                        medianValue += value;
                    popIndexCounter++;
                }

                return medianValue;
            }
        }
    }
}
