using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);


        string finish = "";

        while (finish != "yes")
        {
            Console.Write("What is the magic number? ");
            string guessInput = Console.ReadLine();
            int guessNumber = int.Parse(guessInput);

            if (guessNumber > magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guessNumber < magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                finish = "yes";
            }
        }

    }
}