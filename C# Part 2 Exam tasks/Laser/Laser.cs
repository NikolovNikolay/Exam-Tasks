using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int[] dims = ReadNumbersFromConsole();
        int[] pos = ReadNumbersFromConsole();
        int[] vec = ReadNumbersFromConsole();

        bool[, ,] visited = new bool[dims[0] + 1, dims[1] + 1, dims[2] + 1];

        while (true)
        {
            visited[pos[0], pos[1], pos[2]] = true;
            int[] newPos = new int[3];
            for (int i = 0; i < 3; i++)
            {
                newPos[i] = pos[i] + vec[i];
            }

            if (visited[newPos[0], newPos[1], newPos[2]] || GetNumberOfLimits(newPos, dims) >= 2)
            {
                Console.WriteLine("{0} {1} {2}", pos[0], pos[1], pos[2]);
                return;
            }

            if (GetNumberOfLimits(newPos, dims) == 1)
            {
                Reverse(newPos, dims, vec);
            }

            for (int i = 0; i < 3; i++)
            {
                pos[i] = newPos[i];
            }
        }
    }

    static void Reverse(int[] newPos, int[] dims, int[] vector)
    {
        for (int i = 0; i < 3; i++)
        {
            if (newPos[i] == 1 && vector[i] == -1)
            {
                vector[i] *= -1;
            }
            else if (newPos[i] == dims[i] && vector[i] == 1)
            {
                vector[i] *= -1;
            }
        }
    }

    static int GetNumberOfLimits(int[] pos, int[] dimentions)
    {
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            if (pos[i] == 1 || pos[i] == dimentions[i])
            {
                count++;
            }
        }
        return count;
    }

    static int[] ReadNumbersFromConsole()
    {
        int[] result = new int[3];
        string[] data = Console.ReadLine().Split(' ');
        for (int i = 0; i < 3; i++)
        {
            result[i] = int.Parse(data[i]);
        }

        return result;
    }
}