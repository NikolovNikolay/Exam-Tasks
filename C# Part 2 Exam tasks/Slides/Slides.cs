using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static string[, ,] cuboid;
    static string[] directions = { "L", "R", "F", "B", "FL", "FR", "BL", "BR" };
    static int[] dirsW = { -1, 1, 0, 0, -1, 1, -1, 1 };
    static int[] dirsH = { 1, 1, 1, 1, 1, 1, 1, 1 };
    static int[] dirsD = { 0, 0, -1, 1, -1, -1, 1, 1 };

    static void Main()
    {
        string[] dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int W = int.Parse(dimentions[0]);
        int H = int.Parse(dimentions[1]);
        int D = int.Parse(dimentions[2]);
        cuboid = new string[W, H, D];

        for (int i = 0; i < H; i++)
        {
            string line = Console.ReadLine();
            string[] layers = Array.ConvertAll(line.Split('|'), p => p.Trim());
            for (int j = 0; j < D; j++)
            {
                string[] currentElements = layers[j].Substring(1, layers[j].Length - 2).Split(new string[] { ")(" }, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < W; k++)
                {
                    cuboid[k, i, j] = currentElements[k];
                }
            }
        }

        string[] ballCoordinates = Console.ReadLine().Split(' ');
        int ballW = int.Parse(ballCoordinates[0]);
        int ballD = int.Parse(ballCoordinates[1]);
        int ballH = 0;

        while (true)
        {
            string[] ballPosition = cuboid[ballW, ballH, ballD].Split();
            if (ballPosition[0] == "S")
            {
                int index = Array.IndexOf(directions, ballPosition[1]);
                if (IsInCuboid(ballW + dirsW[index], ballH + dirsH[index], ballD + dirsD[index]))
                {
                    ballW += dirsW[index];
                    ballH += dirsH[index];
                    ballD += dirsD[index];
                }
                else
                {
                    PrintResult(ballW, ballH, ballD);
                    return;
                }
            }
            else if (ballPosition[0] == "T")
            {
                ballW = int.Parse(ballPosition[1]);
                ballD = int.Parse(ballPosition[2]);
            }
            else if (ballPosition[0] == "B")
            {
                PrintResult(ballW, ballH, ballD);
                return;
            }
            else if (ballPosition[0] == "E")
            {
                if (ballH >= H - 1)
                {
                    PrintResult(ballW, ballH, ballD);
                    return;
                }
                ballH++;
            }
        }
    }

    static bool IsInCuboid(int W, int H, int D)
    {
        if (W < 0 || W >= cuboid.GetLength(0) || H < 0 || H >= cuboid.GetLength(1) || D < 0 || D >= cuboid.GetLength(2))
        {
            return false;
        }
        return true;
    }

    static void PrintResult(int W, int H, int D)
    {
        Console.WriteLine(H == cuboid.GetLength(1) - 1 && cuboid[W, H, D] != "B" ? "Yes" : "No");
        Console.WriteLine("{0} {1} {2}", W, H, D);
    }
}