using System;
using System.Text;
using System.Collections.Generic;

class MessageInABottle
{
    static string message;
    static List<KeyValuePair<char, string>> ciphers = new List<KeyValuePair<char, string>>();
    static void Main()
    {
        message = Console.ReadLine();
        string cipher = Console.ReadLine();

        
        StringBuilder value = new StringBuilder();

        char key = char.MinValue;
        for (int i = 0; i < cipher.Length; i++)
        {
            if (cipher[i] >= 'A' && cipher[i] <= 'Z')
            {
                if (key != char.MinValue)
                {
                    ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                    value.Clear();
                }
                key = cipher[i];
            }

            else
            {
                value.Append(cipher[i]);
            }
        }

        if (key != char.MinValue)
        {
            ciphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
            value.Clear();
        }

        Decrypt(0, new StringBuilder());

        Console.WriteLine(solutions.Count);
        solutions.Sort();
        foreach (var solution in solutions)
        {
            Console.WriteLine(solution);
        }
    }

    static List<string> solutions = new List<string>();
    static void Decrypt(int secretMessageIndex, StringBuilder sb)
    {
        if (secretMessageIndex == message.Length)
        {
            solutions.Add(sb.ToString());
            return;
        }

        for (int i = 0; i < ciphers.Count; i++)
        {
            if (message.Substring(secretMessageIndex).StartsWith(ciphers[i].Value))
            {
                sb.Append(ciphers[i].Key);
                Decrypt(secretMessageIndex + ciphers[i].Value.Length, sb);
                sb.Length--;
            }
        }

    }
}