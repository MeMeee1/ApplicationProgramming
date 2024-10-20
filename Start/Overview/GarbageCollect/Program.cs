// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Demonstration of Garbage Collection

void DoSomeBigOperation() {
    // Create a large memory allocation that's only used in this function
    byte[] myArray = new byte[1000000]; // Allocating 1 million bytes (~1MB)

    // Display the total memory allocated after creating the large array
    Console.WriteLine($"Allocated memory inside function: {GC.GetTotalMemory(false)} bytes");
    Console.ReadLine(); // Wait for user input to pause and observe memory usage
}

// Retrieve and print the total memory allocated before the function call
Console.WriteLine($"Allocated memory before function call: {GC.GetTotalMemory(false)} bytes");
Console.ReadLine(); // Wait for user input

// Call the function that allocates a large memory chunk
DoSomeBigOperation(); // Memory allocation happens here

// TODO: After the function completes, force a Garbage Collection 
GC.Collect(); // Explicitly trigger Garbage Collection
GC.WaitForPendingFinalizers(); // Ensure that finalizers are called

// Retrieve and print the updated total memory after garbage collection
Console.WriteLine($"Allocated memory after garbage collection: {GC.GetTotalMemory(false)} bytes");
Console.ReadLine(); // Wait for user input to observe the difference in memory usage
