using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Eric Weber", "addition");
        Console.WriteLine(a1.GetSummary());
        MathAssignment a2 = new MathAssignment("Olivia Murphy", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());
        WritingAssignment a3 = new WritingAssignment("Drew Charley", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}