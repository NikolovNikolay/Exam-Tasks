using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    class Fire
    {
        private const int divisibleDigit = 4;
        private const char blankChar = '.';
        private const char fireChar = '#';
        private const char torchLeft = '\\';
        private const char torchRight = '/';

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            char[,] light = new char[N - N / divisibleDigit, N];
            char[,] torch = new char[N / 2, N];

            
            LightUp(N, light);
            FillTorch(N, torch);


            PrintMatrix(light);
            Console.WriteLine(new string('-', N));
            PrintMatrix(torch);
        }

        private static void FillTorch(int N, char[,] torch)
        {
            FillMatrix(torch, blankChar);
            int row = 0;
            int startCol = 0;
            int endCol = N;
            while (row != N/2)
            {
                
                for (int col = startCol; col < endCol; col++)
                {
                    if (col < N / 2)
                    {
                        torch[row, col] = torchLeft;
                    }
                    else
                    {
                        torch[row, col] = torchRight;
                    }
                }
                row++;
                startCol++;
                endCol--;
            }
        }

        private static void LightUp(int N, char[,] light)
        {
            FillMatrix(light, blankChar);
            int lRow = 0;
            int lCol = (N / 2 - 1);
            int rRow = 0;
            int rCol = (N / 2);
            int row = 0;
            bool leftGoLeft = true;
            bool rightGoRight = true;

            while (row != light.GetLength(0))
            {
                if (leftGoLeft && rightGoRight)
                {
                    light[row, lCol] = fireChar;
                    light[row, rCol] = fireChar;
                    row++;
                      
                    lCol--;
                    rCol++;
                    if (lCol < 0 && rCol == light.GetLength(1))
                    {
                        leftGoLeft = false;
                        rightGoRight = false;
                        lCol++;
                        rCol--;
                    }
                }
                else
                {
                    light[row, lCol] = fireChar;
                    light[row, rCol] = fireChar;
                    row++;
                    //rCol++;
                    lCol++;
                    rCol--;
                }
            }
        }

        private static void FillMatrix(char[,] matrix, char symbol)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = symbol;
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
