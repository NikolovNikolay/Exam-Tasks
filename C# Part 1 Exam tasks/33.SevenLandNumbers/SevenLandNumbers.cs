using System;

class SevenLandNumbers
{
    static void Main()
    {

        int number = int.Parse(Console.ReadLine());

        byte powerCounter = 0;
        int decimalNumber = 0;

        while(number != 0)
        {
            byte lastNumber = (byte)(number % 10);
            decimalNumber += lastNumber*(int)Math.Pow(8, powerCounter);
            powerCounter++;
            number /= 10;
        }

        decimalNumber++;
        string result = string.Empty;

        while (decimalNumber != 0)
        {
            byte lastNumber = (byte)(decimalNumber % 8);
            result = lastNumber + result;
            decimalNumber /= 8;
        }

        Console.WriteLine(result);
    }
}

