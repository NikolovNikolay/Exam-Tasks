using System;

class ForestRoad
{
    static void Main()
    {
        int mapWidth = int.Parse(Console.ReadLine());
        char[,] matrixPartOne = new char[mapWidth, mapWidth];

        for (int row = 0; row < matrixPartOne.GetLength(0); row++)
        {
            for (int col = 0; col < matrixPartOne.GetLength(1); col++)
            {
                matrixPartOne[row, col] = '.';
                if (row == col)
                {
                    matrixPartOne[row, col] = '*';
                }
            }
        }

        char[,] matrixPartTwo = new char[mapWidth - 1, mapWidth];

        int counter = mapWidth - 2;
        for (int rows = 0; rows < matrixPartTwo.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrixPartTwo.GetLength(1); cols++)
            {
                matrixPartTwo[rows, cols] = '.';
                if (counter == cols)
                {
                    matrixPartTwo[rows, cols] = '*';
                    counter--;
                }
            }
        }

        for (int row = 0; row < matrixPartOne.GetLength(0); row++)
        {
            for (int col = 0; col < matrixPartOne.GetLength(1); col++)
            {
                Console.Write(matrixPartOne[row, col]);
            }
            Console.WriteLine();
        }

        for (int row = 0; row < matrixPartTwo.GetLength(0); row++)
        {
            for (int col = 0; col < matrixPartTwo.GetLength(1); col++)
            {
                Console.Write(matrixPartTwo[row, col]);
            }
            Console.WriteLine();
        }
    }
}
