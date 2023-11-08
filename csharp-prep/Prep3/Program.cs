using System;

class Program
{
    static void Main(string[] args)
    {
   Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        
        int guessCount = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
                guessCount = guessCount + 1;
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
                guessCount = guessCount + 1;
            }
            else
            {
                guessCount = guessCount + 1;
                string textVersion = guessCount.ToString();
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {textVersion} guesses!");
            }

        }                    
    }
}