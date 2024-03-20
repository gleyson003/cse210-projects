using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment testAssignment = new("Samuel Bennett", "Multiplication");
        Console.WriteLine(testAssignment.GetSummary());

        MathAssigment testMath = new("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(testMath.GetSummary());
        Console.WriteLine(testMath.GetHomeworkList());

        WritingAssignment testWriting = new("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(testWriting.GetSummary());
        Console.WriteLine(testWriting.GetWritingInformation());
    }
}