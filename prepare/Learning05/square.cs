public class Square : Shape
{
    private double side1;

    public Square(string color, double side) : base (color)
    {
        side1 = side;
    }
    public override double GetArea()
    {
        return side1 * side1;
    }
}