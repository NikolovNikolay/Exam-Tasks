using System;

class Carpets
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        int elementsOnLine = lines;
        int center = elementsOnLine / 2;
        int element = 1;

        for (int i = 1; i <= lines  / 2; i++)
        {
            int elementPosition = 1;
            while (elementPosition <= elementsOnLine)
            {
                if ((elementPosition <= center - i) || (elementPosition > center + i))
                {
                    Console.Write('.');
                    elementPosition++;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (j % 2 != 0)
                        {
                            Console.Write(' ');
                            elementPosition++;
                        }
                        else
                        {
                            Console.Write('/');
                            elementPosition++;
                        }
                    }

                    for (int j = i; j > 0; j--)
                    {
                        if (j % 2 != 0)
                        {
                            Console.Write('\\');
                            elementPosition++;
                        }
                        else
                        {
                            Console.Write(' ');
                            elementPosition++;
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        for (int i = lines /2 ; i > 0; i--)
        {
            int elementPosition = 1;
            while (elementPosition <= elementsOnLine)
            {
                if ((elementPosition <= center - i) || (elementPosition > center + i))
                {
                    Console.Write('.');
                    elementPosition++;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (j % 2 != 0)
                        {
                            Console.Write(' ');
                            elementPosition++;
                        }
                        else
                        {
                            Console.Write('\\');
                            elementPosition++;
                        }
                    }

                    for (int j = i; j > 0; j--)
                    {
                        if (j % 2 != 0)
                        {
                            Console.Write('/');
                            elementPosition++;
                        }
                        else
                        {
                            Console.Write(' ');
                            elementPosition++;
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}