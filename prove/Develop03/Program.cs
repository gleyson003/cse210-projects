using System;

class Program
{
    static void Main(string[] args)
    {
        Reference scriptureReference = new Reference("Mosiah", 4, 9);
        Scripture scripture = new Scripture(scriptureReference, "Believe in God; believe that he is, and that he created all things, both in heaven and in earth; believe that he has all wisdom, and all power, both in heaven and in earth; believe that man doth not comprehend all the things which the Lord can comprehend.");
        string userDecision = "";
        bool allHidden = false;

        do {
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("\nPress enter to continue or type 'quit' to finish: ");

            userDecision = Console.ReadLine().ToLower();
            if (userDecision == "quit")
            {
                break;
            }

            allHidden = scripture.IsCompletelyHidden();
            if (allHidden)
            {
                break;
            }

            
            Console.WriteLine($"{allHidden}");
            scripture.HideRandomWords(2);

            Console.Clear();
        } while (userDecision.ToLower() != "quit");

    }
}