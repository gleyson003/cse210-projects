using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        Console.WriteLine("Enter a list of Numbers, type 0 when finished.");

        int enterNumber = 0;
        List<int> numbersList = new List<int>();

        do
        {
            Console.Write("Enter number:");
            enterNumber = int.Parse(Console.ReadLine());
            numbersList.Add(enterNumber);
        } while(enterNumber != 0);

        Console.WriteLine($"The sum is: {numbersList.Sum()}");
        Console.WriteLine($"The average is: {numbersList.Average()}");
        Console.WriteLine($"The largest number is: {numbersList.Max()}");
    }
}