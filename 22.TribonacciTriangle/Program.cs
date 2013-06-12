using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam._1.Tribonacci_Triangle
{
    class TribonacciTriangle
    {
        static void Main()
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());
            long thirdNumber = long.Parse(Console.ReadLine());
            long numberOfLines = long.Parse(Console.ReadLine());

            long nextNumber = firstNumber + secondNumber + thirdNumber;
            
            Console.WriteLine(firstNumber);
            Console.WriteLine("{0} {1}", secondNumber, thirdNumber);
            
            for (int row = 3; row <= numberOfLines; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    nextNumber = firstNumber + secondNumber + thirdNumber;
                    if (col == row)
                    {
                        Console.Write(nextNumber);
                    }
                    else
                    {
                        Console.Write(nextNumber + " ");
                    }
                    firstNumber = secondNumber;
                    secondNumber = thirdNumber;
                    thirdNumber = nextNumber;
                }
                Console.WriteLine();
            }
        }
    }
}