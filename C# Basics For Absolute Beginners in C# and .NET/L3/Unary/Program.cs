// See https://aka.ms/new-console-template for more information
using System;

namespace Unary
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# Unary operator
            int a, b;
            a = 10;
            b = ++a;
            Console.WriteLine($"Prefix ++, a={a}, b={b}");

            a = 10;
            b = a++;
            Console.WriteLine($"Suffix ++, a={a}, b={b}");
        }
    }
}
