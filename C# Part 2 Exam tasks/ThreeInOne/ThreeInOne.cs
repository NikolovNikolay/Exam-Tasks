using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    class ThreeInOne
    {
        static void Main()
        {
            int result1 = FirstTaskResolve();
            int result2 = SecondTaskResolve();
            int result3 = ThirdTaskResolve();
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
        }

        private static int ThirdTaskResolve()
        {
            string thirdTaskInputAsString = Console.ReadLine();
            var thirdTaskInputStringParts = thirdTaskInputAsString.Split(' ');
            int G1 = int.Parse(thirdTaskInputStringParts[0]);
            int S1 = int.Parse(thirdTaskInputStringParts[1]);
            int B1 = int.Parse(thirdTaskInputStringParts[2]);
            int G2 = int.Parse(thirdTaskInputStringParts[3]);
            int S2 = int.Parse(thirdTaskInputStringParts[4]);
            int B2 = int.Parse(thirdTaskInputStringParts[5]);

            int exchangeOperations = 0;
            while (G2 > G1)
            {
                G2--;
                S2 += 11;
                exchangeOperations++;
            }

            while (S2 > S1)
            {
                if (G1 > G2)
                {
                    G1--;
                    S1 += 9;
                    exchangeOperations++;
                }
                else
                {
                    S2--;
                    B2 += 11;
                    exchangeOperations++;
                }
            }

            while (B2 > B1)
            {
                if (S1 > S2)
                {
                    S1--;
                    B1 += 9;
                    exchangeOperations++;
                }
                else if (G1 > G2)
                {
                    G1--;
                    S1 += 9;
                    exchangeOperations++;
                }
                else
                {
                    return -1;
                }
            }

            return exchangeOperations; 
        }

        private static int FirstTaskResolve()
        {
            string[] input = Console.ReadLine().Split(',');
            int[] points = input.Select(s => int.Parse(s)).ToArray();

            int winner = 0;
            int maxPoints = 0;

            for (int i = 0; i < points.Length - 1; i++)
            {
                if (points[i] <= 21)
                {
                    if (points[i] > maxPoints)
                    {
                        winner = i;
                        maxPoints = points[i];
                    }
                }
            }

            Array.Sort(points);
            int index = Array.IndexOf(points, maxPoints);
            if (index < points.Length - 1)
            {
                if (points[index] != points[index + 1])
                {
                    return winner;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return winner;
            }

            
        }

        private static int SecondTaskResolve()
        {
            string[] input = Console.ReadLine().Split(',');
            int[] bites = input.Select(s => int.Parse(s)).ToArray();
            int friends = int.Parse(Console.ReadLine());
            Array.Sort(bites);
  
            int length = bites.Length;
            int result = 0;
            for (int i = length-1; i >= 0; i-= friends+1)
            {
                result += bites[i];
            }
            return result;
        }
    }
}
