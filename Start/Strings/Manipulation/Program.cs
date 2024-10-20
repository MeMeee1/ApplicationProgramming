// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Example file for manipulating string content

string str1 = "The quick brown fox jumps over the lazy dog.";
string str2 = "This is a string";
string str3 = "THIS is a STRING";
string[] strs = { "one", "two", "three", "four" };

// TODO: Length of a string 
// The Length property gets the number of characters in a string
Console.WriteLine($"Length of str1: {str1.Length}");

// TODO: Access individual characters
// You can access individual characters using indexer notation
Console.WriteLine($"The first character of str1: {str1[0]}");
Console.WriteLine($"The last character of str1: {str1[str1.Length - 1]}");

// TODO: Iterate over a string like any other sequence of values
// You can loop through a string as if it were an array of characters
Console.WriteLine("Characters in str2:");
foreach (char ch in str2) {
    Console.Write(ch + " ");
}
Console.WriteLine();

// TODO: String Concatenation         
// Using the + operator to concatenate strings
string outstr = str2 + " " + str3;
Console.WriteLine($"Concatenated string: {outstr}");

// TODO: Joining strings together with Join
// The Join method combines an array of strings into one string, separated by a specified delimiter
string joinedStr = string.Join(", ", strs);
Console.WriteLine($"Joined string: {joinedStr}");

// TODO: String Comparison
// Equals method is used to check if two strings are identical, considering case
bool isEqual = str2.Equals(str3); // False since str2 and str3 differ in case
Console.WriteLine($"Are str2 and str3 equal? {isEqual}");

// Compare method compares two strings lexicographically
int comparisonResult = string.Compare(str2, str3); // Returns a negative value because str2 < str3
Console.WriteLine($"Comparison result of str2 and str3: {comparisonResult}");

// TODO: Replacing content
// Replace method replaces all occurrences of a substring with another substring
string replacedStr = str1.Replace("fox", "cat");
Console.WriteLine($"After replacing 'fox' with 'cat': {replacedStr}");
