using System;

class SubsetSums
{
    static void Main()
    {
        long wantedSum = long.Parse(Console.ReadLine());
        int digitsInArray = int.Parse(Console.ReadLine());
        long sum = 0;
        int result = 0;

        long[] array = new long[digitsInArray];

        for (int i = 0; i < digitsInArray; i++)
        {
            array[i] = long.Parse(Console.ReadLine());
        }
        int combinations = (1 << digitsInArray) - 1;

        for (int i = 1; i <= combinations; i++)
        {
            sum = 0;
            for (int j = 0; j < digitsInArray; j++)
            {
                if (((i >> j) & 1) == 1) sum += array[j];
            }
            if (sum == wantedSum) result++;
        }
 
        Console.WriteLine(result);
    }
}
