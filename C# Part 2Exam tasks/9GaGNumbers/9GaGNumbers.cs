using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

class GaGNumbers
{
    static void Main()
    {
        List<string> gagNumbers = new List<string>() { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        string input = Console.ReadLine();
        List<int> power = new List<int>();
        var sb = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char element = input[i];
            sb.Append(element);

            if (gagNumbers.Contains(sb.ToString()))
            {
                power.Add(gagNumbers.IndexOf(sb.ToString()));
                sb.Clear();
            }

        }

        BigInteger result = TranslateNumber(power);
        Console.WriteLine(result);
    }

    static BigInteger PowerCalculator(long digit)
    {
        BigInteger result = 1;

        for (int i = 0; i < digit; i++)
        {
            result *= 9;
        }

        return result;
    }

    static BigInteger  TranslateNumber(List<int> list)
    {
        BigInteger result = 0;
        long power = list.Count - 1;

        for (int i = 0; i < list.Count; i++)
        {
            result += PowerCalculator(power)*list[i];
            power--;
        }


        return result;
    }

}
