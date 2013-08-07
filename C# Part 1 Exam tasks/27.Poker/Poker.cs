using System;

class Poker
{
    static void Main()
    {
        int[] inputArray = new int[5];
        //string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        bool impossible = false;
        for (int i = 0; i < 5; i++)
        {
            string card = Console.ReadLine();

            if (card == "J") inputArray[i] = 11;
            if (card == "Q") inputArray[i] = 12;
            if (card == "K") inputArray[i] = 13;
            if (card == "A") inputArray[i] = 14;
            if (card == "2" || card == "3" || card == "4" || card == "5" || card == "6" ||
                card == "7" || card == "8" || card == "9")
            {
                inputArray[i] = Convert.ToInt32(card);
            }
            if (card == "J") inputArray[i] = 11;
            if (card == "Q") inputArray[i] = 12;
            if (card == "K") inputArray[i] = 13;
            if (card == "A") inputArray[i] = 14;
            
        }
        
        
        Array.Sort(inputArray);
        //for (int i = 0; i < 5; i++)
        //{
        //    Console.WriteLine(inputArray[i]);
        //}

        if (inputArray[0] == inputArray[1] && inputArray[1] == inputArray[2] && inputArray[2] == inputArray[3] &&
            inputArray[3] == inputArray[4])  // checks for 5 of a kind cards
        {
            Console.WriteLine("Impossible");
        }
        else if ((inputArray[0] == inputArray[1] && inputArray[1] == inputArray[2] && inputArray[2] == inputArray[3]) ||
                (inputArray[1] == inputArray[2] && inputArray[2] == inputArray[3] && inputArray[3] == inputArray[4]))
        {
            
                Console.WriteLine("Four of a Kind");
        }
        else if (((inputArray[0] == inputArray[1] && inputArray[1] == inputArray[2]) && inputArray[3] == inputArray[4]) ||
                ((inputArray[0] == inputArray[1]) && (inputArray[2] == inputArray[3] && inputArray[3] == inputArray[4])))
        {
            Console.WriteLine("Full House");
        }
        else if (((inputArray[0] == inputArray[1] && inputArray[1] == inputArray[2]) && inputArray[3] == inputArray[4]) ||
                ((inputArray[0] == inputArray[1]) && (inputArray[2] == inputArray[3] && inputArray[3] == inputArray[4])))
        {
            Console.WriteLine("Full House");
        }
        else if ((inputArray[1] - 1 == inputArray[0] && inputArray[2] - 2 == inputArray[0] && inputArray[3] - 3 == inputArray[0] &&
                inputArray[4] - 4 == inputArray[0]) || (inputArray[0] == 2 && inputArray[1] == 3 && inputArray[2] == 4 
                && inputArray[3] == 5 && inputArray[4] == 14))
        {
            Console.WriteLine("Straight");
        }

        else if (((inputArray[0] == inputArray[1] && inputArray[1] == inputArray[2]) && inputArray[3] != inputArray[4]) ||
                (inputArray[2] == inputArray[3] && inputArray[3] == inputArray[4]) && inputArray[0] != inputArray[1])
        {
            Console.WriteLine("Three of a Kind");
        }
        else if ((inputArray[0] == inputArray[1] && (inputArray[2] == inputArray[3] || inputArray[3]== inputArray[4])) ||
            (inputArray[1] == inputArray[2] && (inputArray[0] == inputArray[3] || inputArray[3]== inputArray[4])))
        {
            Console.WriteLine("Two Pairs");
        }
        else if (inputArray[0] == inputArray[1] || inputArray[1] == inputArray[2] || inputArray[2] == inputArray[3] || inputArray[3] == inputArray[4])
        {
            Console.WriteLine("One Pair");
        }
        else
        {
            Console.WriteLine("Nothing");
        }
    }
}


