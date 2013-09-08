using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

// 100 / 100
class GaGNumbers
{
    static void Main()
    {
        List<string> gagDigits = new List<string> { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };

        string input = Console.ReadLine();
        List<int> digitsToCalc = new List<int>();
        var sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];
            if (gagDigits.Contains(sb.ToString()))
            {
                digitsToCalc.Add(gagDigits.IndexOf(sb.ToString()));
                sb.Clear();
                i--;
            }
            else
                sb.Append(ch);
        }

        if (gagDigits.Contains(sb.ToString()))
        {
            digitsToCalc.Add(gagDigits.IndexOf(sb.ToString()));
            sb.Clear();
        }
        BigInteger result = 0;
        int pow = 0;

        for (int i = digitsToCalc.Count - 1; i >= 0; i--)
        {
            result += digitsToCalc[i] * CalcPow(pow);
            pow++;
        }

        Console.WriteLine(result);
    }

    private static BigInteger CalcPow(int pow)
    {
        BigInteger power = 1;
        for (int i = 0; i < pow; i++)
        {
            power *= 9;
        }

        return power;
    }

}
