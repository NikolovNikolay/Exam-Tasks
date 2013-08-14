using System;
using System.Linq;

class KukataIsDancing
{
    public static int[,] cube = new int[3, 3];

    static void Main()
    {
        cube[0, 0] = cube[0, 2] = cube[2, 0] = cube[2, 2] = 1; // 1 for red
        cube[1, 1] = 2; // 2 for green
        
        int dances = int.Parse(Console.ReadLine());
        int row = 1;
        int col = 1;
        int direction = 0; // 0 down, 1 right, 2 up, 3 left

        for (int dance = 0; dance < dances; dance++)
        {
            row = 1;
            col = 1;
            direction = 0;
            string current = Console.ReadLine();
            for (int ch = 0; ch < current.Length; ch++)
            {
                char move = current[ch];
                if (move == 'L')
                {
                    direction++;
                    if (direction > 3)
                    {
                        direction = 0;
                    }
                }
                else if (move == 'R')
                {
                    direction--;
                    if (direction < 0)
                    {
                        direction = 3;
                    }
                }
                else
                {
                    if (direction == 0)
                    {
                        row = row + 1;
                        row = CheckBoundariesRow(row);
                    }
                    else if (direction == 1)
                    {
                        col = col + 1;
                        col = CheckBoundariesCol(col);
                    }
                    else if (direction == 2)
                    {
                        row = row - 1;
                        row = CheckBoundariesRow(row);
                    }
                    else if (direction == 3)
                    {
                        col = col - 1;
                        col = CheckBoundariesCol(col);
                    }
                }

            }
            if (cube[row, col] == 1)
            {
                Console.WriteLine("RED");
            }
            else if (cube[row, col] == 2)
            {
                Console.WriteLine("GREEN");
            }
            else
            {
                Console.WriteLine("BLUE");
            }
        }
    }

    static int CheckBoundariesRow(int row)
    {
        
        if (row == -1)
        {
            row = 2;
            return row;
        }
        else if (row == 3)
        {
            row = 0;
            return row;
        }
        
        return row;
    }

    static int CheckBoundariesCol(int col)
    {
        if (col == -1)
        {
            col = 2;
            return col;
        }
        else if (col == 3)
        {
            col = 0;
            return col;
        }
        return col;
    }
}
        
