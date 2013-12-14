using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static string[] codedDigits = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

    static void Main()
    {
        List<int> digitsToCalc = new List<int>();
        var builder = new StringBuilder();

        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            builder.Append(input[i]);

            if(codedDigits.Contains(builder.ToString()))
            {
                digitsToCalc.Add(Array.IndexOf(codedDigits, builder.ToString()));
                builder.Clear();
            }
        }

        digitsToCalc.Reverse();

        decimal result = 0;
        for (int i = 0; i < digitsToCalc.Count; i++)
        {
            decimal power = PowerCalc(i);
            result += digitsToCalc[i] * power;
        }


        Console.WriteLine(result);
    }

    private static decimal PowerCalc(int power)
    {
        decimal result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= 13;
        }

        return result;
    }
}
