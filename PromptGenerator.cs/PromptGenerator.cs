using System;

public static class PromptGenerator
{
    private static string[] prompts =
    {
        "What are you grateful for today?",
        "What challenge did you face today?",
        "Describe something that made you smile.",
        "What did you learn today?",
        "Write about a moment you felt peace.",
        "What is something you want to improve tomorrow?"
    };

    public static string GetRandomPrompt()
    {
        Random rand = new Random();
        return prompts[rand.Next(prompts.Length)];
    }

    // --- Creative Feature: Multiple Prompts ---
    public static string[] GetMultiplePrompts(int count)
    {
        string[] result = new string[count];
        Random rand = new Random();

        for (int i = 0; i < count; i++)
        {
            result[i] = prompts[rand.Next(prompts.Length)];
        }

        return result;
    }
}
