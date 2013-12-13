using System;

class WeAllLoveBits
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());   // Input for the quantity of numbers
        //string P = "";
        //string invertedP = "";
        //string reversedP = "";
        
        for (int i = 0; i < N; i++)
        {
            string P = "";
            string invertedP = "";
            string reversedP = "";
            string number = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(31, '0'); // input number
            
            for (int j = 0; j < number.Length; j++)
            {
                if (number[j] == '1')
                {
                    for (int k = j; k < number.Length; k++)
                    {
                        P = P + number[k];
                    }
                    break;
                }
            }

            string[] invertedParray = new string[P.Length];
            for (int j = 0; j < P.Length; j++)
            {
                if (P[j] == '0')
                {
                    invertedParray[j] = "1";
                }
                if (P[j] == '1')
                {
                    invertedParray[j] = "0";
                }
            }
            for (int j = 0; j < invertedParray.Length; j++)
            {
                if (number != "0000000000000000000000000000001")
                {
                    if (invertedParray[0] == "0")
                    {
                        invertedParray[0] = " ";
                    } 
                }
            }
            
            if (invertedParray[0] == " ")
            {
                for (int j = 1; j < invertedParray.Length; j++)
                {
                    invertedP = invertedP + invertedParray[j];
                }
            }
            if (invertedParray[0] != " ")
            {
                for (int j = 0; j < invertedParray.Length; j++)
                {
                    invertedP = invertedP + invertedParray[j];
                }
            }

            char[] reversedPArray = new char[P.Length];

            for (int j = 0; j < P.Length; j++)
            {
                reversedPArray[j] = P[j];
            }
            Array.Reverse(reversedPArray);
            if (reversedPArray[0] == '0')
            {
                for (int k = 1; k < reversedPArray.Length; k++)
                {
                    reversedP = reversedP + reversedPArray[k];
                }
            }
            if (reversedPArray[0] != '0')
            {
                for (int k = 0; k < reversedPArray.Length; k++)
                {
                    reversedP = reversedP + reversedPArray[k];
                }
            }

            long numberP = Convert.ToInt64(P, 2);
            long invertedNumberP = Convert.ToInt64(invertedP, 2);
            long reversedNumberP = Convert.ToInt64(reversedP, 2);

            long result = (numberP ^ invertedNumberP) & reversedNumberP;
            Console.WriteLine(result);
        }
    }
}

