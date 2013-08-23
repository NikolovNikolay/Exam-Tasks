using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


class Cooking
{
    static List<decimal> givenQuantity = new List<decimal>();
    static List<string> originalMeasure = new List<string>();
    static List<string> givenProduct = new List<string>();

    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int products = int.Parse(Console.ReadLine());
        for (int i = 0; i < products; i++)
        {
            string[] tokens = Console.ReadLine().Split(':');
            decimal amount = decimal.Parse(tokens[0]);
            string measure = tokens[1];
            string product = tokens[2];
            AddProduct(amount, measure, product);
        }

        int usedProducts = int.Parse(Console.ReadLine());

        for (int i = 0; i < usedProducts; i++)
        {
            string[] tokens = Console.ReadLine().Split(':');
            decimal usedAmount = decimal.Parse(tokens[0]);
            string measure = tokens[1];
            string product = tokens[2];
            RemoveProduct(usedAmount, measure, product);
        }

        for (int i = 0; i < givenProduct.Count; i++)
        {
            if (givenQuantity[i] > 0)
            {
                Console.WriteLine("{0:F2}:{1}:{2}",ConvertToOriginalUnit(originalMeasure[i],givenQuantity[i]),
                    originalMeasure[i],givenProduct[i]);
            }
        }
    }

    private static void RemoveProduct(decimal amount, string measure, string product)
    {
        decimal amountInMilliliters = ConvertToMilliliters(measure, amount);

        for (int i = 0; i < givenProduct.Count; i++)
        {
            if (string.Compare(givenProduct[i], product, true) == 0)
            {
                givenQuantity[i] -= amountInMilliliters;
                return;
            }
        }
    }

    private static void AddProduct(decimal amount, string measure, string product)
    {
        decimal amountInMilliliters = ConvertToMilliliters(measure, amount);

        for (int i = 0; i < givenProduct.Count; i++)
        {
            if (string.Compare(givenProduct[i], product, true) == 0)
            {
                givenQuantity[i] += amountInMilliliters;
                return;
            }
        }

        givenProduct.Add(product);
        originalMeasure.Add(measure);
        givenQuantity.Add(amountInMilliliters);

    }

    private static decimal ConvertToMilliliters(string unit, decimal quantity)
    {
        switch (unit)
        {
            case "milliliters": return quantity;
            case "mls": return quantity;
            case "tablespoons": return quantity * 15;
            case "tbsps": return quantity * 15;
            case "liters": return quantity * 1000;
            case "ls": return quantity * 1000;
            case "fluid ounces": return quantity * 30;
            case "fl ozs": return quantity * 30;
            case "teaspoons": return quantity * 5;
            case "tsps": return quantity * 5;
            case "gallons": return quantity * 3840;
            case "gals": return quantity * 3840;
            case "pints": return quantity * 480;
            case "pts": return quantity * 480;
            case "quarts": return quantity * 960;
            case "qts": return quantity * 960;
            case "cups": return quantity * 240;
            default: throw new ArgumentException("Invalid unit!");
                
        }
    }

    private static decimal ConvertToOriginalUnit(string unit, decimal quantity)
    {
        switch (unit)
        {
            case "milliliters": return quantity;
            case "mls": return quantity;
            case "tablespoons": return quantity / 15;
            case "tbsps": return quantity / 15;
            case "liters": return quantity / 1000;
            case "ls": return quantity / 1000;
            case "fluid ounces": return quantity / 30;
            case "fl ozs": return quantity / 30;
            case "teaspoons": return quantity / 5;
            case "tsps": return quantity / 5;
            case "gallons": return quantity / 3840;
            case "gals": return quantity / 3840;
            case "pints": return quantity / 480;
            case "pts": return quantity / 480;
            case "quarts": return quantity / 960;
            case "qts": return quantity / 960;
            case "cups": return quantity / 240;
            default: throw new ArgumentException("Invalid unit!");

        }
    }

}
