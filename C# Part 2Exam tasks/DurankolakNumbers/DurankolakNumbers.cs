using System;
using System.Collections.Generic;
using System.Numerics;
// един символ включва голяма буква, напр. символи са U, mB, B aG ...
// малките букви се приравняват към големите - смята се тяхната int стойност, първо на малките, после на големите и се събира, като се 
// прибавя към списък с елементи ( съдържа сбора на малките и големите числа, като всеки сбор е един елемент, на който по-късно
// трябва да се изчисли степен. За да се изчисли степента е препоръчително да се обърне Reverse() листът.


class DurankulakNumbers
{
    static void Main()
    {
        string text = Console.ReadLine();

        int capitalSum = 0;
        int lowerSum = 0;
        List<int> elements = new List<int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] >= 'a' && text[i] <= 'a')
            {
                lowerSum = (text[i] - ('a' - 1)) * 26;
            }

            else if (text[i] >= 'A' && text[i] <= 'Z')
            {
                capitalSum = text[i] - 'A' + lowerSum;
                elements.Add(capitalSum);
                lowerSum = 0;
                capitalSum = 0;
            }
        }

        //elements.Reverse();
        BigInteger result = 0;
        int pow = 0;
        for (int i = elements.Count - 1; i >= 0; i--)
        {
            result += elements[i] * CalcPow(pow);
            pow++;
        }

        Console.WriteLine(result);
    }

    static BigInteger CalcPow(int index)
    {
        BigInteger pow = 1;
        for (int i = 0; i < index; index--)
        {
            pow *= 168;
        }

        return pow;
    }
   
}