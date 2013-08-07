using System;

class QuadronacciRectangle
{
    static void Main()
    {
        long firstNum = long.Parse(Console.ReadLine());
        long secondNum = long.Parse(Console.ReadLine());
        long thirdNum = long.Parse(Console.ReadLine());
        long fourthNum = long.Parse(Console.ReadLine());

        byte numberOfRows = byte.Parse(Console.ReadLine());
        byte numberOfCols = byte.Parse(Console.ReadLine());

        long result = 0;

        // first line
        Console.Write("{0} {1} {2} {3} ", firstNum, secondNum, thirdNum, fourthNum);
        for (int i = 5; i <= numberOfCols; i++)
        {
            result = firstNum + secondNum + thirdNum + fourthNum;
            firstNum = secondNum;
            secondNum = thirdNum;
            thirdNum = fourthNum;
            fourthNum = result;
            if (i < numberOfCols)
            {
                Console.Write("{0} ", result);
            }
            if (i == numberOfCols)
            {
                Console.Write("{0}", result);
            }
        }
        Console.WriteLine();

        for (int rows = 2; rows <= numberOfRows; rows++)
        {
            //result = 0;
            for (int cols = 1; cols <= numberOfCols; cols++)
            {
                result = firstNum + secondNum + thirdNum + fourthNum;
                firstNum = secondNum;
                secondNum = thirdNum;
                thirdNum = fourthNum;
                fourthNum = result;
                if (cols < numberOfCols)
                {
                    Console.Write("{0} ", result);
                }
                if (cols == numberOfCols)
                {
                    Console.Write("{0}", result);
                }
            }
            Console.WriteLine();
        }
    }
}