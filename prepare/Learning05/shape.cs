public abstract class Shape
{
    private string color1;

    public Shape(string color)
    {
        color1 = color;
    }

    public string GetColor()
    {
        return color1;
    }

    public void SetColor(string color)
    {
        color1 = color;
    }
    public abstract double GetArea();
}