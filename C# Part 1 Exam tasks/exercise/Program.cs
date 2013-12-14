using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        string n = Console.ReadLine();
        int sum = 0;

        while (true)
        {
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] != '.' && n[i] != ',' && n[i] != '-')
                {
                    sum = sum + int.Parse(n[i].ToString());
                }
            }

            n = sum.ToString();

            if (sum <= 9)
            {
                Console.WriteLine(sum);
                break;
            }
            sum = 0;
        } 
    }
}


