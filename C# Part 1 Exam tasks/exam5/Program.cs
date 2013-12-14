using System;
using System.Collections.Generic;

class Program
{

    static void Main()
    {
        long  number;
        char[] array = new char[32];
        List<int> Final = new List<int>();


        while (true)
        {
            number = long.Parse(Console.ReadLine());
            string strNumber = Convert.ToString(number, 2).PadLeft(32, '0');
            int count = 0;
            
            int elementEnd = 0;
            int elementStart = -1;
            if (number == -1)
            {
                break;
            }
            else
            {
                for (int i = 0; i < strNumber.Length; i++)
                {
                    array[i] = strNumber[i];
                }
                //for (int i = 0; i < array.Length; i++)
                //{
                //    Console.Write(array[i]);
                //}
                for (int i = 0; i < array.Length - 10; i++)
                {
                    if (array[i] == '1' && array[i+1] == '1' && array[i+2] == '1' && array[i+3] == '1' && array[i+4] =='1' &&
                        array[i + 5] == '1' && array[i + 6] == '1' && array[i + 7] == '1' && array[i + 8] == '1' && array[i + 9] == '1' && array[i + 10] == '1')
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = '0';
                    }
                }
                else
                {

                    for (int i = 0; i < strNumber.Length; i++)
                    {
                        array[i] = strNumber[i];
                    }

                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i] == '1' && array[i + 1] != '1')
                        {
                            if (elementStart != -1)
                            {
                                continue;
                            }
                            else
                            elementStart = i;
                        }
                        if (array[i] == '0' && array[i + 1] != '0' )
                        {
                            elementEnd = i + 1;
                            
                        } 
                    }
                    for (int i = elementStart + 1; i < elementEnd; i++)
                    {
                        if (array[i] == '0')
                        {
                            array[i] = '1';
                        }
                    }

                    for (int i = 0; i <= elementStart; i++)
                    {
                        if (array[i] == '1')
                        {
                            array[i] = '0';
                        }
                    }
                    
                    for (int i = elementEnd; i < array.Length- 1; i++)
                    {
                        if (array[i] == '1')
                        {
                            array[i] = '0';
                        }
                    }
                    
                    
                }

                //Console.WriteLine(count);
                //for (int i = 0; i < array.Length; i++)
                //{
                //    Console.Write(array[i]);
                //}

                string finalNumber = "";
                for (int i = 0; i < array.Length; i++)
                {
                    finalNumber = finalNumber + array[i];
                }

                int finalNumb = Convert.ToInt32(finalNumber, 2);
                Final.Add(finalNumb);
            }
        }
        for (int i = 0; i < Final.Count; i++) 
        {
            Console.WriteLine(Final[i]);
        }
    }
} 
