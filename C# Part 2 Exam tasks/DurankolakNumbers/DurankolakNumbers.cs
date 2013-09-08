using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class DurankolakNumbers
{
    static void Main()
    {
        List<string> numbers = new List<string>(168);

        for (char i = 'A'; i <= 'Z'; i++)
        {
            numbers.Add(i.ToString());
        }

        for (char i = 'a'; i <= 'f'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                numbers.Add(i.ToString() + j.ToString());
            }
        }

        string input = Console.ReadLine();

        var builder = new StringBuilder();
        List<int> convert = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLower(input[i]))
            {
                builder.Append(input[i]);
            }
            else
            {
                builder.Append(input[i]);
                //string str = builder.ToString();
                int index = Array.IndexOf(numbers.ToArray(), builder.ToString());
                convert.Add(index);
                builder.Clear();
            }
        }

        long result = 0;
        int pow = 0;

        for (int i = convert.Count - 1; i >= 0; i--)
        {
            result += convert[i] * (long)(Math.Pow(168, pow));
            pow++;
        }

        Console.WriteLine(result);
    }
}
