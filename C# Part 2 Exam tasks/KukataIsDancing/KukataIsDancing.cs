using System;
using System.Linq;

class KukataIsDancing
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        string[,] danceFloor = new string[3, 3];
        danceFloor[0, 0] = danceFloor[0, 2] = danceFloor[2, 0] = danceFloor[2, 2] = "RED";
        danceFloor[0, 1] = danceFloor[1, 0] = danceFloor[1, 2] = danceFloor[2, 1] = "BLUE";
        danceFloor[1, 1] = "GREEN";

        for (int i = 0; i < lines; i++)
        {
            string current = Console.ReadLine();
            int direction = 0;
            int row = 1;
            int col = 1;
            for (int j = 0; j < current.Length; j++)
            {
                char ch = current[j];

                if (ch == 'L')
                {
                    direction++;
                    direction = DetermineDirection(direction);
                }
                else if (ch == 'R')
                {
                    direction--;
                    direction = DetermineDirection(direction);
                }
                else if (ch == 'W')
                {
                    if (direction == 0)
                    {
                        row--;
                    }
                    else if (direction == 1)
                    {
                        col--;
                    }
                    else if (direction == 2)
                    {
                        row++;
                    }
                    else if (direction == 3)
                    {
                        col++;
                    }

                    if (col == -1)
                        col = 2;
                    else if (col == 3)
                        col = 0;

                    if (row == -1)
                        row = 2;
                    else if (row == 3)
                        row = 0;
                }
            }
            Console.WriteLine(danceFloor[row, col]);
        }
    }

    private static int DetermineDirection(int direction)
    {
        if (direction == 4)
        {
            direction = 0;
        }
        else if (direction == -1)
        {
            direction = 3;
        }
        else if (direction == -2)
        {
            direction = 2;
        }
        else if (direction == -3)
        {
            direction = 2;
        }

        return direction;
    }
}
        
