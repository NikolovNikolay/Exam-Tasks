using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Garden
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int tomatoSeeds = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        int cucumberSeeds = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        int potatoSeeds = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        int carrotSeeds = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        int cabbageSeeds = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        int beansSeeds = int.Parse(Console.ReadLine());

        double totalCost = tomatoSeeds * 0.5d + cucumberSeeds * 0.4d + potatoSeeds * 0.25d + carrotSeeds * 0.6d + cabbageSeeds * 0.3d + beansSeeds * 0.4d;
        Console.WriteLine("Total costs: {0:F2}", totalCost);

        int usedArea = tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea;
        int beansArea = 250 - usedArea;

        if (usedArea > 250)
        {
            Console.WriteLine("Insufficient area");
        }
        else if (beansArea > 0)
        {
            Console.WriteLine("Beans area: {0}", beansArea);
        }
        else if (beansArea <= 0)
        {
            Console.WriteLine("No area for beans");
        }

    }
}
