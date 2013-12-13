using System;
using System.Linq;

// 100 / 100
class SpecialValue
{
    static void Main()
    {
        //Console.SetIn(new StreamReader("input.txt"));
        int lines = int.Parse(Console.ReadLine());
        int[][] board = new int[lines][];
        bool[][] visited = new bool[lines][];

        for (int i = 0; i < lines; i++)
        {
            board[i] = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            visited[i] = new bool[board[i].Length];
        }

        int maxLenght = 0;

        for (int i = 0; i < board[0].Length; i++)
        {
            int length = GetMaxLength(board, visited, i, lines);
            if (length > maxLenght)
            {
                maxLenght = length;
            }
        }

        Console.WriteLine(maxLenght);
    }

    private static int GetMaxLength(int[][] board, bool[][] visited, int i, int lines)
    {
        int length = 0;
        int row = -1;
        int col = i;

        while (true)
        {

            int next = board[row + 1][col];

            if (next < 0)
            {
                visited[row + 1][col] = true;
                length++;
                return length + (-next);
            }
            else if (visited[row + 1][col])
            {
                return length;
            }
            else
            {
                col = next;
                row++;
                length++;

                if (row >= lines - 1)
                {
                    row = -1;
                }
            }
        }
    }
}
