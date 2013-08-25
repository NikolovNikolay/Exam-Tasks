using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


class CoffeeMachine
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double N1 = double.Parse(Console.ReadLine());
        N1 = N1 * 0.05d;
        double N2 = double.Parse(Console.ReadLine());
        N2 = N2 * 0.1d;
        double N3 = double.Parse(Console.ReadLine());
        N3 = N3 * 0.2d;
        double N4 = double.Parse(Console.ReadLine());
        N4 = N4 * 0.5d;
        double N5 = int.Parse(Console.ReadLine());
        N5 = N5 * 1d;

        double putAmount = double.Parse(Console.ReadLine());
        double priceOfDrink = double.Parse(Console.ReadLine());
        double totalAmountInMachine = N1 + N2 + N3 + N4 + N5;
        double change = putAmount - priceOfDrink;

        if (putAmount >= priceOfDrink && change <= totalAmountInMachine)
        {
            Console.WriteLine("Yes {0:F2}", totalAmountInMachine - change);
        }
        else if (priceOfDrink > putAmount)
        {
            Console.WriteLine("More {0:F2}", priceOfDrink - putAmount);
        }
        else if (putAmount >= priceOfDrink && change >= totalAmountInMachine)
        {
            Console.WriteLine("No {0:F2}", change - totalAmountInMachine);
        }
    }
}
