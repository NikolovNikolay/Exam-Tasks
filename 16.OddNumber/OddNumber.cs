using System;
using System.Numerics;

class OddNumber
{
    static void Main()
    {
        int numbersCount = int.Parse(Console.ReadLine()); // reads the quantity of numbers to lookup for OddNumber

        long oddNumber = 0;
        long number = 0;
        for (int i = 0; i < numbersCount; i++) // Loop to enter numbers
        {
            number = long.Parse(Console.ReadLine()); // reads a number from the console
            oddNumber = oddNumber ^ number; // pumping numbers into the variable using XOR.
            //The effect is that "x" XOR "x" = 0, and finally 0 XOR "y" = "y" nevertheless the position of y into the array  
        }

        Console.WriteLine(oddNumber);
        
        //int N = int.Parse(Console.ReadLine());
        //long[] numbers = new long[N];

        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    numbers[i] = long.Parse(Console.ReadLine());
        //}

        //long count = 1;
        //long temp = 0;

        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    count = 1;
        //    for (int j = i; j < numbers.Length; j++)
        //    {
        //        if (numbers[i] == numbers[j])
        //        {
        //            count++;
        //            temp = numbers[i];
        //        }
        //    }
        //    if (count % 2 == 0)
        //    {
        //        Console.WriteLine(temp);
        //        break;
        //    }
            
        //}
    }
}
