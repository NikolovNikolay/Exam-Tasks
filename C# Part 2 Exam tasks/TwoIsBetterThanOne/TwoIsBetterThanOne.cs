using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TwoIsBetterThanOne
{
    private static List<string> unluckyNums = new List<string>() { "1", "2", "4", "6", "7", "8", "9", "0" };

    static void Main()
    {
        string[] bounds = Console.ReadLine().Split(' ');
        long a = long.Parse(bounds[0]);
        long b = long.Parse(bounds[1]);

        long luckuNums = GenerateLuckyNumbers(a, b);
        

        string[] input = Console.ReadLine().Split(',');
        List<int> numbers = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            numbers.Add(int.Parse(input[i]));
        }
        int percentage = int.Parse(Console.ReadLine());

        int secondTask = SecondTaskSolver(numbers, percentage);
        Console.WriteLine(luckuNums);
        Console.WriteLine(secondTask);
       
    }

    static int SecondTaskSolver(List<int> numbers, int percentage)
    {
         numbers.Sort();

        for (int i = 0; i < numbers.Count; i++)
        {
            int smaller = 0;
            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[i] >= numbers[j])
                {
                    smaller++;
                }
            }
            double per = percentage / 100.0;
            if (smaller >= (numbers.Count * per))
            {
                return numbers[i];
            }
        }

        return numbers[numbers.Count - 1];
    }

    static bool IsPalindrome(long number)
    {
        string str = number.ToString();
        for (int i = 0; i < str.Length/2; i++)
        {
            if (str[i] != str[str.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    static long GenerateLuckyNumbers(long a, long b)
    {
        long max = b;
        int left = 0;

        var numbers = new List<long>() { 3, 5 };
        long count = 0;
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
            if (num >= a && num <= b && IsPalindrome(num))
            {
                count++;
            }
        }

        return count;
    }
}
