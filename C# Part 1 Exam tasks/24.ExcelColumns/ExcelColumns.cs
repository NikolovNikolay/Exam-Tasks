using System;
using System.Numerics;

class ExcelColumns
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        BigInteger index = 0;
        for (int i = 1; i <= N; i++)
        {
            char ch = char.Parse(Console.ReadLine());
            index *= 26;
            index += ch - 'A' + 1;
        }
        Console.WriteLine(index);
    }
}