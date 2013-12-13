using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class BasicBasic
{
    private static string[] commands = new string[10001];
    private static char[] variables = { 'V', 'W', 'X', 'Y', 'Z'};
    private static int[] values = { 0, 0, 0, 0, 0 };
    private static List<char> operators = new List<char> { '<', '>', '=','+','-' };
    private static StringBuilder output = new StringBuilder();

    static void Main()
    {
        GetCommands();

        for (int i = 0; i < 10001; i++)
        {
            if (commands[i] == "STOP")
            {
                break;
            }
            else if (commands[i] == "CLS")
            {
                output.Clear();
            }
            else if (commands[i] != null)
            {
                if (commands[i].Length >= 4)
                {
                    if (commands[i].Substring(0, 4) == "GOTO")
                    {
                       
                        string[] input = commands[i].Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
                        i = int.Parse(input[1]) - 1;
                        continue;
                    } 
                }
                i = ProcessCommand(commands[i], i);
            }
        }
        Console.WriteLine(output.ToString());
    }

    private static int ProcessCommand(string command, int index)
    {
        
        command = command.Replace(" ", string.Empty);
        if (command[1] == '=')
        {
            //determine used operator - indexOf('+')
            // if index is != -1, then + it is, else it is '-'
            //int operatorIndex = command.IndexOf('+');
            char variable = command[0];

            if ((command.Substring(command.IndexOf("=") + 2).IndexOf("+") < 0 &&
                command.Substring(command.IndexOf("=") + 2).IndexOf("-") < 0))
            {
                int result;
                string str = command.Substring(command.IndexOf("=") + 1);
                if (int.TryParse(command.Substring(command.IndexOf("=") + 1), out result))
                {
                    result = int.Parse(command.Substring(command.IndexOf("=") + 1));
                    values[Array.IndexOf(variables, variable)] = result;
                }
                else
                {
                    values[Array.IndexOf(variables, variable)] = result;
                }
            }
            else
            {
                DivideOrAdd(command, variable);
            }

            
        }
        else if (command.Substring(0, 2) == "IF")
        {
            string[] conditions = command.Substring(2).Split(new string[] { "THEN" }, StringSplitOptions.RemoveEmptyEntries);
            bool canPassToThen = ReadOperator(conditions[0]);

            if (canPassToThen)
            {
                if (conditions[1].Length >= 4)
                {
                    if (conditions[1].Substring(0, 4) == "GOTO")
                    {
                        int lineNumber = int.Parse(conditions[1].Substring(4));
                        index = lineNumber - 1;
                    }
                }
                else
                {
                    // DivideOrAdd(conditions[1], conditions[1][0]);
                    if (conditions[1].Substring(conditions[1].IndexOf("=") + 2).IndexOf("+") < 0 &&
                conditions[1].Substring(conditions[1].IndexOf("=") + 2).IndexOf("-") < 0)
                    {
                        int result;
                        string str = command.Substring(command.IndexOf("=") + 1);
                        if (int.TryParse(command.Substring(command.IndexOf("=") + 1), out result))
                        {
                            result = int.Parse(command.Substring(command.IndexOf("=") + 1));
                            values[Array.IndexOf(variables, conditions[1][0])] = result;
                        }
                        else
                        {
                            values[Array.IndexOf(variables, conditions[1][0])] = result;
                        }
                    }
                    else
                    {
                        DivideOrAdd(conditions[1], conditions[1][0]);
                    }
                }

            }
            
        }
        
        if (command.Contains("PRINT"))
        {
            int intValue = values[Array.IndexOf(variables, command[command.Length - 1])];
            output.AppendLine(intValue.ToString());
        }
        

        return index;
    }

    private static void GetCommands()
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        while (true)
        {
            
            string inputCommand = Console.ReadLine();
            if (inputCommand == "RUN")
            {
                break;
            }

            int index = inputCommand.IndexOf(' ');
            commands[int.Parse(inputCommand.Substring(0, index))] = inputCommand.Substring(index + 1).Trim();

        }
    }

    private static bool ReadOperator(string condition)
    {
        char oper = char.MinValue;
        for (int i = 0; i < operators.Count; i++)
        {
            if (condition.Contains(operators[i]) && operators[i] != '-')
            {
                oper = operators[i];
            }
        }
        string value1 = null;
        string value2 = null;
        int intValue1 = 0;
        int intValue2 = 0;
        bool canPassToThen = false;

        int index = condition.IndexOf(oper);
        if (oper != '=')
        {
            value1 = condition.Substring(0, index);
            value2 = condition.Substring(index + 1);

            if (value1.Length == 1)
            {
                if (char.IsLetter(value1[0]))
                {
                    //intValue1 = values[variables[value1[0]]];
                    int ind = Array.IndexOf(variables, value1[0]);
                    intValue1 = values[ind];
                }
                else
                {
                    intValue1 = int.Parse(value1);
                }
            }
            else
            {
                intValue1 = int.Parse(value1);
            }

            if (value2.Length == 1)
            {
                if (char.IsLetter(value2[0]))
                {
                    intValue2 = values[Array.IndexOf(variables, value2[0])];
                }
                else
                {
                    intValue2 = int.Parse(value2);
                }
            }
            else
            {
                intValue2 = int.Parse(value2);
            }
        }
        else
        {
            value1 = condition.Substring(0, index);
            value2 = condition.Substring(index + 1);

            if (value1.Length == 1)
            {
                if (char.IsLetter(value1[0]))
                {
                    //intValue1 = values[variables[value1[0]]];
                    int ind = Array.IndexOf(variables, value1[0]);
                    intValue1 = values[ind];
                }
                else
                {
                    intValue1 = int.Parse(value1);
                }
            }
            else
            {
                intValue1 = int.Parse(value1);
            }

            if (value2.Length == 1)
            {
                if (char.IsLetter(value2[0]))
                {
                    intValue2 = values[Array.IndexOf(variables, value2[0])];
                }
                else
                {
                    intValue2 = int.Parse(value2);
                }
            }
            else
            {
                intValue2 = int.Parse(value2);
            }
        }

        

        if (oper == '>')
        {
            if (intValue1 > intValue2)
            {
                canPassToThen = true;
            } 
        }
        else if (oper == '<')
        {
            if (intValue1 < intValue2)
            {
                canPassToThen = true;
            }
        }
        else if (oper == '=')
        {
            if (intValue1 == intValue2)
            {
                canPassToThen = true;
            }
        }

        return canPassToThen;
    }

    private static void DivideOrAdd(string command, char variable)
    {
        char oper = char.MinValue;
        for (int i = 0; i < operators.Count; i++)
        {
            if (command.Contains(operators[i]) && operators[i] != '=')
            {
                oper = operators[i];
            }
        }

        int result = 0;
        string value1 = command.Substring(command.IndexOf('=') + 1, command.IndexOf(oper) - command.IndexOf('=') - 1);
        string value2 = command.Substring(command.IndexOf(oper) + 1);

        if (value1.Length == 1)
        {
            if (char.IsLetter(value1[0]))
            {
                int index = Array.IndexOf(variables, value1[0]);
                result += values[index];
            }
            else
            {
                result += int.Parse(value1);
            }
        }
        else
        {
            result += int.Parse(value1);
        }

        if (value2.Length == 1)
        {
            if (char.IsLetter(value2[0]))
            {
                int index = Array.IndexOf(variables, value2[0]);
                 
                 if (oper == '-')
                     result -= values[index];
                 else
                     result += values[index];
            }
            else
            {
                if(oper == '-')
                    result -= int.Parse(value2);
                else
                    result += int.Parse(value2);
                
            }
        }
        else
        {
            if (oper == '-')
                result -= int.Parse(value2);
            else
                result += int.Parse(value2);
        }

        values[Array.IndexOf(variables, variable)] = result;
    }
}
