// See https://aka.ms/new-console-template for more information

// Initialize with a regular string literal
string s1 = "This is a literal string";
String s2 = "This is a literal string";
// This 2 writeline return same result
Console.WriteLine($"s1: {s1}");
Console.WriteLine($"{nameof(s1)}: {s1}");

// Declare without initializing (possible null exception)
string s3;
// Console.WriteLine(s3); // Syntax error, s3 needs a value before it can be used

// Initialize to null (possible null exception)
string? s4 = null;

// Initialize as an empty string
string s5 = string.Empty; // ""
string s6 = "";

// Escape sequences and characters
string sentence = "She said, \"I have your phone\"";
string sentence2 = "She said, \'I have your phone\'";
string sentence3 = "She said, \'I have your phone\' \r\n This is the next line";

// Verbatim string literal
string oldPath = "C:\\program files\\programfolder\\";
string newPath = @"C:\program files\programfolder\";

// Use a const string to prevent modification to a string
const string path = "C:\\program files\\programfolder\\";
// path = "hello" // Cannot modify const

// Raw string literal
string rawLiteral = """ abc \svla, "I have your phone" """;
string rawLiteral1 = """ 
abc \svla, "I have your phone" 
This is a next line
""";

// Review concatenation and interpolation
// Bad Practice (Instead of modifying s1, 
// you accidentally create new instance for s1 => cost more memory)
s1 = s1 + s2;
s1 += s2;
string newString = $"{s1} {s2} Some string";
string newString2 = String.Format("Literal string {0}, {1}", s1, s2);

/* String manipulation methods */
// Substrings
string subString = s1.Substring(5);
Console.WriteLine($"{nameof(subString)}: {subString}");
subString = s1.Substring(5,5);
Console.WriteLine($"{nameof(subString)}: {subString}");

// Null or Empty Checks
// Find the length of a string
Console.WriteLine($"{nameof(s1)} has a length of {s1.Length}");
// Console.WriteLine($"{nameof(s4)} has a length of {s4.Length}"); // Warning: s4 may be null
// Console.WriteLine($"{nameof(s3)} has a length of {s3.Length}"); // Error: s3 is not assigned value
if (!string.IsNullOrEmpty(s4)) {
    Console.WriteLine($"{nameof(s4)} has a length of {s4.Length}");
}

// Splitting String 
var splitString = s2.Split(' ');  // Using var if you not sure what type of data variable you will need
for (int i = 0; i < splitString.Length; i++) {
    Console.WriteLine(splitString[i]);
}

// Replace
string replacements1 = s1.Replace('s', 'V');
string replacements2 = s1.Replace("string", "chicken");
Console.WriteLine($"{nameof(replacements1)}: {replacements1}");
Console.WriteLine($"{nameof(replacements2)}: {replacements2}");

// Convert to String
string salary = 123.45.ToString();
int value = 123;
string strValue = value.ToString();
bool chosen = true;
chosen.ToString();

// Changing Formating (In this example, adding currency)
Console.WriteLine($"{nameof(salary)}: {salary:C}"); // Not working, since salary is already a string => cannot change
// Working, since value is not a string
Console.WriteLine($"{nameof(salary)}: {value:C}"); 
Console.WriteLine(nameof(salary) + ": " + value.ToString("C"));