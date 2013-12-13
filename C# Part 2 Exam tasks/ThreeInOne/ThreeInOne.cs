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
            int index = SolveFirstTask();
            int bites = SolveSecondTask();
            int operations = SolveThirdTask();
            Console.WriteLine(index);
            Console.WriteLine(bites);
            Console.WriteLine(operations);
        }

        private static int SolveThirdTask()
        {
            int operations = 0;
            List<int> resources = Console.ReadLine().Split().Select(s => int.Parse(s)).ToList();
            int G1 = resources[0]; int G2 = resources[3];
            int S1 = resources[1]; int S2 = resources[4];
            int B1 = resources[2]; int B2 = resources[5];



            while (G2 > G1)
            {
                G2--;
                S2 += 11;
                operations++;
            }

            while (S2 > S1)
            {
                if (G1 > G2)
                {
                    G1--;
                    S1 += 9;
                    operations++;
                }
                else
                {
                    S2--;
                    B2 += 11;
                    operations++;
                }
            }

            while (B2 > B1)
            {
                if (S1 > S2)
                {
                    S1--;
                    B1 += 9;
                    operations++;
                }
                else if (G1 > G2)
                {
                    G1--;
                    S1 += 9;
                    operations++;
                }
                else
                {
                    return -1;
                }
            }


            return operations;
        }

        private static int SolveSecondTask()
        {
            int bites = 0;
            List<int> cakes = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToList();
            cakes.Sort();
            int friends = int.Parse(Console.ReadLine());
            for (int i = cakes.Count - 1; i >= 0; i -= friends + 1)
            {
                bites += cakes[i];
            }

            return bites;
        }

        private static int SolveFirstTask()
        {
            int index = 0;
            List<int> points = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToList();
            int equalToTarget = 0;
            int indOf = points.IndexOf(21);

            if (indOf >= 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i] == 21)
                    {
                        equalToTarget++;
                        index = i;
                    }

                    if (equalToTarget > 1)
                    {
                        return -1;
                    }
                }
            }
            else
            {
                var listt = new List<int>();

                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i] < 21)
                    {
                        listt.Add(points[i]);
                    }
                }
                listt.Sort();

                if (listt[listt.Count - 1] == listt[listt.Count - 2])
                {
                    return -1;
                }
                else
                {
                    return points.IndexOf(listt[listt.Count - 1]);
                }
            }


            return index;
        }

    }
}
