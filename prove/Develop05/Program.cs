using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool Completed { get; set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        Completed = false;
    }

    public virtual void RecordEvent()
    {
        Console.WriteLine($"Goal accomplished: {Name} (+{Value} points)");
        Completed = true;
    }

    public virtual string DisplayStatus()
    {
        return Completed ? "[X]" : "[ ]";
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Eternal goal accomplished: {Name} (+{Value} points)");
    }
}

public class ChecklistGoal : Goal
{
    private int completedCount;
    private int targetCount;

    public ChecklistGoal(string name, int value, int targetCount) : base(name, value)
    {
        this.targetCount = targetCount;
        completedCount = 0;
    }

    public override void RecordEvent()
    {
        completedCount++;
        Console.WriteLine($"Checklist goal accomplished: {Name} (+{Value} points)");

        if (completedCount == targetCount)
        {
            Console.WriteLine($"Bonus: Goal completed {completedCount} times! (+{Value * completedCount} points)");
            Completed = true;
        }
    }

    public int GetBonusPoints()
    {
        return Value * completedCount;
    }

    public override string DisplayStatus()
    {
        return Completed ? $"Completed {completedCount}/{targetCount} times" : "[ ]";
    }
}

public class EternalQuestManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEventForGoal(string goalName)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null && !goal.Completed)
        {
            Console.Write($"Did you achieve the goal '{goal.Name}'? (Y/N): ");
            char response = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (response == 'Y' || response == 'y')
            {
                goal.RecordEvent();
                score += goal.Value;

                if (goal is ChecklistGoal checklistGoal)
                {
                    Console.Write($"\nEnter the number of times '{goal.Name}' was completed: ");
                    int completedTimes = int.Parse(Console.ReadLine());

                    score += checklistGoal.Value * completedTimes;
                    Console.WriteLine($"Bonus: Goal completed {completedTimes} times! (+{checklistGoal.Value * completedTimes} points)");
                }
            }
            else
            {
                Console.WriteLine("Event not recorded.");
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.DisplayStatus()} {goal.Name} (+{goal.Value} points)");
        }

        Console.WriteLine($"Total Score: {score} points");
    }
}

class Program
{
    static void Main()
    {
        EternalQuestManager manager = new EternalQuestManager();

        Goal simpleGoal = new SimpleGoal("Exercise for an hour", 100);
        Goal eternalGoal = new EternalGoal("Read scriptures", 100);
        Goal checklistGoal = new ChecklistGoal("Attend the temple", 50, 10);

        manager.AddGoal(simpleGoal);
        manager.AddGoal(eternalGoal);
        manager.AddGoal(checklistGoal);

        manager.DisplayGoals();

        manager.RecordEventForGoal("Exercise for an hour");
        manager.RecordEventForGoal("Read scriptures");
        manager.RecordEventForGoal("Attend the temple");

        manager.DisplayGoals();

        Console.WriteLine("Create a new goal:");
        Console.Write("Enter goal name: ");
        string newGoalName = Console.ReadLine();

        Console.Write("Enter goal type (1: Simple, 2: Eternal, 3: Checklist): ");
        int goalType = int.Parse(Console.ReadLine());

        Console.Write("Enter goal value: ");
        int goalValue = int.Parse(Console.ReadLine());

        Goal newGoal;
        switch (goalType)
        {
            case 1:
                newGoal = new SimpleGoal(newGoalName, goalValue);
                break;
            case 2:
                newGoal = new EternalGoal(newGoalName, goalValue);
                break;
            case 3:
                Console.Write("Enter target count for checklist goal: ");
                int targetCount = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(newGoalName, goalValue, targetCount);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        manager.AddGoal(newGoal);

        Console.WriteLine("Record an event for a goal:");
        Console.Write("Enter the name of the goal: ");
        string eventName = Console.ReadLine();

        manager.RecordEventForGoal(eventName);

        manager.DisplayGoals();
    }
}
