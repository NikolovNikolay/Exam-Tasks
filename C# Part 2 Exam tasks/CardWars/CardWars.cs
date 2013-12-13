using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CardWars
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int firstPlayerScore = 0;
        int secondPlayerScore = 0;
        bool firstHasX = false;
        bool secondHasX = false;

        int firstWonGames = 0;
        int secondWonGames = 0;

        for (int i = 0; i < N; i++)
        {
            //char[] firstPlayer = new char[3];
            //char[] secondPlayer = new char[3];
            int firstPlayerHandStrength = 0;
            int secondPlayerHandStrength = 0;

            for (int j = 0; j < 3; j++)
            {
                string token = Console.ReadLine();
                if (token == "Z")
                    firstPlayerScore = firstPlayerScore * 2;
                else if (token == "Y")
                    firstPlayerScore -= 200;
                else if (token == "X")
                    firstHasX = true;
                else
                    firstPlayerHandStrength += GetResult(token);
            }

            for (int j = 0; j < 3; j++)
            {
                string token = Console.ReadLine();
                if (token == "Z")
                    secondPlayerScore = firstPlayerScore * 2;
                else if (token == "Y")
                    secondPlayerScore -= 200;
                else if (token == "X")
                    secondHasX = true;
                else
                    secondPlayerHandStrength += GetResult(token);
            }

            if (firstHasX && secondHasX)
            {
                firstPlayerScore += 50;
                //firstPlayerScore += firstPlayerHandStrength;
                secondPlayerScore += 50;
                // secondPlayerScore += secondPlayerHandStrength;
            }

            if (!firstHasX && secondHasX)
            {

                break;
            }
            else if (firstHasX && !secondHasX)
            {
                break;
            }
            else if (firstPlayerHandStrength > secondPlayerHandStrength)
            {
                firstPlayerScore += firstPlayerHandStrength;
                firstWonGames++;
            }
            else if (firstPlayerHandStrength < secondPlayerHandStrength)
            {
                secondPlayerScore += secondPlayerHandStrength;
                secondWonGames++;
            }
            else
            {
                continue;
            }
        }


        if (!firstHasX && secondHasX)
        {
            Console.WriteLine("X card drawn! Player two wins the match!");
        }
        else if (firstHasX && !secondHasX)
        {
            Console.WriteLine("X card drawn! Player one wins the match!");
        }
        else
        {
            if (firstPlayerScore > secondPlayerScore)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", firstPlayerScore);
                Console.WriteLine("Games won: {0}", firstWonGames);
            }
            else if (firstPlayerScore < secondPlayerScore)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", secondPlayerScore);
                Console.WriteLine("Games won: {0}", secondWonGames);
            }
            else if (firstPlayerScore == secondPlayerScore)
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", firstPlayerScore);
            }
        }
    }

    private static int GetResult(string token)
    {
        switch (token)
        {
            case "2": return 10;
            case "3": return 9;
            case "4": return 8;
            case "5": return 7;
            case "6": return 6;
            case "7": return 5;
            case "8": return 4;
            case "9": return 3;
            case "10": return 2;
            case "A": return 1;
            case "J": return 11;
            case "Q": return 12;
            case "K": return 13;
            default: throw new Exception("Invalid token");
        }
    }
}
