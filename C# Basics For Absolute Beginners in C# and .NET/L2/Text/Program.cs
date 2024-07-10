// See https://aka.ms/new-console-template for more information
using System;

namespace Text
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# Character
            char c = 'a';
            int sizeChar = sizeof(char);
            Console.WriteLine($"Character: {c}");
            Console.WriteLine($"Char size: {sizeChar}");

            // C# String
            string s = "abc"; // Literal
            Console.WriteLine(s);
            string s2 = @"c:\myfolder\test.txt"; // Verbatim
            Console.WriteLine(s2);
            string s3 = $"Hello {s}"; // Interpolated
            Console.WriteLine(s3);

        }
    }
}