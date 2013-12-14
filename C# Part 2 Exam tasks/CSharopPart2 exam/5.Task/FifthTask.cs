using System;
using System.Collections.Generic;
using System.Linq;

class Grisko
{
    static public IEnumerable<string> GetPermutations(string word)
    {
        if (word.Length > 1)
        {
            char character = word[0];
            foreach (string subPermute in GetPermutations(word.Substring(1)))
            {
                for (int index = 0; index <= subPermute.Length; index++)
                {
                    string pre = subPermute.Substring(0, index);
                    string post = subPermute.Substring(index);

                    if (post.Contains(character))
                        continue;

                    yield return pre + character + post;
                }
            }
        }
        else
        {
            yield return word;
        }
    }

    private static int ProcessPermutations(IEnumerable<string> result, string input)
    {
        int count = 0;
        foreach (var item in result)
        {
            int temp = 1;
            for (int i = 0; i < item.Length - 1; i++)
            {
                if (item[i] != item[i + 1])
                    temp++;
                else
                    break;
            }

            if (temp == input.Length)
                count++;
        }

        return count;
    }

    static void Main()
    {
        string input = Console.ReadLine();

        var result = GetPermutations(input);

        Console.WriteLine(ProcessPermutations(result, input));
    }
}
