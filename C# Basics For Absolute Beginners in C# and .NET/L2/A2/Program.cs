using System;

namespace A2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1
            // Write C# code snippet to declare a character and assign value 'C'. 
            // Print the same to the Console.
            char c = 'c';
            Console.WriteLine(c);

            // Exercise 2
            // Write C# code snippet to read a name as string from console
            // and print "Hello, " along with the name to the Console.
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name);
            

            // Exercise 3
            // Rewrite the solution of Exercise 2 to use string interpolation ('$')
            // to combine two strings instead of using the '+' symbol. 
            Console.WriteLine($"Hello, {name}");


        }
    }
}
