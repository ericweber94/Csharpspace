using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public JournalEntry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"\nDate: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(string prompt, string response)
    {
        JournalEntry entry = new JournalEntry(prompt, response, DateTime.Now);
        entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
        }
        else
        {
            Console.WriteLine("Journal Entries:\n");
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public void SaveToFile(string filename)
    {
        {
            using (StreamWriter OutputFile = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    OutputFile.WriteLine($"{entry.Date};{entry.Prompt};{entry.Response}");
                }
                Console.WriteLine("Journal saved to file successfully!");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
    {
        entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(';');
                if (parts.Length == 3)
                {
                        string prompt = parts[1];
                        string response = parts[2];
                        DateTime date = DateTime.Parse(parts[0]);
                        entries.Add(new JournalEntry(prompt, response, date));
                }
            }
            Console.WriteLine("Journal loaded from file successfully!");
            }
    }

    }
}

class Program
{
    static List<string> prompts = new List<string>
    {
        "What was the most memorable interaction of today?",
        "What was the highlight of the day?",
        "How do I think the Lord could have been working through me today?",
        "How would I rate today on a scale of one to ten?",
        "Who do I think I impacted today?",
        "What should I do differently tomorrow?",
        "What is one thing you learned today?"
    };

    static Journal journal = new Journal();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Welcome to your journal Eric!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            Console.Clear();
Console.WriteLine("Select an option (1-5): ");

            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("Writing a new entry...\n");
                WriteNewEntry();
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Displaying the journal...\n");
                journal.DisplayJournal();
            }
            else if (choice == "3")
            {
                Console.Clear();
                Console.WriteLine("Saving the journal to a file...\n");
                Console.Write("Enter the filename: ");
                string saveFilename = Console.ReadLine();
                journal.SaveToFile(saveFilename);
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Loading the journal from a file...\n");
                Console.Write("Enter the filename: ");
                string loadFilename = Console.ReadLine();
                journal.LoadFromFile(loadFilename);
                journal.DisplayJournal();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }
        }
    }

    static void WriteNewEntry()
    {
        string prompt = prompts[new Random().Next(prompts.Count)];
        Console.WriteLine($"{prompt}\nYour response: ");
        string response = Console.ReadLine();
        journal.AddEntry(prompt, response);
    }
}
// resources used:

// To learn streamwrite:
// https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-7.0

// to learn the syntax of "random" functions:
// https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp

// reminder on manipulatig lines of printed code:
// https://www.educative.io/answers/how-to-print-a-new-line-in-c-sharp

// To learn how to best use lists with classes (recommendation from my brother):
// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-7.0

// To learn how to clear my console when loading
// https://www.tutorialspoint.com/how-to-clear-screen-using-chash#:~:text=Use%20the%20Console.,screen%20and%20the%20console%20buffer.

// To learn modifiers and properties in order to get the load to work right
// https://www.w3schools.com/cs/cs_access_modifiers.php
// https://www.w3schools.com/cs/cs_properties.php