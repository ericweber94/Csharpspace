using System;

public class Fraction
{
    private int top;
    private int bottom;

    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int number)
    {
        top = number;
        bottom = 1;
    }

    public Fraction(int top2, int bottom2)
    {
        top = top2;
        bottom = bottom2;
    }

    public string getFractionText()
    {
        string text = $"{top}/{bottom}";
        return text;
    }

    public double getDecimal()
    {
        return (double)top / (double)bottom;
    }
}