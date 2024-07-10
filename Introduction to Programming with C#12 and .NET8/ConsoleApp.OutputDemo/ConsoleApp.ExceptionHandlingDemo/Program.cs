// See https://aka.ms/new-console-template for more information

// write a program that takes a user's age as input and print it to the screen
// Display an error message if an invalid input is received

try
{
    Console.WriteLine("Enter your age: ");
    int age = Convert.ToInt32(Console.ReadLine());   
    Console.WriteLine($"You are {age} years old");
}
catch (Exception)
{
    Console.WriteLine("An error occurred");
    // throw;
}
finally
{
    Console.WriteLine("Thanks for using this program");
}