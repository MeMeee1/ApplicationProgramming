using System;  

namespace MyFirstApp  
{  
    class TestFile  
    {  
        static void Main(string[] args)  
        {  
            // Welcome message  
            Console.WriteLine("Welcome to My First C# Application!");  

            // Ask for the user's name  
            Console.Write("Please enter your name: ");  
            string name = Console.ReadLine();  

            // Greet the user  
            Console.WriteLine($"Hello, {name}! It's great to meet you!");  

            // Wait for user input before closing the console  
            Console.WriteLine("Press any key to exit...");  
            Console.ReadKey();  
        }  
    }  
}