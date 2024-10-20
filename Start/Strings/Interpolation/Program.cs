// Application Programming .NET Programming with C# by Abdullahi Tijjani

// String Interpolation is a feature that enables the easy insertion of data
// and expression values into a string variable

int a = 100;
float b = 250.0f;
string c = "CSharp";

// String output the old way - using placeholders
Console.WriteLine("The values are {0}, {1} and {2}", a, b, c);

// TODO: Using string interpolation, the code is much easier to read
// With string interpolation, you directly insert variables into the string using $
// It's more readable and you don't need to match placeholders with variable positions
Console.WriteLine($"The values are {a}, {b}, and {c}");

// TODO: Interpolated strings can contain expressions as well
// You can also include expressions directly in the interpolated string
Console.WriteLine($"The sum of a and b is {a + b}");

// TODO: Complex objects can be embedded in strings this way as well
// You can also embed object properties, methods, or even complex calculations
DateTime now = DateTime.Now;
Console.WriteLine($"Today's date is {now.ToLongDateString()} and the time is {now.ToShortTimeString()}");
