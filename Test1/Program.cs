using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;

public class Program
{
    
    static Regex birthdateRegex = new Regex(@"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/(\d{4})$");

    static void Main(string[] args)
    {
        const string filename = "user_info.txt";
        
        // Get user name and birthdate
        Console.WriteLine("Enter your name:");
        string nameInput = Console.ReadLine();

        string birthdateInput;
        while (true)
        {
            Console.WriteLine("Enter your birthdate (mm/dd/yyyy):");
            birthdateInput = Console.ReadLine();

            
            if (birthdateRegex.IsMatch(birthdateInput))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Invalid birthdate format. Please enter in mm/dd/yyyy format.");
            }
        }

    
        using (StreamWriter writer = new StreamWriter(filename, true))
        {
            writer.WriteLine($"Name: {nameInput}, Birthdate: {birthdateInput}");
        }

    
        Console.WriteLine("Contents of the file:");
        using (StreamReader reader = new StreamReader(filename))
        {
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
        }

        
        Console.WriteLine("Enter a directory path:");
        string directoryPath = Console.ReadLine();

       
        if (Directory.Exists(directoryPath))
        {
            Console.WriteLine("Files in the directory:");
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        else
        {
            Console.WriteLine("Directory does not exist.");
        }

        Console.WriteLine("Enter a string to format as title case:");
        string userInput = Console.ReadLine();

        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        string titleCasedInput = textInfo.ToTitleCase(userInput.ToLower());
        Console.WriteLine($"Title cased string: {titleCasedInput}");

        //GC
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Garbage collection triggered.");

    }
}
