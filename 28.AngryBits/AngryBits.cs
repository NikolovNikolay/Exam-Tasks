using System;

class AngryBits
{
    static void Main()
    {
        int[,] matrix = new int[8, 16];

        for (int i = 0; i < 8; i++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int j = 0; j < 16; j++)
            {
                int bit = (number >> j) & 1;
                matrix[i, j] = bit;
            }
        }

        int score = 0;
        string result = "Yes";
        
        for (int col = 8; col < 16; col++)
        {
            int currentRow = -1;

            for (int row = 0; row < 8; row++)
            {
                if (matrix[row, col] == 1)
                {
                    currentRow = row;
                    break;
                }
            }
            

            if (currentRow == -1) continue;
            else
            {
                string direction = "up";
                int path = 0;
                int pigsHitted = 0;
                currentRow--;
                if (currentRow == 0)
                {
                    direction = "Down";
                }

                matrix[currentRow, col] = 0;

                for (int currentColumn = col - 1; currentColumn >= 0; currentColumn--)
                {
                    if (direction == "up")
                    {
                        currentRow--;
                        if (currentRow == 0)
                        {
                            direction = "down";
                        }
                    }
                    else
                    {
                        currentRow++;
                        if (currentRow > 7)
                        {
                            break;
                        }
                    }

                    if (matrix[currentRow, currentColumn] == 1)
                    {
                        path = col - currentColumn;
                        for (int i = currentRow - 1; i <= currentRow + 1; i++)
                        {
                            for (int j = currentColumn - 1; j <= currentColumn + 1; j++)
                            {
                                if (i > -1 && i < 8 && j > -1)
                                {
                                    if (matrix[i, j] == 1)
                                    {
                                        pigsHitted++;
                                        matrix[i, j] = 0;
                                    }

                                }
                            }
                        }
                    }
                }
                score = score + pigsHitted * path;
            }


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        result = "No";
                        break;
                    }

                }
            }
        }
        Console.WriteLine("{0} {1}", score, result);
    }
}