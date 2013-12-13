using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

class DrunkenNumbers
{
    static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());

        long mitko = 0;
        long vladko = 0;
        List<List<int>> results = new List<List<int>>(rounds);

        for (int i = 0; i < rounds; i++)
        {
            string currentDeal = Console.ReadLine().TrimStart(new char[] { '0', '-' });
            results.Add(GetResults(currentDeal));
        }

        for (int i = 0; i < rounds; i++)
        {
            mitko += results[i][0];
            vladko += results[i][1];
        }

        if (mitko > vladko)
        {
            Console.WriteLine("M {0}", mitko - vladko);
        }
        else if (vladko > mitko)
        {
            Console.WriteLine("V {0}", vladko - mitko);
        }
        else
        {
            Console.WriteLine("No {0}", vladko + mitko);
        }



    }

    static List<int> GetResults(string deal)
    {
        int dealLength = deal.Length;
        var result = new List<int>();

        if (dealLength % 2 == 0)
        {
            int mitko = 0;
            int vladko = 0;

            for (int i = 0; i < deal.Length / 2; i++)
            {
                mitko += int.Parse(deal[i].ToString());
            }
            result.Add(mitko);
            for (int i = deal.Length / 2; i < deal.Length; i++)
            {
                vladko += int.Parse(deal[i].ToString());
            }
            result.Add(vladko);
        }
        else
        {
            int mitko = 0;
            int vladko = 0;

            for (int i = 0; i <= deal.Length / 2; i++)
            {
                mitko += int.Parse(deal[i].ToString());
            }
            result.Add(mitko);
            for (int i = deal.Length / 2; i < deal.Length; i++)
            {
                vladko += int.Parse(deal[i].ToString());
            }
            result.Add(vladko);
        }

        return result;
    }
}