using System;

class Program
{
    static void Main()
    {
        int trayOne = int.Parse(Console.ReadLine()); //0.05
        int trayTwo = int.Parse(Console.ReadLine()); //0.10
        int trayThree = int.Parse(Console.ReadLine()); // 0.20
        int trayFour = int.Parse(Console.ReadLine()); // 0.50
        int trayFive = int.Parse(Console.ReadLine()); //1.00

        decimal amountOfMoney = decimal.Parse(Console.ReadLine());
        decimal drinkPrice = decimal.Parse(Console.ReadLine());

        decimal amountIntTrayOne = trayOne * 0.05m;
        decimal amountIntTrayTwo = trayTwo * 0.10m;
        decimal amountIntTrayThree = trayThree * 0.20m;
        decimal amountIntTrayFour = trayFour * 0.50m;
        decimal amountIntTraFive = trayFive * 1.00m;
        decimal amountInMachine = amountIntTrayOne + amountIntTrayTwo + amountIntTrayThree + amountIntTrayFour + amountIntTraFive;


        if (drinkPrice > amountOfMoney)
        {
            Console.WriteLine("More {0:F2}", drinkPrice - amountOfMoney);
        }
        if (amountOfMoney == drinkPrice)
                {
                    Console.WriteLine("Yes {0:F2}", amountInMachine);
                }
        else 
        {
            if (amountOfMoney > drinkPrice)
            {
                decimal change = amountOfMoney - drinkPrice;
                if (amountInMachine < change)
                {
                    decimal remainChange = change - amountInMachine;
                    Console.WriteLine("No {0:F2}", remainChange);
                }

                if (amountInMachine > change)
                {
                    decimal remainInMachine = amountInMachine - change;
                    Console.WriteLine("Yes {0:F2}", remainInMachine);
                }

                
            }

           
        }


    }
}

