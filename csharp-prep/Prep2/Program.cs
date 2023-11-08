using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        string increment = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (percent/10 >= 7 && letter != "A" && letter != "F")
        {
            increment = "+";
        }
        if (percent/10 <= 3 && letter != "F")
        {
            increment = "-";
        }
        Console.WriteLine($"Your grade is: {letter}{increment}");
        
        if (percent >= 70)
        {
            Console.WriteLine("You passed");
        }
        else
        {
            Console.WriteLine("You failed");
        }


    }
}