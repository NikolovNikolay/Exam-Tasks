using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// 60 / 100
class FakeTextMarkupLanguage
{
    static void Main()
    {
        //Console.SetIn(new StreamReader("input.txt"));
        string[] tags = new string[] { "rev", "upper", "toggle", "del", "lower" };
        string[] closeTags = new string[] { "/rev", "/upper", "/toggle", "/del", "/lower" };


        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var words = Console.ReadLine().Split(new char[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var strToMaintain = new StringBuilder();

            for (int j = words.Count - 1; j >= 0; j--)
            {
                if (tags.Contains(words[j]))
                {
                    if (words[j] == "rev")
                    {
                        if (words[j + 1] == "/rev")
                        {
                            words.RemoveAt(j + 1);
                            words.RemoveAt(j);
                            if (!tags.Contains(words[j]) && !closeTags.Contains(words[j]))
                            {
                                if (j + 1 < words.Count)
                                {
                                    if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                                    {
                                        words[j] = words[j] + words[j + 1];
                                        words.RemoveAt(j + 1);
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                                    {
                                        words[j - 1] = words[j - 1] + words[j];
                                        words.RemoveAt(j);
                                    }
                                }
                            }

                            j = words.Count;
                            continue;
                        }
                        for (int k = words[j + 1].Length - 1; k >= 0; k--)
                        {
                            strToMaintain.Append(words[j + 1][k]);
                        }
                        words[j] = strToMaintain.ToString();
                        strToMaintain.Clear();
                        words.RemoveAt(words.IndexOf("/rev", j));
                        words.RemoveAt(j + 1);
                        if (j + 1 < words.Count)
                        {
                            if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                            {
                                words[j] = words[j] + words[j + 1];
                                words.RemoveAt(j + 1);
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                            {
                                words[j - 1] = words[j - 1] + words[j];
                                words.RemoveAt(j);
                            }
                        }

                        j = words.Count;
                    }
                    else if (words[j] == "upper")
                    {
                        if (words[j + 1] == "/upper")
                        {
                            words.RemoveAt(j + 1);
                            words.RemoveAt(j);
                            if (!tags.Contains(words[j]) && !closeTags.Contains(words[j]))
                            {
                                if (j + 1 < words.Count)
                                {
                                    if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                                    {
                                        words[j] = words[j] + words[j + 1];
                                        words.RemoveAt(j + 1);
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                                    {
                                        words[j - 1] = words[j - 1] + words[j];
                                        words.RemoveAt(j);
                                    }
                                }
                            }

                            j = words.Count;
                            continue;
                        }
                        for (int k = 0; k < words[j + 1].Length; k++)
                        {
                            if (char.IsLower(words[j + 1][k]))
                                strToMaintain.Append(char.ToUpper(words[j + 1][k]));
                            else
                                strToMaintain.Append(words[j + 1][k]);
                        }
                        words[j] = strToMaintain.ToString();
                        strToMaintain.Clear();
                        words.RemoveAt(words.IndexOf("/upper", j));
                        words.RemoveAt(j + 1);
                        if (j + 1 < words.Count)
                        {
                            if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                            {
                                words[j] = words[j] + words[j + 1];
                                words.RemoveAt(j + 1);
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                            {
                                words[j - 1] = words[j - 1] + words[j];
                                words.RemoveAt(j);
                            }
                        }

                        j = words.Count;
                    }
                    else if (words[j] == "lower")
                    {
                        if (words[j + 1] == "/lower")
                        {
                            words.RemoveAt(j + 1);
                            words.RemoveAt(j);
                            if (!tags.Contains(words[j]) && !closeTags.Contains(words[j]))
                            {
                                if (j + 1 < words.Count)
                                {
                                    if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                                    {
                                        words[j] = words[j] + words[j + 1];
                                        words.RemoveAt(j + 1);
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                                    {
                                        words[j - 1] = words[j - 1] + words[j];
                                        words.RemoveAt(j);
                                    }
                                }
                            }

                            j = words.Count;
                            continue;
                        }
                        for (int k = 0; k < words[j + 1].Length; k++)
                        {
                            if (char.IsUpper(words[j + 1][k]))
                                strToMaintain.Append(char.ToLower(words[j + 1][k]));
                            else
                                strToMaintain.Append(words[j + 1][k]);
                        }
                        words[j] = strToMaintain.ToString();
                        strToMaintain.Clear();
                        words.RemoveAt(words.IndexOf("/lower", j));
                        words.RemoveAt(j + 1);
                        if (j + 1 < words.Count)
                        {
                            if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                            {
                                words[j] = words[j] + words[j + 1];
                                words.RemoveAt(j + 1);
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                            {
                                words[j - 1] = words[j - 1] + words[j];
                                words.RemoveAt(j);
                            }
                        }

                        j = words.Count;
                    }
                    else if (words[j] == "toggle")
                    {
                        if (words[j + 1] == "/toggle")
                        {
                            words.RemoveAt(j + 1);
                            words.RemoveAt(j);
                            if (!tags.Contains(words[j]) && !closeTags.Contains(words[j]))
                            {
                                if (j + 1 < words.Count)
                                {
                                    if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                                    {
                                        words[j] = words[j] + words[j + 1];
                                        words.RemoveAt(j + 1);
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                                    {
                                        words[j - 1] = words[j - 1] + words[j];
                                        words.RemoveAt(j);
                                    }
                                }
                            }

                            j = words.Count;
                            continue;
                        }
                        for (int k = 0; k < words[j + 1].Length; k++)
                        {
                            if (char.IsUpper(words[j + 1][k]))
                                strToMaintain.Append(char.ToLower(words[j + 1][k]));
                            else
                                strToMaintain.Append(char.ToUpper(words[j + 1][k]));
                        }
                        words[j] = strToMaintain.ToString();
                        strToMaintain.Clear();
                        words.RemoveAt(words.IndexOf("/toggle", j));
                        words.RemoveAt(j + 1);
                        if (j + 1 < words.Count)
                        {
                            if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                            {
                                words[j] = words[j] + words[j + 1];
                                words.RemoveAt(j + 1);
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                            {
                                words[j - 1] = words[j - 1] + words[j];
                                words.RemoveAt(j);
                            }
                        }

                        j = words.Count;
                    }
                    else if (words[j] == "del")
                    {
                        if (words[j + 1] == "/del")
                        {
                            words.RemoveAt(j + 1);
                            words.RemoveAt(j);
                            if (!tags.Contains(words[j]) && !closeTags.Contains(words[j]))
                            {
                                if (j + 1 < words.Count)
                                {
                                    if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                                    {
                                        words[j] = words[j] + words[j + 1];
                                        words.RemoveAt(j + 1);
                                    }
                                }
                                if (j - 1 >= 0)
                                {
                                    if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                                    {
                                        words[j - 1] = words[j - 1] + words[j];
                                        words.RemoveAt(j);
                                    }
                                }
                            }

                            j = words.Count;
                            continue;
                        }
                        words.RemoveAt(words.IndexOf("/del", j));
                        words.RemoveAt(j + 1);
                        words.RemoveAt(j);
                        if (j + 1 < words.Count)
                        {
                            if (!tags.Contains(words[j + 1]) && !closeTags.Contains(words[j + 1]))
                            {
                                words[j] = words[j] + words[j + 1];
                                words.RemoveAt(j + 1);
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            if (!tags.Contains(words[j - 1]) && !closeTags.Contains(words[j - 1]))
                            {
                                words[j - 1] = words[j - 1] + words[j];
                                words.RemoveAt(j);
                            }
                        }

                        j = words.Count;
                    }
                }


            }
            Console.WriteLine(words[0]);
        }
    }
}
