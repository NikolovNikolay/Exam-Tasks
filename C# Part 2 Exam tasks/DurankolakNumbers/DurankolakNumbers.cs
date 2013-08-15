using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class DurankolakNumbers
{
    static string[] durankolakNumbers = new string[168];

    static void Main()
    {
        AssignDurankulakNumbers();
        string input = Console.ReadLine();

        var durankulakDigits = GetDurankulakNumbers(input);
        durankulakDigits.Reverse();

        long result = CalculateResult(durankulakDigits);
        Console.WriteLine(result);

        
    }

    static long CalculateResult(List<string> list)
    {
        long result = 0;
        for (int i = 0; i < list.Count; i++)
        {
            result += Array.IndexOf(durankolakNumbers,list[i]) * (long)Math.Pow(168, i);
        }

        return result;
    }

    static List<string> GetDurankulakNumbers(string input)
    {
        List<string> digits = new List<string>();
        var digit = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (char.IsLower(ch))
            {
                digit.Append(ch);
            }
            else
            {
                digit.Append(ch);
                digits.Add(digit.ToString());
                digit.Clear();
            }
        }

        return digits;
    }

    static void AssignDurankulakNumbers()
    {
        for (int i = 0; i < 168; i++)
        {
            if (i < 26)
            {
                durankolakNumbers[i] = ((char)('A' + i)).ToString();
            }
            else if (i < 2 * 26)
            {
                durankolakNumbers[i] = "a" + durankolakNumbers[i - 26];
            }
            else if (i < 3 * 26)
            {
                durankolakNumbers[i] = "b" + durankolakNumbers[i - 2*26];
            }
            else if (i < 4 * 26)
            {
                durankolakNumbers[i] = "c" + durankolakNumbers[i - 3 * 26];
            }
            else if (i < 5 * 26)
            {
                durankolakNumbers[i] = "d" + durankolakNumbers[i - 4 * 26];
            }
            else if (i < 6 * 26)
            {
                durankolakNumbers[i] = "e" + durankolakNumbers[i - 5 * 26];
            }
            else 
            {
                durankolakNumbers[i] = "f" + durankolakNumbers[i - 6 * 26];
            }
        }
    }
}
