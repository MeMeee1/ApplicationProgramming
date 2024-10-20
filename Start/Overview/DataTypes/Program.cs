// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Example file for .NET Data Types

// Declare some types with values
int a = 1;          // Integer type initialized with value 1
char c = 'A';       // Character type initialized with 'A'
float f = 123.45f;  // Floating-point type initialized with 123.45
decimal d = 400.85m; // Decimal type initialized with 400.85
int b = default;    // Integer type with default value (0)
bool tf = default;  // Boolean type with default value (false)

Console.WriteLine($"{a}, {b}, {tf}, {c}, {f}, {d}");

// TODO: Implicit type conversion
// Example of implicit conversion: convert `a` (int) to `float`
float convertedFloat = a; // `a` is converted to a float automatically
Console.WriteLine($"Implicit conversion from int to float: {convertedFloat}");

// TODO: Create an instance of a struct (which is a value type)
// Creating an instance of the struct 's'
s myStruct = new s(); 
myStruct.a = 5;
myStruct.b = false;
Console.WriteLine($"Struct before modification: {myStruct.a}, {myStruct.b}");

// Perform an operation on a struct
void StructOp(s theStruct) {
    // Modify the struct properties inside the function
    theStruct.a = 10;
    theStruct.b = true;
    Console.WriteLine($"Struct inside function: {theStruct.a}, {theStruct.b}");
}

// Structs are passed by copy, since they are value types:
Console.WriteLine($"Struct before function call: {myStruct.a}, {myStruct.b}");
StructOp(myStruct); // The struct is passed by value (copy)
Console.WriteLine($"Struct after function call: {myStruct.a}, {myStruct.b}");
// Notice that `myStruct` is not changed outside the function

// TODO: Create an object instance of a class (which is a reference type)
// Creating an instance of the class 'MyClass'
MyClass myClass = new MyClass(); 
myClass.a = 5;
myClass.b = false;
Console.WriteLine($"Class before modification: {myClass.a}, {myClass.b}");

// Perform an operation on the class
void ClassOp(MyClass theClass) {
    // Modify some of the properties of the class inside the function
    theClass.a = 10;
    theClass.b = true;
    Console.WriteLine($"Class inside function: {theClass.a}, {theClass.b}");
}

// Objects are passed by reference, since they are reference types:
Console.WriteLine($"Class before function call: {myClass.a}, {myClass.b}");
ClassOp(myClass); // The class is passed by reference
Console.WriteLine($"Class after function call: {myClass.a}, {myClass.b}");
// Notice that `myClass` is changed outside the function

// These are declared at the bottom of the file because C# requires
// top-level statements to come before type declarations
class MyClass {
    public int a;    // Integer field in the class
    public bool b;   // Boolean field in the class
}

struct s {
    public int a;    // Integer field in the struct
    public bool b;   // Boolean field in the struct
}
