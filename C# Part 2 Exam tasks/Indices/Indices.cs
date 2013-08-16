using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Indices
{
    static void Main()
    {
        var numbers = ParseInput();

        Console.WriteLine(GetResult(new StringBuilder(), numbers).ToString().Trim());
    }

    private static StringBuilder GetResult(StringBuilder result, int[] numbers)
    {
        int currentIndex = 0;
        bool[] visited = new bool[numbers.Length];

        while (true)
        {
            if (currentIndex < 0 || currentIndex >= numbers.Length)
            {
                break;
            }
            if (visited[currentIndex])
            {
                int positionLeft = result.ToString().IndexOf((" " + currentIndex + " ").ToString());

                if (positionLeft < 0)
                {
                    result.Insert(0, '(');
                }
                else
                {
                    result[positionLeft] = '(';
                }

                result.Replace(' ', ')', result.Length - 1, 1);
                break;
            }

            visited[currentIndex] = true;
            result.AppendFormat("{0} ", currentIndex);
            currentIndex = numbers[currentIndex];
        }

        return result;
    }

    private static int[] ParseInput()
    {
        int N = int.Parse(Console.ReadLine());

        int[] numbers = new int[N];

        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < N; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        return numbers;
    }
}