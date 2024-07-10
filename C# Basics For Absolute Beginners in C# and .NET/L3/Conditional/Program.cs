// See https://aka.ms/new-console-template for more information
using System;

namespace Conditional
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# Conditional Operators
            bool a = false;
            bool b = true;
            Console.WriteLine($"a, b: {a}, {b}");
            Console.WriteLine($"a||b: {a || b}");
            Console.WriteLine($"a&&b: {a && b}");
        }
    }
}
