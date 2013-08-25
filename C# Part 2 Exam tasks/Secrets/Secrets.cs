using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Collections;
using System.Numerics;

class Secrets
{
    static void Main()
    {
        BigInteger inputNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger number = inputNumber;

        if (number < 0)
        {
            number *= -1;
        }

        // special sum
        long specialSum = 0;
        long position = 0;
        string digits = number.ToString();
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            position++;

            int digi = int.Parse(digits[i].ToString());
            if (position % 2 == 1)
            {
                specialSum += digi * position * position;
            }
            else
            {
                specialSum += digi * digi * position;
            }
        }

        Console.WriteLine(specialSum);
        int specialLength = (int)specialSum % 10;
        char startLetter = (char)(specialSum % 26 + 'A');

        if (specialLength > 0)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < specialLength; i++)
            {
                sb.Append(startLetter);
                startLetter++;
                if (startLetter > 'Z')
                {
                    startLetter = 'A';
                }
            }
            Console.WriteLine(sb.ToString());
        }
        else
        {
            Console.WriteLine("{0} has no secret alpha-sequence", inputNumber);
        }
    }

}