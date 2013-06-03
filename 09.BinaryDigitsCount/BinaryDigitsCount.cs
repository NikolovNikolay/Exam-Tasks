using System;

class BinaryDigitsCount
{
    static void Main()
    {
        byte bitToCount = byte.Parse(Console.ReadLine());
        int digitsCount = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < digitsCount; i++)
        {
            long currentNumber = long.Parse(Console.ReadLine());
            int result = 0;
            while (currentNumber != 0)
            {
                if ((currentNumber & 1) == bitToCount)
                {
                    result++;
                }
                currentNumber >>= 1;  
            }
            Console.WriteLine(result);
        }
    }
}
/*

1 0 1 0 1 1 0
            0 

*/