using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        do
        {
            Console.Clear();
            
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            string activityName = "";
            string activityDescription = "";
            int activityDuration = 0;

            List<string> activitysNamesList = new List<string>()
            {
                "Breathing Activity",
                "Reflecting Activity",
                "Listing Activity"
            };

            List<string> activitysDescriptionsList = new List<string>()
            {
                "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
                "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
                "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
            };

            if (choice == 1)
            {
                activityName = activitysNamesList[0];
                activityDescription = activitysDescriptionsList[0];

                BreathingActivity breathingActivity = new(activityName, activityDescription, activityDuration);
                breathingActivity.Run();                
            }
            else if (choice == 2)
            {
                activityName = activitysNamesList[1];
                activityDescription = activitysDescriptionsList[1];

                ReflectingActivity reflectingActivity = new(activityName, activityDescription, activityDuration);
                reflectingActivity.Run();
            }
            else if (choice == 3)
            {
                activityName = activitysNamesList[2];
                activityDescription = activitysDescriptionsList[2];

                ListingActivity listingActivity = new(activityName, activityDescription, activityDuration);
                listingActivity.Run();
            }
            else
            {
                break;
            }          

        } while (choice != 4);
    }
}