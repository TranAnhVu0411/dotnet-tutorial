// See https://aka.ms/new-console-template for more information
// Declare variable
string? name = string.Empty; // intialize empty string
int age = 0, retirementAge = 65;
decimal salary = 0;
char gender = char.MinValue;
bool working;

// Prompt the user for input
Console.WriteLine("Please enter your name");
name = Console.ReadLine();

Console.WriteLine("Please enter your age");
age = Convert.ToInt32(Console.ReadLine());

// Will have a logical error since 
// Convert.ToInt32 only accept integer only
Console.WriteLine("Please enter your salary");
salary = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Please enter your gender (M, F)");
gender = Convert.ToChar(Console.ReadLine());

Console.WriteLine("Please enter your working status, (true, false)");
working = Convert.ToBoolean(Console.ReadLine());

// Process the data
int workingYearsRemaning = retirementAge - age;

// Output results
Console.WriteLine($"Full name: {name}");
Console.WriteLine($"Age : {age}");
Console.WriteLine($"Working years Remaining: {workingYearsRemaning}");
Console.WriteLine($"Salary: {salary}");
Console.WriteLine($"Gender : {gender}");
Console.WriteLine($"Are Working? {working}");
