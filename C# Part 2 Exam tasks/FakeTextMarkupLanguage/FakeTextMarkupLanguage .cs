using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



class FakeTextMarkupLanguage
{
    private static List<string> OpenTags = new List<string> { "<lower>", "<upper>", "<toggle>", "<rev>", "<del>" };
    private static List<string> CloseTags = new List<string> { "</lower>", "</upper>", "</toggle>", "</rev>", "</del>" };
    private const char OpenTagChar = '<';
    private const char CloseTagChar = '>';

    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());

        for (int line = 0; line < lines; line++)
        {
            string code = Console.ReadLine();
            List<string> content = GetCodeContent(code);

            if (content.Count > 1)
            {
                for (int i = 0; i < content.Count; i++)
                {

                    if (i > 0 && i < content.Count - 1 && !CloseTags.Contains(content[i]) && !OpenTags.Contains(content[i]) &&
                        OpenTags.IndexOf(content[i - 1]) == CloseTags.IndexOf(content[i + 1]))
                    {
                        if (content[i - 1] == "<rev>")
                        {
                            var sb = new StringBuilder();
                            for (int j = content[i].Length - 1; j >= 0; j--)
                            {
                                sb.Append(content[i][j]);
                            }
                            content[i] = sb.ToString();
                            content.RemoveAt(i + 1);
                            content.RemoveAt(i - 1);
                            i--;
                            Check(i, content, sb);

                            i = -1;
                        }
                        else if (content[i - 1] == "<upper>")
                        {
                            var sb = new StringBuilder();
                            for (int j = 0; j < content[i].Length; j++)
                            {
                                if (char.IsLower(content[i][j]))
                                {
                                    sb.Append(char.ToUpper(content[i][j]));
                                }
                                else
                                {
                                    sb.Append(content[i][j]);
                                }

                            }
                            content[i] = sb.ToString();
                            content.RemoveAt(i + 1);
                            content.RemoveAt(i - 1);
                            i--;
                            Check(i, content, sb);

                            i = -1;
                        }
                        else if (content[i - 1] == "<lower>")
                        {
                            var sb = new StringBuilder();
                            for (int j = 0; j < content[i].Length; j++)
                            {
                                if (char.IsUpper(content[i][j]))
                                {
                                    sb.Append(char.ToLower(content[i][j]));
                                }
                                else
                                {
                                    sb.Append(content[i][j]);
                                }

                            }
                            content[i] = sb.ToString();
                            content.RemoveAt(i + 1);
                            content.RemoveAt(i - 1);
                            i--;
                            Check(i, content, sb);

                            i = -1;
                        }
                        else if (content[i - 1] == "<toggle>")
                        {
                            var sb = new StringBuilder();
                            for (int j = 0; j < content[i].Length; j++)
                            {
                                if (char.IsUpper(content[i][j]))
                                {
                                    sb.Append(char.ToLower(content[i][j]));
                                }
                                else
                                {
                                    sb.Append(char.ToUpper(content[i][j]));
                                }
                            }

                            content[i] = sb.ToString();
                            content.RemoveAt(i + 1);
                            content.RemoveAt(i - 1);
                            i--;
                            Check(i, content, sb);

                            i = -1;
                        }
                        else if (!OpenTags.Contains(content[i - 1]))
                        {
                            content[i] = content[i - 1] + content[i];
                            content.RemoveAt(i - 1);

                            i = -1;
                        }
                    }
                    else if (i > 0 && i < content.Count - 1 && !CloseTags.Contains(content[i]) && !OpenTags.Contains(content[i]) &&
                   OpenTags.Contains(content[i - 1]) && !CloseTags.Contains(content[i + 1]))
                    {
                        content[i] = content[i] + content[i + 1];
                        content.RemoveAt(i + 1);
                        i = -1;
                    }
                    else if (i > 0 && i < content.Count - 1 && !CloseTags.Contains(content[i]) && !OpenTags.Contains(content[i]) &&
                    !OpenTags.Contains(content[i - 1]) && CloseTags.Contains(content[i + 1]))
                    {
                        content[i - 1] = content[i - 1] + content[i];
                        content.RemoveAt(i - 1);
                        i = -1;
                    }
                    else if (content[i] == "<del>")
                    {
                        int index = content.IndexOf("</del>");
                        for (int j = index; j >= i; j--)
                        {
                            content.RemoveAt(j);
                        }
                        i = -1;
                    }

                    if (content.Count == 2)
                    {
                        content[0] = content[0] + content[1];
                        content.RemoveAt(1);
                        if (content.Count == 1)
                        {
                            Console.WriteLine(content[0]);
                            break;
                        }
                    }
                }

            }
            else
            {
                Check(0, content, new StringBuilder());
            }
        }
    }

    private static void Check(int i, List<string> content, StringBuilder sb)
    {
        if (i > 0 && i < content.Count - 1)
        {
            if (!CloseTags.Contains(content[i + 1]) && !OpenTags.Contains(content[i + 1]))
            {
                sb.Insert(sb.Length, content[i + 1]);
                content[i] = sb.ToString();
                content.RemoveAt(i + 1);
            }
            else if (!CloseTags.Contains(content[i - 1]) && !OpenTags.Contains(content[i - 1]))
            {
                sb.Insert(0, content[i - 1]);
                content[i] = sb.ToString();
                content.RemoveAt(i - 1);
            }
        }
        else if (content.Count == 2)
        {
            content[0] = content[0] + content[1];
            content.RemoveAt(1);
        }

        if (content.Count == 1)
        {
            Console.WriteLine(content[0]);
            return;
        }
    }

    private static List<string> GetCodeContent(string code)
    {
        List<string> content = new List<string>();
        var builder = new StringBuilder();
        for (int i = 0; i < code.Length; i++)
        {
            char curChar = code[i];
            if (curChar != OpenTagChar)
            {
                builder.Append(curChar);
            }
            else
            {
                if (builder.Length > 0)
                {
                    content.Add(builder.ToString());
                    builder.Clear();
                }
                while (true)
                {
                    builder.Append(curChar);
                    i++;
                    curChar = code[i];
                    if (curChar == CloseTagChar)
                    {
                        builder.Append(curChar);
                        content.Add(builder.ToString());
                        builder.Clear();
                        break;
                    }
                }
            }
        }
        if (builder.Length > 0)
        {
            content.Add(builder.ToString());
        }

        return content;
    }
}
