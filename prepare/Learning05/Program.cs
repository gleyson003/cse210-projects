using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new("blue", 9.99);
        shapes.Add(square);

        Rectangle rectangule = new("blue", 9.2, 10);
        shapes.Add(rectangule);

        Circle circle = new("blue", 10);
        shapes.Add(circle);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}