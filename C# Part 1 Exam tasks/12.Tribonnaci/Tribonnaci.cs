using System;
using System.Numerics;

class Tribonnaci
{
    static void Main()
    {
        BigInteger a = BigInteger.Parse(Console.ReadLine());
        BigInteger b = BigInteger.Parse(Console.ReadLine());
        BigInteger c = BigInteger.Parse(Console.ReadLine());
        BigInteger position = BigInteger.Parse(Console.ReadLine());
        BigInteger d = 0 ;

        if (position == 1)
        {
            Console.WriteLine(a);
        }
        else if (position == 2)
        {
            Console.WriteLine(b);
        }
        else if (position == 3)
        {
            Console.WriteLine(c);
        }
        else
        {
            for (BigInteger i = 3; i < position; i++)
            {
                d = a + b + c;
                a = b;
                b = c;
                c = d;
            }
            Console.WriteLine(d);
        }
    }
}