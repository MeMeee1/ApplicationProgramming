// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Example file for formatting string content

float f1 = 123.4f;
int i1 = 2000;

// TODO: Spacing and Alignment: Indexes
// Using string.Format with indexed placeholders and alignment
// The number after the comma specifies the minimum width for the value (positive = right-align, negative = left-align)
string formattedString1 = string.Format("Float value: {0,10} | Integer value: {1,-10}", f1, i1);
Console.WriteLine(formattedString1);

// TODO: Spacing and Alignment: Interpolation
// Using string interpolation with alignment
// The number after the colon specifies the width (positive = right-align, negative = left-align)
string formattedString2 = $"Float value: {f1,10} | Integer value: {i1,-10}";
Console.WriteLine(formattedString2);
