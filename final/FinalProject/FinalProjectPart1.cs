using System;
using System.Collections.Generic;

public abstract class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    public Task(string name, string description, DateTime dueDate)
    {
        Name = name;
        Description = description;
        DueDate = dueDate;
    }

    public abstract void DisplayTaskDetails();
}

public class RecurringTask : Task
{
    public int RecurringInterval { get; set; }

    public RecurringTask(string name, string description, DateTime dueDate, int recurringInterval)
        : base(name, description, dueDate)
    {
        RecurringInterval = recurringInterval;
    }

    public override void DisplayTaskDetails()
    {
        Console.WriteLine($"Recurring Task: {Name}\nDescription: {Description}\nDue Date: {DueDate}\nRecurring Interval: {RecurringInterval} days");
    }
}

public class PriorityTask : Task
{
    public int PriorityLevel { get; set; }

    public PriorityTask(string name, string description, DateTime dueDate, int priorityLevel)
        : base(name, description, dueDate)
    {
        PriorityLevel = priorityLevel;
    }

    public override void DisplayTaskDetails()
    {
        Console.WriteLine($"Priority Task: {Name}\nDescription: {Description}\nDue Date: {DueDate}\nPriority Level: {PriorityLevel}");
    }
}
public class TaskManager
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void DisplayAllTasks()
    {
        foreach (var task in tasks)
        {
            task.DisplayTaskDetails();
            Console.WriteLine();
        }
    }
}
public class UserInterface
{
    private TaskManager taskManager = new TaskManager();

    public void Start()
    {
        Console.WriteLine("Task Management System");

        Task recurringTask = new RecurringTask("Daily Exercise", "Exercise for 30 minutes", DateTime.Now.AddDays(2), 1);
        Task priorityTask = new PriorityTask("Project Deadline", "Complete project report", DateTime.Now.AddDays(5), 2);

        taskManager.AddTask(recurringTask);
        taskManager.AddTask(priorityTask);

        taskManager.DisplayAllTasks();
    }
}

class Program
{
    static void Main()
    {
        UserInterface ui = new UserInterface();
        ui.Start();
    }
}