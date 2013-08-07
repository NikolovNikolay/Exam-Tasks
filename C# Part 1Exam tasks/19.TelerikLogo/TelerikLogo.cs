using System;

class TelerikLogo
{
    static void Main()
    {
        int X = int.Parse(Console.ReadLine());
        int Y = X;
        int Z = (X / 2) + 1;


        int lines = X + (X - 1) + ((X / 2) * 2);
        char[,] matrix = new char[lines, lines];

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < lines; j++)
            {
                matrix[i, j] = '.';
            }
        }

        int row = X / 2;
        int col = 0;
        // starting from left horn. Every loop is a straight line

        for (int i = 0; i < Z; i++)
        {
            matrix[row, col] = '*';
            row--;
            col++;
        }

        row += 2;

        for (int i = 1; i <= lines - X; i++)
        {
            matrix[row, col] = '*';
            row++;
            col++;

        }

        col -= 2;

        for (int i = 0; i < X - 1; i++)
        {
            matrix[row, col] = '*';
            row++;
            col--;
        }

        row -= 2;

        for (int i = 0; i < X - 1; i++)
        {
            matrix[row, col] = '*';
            row--;
            col--;
        }

        col += 2;

        for (int i = 0; i < lines - X; i++)
        {
            matrix[row, col] = '*';
            col++;
            row--;
        }

        row += 2;

        for (int i = 0; i < Z - 1; i++)
        {
            matrix[row, col] = '*';
            col++;
            row++;
        }

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < lines; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}