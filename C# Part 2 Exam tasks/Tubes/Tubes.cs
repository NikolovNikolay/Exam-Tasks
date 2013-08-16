using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tubes
{
    static void Main()
    {
        int tubes = int.Parse(Console.ReadLine());
        long friends = long.Parse(Console.ReadLine());

        long[] tubesLength = new long[tubes];
        long maxtube = -1;
        long mintube = long.MaxValue;
        for (int i = 0; i < tubes; i++)
        {
            tubesLength[i] = long.Parse(Console.ReadLine());
            if (maxtube < tubesLength[i])
            {
                maxtube = tubesLength[i];
            }
            
        }

        long left = 1;
        long right = maxtube;
        long middle = (right - left) / 2;
        long result = -1;

        while (left <= right)
        {
            long currentTube = 0;

            for (int i = 0; i < tubesLength.Length; i++)
            {
                currentTube += tubesLength[i] / middle;
            }

            if (currentTube < friends)
            {
                right = middle - 1;
            }
            else if (currentTube >= friends)
            {
                left = middle + 1;
                result = middle;
            }

            middle = (right + left) / 2;
        }
        Console.WriteLine(result);
    }
}
