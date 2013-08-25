using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < N; i++)
        {
            string[] lineWords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < lineWords.Length; j++)
            {
                builder.AppendFormat(lineWords[j] + " ");
            }
        }

        List<string> allWords = builder.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        builder.Clear();
        int indexOfWhitespace = -1;
        while (true)
        {
            int wordIndex = 0;
            if (allWords.Count != 0 && builder.Length + allWords[wordIndex].Length < M)
            {
                builder.AppendFormat(allWords[wordIndex] + " ");
                //if (allWords.Count == 1)
                //{
                //    Console.WriteLine(builder.ToString().Trim());
                //}
                allWords.Remove(allWords[wordIndex]);


            }
            else if (allWords.Count != 0 && builder.Length + allWords[wordIndex].Length == M)
            {
                builder.AppendFormat(allWords[wordIndex]);
                allWords.Remove(allWords[wordIndex]);
                Console.WriteLine(builder.ToString());
                builder.Clear();
                indexOfWhitespace = 0;
            }
            else
            {
                string str = builder.ToString().Trim();

                for (int i = 0; i < M - str.Length; i++)
                {
                    if (indexOfWhitespace < builder.ToString().Trim().Length)
                    {
                        indexOfWhitespace = builder.ToString().Trim().IndexOf(' ', indexOfWhitespace + 1);
                    }

                    if (indexOfWhitespace == -1)
                    {
                        indexOfWhitespace = builder.ToString().Trim().IndexOf(' ', indexOfWhitespace + 1);
                        //builder.Insert(indexOfWhitespace + 1, ' ');

                    }

                    if (indexOfWhitespace < builder.ToString().Trim().Length)
                    {
                        builder.Insert(indexOfWhitespace + 1, ' ');
                    }
                    indexOfWhitespace++;

                    while (indexOfWhitespace < builder.ToString().Length && builder.ToString()[indexOfWhitespace] == ' ')
                    {
                        indexOfWhitespace++;
                    }
                }

                Console.WriteLine(builder.ToString().Trim());
                builder.Clear();
                indexOfWhitespace = -1;

                if (allWords.Count == 0)
                {
                    break;
                }
            }
        }
    }
}