using System;
using System.Collections.Generic;
using System.Linq;

class KaspichanNumbers
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());

        List<string> list = new List<string>();

        for (char i = 'A'; i <= 'Z'; i++)
        {
            list.Add(i.ToString());
        }

        for (char i = 'a'; i <= 'i'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                list.Add(i.ToString() + j.ToString());
            }
        }

        string result = null;

        if (number == 0)
        {
            Console.WriteLine('A');
        }

        while (number != 0)
        {
            result = list[(int)(number % 256)] + result;
            number /= 256;
        }

        Console.WriteLine(result);
    }
}
