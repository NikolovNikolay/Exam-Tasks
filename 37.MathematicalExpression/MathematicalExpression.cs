using System;

class Program
{
    static void Main()
    {
        double N = double.Parse(Console.ReadLine());
        double M = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());

        const double number = 1337;
        const double numberInDenominator = 128.523123123;

        double up = N * N + (1 / (M * P)) + number;
        double down = N - numberInDenominator * P;

        double result = up / down + Math.Sin((int)(M % 180));
        Console.WriteLine("{0:F6}", result);
    }
}