using System;

class Carpets
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        char[,] matrix = new char[N / 2, N];

        int stepLeft =  1;
        int stepRight = 0;
        for (int i = 0; i < N/2; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = '.';
                
            }
        }

        for (int i = 0; i < N/2 ; i++)
        {
            matrix[i, N/2 - stepLeft] = '/';
            matrix[i, N/2 + stepRight] = '\\';
            
            stepLeft++;
            stepRight++; 
        }

        stepLeft = 2;
        stepRight = 1;
        for (int row = 1; row < N/2; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (row % 2 == 0)
                {
                    for (int i = N/2 - stepLeft; i <= N/2 - 1; i++)
                    {
                        if (i % 2 != 0)
                        {
                            matrix[row, i] = '/';
                        }
                        if (i % 2 == 0) matrix[row, i] = ' ';
                    }
                }
                if (row % 2 != 0)
                {
                    for (int i = N / 2 - stepLeft; i <= N / 2 - 1; i++)
                    {
                        if (i % 2 == 0)
                        {
                            matrix[row, i] = '/';
                        }
                        if (i % 2 != 0) matrix[row, i] = ' ';
                    }
                }
            }
            stepLeft++;
            
        }

        for (int row = 1; row < N / 2; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (row % 2 != 0)
                {
                    for (int i = N / 2; i < N/2 + stepRight; i++)
                    {
                        if (i % 2 != 0)
                        {
                            matrix[row, i] = '\\';
                        }
                        if (i % 2 == 0) matrix[row, i] = ' ';
                    }
                }
                if (row % 2 == 0)
                {
                    for (int i = N / 2; i < N / 2 + stepRight; i++)
                    {
                        if (i % 2 == 0)
                        {
                            matrix[row, i] = '\\';
                        }
                        if (i % 2 != 0) matrix[row, i] = ' ';
                    }
                }
            }
            stepRight++;

        }
        //print
        for (int i = 0; i < N / 2; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
        //Array.Reverse(matrix);
        //print
        for (int i = N/2; i >= 0; i--)
        {
            for (int j = N; j >= 0; j--)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }









        //int outerDots = (N / 2) - 1;
        //int spaces = 0;
        //int dashes = 1;

        //for (int i = 1; i <= N / 2; i++)
        //{
        //    Console.Write(new string('.', outerDots));
        //    Console.Write(new string('/', dashes));
        //    //Console.Write(new string(' ',spaces));
        //    Console.Write(new string('\\',dashes));
        //    Console.Write(new string('.', outerDots));
        //    outerDots--;
        //    dashes++;
        //    spaces += 2;
        //    Console.WriteLine();
        //}

       

    }
}