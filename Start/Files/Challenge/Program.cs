using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Program
{
    const string directoryName = "FileCollection";
    const string result_File = "results.txt";

    static Regex excel_file = new Regex(@"\.xlsx$", RegexOptions.IgnoreCase);
    static Regex word_file = new Regex(@"\.docx$", RegexOptions.IgnoreCase);
    static Regex pptx_file = new Regex(@"\.pptx$", RegexOptions.IgnoreCase);

    static void Main(string[] args)
    {
        // Create directory if it doesn't exist
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        // Initialize counters and size trackers
        int excelCount = 0, wordCount = 0, pptxCount = 0;
        long excelSize = 0, wordSize = 0, pptxSize = 0;

        // Enumerate files in the directory
        List<string> files = new List<string>(Directory.EnumerateFiles(directoryName));
        foreach (string file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            
            // Check if it's an Excel file
            if (excel_file.IsMatch(fileInfo.Name))
            {
                excelCount++;
                excelSize += fileInfo.Length;
            }
            // Check if it's a Word file
            else if (word_file.IsMatch(fileInfo.Name))
            {
                wordCount++;
                wordSize += fileInfo.Length;
            }
            // Check if it's a PowerPoint file
            else if (pptx_file.IsMatch(fileInfo.Name))
            {
                pptxCount++;
                pptxSize += fileInfo.Length;
            }
        }

        // Write the results to the file
        using (StreamWriter sw = new StreamWriter(result_File))
        {
            sw.WriteLine("Summary of Office Files in Directory:");
            sw.WriteLine($"Excel Files: {excelCount}, Total Size: {FormatSize(excelSize)}");
            sw.WriteLine($"Word Files: {wordCount}, Total Size: {FormatSize(wordSize)}");
            sw.WriteLine($"PowerPoint Files: {pptxCount}, Total Size: {FormatSize(pptxSize)}");
            sw.WriteLine($"Total Office Files: {excelCount + wordCount + pptxCount}");
            sw.WriteLine($"Total Size of Office Files: {FormatSize(excelSize + wordSize + pptxSize)}");
        }

        Console.WriteLine("Analysis complete! Check the results.txt file.");
    }

    // Helper function to format file size in a human-readable way
    public static string FormatSize(long size)
    {
        if (size >= 1024 * 1024)
            return $"{size / (1024 * 1024)} MB";
        else if (size >= 1024)
            return $"{size / 1024} KB";
        else
            return $"{size} bytes";
    }
}
