using System;
using System.Threading;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        while (true)
        {
            DisplayMenu();
            int choice = GetChoice();

            MindfulnessActivity activity;
            if (choice == 1)
            {
                activity = new BreathingActivity();
            }
            else if (choice == 2)
            {
                activity = new ReflectionActivity();
            }
            else if (choice == 3)
            {
                activity = new ListingActivity();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }
            
            activity.RunActivity();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Mindfulness App Menu");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
    }

    static int GetChoice()
    {
        int choice;
        while (true)
        {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
                return choice;
            else
                Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}

abstract class MindfulnessActivity
{
    protected int Duration;

    public virtual void RunActivity()
    {
        DisplayStartingMessage();
        PrepareToBegin();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"Prepare for {GetType().Name.ToLower()}...");
        Console.Write("Enter the duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine($"Starting {GetType().Name.ToLower()} activity for {Duration} seconds.");
        Thread.Sleep(2000);
    }

    protected virtual void PrepareToBegin()
    {
        Console.WriteLine("Get ready...");
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }

    protected abstract void PerformActivity();

    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You have completed {GetType().Name.ToLower()} for {Duration} seconds.");
        Thread.Sleep(2000);
    }
}

class BreathingActivity : MindfulnessActivity
{
    protected override void PerformActivity()
    {
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        int breathe = Duration/10/2;
        int Duration1 = Duration;
        for (int i = 0; i < 10; i += 1 )
        {
            Console.WriteLine($"Breathe in...({Duration1} sec)");
            Thread.Sleep(breathe*1000);
            Duration1 -= breathe;
            Console.WriteLine($"Breathe out...({Duration1} sec)");
            Thread.Sleep(breathe*1000);
            Duration1 -= breathe;
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static string[] prompts = 
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static string[] reflectionQuestions = 
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    protected override void PerformActivity()
    {
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(prompt);

        foreach (var question in reflectionQuestions)
        {
            Console.WriteLine($"\n{question}");
            Console.Write("\n\\");
            Thread.Sleep(Duration/9*1000/5);
            Console.Write("\b \b");
            Console.Write("_");
            Thread.Sleep(Duration/9*1000/20);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(Duration/9*1000/5);
            Console.Write("\b \b");
            Console.Write("_");
            Thread.Sleep(Duration/9*1000/20);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(Duration/9*1000/5);
            Console.Write("\b \b");
            Console.Write("_");
            Thread.Sleep(Duration/9*1000/20);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(Duration/9*1000/5);
            Console.Write("\b \b");
            Console.Write("_");
            Thread.Sleep(Duration/9*1000/20);
            Console.Write("\b \b");
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private static string[] prompts = 
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected override void PerformActivity()
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("Get ready to list. Starting in 3 seconds...");
        Thread.Sleep(3000);
        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine("Begin listing...");
        List<string> itemList = new List<string>();

        Timer timer = new Timer(TimerCallback, itemList, Duration*1000, Timeout.Infinite);

        while (true)
        {
            string item = Console.ReadLine();

            if (item != null)
            {
                itemList.Add(item);
            }
            else
            {
                break;
            }
        }
        Console.WriteLine($"\nTime's up! You listed {itemList.Count} item(s):");

        foreach (var item in itemList)
        {
            Console.WriteLine(item);
        }
    }
    private static void TimerCallback(object state)
    {
        List<string> itemList = (List<string>)state;

        Console.WriteLine("\nTime's up!");

        Console.WriteLine($"You listed {itemList.Count} item(s):");
        foreach (var item in itemList)
        {
            Console.WriteLine(item);
        }
    }
}




// resources used: 
// To learn how to use timers,
// https://learn.microsoft.com/en-us/dotnet/api/system.timers.timer?view=net-8.0
// https://learn.microsoft.com/en-us/dotnet/api/system.threading.timercallback?view=net-8.0
// To fix issues with certain functions:
// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-8.0