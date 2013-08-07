using System;

class Trapezoid
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        // Assembling trapezoid TOP line
        char[] upLineTrapezoid = new char[2*N];
        for (int i = 0; i < upLineTrapezoid.Length; i++)
        {
            if (i <= (N - 1))
            {
                upLineTrapezoid[i] = '.';
            }
            else
            {
                upLineTrapezoid[i] = '*';
            }
        }

        //Assembling the body of the trapezoid
        char[,] matrix = new char[N - 1, 2 * N];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, N - (row + 1)] = '*';
                if (col == (2 * N) - 1)
                {
                    matrix[row, col] = '*';
                }
                else
                {
                    matrix[row, col] = '.';
                }
            }
        }

        // Print trapezoid TOP line 
        for (int i = 0; i < upLineTrapezoid.Length; i++)
        {
            Console.Write(upLineTrapezoid[i]);
        }
        Console.WriteLine();

        // Print the body of the trapezoid
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j]);
            }
            Console.WriteLine();
        }
        //Bottom line of the trapezoid
        for (int i = 0; i < 2 * N; i++)
        {
            Console.Write('*');
        }
        Console.WriteLine();
    }
}
