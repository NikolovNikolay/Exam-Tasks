using System;

class Pillars
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];

        for (int i = 0; i < 8; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                matrix[i, j] = (number >> j) & 1;
            }
        }

        int pillar = 7;
        int countLeft = 0;
        int countRight = 0;

        bool solutionAvailable = false;

        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(matrix[i,j]);
        //    }
        //    Console.WriteLine();
        //}

        int[] testArray = new int[8];

        int countSolutions = 0;
        while (pillar >=0)
        {
            countRight = 0;
            countLeft = 0;
            for (int col = 0; col < pillar; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        countLeft++;
                    }
                }
            }

                for (int col = pillar + 1; col < 8; col++)
                {
                    for (int row = 0; row < 8; row++)
                    {
                        if (matrix[row, col] == 1)
                        {
                            countRight++;
                        }
                    }
                }
            
            if (countRight == countLeft)
            {
                
                solutionAvailable = true;
                
                break;
            }
            pillar--;

        }

        if (solutionAvailable)
        {

            Console.WriteLine(pillar);
            Console.WriteLine(countLeft);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
