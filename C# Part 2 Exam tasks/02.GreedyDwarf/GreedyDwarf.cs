//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//class GreedyDwarf
//{
//    static void Main()
//    {
//        string[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

//        int[] valley = new int[numbers.Length];
//        for (int i = 0; i < numbers.Length; i++)
//        {
//            valley[i] = int.Parse(numbers[i]);
//        }

//        int m = int.Parse(Console.ReadLine());
//        long maxCoins = long.MinValue;
//        for (int i = 0; i < m; i++)
//        {
//            long sum = SumCoinsInPattern(valley);

//            if (sum > maxCoins)
//            {
//                maxCoins = sum;
//            }
//        }

//        Console.WriteLine(maxCoins);
//    }

//    private static long SumCoinsInPattern(int[] valley)
//    {
//        string[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
//        int[] pattern = new int[numbers.Length];
//        for (int i = 0; i < pattern.Length; i++)
//        {
//            pattern[i] = int.Parse(numbers[i]);
//        }

//        long currentCoins = valley[0];
//        int currentPosition = 0;
//        bool[] visited = new bool[valley.Length];
//        visited[currentPosition] = true;

//        while (true)
//        {
//            for (int i = 0; i < pattern.Length; i++)
//            {
//                int nextMove = currentPosition + pattern[i];

//                if ((nextMove >= 0 && nextMove < valley.Length) && !visited[nextMove])
//                {
//                    currentCoins += valley[nextMove];
//                    visited[nextMove] = true;
//                    currentPosition = nextMove;
//                }
//                else
//                {
//                    return currentCoins;
//                }
//            }
//        }

//    }
//}

using System;
namespace GreedyDwarf
{
    class GreedyDwarf
    {
        private static long ProccessPattern(int[] Vally)
        {

            string[] rawNumbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            int[] pattern = new int[rawNumbers.Length];
            for (int i = 0; i < pattern.Length; i++)
            {
                pattern[i] = int.Parse(rawNumbers[i]);
            }

            long coinSum = new long();
            coinSum += Vally[0];

            bool[] visited = new bool[Vally.Length];
            visited[0] = true;

            int currentPosition = 0;
            while (true)
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    int nextMove = currentPosition + pattern[i];
                    if ((nextMove >= 0 && nextMove < Vally.Length) && !visited[nextMove])
                    {
                        coinSum += Vally[nextMove];
                        visited[nextMove] = true;
                        currentPosition = nextMove;

                    }
                    else
                    {
                        return coinSum;
                    }

                }
            }

        }

        static void Main()
        {
            string[] rawNumbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] Valley = new int[rawNumbers.Length];

            for (int i = 0; i < Valley.Length; i++)
            {
                Valley[i] = int.Parse(rawNumbers[i]);
            }

            int numberOfPatterns = int.Parse(Console.ReadLine());

            long bestSum = long.MinValue;
            for (int i = 0; i < numberOfPatterns; i++)
            {
                long sum = ProccessPattern(Valley);
                if (sum > bestSum)
                {
                    bestSum = sum;
                }

            }
            Console.WriteLine(bestSum);

        }
    }

}