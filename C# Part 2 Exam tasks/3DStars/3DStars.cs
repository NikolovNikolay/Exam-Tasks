using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Stars
{
    private static char[, ,] cuboid;
    private static int width, height, depth;
    private static Dictionary<char, int> values = new Dictionary<char, int>();

    static void Main()
    {
        ParseInput();
        GetStars();
        PrintResults();
    }

    private static void PrintResults()
    {
        int allStars = 0;

        foreach (var pair in values)
        {
            allStars += pair.Value;
        }

        var list = values.Keys.ToList();
        list.Sort();
        Console.WriteLine(allStars);
        foreach (var key in list)
        {
            Console.WriteLine("{0} {1}", key, values[key]);
        }
    }

    private static void GetStars()
    {
        int wCoord = 1;
        int hCoord = 1;
        int dCoord = 1;

        while (dCoord + 1 < depth)
        {
            for (int row = hCoord; row < height - 1; row++)
            {
                for (int col = wCoord; col < width - 1; col++)
                {
                    if (cuboid[col, row, dCoord] == cuboid[col, row, dCoord - 1] &&
                        cuboid[col, row, dCoord] == cuboid[col, row, dCoord + 1] &&
                        cuboid[col, row, dCoord] == cuboid[col, row - 1, dCoord] &&
                        cuboid[col, row, dCoord] == cuboid[col, row + 1, dCoord] &&
                        cuboid[col, row, dCoord] == cuboid[col + 1, row, dCoord] &&
                        cuboid[col, row, dCoord] == cuboid[col - 1, row, dCoord])
                    {
                        if (values.ContainsKey(cuboid[col, row, dCoord]))
                        {
                            values[cuboid[col, row, dCoord]]++;
                        }
                        else
                        {
                            values.Add(cuboid[col, row, dCoord], 1);
                        }
                    }
                }
            }

            dCoord++;
        }
    }

    private static void ParseInput()
    {
        string[] cubeDimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        width = int.Parse(cubeDimentions[0]);
        height = int.Parse(cubeDimentions[1]);
        depth = int.Parse(cubeDimentions[2]);

        cuboid = new char[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] currentLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < depth; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    cuboid[w, h, d] = currentLine[d][w];
                }
            }
        }
    }
}