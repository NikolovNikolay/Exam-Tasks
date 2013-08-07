using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GenomeDecoder
{
    static void Main()
    {
        string[] mN = Console.ReadLine().Split(' ');
        int N = int.Parse(mN[0]);
        int M = int.Parse(mN[1]);
        string genome = Console.ReadLine();

        var wholekey = new StringBuilder();
        var value = new StringBuilder();

        for (int i = 0; i < genome.Length; i++)
        {
            if (genome[i] >= '0' && genome[i] <= '9')
            {
                value.Append(genome[i]);
            }
            else if(genome[i] == 'A' || genome[i] == 'C' || genome[i] == 'G' || genome[i] == 'T')
            {
                if (value.Length != 0)
                    wholekey.Append(new string(genome[i], int.Parse(value.ToString())));
                else
                    wholekey.Append(new string(genome[i], 1));
                value.Clear();
            }
        }

        int lineNumber = 1;
        int untilBreak = M;
        int charCount = 0;

        int index = 0;
        int inline = ((wholekey.Length/N) + 1).ToString().Length;
        for (int i = index; index < wholekey.Length; i++)
        {
            var printLine = new StringBuilder();
            printLine.Append(lineNumber.ToString().PadLeft(inline, ' ') + ' ');

            for (int j = 1; j <= N; j++)
            {
                 printLine.Append(wholekey[index]);
                 index++;
                 if (index + 1 > wholekey.Length || j == N)
                 {
                     break;
                 }
                 if (j % M == 0)
                 {
                     printLine.Append(" ");
                 } 
            }
                
            
            lineNumber++;
            
            Console.WriteLine(printLine.ToString());
        }
    }
}
