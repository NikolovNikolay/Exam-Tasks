using System;
using System.Linq;

class Program
{
    private static char[, ,] cube;
    private static int width, height, depth;
    private static int[] dirWidth = { 1, 0, 1, -1, 0, 0, 0, 1, -1, 1, 1, 1, 1 };
    private static int[] dirHeight = { 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, -1, 1, -1 };
    private static int[] dirDepth = { 0, 0, 1, 1, 1, 1, -1, 0, 0, 1, 1, -1, -1 };
    private static int bestLength = 0;
    private static int bestQuantity = 0;

    static void Main()
    {
        FillCube();
        GetBestLength();

    }

    static void FillCube()
    {
        int[] dims = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
        width = dims[0];
        height = dims[1];
        depth = dims[2];
        cube = new char[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string line = Console.ReadLine();
            string[] parts = line.Split();

            for (int d = 0; d < depth; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = parts[d][w];
                }
            }
        }
    }

    static void GetBestLength()
    {
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    ProcessDirection(w, h, d);
                }
            }
        }

        Console.WriteLine("{0} {1}", bestLength, bestQuantity);

    }

    private static void ProcessDirection(int w, int h, int d)
    {
        char currentCell = cube[w, h, d];


        for (int i = 0; i < dirDepth.Length; i++)
        {
            int currentWidth = w;
            int currentHeight = h;
            int currentDepth = d;
            int currentLength = 1;

            while (true)
            {
                currentWidth += dirWidth[i];
                currentHeight += dirHeight[i];
                currentDepth += dirDepth[i];

                if (!IsInCube(currentWidth, currentHeight, currentDepth))
                {
                    break;
                }

                if (cube[currentWidth, currentHeight, currentDepth] == currentCell)
                {
                    currentLength++;
                }
                else
                {
                    break;
                }
            }

            if (currentLength > bestLength)
            {
                bestLength = currentLength;
                bestQuantity = 1;
            }
            else if (currentLength == bestLength)
            {
                bestQuantity++;
            }
        }
    }

    private static bool IsInCube(int w, int h, int d)
    {
        if (w >= 0 && w < width && h >= 0 && h < height && d >= 0 && d < depth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}