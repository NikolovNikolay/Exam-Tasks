using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class BullsAndCows
    {
        static void Main()
        {
            string number = Console.ReadLine();
            char[] secretNumber = number.ToCharArray();
            char[] backup = number.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                backup[i] = secretNumber[i];
            }
            bool solutionFound = false;

            int B = int.Parse(Console.ReadLine());
            int C = int.Parse(Console.ReadLine());

            //if (B + C > 4 || B > 2)
            //{
            //    Console.WriteLine("No");
            //    Environment.Exit(0);
            //}
            var possibleNumbers = new StringBuilder();

            for (int currentNumber = 1111; currentNumber <= 9999; currentNumber++)
            {
                backup = number.ToCharArray();
                char[] current = currentNumber.ToString().ToCharArray();
                char usedChar = '*';

                if (current.Contains('0'))
                {
                    continue;
                }

                int bulls = 0;
                int cows = 0;
                // find bulls
                for (int digit = 0; digit < backup.Length; digit++)
                {
                    if (current[digit] == backup[digit])
                    {
                        bulls++;
                        current[digit] = backup[digit] = usedChar;
                    }
                }

                //find cows
                for (int i = 0; i < 4; i++) // secret number length
                {
                    for (int j = 0; j < 4; j++) // current number length
                    {
                        if (backup[i] == current[j] && backup[i] != usedChar)
                        {
                            cows++;
                            backup[i] = current[j] = usedChar;
                        }
                    }
                }

                if (bulls == B && cows == C)
                {
                    possibleNumbers.AppendFormat("{0} ", currentNumber);
                    solutionFound = true;
                }

                //for (int i = 0; i < 4; i++)
                //{
                //    secretNumber[i] = backup[i];
                //}
                backup = secretNumber;
            }
            if (solutionFound)
                Console.WriteLine(possibleNumbers.ToString().Trim());
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
