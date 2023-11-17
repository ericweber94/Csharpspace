using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction n1 = new Fraction(1, 1);
        Console.WriteLine(n1.getFractionText());
        Console.WriteLine(n1.getDecimal());

        Fraction n2 = new Fraction(6, 1);
        Console.WriteLine(n2.getFractionText());
        Console.WriteLine(n2.getDecimal());

        Fraction n3 = new Fraction(6, 7);
        Console.WriteLine(n3.getFractionText());
        Console.WriteLine(n3.getDecimal());

    //     Fraction n4 = new Fraction(1, 3);
    //     Console.WriteLine(n4.getFractionText());
    //     Console.WriteLine(n4.getDecimal());
    }
}