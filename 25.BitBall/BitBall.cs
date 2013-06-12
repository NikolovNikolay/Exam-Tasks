using System;

class BitBall
{
    static void AssignFirstMatrixValues(char[,] array)
    {
        for (int row = 0; row < 8; row++)
        {
            string number = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
            for (int col = 0; col < 8; col++)
            {
                array[row, col] = number[col];
            }
        }
    }

    static void AssignSecondMatrixValues(char[,] array)
    {
        for (int row = 0; row < 8; row++)
        {
            string number = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
            for (int col = 0, i = 0; col < 8; col++, i++)
            {
                array[row, col] = number[col];
                if (number[col] == '1')
                {
                    array[row, col] = '2';
                }
            }
        }
    }




    static void Main()
    {
        char[,] matrixOne = new char[8, 8];
        char[,] matrixTwo = new char[8, 8];
        char[,] finalMatrix = new char[8, 8];
        int firstTeamResult = 0;
        int secondTeamResult = 0;
        int counter = 0;

        AssignFirstMatrixValues(matrixOne);
        //for (int row = 0; row < 8; row++)
        //{
        //    string number = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
        //    for (int col = 0; col < 8; col++)
        //    {
        //        matrixOne[row, col] = number[col];
        //    }
        //}

        AssignSecondMatrixValues(matrixTwo);
        //for (int row = 0; row < 8; row++)
        //{
        //    string number = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
        //    for (int col = 0, i = 0; col < 8; col++, i++)
        //    {
        //        matrixTwo[row, col] = number[col];
        //        if (number[col] == '1')
        //        {
        //            matrixTwo[row, col] = '2';
        //        }
        //    }
        //}

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (matrixOne[row, col] == '1' && matrixTwo[row, col] == '2')
                {
                    matrixOne[row, col] = '0';
                    matrixTwo[row, col] = '0';
                }
            }
        }

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                finalMatrix[row, col] = matrixOne[row, col];
                if (finalMatrix[row, col] == '0')
                {
                    finalMatrix[row, col] = matrixTwo[row, col];
                }
            }
        }

        char[] testArray = new char[8];
        for (int col = 0; col < 8; col++)
        {
            counter = 0;
            for (int row = 0; row < 8; row++)
            {
                testArray[row] = finalMatrix[row, col];
            }
            
            for (int i = 0; i < 8; i++)
            {
                if (testArray[i] == '1')
                {
                    counter++;
                }
                if (testArray[i] == '2')
                {
                    counter = 0;
                }
            }
            if (counter > 0)
            {
                firstTeamResult++;
            }
        }

        for (int col = 0; col < 8; col++)
        {
            counter = 0;
            for (int row = 0; row < 8; row++)
            {
                testArray[row] = finalMatrix[row, col];
            }
            
            Array.Reverse(testArray);
            for (int i = 0; i < 8; i++)
            {
                if (testArray[i] == '2')
                {
                    counter++;
                }
                if (testArray[i] == '1')
                {
                    counter = 0;
                }
            }
            if (counter > 0)
            {
                secondTeamResult++;
            }
        }
        Console.WriteLine("{0}:{1}", firstTeamResult, secondTeamResult);

        //// print - to be removed
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(matrixOne[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        //Console.WriteLine();
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(matrixTwo[i, j]);
        //    }
        //    Console.WriteLine();
        //}
        //Console.WriteLine();
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(finalMatrix[i, j]);
        //    }
        //    Console.WriteLine();
        //}
        
        //Console.WriteLine(secondTeamResult);
    }
}