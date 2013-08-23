using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tubes
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());  // tubes 
        int m = int.Parse(Console.ReadLine());  // friends

        int[] tubes = new int[n];
        int biggestTube = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            tubes[i] = int.Parse(Console.ReadLine());
            if (tubes[i] > biggestTube)
            {
                biggestTube = tubes[i];
            }
        }

        int left = 0;
        int right = biggestTube;
        int middle = (left + right) / 2;
        int maxTube = -1;

        while (left <= right)
        {
            int cutTubes = 0;

            for (int i = 0; i < n; i++)
            {
                cutTubes += tubes[i] / middle;
            }

            if (cutTubes >= m)
            {
                left = middle + 1;
                maxTube = middle;

            }
            else
            {
                right = middle - 1;
            }

            middle = (left + right) / 2;
        }

        Console.WriteLine(maxTube);
    }
}
