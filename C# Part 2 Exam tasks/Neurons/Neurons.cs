using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Neurons
{
    static void Main(string[] args)
    {
        while (true)
        {
            long integer = long.Parse(Console.ReadLine());
            if (integer == -1)
            {
                return;
            }
            else if (integer == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                string convertedInteger = Convert.ToString(integer, 2).PadLeft(32, '0');
                int firstIndex = convertedInteger.IndexOf('1');
                int lastIndex = convertedInteger.LastIndexOf('1');
                if (!convertedInteger.Substring(firstIndex, lastIndex - firstIndex + 1).Contains('0'))
                {
                    Console.WriteLine(0);
                }
                else
                {
                    var result = new StringBuilder();
                    for (int i = 0; i < 32; i++)
                    {
                        if (i >= firstIndex && i <= lastIndex)
                        {
                            if (convertedInteger[i] == '1')
                                result.Append('0');
                            else
                                result.Append('1');
                        }
                        else
                            result.Append(convertedInteger[i]);
                    }
                    Console.WriteLine(Convert.ToInt32(result.ToString(), 2));
                }
            }
        }
    }
}
