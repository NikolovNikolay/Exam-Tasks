using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        int[] numbers = new int[5];
        int count = 0;
        long biggestNumber = 0;
        long result = 0;
        long allCombinations = 10000000000;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // determin the biggest number
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] < numbers[i + 1])
            {
                biggestNumber = numbers[i + 1];
            }
            if (biggestNumber == 0) biggestNumber = numbers[0];
        }

        // Lest Majourity Multilple is part of the variables
        if (count == 0)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                count = 0;
                for (int j = 0; j < numbers.Length; j++)
                {

                    if (numbers[i] % numbers[j] == 0)
                    {
                        count++;
                    }
                }
                if (count >= 3)
                {
                    Console.WriteLine(numbers[i]);
                    break;
                }
            }
        }
        if (count < 3)
        {
            for (long k = biggestNumber + 1; k < allCombinations; k++)
            {
                count = 0;
                for (int p = 0; p < numbers.Length; p++)
                {
                    if (k % numbers[p] == 0)
                    {
                        count++;
                    }
                }
                if (count >= 3)
                {
                    result = k;
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
