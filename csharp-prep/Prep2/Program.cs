using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        Console.Write("What is your grade? ");
        string userGradeInput = Console.ReadLine();
        int userGrade = int.Parse(userGradeInput);

        string letterGrade = "";

        if (userGrade >= 90)
        {
            letterGrade = "A";
        }
        else if (userGrade >= 80)
        {
            letterGrade = "B";
        }
        else if (userGrade >= 70)
        {
            letterGrade = "C";
        }
        else if (userGrade >= 60)
        {
            letterGrade = "D";
        }
        else 
        {
            letterGrade = "F";
        }

        Console.WriteLine($"You letter grade is {letterGrade}");
        
        if (letterGrade == "A" || letterGrade == "B" || letterGrade == "C")
        {
            Console.WriteLine("Congratulation! You finished the course sucessfully.");
        }
        else
        {
            Console.WriteLine("Unfortunately your grade did not reach the required average. But don't be discouraged, you can take the course again and continue improving.");
        }
    }
}