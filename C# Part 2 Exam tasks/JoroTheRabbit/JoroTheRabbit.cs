using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JoroTheRabbit
{
    static void Main(string[] args)
    {
        //Console.SetIn(new StreamReader("input.txt"));
        int[] terrain = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
        int maxLength = int.MinValue;

        for (int start = 0; start < terrain.Length; start++)
        {
            for (int step = 0; step < terrain.Length; step++)
            {
                int length = 1;
                int current = start;
                int next = (current + step) % terrain.Length;
                while (next != start && terrain[current] < terrain[next])
                {
                    current = next;
                    length++;
                    next = (current + step) % terrain.Length;
                }

                if (length > maxLength)
                {
                    maxLength = length;
                }
            }
        }
        Console.WriteLine(maxLength);
    }
}
