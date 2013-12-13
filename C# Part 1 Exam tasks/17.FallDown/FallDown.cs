using System;

class FallDown
{
    static void Main()
    {
        string number = string.Empty;
        char[,] matrix = new char[8, 8];

        for (int row = 0; row < 8; row++)
        {
            number = Convert.ToString(byte.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
            for (int col = 0; col < 8; col++)
            {
                matrix[row, col] = number[col];
            }
        }

        //for (int i = 0; i < matrix.GetLength(0); i++)
        //{
        //    for (int j = 0; j < matrix.GetLength(1); j++)
        //    {
        //        Console.Write(" {0}", matrix[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        char[] tempArray = new char[8];

        for (int col = 0; col < 8; col++)
        {
            for (int row = 0; row < 8; row++)
            {
                tempArray[row] = matrix[row, col];
            }
            Array.Sort(tempArray);
            for (int j = 0; j < 8; j++)
            {
                matrix[j, col] = tempArray[j];
            }
        }

        //for (int i = 0; i < matrix.GetLength(0); i++)
        //{
        //    for (int j = 0; j < matrix.GetLength(1); j++)
        //    {
        //        Console.Write(" {0}", matrix[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        string exchangedArray = "";
        //long result = 0;
        for (int row = 0; row < 8; row++)
        {

            for (int col = 0; col < 8; col++)
            {
                tempArray[col] = matrix[row, col];
                exchangedArray = new string(tempArray);
                //result = Convert.ToInt64(exchamgedArray, 2);
            }
            Console.WriteLine(Convert.ToInt64(exchangedArray, 2));
        }
    }
}
