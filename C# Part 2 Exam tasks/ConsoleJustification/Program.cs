using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 100/ 100
class Program
{
    static void Main()
    {
       //Console.SetIn(new StreamReader("input.txt"));
        int lines = int.Parse(Console.ReadLine());
        int tokens = int.Parse(Console.ReadLine());
        var builder = new StringBuilder();

        List<string> allWords = new List<string>();

        for (int i = 0; i < lines; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < line.Length; j++)
			{
                allWords.Add(line[j]);
			}
        }

        int last = 0;
        for (int j = 0; j < allWords.Count; j++)
        {
            if (builder.Length + allWords[j].Length <= tokens)
            {
                builder.Append(allWords[j] + " ");
                last = j;
            }
            else
            {
                CheckResult(builder, tokens, allWords, j);
                last = j;
            }
        }

        if (builder.Length > 0)
        {
            for (int j = last; j < allWords.Count; j++)
            {
                CheckResult(builder, tokens, allWords, j); 
            }

        }
    }
  
    private static void CheckResult(StringBuilder builder, int tokens, List<string> allWords, int j)
    {
        if (builder.Length > tokens)
        {
            builder.Length--;
            Console.WriteLine(builder);
            builder.Clear();
            builder.Append(allWords[j] + " ");
            
        }
        else if (builder.Length == tokens && builder[builder.Length - 1] == ' ')
        {
            builder.Length--;
            int ind = builder.ToString().IndexOf(' ');
            if(ind > 0)
            builder.Insert(builder.ToString().IndexOf(' '), ' ');
            

            Console.WriteLine(builder);
            builder.Clear();
            builder.Append(allWords[j] + " ");
        }
        else if (builder.Length < tokens)
        {
            builder.Length--;

            int whitespaces = tokens - builder.Length;
            int startIndex = 0;
            int indOf = builder.ToString().IndexOf(" ", startIndex);
            if (indOf < 0)
            {
                whitespaces = 0;
            }

            while (whitespaces != 0)
            {
                builder.Insert(indOf, " ");
                startIndex = indOf;
                while (builder[startIndex] == ' ')
                {
                    startIndex++;
                }
                indOf = builder.ToString().IndexOf(" ", startIndex);
                if (indOf < 0)
                {
                    startIndex = 0;
                    indOf = builder.ToString().IndexOf(" ", startIndex);
                }
                whitespaces--;
            }

            Console.WriteLine(builder);
            builder.Clear();
            builder.Append(allWords[j] + " ");
        }
    }
}