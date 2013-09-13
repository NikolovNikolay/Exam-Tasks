using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombingCuboids
{
    class Program
    {
        private static char[,,] cube;
        private static int width, height, depth;
        private static Dictionary<char,int> bombedCollors = new Dictionary<char,int>();
        static void Main()
        {
            FillCube();
            int numberOfBombs = int.Parse(Console.ReadLine());
            int allDestoyed = 0;

            for (int i = 0; i < numberOfBombs; i++)
            {
                Bomb currentBomb = new Bomb();
                int[] bombInfo = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
                currentBomb.width = bombInfo[0];
                currentBomb.height = bombInfo[1];
                currentBomb.depth = bombInfo[2];
                currentBomb.power = bombInfo[3];
                bool[,] hasDestoyed = new bool[width, depth];

                for (int w = 0; w < width; w++)
                {
                    for (int h = 0; h < height; h++)
                    {
                        for (int d = 0; d < depth; d++)
                        {
                            double distance = CalculateDistance(w, h, d, currentBomb.width, currentBomb.height, currentBomb.depth);
                            if (cube[w, h, d] == '\0')
                                break;
                            if (distance <= (double)currentBomb.power)
                            {
                                char color = cube[w, h, d];
                                hasDestoyed[w, d] = true;
                                cube[w, h, d] = '\0';
                                allDestoyed++;

                                if (!bombedCollors.ContainsKey(color))
                                {
                                    bombedCollors.Add(color, 1);
                                }
                                else
                                {
                                    bombedCollors[color]++;
                                }
                                
                            }

                            
                        }
                    }
                }

                for (int w = 0; w < width; w++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        if (!hasDestoyed[w, d])
                            continue;
                        int holes = 0;

                        for (int h = 0; h < height; h++)
                        {
                            if (cube[w, h, d] == '\0')
                            {
                                holes++;
                            }
                            else
                            {
                                if (holes != 0)
                                {
                                    cube[w, h - holes, d] = cube[w, h, d];
                                    cube[w, h, d] = '\0';
                                }
                            }
                        }
                    }
                }

            }
            var list = bombedCollors.Keys.ToList();
            list.Sort();

            Console.WriteLine(allDestoyed);
            foreach (var item in list)
            {
                Console.WriteLine("{0} {1}",item, bombedCollors[item]);
            }

        }

        private static double CalculateDistance(int w, int h, int d, int bombW, int bombH, int bombD )
        {
            int distance = 0;
            distance = (w - bombW) * (w - bombW) + (h - bombH) * (h - bombH) + (d - bombD) * (d - bombD);

            return Math.Sqrt(distance);
        }

        private static void FillCube()
        {
            int[] dims = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
            width = dims[0];
            height = dims[1];
            depth = dims[2];

            cube = new char[width, height, depth];
            for (int h = 0; h < height; h++)
            {
                string[] line = Console.ReadLine().Split();
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        cube[w, h, d] = line[d][w];
                    }
                }
            }
        }

    }

    class Bomb
    {
        public int width { get; set; }
        public int height { get; set; }
        public int depth { get; set; }
        public int power { get; set; }
    }
}
