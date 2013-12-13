using System;

class FormulaBit1
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

        int col = 0;
        int row = 0;

        int pathCounter = 0;
        int turnsCounter = 0;

        bool finalReached = false;
        string direction = "down";
        string lastDirection = "";



        while (true)
        {
            if (matrix[row, col] == 1)
            {
                break;
            }

            pathCounter++;

            if (row == 7 && col == 7)
            {
                finalReached = true;
                break;
            }

            if (direction == "down" && (row + 1 > 7 || matrix[row + 1, col] == 1))
            {
                direction = "right";
                lastDirection = "down";
                turnsCounter++;
                if (col + 1 > 7 || matrix[row, col + 1] == 1)
                {
                    break;
                }
            }
            else if (direction == "up" && (row - 1 < 0 || matrix[row - 1, col] == 1))
            {
                direction = "right";
                lastDirection = "up";
                turnsCounter++;
                if ((col + 1 > 7 || matrix[row, col + 1] == 1))
                {
                    break;
                }
            }
            else if (direction == "right" && lastDirection == "down" && (col + 1 > 7 || matrix[row, col + 1] == 1))
            {
                direction = "up";
                turnsCounter++;
                if (row - 1 < 0 || matrix[row - 1, col] == 1)
                {
                    break;
                }
            }
            else if (direction == "right" && lastDirection == "up" && (col + 1 > 7 || matrix[row, col + 1] == 1))
            {
                direction = "down";
                turnsCounter++;
                if (row + 1 > 7 || matrix[row + 1, col] == 1)
                {
                    break;
                }
            }


            if (direction == "down")
            {
                row++;
            }
            else if (direction == "right")
            {
                col++;
            }
            else if (direction == "up")
            {
                row--;
            }
        }

        if (finalReached)
        {
            Console.WriteLine(pathCounter + " " + turnsCounter);
        }
        else
        {
            Console.WriteLine("No {0}", pathCounter);
        }
    }
}

