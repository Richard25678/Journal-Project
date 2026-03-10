using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Entry #{i + 1}");
            _entries[i].Display();
        }
    }

    // --- Creative Feature: Delete Entry ---
    public bool DeleteEntry(int index)
    {
        if (index >= 0 && index < _entries.Count)
        {
            _entries.RemoveAt(index);
            return true;
        }
        return false;
    }

    // --- Creative Feature: Search ---
    public void SearchEntries(string keyword)
    {
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (entry.Text.ToLower().Contains(keyword.ToLower()))
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching entries found.");
        }
    }

    public void Save(string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (Entry e in _entries)
            {
                sw.WriteLine($"{e.Date}|{e.Prompt}|{e.Text}");
            }
        }
    }

    public void Load(string fileName)
    {
        _entries.Clear();
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                _entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
    }
}
