using System;

public class Program
{
    public static void Main()
    {
        while (true) // Continuous loop until user types "exit"
        {
            Console.WriteLine("Enter a date (MM/DD/YYYY) or type 'exit' to quit:");
            string input = Console.ReadLine();

            // Exit the program if the user types "exit"
            if (input.ToLower() == "exit")
            {
                break;
            }

            // Try parsing the date input
            DateTime enteredDate;
            bool isValidDate = DateTime.TryParse(input, out enteredDate);

            if (isValidDate)
            {
                DateTime currentDate = DateTime.Now;
                
                // Calculate the difference between the current date and entered date
                TimeSpan dateDifference = enteredDate - currentDate;

                if (dateDifference.TotalDays > 0)
                {
                    // Future date
                    Console.WriteLine($"The date is {Math.Ceiling(dateDifference.TotalDays)} days in the future.");
                }
                else if (dateDifference.TotalDays < 0)
                {
                    // Past date
                    Console.WriteLine($"The date was {Math.Abs(Math.Floor(dateDifference.TotalDays))} days ago.");
                }
                else
                {
                    // Today
                    Console.WriteLine("The date you entered is today.");
                }
            }
            else
            {
                // Invalid date format
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }

        Console.WriteLine("Program exited. Goodbye!");
    }
}
