using System;

// --- Creativity Explanation for Teacher ---
// I added the following extra features:
// 1. Delete an entry
// 2. Search entries by keyword
// 3. Choose from multiple prompts instead of one
// These features go beyond requirements and improve user control.

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Delete Entry (Creative)");
            Console.WriteLine("6. Search Entries (Creative)");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string date = DateTime.Now.ToShortDateString();
                string[] prompts = PromptGenerator.GetMultiplePrompts(3);

                Console.WriteLine("Choose a prompt:");
                for (int i = 0; i < prompts.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {prompts[i]}");
                }

                int selected = int.Parse(Console.ReadLine());
                string prompt = prompts[selected - 1];

                Console.Write("Your entry: ");
                string text = Console.ReadLine();

                journal.AddEntry(new Entry(date, prompt, text));
                Console.WriteLine("Entry added!");
            }
            else if (choice == "2")
            {
                journal.DisplayEntries();
            }
            else if (choice == "3")
            {
                Console.Write("File name: ");
                journal.Save(Console.ReadLine());
            }
            else if (choice == "4")
            {
                Console.Write("File name: ");
                journal.Load(Console.ReadLine());
            }
            else if (choice == "5")
            {
                Console.Write("Delete entry number: ");
                int index = int.Parse(Console.ReadLine()) - 1;

                if (journal.DeleteEntry(index))
                    Console.WriteLine("Entry deleted.");
                else
                    Console.WriteLine("Invalid entry number.");
            }
            else if (choice == "6")
            {
                Console.Write("Enter keyword: ");
                journal.SearchEntries(Console.ReadLine());
            }
            else if (choice == "7")
            {
                break;
            }
        }
    }
}