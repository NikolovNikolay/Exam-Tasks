using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LargestArrea
{
    static int largestArrea = int.MinValue;
    static int bestElement = int.MinValue;
    static int element;
    static int arrea;

    static void Main()
    {
        int[,] matrix = {
                           { 1,1,1,1,1,1},
                           { 3,3,3,2,4,1},
                           { 1,3,1,1,3,1},
                           { 1,3,1,3,3,1},
                           { 1,1,1,1,1,1}
                       };

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                element = matrix[row, col];
                arrea = 0;
                BFS(matrix, row, col);
            }
        }
        Console.WriteLine("The elemenet {0} is at {1} positions in a row!", bestElement, largestArrea);
    }

    static void BFS(int[,] matrix,int row, int col)
    {
        if (row < 0 || row > matrix.GetLength(0) - 1 || col < 0 || col > matrix.GetLength(1) - 1)
        {
            return;
        }
        if (matrix[row, col] != element)
        {
            return;
        }

        arrea++;
        if (arrea > largestArrea)
        {
            largestArrea = arrea;
            bestElement = element;
        }

        matrix[row, col] = int.MinValue;
        BFS(matrix, row + 1, col);
        BFS(matrix, row - 1, col);
        BFS(matrix, row, col + 1);
        BFS(matrix, row, col - 1);
        matrix[row, col] = element;
    }
}
