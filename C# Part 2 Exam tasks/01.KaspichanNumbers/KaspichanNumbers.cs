using System;
using System.Collections.Generic;
using System.Linq;

// 100/100
class KaspichanNumbers
{
    static void Main()
    {
        List<string> numbers = FillNumbers();

        ulong number = ulong.Parse(Console.ReadLine());

        List<int> result = new List<int>();
        while (number >= 256)
        {
            result.Add((int)(number % 256));
            number = number / 256;
        }

        result.Add((int)(number));
        for (int i = result.Count - 1; i >= 0; i--)
        {
            Console.Write(numbers[result[i]]);
        }

    }

    private static List<string> FillNumbers()
    {
        List<string> numbers = new List<string>();

        for (int i = 'A'; i <= 'Z'; i++)
        {
            numbers.Add(((char)(i)).ToString());
        }

        for (char i = 'a'; i <= 'i'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                numbers.Add(i.ToString() + j.ToString());
            }
        }

        return numbers;
    }
}
