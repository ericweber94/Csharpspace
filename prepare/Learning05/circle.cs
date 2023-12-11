public class Circle : Shape
{
    private double radius1;

    public Circle(string color, double radius) : base (color)
    {
        radius1 = radius;
    }

    public override double GetArea()
    {
        return radius1 * radius1 * Math.PI;
    }
}