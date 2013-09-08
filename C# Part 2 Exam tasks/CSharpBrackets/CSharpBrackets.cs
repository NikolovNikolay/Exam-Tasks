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
        //Console.SetIn(new StreamReader("input.txt"));
        int lines = int.Parse(Console.ReadLine());
        string tab = Console.ReadLine();
        int brackets = 0;
        var sb = new StringBuilder();

        for (int line = 0; line < lines; line++)
        {
            string currentLine = Console.ReadLine().Trim();
            if (currentLine == string.Empty)
            {
                continue;
            }
            else if (currentLine.IndexOf('{') < 0 && currentLine.IndexOf('}') < 0)
            {
                string[] words = currentLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    sb.Append(words[i] + " ");
                }
                AppendTabs(brackets, sb, tab);
                Console.WriteLine(sb.ToString().Trim());
                sb.Clear();
            }
            else
            {
                for (int i = 0; i < currentLine.Length; i++)
                {
                    char ch = currentLine[i];
                    if (ch == '{')
                    {
                        if (sb.Length > 0)
                        {
                            AppendTabs(brackets, sb, tab);
                            Console.WriteLine(sb.ToString().Trim());
                            sb.Clear();
                        }
                        sb.Append(ch);
                        AppendTabs(brackets, sb, tab);
                        Console.WriteLine(sb);
                        brackets++;
                        sb.Clear();
                    }
                    else if (ch == '}')
                    {
                        if (sb.Length > 0)
                        {
                            AppendTabs(brackets, sb, tab);
                            Console.WriteLine(sb.ToString().Trim());
                            sb.Clear();
                        }
                        sb.Append(ch);
                        brackets--;
                        AppendTabs(brackets, sb, tab);
                        Console.WriteLine(sb);
                        sb.Clear();
                    }
                    else if (ch == ';' && i == currentLine.Length - 1)
                    {
                        sb.Append(ch);
                        for (int k = 0; k < brackets; k++)
                        {
                            sb.Insert(0, tab);
                        }
                        Console.WriteLine(sb.ToString().Trim());
                        sb.Clear();
                    }
                    else
                    {
                        if (ch == ' ' && sb.Length > 0 && sb[sb.Length - 1] != ' ')
                        {
                            sb.Append(ch);
                        }
                        else if (ch != ' ')
                        {
                            sb.Append(ch);
                        }

                    }
                }
            }
        }
    }

    static void AppendTabs(int brackets, StringBuilder sb, string tab)
    {
        for (int i = 0; i < brackets; i++)
        {
            sb.Insert(0, tab);
        }
    }
}