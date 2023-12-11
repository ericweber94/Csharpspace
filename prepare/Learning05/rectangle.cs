public class Rectangle : Shape
{
    private double length1;
    private double width1;

    public Rectangle(string color, double length, double width) : base (color)
    {
        length1 = length;
        width1 = width;
    }
    public override double GetArea()
    {
        return length1 * width1;
    }
}