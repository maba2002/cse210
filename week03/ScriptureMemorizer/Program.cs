using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // The List of scriptures to memorize
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Jacob  1:7"),
                "Wherefore we labored diligently among our people, that we might persuade them to come unto Christ, and partake of the goodness of God, that they might enter into his rest, lest by any means he should swear in his wrath they should not enter in, as in the provocation in the days of temptation while the children of Israel were in the wilderness.."),

            new Scripture(new Reference(" Mathew 3:7"),
                "But when he saw many of the Pharisees and Sadducees come to his baptism, he said unto them, O generation of vipers, who hath warned you to flee from the wrath to come?."),
                
            new Scripture(new Reference("1 Nephi 33:1"),
                "And now I, Nephi, cannot write all the things which were taught among my people; neither am I mighty in writing, like unto speaking; for when a man speaketh by the power of the Holy Ghost the power of the Holy Ghost carrieth it unto the hearts of the children of men."),
        };

        // This will Randomly select a scripture
        var rand = new Random();
        var selectedScripture = scriptures[rand.Next(scriptures.Count)];

        selectedScripture.DisplayScripture();

        while (!selectedScripture.IsComplete())
        {
            var input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }
            else if (input == "")
            {
                selectedScripture.HideRandomWord();
                selectedScripture.DisplayScripture();
            }
        }

        // This will hidden scripture display
        selectedScripture.DisplayScripture();
        Console.WriteLine("Memorization complete!");
    }
}

public class Reference
{
    public string Text { get; private set; }

    public Reference(string text)
    {
        Text = text;
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public string GetDisplayText()
    {
        return Hidden ? new string('_', Text.Length) : Text;
    }

    public void Hide()
    {
        Hidden = true;
    }
}

public class Scripture
{
    private static readonly Random rand = new Random();
    public Reference Reference { get; private set; }
    public List<Word> Words { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWord()
    {
        // And this will randomly select a word that is not hidden and hide it
        var visibleWords = Words.Where(w => !w.Hidden).ToList();
        if (visibleWords.Count > 0)
        {
            var wordToHide = visibleWords[rand.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }

    public void DisplayScripture()
    {
        Console.Clear();

        Console.Write(Reference.Text + ": ");
        Console.WriteLine(string.Join(" ", Words.Select(w => w.GetDisplayText())));
        
        Console.WriteLine("Please press Enter to continue or Type 'quit' to finish:");
    }

    public bool IsComplete()
    {
        return !Words.Any(w => !w.Hidden);
    }
}