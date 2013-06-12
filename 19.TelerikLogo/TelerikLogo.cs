using System;

class TelerikLogo
{
    static void Main()
    {
        int numberX = int.Parse(Console.ReadLine());

        int numberY = numberX;
        int numberZ = (numberX / 2) + 1;

        char[,] matrix = new char[(numberX + (numberX - 1) + ((2 * numberZ) - 2)),(numberX + (numberX - 1) + ((2 * numberZ) - 2))];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = '.';
            }
        }

        int startRow = numberX / 2;
        int startCol = 0;

        for (int i = 0; i < numberZ; i++)
        {
            matrix[startRow, startCol] = '*';
            startRow--;
            startCol++;
        }

        startRow += 2;

        for (int i = 1; startCol < matrix.GetLength(1) - numberX/2; i++)
        {
            matrix[startRow, startCol] = '*';
            startCol++;
            startRow++;
        }

        startCol -= 2;

        for (int i = 0; i < numberX - 1; i++)
        {
            matrix[startRow, startCol] = '*';
            startCol--;
            startRow++;
        }

        startRow -= 2;

        for (int i = 0; i < numberX - 1; i++)
        {
            matrix[startRow, startCol] = '*';
            startCol--;
            startRow--;
        }

        startCol += 2;
        for (int i = 0; startRow >= 0; i++)
        {
            matrix[startRow, startCol] = '*';
            startCol++;
            startRow--;
        }

        startRow += 2;

        for (int i = 0; i < numberX /2; i++)
        {
            matrix[startRow, startCol] = '*';
            startCol++;
            startRow++;
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
