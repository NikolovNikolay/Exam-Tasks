using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        char[,] matrixOne = new char[n / 2, n];
        char[,] matrixTwo = new char[n / 2, n];

        int leftCol = 0;
        int leftRow = 0;

        int rightCol = n - 1;
        int rightRow = 0;

        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrixOne[i, j] = '.';
                matrixOne[i, n / 2] = '|';
                matrixTwo[i, j] = '.';
                matrixTwo[i, n / 2] = '|';
            }
        }

        while (leftRow <= n / 2 - 1 && rightRow <= n / 2 - 1)
        {
            matrixOne[leftRow, leftCol] = '\\';
            matrixOne[rightRow, rightCol] = '/';
            leftCol++;
            leftRow++;
            rightCol--;
            rightRow++;
        }

        leftRow = 0;
        rightRow = 0;
        leftCol++;
        rightCol--;


        while (leftRow <= n / 2 - 1 && rightRow <= n / 2 - 1)
        {
            matrixTwo[leftRow, leftCol] = '\\';
            matrixTwo[rightRow, rightCol] = '/';
            leftCol++;
            leftRow++;
            rightCol--;
            rightRow++;
        }

        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrixOne[i, j]);
            }
            Console.WriteLine();
        }
        Console.Write(new string('-', n / 2));
        Console.Write(new string('*', 1));
        Console.Write(new string('-', n / 2));
        Console.WriteLine();
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrixTwo[i, j]);
            }
            Console.WriteLine();
        }
    }
}



