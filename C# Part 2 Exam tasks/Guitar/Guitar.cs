using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Guitar
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] splitInput = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        int[] steps = splitInput.Select(s => int.Parse(s)).ToArray();

        int B = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        int[,] mainArray = new int[steps.Length + 1, M + 1];
        mainArray[0, B] = 1;
        int result = -1;

        for (int row = 1; row < steps.Length + 1; row++)
        {
            var interval = steps[row - 1];
            for (int col = 0; col < M + 1; col++)
            {
                if (mainArray[row - 1, col] == 1)
                {
                    if (col - interval >= 0)
                    {
                        mainArray[row, col - interval] = 1;
                    }
                    if (col + interval <= M)
                    {
                        mainArray[row, col + interval] = 1;
                    }

                }
            }
        }


        for (int col = M; col >= 0; col--)
        {
            if (mainArray[steps.Length, col] == 1)
            {
                Console.WriteLine(col);
                return;
            }
        }


        Console.WriteLine(-1);
    }
}
