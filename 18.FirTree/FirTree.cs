using System;

class FirTree
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        for (int row = 1; row <= N; row++)
        {
            if (row < N)
            {
                for (int col = N - 1; col > 0; col--)
                {
                    if (row >= col)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }

                for (int i = 1; i < N - 1; i++)
                {
                    if (row > i)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
            }
            else
            {
                for (int k = 1; k <= 2*N - 3; k++)
                {
                    if (k == N - 1)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
