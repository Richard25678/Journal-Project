using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Text { get; set; }

    public Entry(string date, string prompt, string text)
    {
        Date = date;
        Prompt = prompt;
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Entry: {Text}");
        Console.WriteLine("----------------------------");
    }
}