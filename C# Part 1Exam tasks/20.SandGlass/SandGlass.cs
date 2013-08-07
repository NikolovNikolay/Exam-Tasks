using System;

class SandGlass
{
    static void Main()
    {

        int N = int.Parse(Console.ReadLine());

        char[,] firstMatrix = new char[N / 2, N];
        char[,] secondMatrix = new char[N / 2, N];

        // assigning dots for values in the first matrix
        for (int i = 0; i < firstMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < firstMatrix.GetLength(1); j++)
            {
                firstMatrix[i, j] = '.';
            }
        }

        // assigning dots for values in the second matrix
        for (int i = 0; i < secondMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < secondMatrix.GetLength(1); j++)
            {
                secondMatrix[i, j] = '.';
            }
        }

        
        int startCol = 0;
        int endCol = N;

        for (int row = 0; row < firstMatrix.GetLength(0); row++)
        {
            for (int col = startCol; col < endCol ; col++)
            {
                firstMatrix[row, col] = '*';
            }
            startCol++;
            endCol--;
        }

        startCol = 0;
        endCol = N;

        for (int row = secondMatrix.GetLength(0) - 1; row >= 0; row--)
        {
            for (int col = startCol; col < endCol; col++)
            {
                secondMatrix[row, col] = '*';
            }
            startCol++;
            endCol--;
        }

        // Print the whole SandGlass
        for (int i = 0; i < firstMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < firstMatrix.GetLength(1); j++)
            {
                Console.Write(firstMatrix[i, j]);
            }
            Console.WriteLine();
        }

        Console.Write(new string('.', N / 2));
        Console.Write('*');
        Console.Write(new string('.', N / 2));
        Console.WriteLine();

        for (int i = 0; i < secondMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < secondMatrix.GetLength(1); j++)
            {
                Console.Write(secondMatrix[i, j]);
            }
            Console.WriteLine();
        }

    }
}
