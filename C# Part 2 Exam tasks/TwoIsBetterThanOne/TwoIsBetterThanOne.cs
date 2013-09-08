using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TwoIsBetterThanOne
{
    static long luckyNums = 0;

    static void Main()
    {
        //-------------- First task -----------------------------------------
        string[] input = Console.ReadLine().Split();
        long A = long.Parse(input[0]);
        long B = long.Parse(input[1]);

        GetLuckyNumber(A, B);
        Console.WriteLine(luckyNums);

        //-------------------------------------------------------------------
        List<int> numbers = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();
        int percent = int.Parse(Console.ReadLine());
        numbers.Sort();

        for (int i = 0; i < numbers.Count; i++)
        {
            int smallOrEqual = 0;
            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[i] >= numbers[j])
                {
                    smallOrEqual++;
                }
            }

            if (smallOrEqual >= numbers.Count * (percent / 100.0))
            {
                Console.WriteLine(numbers[i]);
                Environment.Exit(0);
            }
        }

        Console.WriteLine(numbers[numbers.Count - 1]);
    }
    //---------------- First task ---------------------------------------
    private static void GetLuckyNumber(long A, long B)
    {
        List<long> numbers = new List<long> { 3, 5 };
        long max = B;
        int left = 0;

        while (left < numbers.Count)
        {
            int right = numbers.Count;
            for (int i = left; i < right; i++)
            {
                if (numbers[i] < max)
                {
                    numbers.Add(numbers[i] * 10 + 3);
                    numbers.Add(numbers[i] * 10 + 5);
                }
            }
            left = right;
        }

        foreach (var num in numbers)
        {
            if (num >= A && num <= B && IsPalindrome(num))
            {
                luckyNums++;
            }
        }

    }

    static bool IsPalindrome(long number)
    {
        string str = number.ToString();
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
}
