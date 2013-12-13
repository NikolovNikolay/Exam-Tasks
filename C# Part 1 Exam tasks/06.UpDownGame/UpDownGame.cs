using System;

class UpDownGame
{
    static void Main()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);
        Console.WriteLine("Guess the number :)");
        bool correctAnswer = false;

        while (!correctAnswer)
        {
            
            int guess = int.Parse(Console.ReadLine());
            if (guess != number)
            {
                //Console.Clear();                                    // Clears the numbers already written on the console
                //Console.WriteLine("Guess the number :)");
                if (guess < number)
                {
                    Console.WriteLine("Up");
                }
                else
                {
                    Console.WriteLine("Down");
                }
            }
            else
            {
                correctAnswer = true;
                Console.WriteLine("You've done it! The answer is {0} !", number);
            }
        }
    }
}
