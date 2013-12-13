using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



class BasicLanguage
{
    static void Main()
    {
        string code = ProcessInput();
        int thingsToPrint = Regex.Matches(code, "PRINT").Count;

        string[] commands = code.Split(';');
        for (int i = 0; i < thingsToPrint; i++)
        {
            commands[i] = Regex.Replace(commands[i], @"PRINT\s+", "PRINT");
            string toBePrinted = Regex.Match(commands[i], @"PRINT\(([^)]*)\)").Groups[1].Value;
            long timesToBePrinted = 1;
            if (commands[i].IndexOf("FOR") != -1)
            {
                
                int forQuantity = Regex.Matches(commands[i], "FOR").Count;
                commands[i] = Regex.Replace(commands[i], @"FOR\s+", "FOR");
                for (int k = 0; k < forQuantity; k++)
                {
                    long firstForIndex = commands[i].IndexOf("FOR");
                    string numbers = Regex.Match(commands[i], @"FOR\(([^)]*)\)").Groups[1].Value;
                    string[] values = numbers.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    long[] intValues = new long[values.Length];

                    for (int j = 0; j < values.Length; j++)
                    {
                        intValues[j] = long.Parse(values[j]);
                    }

                    if (intValues.Length > 1)
                    {
                        timesToBePrinted *= ((intValues[1] - intValues[0]) + 1);
                    }
                    else
                    {
                        timesToBePrinted *= intValues[0];
                    }
                    commands[i] = commands[i].Remove((int)firstForIndex, 2);

                }

                for (int j = 0; j < timesToBePrinted; j++)
                {
                    Console.Write(toBePrinted);
                }
            }
            else
            {
                Console.Write(toBePrinted);
            }
        }


        Console.WriteLine();
    }

    static string ProcessInput()
    {
        StringBuilder sb = new StringBuilder();
        string currentLine = "";

        while (!currentLine.EndsWith("EXIT;"))
        {
            currentLine = Console.ReadLine().Trim();
            sb.Append(currentLine);
        }

        return sb.ToString();
    }
}
