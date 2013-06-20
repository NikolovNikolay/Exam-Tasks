using System;

class Sheets
{
    static void Main(string[] args)
    {
        string number = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(11, '0');
        for (int i = 10; i >= 0; i--)
        {
            if (number[i] == '0')
            {
                Console.WriteLine("A{0}", i);
            }
        }
    }
}
