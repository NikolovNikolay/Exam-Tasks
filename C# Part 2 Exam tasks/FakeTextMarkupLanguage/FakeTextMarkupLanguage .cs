using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



class FakeTextMarkupLanguage 
{
    static void Main(string[] args)
    {
        List<string> tags = new List<string>() { "<lower", "<upper", "<rev", "<toggle", "<del" };
        List<string> closeTags = new List<string>() { "</lower", "</upper", "</rev", "</toggle", "</del" };
        List<bool> state = new List<bool>() { false, false, false, false, false };

        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        string text = "";
        int lines = int.Parse(Console.ReadLine());
        var builder = new StringBuilder();
        var result = new StringBuilder();

        for (int line = 0; line < lines; line++)
        {
            string code = Console.ReadLine();

            for (int i = 0; i < code.Length; i++)
            {
                //char ch = code[i];
                if (code[i] == '<' && code[i + 1] != '/')
                {
                    while (code[i] != '>')
                    {
                        builder.Append(code[i]);
                        i++;
                    }

                    if (tags.Contains(builder.ToString()))
                    {
                        int index = tags.IndexOf(builder.ToString());
                        state[index] = true;
                    }
                   
                    builder.Clear();
                }
                if (code[i] == '<' && code[i + 1] == '/')
                {
                    while (code[i] != '>')
                    {
                        builder.Append(code[i]);
                        i++;
                    }

                    if (closeTags.Contains(builder.ToString()))
                    {
                        int index = closeTags.IndexOf(builder.ToString());
                        if (state[0] == true)
                        {
                            text = text.ToLower();
                        }
                        else if (state[1] == true)
                        {
                            text = text.ToUpper();
                        }
                        else if (state[2] == true)
                        {
                            var reverseBuilder = new StringBuilder(text.Length);
                            for (int k = text.Length - 1; k >= 0; k--)
                            {
                                reverseBuilder.Append(text[k]);
                            }

                            text = reverseBuilder.ToString();
                            reverseBuilder.Clear();
                        }
                        else if (state[3] == true)
                        {
                            var sb = new StringBuilder();
                            for (int k = 0; k < text.Length; k++)
                            {
                                if(Char.IsLower(text[k]))
                                {
                                    sb.Append(text[k].ToString().ToUpper());
                                }
                                else if (char.IsUpper(text[k]))
                                {
                                    sb.Append(text[k].ToString().ToLower());
                                }
                            }
                            text = sb.ToString();
                            sb.Clear();
                        }
                        else if (state[4] == true)
                        {
                            text = string.Empty;
                        }

                        state[index] = false;
                    }

                    builder.Clear();
                }
                if (i <= code.Length - 2 && code[i + 1] != '<') // then it is some text between the tags
                {
                    i++;
                    while (code[i] != '<')
                    {
                        builder.Append(code[i]);
                        if (i ==  code.Length - 1)
                        {
                            break;
                        }
                        else
                        {
                            i++;
                        }
                        
                    }
                    text = text + builder.ToString();
                    i--;
                    builder.Clear();
                }
            }
            Console.WriteLine(text);
            text = "";
        }

    }



  
}
