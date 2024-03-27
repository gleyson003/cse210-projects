public class Rectangle : Shape
{
    private double _legnth;
    private double _width;

    public Rectangle(string color, double legnth, double width) : base (color)
    {
        _legnth = legnth;
        _width = width;
    }

    public override double GetArea ()
    {
        return _legnth * _width;
    }
}