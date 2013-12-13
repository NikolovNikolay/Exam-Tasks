using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BatGoikoTower
{
    static void Main(string[] args)
    {
        int H = int.Parse(Console.ReadLine());

        char[,] tower = new char[H, 2 * H];
        FillTower(tower, '.');
        int step= 1;
        //int length = 2;
        int start = H - 1;
        for (int row = 1; row < H; row+=step)
        {
            int length = row * 2;
            for (int col = start; col < start + length; col++)
            {
                tower[row, col] = '-';
            }
           
            start -= step + 1;
            step++;
        }
        int rows = 0;
        int left = H - 1;
        int right = H;
        while (rows < H)
        {
            tower[rows, left] = '/';
            tower[rows, right] = '\\';
            rows++;
            left--;
            right++;
        }


        for (int row = 0; row < H; row++)
        {
            for (int col = 0; col < 2*H; col++)
            {
                Console.Write(tower[row,col]);
            }
            Console.WriteLine();
        }
    }

    private static void FillTower(char[,] matrix, char ch)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = ch;
            }
        }
    }
}
