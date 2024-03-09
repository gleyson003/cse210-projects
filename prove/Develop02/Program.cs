using System;
using System.IO;
using System.Text.Json.Nodes;


class Program
{
    static void Main(string[] args)
    {
        int userChoice = 0;
        Journal journal = new Journal();

        do
        {
            Console.WriteLine($"Please select one of the following choices: ");
            Console.WriteLine("1.Write");
            Console.WriteLine("2.Display");
            Console.WriteLine("3.Load");
            Console.WriteLine("4.Save");
            Console.WriteLine("5.Quit");
            Console.Write("What would you like to do? ");
            userChoice = int.Parse(Console.ReadLine());

            if (userChoice == 1)
            {
                PromptGenerator promptList = new PromptGenerator
                {
                    _prompts = [
                        "What was the best part of your day?",
                        "If I had one thing I could do over today, what would it be?",
                        "Who is the most interesting person with I interacted today?",
                        "What happened today that I would like to be remembered?"
                    ]
                };

                Entry userWrite = new Entry
                {
                    _promptText = promptList.GetRandomPrompt()
                };

                Console.WriteLine(userWrite._promptText);
                Console.Write("> ");
                userWrite._entryText = Console.ReadLine();

                DateTime currentDate = DateTime.Now;
                userWrite._date = currentDate.ToString("MM-dd-yyyy");

                journal.AddEntry(userWrite);
                Console.WriteLine("\n");
            }
            else if (userChoice == 2)
            {
                Console.WriteLine("\n");
                journal.DisplayAll();
            }
            else if (userChoice == 3)
            {
                Console.Write("What is the filename? ");
                journal.LoadFromFile(Console.ReadLine());
                Console.WriteLine("\n");
            }
            else if (userChoice == 4)
            {
                Console.Write("What is the filename? ");
                journal.SaveToFile(Console.ReadLine());
                Console.WriteLine("\n");
                
            }
            else if (userChoice > 5)
            {
                Console.WriteLine("Choose one of the numbers from the options shown.\n");
            }
            else
            {
                Console.WriteLine("Choose one of the numbers from the options shown.\n");
            }

        } while (userChoice != 5);

        Console.WriteLine("Your code is finished");
    }
}