// See https://aka.ms/new-console-template for more information
using System;

namespace Mathematical
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# Mathematical Operator
            int a = 10, b = 3;
            Console.WriteLine($"{a}+{b}={a+b}");
            Console.WriteLine($"{a}-{b}={a-b}");
            Console.WriteLine($"{a}*{b}={a*b}");
            Console.WriteLine($"{a}/{b}={a/b}");
            Console.WriteLine($"{a}%{b}={a%b}");

            float f = 11.0f;
            Console.WriteLine($"{f}/{b}={f/b}");
            Console.WriteLine($"{f}%{b}={f%b}");
        }
    }
}
