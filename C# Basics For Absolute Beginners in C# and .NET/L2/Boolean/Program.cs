// See https://aka.ms/new-console-template for more information
using System;

namespace Boolean
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b;
            b = true;

            Console.WriteLine(b);
            b = bool.Parse(Console.ReadLine()); // Can be any case
            Console.WriteLine(b);
        }
    }
}
