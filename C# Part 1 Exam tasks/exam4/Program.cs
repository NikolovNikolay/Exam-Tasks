using System;

class Program
{
    static void Main()
    {
        int matrixWidth = int.Parse(Console.ReadLine());
        int matrixHeight = matrixWidth - (matrixWidth/4);

        char[,] matrix = new char[matrixHeight, matrixWidth];

        for (int i = 0; i < matrixHeight; i++)
        {
            for (int j = 0; j < matrixWidth; j++)
            {
                matrix[i, j] = '.';
            }
        }

        int loopLength = 2;
        int leftCol = matrixWidth / 2 - 1;
        int rightCol = matrixWidth / 2;
        int row = 0;

        while (leftCol >= 0 && rightCol <= matrixWidth - 1)
        {
            matrix[row, leftCol] = '#';
            matrix[row, rightCol] = '#';
            row++;
            leftCol--;
            rightCol++;
        }

        leftCol++;
        rightCol--;
        while (row <= matrixHeight - 1)
        {
            matrix[row, leftCol] = '#';
            matrix[row, rightCol] = '#';
            leftCol++;
            rightCol--;
            row++;
        }

        char[,] torch = new char[matrixWidth / 2, matrixWidth];

        for (int i = 0; i < torch.GetLength(0); i++)
        {
            for (int j = 0; j < torch.GetLength(1); j++)
            {

                torch[i, j] = '.';
            }
        }

        int start = 0;
        int end = matrixWidth;
        row = 0;
        int col = 0;

        for (int torchrow = 0; torchrow < torch.GetLength(0); torchrow++)
        {
            for (int torchcol = start; torchcol < end; torchcol++)
			{
                if (torchcol <= matrixWidth / 2 - 1)
                {
                    torch[torchrow, torchcol] = '\\';
                }
                if (torchcol > matrixWidth / 2 - 1)
                {
                    torch[torchrow, torchcol] = '/';
                }
			}
            start++;
            end--;
        }



        // ---------------------------------------------------------------------------
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('-', matrixWidth));

        for (int i = 0; i < torch.GetLength(0); i++)
        {
            for (int j = 0; j < torch.GetLength(1); j++)
            {

                Console.Write(torch[i, j]);
            }
            Console.WriteLine();
        }
    }
}
