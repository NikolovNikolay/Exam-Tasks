using System;

class AstrologicalNumbers
{
    static void Main()
    {
        string number = Console.ReadLine();
        int sum = 0;

        while (true)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!(number[i] == '.' || number[i] == '-' || number[i] == ','))
                {
                    sum = sum + int.Parse(number[i].ToString());
                }
            }

            number = sum.ToString();
            if (sum <= 9)
            {
                Console.WriteLine(sum);
                break;
            }
            sum = 0; 
        }
    }
}

