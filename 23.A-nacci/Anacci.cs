using System;

class Anacci
{
    static void Main()
    {
        char[] letters = {' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                         'T', 'U','V','W','X','Y','Z' };

        char firstLetter = char.Parse(Console.ReadLine());
        char secondLetter = char.Parse(Console.ReadLine());
        int numberOfLines = int.Parse(Console.ReadLine());

        int first = Array.IndexOf(letters, firstLetter);
        int second = Array.IndexOf(letters, secondLetter);
        int third = (first + second);
        char thirdLetter;
        if (third > 26)
        {
            thirdLetter = letters[third % 26];
        }
        else
        {
            thirdLetter = letters[third];
        }

        int whitelines = 1;
        Console.WriteLine(firstLetter);
        if (numberOfLines >1)
        {
            Console.WriteLine("{0}{1}", secondLetter, thirdLetter);
            if (numberOfLines > 2)
            {
                for (int i = 3; i <= numberOfLines; i++)
                {
                    firstLetter = secondLetter;
                    secondLetter = thirdLetter;
                    first = Array.IndexOf(letters, firstLetter);
                    second = Array.IndexOf(letters, secondLetter);
                    third = (first + second);

                    if (third > 26)
                    {
                        thirdLetter = letters[third % 26];
                    }
                    else
                    {
                        thirdLetter = letters[third];
                    }
                    
                    for (int j = 1; j <= 1; j++)
                    {
                        Console.Write("{0}", thirdLetter);
                        Console.Write(new string(' ', whitelines));
                    }
                    whitelines++;
                    firstLetter = secondLetter;
                    secondLetter = thirdLetter;
                    first = Array.IndexOf(letters, firstLetter);
                    second = Array.IndexOf(letters, secondLetter);
                    third = (first + second);

                    if (third > 26)
                    {
                        thirdLetter = letters[third % 26];
                    }
                    else
                    {
                        thirdLetter = letters[third];
                    }
                    for (int j = 1; j <= 1; j++)
                    {
                        Console.Write("{0}", thirdLetter);
                    }
                    Console.WriteLine();
                }
                
            }
        }
        
        
    }
}
