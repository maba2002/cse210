using System;

class Program
{
     public static void Main(string[] args)
    {
        Journal journal = new Journal();
        string[] prompts = {
             "what was nice throgh the day",
            
            "who is the most person l interected with?",
            "How have l seen the hand of the Lord in my life today?",
            "What was the best part of my day?",
            "Have l read the book of Mormon today?",
            "What did l enjoyed today most",
            "Who was the most interesting person I interacted with today?",
            
           
        

        };

        while (true)
        {
            Console.WriteLine(" Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Write in your journal");
            Console.WriteLine("2. Display your journal");
            Console.WriteLine("3. Save the your journal to a file");
            Console.WriteLine("4. Load your journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do today, choose an option: ");

            string option = Console.ReadLine();

            if (option == "1")
            {
                Random random = new Random();
                int index = random.Next(prompts.Length);
                string prompt = prompts[index];
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                journal.AddEntry(prompt, response);
            }
            else if (option == "2")
            {
                journal.DisplayEntries();
            }
            else if (option == "3")
            {
                Console.Write("Please enter filename to save journal: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("your Journal has been saved successfully.");
            }
            else if (option == "4")
            {
                Console.Write("Enter filename to load journal: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine("Journal was loaded successfully.");
            }
            else if (option == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option, please try again with correct option.");
            }
        }
    }

}  
