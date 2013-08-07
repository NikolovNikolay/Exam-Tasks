using System;
using System.Linq;

class MissCat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        int winner = 0;

        for (int i = 0; i < n; i++)
        {
           numbers[i] = int.Parse(Console.ReadLine());
        }
        var query = (from item in numbers group item by item into g orderby g.Count() descending select g.Key).First();
        Console.WriteLine(query);
    }
}
