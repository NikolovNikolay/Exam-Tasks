using System;

class Program
{
    static void Main()
    {

        int[,] matrix = new int[8, 16];
        int lengthFlight = 0;
        string direction = "up";
        int pigsHit = 0;

        for (int i = 0; i < 8; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int j = 0; j < 16; j++)
            {
                matrix[i, j] = (number >> j) & 1;
            }
        }


        //for (int i = 8; i < 15; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        if (matrix[i,j] == 1)
        //        {
        //            if (j<= 0)
        //            {
        //                direction = "down";
        //            }
        //            if (j == 7)
        //            {
        //                break;
        //            }
        //        }
                
            
        //    }
        //}




        if (direction == "up")
        {

        }
        for (int i = 0; i < 8; i++)
        {

            for (int j = 0; j < 16; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
