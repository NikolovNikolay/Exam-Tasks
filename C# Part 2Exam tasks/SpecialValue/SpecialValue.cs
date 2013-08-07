using System;

class SpecialValue
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[][] field = new int[N][];
        ProcessField(field);

        bool[][] used = new bool[N][];

        for (int i = 0; i < N; i++)
        {
            used[i] = new bool[field[i].Length];
        }

        long max = long.MinValue;

        for (int i = 0; i < field[0].Length; i++)
        {
            long specialValue = GetSpecialValue(field, i, used);
            if (max < specialValue)
            {
                max = specialValue;
            }
        }

        Console.WriteLine(max);
    }

    static long GetSpecialValue(int[][] field, int col, bool[][] used)
    {
        long result = 0;
        int row = 0;

        while (true)
        {
            result++;
            if (used[row][col])
            {
                return long.MinValue;
            }
            if (field[row][col] < 0)
            {
                result -= field[row][col];
                return result;
            }

            int nextCol = field[row][col];
            used[row][col] = true;
            col = nextCol;

            row++;

            if (row == field.GetLength(0))
            {
                row = 0;
            }
        }


    }

    static int[][] ProcessField(int[][] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            string[] elements = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            field[i] = new int[elements.Length];
            for (int j = 0; j < elements.Length; j++)
            {
                field[i][j] = int.Parse(elements[j]);
            }
        }

        return field;
    }
}
