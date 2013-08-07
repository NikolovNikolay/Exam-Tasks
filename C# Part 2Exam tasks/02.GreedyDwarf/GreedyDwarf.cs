using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GreedyDwarf
{
    static void Main()
    {
        string[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] valley = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            valley[i] = int.Parse(numbers[i]);
        }

        int m = int.Parse(Console.ReadLine());
        long maxCoins = long.MinValue;
        for (int i = 0; i < m; i++)
        {
            long sum = SumCoinsInPattern(valley);

            if (sum > maxCoins)
            {
                maxCoins = sum;
            }
        }

        Console.WriteLine(maxCoins);
    }

    private static long SumCoinsInPattern(int[] valley)
    {
        string[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] pattern = new int[numbers.Length];
        for (int i = 0; i < pattern.Length; i++)
        {
            pattern[i] = int.Parse(numbers[i]);
        }

        long currentCoins = valley[0];
        int currentPosition = 0;
        bool[] visited = new bool[valley.Length];
        visited[currentPosition] = true;

        while (true)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                int nextMove = currentPosition + pattern[i];

                if ((nextMove >= 0 && nextMove < valley.Length) && !visited[nextMove])
                {
                    currentCoins += valley[nextMove];
                    visited[nextMove] = true;
                    currentPosition = nextMove;
                }
                else
                {
                    return currentCoins;
                }
            } 
        }

    }
}