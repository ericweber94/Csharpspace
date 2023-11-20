using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Example from bro. Christensen
        string scriptureText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        ScriptureReference reference = new ScriptureReference("John 3:16");
        Scripture scripture = new Scripture(reference, scriptureText);

        MemorizationHelper memorizationHelper = new MemorizationHelper(scripture);
        memorizationHelper.DisplayFullScripture(); // Display the full scripture initially
        Console.WriteLine("\nPress Enter to start memorization.");
        Console.ReadLine(); // Wait for user to press Enter
        Console.Clear();

        memorizationHelper.StartMemorization();
    }
}

class MemorizationHelper
{
    private readonly Scripture _scripture;
    private readonly Random _random;

    public MemorizationHelper(Scripture scripture)
    {
        _scripture = scripture;
        _random = new Random();
    }

    public void DisplayFullScripture()
    {
        Console.WriteLine(_scripture.GetFullText());
    }

    public void StartMemorization()
    {
        while (!_scripture.AllWordsHidden)
        {
            DisplayScripture();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            _scripture.HideRandomWord(_random);
            Console.Clear();
        }

        Console.Clear();
        Console.WriteLine("Program ended. Here is the complete scripture:");
        Console.WriteLine(_scripture.GetFullText());
    }

    private void DisplayScripture()
    {
        Console.WriteLine(_scripture.GetVisibleText());
    }
}

class Scripture
{
    private readonly ScriptureReference _reference;
    private readonly List<ScriptureWord> _words;

    public bool AllWordsHidden => _words.All(word => word.IsHidden);

    public int WordCount => _words.Count;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public void HideRandomWord(Random random)
    {
        List<int> visibleWordIndices = Enumerable.Range(0, _words.Count).Where(i => !_words[i].IsHidden).ToList();
        if (visibleWordIndices.Count > 0)
        {
            int randomIndex = visibleWordIndices[random.Next(visibleWordIndices.Count)];
            _words[randomIndex].IsHidden = true;
        }
    }

    public string GetVisibleText()
    {
        return $"{_reference} {_words.Select(word => word.IsHidden ? "_____" : word.Text).Aggregate((current, next) => $"{current} {next}")}";
    }

    public string GetFullText()
    {
        return $"{_reference}\n{_words.Select(word => word.Text).Aggregate((current, next) => $"{current} {next}")}";
    }
}

class ScriptureReference
{
    public string Book { get; }
    public int? Chapter { get; }
    public int? VerseStart { get; }
    public int? VerseEnd { get; }

    public ScriptureReference(string reference)
    {
        string[] parts = reference.Split(' ');
        string[] bookParts = parts[0].Split(':');
        Book = bookParts[0];

        if (bookParts.Length > 1)
        {
            // Check if the verse reference contains a colon or else it won't work?
            string[] verseParts = bookParts[1].Split('-');
            Chapter = int.Parse(verseParts[0]);
            VerseEnd = verseParts.Length > 1 ? (int?)int.Parse(verseParts[1]) : null;
        }
        else
        {
            Chapter = null;
            VerseStart = null;
            VerseEnd = null;
        }
    }

    public override string ToString()
    {
        if (Chapter.HasValue && VerseStart.HasValue)
        {
            return $"{Book} {Chapter}:{VerseStart}" + (VerseEnd.HasValue ? $"-{VerseEnd}" : "");
        }
        else
        {
            return Book;
        }
    }
}

class ScriptureWord
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public ScriptureWord(string text)
    {
        Text = text;
        IsHidden = false;
    }
}