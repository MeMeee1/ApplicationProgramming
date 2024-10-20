// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Example file for searching string content

string teststr = "The quick brown Fox jumps over the lazy Dog";

// TODO: Contains determines whether a string contains certain content
// Contains method returns true if the substring is found in the string
bool containsFox = teststr.Contains("Fox");
Console.WriteLine($"Does the string contain 'Fox'? {containsFox}");

// TODO: StartsWith and EndsWith determine if a string starts 
// or ends with a given test string
bool startsWithThe = teststr.StartsWith("The");
bool endsWithDog = teststr.EndsWith("Dog");

Console.WriteLine($"Does the string start with 'The'? {startsWithThe}");
Console.WriteLine($"Does the string end with 'Dog'? {endsWithDog}");

// TODO: IndexOf, LastIndexOf finds the index of a substring
// IndexOf returns the first occurrence of a substring
int indexOfFox = teststr.IndexOf("Fox");
int lastIndexOfO = teststr.LastIndexOf("o");

Console.WriteLine($"Index of 'Fox': {indexOfFox}");
Console.WriteLine($"Last index of 'o': {lastIndexOfO}");

// TODO: Determining empty, null, or whitespace
string str1 = null;
string str2 = "   ";
string str3 = String.Empty;

// Use String.IsNullOrEmpty to check if a string is null or empty
bool isStr1NullOrEmpty = String.IsNullOrEmpty(str1);
bool isStr3NullOrEmpty = String.IsNullOrEmpty(str3);

// Use String.IsNullOrWhiteSpace to check if a string is null, empty, or just whitespace
bool isStr2NullOrWhiteSpace = String.IsNullOrWhiteSpace(str2);

Console.WriteLine($"Is str1 null or empty? {isStr1NullOrEmpty}");
Console.WriteLine($"Is str2 null, empty, or whitespace? {isStr2NullOrWhiteSpace}");
Console.WriteLine($"Is str3 null or empty? {isStr3NullOrEmpty}");
