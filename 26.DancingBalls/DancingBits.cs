using System;

class DancingBits
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        int count = 0;
        int result = 0;
        string allBits = string.Empty;

        for (int i = 0; i < N; i++)
        {
            string currentNumber = Convert.ToString(long.Parse(Console.ReadLine()), 2);
            allBits = allBits + currentNumber;
        }

        count = 1;
        if (K != 1)
        {
            for (int j = 0; j < allBits.Length - 1; j++)
            {
                if (allBits[j] == allBits[j + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count == K)
                {
                    result++;

                }
                if (count > K)
                {

                    count = 1;
                    result--;
                    break;
                }

            }
        }
        else
        {
            result = 1;
            for (int j = 0; j < allBits.Length - 1; j++)
            {
                if (allBits[j] == allBits[j+1])
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == K)
                {
                    result++;

                }
                if (count > K)
                {

                    count = 0;
                    //result--;
                    break;
                }

            }
        }
        
        
            Console.WriteLine(result);

    }
}
