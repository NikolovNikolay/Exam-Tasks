using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Collections;

class Program
{
    private static string GetCode()
    {
        var code = new StringBuilder();
        string line = "";
        while (line != "?>")
        {
            line = Console.ReadLine();
            code.AppendLine(line);
        }

        return code.ToString();
    }

    private static bool IsValidVariable(char symbol)
    {
        if (char.IsLetterOrDigit(symbol) || symbol == '_')
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static HashSet<string> GetVariables(string phpCode)
    {
        bool inSingleLineComment = false;
        bool inMultiLineComment = false;
        bool inSingleQuotedString = false;
        bool inDoubleQuotedString = false;
        bool inVariable = false;

        HashSet<string> allVariables = new HashSet<string>();
        var currentVariable = new StringBuilder();
        for (int i = 0; i < phpCode.Length; i++)
        {
            char ch = phpCode[i];

            // this is about // or #, if we are in one line comment and the row is over
            if (inSingleLineComment)
            {
                if (ch == '\n')
                {
                    inSingleLineComment = false;
                    continue;
                }
                else
                {
                    continue;
                }
            }

            // this is about */, if we are in multiline comment
            if (inMultiLineComment)
            {
                if (ch == '*' && phpCode[i + 1] == '/' && i + 1 < phpCode.Length)
                {
                    inMultiLineComment = false;
                    i++;
                    continue;
                }
                else
                {
                    continue;
                }
            }

            // this is all about if we are in a variable
            if (inVariable)
            {
                if (IsValidVariable(ch))
                {
                    currentVariable.Append(ch);
                    continue;
                }
                else
                {
                    if (currentVariable.Length > 0)
                    {
                        allVariables.Add(currentVariable.ToString());
                    }
                    currentVariable.Clear();
                    inVariable = false;
                }
            }

            if (inSingleQuotedString)
            {
                if (ch == '\'')
                {
                    inSingleQuotedString = false;
                    continue;
                }
            }

            if (inDoubleQuotedString)
            {
                if (ch == '"')
                {
                    inDoubleQuotedString = false;
                    continue;
                }
            }

            if (!inSingleQuotedString && !inDoubleQuotedString)
            {
                if (ch == '#')
                {
                    inSingleLineComment = true;
                    continue;
                }

                if (ch == '/' && i + 1 < phpCode.Length && phpCode[i + 1] == '/')
                {
                    inSingleLineComment = true;
                    continue;
                }

                if (ch == '/' && i + 1 < phpCode.Length && phpCode[i + 1] == '*')
                {
                    i++;
                    inMultiLineComment = true;
                    continue;
                }
            }
            else
            {
                if (ch == '\\')
                {
                    i++;
                    continue;
                }
            }

            if (ch == '\'')
            {
                inSingleQuotedString = true;
                continue;
            }

            if (ch == '\"')
            {
                inDoubleQuotedString = true;
                continue;
            }

            if (ch == '$')
            {
                inVariable = true;
                continue;
            }
        }

        return allVariables;
    }

    private static void PrintResult(HashSet<string> result)
    {
        foreach (var variable in result)
        {
            Console.WriteLine(variable);
        }
    }

    static void Main()
    {
        string phpCode = GetCode();
        var result = GetVariables(phpCode);
        Console.WriteLine(result.Count);
        PrintResult(result);
    }
}