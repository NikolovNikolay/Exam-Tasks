using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());

        BigInteger mitko = 0;
        BigInteger vladko = 0;

        for (int i = 0; i < rounds; i++)
        {
            string number = Console.ReadLine();
            number = number.TrimStart('-');
            number = number.TrimStart('0');
            
            int[] array = new int[number.Length];
            for (int j = 0; j < array.Length; j++)
            {
                
                    int num = Convert.ToInt32(new string(number[j], 1));
                    array[j] = num;
          
                
            }
            
            if (array.Length % 2 == 0)
            {
                for (int k = 0; k < array.Length / 2; k++)
                {
                    mitko += array[k];

                }
                for (int k = array.Length / 2; k < array.Length; k++)
                {
                    vladko += array[k];
                }
            }

            if (array.Length % 2 != 0)
            {
                for (int k = 0; k <= array.Length / 2; k++)
                {
                    mitko += array[k];

                }
                for (int k = array.Length / 2; k < array.Length; k++)
                {
                    vladko += array[k];
                }
            }

        }

        if (mitko > vladko)
        {
            Console.WriteLine("M {0}", mitko - vladko);
        }
        if (mitko < vladko)
        {
            Console.WriteLine("V {0}", vladko - mitko);
        }
        if (mitko == vladko)
        {
            Console.WriteLine("No {0}", mitko + vladko);
        }
            
    }
}
