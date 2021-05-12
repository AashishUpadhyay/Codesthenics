using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class CalculateApplesBetweenPeopleWhenTotalApplesAndDifferenceOfAppleIsKnownTheInputIsReallyHuge
    {
        public static void Calculate()
        {
            Console.WriteLine("Enter total apples and difference in apples!");
            CalculateAndPrintApplesWithGiaAndMaddie();
        }

        private static void CalculateAndPrintApplesWithGiaAndMaddie()
        {
            var line = string.Empty;
            var totalApples = string.Empty;
            var differenceInApples = string.Empty;

            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                if (totalApples == string.Empty && differenceInApples == string.Empty)
                    totalApples = line;
                else if (totalApples != string.Empty && differenceInApples == string.Empty)
                    differenceInApples = line;
                else if (totalApples != string.Empty && differenceInApples != string.Empty)
                    break;
            }

            var totalApplesReverse = ReverseString(totalApples);
            var differenceInApplesReverse = ReverseString(differenceInApples);

            var intermediateSum = string.Empty;
            var sum = 0;
            var carry = 0;
            int i = 0;
            for (i = 0; i < totalApplesReverse.Length; i++)
            {
                var total = (Convert.ToInt32(Convert.ToString(totalApplesReverse[i])) +
                             ((i >= differenceInApplesReverse.Length) ? 0 : (Convert.ToInt32(Convert.ToString(differenceInApplesReverse[i])))) + carry);
                sum = total % 10;
                carry = total / 10;

                intermediateSum += sum;
            }

            if (carry > 0)
                intermediateSum += carry;

            intermediateSum = ReverseString(intermediateSum);

            var applesWithGia = string.Empty;
            carry = 0;
            int digit = 0;
            for (int k = 0; k < intermediateSum.Length; k++)
            {
                digit += Convert.ToInt32(Convert.ToString(intermediateSum[k])) + carry;
                carry = 0;

                if (!(Convert.ToInt32(digit) < 2))
                {
                    applesWithGia += Convert.ToInt32(digit) / 2;
                    carry = (Convert.ToInt32(digit) % 2) * 10;
                    digit = 0;
                }
                else if (Convert.ToInt32(digit) == 0)
                {
                    applesWithGia += digit;
                }
                else
                {
                    digit = digit * 10;

                    if (applesWithGia.Length > 0)
                        applesWithGia += 0;
                }
            }

            var applesWithGiaReverse = ReverseString(applesWithGia);
            var applesWithMaddieReverse = string.Empty;

            carry = 0;
            for (int l = 0; l < applesWithGiaReverse.Length; l++)
            {
                var digit1 = Convert.ToInt32(Convert.ToString(totalApplesReverse[l])) - carry;
                carry = 0;
                var digit2 = Convert.ToInt32(Convert.ToString(applesWithGiaReverse[l]));

                if (digit1 < digit2)
                {
                    digit1 = digit1 + 10;
                    carry = 1;
                }

                applesWithMaddieReverse += digit1 - digit2;
            }

            var applesWithMaddie = ReverseString(applesWithMaddieReverse);

            Console.WriteLine(applesWithGia + "," + applesWithMaddie);
            Console.Read();
        }

        private static string ReverseString(string input)
        {
            var returnValue = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                returnValue += input[i];
            }

            return returnValue;
        }
    }
}
