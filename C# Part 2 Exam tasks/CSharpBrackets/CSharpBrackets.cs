using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CSharpBrackets
{
    static void Main()
    {
        //DateTime now = DateTime.Now;
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }

        int numberOfLines = int.Parse(Console.ReadLine());
        string inlineString = Console.ReadLine();
        var builder = new StringBuilder();
        int brackets = 0;
        for (int i = 0; i < numberOfLines; i++)
        {
            string line = Console.ReadLine().Trim();
            if (line == string.Empty)
            {
                continue;
            }
            if (line.IndexOf('{') == -1 && line.IndexOf('}') == -1)
            {
                string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < words.Length; j++)
                {
                    builder.AppendFormat("{0} ", words[j]);

                }
                for (int j = 0; j < brackets; j++)
                {
                    builder.Insert(0, inlineString);
                }
                Console.WriteLine(builder.ToString().Trim());
                builder.Clear();
            }
            else
            {
                for (int j = 0; j < line.Length; j++)
                {
                    char ch = line[j];
                    if (ch == '{')
                    {
                        if (builder.Length > 0)
                        {
                            for (int k = 0; k < brackets; k++)
                            {
                                builder.Insert(0, inlineString);
                            }
                            Console.WriteLine(builder.ToString().Trim());
                            builder.Clear();
                        }
                        builder.Append(ch);
                        for (int k = 0; k < brackets; k++)
                        {
                            builder.Insert(0, inlineString);
                        }
                        Console.WriteLine(builder.ToString().Trim());
                        brackets++;
                        builder.Clear();
                    }
                    else if (ch == '}')
                    {
                        if (builder.Length > 0)
                        {
                            for (int k = 0; k < brackets; k++)
                            {
                                builder.Insert(0, inlineString);
                            }
                            Console.WriteLine(builder.ToString().Trim());
                            builder.Clear();
                        }
                        builder.Append(ch);
                        brackets--;
                        for (int k = 0; k < brackets; k++)
                        {
                            builder.Insert(0, inlineString);
                        }
                        Console.WriteLine(builder.ToString().Trim());
                        builder.Clear();
                    }
                    else if (ch == ';' && j == line.Length - 1)
                    {
                        builder.Append(ch);
                        for (int k = 0; k < brackets; k++)
                        {
                            builder.Insert(0, inlineString);
                        }
                        Console.WriteLine(builder.ToString().Trim());
                        builder.Clear();
                    }
                    else
                    {
                        if (ch == ' ' && builder.Length > 0 && builder[builder.Length - 1] != ' ')
                        {
                            builder.Append(ch);
                        }
                        else if (ch != ' ')
                        {
                            builder.Append(ch);
                        }
                    }
                }
            }
           
        }
        //TimeSpan span = DateTime.Now - now;
    }
}
