using System;
using System.Collections.Generic;

namespace PersonalizedTaskManager
{
    public abstract class TaskBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public TaskBase(string name, string description, DateTime dueDate)
        {
            Name = name;
            Description = description;
            DueDate = dueDate;
        }

        public virtual void DisplayTaskDetails()
        {
            Console.WriteLine($"Task: {Name}\nDescription: {Description}\nDue Date: {DueDate.ToString("MM/dd/yyyy hh:mm tt")}");
        }
    }

    public class RecurringTask : TaskBase
    {
        public int RecurringInterval { get; set; }

        public RecurringTask(string name, string description, DateTime dueDate, int recurringInterval)
            : base(name, description, dueDate)
        {
            RecurringInterval = recurringInterval;
        }

        public override void DisplayTaskDetails()
        {
            base.DisplayTaskDetails();
            Console.WriteLine($"Next Occurrence: {DueDate.AddDays(RecurringInterval).ToString("MM/dd/yyyy hh:mm tt")}");
        }
    }

    public class PriorityTask : TaskBase
    {
        public int PriorityLevel { get; set; }

        public PriorityTask(string name, string description, DateTime dueDate, int priorityLevel)
            : base(name, description, dueDate)
        {
            PriorityLevel = priorityLevel;
        }

        public override void DisplayTaskDetails()
        {
            base.DisplayTaskDetails();
            Console.WriteLine($"Priority Level: {PriorityLevel}");
        }
    }

    public class TaskManager
    {
        private List<TaskBase> tasks = new List<TaskBase>();

        public void AddTask(TaskBase task)
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

        public void DisplayTasksWithPriority(int priority)
        {
            var priorityTasks = tasks.FindAll(t => t is PriorityTask && ((PriorityTask)t).PriorityLevel == priority);

            if (priorityTasks.Count == 0)
            {
                Console.WriteLine($"No tasks found with Priority Level {priority}.");
            }
            else
            {
                Console.WriteLine($"Tasks with Priority Level {priority}:\n");

                foreach (var task in priorityTasks)
                {
                    task.DisplayTaskDetails();
                    Console.WriteLine();
                }
            }
        }
    }

    public class PersonalizedTaskManager
    {
        public static void Main()
        {
            Console.WriteLine("Personalized Task Manager");

            TaskBase recurringTask = new RecurringTask("Daily Exercise", "lift weights for 30 minutes and do abs for 10", DateTime.Now.AddDays(1), 1);
            TaskBase priorityTask1 = new PriorityTask("Jewelry vendor Meeting", "Discuss latest jewelry collections", DateTime.Now.AddDays(3), 1);
            TaskBase priorityTask2 = new PriorityTask("Meet daily sales goal!", "calculate it first and then do all you can to sell", DateTime.Now.AddDays(5), 2);

            TaskBase loveTask1 = new PriorityTask("Surprise Olivia (your wife) in some way", $"Plan and execute a surprise date night for Olivia", DateTime.Now.AddDays(7), 3);
            TaskBase loveTask2 = new RecurringTask("Tell Olivia you love her", $"Leave a love note for Olivia", DateTime.Now.AddDays(1), 1);

            TaskManager taskManager = new TaskManager();
            taskManager.AddTask(recurringTask);
            taskManager.AddTask(priorityTask1);
            taskManager.AddTask(priorityTask2);
            taskManager.AddTask(loveTask1);
            taskManager.AddTask(loveTask2);

            Console.WriteLine("All Tasks:\n");
            taskManager.DisplayAllTasks();

            Console.WriteLine("\nTasks with Priority Level 2:\n");
            taskManager.DisplayTasksWithPriority(2);
        }
    }
}
